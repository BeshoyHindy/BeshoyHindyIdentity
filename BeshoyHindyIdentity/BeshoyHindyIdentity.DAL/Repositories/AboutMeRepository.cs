using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.DataModels;
using DAL.Extensions;

namespace DAL.Repositories
{
    public class AboutMeRepository
    {
        #region Variables
        DBDataContext db;
        public AboutMe _Obj { get; set; }
        #endregion
        #region Methods
        public AboutMeRepository()
        {
            db = new DBDataContext();
            _Obj = new AboutMe();
        }
        public Guid Add()
        {
            _Obj.Id = Guid.NewGuid(); //get next or new id
            _Obj.Active = true;
            _Obj.RecOrder = LoadItemsCount(true) + 1;
            _Obj.CreatedOn = DateTime.Now;
            db.AboutMes.Add(_Obj);
            db.SaveChanges();
            return _Obj.Id;
        }
        public Boolean Edit(AboutMe AboutMePram)
        {
            try
            {
                _Obj = db.AboutMes.FirstOrDefault(usr => usr.Id == AboutMePram.Id);
                if (_Obj != null)
                {
                    _Obj = AboutMePram;
                    _Obj.ModifiedOn = DateTime.Now;
                    _Obj.ModifiedBy = AboutMePram.ModifiedBy;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Boolean Edit()
        {
            try
            {
                if (_Obj != null)
                {
                    _Obj.ModifiedOn = DateTime.Now;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Boolean Delete(Guid ID, Guid ModifiedBy)
        {
            try
            {
                _Obj = db.AboutMes.FirstOrDefault(use => use.Id == ID);
                if (_Obj != null)
                {
                    ShiftRecords((Int32)_Obj.RecOrder, true);
                    _Obj.RecOrder = LoadItemsCount(false) + 1;
                    _Obj.ModifiedOn = DateTime.Now;
                    _Obj.ModifiedBy = ModifiedBy;
                    _Obj.Active = false;
                    db.SaveChanges();
                    return true;
                }
                return false;

            }
            catch (Exception Ex)
            {
                return false;
            }
        }
        public Boolean Restore(Guid ID, Guid ModifiedBy)
        {
            try
            {
                _Obj = db.AboutMes.FirstOrDefault(use => use.Id == ID);
                if (_Obj != null)
                {
                    ShiftRecords((Int32)_Obj.RecOrder, false);
                    _Obj.RecOrder = LoadItemsCount(true) + 1;
                    _Obj.ModifiedOn = DateTime.Now;
                    _Obj.ModifiedBy = ModifiedBy;
                    _Obj.Active = false;
                    db.SaveChanges();
                    return true;
                }
                return false;

            }
            catch (Exception Ex)
            {
                return false;
            }
        }
        public DataTable LoadByActiveState(AboutMe AboutMePram, String SortField, String SortType)
        {
            try
            {
                if (AboutMePram.Id != null)
                {
                    var Query = (from usr in db.AboutMes
                                 where usr.Active == AboutMePram.Active && usr.Id == AboutMePram.Id
                                 select usr);
                    return Query.ToDataTable(SortField, SortType);

                }
                else if (AboutMePram.Id == null)
                {
                    return null;
                }
                return null;

            }
            catch (Exception Ex)
            {
                return null;
            }

        }
        public DataTable LoadByActiveState(Boolean ActiveStatePram, String SortField = "RecOrder", String SortType = "ASC")
        {
            try
            {
                var Query = (from usr in db.AboutMes
                             where usr.Active == ActiveStatePram
                             select usr);
                return Query.ToDataTable(SortField, SortType);
            }
            catch (Exception Ex)
            {
                return null;
            }
        }

        public AboutMe LoadByAboutMe(AboutMe AboutMePram)
        {
            if (AboutMePram != null)
            {
                _Obj = db.AboutMes.FirstOrDefault(usr => usr.Id == AboutMePram.Id);
                return _Obj;
            }
            return null;
        }
        public AboutMe LoadByAboutMe(Boolean ActiveStatePram = true)
        {
            _Obj = db.AboutMes.OrderBy(ordr => ordr.RecOrder).FirstOrDefault(itm => itm.Active == ActiveStatePram);
            return _Obj;
        }

        public AboutMe LoadByAboutMeId(String AboutMeIdPram)
        {
            if (AboutMeIdPram != null)
            {
                _Obj = db.AboutMes.FirstOrDefault(usr => usr.Id == new Guid(AboutMeIdPram));
                return _Obj;
            }
            return null;
        }


        #endregion
        #region Shift Records
        public Int32 LoadItemsCount(Boolean ActiveStatePram)
        {
            return (from Obj in db.AboutMes
                    where Obj.Active == ActiveStatePram
                    select Obj.Id).Count();
        }
        public AboutMe LoadByOrder(Int32 Order, Boolean ActiveStatePram)
        {
            return db.AboutMes.FirstOrDefault(o => o.RecOrder == Order && o.Active == ActiveStatePram);
        }
        public String ReOrder(String AboutMeId, Boolean Incre, String ModifiedBy, Boolean ActiveStatePram)
        {
            // try
            {
                AboutMe Obj = db.AboutMes.FirstOrDefault(o => o.Id == new Guid(AboutMeId));
                if (Obj != null)
                {

                    //Calc Current and New Order
                    Int32 CurrentOrder = Int32.Parse(Obj.RecOrder.ToString());
                    Int32 NewOrder = 1;

                    if (Incre) { NewOrder = CurrentOrder - 1; }
                    else { NewOrder = CurrentOrder + 1; }

                    //Update the Up / Down Record
                    AboutMe obj2 = LoadByOrder(NewOrder, ActiveStatePram);
                    if (obj2 != null)
                    {
                        obj2.RecOrder = CurrentOrder;
                        obj2.ModifiedOn = DateTime.Now;
                        obj2.ModifiedBy = new Guid(ModifiedBy);
                    }
                    else
                    {
                        if (Incre) { CurrentOrder--; }
                        else { CurrentOrder++; }
                    }

                    //Update this record
                    Obj.RecOrder = NewOrder;
                    Obj.ModifiedBy = new Guid(ModifiedBy);
                    Obj.ModifiedOn = DateTime.Now;

                    db.SaveChanges();
                    return obj2.Id.ToString();
                }
                return String.Empty;
            }
            //catch (Exception ex)
            //{
            //    return String.Empty;
            //}
        }
        public Boolean ShiftRecords(Int32 currentOrder, Boolean ActiveStatePram)// delete & restore
        {
            try
            {
                Int32 RowsCount = LoadItemsCount(ActiveStatePram);
                AboutMe[] ObjArr = new AboutMe[RowsCount - currentOrder];
                for (Int32 k = 0, i = currentOrder + 1; i <= RowsCount; i++, k++)
                {
                    ObjArr[k] = LoadByOrder(i, ActiveStatePram);
                    if (ObjArr[k] != null)
                        ObjArr[k].RecOrder = ObjArr[k].RecOrder - 1;
                }
                db.SaveChanges();
                return true;
            }
            catch { return true; }
        }
        public Boolean IsFirestRec(String IdPram, Boolean ActiveStatePram)
        {
            //Int32 RowsCount = LoadItemsCount(ActiveStatePram);
            //Int32 CurrentRec = (Int32)LoadByAboutMeId(IdPram).RecOrder;
            //if (RowsCount - CurrentRec == RowsCount - 1)
            //{
            //    return true;
            //}
            //else return false;

            Int32 CurrentRec = (Int32)LoadByAboutMeId(IdPram).RecOrder;
            if (CurrentRec == 1 || LoadItemsCount(ActiveStatePram) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public Boolean IsLastRec(String IdPram, Boolean ActiveStatePram)
        {
            Int32 RowsCount = LoadItemsCount(ActiveStatePram);
            Int32 CurrentRec = (Int32)LoadByAboutMeId(IdPram).RecOrder;
            if (RowsCount - CurrentRec == 0)
            {
                return true;
            }
            else return false;
        }
        public Boolean MoveUp(String IdPram, Boolean ActiveStatePram)
        {
            if (!IsFirestRec(IdPram, ActiveStatePram))
            {
                AboutMe CurrentRow = LoadByAboutMeId(IdPram);
                AboutMe UpperRow = LoadByOrder((Int32)CurrentRow.RecOrder - 1, ActiveStatePram);
                int CurrentRec = (int)CurrentRow.RecOrder;
                int UpperRec = (int)UpperRow.RecOrder;

                CurrentRow.RecOrder = UpperRec;
                UpperRow.RecOrder = CurrentRec;
                db.SaveChanges();
                return true;

            }
            else
            {
                return false;
            }
        }
        public Boolean MoveDown(String IdPram, Boolean ActiveStatePram)
        {
            if (!IsLastRec(IdPram, ActiveStatePram))
            {
                AboutMe CurrentRow = LoadByAboutMeId(IdPram);
                AboutMe BottomRow = LoadByOrder((Int32)CurrentRow.RecOrder + 1, ActiveStatePram);
                int CurrentRec = (int)CurrentRow.RecOrder;
                int BottomRec = (int)BottomRow.RecOrder;

                CurrentRow.RecOrder = BottomRec;
                BottomRow.RecOrder = CurrentRec;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

    }

}
