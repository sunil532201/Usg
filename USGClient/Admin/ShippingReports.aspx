<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="ShippingReports.aspx.cs" Inherits="USGClient.Admin.ShippingReports" %>
<%@ Register Src="~/Controls/AdminDetails.ascx" TagPrefix="uc1" TagName="AdminDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
        <uc1:AdminDetails runat="server" ID="AdminDetails" />
    
    <div class="card mb-3">
       <div class="card-header">
           <img id="logo" runat="server" class="LogoSize"/> <span class="card-title"> Shipping Report</span>
                    <div class="float-right"> <a class="btn btn-dark mr-30" href="OrderEntryLanding.aspx?CID=<%=Request.QueryString["CID"]%>&JID=<%=Request.QueryString["JID"]%>" id="orderEntryButton" >Back</a></div>

        </div>
        <div class="card-body bg-white" >
           <div class="float-left"> 
               <asp:Button ID="btnShippingTos" CssClass="btn btn-dark mr-30" runat="server" OnClick="btnShippingTos_Click" Text="Shipping TOS"/>
               <asp:Button ID="btnPackingSlips" CssClass="btn btn-dark mr-30" runat="server" OnClick="btnPackingSlips_Click" Text="Packing Slips"/>
               <asp:Button ID="btnPrintLabels" CssClass="btn btn-dark" runat="server" OnClick="btnPrintLabels_Click" Text="Print Labels"/></div>
        </div>
    </div>
</asp:Content>
<asp:Content runat="server" ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3">
   
</asp:Content>