<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="ReportWeeklyCash.aspx.cs" Inherits="USGClient.Admin.ReportWeeklyCash" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
     <ul class="nav nav-pills  mb-20" id="ReportCash"  runat="server" visible="true">
        <li runat="server" id="liOutstanding" class="nav-item">
          <a runat="server" id="lnkOutstanding" href="InvoicesMaintenance.aspx" class="nav-link">Outstanding</a></li>
        <li runat="server" id="liPaid" class="nav-item" >
            <a runat="server" id="lnkPaid" href="InvoicesMaintenance.aspx?PaidClick=true" class="nav-link">Paid</a></li>
       <li runat="server" id="liWeeklyCash" class="nav-item" >
            <asp:LinkButton runat="server" ClientIDMode="Static" ID="lnkWeeklyCash" OnClick="ReportWeeklyCash_Click" Text="ReportWeeklyCash" class="nav-link active"></asp:LinkButton></li>
    </ul>

     <div class="card mb-3">
        <div class="card-header">
            <i class="fa fa-table " ></i><span class="card-title"> Invoices Report</span>
        </div>
        <div class="card-body bg-white" >
           
         <div class="table-responsive">
              <asp:PlaceHolder ID = "PlaceHolder1" runat="server" />
               <table class="table table-bordered table-striped" id="dataTable" width="100%" >
                  <thead>
                      <tr>
                         
                          <th>Customer Name</th>
                          <th>Invoice Date</th>
                          <th>Date Due</th>
                          <th>Invoice Number</th>
                          <th style="text-align:right">Invoice Total</th>
                          <th style="text-align:right">Balance Due</th>
                          
                      </tr>
                  </thead>
                  <tbody>
                      <asp:Repeater runat="server" ID="rptReportCash">
                          <ItemTemplate>
                              <tr>
                                  
                                  <td><%# Eval("customername") %></td>
                                  <td><%# Eval("InvoiceDate","{0: MM/dd/yyyy}") %></td>
                                  <td><%# Eval("DueDate","{0: MM/dd/yyyy}") %></td>
                                  <td><%# Eval("InvoiceNumber") %></td>
                                  <td style="text-align:right">$ <%# Eval("InvoiceTotal") %></td>
                                  <td style="text-align:right">$ <%# Eval("BalanceDue") %></td>
                              </tr>
                          </ItemTemplate>
                      </asp:Repeater>
                  </tbody>
              </table>
              <%--<asp:Button CssClass="btn btn-dark" ID="btnback" runat="server" OnClientClick="JavaScript:window.history.back(1); return false;" Text="Back" />--%>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <script>
        $(document).ready(function () {
            debugger
            $(function() {
            var rows = [];
            $('#dataTable tr td:first-child').each(function(){
               var rowText = $(this).text();
               rows.push(rowText);
               if (rowText.includes("Total for the week ending")) {
                 $(this).parent().css('font-weight', 'bold');
               }
            });
            });
        });
    </script>
</asp:Content>
