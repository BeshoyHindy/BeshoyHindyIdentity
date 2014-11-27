<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanale/MasterPages/Pages.Master" AutoEventWireup="true" CodeBehind="WorkTypeManagement.aspx.cs" Inherits="WebGUI.AdminPanale.MainPages.WorkTypeManagement" %>

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
                                    <label class="form-label">Work Type Name :.</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtTypeName" CssClass="form-control " runat="server" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="form-label">Class Name (Uniqe Name) :.</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtClassName" CssClass="form-control " runat="server" />
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
