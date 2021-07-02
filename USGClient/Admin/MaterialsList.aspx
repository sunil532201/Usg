<%@ Page Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="MaterialsList.aspx.cs" Inherits="USGClient.Admin.MaterialsList" %>
<%@ Register Src="~/Controls/DatabaseMaintenanceMenu.ascx" TagPrefix="uc1" TagName="DatabaseMaintenanceMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <uc1:DatabaseMaintenanceMenu runat="server" ID="DatabaseMaintenanceMenu" />
         
          <div class="row mb-3">
            <div class="col-4">
                <asp:TextBox ID="txtMaterial" placeholder="New Material Name" CssClass="form-control" runat="server"></asp:TextBox>   
            </div>
            <div class="col-8">
                <asp:Button ID="btnAddMaterial" class="btn btn-dark" runat="server" Text="Add" OnClick="btnAddMaterial_Click"/> 
            </div>
        </div>
     <div class="card-header">
             <i class="fa fa-table "></i><span class="card-title"> Materials </span>
        </div>

        <div class="card-body bg-white">
          <div class="table-responsive">
              <table class="table table-bordered table-striped" id="dataTable" width="100%" >
                  <thead>
                      <tr>
                          <th>Material ItemID </th>
                          <th>Material Item </th>
                          <th>Update</th>
                          <th>Delete</th>
                      </tr>
                  </thead>

                  <tbody>
                      <asp:Repeater runat="server" ID="rptMaterialbyID" >
                          <ItemTemplate>
                              <tr>
                                  <td><%# Eval("MaterialItemID") %></td>
                                  <td><asp:TextBox CssClass="form-control" onkeypress="return MoveNext('btnUpdatetxtMaterialName',event.keyCode);" ClientIDMode="Static" runat="server"  ID="txtMaterialName" Text='<%# Eval("MaterialItem") %>'></asp:TextBox>
                                   <td><asp:LinkButton runat="server" ID="btnUpdateMaterialname" OnClick="btnUpdatetxtMaterialName" CommandName="UpdateMaterialName" ClientIDMode="Static" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "MaterialItemID") %>'>UPDATE</asp:LinkButton></td>

<%--                                  <td><a href='MaterialDetails.aspx?MID=<%# Eval("MaterialItemID") %>'>Update</a></td>--%>
                                  <%-- <td><a href="#" runat="server" onclick="return confirm('Are you sure you want to delete this material?');"  style="float:right" onserverclick="CheckedDelete_Click">DELETE</a></td>--%>
                                  <td><asp:LinkButton runat="server" ID="btnDelete"  OnClick="btnDelete_Click"  CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "MaterialItemID")%>'>DELETE</asp:LinkButton></td>

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