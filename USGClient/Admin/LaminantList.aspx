<%@ Page  Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="LaminantList.aspx.cs" Inherits="USGClient.Admin.LaminantList" %>

<%@ Register Src="~/Controls/DatabaseMaintenanceMenu.ascx" TagPrefix="uc1" TagName="DatabaseMaintenanceMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <uc1:DatabaseMaintenanceMenu runat="server" ID="DatabaseMaintenanceMenu" />
      <div class="row mb-3">
            <div class="col-4">
               <asp:TextBox ID="txtLaminant" placeholder="New Laminant Name" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-8">
               <asp:Button ID="btnAddLaminant" class="btn btn-dark" runat="server" Text="Add" OnClick="btnAddLaminant_Click"/>
            </div>
      </div>
     <div class="card-header">
             <i class="fa fa-table "></i><span class="card-title"> Laminants </span>
        </div>
         <%--<div class="card mb-3">
        <div class="card-header">
            <i class="fa fa-table "></i><span class="card-title"> Laminants</span>
            <div class="float-right"><a class="btn btn-dark" href="LaminantDetails.aspx" id="liLaminant">Create Laminant</a></div>
        </div>--%>
        <div class="card-body bg-white">
          <div class="table-responsive">
              <table class="table table-bordered table-striped" id="dataTable" width="100%" >
                  <thead>
                      <tr>
                          <th>Laminant ID</th>
                          <th>Laminant Item </th>
                          <th>Update</th>
                          <th>Delete</th>
                      </tr>
                  </thead>

                  <tbody>
                      <asp:Repeater runat="server" ID="rptLaminantbyID" >
                          <ItemTemplate>
                              <tr>
                                  <td><%# Eval("LaminantID") %></td>
                                  <td><asp:TextBox CssClass="form-control" onkeypress="return MoveNext('btnUpdatetxtLaminantName',event.keyCode);" ClientIDMode="Static" runat="server"  ID="txtLaminantName" Text='<%# Eval("LaminantItem") %>'></asp:TextBox></td>
                                  <td><asp:LinkButton runat="server" ID="btnUpdateLaminantName" OnClick="btnUpdatetxtLaminantName" CommandName="UpdateLaminantName" ClientIDMode="Static" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "LaminantID") %>'>UPDATE</asp:LinkButton></td>
                                  <td><asp:LinkButton runat="server" ID="btnDelete"  OnClick="btnDelete_Click"  CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "LaminantID")%>'>DELETE</asp:LinkButton></td>

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