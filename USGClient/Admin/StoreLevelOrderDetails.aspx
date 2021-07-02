<%@ Page Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="StoreLevelOrderDetails.aspx.cs" Inherits="USGClient.Admin.StoreLeveOrderDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .table td, .table th {
            vertical-align: middle;
        }

/* 100% Image Width on Smaller Screens */
@media only screen and (max-width: 700px){
  .modal-content {
    width: 100%;
  }
} 
    </style>
    <link href="../Vendor/bootstrap/css/ModelDialog.css" rel="stylesheet" />
    
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script>

        $(document).ready(function () {
            $(".imageClass").on("click",function(e){
              e.preventDefault();
                var modal = document.getElementById("myModalImage");

                // Get the image and insert it inside the modal - use its "alt" text as a caption
                var img = document.getElementById(e.target.id);
                var modalImg = document.getElementById("img01");
                var captionText = document.getElementById("caption");
               // img.onclick = function () {
                    modal.style.display = "block";
                    modalImg.src = this.src;
                    captionText.innerHTML = this.alt;
               // }  

                // Get the <span> element that closes the modal
                var span = document.getElementsByClassName("closeImage")[0];
                span.onclick = function () {
                    modal.style.display = "none";
                }
            });
             });
    </script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="PrintPage">
    <!------Model PopUp--------->
<div id="myModalImage" class="modalImage">
    <span class="closeImage">&times;</span>
    <img class="modalImage-content" id="img01"/>
    <div id="caption"></div>
</div>
     <div class="card mb-3">
        <div class="card-header">
            <img id="logo" runat="server" class="LogoSize"/><span class="card-title" > Store Level Order Details</span>&nbsp;&nbsp;&nbsp;
             <div class="float-right"><i class="fa fa-user-circle"></i>&nbsp;<%=Session["CustomerName"]%> </div>
        </div>

         <asp:Label runat="server" ID="lblMessage"></asp:Label>
            
         <div class="card-body bg-white" >
            <div class="table-responsive" >
                <style> 
                 @media print{ 
                 .table td, .table th
                {
                     vertical-align: middle;
                 }
                }  
                </style>
                <table class="table table-bordered table-striped" cellspacing="0" >
                    <tbody>
                        <tr>
                            <td style="font-weight: bold;">Order ID: </td>
                            <td>
                                <asp:Label runat="server" ID="lblOrderID" ></asp:Label></td>
                             <td style="font-weight: bold;">Ordered Date: </td>
                            <td>
                                <asp:Label runat="server" ID="lblOrderedDate"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold;">Client Name: </td>
                            <td>
                                <asp:Label runat="server" ID="lblClientName"></asp:Label></td>
                             <td style="font-weight: bold;">PO Number: </td>
                            <td>
                                <asp:Label ID="lblPONumber" runat="server" ></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold;">Name: </td>
                            <td>
                                <asp:Label ID="lblName" runat="server" ></asp:Label></td>
                            
                            <td style="font-weight: bold;">Previous Job Number: </td>
                            <td>
                                <asp:Label ID="lblPreviousJobNumber" runat="server" ></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold;">Phone Number: </td>
                            <td>
                                <asp:Label ID="lblPhoneNumber" runat="server" ></asp:Label></td>
                            
                            <td style="font-weight: bold;">New Job Number: </td>
                            <td>
                                <asp:Label ID="lblNewJobNumber" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold;">Email Address: </td>
                            <td>
                                <asp:Label ID="lblEmail" runat="server" ></asp:Label></td>
                            <td style="font-weight: bold;">Store Count: </td>
                            <td>
                                <asp:Label runat="server" ID="lblStoreNumber"></asp:Label></td>
                        </tr>
                    </tbody>
                </table> 
                <style> 
                 @media print{ 
                .noprint,
                .Details,
                .dataTables_length,
                .dataTables_filter,
                .dataTables_info,
                #dataTable_paginate,
                .thead Details{
                display:none;
                }          
               }
                </style>
                <div class="noprint">
                <asp:LinkButton ID="lnkUpdateOrderInfo" runat="server" CssClass="btn btn-dark" Text="Move To Order Entry" OnClick="lnkUpdateOrderInfo_Click"></asp:LinkButton>
<%--                    <a id="PrintPage" href="#" Class="btn btn-dark">Print</a>
                <asp:LinkButton ID="btnSaveToExcel" runat="server" CssClass="btn btn-dark" Text="Export" onclick="btnSaveToExcel_Click"></asp:LinkButton>
                    <asp:LinkButton ID="btnOrderForm" runat="server" CssClass="btn btn-dark" Text="Order Form" onclick="btnOrderForm_Click"></asp:LinkButton>
                    <asp:LinkButton ID="lnkCompleted" runat="server" CssClass="btn btn-dark" Text="Mark as Completed" OnClick="lnkCompletedInfo_Click"></asp:LinkButton>--%>
                </div>
            </div>
        </div>
     </div>

        <div class="card mb-3" runat="server" id="divOrders">
            <div class="card-header">
                <i class="fa fa-table"></i> <span class="card-title" >Store Level Ordered Items</span>
                <div class="noprint">
    <%--      <div style="float: right;"><a class="btn btn-dark" href="StoreLevelOrderItems.aspx?OID=<%=Request.QueryString["OID"] %>&OIID=<%=Request.QueryString["OIID"] %>" id="toggleNavColor">Add Order Item</a></div>--%>
            </div>
        </div>
        
    <div class="card-body" style="background-color: white !important">
    <div class="table-responsive">
                    <table class="table table-bordered table-striped" id="dataTable" width="100%" cellspacing="0" class="table-striped">
                        <thead>
                            <tr>
                                <th>SignType</th>
                               <%-- <th>Size</th>--%>
                                <th>Quantity</th>
                                <th>Promotion</th>
                                <th>Reason</th>
                                <th>Store Number</th>
                                <th>Image</th>
                                <th>Details</th>

                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater runat="server" ID="rptAdministrator" >
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("SignType") %></td>
                                       <%-- <td><%# Eval("SignTypeSize") %></td>--%>
                                        <td><%# Eval("Quantity") %></td>
                                        <td><%# Eval("Promotion") %></td>
                                        <td><%# Eval("OrderReason") %></td>
                                        <td><%# Eval("ShipToStoreNumber") %></td>
                                        <td><%# GetImage(Eval("OrderedItemID"))%></td>
                                        <td><a href='StoreLevelOrderItems.aspx?OIID=<%# Eval("OrderedItemID") %>&OID=<%# Eval("OrderID") %>' style="color:#172C55">DETAILS</a></td>
                                    
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>

                </div>
    </div>

    </div>
    </div>
</asp:Content>
<asp:Content runat="server" ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3">
    
    <script src="../js/printThis.js"></script>
    <script>
        // Call the dataTables jQuery plugin
        $(document).ready(function () {
            $.fn.dataTable.moment('M/D/YYYY');
            var count = $('#dataTable tr').not('thead tr').length;
            $('#dataTable').DataTable({
                "order": [[2, "asc"]],
                "columnDefs": [
                    { className: "Details", targets: 7 }
                ],
                "pageLength": count
            });

            $('#PrintPage').click(function () {
                $(".PrintPage").printThis();
            });
        });
    </script>
</asp:Content>
