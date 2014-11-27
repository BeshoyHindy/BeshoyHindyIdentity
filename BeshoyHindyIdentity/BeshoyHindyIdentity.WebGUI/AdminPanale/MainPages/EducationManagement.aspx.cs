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
    public partial class EducationManagement : System.Web.UI.Page
    {
        #region Variables
        EducationRepository _objRepository;
        #endregion
        #region Property
        public string EducationId
        {
            set { ViewState["EducationId"] = value; }
            get { return ViewState["EducationId"] == null ? string.Empty : ViewState["EducationId"].ToString(); }
        }
        #endregion
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                EducationId = Request.QueryString["ID"].ToString();
            }
            if (!IsPostBack)
            {
                GetInfo();
                MasterPages.Pages.PageTitle = "Education";
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
            Response.Redirect("~/AdminPanale/MainPages/EducationMaganagement.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPanale/MainPages/EducationList.aspx");
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        #endregion
        #region Methods
        private void Save()
        {
            _objRepository = new EducationRepository();
            #region Manage Item

            _objRepository._Obj.Title = txtTitle.Text;
            _objRepository._Obj.Institute = txtInstitute.Text;
            _objRepository._Obj.Description = txtDescription.Text;
            _objRepository._Obj.DateFrom = txtDateFrom.Text;
            _objRepository._Obj.DateTo = txtDateTo.Text;

            if (string.IsNullOrEmpty(EducationId))
            {
                _objRepository._Obj.CreatedBy = new Guid(Request.Cookies["CooLoginUserId"].Value);

                EducationId = _objRepository.Add().ToString();
            }
            else
            {
                _objRepository._Obj = _objRepository.LoadByEducationId(EducationId);

                _objRepository._Obj.Title = txtTitle.Text;
                _objRepository._Obj.Institute = txtInstitute.Text;
                _objRepository._Obj.Description = txtDescription.Text;
                _objRepository._Obj.DateFrom = txtDateFrom.Text;
                _objRepository._Obj.DateTo = txtDateTo.Text;

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

            if (!string.IsNullOrEmpty(EducationId))
            {
                _objRepository = new EducationRepository();

                Education EducationEnt = _objRepository.LoadByEducationId(EducationId);

                if (EducationEnt != null)
                {
                    txtTitle.Text = EducationEnt.Title;
                    txtInstitute.Text = EducationEnt.Institute;
                    txtDescription.Text = EducationEnt.Description;
                    txtDateFrom.Text = EducationEnt.DateFrom;
                    txtDateTo.Text = EducationEnt.DateTo;
                }
            }

        }
        private void Clear()
        {
            txtTitle.Text =
            txtInstitute.Text =
            txtDescription.Text =
            txtDateFrom.Text =
            txtDateTo.Text =
            String.Empty;
        }
        #endregion
    }
}