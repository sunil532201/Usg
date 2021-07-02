<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="Administrator.aspx.cs" Inherits="USGClient.Admin.Administrator" %>
<%@ Register Src="~/Controls/AdministratorMenu.ascx" TagPrefix="uc1" TagName="AdministratorMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
        <%--<uc1:AdministratorMenu runat="server" id="AdministratorMenu" />--%>
    <ul class="nav nav-tabs md-tabs" id="myTabEx" role="tablist">
  <li class="nav-item">
    <a class="nav-link active show" id="active-tab-ex" data-toggle="tab" href="#active-ex" role="tab" aria-controls="active-ex"
      aria-selected="true">Active</a>
  </li>
  <li class="nav-item">
    <a class="nav-link" id="inActive-tab-ex" data-toggle="tab" href="#inActive-ex" role="tab" aria-controls="inActive-ex"
      aria-selected="false">Inactive</a>
  </li>
        </ul>

     <%-- <asp:MultiView ID="MultiView1" runat="server">
          <asp:View ID="Active" runat="server">--%>
    <div class="card mb-3">
        <div class="card-header">
            <i class="fa fa-table "></i><span class="card-title"> Administrator</span>
             <div class="float-right"><a class="btn btn-dark" href="AdministratorDetails.aspx" id="toggleNavColor">Add Administrators</a></div>
        </div>
        <div class="card-body bg-white">
          <div class="table-responsive">

           <div class="tab-content pt-5" id="myTabContentEx">
 <div class="tab-pane fade active show" id="active-ex" role="tabpanel" aria-labelledby="active-tab-ex">
              <table class="table table-bordered table-striped" id="dataTable" width="100%" >
                  <thead>
                      <tr>
                          <th>Administrator ID</th>
                          <th>First Name</th>
                          <th>Last Name</th>
                          <th>Email Address</th>
                          <th>Active</th>
                          <th>View</th>
                      </tr>
                  </thead>

                  <tbody>
                      <asp:Repeater runat="server" ID="rptActiveAdministrator">
                          <ItemTemplate>
                              <tr>
                              <td><%# Eval("AdministratorID") %></td>
                              <td><%# Eval("AdminFirstName") %></td>
                              <td><%# Eval("AdminLastName") %></td>
                              <td><%# Eval("EmailAddress") %></td>
                              <td><%# ParseActive(Eval("Active")) %></td>
                              <td><a href='AdministratorDetails.aspx?ID=<%# Eval("AdministratorID") %>'>DETAILS</a></td>   
                              </tr>
                             
                          </ItemTemplate>
                      </asp:Repeater>
                  </tbody>
              </table>
            </div>
 
 <div class="tab-pane fade" id="inActive-ex" role="tabpanel" aria-labelledby="inActive-tab-ex">
                      <table class="table table-bordered table-striped" id="dataTable1" width="100%" >
                  <thead>
                      <tr>
                          <th>Administrator ID</th>
                          <th>First Name</th>
                          <th>Last Name</th>
                          <th>Email Address</th>
                          <th>Active</th>
                          <th>View</th>
                      </tr>
                  </thead>

                  <tbody>
                      <asp:Repeater runat="server" ID="rptInactiveAdministrator">
                          <ItemTemplate>
                              <tr>
                              <td><%# Eval("AdministratorID") %></td>
                              <td><%# Eval("AdminFirstName") %></td>
                              <td><%# Eval("AdminLastName") %></td>
                              <td><%# Eval("EmailAddress") %></td>
                              <td><%# ParseActive(Eval("Active")) %></td>
                              <td><a href='AdministratorDetails.aspx?ID=<%# Eval("AdministratorID") %>'>DETAILS</a></td>   
                              </tr>
                          </ItemTemplate>
                      </asp:Repeater>
                  </tbody>
                          </table>
                      </div>
                  </div>
        </div>
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

            $('#dataTable1').DataTable({
                "order": [[2, "asc"]]
            });
        });
    </script>
</asp:Content>
