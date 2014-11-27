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
    public class SoftwareSkillRepository
    {
        #region Variables
        DBDataContext db;
        public SoftwareSkill _Obj { get; set; }
        #endregion
        #region Methods
        public SoftwareSkillRepository()
        {
            db = new DBDataContext();
            _Obj = new SoftwareSkill();
        }
        public Guid Add()
        {
            _Obj.Id = Guid.NewGuid(); //get next or new id
            _Obj.Active = true;
            _Obj.RecOrder = LoadItemsCount(true) + 1;
            _Obj.CreatedOn = DateTime.Now;
            db.SoftwareSkills.Add(_Obj);
            db.SaveChanges();
            return _Obj.Id;
        }
        public Boolean Edit(SoftwareSkill SoftwareSkillPram)
        {
            try
            {
                _Obj = db.SoftwareSkills.FirstOrDefault(usr => usr.Id == SoftwareSkillPram.Id);
                if (_Obj != null)
                {
                    _Obj = SoftwareSkillPram;
                    _Obj.ModifiedOn = DateTime.Now;
                    _Obj.ModifiedBy = SoftwareSkillPram.ModifiedBy;
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
                _Obj = db.SoftwareSkills.FirstOrDefault(use => use.Id == ID);
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
                _Obj = db.SoftwareSkills.FirstOrDefault(use => use.Id == ID);
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
        public DataTable LoadByActiveState(SoftwareSkill SoftwareSkillPram, String SortField, String SortType)
        {
            try
            {
                if (SoftwareSkillPram.Id != null)
                {
                    var Query = (from usr in db.SoftwareSkills
                                 where usr.Active == SoftwareSkillPram.Active && usr.Id == SoftwareSkillPram.Id
                                 select usr);
                    return Query.ToDataTable(SortField, SortType);

                }
                else if (SoftwareSkillPram.Id == null)
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
                    var Query = (from usr in db.SoftwareSkills
                                 where usr.Active == ActiveStatePram
                                 select usr);
                    return Query.ToDataTable(SortField, SortType);
            }
            catch (Exception Ex)
            {
                return null;
            }

        }

        public SoftwareSkill LoadBySoftwareSkill(SoftwareSkill SoftwareSkillPram)
        {
            if (SoftwareSkillPram != null)
            {
                _Obj = db.SoftwareSkills.FirstOrDefault(usr => usr.Id == SoftwareSkillPram.Id);
                return _Obj;
            }
            return null;
        }
        public SoftwareSkill LoadBySoftwareSkillId(String SoftwareSkillIdPram)
        {
            if (SoftwareSkillIdPram != null)
            {
                _Obj = db.SoftwareSkills.FirstOrDefault(usr => usr.Id == new Guid(SoftwareSkillIdPram));
                return _Obj;
            }
            return null;
        }


        #endregion
        #region Shift Records
        public Int32 LoadItemsCount(Boolean ActiveStatePram)
        {
            return (from Obj in db.SoftwareSkills
                    where Obj.Active == ActiveStatePram
                    select Obj.Id).Count();
        }
        public SoftwareSkill LoadByOrder(Int32 Order, Boolean ActiveStatePram)
        {
            return db.SoftwareSkills.FirstOrDefault(o => o.RecOrder == Order && o.Active == ActiveStatePram);
        }
        public String ReOrder(String SoftwareSkillId, Boolean Incre, String ModifiedBy, Boolean ActiveStatePram)
        {
            // try
            {
                SoftwareSkill Obj = db.SoftwareSkills.FirstOrDefault(o => o.Id == new Guid(SoftwareSkillId));
                if (Obj != null)
                {

                    //Calc Current and New Order
                    Int32 CurrentOrder = Int32.Parse(Obj.RecOrder.ToString());
                    Int32 NewOrder = 1;

                    if (Incre) { NewOrder = CurrentOrder - 1; }
                    else { NewOrder = CurrentOrder + 1; }

                    //Update the Up / Down Record
                    SoftwareSkill obj2 = LoadByOrder(NewOrder, ActiveStatePram);
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
                SoftwareSkill[] ObjArr = new SoftwareSkill[RowsCount - currentOrder];
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
            //Int32 CurrentRec = (Int32)LoadBySoftwareSkillId(IdPram).RecOrder;
            //if (RowsCount - CurrentRec == RowsCount - 1)
            //{
            //    return true;
            //}
            //else return false;

            Int32 CurrentRec = (Int32)LoadBySoftwareSkillId(IdPram).RecOrder;
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
            Int32 CurrentRec = (Int32)LoadBySoftwareSkillId(IdPram).RecOrder;
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
                SoftwareSkill CurrentRow = LoadBySoftwareSkillId(IdPram);
                SoftwareSkill UpperRow = LoadByOrder((Int32)CurrentRow.RecOrder - 1, ActiveStatePram);
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
                SoftwareSkill CurrentRow = LoadBySoftwareSkillId(IdPram);
                SoftwareSkill BottomRow = LoadByOrder((Int32)CurrentRow.RecOrder + 1, ActiveStatePram);
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
