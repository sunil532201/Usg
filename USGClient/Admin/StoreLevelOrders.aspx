<%@ Page Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="StoreLevelOrders.aspx.cs" Inherits="USGClient.Admin.StoreLevelOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%-- <style>
        .table td, .table th {
            vertical-align: middle;
        }
        .btnPrimary{
         color: #e3c17e;
         background-color: #172C55;
        }
    </style>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<li class="breadcrumb-item">
         
        <a href="StoreLevelOrders.aspx">Store Level Orders</a>
    </li>
    <li class="breadcrumb-item active" >Store Level Orders List</li>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="card mb-3">
        <div class="card-header">
            <i class="fa fa-table"></i>&nbsp;<span class="card-title">Store Level Orders</span>&nbsp;&nbsp;
                     <asp:Button Text="Current Orders" BorderStyle="None" ID="Tab1" CssClass="btn btn-dark" runat="server"  OnClick="CurrentOrder_Click"   />&nbsp;&nbsp;&nbsp;
                     <asp:Button Text="Completed Orders" BorderStyle="None" ID="Tab2" CssClass="btn btn-dark" runat="server"  OnClick="CompletedOrder_Click"/>
        </div>
        <div class="card-body bg-white" >
            <div class="table-responsive">
                <table class="table table-bordered  table-striped" id="dataTable" width="100%" >
                    <thead>
                        <tr>
                            <th>Client Name</th>
                            <th>Customer Name</th>
<%--                            <th>Email Address</th>--%>
                            <th>PO Number</th>
                            <th>Job Number</th>
                            <th>Previous Job</th>
                            <th>Store Count</th>
                            <th>Date</th>
                            <th>Details</th>
                        </tr>
                    </thead>

                    <tbody>
                        <asp:Repeater runat="server" ID="rptList">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("CustomerName") %></td>
                                    <td><%# Eval("ApproverFirstName") %> <%# Eval("ApproverLastName") %></td>
<%--                                    <td><%# Eval("EmailAddress") %></td>--%>
                                    <td><%# Eval("PONumber") %></td>
                                    <td><%# Eval("Prefix")+"-"+Eval("JobID") %></td>
                                    <td><%# Eval("PreviousJobNumber") %></td>
                                    <td><%# Eval("ShipToStoreNumber") %></td>
                                    <td><%# Convert.ToDateTime(Eval("CreateDate")).ToString("MM/dd/yyyy") %></td>
                                    <td><a href='StoreLevelOrderDetails.aspx?OID=<%# Eval("OrderID") %>' style="color:#172C55">DETAILS</a></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content runat="server" ID="Content5" ContentPlaceHolderID="ContentPlaceHolder3">
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
