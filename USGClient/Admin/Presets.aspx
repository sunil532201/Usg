<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="Presets.aspx.cs" Inherits="USGClient.Admin.Presets" %>

<%@ Register Src="~/Controls/AdminDetails.ascx" TagPrefix="uc1" TagName="AdminDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <uc1:AdminDetails runat="server" ID="AdminDetails" />


         <div class="row mb-3">
            <div class="col-4">
                <asp:TextBox ID="txtPresetName" placeholder="New Present Name" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-8">
                <asp:Button ID="btnAddPreset" class="btn btn-dark" runat="server" Text="Add" OnClick="btnAddPreset_Click"/>
           </div>
        </div>

   
        <div class="card-header">
            <img id="logo" runat="server" class="LogoSize"/><span class="card-title"> Presets</span>
             
        </div>
        <div class="card-body bg-white">
          <div class="table-responsive">
              <table class="table table-bordered table-striped" id="dataTable" width="100%" >
                  <thead>
                      <tr>
                          <th>Preset Name</th>
                          <th>Update</th>
                          <th>Number of Stores</th>
<%--                          <th>Update</th>--%>
                          <th>Delete</th>

                          <th>Details</th>
                      </tr>
                  </thead>

                  <tbody>
                      <asp:Repeater runat="server" ID="rptPresets" >
                          <ItemTemplate>
                              <tr>
                                  <td><asp:TextBox CssClass="form-control" onkeypress="return MoveNext('btnUpdatetxtPresetName',event.keyCode);" ClientIDMode="Static" runat="server"  ID="txtPresetName" Text='<%# Eval("PresetName") %>'></asp:TextBox></td>
                                  <td><asp:LinkButton runat="server" ID="btnUpdatePresetname" OnClick="btnUpdatePresetname_Click" CommandName="UpdatePresetName" ClientIDMode="Static" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "PresetID") %>'>Update</asp:LinkButton></td>
                                  <td><%# Eval("count") %></td>
<%--                                   <td><asp:LinkButton runat="server" ID="btnUpdate" OnClick="btnUpdate_Click"   CommandName="Update" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "PresetID ") %>'>Update</asp:LinkButton></td>--%>
                                   <td><asp:LinkButton runat="server" ID="btnDelete"  OnClick="btnDelete_Click"  CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "PresetID")%>'>Delete</asp:LinkButton></td>

                                  <td><a href='PresetDetails.aspx?CID=<%=Request.QueryString["CID"]%>&PID=<%# Eval("PresetID") %>'>Add Stores</a></td>
                              </tr>
                          </ItemTemplate>
                      </asp:Repeater>
                  </tbody>
              </table>
            </div>
        </div>
   
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
