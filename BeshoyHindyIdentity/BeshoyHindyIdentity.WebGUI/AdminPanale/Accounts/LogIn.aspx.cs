using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Repositories;
using DAL.DataModels;
using System.Web.Security;

namespace WebGUI.AdminPanale.Accounts
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {

            Boolean IsInvaledAdmin = false;
            String _message = String.Empty;
            Boolean _visibleMeassage = false;

            //loginAdmin(txtUserName.Text, txtPassword.Text, out IsInvaledAdmin);
            loginAdmin(txtusername.Text, txtpassword.Text, chkRememberMe.Checked, out IsInvaledAdmin, out _message, out _visibleMeassage);
            if (IsInvaledAdmin)
            {
                _message = "invaled username or password";
                _visibleMeassage = true;
            }
            else
            {
                _visibleMeassage = false;
            }

            lblMessage.Text = _message;
            divMessage.Visible = _visibleMeassage;
        }




        private void loginAdmin(String LoginNamePram, String PasswordPram, Boolean Reminded, out Boolean IsInvaledAdminPram, out String Message, out Boolean VisibleMeassage)
        {

            AdminRepository _ObjRepo = new AdminRepository();
            Admin _AdminObj = new Admin();
            Admin _AdminLoginObj = new Admin();
            String _AdminId = String.Empty;


            _AdminObj.Password = PasswordPram;
            _AdminObj.LoginName = LoginNamePram;

            Boolean loginStat;


            if (String.IsNullOrEmpty(LoginNamePram) || String.IsNullOrEmpty(PasswordPram))
            {
                Message = "invaled username or password";
                VisibleMeassage = true;

                IsInvaledAdminPram = true;
            }
            else
            {
                _AdminId = _ObjRepo.LoginUser(LoginNamePram, PasswordPram, out loginStat);
                //_LoginUser = _UsersManagement.LoginUser(_UserPramObj, out loginStat);

                if (loginStat)
                {
                    HttpCookie CooLoginUser = new HttpCookie("CooLoginUser");


                    HttpCookie CooLoginUserID = new HttpCookie("CooLoginUserId");
                    CooLoginUserID.Value = _AdminId;


                    Response.Cookies.Add(CooLoginUser);
                    Response.Cookies.Add(CooLoginUserID);

                    FormsAuthentication.RedirectFromLoginPage(LoginNamePram, Reminded);

                    IsInvaledAdminPram = loginStat;
                }

                IsInvaledAdminPram = false;
                Message = "";
                VisibleMeassage = false;
            }

        }


    }
}