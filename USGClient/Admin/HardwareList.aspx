<%@ Page Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="HardwareList.aspx.cs" Inherits="USGClient.Admin.HardwareList" %>

<%@ Register Src="~/Controls/DatabaseMaintenanceMenu.ascx" TagPrefix="uc1" TagName="DatabaseMaintenanceMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <uc1:DatabaseMaintenanceMenu runat="server" ID="DatabaseMaintenanceMenu" />
   
        <div class="row mb-3">
            <div class="col-4">
                <asp:TextBox ID="txtHardware" placeholder="New Hardware Name" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-8">
                <asp:Button ID="btnAddHardware" class="btn btn-dark" runat="server" Text="Add" OnClick="btnAddHardware_Click"/>
             </div>
        </div>

     <div class="card-header">
             <i class="fa fa-table "></i><span class="card-title"> Hardware </span>
        </div>
         <%--<div class="card mb-3">
        <div class="card-header">
            <i class="fa fa-table "></i><span class="card-title"> Hardware </span>
            <div class="float-right"><a class="btn btn-dark" href="HardwareDetails.aspx" id="liMaterial">Create Hardware</a></div>
        </div>--%>
        <div class="card-body bg-white">
          <div class="table-responsive">
              <table class="table table-bordered table-striped" id="dataTable" width="100%" >
                  <thead>
                      <tr>
                          <th>Hardware ItemID </th>
                          <th>Hardware Item </th>
                          <th>Update</th>
                          <th>Delete</th>

                      </tr>
                  </thead>

                  <tbody>
                      <asp:Repeater runat="server" ID="rptHardwarebyID" >
                          <ItemTemplate>
                              <tr>
                                  <td><%# Eval("HardwareItemID") %></td>
                                  <td><asp:TextBox CssClass="form-control" onkeypress="return MoveNext('btnUpdatetxtHardwareName',event.keyCode);" ClientIDMode="Static" runat="server"  ID="txtHardwareName" Text='<%# Eval("HardwareItem") %>'></asp:TextBox></td>
                                  <td><asp:LinkButton runat="server" ID="btnUpdateHardwareName" OnClick="btnUpdatetxtHardwareName" CommandName="UpdateHardwareName" ClientIDMode="Static" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "HardwareItemID") %>'>UPDATE</asp:LinkButton></td>
                                  <td><asp:LinkButton runat="server" ID="btnDelete"  OnClick="btnDelete_Click"  CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "HardwareItemID")%>'>DELETE</asp:LinkButton></td>

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