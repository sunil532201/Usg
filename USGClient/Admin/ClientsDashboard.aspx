<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="ClientsDashboard.aspx.cs" Inherits="USGClient.Admin.ClientsDashBoard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <ul class="nav nav-pills mb-20">
        <li runat="server" id="lblActive" class="nav-item">
            <asp:LinkButton runat="server" ID="lnkActive" OnClick="lnkActive_Click"  Text="Active"></asp:LinkButton></li>
        <li runat="server" id="lblInactive" class="nav-item" >
            <asp:LinkButton runat="server" ID="lnkInactive" OnClick="lnkInactive_Click"  Text="Inactive"></asp:LinkButton></li>
        <li runat="server" id="lblChargeGuest" class="nav-item">
            <asp:LinkButton runat="server" ID="lnkChargeGuest" OnClick="lnkChargeGuest_Click"  Text="Charged Guest"></asp:LinkButton></li>
        <li runat="server" id="lblNoChargeGuest" class="nav-item" >
            <asp:LinkButton runat="server" ID="lnkNoChargeGuest" OnClick="lnkNoChargeGuest_Click"  Text="No Charge Guest"></asp:LinkButton></li>
    </ul>
    <div class="card mb-3">
        <div class="card-header">
            <i class="fa fa-table " ></i><span class="card-title"> Clients</span>
             <div class="float-right"><a class="btn btn-dark" href="ClientDetails.aspx" id="toggleNavColor">Add Client</a></div>
        </div>
        <div class="card-body bg-white" >

          <div class="table-responsive">
              <table class="table table-bordered table-striped" id="dataTable" width="100%" >
                  <thead>
                      <tr>
                          <th>Client ID</th>
                          <th>Date</th>
                          <th>Client Name</th>
                          <th>View</th>
                      </tr>
                  </thead>
                  <tbody>
                      <asp:Repeater runat="server" ID="rptList">
                          <ItemTemplate>
                              <tr>
                                  <td><%# Eval("CustomerID") %></td>
                                  <td><%# Convert.ToDateTime(Eval("CreateDate")).ToString("MM/dd/yyyy") %></td>
                                  <td><%# Eval("CustomerName") %></td>
                                  <td><a href='ClientDetails.aspx?CID=<%# Eval("CustomerID") %>' style="color:#172C55" >DETAILS</a></td>
                              </tr>
                          </ItemTemplate>
                      </asp:Repeater>
                  </tbody>
              </table>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
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
