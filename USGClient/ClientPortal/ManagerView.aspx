<%@ Page Language="C#" MasterPageFile="~/MasterPages/ClientPage.Master" AutoEventWireup="true" CodeBehind="ManagerView.aspx.cs" Inherits="USGClient.ClientPortal.ManagerView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Vendor/bootstrap/css/ModelDialog.css" rel="stylesheet" />


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageTitle" runat="server">
    <h5>Manage Orders</h5>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadCrumbs" runat="server">
   
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cphMainContent" runat="server">

    <ul class="nav nav-pills mb-20">
        <li runat="server" id="lblCurrent" class="nav-item">
            <asp:LinkButton runat="server" ID="lnkCurrent" OnClick="lnkCurrent_Click" Text="Current"></asp:LinkButton></li>
        <li runat="server" class="nav-item" id="lblArchive">
            <asp:LinkButton runat="server" ID="lnkArchive" OnClick="lnkArchive_Click" Text="Archive"></asp:LinkButton></li>
    </ul>
    <div id="myModalImage" class="modalImage">
        <span class="closeImage">&times;</span>
        <img class="modalImage-content" id="img01" />
        <div id="caption"></div>
    </div>

    <asp:MultiView ID="MainView" runat="server">
        <asp:View ID="CurrentView" runat="server">
            <div class="card mb-3">
                <div class="card-header">
                    <i class="fa fa-table "></i><span class="card-title">Current Orders</span>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <table class="table table-bordered table-striped" id="dtCurrent" width="100%">
                            <thead>
                                <tr>
                                    <th>Details</th>
<%--                                    <th>Name</th>
                                    <th>Phone Number</th>--%>
                                    <th>PO Number</th>
                                    <th>Job Number</th>
                                    <th>Store Number</th>
                                    <th>Create Date</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="rptCurrent" OnItemCommand="rtpArchive_ItemCommand">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:LinkButton runat="server" ID="lnkDetails" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "OrderID") %>'><%# Eval("OrderID")%></asp:LinkButton></td>
<%--                                            <td><%# Eval("Name") %></td>
                                            <td><%# Eval("PhoneNumber") %></td>--%>
                                            <td><%# Eval("PONumber") %></td>
                                            <td><%# Eval("PreviousJobNumber") %></td>
                                            <td><%# Eval("ShipToStoreNumber") %></td>
                                            <td><%# Eval("CreateDate")%></td>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </asp:View>
        <asp:View ID="ArchiveView" runat="server">
            <div class="card mb-3">
                <div class="card-header">
                    <i class="fa fa-table "></i><span class="card-title">Archived Orders</span>
                </div>
                <br />
                <div class="card-body bg-white">
                    <div class="table-responsive">
                        <table class="table table-bordered table-striped" id="dtArchive" width="100%">
                            <thead>
                                <tr>
                                    <th>Details</th>
<%--                                    <th>Name</th>
                                    <th>Phone Number</th>--%>
                                    <th>PO Number</th>
                                    <th>Job Number</th>
                                    <th>Store Number</th>
                                    <th>Create Date</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="rtpArchive" OnItemCommand="rtpArchive_ItemCommand">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:LinkButton runat="server" ID="lnkDelete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "OrderID") %>'><%# Eval("OrderID")%></asp:LinkButton></td>
<%--                                            <td><%# Eval("Name") %></td>
                                            <td><%# Eval("PhoneNumber") %></td>--%>
                                            <td><%# Eval("PONumber") %></td>
                                            <td><%# Eval("PreviousJobNumber") %></td>
                                            <td><%# Eval("ShipToStoreNumber") %></td>
                                            <td><%# Eval("CreateDate")%></td>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
                <br />
            </div>
        </asp:View>
        <asp:View ID="Details" runat="server">
            <div class="card mb-3">
                <div class="card-header">
                    <i class="fa fa-table "></i><span class="card-title">Manage Orders</span>
                </div>
                <div class="card-body bg-white">
                    <div class="table-responsive">
                        <table class="table table-bordered table-striped" id="dataTable" width="100%">
                            <thead>
                                <tr>
                                    <th>SignType</th>
                                    <th>SignTypeSize</th>
                                    <th>Quantity</th>
                                    <th>Promotion</th>
                                    <th>OrderReason</th>
                                    <th>ShipToStoreNumber</th>
                                    <th>Image</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="rptAdministrator">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Eval("SignType") %></td>
                                            <td><%# Eval("SignTypeSize") %></td>
                                            <td><%# Eval("Quantity") %></td>
                                            <td><%# Eval("Promotion") %></td>
                                            <td><%# Eval("OrderReason") %></td>
                                            <td><%# Eval("ShipToStoreNumber") %></td>
                                            <td><%# GetImage(Eval("OrderedItemID"))%></td>

                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                    <div class="mt-20">
                        <asp:Button ID="Button6" runat="server" CssClass="btn btn-dark" Text="Back" OnClick="Button6_Click" />
                    </div>
                </div>
            </div>

        </asp:View>
    </asp:MultiView>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script>
        $(document).ready(function () {
            $(".imageClass").on("click",function(e){
              e.preventDefault();
            debugger;
                var modal = document.getElementById("myModalImage");
                // Get the image and insert it inside the modal - use its "alt" text as a caption
                var img = document.getElementById(e.target.id);
                var modalImg = document.getElementById("img01");
                var captionText = document.getElementById("caption");
                //img.onclick = function () {
                    modal.style.display = "block";
                    modalImg.src = this.src;
                    captionText.innerHTML = this.alt;
                //}
                // Get the <span> element that closes the modal
                var span = document.getElementsByClassName("closeImage")[0];

                // When the user clicks on <span> (x), close the modal
                span.onclick = function () {
                    modal.style.display = "none";
                }
            //}
            });
             });
    </script>
    <script>
        $(document).ready( function () {
    $('#dtCurrent').DataTable();
        });

         $(document).ready( function () {
    $('#dtArchive').DataTable();
} );
    </script>
</asp:Content>
