<%@ Page Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="SignTypeFamilies.aspx.cs" Inherits="USGClient.Admin.SignTypeFamilies" %>

<%@ Register Src="~/Controls/AdminDetails.ascx" TagPrefix="uc1" TagName="AdminDetails" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <uc1:AdminDetails runat="server" ID="AdminDetails" />

    <div class="card mb-3">
    <table>
        <tr>
        <%--<td><b>New Preset Name:</b></td>--%>
            <td><asp:TextBox ID="txtSignTypeFamily" placeholder="New Sign Type Family Name" CssClass="form-control" runat="server"></asp:TextBox></td>
            <td><asp:Button ID="btnAddSTFamily" class="btn btn-dark" runat="server" Text="Add" OnClick="btnAddSTFamily_Click"/></td>
        </tr>
    </table>
        </div>

   
        <div class="card-header">
            <img id="logo" runat="server" class="LogoSize"/><span class="card-title"> Sign Type Family</span>
             
        </div>
        <div class="card-body bg-white">
          <div class="table-responsive">
              <table class="table table-bordered table-striped" id="dataTable" width="100%" >
                  <thead>
                      <tr>
                          <th>No</th>
                          <th>Sign Type Family </th>
                          <th>Delete</th>
                      </tr>
                  </thead>

                  <tbody>
                      <asp:Repeater runat="server" ID="rptSTFamily" >
                          <ItemTemplate>
                              <tr>
                                  <td><%# Eval("CustomerSignTypeGroupID") %></td>
                                  <td><%# Eval("SignTypeFamily") %></td>
                                  <td><asp:LinkButton runat="server" ID="btnDelete"  OnClick="btnDelete_Click" OnClientClick="return confirm('Are you sure you want to delete this file?');" CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CustomerSignTypeGroupID")%>'>Delete</asp:LinkButton></td>

                              </tr>
                          </ItemTemplate>
                      </asp:Repeater>
                  </tbody>
              </table>
            </div>
        </div>
   
</asp:Content>
<asp:Content runat="server" ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3">
   
    <script>
        // Call the dataTables jQuery plugin
        $(document).ready(function () {
            $.fn.dataTable.moment('M/D/YYYY');
            $('#dataTable').DataTable({
                "order": [[1, "asc"]]
            });
        });

    </script>
</asp:Content>