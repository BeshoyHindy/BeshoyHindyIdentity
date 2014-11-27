using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.DataModels;
using DAL.Extensions;
using System.Collections;

namespace DAL.Repositories
{
    public class GeneralSkillRepository
    {
        #region Variables
        DBDataContext db;
        public GeneralSkill _Obj { get; set; }
        #endregion
        #region Methods
        public GeneralSkillRepository()
        {
            db = new DBDataContext();
            _Obj = new GeneralSkill();
        }
        public Guid Add()
        {
            _Obj.Id = Guid.NewGuid(); //get next or new id
            _Obj.Active = true;
            _Obj.RecOrder = LoadItemsCount(true) + 1;
            _Obj.CreatedOn = DateTime.Now;
            db.GeneralSkills.Add(_Obj);
            db.SaveChanges();
            return _Obj.Id;
        }
        public Boolean Edit(GeneralSkill GeneralSkillPram)
        {
            try
            {
                _Obj = db.GeneralSkills.FirstOrDefault(usr => usr.Id == GeneralSkillPram.Id);
                if (_Obj != null)
                {
                    _Obj = GeneralSkillPram;
                    _Obj.ModifiedOn = DateTime.Now;
                    _Obj.ModifiedBy = GeneralSkillPram.ModifiedBy;
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
                _Obj = db.GeneralSkills.FirstOrDefault(use => use.Id == ID);
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
                _Obj = db.GeneralSkills.FirstOrDefault(use => use.Id == ID);
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
        public DataTable LoadByActiveState(GeneralSkill GeneralSkillPram, String SortField, String SortType)
        {
            try
            {
                if (GeneralSkillPram.Id != null)
                {
                    var Query = (from usr in db.GeneralSkills
                                 where usr.Active == GeneralSkillPram.Active && usr.Id == GeneralSkillPram.Id
                                 select usr);
                    return Query.ToDataTable(SortField, SortType);

                }
                else if (GeneralSkillPram.Id == null)
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
                var Query = (from usr in db.GeneralSkills
                             where usr.Active == ActiveStatePram
                             select usr);
                return Query.ToDataTable(SortField, SortType);
            }
            catch (Exception Ex)
            {
                return null;
            }

        }
        public DataTable LoadOdds()
        {
            var OddsQuery = (from odd in db.GeneralSkills
                             where odd.Active == true
                             select odd).ToList().Where((item, index) => index % 2 == 0).ToDataTable("RecOrder", "ASC");
            return OddsQuery;
        }
        public DataTable LoadEvens()
        {
            var EvensQuery = (from even in db.GeneralSkills
                              where even.Active == true
                              select even).ToList().Where((item, index) => index % 2 != 0).ToDataTable("RecOrder", "ASC");
            return EvensQuery;
        }

        public GeneralSkill LoadByGeneralSkill(GeneralSkill GeneralSkillPram)
        {
            if (GeneralSkillPram != null)
            {
                _Obj = db.GeneralSkills.FirstOrDefault(usr => usr.Id == GeneralSkillPram.Id);
                return _Obj;
            }
            return null;
        }
        public GeneralSkill LoadByGeneralSkillId(String GeneralSkillIdPram)
        {
            if (GeneralSkillIdPram != null)
            {
                _Obj = db.GeneralSkills.FirstOrDefault(usr => usr.Id == new Guid(GeneralSkillIdPram));
                return _Obj;
            }
            return null;
        }


        #endregion
        #region Shift Records
        public Int32 LoadItemsCount(Boolean ActiveStatePram)
        {
            return (from Obj in db.GeneralSkills
                    where Obj.Active == ActiveStatePram
                    select Obj.Id).Count();
        }
        public GeneralSkill LoadByOrder(Int32 Order, Boolean ActiveStatePram)
        {
            return db.GeneralSkills.FirstOrDefault(o => o.RecOrder == Order && o.Active == ActiveStatePram);
        }
        public String ReOrder(String GeneralSkillId, Boolean Incre, String ModifiedBy, Boolean ActiveStatePram)
        {
            // try
            {
                GeneralSkill Obj = db.GeneralSkills.FirstOrDefault(o => o.Id == new Guid(GeneralSkillId));
                if (Obj != null)
                {

                    //Calc Current and New Order
                    Int32 CurrentOrder = Int32.Parse(Obj.RecOrder.ToString());
                    Int32 NewOrder = 1;

                    if (Incre) { NewOrder = CurrentOrder - 1; }
                    else { NewOrder = CurrentOrder + 1; }

                    //Update the Up / Down Record
                    GeneralSkill obj2 = LoadByOrder(NewOrder, ActiveStatePram);
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
                GeneralSkill[] ObjArr = new GeneralSkill[RowsCount - currentOrder];
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
            //Int32 CurrentRec = (Int32)LoadByGeneralSkillId(IdPram).RecOrder;
            //if (RowsCount - CurrentRec == RowsCount - 1)
            //{
            //    return true;
            //}
            //else return false;

            Int32 CurrentRec = (Int32)LoadByGeneralSkillId(IdPram).RecOrder;
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
            Int32 CurrentRec = (Int32)LoadByGeneralSkillId(IdPram).RecOrder;
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
                GeneralSkill CurrentRow = LoadByGeneralSkillId(IdPram);
                GeneralSkill UpperRow = LoadByOrder((Int32)CurrentRow.RecOrder - 1, ActiveStatePram);
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
                GeneralSkill CurrentRow = LoadByGeneralSkillId(IdPram);
                GeneralSkill BottomRow = LoadByOrder((Int32)CurrentRow.RecOrder + 1, ActiveStatePram);
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
