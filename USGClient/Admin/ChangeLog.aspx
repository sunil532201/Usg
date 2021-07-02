<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="ChangeLog.aspx.cs" Inherits="USGClient.Admin.ChangeLog" %>

<%@ Register Src="~/Controls/AdminDetails.ascx" TagPrefix="uc1" TagName="AdminDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <uc1:AdminDetails runat="server" ID="AdminDetails" />
    <div class="card mb-3">
        <div class="card-header">
            <img id="logo" runat="server" class="LogoSize" /><span class="card-title">  Change Log</span>
                  
        </div>
        <div class="card-body bg-white">
          <div class="table-responsive">
              <table class="table table-bordered table-striped" id="dataTable" width="100%" >
                  <thead>
                      <tr>
                          <th>Change Date</th>
                          <th>Admin FirstName</th>
                          <th>Admin LastName</th>
                          <th>Log Type</th>
                          <th>Change Type</th>
                          <th>Details</th>
                          
                      </tr>
                  </thead>

                  <tbody>
                      <asp:Repeater runat="server" ID="rptChangelog"  >
                          <ItemTemplate>
                              <tr>
                                  <td><%# Eval("CreateDate","{0: MM/dd/yyyy}")%></td>
                                  <td><%# Eval("AdminFirstName") %></td>
                                  <td><%# Eval("AdminLastName") %></td>
                                  <td><%# Eval("AdminLogType") %></td>
                                  <td><%# Eval("Changetype")%></td>
                                  <td><a href='ChangeLog.aspx?LID=<%# Eval("AdminLogID") %>&CID=<%#Eval("CustomerID")%>'>DETAILS</a></td>
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
$(document).ready(function () {
            $('#dataTable').DataTable({
                "order": [[1, "ASC"]]
            });
         });
    </script>
</asp:Content>
