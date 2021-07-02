<%@ Page Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="SignTypeManager.aspx.cs" Inherits="USGClient.SignTypeManager" %>

<%@ Register Src="~/Controls/AdminDetails.ascx" TagPrefix="uc1" TagName="AdminDetails" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<li class="breadcrumb-item">
        <a href="SignTypeManager.aspx">Sign Types</a></li>
    <li class="breadcrumb-item active card-title">Sign Types List</li>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <uc1:AdminDetails runat="server" ID="AdminDetails" />
       <div class="card mb-3" runat="server" id="divClientUsers">
        <div class="card-header">
          <i class="fa fa-table"></i><span > Client Users</span>
          <div class="float-right;"><a class="btn btn-dark" href="ClientUserDetails.aspx?ID=<%=Request.QueryString["ID"] %>" id="toggleNavColor">Add User</a></div>
        </div>
        <div class="card-body bg-white" >
          <div class="table-responsive">
              <table class="table table-bordered table-striped" id="dataTable" width="100%" >
                  <thead>
                      <tr>
                          <th>Customer ID</th>
                          <th>Sign Type</th>
                          <th>Edit</th>
                          <th>Layouts</th>
                      </tr>
                  </thead>

                  <tbody>
                      <asp:Repeater runat="server" ID="rptAdministrator">
                          <ItemTemplate>
                              <tr>
                                  <td><%# Eval("CustomerID") %></td>
                                  <td><%# Eval("SignType") %></td>
                                  <td><a href='SignTypeDetails.aspx?ID=<%# Eval("CustomerSignTypeID") %>&CUID=<%# Eval("CustomerID") %>' style="color:#172C55">EDIT USER</a></td>
                                  <td><a href='Layouts.aspx?ID=<%# Eval("CustomerSignTypeID") %>&CUID=<%# Eval("CustomerID") %>' style="color:#172C55">VIEW LAYOUTS</a></td>
                              </tr>
                          </ItemTemplate>
                      </asp:Repeater>
                  </tbody>
              </table>
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
        });
    </script>
</asp:Content>