<%@ Page Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="PurchaseOrders.aspx.cs" Inherits="USGClient.Admin.PurchaseOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
         <div class="card mb-3">
        <div class="card-header">
            <i class="fa fa-table "></i><span class="card-title"> Purchase Order</span>
            <div class="float-right"><a class="btn btn-dark" href="PurchaseOrderDetails.aspx" id="liLaminant">Create Purchase Order</a></div>
        </div>
        <div class="card-body bg-white">
          <div class="table-responsive">

              <table class="table table-bordered table-striped" id="dataTable" width="100%" >
                  <thead>
                      <tr>
                          <th>Status </th>
                          <th>PO Number </th>
                          <th>Vendor  </th>
                          <th>Submitted By  </th>
                          <th>Date   </th>
                          <th>Amount </th>
                          <th>Details</th>

                      </tr>
                  </thead>

                  <tbody>
                      <asp:Repeater runat="server" ID="rptPurchaseOrder" >
                          <ItemTemplate>
                              <tr>
                                  <td><%# Eval("PurchaseOrderStatus") %></td>
                                  <td><%# Eval("PurchaseOrderID ") %></td>
                                  <td><%# Eval("VendorName") %></td>
                                  <td><%# Eval("AdminName") %></td>
                                  <td><%# Eval("CreateDate") %></td>
                                  <td><%# Eval("Amount") %></td>
                                  <td><a href='PurchaseOrderDetails.aspx?POID=<%# Eval("PurchaseOrderID") %>'>DETAILS</a></td>
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
        // Call the dataTables jQuery plugin
        $(document).ready(function () {
            $.fn.dataTable.moment('M/D/YYYY');
            $('#dataTable').DataTable({
                "order": [[1, "asc"]]
            });
           
        });
    </script>  
</asp:Content>