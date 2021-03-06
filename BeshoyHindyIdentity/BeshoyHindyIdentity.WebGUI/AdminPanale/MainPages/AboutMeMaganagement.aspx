﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanale/MasterPages/Pages.Master" AutoEventWireup="true" CodeBehind="AboutMeMaganagement.aspx.cs" Inherits="WebGUI.AdminPanale.MainPages.AboutMeMaganagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainCPH" runat="server">

    <div>
        <!-- BEGIN BASIC FORM ELEMENTS-->
        <div class="row">
            <div class="col-md-12">
                <div class="grid simple">
                    <div class="grid-title no-border">
                        <h4><%= WebGUI.AdminPanale.MasterPages.Pages.PageTitle %>  <span class="semi-bold">Management</span></h4>
                        <div class="tools"><a href="javascript:;" class="collapse"></a></div>
                    </div>
                    <div class="grid-body no-border">
                        <br>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="alert alert-block alert-success fade in" id="divMessage" runat="server" visible="false">
                                    <img src="../assets/img/icon/icon-success.png" style="float: left; padding-right: 10PX;" />
                                    <button type="button" class="close" data-dismiss="alert"></button>
                                    <h4 class="alert-heading"><i class="icon-success-sign"></i>
                                        <asp:Literal ID="lblMessage" runat="server" /></h4>
                                </div>

                                <div class="form-group">
                                    <label class="form-label">Name :.</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtName" CssClass="form-control " runat="server" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="form-label">Job Title :.</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtJobTitle" CssClass="form-control " runat="server" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="form-label">Date OF Birth :.</label>
                                    <div class="controls">
                                        <div class="input-append success date  no-padding">
                                            <asp:TextBox ID="txtBirthdate" CssClass="form-control " runat="server" />
                                            <span class="add-on"><span class="arrow"></span><i class="fa fa-th"></i></span>
                                        </div>

                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="form-label">Phone :.</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtPhone" CssClass="form-control " runat="server" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="form-label">E-Mail :.</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtEmail" CssClass="form-control " runat="server" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="form-label">Web Site URL :.</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtWebSiteURL" CssClass="form-control " runat="server" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="form-label">Reusme RUL - 'filename' :.</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtReusmeURL" CssClass="form-control " runat="server" />
                                    </div>
                                </div>

                                <!--image here-->
                                <div class="form-group">
                                    <label class="form-label">Current Image :.</label>
                                    <div class="controls">
                                        <asp:Image runat="server" ID="imgImage" Width="200px" Height="200px" CssClass="form-control" Visible="false" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="form-label">Image :.</label>
                                    <div class="controls">

                                        <asp:FileUpload ID="fpld" CssClass="form-control" runat="server" />
                                    </div>
                                </div>
                                <!-- end image -->
                                <div class="form-group">
                                    <label class="form-label">Address :.</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtAddress" CssClass="form-control " runat="server" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="form-label">Quote :.</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtQuote" TextMode="MultiLine" Rows="4" CssClass="form-control " runat="server" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="form-label">Identity Description :.</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtIdentityDescription" TextMode="MultiLine" Rows="4" CssClass="form-control " runat="server" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="form-label">Experience Years :.</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtExperienceYears" CssClass="form-control " runat="server" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="form-label">Clines :.</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtClints" CssClass="form-control " runat="server" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="form-label">Projects :.</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtProjects" CssClass="form-control " runat="server" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="form-label">Certifications :.</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtCertifications" CssClass="form-control " runat="server" />
                                    </div>
                                </div>

                                <div class="form-actions">
                                    <div class="pull-right">
                                        <div class="control-group">
                                            <asp:Button CssClass="btn btn-primary btn-cons-md" ID="btnSave" Text="Save" runat="server" OnClick="btnSave_Click" />
                                            <asp:Button CssClass="btn btn-primary btn-cons-md" ID="btnSaveAndNew" Text="Save And New" runat="server" OnClick="btnSaveAndNew_Click" />
                                            <asp:Button CssClass="btn btn-primary btn-cons-md" ID="btnBack" Text="Back" runat="server" OnClick="btnBack_Click" />
                                            <asp:Button CssClass="btn btn-primary btn-cons-md" ID="btnClear" Text="Clear" runat="server" OnClick="btnClear_Click" />
                                        </div>
                                    </div>
                                </div>

                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- END BASIC FORM ELEMENTS-->

    </div>


</asp:Content>
