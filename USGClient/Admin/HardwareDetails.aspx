<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="HardwareDetails.aspx.cs" Inherits="USGClient.Admin.HardwareDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="card mb-3">
        <div class="card-header">
            <i class="fa fa-table "></i><span class="card-title"> Hardware Details </span>&nbsp;&nbsp;&nbsp;
            <asp:Label runat="server" ID="lblMessage" ></asp:Label>
        </div>
        <div class="card-body bg-white" >
            <div class="table-responsive">
                <table class="table table-bordered table-striped" style="width: 100%">
                    <tbody>
                        <tr>
                            <td >Hardware Item ID :</td>
                             <td><asp:Label runat="server" ID="lblHardwareItemID"></asp:Label></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td >Hardware Item :</td>
                            <td><asp:TextBox ID="txtHardwareItem" CssClass="form-control" runat="server" /></td>
                            <td></td>
                        </tr>
                        
                    </tbody>
                </table>
                <asp:LinkButton ID="lnkSaveHardwareItemDetails" runat="server" CssClass="btn btn-dark" OnClick="lnkSaveMHardwareItemDetails_Click" Text="Update"></asp:LinkButton>
                <asp:Button CssClass="btn btn-dark" ID="BacktoHardwareItem" runat="server" Text="Back" OnClick="BacktoHardwareItem_Click"/>
            </div>
             
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
