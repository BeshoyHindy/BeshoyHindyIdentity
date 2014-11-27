using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.DataModels;
using DAL.Repositories;
using DAL.Extensions;
using System.Configuration;
using System.Text;


namespace WebGUI
{
    public partial class Default : System.Web.UI.Page
    {
        #region Events
        public static string YearExperiance { get; set; }
        public static string ProjectsNumber { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAboutMeSection();
                BindWorksSection();
                BindSoftwareSkillesSection();
                BindGeneralSkillesSection();
                BindResumesSection();
                BindEducationSection();
                BindClientsSection();
                BindProcessSection();
                BindContactUsSection();

            }
        }

        protected void contactForm_submit_Click(object sender, EventArgs e)
        {
            lblAddress_ContactSection.Text = "sdfasdfasdfasd";
        }
        #endregion
        #region Methods
        private void BindAboutMeSection()
        {
            AboutMeRepository _objRepo = new AboutMeRepository();
            AboutMe _objAboutMe = _objRepo.LoadByAboutMe();

            lblBirthDate.Text = string.Format("{0:dd-MM-yyy}", _objAboutMe.Birthdate);

            lblAddress.Text = _objAboutMe.Address.ToString();
            lblEmail.Text = _objAboutMe.Email.ToString();
            lblIdentityDescription.Text = _objAboutMe.IdentityDescription.ToString();
            lblJobTitle.Text = _objAboutMe.JobTitle.ToString();
            lblName.Text = _objAboutMe.Name.ToString();
            lblPhone.Text = _objAboutMe.Phone.ToString();
            lblQuote.Text = _objAboutMe.Quote.ToString();
            lblWebsite.Text = _objAboutMe.WebSiteUrl.ToString();
            YearExperiance = _objAboutMe.ExperienceYears.ToString();
            ProjectsNumber = _objAboutMe.Projects.ToString();
            imgImageFile.ImageUrl = ConfigurationManager.AppSettings["Image"].ToString() + _objAboutMe.Image.ToString();
        }
        private void BindWorksSection()
        {
            WorkTypeRepository _objWorkTypeRepo = new WorkTypeRepository();
            WorkRepository _objWorksRepo = new WorkRepository();

            rptrWorkType.DataSource = _objWorkTypeRepo.LoadByActiveState(true);
            rptrWorkType.DataBind();

            rptrWorks.DataSource = _objWorksRepo.LoadWorksWithWorkTypeNmae();
            rptrWorks.DataBind();

        }
        private void BindSoftwareSkillesSection()
        {
            SoftwareSkillRepository _objRepo = new SoftwareSkillRepository();
            rptrSoftWareSkilles.DataSource = _objRepo.LoadByActiveState(true);
            rptrSoftWareSkilles.DataBind();
        }
        private void BindGeneralSkillesSection()
        {
            GeneralSkillRepository _objRepo = new GeneralSkillRepository();
            rptrEvenGeleralSkilles.DataSource = _objRepo.LoadEvens();
            rptrEvenGeleralSkilles.DataBind();

            rptrOddsGeneralSkilles.DataSource = _objRepo.LoadOdds();
            rptrOddsGeneralSkilles.DataBind();
        }
        private void BindResumesSection()
        {
            Resume _objResume = new Resume();
            StringBuilder strbldrResumes = new StringBuilder();
            ResumeRepository _objResumeRepository = new ResumeRepository();

            for (int i = 0; i < _objResumeRepository.LoadByActiveState(true).Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    _objResume = _objResumeRepository.LoadByTakeAndSkipe(i, 1).SingleOrDefault();

                    String strOddResumes_Lift = "<li class=\"note item_left\">";
                    strOddResumes_Lift += "<h4>" + _objResume.CompanyName + "</h4>";
                    strOddResumes_Lift += "<h5>" + _objResume.JobPosition + "</h5>";
                    strOddResumes_Lift += "<p class=\"desc\">";
                    strOddResumes_Lift += _objResume.JobDescription;
                    strOddResumes_Lift += "</p>";
                    strOddResumes_Lift += "<span class=\"date\">" + _objResume.DateFrom + "to" + _objResume.DateTo + "</span>";
                    strOddResumes_Lift += "<span class=\"arrow fa fa-play\"></span>";
                    strOddResumes_Lift += "</li>";

                    strbldrResumes.Append(strOddResumes_Lift);
                }
                else if (i % 2 != 0)
                {
                    _objResume = _objResumeRepository.LoadByTakeAndSkipe(i, 1).SingleOrDefault();

                    String strEvenResumes_Right = "<li class=\"note item_right\">";
                    strEvenResumes_Right += "<h4>" + _objResume.CompanyName + "</h4>";
                    strEvenResumes_Right += "<h5>" + _objResume.JobPosition + "</h5>";
                    strEvenResumes_Right += "<p class=\"desc\">";
                    strEvenResumes_Right += _objResume.JobDescription;
                    strEvenResumes_Right += "</p>";
                    strEvenResumes_Right += "<span class=\"date\">" + _objResume.DateFrom + "to" + _objResume.DateTo + "</span>";
                    strEvenResumes_Right += "<span class=\"arrow fa fa-play\"></span>";
                    strEvenResumes_Right += "</li>";

                    strbldrResumes.Append(strEvenResumes_Right);
                }
            }

