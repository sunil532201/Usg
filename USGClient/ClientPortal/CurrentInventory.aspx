<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/ClientPage.Master" AutoEventWireup="true" CodeBehind="CurrentInventory.aspx.cs" Inherits="USGClient.ClientPortal.CurrentInventory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadCrumbs" runat="server"></asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphMainContent" runat="server">
    <ul class="nav nav-pills mb-20">
        <li runat="server" id="lblActive" class="nav-item">
            <asp:LinkButton runat="server" ID="lnkActive" OnClick="lnkActive_Click" Text="Current Inventory"></asp:LinkButton></li>
        <li runat="server" id="lblInactive" class="nav-item">
            <asp:LinkButton runat="server" ID="lnkInactive" OnClick="lnkInactive_Click" Text="Past Orders"></asp:LinkButton></li>
    </ul>
    <div id="myModalImage" class="modalImage">
        <span class="closeImage">&times;</span>
        <img class="modalImage-content" id="img01" />
        <div id="caption"></div>
    </div>
    <asp:MultiView ID="MainView" runat="server">

        <asp:View ID="CurrentInventoryView" runat="server">
            <div class="card mb-3">
                <div class="card-header">
                    <i class="fa fa-table "></i><span class="card-title">Inventory Items</span>
                    <asp:Label runat="server" ID="lblMessage" ></asp:Label>

                </div>
                <div class="card-body bg-white">
                    <div class="table-responsive">
                        <table class="table table-bordered table-striped" visible="false" id="dataTable" width="100%">
                            <thead>
                                <tr>
                                    <%if (this.IsChecked){ %>
                                    <th>Quantity On Hand</th>
                                    <%} %>
                                    <th>Sign Type </th>
                                    <th># of Sides</th>
                                    <th>Promotion </th>
                                    <th>Image Of Sign </th>
                                    <th>Quantity</th>

                                    <%--<th>Order</th>--%>
                                </tr>
                            </thead>

                            <tbody>

                                <asp:Repeater runat="server" ID="rptCurrentInventory">
                                    <ItemTemplate>

                                        <tr>
                                            <%if (this.IsChecked)
                                            { %>
                                            <td><%# Eval("QuantityOnHand") %></td>
                                            <%} %>
                                            <td><%# Eval("SignType") %>

                                                <asp:HiddenField runat="server" ID="txtInventoryItemID" Value='<%# Eval("InventoryItemID")%>'></asp:HiddenField>
                                            </td>
                                            <td><%# Eval("NumberOfSides") %></td>
                                            <td><%# Eval("Promotion") %></td>
                                            <td><%# GetImage(Eval("ImageUrl")) %></td>
                                            <td>
                                                <asp:TextBox ID="txtQuantity" CssClass="form-control w-25" Text='<%# Eval("Quantity")%>' runat="server"> </asp:TextBox>
                                                <asp:RangeValidator ID="RangeValidator1" runat="server"
                                                    ControlToValidate="txtQuantity"
                                                    Text='<%# "The Maximum Quantity Allowed for this item is " + Eval("MaxOrderQuantity")%>'
                                                    MaximumValue='<%# (Eval("MaxOrderQuantity"))%>'
                                                    MinimumValue="0"
                                                    ForeColor="Red"
                                                    Type="Integer"> 
                                                </asp:RangeValidator>
                                            </td>
                                            <%-- <td><a href='InventoryOrder.aspx?IID=<%#Eval("InventoryItemID")%>'>Order</a></td>--%>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>

                        </table>
                        <div>
                            <asp:LinkButton ID="lnkSaveOrder" runat="server" CssClass="btn btn-dark" OnClick="lnkSaveOrder_Click" Text="Create Order"></asp:LinkButton>
                        </div>

                    </div>
                </div>
            </div>
        </asp:View>
        <asp:View ID="PastOrderView" runat="server">
            <div class="card mb-3">
                <div class="card-header">
                    <i class="fa fa-table "></i><span class="card-title">Inventory Items</span>
                </div>
                <div class="card-body bg-white">
                    <div class="table-responsive">
                        <table class="table table-bordered table-striped" visible="false" id="Table2" width="100%">
                            <thead>
                                <tr>
                                    <th>Job Number</th>
                                    <th>Customer Name </th>

                                    <%--                              <th>Sign Type </th>
                              <th># of Sides</th>
                              <th>Promotion </th>
                              <th>Image Of Sign </th>
                              <th>Quantity Ordered</th>--%>
                                    <th>Date Ordered</th>
                                    <th>Date Needed</th>
                                    <th>Ordered By</th>
                                    <th>Details</th>


                                </tr>
                            </thead>

                            <tbody>
                                <asp:Repeater runat="server" ID="rptPastInventory">
                                    <ItemTemplate>

                                        <tr>
                                            <td><%#Eval("Prefix").ToString() +"-" + Eval("JobID").ToString()%></td>
                                            <td><%# Eval("CustomerName") %></td>

                                            <%--                                      <td><%# Eval("SignType") %></td>
                                      <td><%# Eval("NumberOfSides") %></td>
                                      <td><%# Eval("Promotion") %></td>
                                      <td><%# GetImage(Eval("ImageUrl")) %></td>
                                      <td><%# Eval("Quantity") %></td>--%>
                                      <td><%# Eval("CreateDate") %></td>
                                            <td><%#(Eval("DisplayDate").ToString().Contains("1900")) ?"":Eval("DisplayDate")%></td>
<%--                                      <td><%# (Eval("DisplayDate").ToString().Contains("1900")) ? "" : Eval("DateShipped")%></td>--%>
                                      <td><%# Eval("CustomerUser") %></td>
                                  <td><a href='InventoryOrder.aspx?IOID=<%#Eval("InventoryOrderID")%>'>DETAILS</a></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>

                    </div>
                </div>
            </div>

        </asp:View>

    </asp:MultiView>
    <link href="../Vendor/bootstrap/css/ModelDialog.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>

    <script>
        $(document).ready(function () {
            $(".img-thumbnail").on("click", function (e) {
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
                //captionText.innerHTML = this.alt;
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
</asp:Content>
