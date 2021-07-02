<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="Store.aspx.cs" Inherits="USGClient.Admin.Store" %>
<%@ Register Src="~/Controls/AdminDetails.ascx" TagPrefix="uc1" TagName="AdminDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
        <uc1:AdminDetails runat="server" ID="AdminDetails" />

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
         <div class="card mb-3">
        <div class="card-header">
            <img id="logo" runat="server" class="LogoSize"/><span class="card-title"> Stores</span>
             <div  style="float: right;" class="card-title">
            <div style="float:left; padding-right: 15px;">
                <asp:Button runat="server" ID="btnSelectAll" CssClass="btn btn-dark " ClientIDMode="Static" Text="Select All"  OnClick="loadSelectedAll" />

                <asp:Button runat="server" ID="btnPrint" CssClass="btn btn-dark " ClientIDMode="Static" Text="Print" OnClick="loadSelectedStore" />
                <a class="btn btn-dark" href="StoreDetails.aspx?CID=<%=Request.QueryString["CID"]%>&SID=<%=Request.QueryString["SID"]%>" id="A1">Create Store</a></div>
           
                  </div>
        </div>
        <div class="card-body bg-white" >
          <div class="table-responsive">
<div class="tab-content pt-5" id="myTabContentEx">
 <asp:Label runat="server" style="text-align:center;" ID="lblPreset"></asp:Label>

 <div class="tab-pane fade active show" id="active-ex" role="tabpanel" aria-labelledby="active-tab-ex">

             <div  align="right"  style="margin-top:-60px;padding:15px;" class="form-group">
                           <asp:LinkButton ID="lnkSavePreset" style="margin-left:10px;float: right" CssClass="btn btn-dark" runat="server" Text="Update Preset"  OnClick="btnSavePreset_Click"/>
                           <asp:DropDownList ID="ddlPreset" runat="server" style="width:300px;float: right" CssClass="form-control" AutoPostBack="True"
                            AppendDataBoundItems="true"  onselectedindexchanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
            </div>
     </br>
     </br>
              <table class="table table-bordered table-striped" style="margin-top:25px;" id="dataTable" width="100%" >
                  <thead>
                      <tr>
                          <th>Print</th>
                          <th>Preset</th>
                          <th>Store Number</th>
                          <th>Shipping City</th>
                          <th>Shipping State</th>
                          <th>Phone</th>
                          <th>Store Manager Name</th>
                          <th>Email</th>
                          <th>Details</th>

                      </tr>
                  </thead>

                  <tbody>
                      <asp:Repeater runat="server" ID="rptActiveStore" >
                          <ItemTemplate>
                              <tr>
                                  <td> <asp:HiddenField ID="hfvalue" runat="server" Value='<%# Eval("StoreID") %>'/><asp:CheckBox ID="chkIsChecked" runat="Server"  Text="" ></asp:CheckBox></td>
                                  <td> <asp:HiddenField ID="hfStoreID" runat="server" Value='<%# Eval("StoreID") %>'/><asp:CheckBox ID="chkIsStoreChecked" runat="Server"  Text="" checked='<%# Eval("IsChecked") %>'></asp:CheckBox></td>

                                  <td><%# Eval("StoreNumber") %></td>
                                  <td><%# Eval("ShippingCity") %></td>
                                  <td><%# Eval("ShippingState") %> </td>
                                  <td><%# Eval("Phone") %></td>
                                  <td><%# Eval("StoreManagerName") %></td>
                                  <td><%# Eval("Email") %></td>
                                  <td><a href='StoreDetails.aspx?CID=<%=Request.QueryString["CID"]%>&SID=<%# Eval("StoreID") %>'>DETAILS</a></td>

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
                          <th>Store Number</th>
                          <th>Shipping City</th>
                          <th>Shipping State</th>
                          <th>Phone</th>
                          <th>Store Manager Name</th>
                          <th>Email</th>
                          <th>Details</th>
                      </tr>
                  </thead>

                  <tbody>
                      <asp:Repeater runat="server" ID="rptInactiveStore" >
                          <ItemTemplate>
                              <tr>
                                  <td><%# Eval("StoreNumber") %></td>
                                  <td><%# Eval("ShippingCity") %></td>
                                  <td><%# Eval("ShippingState") %> </td>
                                  <td><%# Eval("Phone") %></td>
                                  <td><%# Eval("StoreManagerName") %></td>
                                  <td><%# Eval("Email") %></td>
                                  <td><a href='StoreDetails.aspx?CID=<%=Request.QueryString["CID"]%>&SID=<%# Eval("StoreID") %>'>DETAILS</a></td>
                              </tr>
                          </ItemTemplate>
                      </asp:Repeater>
                  </tbody>
              </table>
     </div>
    </div>

            </div>
        </div>
             <asp:HiddenField id="hfPrint" runat="server"/>
    </div>
     <div class="card mb-3" runat="server" id="CheckedStore">
          <div class="card-body bg-white html-content" id="PrintArea">
              <asp:PlaceHolder ID = "PlaceHolder1" runat="server" />
   
      </div>
       </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
       <script src="../js/printThis.js"></script>
 
    <script>

         // Call the dataTables jQuery plugin
         $(document).ready(function () {
             // $.fn.dataTable.moment('M/D/YYYY');
             $('#dataTable').DataTable({
                 "order": [[0, "asc"]],
                 'iDisplayLength': 500
             });
             $('#dataTable1').DataTable({
                 "order": [[0, "asc"]],
                 'iDisplayLength': 500

             });
             var value = $('#<%=hfPrint.ClientID%>').val();
            if (value == 'true') {
                function printDiv() { $("#PrintArea").printThis(); return false; }
                printDiv();
            }
           $('#<%=hfPrint.ClientID%>').val("");
           $('#<%=CheckedStore.ClientID%>').hide();
        });
        
    </script>
</asp:Content>