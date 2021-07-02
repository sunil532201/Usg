<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="USGClient.AdminLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #tblLogin{
            max-width:360px; 
            margin-left: auto; 
            margin-right:auto;
        }
        #tblLogin td{
            padding-bottom: 10px;
        }
        .tblLabel{
            padding-right: 10px;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBreadCrumbs" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPageTitle" runat="server">
    <h1>Login</h1>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphMainContent" runat="server">
    <table id="tblLogin">
        <tr>
            <td class="tblLabel">Email Address:</td>
            <td><asp:TextBox runat="server" ID="txtEmailAddress" CssClass="form-control"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="tblLabel">Password:</td>
            <td><asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control"></asp:TextBox></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td><asp:Button  runat="server" ID="btnLogin" Text="LOGIN" OnClick="btnLogin_Click" CssClass="btn btn-primary" /></td>
        </tr>
        <tr>
            <td colspan="2"><asp:Label runat="server" ID="lblError" ForeColor="Red"></asp:Label></td>
        </tr>
    </table>
</asp:Content>
