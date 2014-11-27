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
    public partial class SoftwareSkillsManagement : System.Web.UI.Page
    {
        #region Variables
        SoftwareSkillRepository _objRepository;
        #endregion
        #region Property
        public string SoftwareSkillId
        {
            set { ViewState["SoftwareSkillId"] = value; }
            get { return ViewState["SoftwareSkillId"] == null ? string.Empty : ViewState["SoftwareSkillId"].ToString(); }
        }
        #endregion
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                SoftwareSkillId = Request.QueryString["ID"].ToString();
            }
            if (!IsPostBack)
            {
                GetInfo();
                MasterPages.Pages.PageTitle = "About Me";
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
            Response.Redirect("~/AdminPanale/MainPages/SoftwareSkillsMaganagement.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPanale/MainPages/SoftwareSkillsList.aspx");
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        #endregion
        #region Methods
        private void Save()
        {
            _objRepository = new SoftwareSkillRepository();
            #region Manage Item

            _objRepository._Obj.Title = txtTitle.Text;
            _objRepository._Obj.Description = txtDescription.Text;
            _objRepository._Obj.Percentage = int.Parse(txtPercentage.Text);


            if (string.IsNullOrEmpty(SoftwareSkillId))
            {
                _objRepository._Obj.CreatedBy = new Guid(Request.Cookies["CooLoginUserId"].Value);

                SoftwareSkillId = _objRepository.Add().ToString();
            }
            else
            {
                _objRepository._Obj = _objRepository.LoadBySoftwareSkillId(SoftwareSkillId);

                _objRepository._Obj.Title = txtTitle.Text;
                _objRepository._Obj.Description = txtDescription.Text;
                _objRepository._Obj.Percentage = int.Parse(txtPercentage.Text);

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

            if (!string.IsNullOrEmpty(SoftwareSkillId))
            {
                _objRepository = new SoftwareSkillRepository();

                SoftwareSkill SoftwareSkillEnt = _objRepository.LoadBySoftwareSkillId(SoftwareSkillId);

                if (SoftwareSkillEnt != null)
                {
                    txtTitle.Text = SoftwareSkillEnt.Title;
                    txtDescription.Text = SoftwareSkillEnt.Description;
                    txtPercentage.Text = SoftwareSkillEnt.Percentage.ToString();
                }
            }

        }
        private void Clear()
        {
            txtTitle.Text =
            txtDescription.Text =
            txtPercentage.Text =
            String.Empty;
        }
        #endregion
    }
}