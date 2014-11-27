using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.Extensions;
using DAL.DataModels;

namespace DAL.Repositories
{
    public class AdminRepository
    {
        #region Variables
        DBDataContext db;
        public Admin _Obj { get; set; }
        #endregion
        #region Methods
        public AdminRepository()
        {
            db = new DBDataContext();
            _Obj = new Admin();
        }
        public Guid Add()
        {
            _Obj.Id = Guid.NewGuid(); //get next or new id
            _Obj.Active = true;
            _Obj.RecOrder = LoadItemsCount(true) + 1;
            _Obj.CreatedOn = DateTime.Now;
            _Obj.ModifiedOn = DateTime.Now;
            db.Admins.Add(_Obj);
            db.SaveChanges();
            return _Obj.Id;
        }
        public Boolean Edit(Admin AdminPram)
        {
            try
            {
                _Obj = db.Admins.FirstOrDefault(usr => usr.Id == AdminPram.Id);
                if (_Obj != null)
                {
                    _Obj = AdminPram;
                    _Obj.ModifiedOn = DateTime.Now;
                    _Obj.ModifiedBy = AdminPram.ModifiedBy;
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
                _Obj = db.Admins.FirstOrDefault(use => use.Id == ID);
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
                _Obj = db.Admins.FirstOrDefault(use => use.Id == ID);
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
        public DataTable LoadByActiveState(Admin AdminPram, String SortField, String SortType)
        {
            try
            {
                if (AdminPram.Id != null)
                {
                    var Query = (from usr in db.Admins
                                 where usr.Active == AdminPram.Active && usr.Id == AdminPram.Id
                                 select usr);
                    return Query.ToDataTable(SortField, SortType);

                }
                else if (AdminPram.Id == null)
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
        public Admin LoadByAdmin(Admin AdminPram)
        {
            if (AdminPram != null)
            {
                _Obj = db.Admins.FirstOrDefault(usr => usr.Id == AdminPram.Id);
                return _Obj;
            }
            return null;
        }
        public Admin LoadByAdminId(String AdminIdPram)
        {
            if (AdminIdPram != null)
            {
                _Obj = db.Admins.FirstOrDefault(usr => usr.Id == new Guid(AdminIdPram));
                return _Obj;
            }
            return null;
        }

        public Admin LoginAdmin(Admin AdminPram, out Boolean loginAdmintate)
        {

            if (AdminPram != null)
            {
                loginAdmintate = true;
                return db.Admins.FirstOrDefault(admn => admn.Password == AdminPram.Password.ToString() && admn.LoginName == AdminPram.LoginName.ToString() && admn.Active == true);
            }
            else
            {
                loginAdmintate = false;
                return null;
            }

        }
        public String LoginUser(String LoginName, String Passowrd, out Boolean loginAdmintate)
        {
            _Obj = db.Admins.FirstOrDefault(admn => admn.LoginName == LoginName.Trim() && admn.Password == Passowrd.Trim() && admn.Active == true);

            //User Query = (from usr in db.Users
            //              where usr.LogInName == Username && usr.Password == Passowrd && usr.Active == true
            //              select usr).SingleOrDefault();

            if (_Obj != null)
            {
                loginAdmintate = true;
                return _Obj.Id.ToString();
            }
            else
            {
                loginAdmintate = false;
                return String.Empty;
            }
        }

        #endregion
        #region Shift Records
        public Int32 LoadItemsCount(Boolean ActiveStatePram)
        {
            return (from Obj in db.Admins
                    where Obj.Active == ActiveStatePram
                    select Obj.Id).Count();
        }
        public Admin LoadByOrder(Int32 Order, Boolean ActiveStatePram)
        {
            return db.Admins.FirstOrDefault(o => o.RecOrder == Order && o.Active == ActiveStatePram);
        }
        public String ReOrder(String AdminId, Boolean Incre, String ModifiedBy, Boolean ActiveStatePram)
        {
            // try
            {
                Admin Obj = db.Admins.FirstOrDefault(o => o.Id == new Guid(AdminId));
                if (Obj != null)
                {

                    //Calc Current and New Order
                    Int32 CurrentOrder = Int32.Parse(Obj.RecOrder.ToString());
                    Int32 NewOrder = 1;

                    if (Incre) { NewOrder = CurrentOrder - 1; }
                    else { NewOrder = CurrentOrder + 1; }

                    //Update the Up / Down Record
                    Admin obj2 = LoadByOrder(NewOrder, ActiveStatePram);
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
                Admin[] ObjArr = new Admin[RowsCount - currentOrder];
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
            //Int32 CurrentRec = (Int32)LoadByAdminId(IdPram).RecOrder;
            //if (RowsCount - CurrentRec == RowsCount - 1)
            //{
            //    return true;
            //}
            //else return false;

            Int32 CurrentRec = (Int32)LoadByAdminId(IdPram).RecOrder;
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
            Int32 CurrentRec = (Int32)LoadByAdminId(IdPram).RecOrder;
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
                Admin CurrentRow = LoadByAdminId(IdPram);
                Admin UpperRow = LoadByOrder((Int32)CurrentRow.RecOrder - 1, ActiveStatePram);
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
                Admin CurrentRow = LoadByAdminId(IdPram);
                Admin BottomRow = LoadByOrder((Int32)CurrentRow.RecOrder + 1, ActiveStatePram);
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
