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
    public partial class SocialLinksManagement : System.Web.UI.Page
    {
        #region Variables
        SocialLinkRepository _objRepository;
        #endregion
        #region Property
        public string SocialLinksId
        {
            set { ViewState["SocialLinksId"] = value; }
            get { return ViewState["SocialLinksId"] == null ? string.Empty : ViewState["SocialLinksId"].ToString(); }
        }
        #endregion
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                SocialLinksId = Request.QueryString["ID"].ToString();
            }
            if (!IsPostBack)
            {
                GetInfo();
                MasterPages.Pages.PageTitle = "SocialLinks";
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
            Response.Redirect("~/AdminPanale/MainPages/SocialLinkssMaganagement.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPanale/MainPages/SocialLinkssList.aspx");
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        #endregion
        #region Methods
        private void Save()
        {
            _objRepository = new SocialLinkRepository();
            #region Manage Item

            _objRepository._Obj.Title = txtTitle.Text;
            _objRepository._Obj.Logo = txtLogo.Text;
            _objRepository._Obj.URl = txtURL.Text;

            if (string.IsNullOrEmpty(SocialLinksId))
            {
                _objRepository._Obj.CreatedBy = new Guid(Request.Cookies["CooLoginUserId"].Value);

                SocialLinksId = _objRepository.Add().ToString();
            }
            else
            {
                _objRepository._Obj = _objRepository.LoadBySocialLinkId(SocialLinksId);

                _objRepository._Obj.Title = txtTitle.Text;
                _objRepository._Obj.Logo = txtLogo.Text;
                _objRepository._Obj.URl = txtURL.Text;

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

            if (!string.IsNullOrEmpty(SocialLinksId))
            {
                _objRepository = new SocialLinkRepository();

                SocialLink SocialLinkEnt = _objRepository.LoadBySocialLinkId(SocialLinksId);

                if (SocialLinkEnt != null)
                {
                    txtTitle.Text = SocialLinkEnt.Title;
                    txtLogo.Text = SocialLinkEnt.Logo;
                    txtURL.Text = SocialLinkEnt.URl;
                }
            }

        }
        private void Clear()
        {
            txtTitle.Text =
            txtLogo.Text =
            txtURL.Text =
            String.Empty;
        }
        #endregion
    }
}