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
    public partial class GeneralSkillsManagement : System.Web.UI.Page
    {
        #region Variables
        GeneralSkillRepository _objRepository;
        #endregion
        #region Property
        public string GeneralSkillId
        {
            set { ViewState["GeneralSkillId"] = value; }
            get { return ViewState["GeneralSkillId"] == null ? string.Empty : ViewState["GeneralSkillId"].ToString(); }
        }
        #endregion
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                GeneralSkillId = Request.QueryString["ID"].ToString();
            }
            if (!IsPostBack)
            {
                GetInfo();
                MasterPages.Pages.PageTitle = "General Skills";
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
            Response.Redirect("~/AdminPanale/MainPages/GeneralSkillsManagement.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPanale/MainPages/GeneralSkillsList.aspx");
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        #endregion
        #region Methods
        private void Save()
        {
            _objRepository = new GeneralSkillRepository();
            #region Manage Item

            _objRepository._Obj.Title = txtTitle.Text;
            _objRepository._Obj.Description = txtDescription.Text;
            _objRepository._Obj.Percentage = int.Parse(txtPercentage.Text);


            if (string.IsNullOrEmpty(GeneralSkillId))
            {
                _objRepository._Obj.CreatedBy = new Guid(Request.Cookies["CooLoginUserId"].Value);

                GeneralSkillId = _objRepository.Add().ToString();
            }
            else
            {
                _objRepository._Obj = _objRepository.LoadByGeneralSkillId(GeneralSkillId);

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

            if (!string.IsNullOrEmpty(GeneralSkillId))
            {
                _objRepository = new GeneralSkillRepository();

                GeneralSkill GeneralSkillEnt = _objRepository.LoadByGeneralSkillId(GeneralSkillId);

                if (GeneralSkillEnt != null)
                {
                    txtTitle.Text = GeneralSkillEnt.Title;
                    txtDescription.Text = GeneralSkillEnt.Description;
                    txtPercentage.Text = GeneralSkillEnt.Percentage.ToString();
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