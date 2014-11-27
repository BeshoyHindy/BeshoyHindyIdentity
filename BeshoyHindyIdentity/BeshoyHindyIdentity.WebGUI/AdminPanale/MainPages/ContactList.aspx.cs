﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebGUI;
using WebGUI.AdminPanale.MasterPages;
using DAL.Repositories;
using DAL.DataModels;
using DAL.Extensions;
using System.Data;

namespace WebGUI.AdminPanale.MainPages
{
    public partial class ContactList : System.Web.UI.Page
    {
        #region  Methods
        private void BindData()
        {
            MasterPages.Pages.PageTitle = "Conatcs";   // Set page title

            ContactRepository _ContactRepository = new ContactRepository();

            grdData.DataSource = _ContactRepository.LoadByActiveState(true);
            grdData.DataBind();
        }

        #endregion
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }

        }
        protected void grdData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ContactRepository _Obj = new ContactRepository();
            switch (e.CommandName)
            {
                case "restoreitem":
                    if (_Obj.Restore(new Guid(e.CommandArgument.ToString()), new Guid(Request.Cookies["CooLoginUserId"].Value)))
                    { grdData.DataBind(); }
                    break;
                case "deleteitem":
                    if (_Obj.Delete(new Guid(e.CommandArgument.ToString()), new Guid(Request.Cookies["CooLoginUserId"].Value)))
                    { grdData.DataBind(); }
                    break;
                case "MoveUp":
                    if (_Obj.MoveUp(e.CommandArgument.ToString(), true))
                    { BindData(); }
                    break;
                case "MoveDown":
                    if (_Obj.MoveDown(e.CommandArgument.ToString(), true))
                    { BindData(); }
                    break;
            }
        }
        protected void grdData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ContactRepository _Obj = new ContactRepository();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView row = (DataRowView)e.Row.DataItem;
                Button btnMoveUp = (Button)e.Row.FindControl("btnMoveUp");
                Button btnMoveDown = (Button)e.Row.FindControl("btnMoveDown");
                if (_Obj.IsFirestRec(row["Id"].ToString(), true))
                { btnMoveUp.Enabled = false; }

                if (_Obj.IsLastRec(row["Id"].ToString(), true))
                { btnMoveDown.Enabled = false; }
            }

        }
        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPanale/MainPages/ContactManagement.aspx");
        }

        #endregion


    }
}