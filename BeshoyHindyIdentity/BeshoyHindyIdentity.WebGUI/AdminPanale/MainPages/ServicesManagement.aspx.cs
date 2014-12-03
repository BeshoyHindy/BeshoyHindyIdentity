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
    public partial class ServicesManagement : System.Web.UI.Page
    {
        #region Variables
        ServicesRepository _objRepository;

        #endregion
        #region Property
        public string ServiceId
        {
            set { ViewState["ServiceId"] = value; }
            get { return ViewState["ServiceId"] == null ? string.Empty : ViewState["ServiceId"].ToString(); }
        }
        #endregion
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                ServiceId = Request.QueryString["ID"].ToString();
            }
            if (!IsPostBack)
            {
                GetInfo();
                MasterPages.Pages.PageTitle = "Service";
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
            Response.Redirect("~/AdminPanale/MainPages/ServicesManagement.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPanale/MainPages/ServicesList.aspx");
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        #endregion
        #region Methods
        private void Save()
        {
            _objRepository = new ServicesRepository();
            #region Manage Item

            _objRepository._Obj.Title = txtTitle.Text;
            _objRepository._Obj.Description = txtDescription.Text;
            _objRepository._Obj.Image = txtImage.Text;


            if (string.IsNullOrEmpty(ServiceId))
            {
                _objRepository._Obj.CreatedBy = new Guid(Request.Cookies["CooLoginUserId"].Value);

                ServiceId = _objRepository.Add().ToString();
            }
            else
            {
                _objRepository._Obj = _objRepository.LoadByServiceId(ServiceId);

                _objRepository._Obj.Title = txtTitle.Text;
                _objRepository._Obj.Description = txtDescription.Text;
                _objRepository._Obj.Image = txtImage.Text;

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

            if (!string.IsNullOrEmpty(ServiceId))
            {
                _objRepository = new ServicesRepository();

                Service ServiceEnt = _objRepository.LoadByServiceId(ServiceId);

                if (ServiceEnt != null)
                {
                    txtTitle.Text = ServiceEnt.Title;
                    txtDescription.Text = ServiceEnt.Description;
                    txtImage.Text = ServiceEnt.Image.ToString();
                }
            }

        }
        private void Clear()
        {
            txtTitle.Text =
            txtDescription.Text =
            txtImage.Text =
            String.Empty;
        }
        #endregion
    }
}