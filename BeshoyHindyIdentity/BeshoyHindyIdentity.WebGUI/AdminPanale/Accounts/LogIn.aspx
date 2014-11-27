<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="WebGUI.AdminPanale.Accounts.LogIn" %>

<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>--%>
<%--___________________________________________________________________--%>



<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="content-type" content="text/html;charset=UTF-8" />
    <meta charset="utf-8" />
    <title>Beshoy Hindy - Admin Dashboard</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta content="" name="description" />
    <meta content="" name="author" />
    <!-- BEGIN CORE CSS FRAMEWORK -->
    <link href="../assets/plugins/pace/pace-theme-flash.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="../assets/plugins/boostrapv3/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/plugins/boostrapv3/css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/plugins/font-awesome/css/font-awesome.css" rel="stylesheet" type="text/css" />
    <link href="../assets/css/animate.min.css" rel="stylesheet" type="text/css" />
    <!-- END CORE CSS FRAMEWORK -->
    <!-- BEGIN CSS TEMPLATE -->
    <link href="../assets/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="../assets/css/custom-icon-set.css" rel="stylesheet" type="text/css" />
    <!-- END CSS TEMPLATE -->
</head>
<!-- END HEAD -->
<!-- BEGIN BODY -->
<body class="error-body no-top">
    <form id="loginForm" runat="server">
        <div class="container" style="width: 450px;">

            <div>
                <!-- BEGIN BASIC FORM ELEMENTS-->

                <div class="" style="margin-top: 150px;">
                    <div class="grid simple">
                        <div class="grid-body no-border">
                            <div class="row-fluid">
                                <h3>Login <span class="semi-bold">Here</span></h3>
                                <p>Enter your username and password to login Into Admin Panel</p>

                                <div class="alert alert-block alert-error fade in" id="divMessage" visible="false" runat="server">
                                    <button type="button" class="close" data-dismiss="alert"></button>
                                    <p>
                                        <asp:Literal ID="lblMessage" Text="message" runat="server" />
                                    </p>
                                </div>

                                <div class="row form-row">
                                    <div class="input-append col-md-10 col-sm-10 primary">
                                        <asp:TextBox ID="txtusername" CssClass="form-control" placeholder="your Login Name" runat="server"> </asp:TextBox>
                                        <span class="add-on"><span class="arrow"></span><i class="fa fa-align-justify"></i></span>
                                    </div>
                                </div>
                                <div class="row form-row">
                                    <div class="input-append col-md-10 col-sm-10 primary">
                                        <asp:TextBox ID="txtpassword" CssClass="form-control" TextMode="Password" placeholder="your password" runat="server"> </asp:TextBox>
                                        <span class="add-on"><span class="arrow"></span><i class="fa fa-lock"></i></span>
                                    </div>
                                </div>
                            </div>
                            <div class="form-actions">
                                <div class="pull-left">
                                    <div class="control-group">
                                        <div class="checkbox checkbox check-success">
                                            <asp:CheckBox ID="chkRememberMe" Text="" runat="server" />
                                            <label for="chkRemind">Keep me reminded </label>
                                        </div>
                                    </div>
                                </div>
                                <div class="pull-right">
                                    <asp:Button Text="Login" ID="btnLogin" CssClass="btn btn-primary btn-cons-md" runat="server" OnClick="btnLogin_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


                <!-- END BASIC FORM ELEMENTS-->

            </div>

        </div>


    </form>
    <!-- END CONTAINER -->
    <!-- BEGIN CORE JS FRAMEWORK-->
    <script src="../assets/plugins/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script src="../assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="../assets/plugins/pace/pace.min.js" type="text/javascript"></script>
    <script src="../assets/plugins/jquery-validation/js/jquery.validate.min.js" type="text/javascript"></script>
    <script src="../assets/js/login.js" type="text/javascript"></script>
    <!-- BEGIN CORE TEMPLATE JS -->
    <!-- END CORE TEMPLATE JS -->
</body>
</html>
