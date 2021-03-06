<%@ Page Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="InventoryOrder.aspx.cs" Inherits="USGClient.Admin.InventoryOrder" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <div id="myModalImage" class="modalImage">
                <span class="closeImage">&times;</span>
                <img class="modalImage-content" id="img01" />
                <div id="caption"></div>
            </div>   
       <ul class="nav nav-tabs md-tabs" id="myTabEx" role="tablist">
  <li class="nav-item">
    <a class="nav-link active show" id="active-tab-ex" data-toggle="tab" href="#active-ex" role="tab" aria-controls="active-ex"
      aria-selected="true">Current Orders</a>
  </li>
  <li class="nav-item">
    <a class="nav-link" id="inActive-tab-ex" data-toggle="tab" href="#inActive-ex" role="tab" aria-controls="inActive-ex"
      aria-selected="false">Completed Orders</a>
  </li>
  </ul>    
   
           <div class="card mb-3">
        <div class="card-header">
            <i class="fa fa-table "></i><span class="card-title"> Inventory Orders</span>
        </div>
        <div class="card-body bg-white">
          <div class="table-responsive">
<div class="tab-content pt-5" id="myTabContentEx">
 <div class="tab-pane fade active show" id="active-ex" role="tabpanel" aria-labelledby="active-tab-ex">

 <table class="table table-bordered table-striped" id="dataTable" width="100%" >
                  <thead>
                      <tr>
                          <th>Job Number</th>
                          <th>Customer Name </th>
<%--                          <th>Sign Type </th>
                          <th># of Sides</th>
                          <th>Promotion </th>
                          <th>Image Of Sign </th>
                          <th>Quantity Ordered</th>--%>
                          <th>Date Ordered</th>
                          <th> Date Needed</th>
                          <th>Ordered By </th>
                          <th>Details</th>

                      </tr>
                  </thead>

                  <tbody>
                      <asp:Repeater runat="server" ID="rptCurrentOrder" >
                          <ItemTemplate>
                              <tr>
                                <asp:HiddenField ID="hfvalue" runat="server"  Value='<%# Eval("InventoryOrderID")%>' />
                                  <td><%# Eval("Prefix")+"-"+Eval("JobID") %></td>
                                  <td><%# Eval("CustomerName") %></td>
<%--                                  <td><%# Eval("SignType") %></td>
                                  <td><%# Eval("NumberOfSides") %></td>
                                  <td><%# Eval("Promotion") %></td>
                                  <td><%# GetImage(Eval("ImageUrl")) %></td>
                                  <td><%# Eval("Quantity") %></td>--%>
                                  <td><%# (Eval("CreateDate").ToString().Contains("1900")) ?"":Eval("CreateDate","{0: MM/dd/yyyy}")%></td>
                                  <td><%# (Eval("DisplayDate").ToString().Contains("1900")) ?"":Eval("DisplayDate","{0: MM/dd/yyyy}")%></td>
                                  <td><%# Eval("CustomerUser") %></td>
                                  <td><a href='InventoryOrderDetails.aspx?IOID=<%#Eval("InventoryOrderID")%>'>DETAILS</a></td>

                              </tr>
                          </ItemTemplate>
                      </asp:Repeater>
                  </tbody>
              </table>     </div>
  <div class="tab-pane fade" id="inActive-ex" role="tabpanel" aria-labelledby="inActive-tab-ex">

 <table class="table table-bordered table-striped" id="dataTable1" width="100%" >
                  <thead>
                      <tr>
                          <th>Job Number</th>
                          <th>Customer Name </th>
<%--                          <th>Sign Type </th>
                          <th># of Sides</th>
                          <th>Promotion </th>
                          <th>Image Of Sign </th>
                          <th>Quantity Ordered</th>--%>
                          <th>Date Ordered</th>
                          <th> Date Needed</th>
                          <th>Ordered By </th>
                          <th>Details</th>

                      </tr>
                  </thead>

                  <tbody>
                      <asp:Repeater runat="server" ID="rptCompltedOrder" >
                          <ItemTemplate>
                              <tr>
                                  <asp:HiddenField ID="hfvalue" runat="server"  Value='<%# Eval("InventoryOrderID")%>' />
                                  <td><%# Eval("Prefix")+"-"+Eval("JobID") %></td>
                                  <td><%# Eval("CustomerName") %></td>
<%--                                  <td><%# Eval("SignType") %></td>
                                  <td><%# Eval("NumberOfSides") %></td>
                                  <td><%# Eval("Promotion") %></td>
                                  <td><%# GetImage(Eval("ImageUrl")) %></td>
                                  <td><%# Eval("Quantity") %></td>--%>
                                  <td><%# (Eval("CreateDate").ToString().Contains("1900")) ? "" : Eval("CreateDate","{0: MM/dd/yyyy}")%></td>
                                  <td><%# (Eval("DisplayDate").ToString().Contains("1900")) ?"":Eval("DisplayDate","{0: MM/dd/yyyy}")%></td>

                                  <td><%# Eval("CustomerUser") %></td>
                                 <td><a href='InventoryOrderDetails.aspx?IOID=<%#Eval("InventoryOrderID")%>'>DETAILS</a></td>

<%--                                  <td> <asp:CheckBox  type="checkbox" ID="chkShipped" runat="server" Checked='<%# Eval("Shipped") %>' AutoPostBack="true" OnCheckedChanged="chk_ShippedChanged" /> </td>
                                  <td><%#(Eval("DateShipped").ToString().Contains("1900")) ? "" : Eval("DateShipped","{0: MM/dd/yyyy}")%></td>--%>


                              </tr>
                          </ItemTemplate>
                      </asp:Repeater>
                  </tbody>
              </table>     </div>
    </div>

            </div>
        </div>
    </div>
  
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
       <link href="../Vendor/bootstrap/css/ModelDialog.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
  
    <script>
        // Call the dataTables jQuery plugin
        $(document).ready(function () {
            $.fn.dataTable.moment('M/D/YYYY');
            $('#dataTable').DataTable({
                "order": [[1, "desc"]]
            });
           
        });

         $(document).ready(function () {
             $.fn.dataTable.moment('M/D/YYYY');
             $('#dataTable1').DataTable({
                 "order": [[1, "desc"]]
             });
         });
       

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