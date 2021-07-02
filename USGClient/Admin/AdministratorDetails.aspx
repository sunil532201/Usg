<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/AdminPage1.Master" CodeBehind="AdministratorDetails.aspx.cs" Inherits="USGClient.Admin.AdminUserDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .table td, .table th {
            vertical-align: middle;
        }
    </style>
</asp:Content>
<%@ Register Src="~/Controls/AdministratorMenu.ascx" TagPrefix="uc1" TagName="AdministratorMenu" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
        <uc1:AdministratorMenu runat="server" ID="AdministratorMenu" />

    <div class="card mb-3">
        <div class="card-header">
            <i class="fa fa-table " ></i><span class="card-title"> Admin Details</span>&nbsp;&nbsp;&nbsp;
            <asp:Label runat="server" ID="lblMessage"></asp:Label>
        </div>
        <div class="card-body bg-white" >
            <div class="table-responsive">
                <table class="table table-bordered table-striped" cellspacing="0">
                    <tbody>
                        <tr>
                            <td style="font-weight: bold;" >Admin ID:
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblAdminID"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold;">First Name:
                            </td>
                            <td>
                                <asp:TextBox ID="txtAdminFirstName" runat="server" CssClass="form-control"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold;">Last Name:
                            </td>
                            <td>
                                <asp:TextBox ID="txtAdminLastName" runat="server" CssClass="form-control"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold;" >Email Address:
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmailAddress" runat="server" CssClass="form-control"></asp:TextBox>
                            </td>
                        </tr>
<%--                         <tr>
                            <td>Password:
                            </td>
                            <td>
                                <asp:TextBox ID="txtAdminPwd" runat="server" CssClass="form-control"></asp:TextBox>
                            </td>
                        </tr>--%>
                        <tr>
                            <td style="font-weight: bold;" >Active:
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rbActive" runat="server" RepeatDirection="Vertical" RepeatLayout="Flow">
                                    <asp:ListItem Value="True">Yes</asp:ListItem>
                                    <asp:ListItem Value="False">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr >
                           
                            <td style="font-weight: bold;">Admin User Roles:
                            </td>
                            <td runat="server" class="rolesDiv">
                                <div style="width: 300px; height:505px"><SPAN STYLE="font-weight:bold">Left Menu</SPAN> <br><br>
                                <asp:CheckBoxList ID="chkLeftMenu" RepeatLayout="Flow" RepeatDirection="Horizontal" runat="server">
                                </asp:CheckBoxList></div>
                               <div style="width: 300px; height:505px"><SPAN STYLE="font-weight:bold">Top Menu</SPAN> <br><br>
                                <asp:CheckBoxList ID="chkTopMenu" RepeatLayout="Flow" RepeatDirection="Horizontal" runat="server">
                                </asp:CheckBoxList></div>
                                <div style="width: 300px; height:505px" ><SPAN STYLE="font-weight:bold">Dropdown</SPAN> <br><br>
                               <asp:CheckBoxList ID="chkDropdown" RepeatLayout="Flow" RepeatDirection="Horizontal" runat="server">
                                </asp:CheckBoxList></div>

                                <asp:PlaceHolder ID="chkRolesPanel"    runat="server"></asp:PlaceHolder>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <asp:LinkButton ID="LnkUpdateUserInfo" runat="server" CssClass="btn btn-dark" Text="Update" OnClick="LnkUpdateUserInfo_Click"></asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">

    <script>
       
    </script>
</asp:Content>

