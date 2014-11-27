<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanale/MasterPages/Pages.Master" AutoEventWireup="true" CodeBehind="ContactList.aspx.cs" Inherits="WebGUI.AdminPanale.MainPages.ContactList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainCPH" runat="server">


    <div>

        <div class="row">
            <div class="col-md-12">
                <div class="grid simple">
                    <div class="grid-title no-border">
                        <h4><%= WebGUI.AdminPanale.MasterPages.Pages.PageTitle %>  <span class="semi-bold">List</span></h4>
                        <div class="tools">
                            <asp:Button CssClass="btn btn-primary btn-cons-md" ID="btnAddNew" Text="Add New..." runat="server" OnClick="btnAddNew_Click" />
                        </div>
                    </div>
                    <div class="grid-body no-border">
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <div class="controls">
                                        <asp:GridView ID="grdData"
                                            runat="server"
                                            AutoGenerateColumns="False"
                                            OnItemCommand="grdData_RowCommand"
                                            CssClass="table table-striped table-flip-scroll cf table-hover" OnRowCommand="grdData_RowCommand" OnRowDataBound="grdData_RowDataBound">
                                            <Columns>
                                                <asp:BoundField DataField="Title" HeaderText="contact Title" SortExpression="title">
                                                    <HeaderStyle Width="70%" />
                                                    <ItemStyle Width="70%" />
                                                </asp:BoundField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                                                                                <asp:Button ID="btnMoveUp"
                                                            CssClass="btn btn-default btn-sm btn-small"
                                                            Text='Up'
                                                            CommandName="MoveUp"
                                                            CommandArgument='<%# Eval("id") %>'
                                                            data-toggle="tooltip"
                                                            title="MoveUp Item"
                                                            data-placement="bottom"
                                                            runat="server" />

                                                        <asp:Button ID="btnMoveDown"
                                                            CssClass="btn btn-default btn-sm btn-small"
                                                            Text='Down'
                                                            CommandName="MoveDown"
                                                            CommandArgument='<%# Eval("id") %>'
                                                            data-toggle="tooltip"
                                                            title="MoveDown Item"
                                                            data-placement="bottom"
                                                            runat="server" />

                                                        <button
                                                            class="btn btn-default btn-sm btn-small"
                                                            type="button"
                                                            data-toggle="tooltip"
                                                            title='<%# DAL.Extensions.GeneralMethods.GetRecordInfo(Eval("CreatedOn").ToString(),Eval("CreatedBy").ToString(),Eval("ModifiedOn").ToString(),Eval("ModifiedBy").ToString()) %>'
                                                            data-placement="bottom">
                                                            <i class="fa fa-map-marker"></i>
                                                        </button>
                                                        <asp:Button ID="btnRestore"
                                                            CssClass="btn btn-default btn-sm btn-small"
                                                            Text='Restore'
                                                            CommandName="restoreitem"
                                                            CommandArgument='<%# Eval("id") %>'
                                                            data-toggle="tooltip"
                                                            title="Restore Item"
                                                            data-placement="bottom"
                                                            Visible='<%# DAL.Extensions.GeneralMethods.DeleteRestorVisible(Eval("Active"),"true") %>'
                                                            runat="server" />

                                                        <asp:Button ID="btnDelete"
                                                            CssClass="btn btn-default btn-sm btn-small"
                                                            Text="Delete"
                                                            CommandName="deleteitem"
                                                            CommandArgument='<%# Eval("id") %>'
                                                            OnClientClick="if(!confirm('Are you sure you want delete this?')) return false;"
                                                            data-toggle="tooltip"
                                                            title="Delete Item"
                                                            data-placement="bottom"
                                                            Visible='<%# DAL.Extensions.GeneralMethods.DeleteRestorVisible(Eval("Active"),"false") %>'
                                                            runat="server" />

                                                        <asp:HyperLink ID="btnEdit" runat="server"
                                                            CssClass="btn btn-default btn-sm btn-small"
                                                            NavigateUrl='<%#"~/AdminPanale/MainPages/ContactManagement.aspx?ID="+Eval("id")%>'
                                                            data-toggle="tooltip"
                                                            title="Edit Item"
                                                            data-placement="bottom"
                                                            Text="Edit">
                                                        </asp:HyperLink>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>

                                        </asp:GridView>



                                    </div>

                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>


    </div>


</asp:Content>
