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
    public partial class ClientsManagement : System.Web.UI.Page
    {
        #region Variables
        ClientRepository _objRepository;
        #endregion
        #region Property
        public string ClientId
        {
            set { ViewState["ClientId"] = value; }
            get { return ViewState["ClientId"] == null ? string.Empty : ViewState["ClientId"].ToString(); }
        }
        #endregion
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                ClientId = Request.QueryString["ID"].ToString();
            }
            if (!IsPostBack)
            {
                GetInfo();
                MasterPages.Pages.PageTitle = "Client";
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
            Response.Redirect("~/AdminPanale/MainPages/ClientsMaganagement.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPanale/MainPages/ClientsList.aspx");
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        #endregion
        #region Methods
        private void Save()
        {
            _objRepository = new ClientRepository();
            #region Manage Item

            string FileName = string.Empty;

            _objRepository._Obj.ClientName = txtClientName.Text;
            _objRepository._Obj.ClientPosition = txtClientPosition.Text;
            _objRepository._Obj.ClientUrl = txtClientURL.Text;
            _objRepository._Obj.ClientMessage = txtClientMessage.Text;

            if (string.IsNullOrEmpty(ClientId))
            {
                _objRepository._Obj.CreatedBy = new Guid(Request.Cookies["CooLoginUserId"].Value);

                if (fpld.PostedFile.FileName != "")
                {
                    FileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(fpld.PostedFile.FileName);
                    string PathUrl = Server.MapPath(ConfigurationManager.AppSettings["Clients"].ToString()) + FileName;
                    fpld.SaveAs(PathUrl);
                    // DAL.ImagesFact.ResizeWithCropResizeImage("", FileName, "Section");
                    _objRepository._Obj.Logo = FileName;
                }

                ClientId = _objRepository.Add().ToString();
            }
            else
            {
                _objRepository._Obj = _objRepository.LoadByClientId(ClientId);

                _objRepository._Obj.ClientName = txtClientName.Text;
                _objRepository._Obj.ClientPosition = txtClientPosition.Text;
                _objRepository._Obj.ClientUrl = txtClientURL.Text;
                _objRepository._Obj.ClientMessage = txtClientMessage.Text;

                if (fpld.PostedFile.FileName != "")
                {
                    if (_objRepository._Obj.Logo != null)
                    {
                        DirectoryInfo di = new DirectoryInfo(Server.MapPath(ConfigurationManager.AppSettings["Clients"]));
                        foreach (FileInfo fi in di.GetFiles())
                        {
                            if (_objRepository._Obj.Logo == fi.Name)
                            {
                                File.Delete(fi.Name);
                            }
                        }
                    }

                    FileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(fpld.PostedFile.FileName);
                    string PathUrl = Server.MapPath(ConfigurationManager.AppSettings["Image"].ToString()) + FileName;
                    fpld.SaveAs(PathUrl);
                    // DAL.ImagesFact.ResizeWithCropResizeImage("", FileName, "Section");
                    _objRepository._Obj.Logo = FileName;
                }


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

            if (!string.IsNullOrEmpty(ClientId))
            {
                _objRepository = new ClientRepository();

                Client ClientEnt = _objRepository.LoadByClientId(ClientId);

                if (ClientEnt != null)
                {
                    txtClientName.Text = ClientEnt.ClientName;
                    txtClientMessage.Text = ClientEnt.ClientMessage;
                    txtClientPosition.Text = ClientEnt.ClientPosition;
                    txtClientURL.Text = ClientEnt.ClientUrl;

                    if (!string.IsNullOrEmpty(ClientEnt.Logo))
                    {
                        imgImage.ImageUrl = ConfigurationManager.AppSettings["Image"].ToString() + ClientEnt.Logo;
                        imgImage.Visible = true;
                    }
                    else
                    {
                        imgImage.Visible = false;
                    }
                }
            }

        }
        private void Clear()
        {
            txtClientName.Text =
            txtClientMessage.Text =
            txtClientPosition.Text =
            txtClientURL.Text =
            String.Empty;
        }
        #endregion
    }
}