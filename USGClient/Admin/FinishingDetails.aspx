<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="FinishingDetails.aspx.cs" Inherits="USGClient.Admin.FinishingDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="card mb-3">
        <div class="card-header">
            <i class="fa fa-table "></i><span class="card-title"> Finishing Details </span>&nbsp;&nbsp;&nbsp;
            <asp:Label runat="server" ID="lblMessage" ></asp:Label>
        </div>
        <div class="card-body bg-white" >
            <div class="table-responsive">
                <table class="table table-bordered table-striped" style="width: 100%">
                    <tbody>
                        <tr>
                            <td >Finishing Item ID :</td>
                             <td><asp:Label runat="server" ID="lblFinishingItemID"></asp:Label></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td >Finishing Item :</td>
                            <td><asp:TextBox ID="txtFinishingItem" CssClass="form-control" runat="server" /></td>
                            <td></td>
                        </tr>
                        
                    </tbody>
                </table>
                <asp:LinkButton ID="lnkSaveFinishingItemDetails" runat="server" CssClass="btn btn-dark" OnClick="lnkSaveFinishingItemDetails_Click" Text="Update"></asp:LinkButton>
                <asp:Button CssClass="btn btn-dark" ID="BacktoFinishingItem" runat="server" Text="Back" OnClick="BacktoFinishingItem_Click"/>
            </div>
             
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
