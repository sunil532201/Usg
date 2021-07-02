<%@ Page Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="FinishingsList.aspx.cs" Inherits="USGClient.Admin.FinishingsList" %>

<%@ Register Src="~/Controls/DatabaseMaintenanceMenu.ascx" TagPrefix="uc1" TagName="DatabaseMaintenanceMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <uc1:DatabaseMaintenanceMenu runat="server" ID="DatabaseMaintenanceMenu" />

     <div class="row mb-3">
            <div class="col-4">
                <asp:TextBox ID="txtFinishing" placeholder="New Finishing Name" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-8">
                <asp:Button ID="btnAddFinishing" class="btn btn-dark" runat="server" Text="Add" OnClick="btnAddFinishing_Click"/>
           </div>
    </div>

  
     <div class="card-header">
             <i class="fa fa-table "></i><span class="card-title"> Finishings </span>
        </div>
        <%-- <div class="card mb-3">
        <div class="card-header">
            <i class="fa fa-table "></i><span class="card-title"> Finishings </span>
            <div class="float-right"><a class="btn btn-dark" href="FinishingDetails.aspx" id="liFinishig">Create Finishing</a></div>
        </div>--%>
        <div class="card-body bg-white">
          <div class="table-responsive">
              <table class="table table-bordered table-striped" id="dataTable" width="100%" >
                  <thead>
                      <tr>
                          <th>Finishing ItemID </th>
                          <th>Finishing Item </th>
                          <th>Update</th>
                          <th>Delete</th>
                      </tr>
                  </thead>

                  <tbody>
                      <asp:Repeater runat="server" ID="rptFinishingbyID" >
                          <ItemTemplate>
                              <tr>
                                  <td><%# Eval("FinishingItemID") %></td>
                                  <td><asp:TextBox CssClass="form-control" onkeypress="return MoveNext('btnUpdatetxtFinishingName',event.keyCode);" ClientIDMode="Static" runat="server"  ID="txtFinishingName" Text='<%# Eval("FinishingItem") %>'></asp:TextBox></td>
                                  <td><asp:LinkButton runat="server" ID="btnUpdateFinishingname" OnClick="btnUpdatetxtFinishingName" CommandName="UpdateFinishingName" ClientIDMode="Static" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "FinishingItemID") %>'>UPDATE</asp:LinkButton></td>
                                  <td><asp:LinkButton runat="server" ID="btnDelete"  OnClick="btnDelete_Click"  CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "FinishingItemID")%>'>DELETE</asp:LinkButton></td>

                              </tr>
                          </ItemTemplate>
                      </asp:Repeater>
                  </tbody>
              </table>
            </div>
        </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
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