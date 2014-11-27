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
    public partial class ProcessManagement : System.Web.UI.Page
    {
        #region Variables
        ProcessRepository _objRepository;
        #endregion
        #region Property
        public string ProcessId
        {
            set { ViewState["ProcessId"] = value; }
            get { return ViewState["ProcessId"] == null ? string.Empty : ViewState["ProcessId"].ToString(); }
        }
        #endregion
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                ProcessId = Request.QueryString["ID"].ToString();
            }
            if (!IsPostBack)
            {
                GetInfo();
                MasterPages.Pages.PageTitle = "Process";
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
            Response.Redirect("~/AdminPanale/MainPages/ProcessMaganagement.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPanale/MainPages/ProcessList.aspx");
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        #endregion
        #region Methods
        private void Save()
        {
            _objRepository = new ProcessRepository();
            #region Manage Item

            //string FileName = string.Empty;

            _objRepository._Obj.Title = txtTitle.Text;
            _objRepository._Obj.Description = txtDescription.Text;
            _objRepository._Obj.Logo = txtLogo.Text;
            _objRepository._Obj.Oreder = int.Parse(txtOrder.Text);

            if (string.IsNullOrEmpty(ProcessId))
            {
                _objRepository._Obj.CreatedBy = new Guid(Request.Cookies["CooLoginUserId"].Value);

                //if (fpld.PostedFile.FileName != "")
                //{
                //    FileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(fpld.PostedFile.FileName);
                //    string PathUrl = Server.MapPath(ConfigurationManager.AppSettings["Processs"].ToString()) + FileName;
                //    fpld.SaveAs(PathUrl);
                //    // DAL.ImagesFact.ResizeWithCropResizeImage("", FileName, "Section");
                //    _objRepository._Obj.Logo = FileName;
                //}

                ProcessId = _objRepository.Add().ToString();
            }
            else
            {
                _objRepository._Obj = _objRepository.LoadByProcessId(ProcessId);

                _objRepository._Obj.Title = txtTitle.Text;
                _objRepository._Obj.Description = txtDescription.Text;
                _objRepository._Obj.Logo = txtLogo.Text;
                _objRepository._Obj.Oreder = int.Parse(txtOrder.Text);

                //if (fpld.PostedFile.FileName != "")
                //{
                //    if (_objRepository._Obj.Logo != null)
                //    {
                //        DirectoryInfo di = new DirectoryInfo(Server.MapPath(ConfigurationManager.AppSettings["Processs"]));
                //        foreach (FileInfo fi in di.GetFiles())
                //        {
                //            if (_objRepository._Obj.Logo == fi.Name)
                //            {
                //                File.Delete(fi.Name);
                //            }
                //        }
                //    }

                //    FileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(fpld.PostedFile.FileName);
                //    string PathUrl = Server.MapPath(ConfigurationManager.AppSettings["Image"].ToString()) + FileName;
                //    fpld.SaveAs(PathUrl);
                //    // DAL.ImagesFact.ResizeWithCropResizeImage("", FileName, "Section");
                //    _objRepository._Obj.Logo = FileName;
                //}


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

            if (!string.IsNullOrEmpty(ProcessId))
            {
                _objRepository = new ProcessRepository();

                Process ProcessEnt = _objRepository.LoadByProcessId(ProcessId);

                if (ProcessEnt != null)
                {
                    txtTitle.Text = ProcessEnt.Title;
                    txtDescription.Text = ProcessEnt.Description;
                    txtLogo.Text = ProcessEnt.Logo;
                    txtOrder.Text = ProcessEnt.Oreder.ToString();

                    //if (!string.IsNullOrEmpty(ProcessEnt.Logo))
                    //{
                    //    imgImage.ImageUrl = ConfigurationManager.AppSettings["Image"].ToString() + ProcessEnt.Logo;
                    //    imgImage.Visible = true;
                    //}
                    //else
                    //{
                    //    imgImage.Visible = false;
                    //}
                }
            }

        }
        private void Clear()
        {
            txtTitle.Text =
            txtDescription.Text =
            txtLogo.Text =
            txtOrder.Text =
            String.Empty;
        }
        #endregion
    }
}