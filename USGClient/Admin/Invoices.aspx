<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="Invoices.aspx.cs" Inherits="USGClient.Admin.Invoices" %>

<%@ Register Src="~/Controls/JobMenuControl.ascx" TagPrefix="uc1" TagName="JobMenuControl" %>
<%@ Register Src="~/Controls/AdminDetails.ascx" TagPrefix="uc1" TagName="AdminDetails" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <uc1:AdminDetails runat="server" ID="AdminDetails" />
<%--    <uc1:JobMenuControl runat="server" ID="JobMenuControl" />--%>
    <div class="card mb-3">
        <div class="card-header">
            <img id="logo" runat="server" class="LogoSize"/><span class="card-title"> Invoices</span>
        </div>
        <div class="card-body bg-white" >
          <div class="table-responsive">
              <table class="table table-bordered table-striped" id="dataTable" width="100%" >
                  <thead>
                      <tr>
                          <th>Invoice Number</th>
                          <th>Invoice Date</th>
                          <th>Date Due</th>
                          <th>Job Number</th>
                          <th style="text-align:right">Invoice Total</th>
                          <th style="text-align:center">View Invoice</th>
                      </tr>
                  </thead>
                  <tbody>
                      <asp:Repeater runat="server" ID="rptInvoiceList">
                          <ItemTemplate>
                              <tr>
                                  <td><%# Eval("InvoiceNumber") %></td>
                                  <td><%# Eval("InvoiceDate","{0: MM/dd/yyyy}") %></td>
                                  <td><%# Eval("DueDate","{0: MM/dd/yyyy}") %></td>
                                  <td><%# Eval("Prefix")+"-"+Eval("JobID") %></td>
                                  <td style="text-align:right">$ <%# Eval("InvoiceTotal") %></td>
                                  <%--<td style="text-align:center"><a href="http://docs.google.com/gview?url=<%# Eval("PDFURL") %>&embedded=true" target="_blank">View PDF</a></td>--%>
                                  <td style="text-align:center"><a  href="Invoices.aspx?url=<%# Eval("PDFURL") %>&JID=<%=Request.QueryString["JID"]%>&CID=<%=Request.QueryString["CID"]%>" target="_blank" >View PDF</a></td>
                              </tr>
                          </ItemTemplate>
                      </asp:Repeater>
                  </tbody>
              </table>
              <asp:Button CssClass="btn btn-dark" ID="btnback" runat="server" OnClientClick="JavaScript:window.history.back(1); return false;" Text="Back" />
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
        <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script>
        $(document).ready(function () {
            $('#cusName').hide();
        });

    </script>
</asp:Content>
