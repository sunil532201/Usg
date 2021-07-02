<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="LaminantDetails.aspx.cs" Inherits="USGClient.Admin.LaminantDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="card mb-3">
        <div class="card-header">
            <i class="fa fa-table "></i><span class="card-title"> Laminant Details </span>&nbsp;&nbsp;&nbsp;
            <asp:Label runat="server" ID="lblMessage" ></asp:Label>
        </div>
        <div class="card-body bg-white" >
            <div class="table-responsive">
                <table class="table table-bordered table-striped" style="width: 100%">
                    <tbody>
                        <tr>
                            <td >Laminant ID :</td>
                             <td><asp:Label runat="server" ID="lblLaminantID"></asp:Label></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td >Laminant Item :</td>
                            <td><asp:TextBox ID="txtLaminant" CssClass="form-control" runat="server" /></td>
                            <td></td>
                        </tr>
                        
                    </tbody>
                </table>
                <asp:LinkButton ID="lnkSaveMaterialItemDetails" runat="server" CssClass="btn btn-dark" OnClick="lnkSaveMaterialItemDetails_Click" Text="Update"></asp:LinkButton>
                <asp:Button CssClass="btn btn-dark" ID="BacktoMaterialItem" runat="server" Text="Back" OnClick="BacktoMaterialItem_Click"/>
            </div>
             
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
