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
    public partial class ResumeManagement : System.Web.UI.Page
    {
        #region Variables
        ResumeRepository _objRepository;
        #endregion
        #region Property
        public string ResumeId
        {
            set { ViewState["ResumeId"] = value; }
            get { return ViewState["ResumeId"] == null ? string.Empty : ViewState["ResumeId"].ToString(); }
        }
        #endregion
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                ResumeId = Request.QueryString["ID"].ToString();
            }
            if (!IsPostBack)
            {
                GetInfo();
                MasterPages.Pages.PageTitle = "Resume";
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
            Response.Redirect("~/AdminPanale/MainPages/ResumeManagement.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPanale/MainPages/ResumeList.aspx");
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        #endregion
        #region Methods
        private void Save()
        {
            _objRepository = new ResumeRepository();
            #region Manage Item

            _objRepository._Obj.JobTitle = txtJobTitle.Text;
            _objRepository._Obj.JobDescription = txtJobDescription.Text;
            _objRepository._Obj.JobPosition = txtJobPosition.Text;
            _objRepository._Obj.CompanyName = txtCompanyName.Text;
            _objRepository._Obj.DateFrom = txtDateFrom.Text;
            _objRepository._Obj.DateTo = txtDateTo.Text;


            if (string.IsNullOrEmpty(ResumeId))
            {
                _objRepository._Obj.CreatedBy = new Guid(Request.Cookies["CooLoginUserId"].Value);

                ResumeId = _objRepository.Add().ToString();
            }
            else
            {
                _objRepository._Obj = _objRepository.LoadByResumeId(ResumeId);

                _objRepository._Obj.JobTitle = txtJobTitle.Text;
                _objRepository._Obj.JobDescription = txtJobDescription.Text;
                _objRepository._Obj.JobPosition = txtJobPosition.Text;
                _objRepository._Obj.CompanyName = txtCompanyName.Text;
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

            if (!string.IsNullOrEmpty(ResumeId))
            {
                _objRepository = new ResumeRepository();

                Resume ResumeEnt = _objRepository.LoadByResumeId(ResumeId);

                if (ResumeEnt != null)
                {
                    txtJobTitle.Text = ResumeEnt.JobTitle;
                    txtJobDescription.Text = ResumeEnt.JobDescription;
                    txtJobPosition.Text = ResumeEnt.JobPosition;
                    txtCompanyName.Text = ResumeEnt.CompanyName;
                    txtDateFrom.Text = ResumeEnt.DateFrom;
                    txtDateTo.Text = ResumeEnt.DateTo;
                }
            }

        }
        private void Clear()
        {
            txtJobTitle.Text =
            txtJobDescription.Text =
            txtJobPosition.Text =
            txtCompanyName.Text =
            txtDateFrom.Text =
            txtDateTo.Text =
            String.Empty;
        }
        #endregion
    }
}