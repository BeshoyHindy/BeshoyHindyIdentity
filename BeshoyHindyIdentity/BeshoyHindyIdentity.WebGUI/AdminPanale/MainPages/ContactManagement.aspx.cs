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
    public partial class ContactManagement : System.Web.UI.Page
    {
        #region Variables
        ContactRepository _objRepository;
        #endregion
        #region Property
        public string ContactId
        {
            set { ViewState["ContactId"] = value; }
            get { return ViewState["ContactId"] == null ? string.Empty : ViewState["ContactId"].ToString(); }
        }
        #endregion
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                ContactId = Request.QueryString["ID"].ToString();
            }
            if (!IsPostBack)
            {
                GetInfo();
                MasterPages.Pages.PageTitle = "Contact";
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
            Response.Redirect("~/AdminPanale/MainPages/ContactMaganagement.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPanale/MainPages/ContactList.aspx");
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        #endregion
        #region Methods
        private void Save()
        {
            _objRepository = new ContactRepository();
            #region Manage Item

            _objRepository._Obj.Title = txtTitle.Text;
            _objRepository._Obj.Email = txtEmail.Text;
            _objRepository._Obj.Address = txtAddress.Text;
            _objRepository._Obj.Phone = txtPhone.Text;
            _objRepository._Obj.GoogleMap = txtGoogleMap.Text;

            if (string.IsNullOrEmpty(ContactId))
            {
                _objRepository._Obj.CreatedBy = new Guid(Request.Cookies["CooLoginUserId"].Value);

                ContactId = _objRepository.Add().ToString();
            }
            else
            {
                _objRepository._Obj = _objRepository.LoadByContactId(ContactId);

                _objRepository._Obj.Title = txtTitle.Text;
                _objRepository._Obj.Email = txtEmail.Text;
                _objRepository._Obj.Address = txtAddress.Text;
                _objRepository._Obj.Phone = txtPhone.Text;
                _objRepository._Obj.GoogleMap = txtGoogleMap.Text;

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

            if (!string.IsNullOrEmpty(ContactId))
            {
                _objRepository = new ContactRepository();

                Contact ContactEnt = _objRepository.LoadByContactId(ContactId);

                if (ContactEnt != null)
                {
                    txtTitle.Text = ContactEnt.Title;
                    txtAddress.Text = ContactEnt.Address;
                    txtEmail.Text = ContactEnt.Email;
                    txtPhone.Text = ContactEnt.Phone;
                    txtGoogleMap.Text = ContactEnt.GoogleMap;
                }
            }

        }
        private void Clear()
        {
            txtTitle.Text =
            txtAddress.Text =
            txtEmail.Text =
            txtPhone.Text =
            txtGoogleMap.Text =
            String.Empty;
        }
        #endregion
    }
}