            lblResumes.Text = strbldrResumes.ToString();
        }
        private void BindEducationSection()
        {
            Education _objEducation = new Education();
            StringBuilder strbldrEducation = new StringBuilder();
            EducationRepository _objEducationRepository = new EducationRepository();

            for (int i = 0; i < _objEducationRepository.LoadByActiveState(true).Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    _objEducation = _objEducationRepository.LoadByTakeAndSkipe(i, 1).SingleOrDefault();

                    String strOddEducations_Lift = "<li class=\"note item_left\">";
                    strOddEducations_Lift += "<h4>" + _objEducation.Title + "</h4>";
                    strOddEducations_Lift += "<h5>" + _objEducation.Institute + "</h5>";
                    strOddEducations_Lift += "<p class=\"desc\">";
                    strOddEducations_Lift += _objEducation.Description;
                    strOddEducations_Lift += "</p>";
                    strOddEducations_Lift += "<span class=\"date\">" + _objEducation.DateFrom + " - " + _objEducation.DateTo + " </span>";
                    strOddEducations_Lift += "<span class=\"arrow fa fa-play\"></span>";

                    strbldrEducation.Append(strOddEducations_Lift);
                }
                else if (i % 2 != 0)
                {
                    _objEducation = _objEducationRepository.LoadByTakeAndSkipe(i, 1).SingleOrDefault();

                    String strEvenEducations_Right = "<li class=\"note item_right\">";
                    strEvenEducations_Right += "<h4>" + _objEducation.Title + "</h4>";
                    strEvenEducations_Right += "<h5>" + _objEducation.Institute + "</h5>";
                    strEvenEducations_Right += "<p class=\"desc\">";
                    strEvenEducations_Right += _objEducation.Description;
                    strEvenEducations_Right += "</p>";
                    strEvenEducations_Right += "<span class=\"date\">" + _objEducation.DateFrom + " - " + _objEducation.DateTo + " </span>";
                    strEvenEducations_Right += "<span class=\"arrow fa fa-play\"></span>";

                    strbldrEducation.Append(strEvenEducations_Right);
                }
            }

            lblEducation.Text = strbldrEducation.ToString();
        }
        private void BindClientsSection()
        {
            ClientRepository _objRepo = new ClientRepository();
            rptrClientsSayes.DataSource = _objRepo.LoadByActiveState(true);
            rptrClientsSayes.DataBind();

            rptrClientsLogo.DataSource = _objRepo.LoadByActiveState(true);
            rptrClientsLogo.DataBind();
        }
        private void BindProcessSection()
        {
            ProcessRepository _objRepo = new ProcessRepository();
            rptrProcess.DataSource = _objRepo.LoadByActiveState(true);
            rptrProcess.DataBind();
        }
        private void BindContactUsSection()
        {
            ContactRepository _objRepo = new ContactRepository();
            Contact _objContac = new Contact();
            _objContac = _objRepo.LoadContactByActiveState(true);

            lblAddress_ContactSection.Text = _objContac.Address.ToString();
            lblPhone_ContactSection.Text = _objContac.Phone.ToString();

            #region SocialLinks
            SocialLinkRepository _objSocialRepo = new SocialLinkRepository();
            rptrSocialLinks.DataSource = _objSocialRepo.LoadByActiveState(true);
            rptrSocialLinks.DataBind();

            #endregion

        }
        #endregion


    }
}