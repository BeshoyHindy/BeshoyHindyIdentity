using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.DataModels;
using DAL.Extensions;
using DAL.Repositories;
using System.Configuration;
using System.IO;

namespace WebGUI.AdminPanale.MainPages
{
    public partial class WorkTypeManagement : System.Web.UI.Page
    {
        #region Variables
        WorkTypeRepository _objRepository;
        #endregion
        #region Property
        public string WorkTypeId
        {
            set { ViewState["WorkTypeId"] = value; }
            get { return ViewState["WorkTypeId"] == null ? string.Empty : ViewState["WorkTypeId"].ToString(); }
        }
        #endregion
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                WorkTypeId = Request.QueryString["ID"].ToString();
            }
            if (!IsPostBack)
            {
                GetInfo();
                MasterPages.Pages.PageTitle = "WorkType";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            GetInfo();

        }

        protected void btnSaveAndNew_Click(object sender, EventArgs e)
        {
            Save();
            Response.Redirect("~/AdminPanale/MainPages/WorkTypeManagement.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPanale/MainPages/WorkTypeList.aspx");
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        #endregion
        #region Methods
        private void Save()
        {
            _objRepository = new WorkTypeRepository();
            #region Manage Item

            _objRepository._Obj.TypeName = txtTypeName.Text;
            _objRepository._Obj.ClassName = txtClassName.Text;

            if (string.IsNullOrEmpty(WorkTypeId))
            {
                _objRepository._Obj.CreatedBy = new Guid(Request.Cookies["CooLoginUserId"].Value);
               
                WorkTypeId = _objRepository.Add().ToString();
            }
            else
            {
                _objRepository._Obj = _objRepository.LoadByWorkTypeId(WorkTypeId);

                _objRepository._Obj.TypeName = txtTypeName.Text;
                _objRepository._Obj.ClassName = txtClassName.Text;

                _objRepository._Obj.ModifiedBy = new Guid(Request.Cookies["CooLoginUserId"].Value);

                if (_objRepository.Edit())
                {
                    lblMessage.Text = "Done, changes has been saved successfully!";
                    divMessage.Attributes["class"] = "alert-success";
                    divMessage.Visible = true;
                }
                else
                {
                    lblMessage.Text = "Error, Please try again later!";
                    divMessage.Attributes["class"] = "alert-error";
                    divMessage.Visible = true;

                }
            }
            #endregion
        }
        private void GetInfo()
        {

            if (!string.IsNullOrEmpty(WorkTypeId))
            {
                _objRepository = new WorkTypeRepository();

                WorkType WorkTypeEnt = _objRepository.LoadByWorkTypeId(WorkTypeId);

                if (WorkTypeEnt != null)
                {
                    txtTypeName.Text = WorkTypeEnt.TypeName;
                    txtClassName.Text = WorkTypeEnt.ClassName;
                }
            }

        }
        private void Clear()
        {
            txtTypeName.Text =
            txtClassName.Text =
            String.Empty;
        }
        #endregion
    }
}