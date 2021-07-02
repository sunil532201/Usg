<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/ClientPage.Master" AutoEventWireup="true" CodeBehind="Invoices.aspx.cs" Inherits="USGClient.ClientPortal.Invoices" %>

<%--<%@ Register Src="~/Controls/InvoicesControl.ascx" TagPrefix="uc1" TagName="InvoicesControl" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageTitle" runat="server">
     <h5>Approval System</h5>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadCrumbs" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphMainContent" runat="server">
    <%--<uc1:InvoicesControl runat="server" id="InvoicesControl" />--%>
     <ul class="nav nav-pills mb-20" id="Invoice"  runat="server" visible="true">
        <li runat="server" id="liOutstanding" class="nav-item">
            <asp:LinkButton runat="server" ID="lnkOutstanding" OnClick="lnkOutstanding_Click"  Text="Outstanding"></asp:LinkButton></li>
        <li runat="server" id="liPaid" class="nav-item" >
            <asp:LinkButton runat="server" ID="lnkPaid" OnClick="lnkPaid_Click" Text="Paid"></asp:LinkButton></li>
       
    </ul>
  <%-- <asp:MultiView ID="MultiView1" runat="server">
         <asp:View ID="InvoicesTotal" runat="server">--%>
     <div class="card mb-3 pb-30" id="invoiceCount" runat="server" visible="false">
        <div class="card-header">
            <i class="fa fa-table " ></i><span class="card-title"> Amount Due</span>
             
        </div>
        <div class="card-body bg-white" >
          <div class="table-responsive">
              <table class="table table-bordered table-striped" id="dataTable" width="100%" >
                  <thead>
                      <tr>
                          <th>0-30</th>
                          <th>31-60</th>
                          <th>61-90</th>
                          <th>Over 90 Days</th>
                          <th>Total</th>
                      </tr>
                  </thead>
                  <tbody>
                      <asp:Repeater runat="server" ID="rptInvoices">
                          <ItemTemplate>
                              <tr>
                                  <td>$ <%# Eval("Thirtydays") %></td>
                                  <td>$ <%# Eval("Sixtydays") %></td>
                                  <td>$ <%# Eval("Nintydays") %></td>
                                  <td>$ <%# Eval("MorethanNintydays") %></td>
                                  <td>$ <%# Eval("Totalcount") %></td>
                              </tr>
                          </ItemTemplate>
                      </asp:Repeater>
                  </tbody>
              </table>
            </div>
        </div>
    </div>
           <%--  </asp:View>--%>
      
       <%--<asp:View ID="InvoiceDetails" runat="server">--%>
    <div class="card mb-3" id="invoiceDetails" runat="server" visible="true">
        <div class="card-header">
            <i class="fa fa-table " ></i><span class="card-title"> Invoices</span>
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
                                  <td style="text-align:center"><a  href="Invoices.aspx?url=<%# Eval("PDFURL") %>" target="_blank" >View PDF</a></td>
                                  
                              </tr>
                          </ItemTemplate>
                      </asp:Repeater>
                  </tbody>
              </table>
            </div>
        </div>
    </div>
           <%--</asp:View>
        </asp:MultiView>--%>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphFooter" runat="server">
</asp:Content>
