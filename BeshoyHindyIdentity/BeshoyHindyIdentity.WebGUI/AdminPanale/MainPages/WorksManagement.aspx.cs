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
    public partial class WorksManagement : System.Web.UI.Page
    {
        #region Variables
        WorkRepository _objRepository;
        #endregion
        #region Property
        public string WorkId
        {
            set { ViewState["WorkId"] = value; }
            get { return ViewState["WorkId"] == null ? string.Empty : ViewState["WorkId"].ToString(); }
        }
        #endregion
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                WorkId = Request.QueryString["ID"].ToString();
            }
            if (!IsPostBack)
            {
                GetInfo();
                FillddlWorkType();
                MasterPages.Pages.PageTitle = "Work";
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
            Response.Redirect("~/AdminPanale/MainPages/WorksManagement.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPanale/MainPages/WorksList.aspx");
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        #endregion
        #region Methods
        private void FillddlWorkType()
        {
            WorkTypeRepository _WorkTypeRepository = new WorkTypeRepository();

            ddlWorkType.DataSource = _WorkTypeRepository.LoadWorksTypes();
            ddlWorkType.DataTextField = "TypeName";
            ddlWorkType.DataValueField = "Id";
            ddlWorkType.DataBind();

            ddlWorkType.Items.Insert(0, "Select Work Type...");
            ddlWorkType.SelectedIndex = 0;
        }

        private void Save()
        {
            _objRepository = new WorkRepository();
            #region Manage Item

            string FileName = string.Empty;
            string FileNameThumb = string.Empty;

            _objRepository._Obj.Title = txtTitle.Text;
            _objRepository._Obj.Url = txtURL.Text;
            _objRepository._Obj.Description = txtDescription.Text;
            _objRepository._Obj.ProjectDate = txtProjectDate.Text;
            _objRepository._Obj.WorkTypeId = new Guid(ddlWorkType.SelectedValue);

            if (string.IsNullOrEmpty(WorkId))
            {
                _objRepository._Obj.CreatedBy = new Guid(Request.Cookies["CooLoginUserId"].Value);

                if (fpld.PostedFile.FileName != "")
                {
                    FileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(fpld.PostedFile.FileName);
                    string PathUrl = Server.MapPath(ConfigurationManager.AppSettings["Portfolio"].ToString()) + FileName;
                    fpld.SaveAs(PathUrl);
                    // DAL.ImagesFact.ResizeWithCropResizeImage("", FileName, "Section");
                    _objRepository._Obj.IamgeFile = FileName;
                }

                if (fpldThumb.PostedFile.FileName != "")
                {
                    FileNameThumb = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(fpldThumb.PostedFile.FileName);
                    string PathUrl = Server.MapPath(ConfigurationManager.AppSettings["Portfolio"].ToString()) + FileNameThumb;
                    fpldThumb.SaveAs(PathUrl);
                    // DAL.ImagesFact.ResizeWithCropResizeImage("", FileName, "Section");
                    _objRepository._Obj.IamgeThumb = FileNameThumb;
                }

                WorkId = _objRepository.Add().ToString();
            }
            else
            {
                _objRepository._Obj = _objRepository.LoadByWorkId(WorkId);

                _objRepository._Obj.Title = txtTitle.Text;
                _objRepository._Obj.Url = txtURL.Text;
                _objRepository._Obj.Description = txtDescription.Text;
                _objRepository._Obj.ProjectDate = txtProjectDate.Text;
                _objRepository._Obj.WorkTypeId = new Guid(ddlWorkType.SelectedValue);

                if (fpld.PostedFile.FileName != "")
                {
                    if (_objRepository._Obj.IamgeFile != null)
                    {
                        DirectoryInfo di = new DirectoryInfo(Server.MapPath(ConfigurationManager.AppSettings["Portfolio"]));
                        foreach (FileInfo fi in di.GetFiles())
                        {
                            if (_objRepository._Obj.IamgeFile == fi.Name)
                            {
                                File.Delete(fi.Name);
                            }
                        }
                    }

                    FileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(fpld.PostedFile.FileName);
                    string PathUrl = Server.MapPath(ConfigurationManager.AppSettings["Portfolio"].ToString()) + FileName;
                    fpld.SaveAs(PathUrl);
                    // DAL.ImagesFact.ResizeWithCropResizeImage("", FileName, "Section");
                    _objRepository._Obj.IamgeFile = FileName;
                }

                if (fpldThumb.PostedFile.FileName != "")
                {
                    if (_objRepository._Obj.IamgeThumb != null)
                    {
                        DirectoryInfo di = new DirectoryInfo(Server.MapPath(ConfigurationManager.AppSettings["Portfolio"]));
                        foreach (FileInfo fi in di.GetFiles())
                        {
                            if (_objRepository._Obj.IamgeThumb == fi.Name)
                            {
                                File.Delete(fi.Name);
                            }
                        }
                    }

                    FileNameThumb = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(fpldThumb.PostedFile.FileName);
                    string PathUrl = Server.MapPath(ConfigurationManager.AppSettings["Portfolio"].ToString()) + FileNameThumb;
                    fpldThumb.SaveAs(PathUrl);
                    // DAL.ImagesFact.ResizeWithCropResizeImage("", FileName, "Section");
                    _objRepository._Obj.IamgeThumb = FileNameThumb;
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

            if (!string.IsNullOrEmpty(WorkId))
            {
                _objRepository = new WorkRepository();

                Work WorkEnt = _objRepository.LoadByWorkId(WorkId);

                if (WorkEnt != null)
                {
                    txtTitle.Text = WorkEnt.Title;
                    txtURL.Text = WorkEnt.Url;
                    txtProjectDate.Text = WorkEnt.ProjectDate;
                    txtDescription.Text = WorkEnt.Description;
                    ddlWorkType.SelectedValue = WorkEnt.WorkTypeId.ToString();

                    if (!string.IsNullOrEmpty(WorkEnt.IamgeFile))
                    {
                        imgImage.ImageUrl = ConfigurationManager.AppSettings["Portfolio"].ToString() + WorkEnt.IamgeFile;
                        imgImage.Visible = true;
                    }
                    else
                    {
                        imgImage.Visible = false;
                    }

                    if (!string.IsNullOrEmpty(WorkEnt.IamgeThumb))
                    {
                        imgImageThumb.ImageUrl = ConfigurationManager.AppSettings["Portfolio"].ToString() + WorkEnt.IamgeThumb;
                        imgImageThumb.Visible = true;
                    }
                    else
                    {
                        imgImageThumb.Visible = false;
                    }
                }
            }

        }
        private void Clear()
        {
            txtTitle.Text =
            txtURL.Text =
            txtProjectDate.Text =
            txtDescription.Text =
            String.Empty;

            ddlWorkType.SelectedIndex = -1;
        }
        #endregion
    }
}