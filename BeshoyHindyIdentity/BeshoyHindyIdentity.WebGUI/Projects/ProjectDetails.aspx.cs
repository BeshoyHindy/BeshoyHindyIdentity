using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using DAL.Repositories;
using DAL.DataModels;
using DAL.Extensions;


namespace WebGUI.Projects
{
    public partial class ProjectDetails : System.Web.UI.Page
    {
        #region Variables

        WorkRepository _objRepo;
        Work _objWork;

        #endregion
        #region Properties
        public String ProjectId { get; set; }
        #endregion
        #region Methods
        private void BindData()
        {
            _objRepo = new WorkRepository();
            _objWork = new Work();

            _objWork = _objRepo.LoadByWorkId(ProjectId);

            lblTitle.Text = _objWork.Title.ToString();
            lblTitle_URL.Text = _objWork.Title.ToString();
            hURL.HRef = _objWork.Url.ToString();
            lblProjectDate.Text = _objWork.ProjectDate.ToString();
            lblDescription.Text = _objWork.Description.ToString();

            imgIamgeFile.Src = ConfigurationManager.AppSettings["PortfolioUI"].ToString() + _objWork.IamgeFile.ToString();
        }
        #endregion
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(Request.QueryString["PID"].ToString()))
            {
                ProjectId = Request.QueryString["PID"].ToString();
            }
            if (!IsPostBack)
            {
                BindData();
            }
        }


        #endregion
    }
}