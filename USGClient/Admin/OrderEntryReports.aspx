<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="OrderEntryReports.aspx.cs" Inherits="USGClient.Admin.OrderEntryReports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="card mb-3">
        <div class="card-header">
         <img id="logo" runat="server" class="LogoSize"/><span class="card-title"> Order Entry Report</span>
           <div class="float-right"> <a class="btn btn-dark mr-30" href="OrderEntryLanding.aspx?CID=<%=Request.QueryString["CID"]%>&JID=<%=Request.QueryString["JID"]%>" id="orderEntryButton" >Back</a></div>

        </div>
        <div class="card-body bg-white" >

         
        </div>
    </div>
</asp:Content>
<asp:Content runat="server" ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3">
    <script>
        // Call the dataTables jQuery plugin
        $(document).ready(function () {
            $.fn.dataTable.moment('M/D/YYYY');
            $('#dataTable').DataTable({
                "order": [[2, "asc"]]
            });
        });
    </script>
</asp:Content>