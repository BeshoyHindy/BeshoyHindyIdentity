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
    public partial class AboutMeMaganagement : System.Web.UI.Page
    {
        #region Variables
        AboutMeRepository _objRepository;
        #endregion
        #region Property
        public string AboutMeId
        {
            set { ViewState["AboutMeId"] = value; }
            get { return ViewState["AboutMeId"] == null ? string.Empty : ViewState["AboutMeId"].ToString(); }
        }
        #endregion
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                AboutMeId = Request.QueryString["ID"].ToString();
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
            Response.Redirect("~/AdminPanale/MainPages/AboutMeMaganagement.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPanale/MainPages/AboutMeList.aspx");
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        #endregion
        #region Methods
        private void Save()
        {
            _objRepository = new AboutMeRepository();
            #region Manage Item

            string FileName = string.Empty;

            _objRepository._Obj.Name = txtName.Text;
            _objRepository._Obj.JobTitle = txtJobTitle.Text;
            _objRepository._Obj.Birthdate = DateTime.Parse(txtBirthdate.Text.ToString());
            _objRepository._Obj.Phone = txtPhone.Text;
            _objRepository._Obj.Email = txtEmail.Text;
            _objRepository._Obj.WebSiteUrl = txtWebSiteURL.Text;
            _objRepository._Obj.ReusmeUrl = txtReusmeURL.Text;
            _objRepository._Obj.Address = txtAddress.Text;
            _objRepository._Obj.Quote = txtQuote.Text;
            _objRepository._Obj.IdentityDescription = txtIdentityDescription.Text;
            _objRepository._Obj.ExperienceYears = int.Parse(txtExperienceYears.Text);
            _objRepository._Obj.Clints = int.Parse(txtClints.Text);
            _objRepository._Obj.Projects = int.Parse(txtProjects.Text);
            _objRepository._Obj.Certifications = int.Parse(txtCertifications.Text);


            if (string.IsNullOrEmpty(AboutMeId))
            {
                _objRepository._Obj.CreatedBy = new Guid(Request.Cookies["CooLoginUserId"].Value);

                if (fpld.PostedFile.FileName != "")
                {
                    FileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(fpld.PostedFile.FileName);
                    string PathUrl = Server.MapPath(ConfigurationManager.AppSettings["Image"].ToString()) + FileName;
                    fpld.SaveAs(PathUrl);
                    // DAL.ImagesFact.ResizeWithCropResizeImage("", FileName, "Section");
                    _objRepository._Obj.Image = FileName;
                }

                AboutMeId = _objRepository.Add().ToString();
            }
            else
            {
                _objRepository._Obj = _objRepository.LoadByAboutMeId(AboutMeId);

                _objRepository._Obj.Name = txtName.Text;
                _objRepository._Obj.JobTitle = txtJobTitle.Text;
                _objRepository._Obj.Birthdate = DateTime.Parse(txtBirthdate.Text.ToString());
                _objRepository._Obj.Phone = txtPhone.Text;
                _objRepository._Obj.Email = txtEmail.Text;
                _objRepository._Obj.WebSiteUrl = txtWebSiteURL.Text;
                _objRepository._Obj.ReusmeUrl = txtReusmeURL.Text;
                _objRepository._Obj.Address = txtAddress.Text;
                _objRepository._Obj.Quote = txtQuote.Text;
                _objRepository._Obj.IdentityDescription = txtIdentityDescription.Text;
                _objRepository._Obj.ExperienceYears = int.Parse(txtExperienceYears.Text);
                _objRepository._Obj.Clints = int.Parse(txtClints.Text);
                _objRepository._Obj.Projects = int.Parse(txtProjects.Text);
                _objRepository._Obj.Certifications = int.Parse(txtCertifications.Text);

                if (fpld.PostedFile.FileName != "")
                {
                    if (_objRepository._Obj.Image != null)
                    {
                        DirectoryInfo di = new DirectoryInfo(Server.MapPath(ConfigurationManager.AppSettings["Image"]));
                        foreach (FileInfo fi in di.GetFiles())
                        {
                            if (_objRepository._Obj.Image == fi.Name)
                            {
                                File.Delete(fi.Name);
                            }
                        }
                    }

                    FileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(fpld.PostedFile.FileName);
                    string PathUrl = Server.MapPath(ConfigurationManager.AppSettings["Image"].ToString()) + FileName;
                    fpld.SaveAs(PathUrl);
                    // DAL.ImagesFact.ResizeWithCropResizeImage("", FileName, "Section");
                    _objRepository._Obj.Image = FileName;
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

            if (!string.IsNullOrEmpty(AboutMeId))
            {
                _objRepository = new AboutMeRepository();

                AboutMe AboutMeEnt = _objRepository.LoadByAboutMeId(AboutMeId);

                if (AboutMeEnt != null)
                {
                    txtName.Text = AboutMeEnt.Name;
                    txtJobTitle.Text = AboutMeEnt.JobTitle;
                    txtBirthdate.Text = AboutMeEnt.Birthdate.ToString();
                    //txtBirthdate.Text = String.Format("{0:dd-MM-yyyy}", AboutMeEnt.Birthdate);
                    txtPhone.Text = AboutMeEnt.Phone;
                    txtEmail.Text = AboutMeEnt.Email;
                    txtWebSiteURL.Text = AboutMeEnt.WebSiteUrl;
                    txtReusmeURL.Text = AboutMeEnt.ReusmeUrl;
                    txtAddress.Text = AboutMeEnt.Address;
                    txtQuote.Text = AboutMeEnt.Quote;
                    txtIdentityDescription.Text = AboutMeEnt.IdentityDescription;
                    txtExperienceYears.Text = AboutMeEnt.ExperienceYears.ToString();
                    txtClints.Text = AboutMeEnt.Clints.ToString();
                    txtProjects.Text = AboutMeEnt.Projects.ToString();
                    txtCertifications.Text = AboutMeEnt.Certifications.ToString();
                    if (!string.IsNullOrEmpty(AboutMeEnt.Image))
                    {
                        imgImage.ImageUrl = ConfigurationManager.AppSettings["Image"].ToString() + AboutMeEnt.Image;
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
            txtName.Text =
            txtJobTitle.Text =
            txtBirthdate.Text =
            txtPhone.Text =
            txtEmail.Text =
            txtWebSiteURL.Text =
            txtReusmeURL.Text =
            txtAddress.Text =
            txtQuote.Text =
            txtIdentityDescription.Text =
            txtExperienceYears.Text =
            txtClints.Text =
            txtProjects.Text =
            txtCertifications.Text =
            String.Empty;
        }
        #endregion
    }
}