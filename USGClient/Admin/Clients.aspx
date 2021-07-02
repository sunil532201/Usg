 <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminPage1.master" AutoEventWireup="true" CodeBehind="Clients.aspx.cs" Inherits="USGClient.Admin.Clients" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
   <ul class="nav nav-tabs md-tabs" id="myTabEx" role="tablist">
  <li class="nav-item">
    <a class="nav-link active show" id="active-tab-ex" data-toggle="tab" href="#active-ex" role="tab" aria-controls="active-ex"
      aria-selected="true">Active</a>
  </li>
  <li class="nav-item">
    <a class="nav-link" id="inActive-tab-ex" data-toggle="tab" href="#inActive-ex" role="tab" aria-controls="inActive-ex"
      aria-selected="false">Inactive</a>
  </li>
  <li class="nav-item">
    <a class="nav-link" id="charged-tab-ex" data-toggle="tab" href="#charged-ex" role="tab" aria-controls="charged-ex"
      aria-selected="false">Charged Guest</a>
  </li>
  <li class="nav-item">
    <a class="nav-link" id="noCharged-tab-ex" data-toggle="tab" href="#noCharged-ex" role="tab" aria-controls="noCharged-ex"
      aria-selected="false">No Charge Guest</a>
  </li>

</ul>   
         <div id="myModalImage" class="modalImage">
                <span class="closeImage">&times;</span>
                <img class="modalImage-content" id="img01" />
                <div id="caption"></div>
            </div>
    
    <div class="card mb-3">
            <div class="card-header">
              <i class="fa fa-table " ></i><span class="card-title"> Clients</span>
                 <div class="float-right"><a class="btn btn-dark" href="ClientDetails.aspx" id="toggleNavColor">Add Client</a></div>
            </div>
            <div class="card-body bg-white" >

              <div class="table-responsive">

<div class="tab-content pt-5" id="myTabContentEx">
 <div class="tab-pane fade active show" id="active-ex" role="tabpanel" aria-labelledby="active-tab-ex">
 <table class="table table-bordered table-striped" id="dataTable" width="100%" >
                  <thead>
                      <tr>
                          <th>Client ID</th>
                          <th>Date</th>
                          <th>Client Name</th>
                          <th>Logos</th>

                          <th>View</th>
                      </tr>
                  </thead>
                  <tbody>

                      <asp:Repeater runat="server" ID="rptActiveList">
                          <ItemTemplate>
                              <tr>
                                  <td><%# Eval("CustomerID") %></td>
                                 <td><%# Convert.ToDateTime(Eval("CreateDate")).ToString("MM/dd/yyyy") %></td>
                                  <td><%# Eval("CustomerName") %></td>
                                  <td><%# GetImage(Eval("ClientLogo") )%></td>

                                  <td><a href='ClientDetails.aspx?CID=<%# Eval("CustomerID") %>' style="color:#172C55" >DETAILS</a></td>
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
                          <th>Client ID</th>
                          <th>Date</th>
                          <th>Client Name</th>
                          <th>Logos</th>
                          <th>View</th>
                      </tr>
                  </thead>
                  <tbody>
                      <asp:Repeater runat="server" ID="rptInactiveList">
                          <ItemTemplate>
                              <tr>
                                  <td><%# Eval("CustomerID") %></td>
                                  <td><%# Convert.ToDateTime(Eval("CreateDate")).ToString("MM/dd/yyyy") %></td>
                                  <td><%# Eval("CustomerName") %></td>
                                  <td><%# GetImage(Eval("ClientLogo") )%></td>
                                  <td><a href='ClientDetails.aspx?CID=<%# Eval("CustomerID") %>' style="color:#172C55" >DETAILS</a></td>
                              </tr>
                          </ItemTemplate>
                      </asp:Repeater>
                  </tbody>
              </table>

  </div>
  <div class="tab-pane fade" id="charged-ex" role="tabpanel" aria-labelledby="charged-tab-ex">
        <table class="table table-bordered table-striped" id="dataTable2" width="100%" >
                  <thead>
                      <tr>
                          <th>Client ID</th>
                          <th>Date</th>
                          <th>Client Name</th>
                          <th>Logos</th>
                          <th>View</th>
                      </tr>
                  </thead>
                  <tbody>
                      <asp:Repeater runat="server" ID="rptChargeList">
                          <ItemTemplate>
                              <tr>
                                  <td><%# Eval("CustomerID") %></td>
                                  <td><%# Convert.ToDateTime(Eval("CreateDate")).ToString("MM/dd/yyyy") %></td>
                                  <td><%# Eval("CustomerName") %></td>
                                  <td><%# GetImage(Eval("ClientLogo") )%></td>
                                  <td><a href='ClientDetails.aspx?CID=<%# Eval("CustomerID") %>' style="color:#172C55" >DETAILS</a></td>
                              </tr>
                          </ItemTemplate>
                      </asp:Repeater>
                  </tbody>
              </table>

  </div>
  <div class="tab-pane fade" id="noCharged-ex" role="tabpanel" aria-labelledby="noCharged-tab-ex">
    <table class="table table-bordered table-striped" id="dataTable3" width="100%" >
                  <thead>
                      <tr>
                          <th>Client ID</th>
                          <th>Date</th>
                          <th>Client Name</th>
                           <th>Logo</th>
                          <th>View</th>
                      </tr>
                  </thead>
                  <tbody>
                      <asp:Repeater runat="server" ID="rptNoChargeList">
                          <ItemTemplate>
                              <tr>
                                  <td><%# Eval("CustomerID") %></td>
                                  <td><%# Convert.ToDateTime(Eval("CreateDate")).ToString("MM/dd/yyyy") %></td>
                                  <td><%# Eval("CustomerName") %></td>
                                   <td><%# GetImage(Eval("ClientLogo") )%></td>
                                  <td><a href='ClientDetails.aspx?CID=<%# Eval("CustomerID") %>' style="color:#172C55" >DETAILS</a></td>
                              </tr>
                          </ItemTemplate>
                      </asp:Repeater>
                  </tbody>
              </table>

  </div>

</div>
  </div>
     </div>
     </div>
      
</asp:Content>

<asp:Content runat="server" ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3">
            <link href="../Vendor/bootstrap/css/ModelDialog.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>

    <script>
        // Call the dataTables jQuery plugin
        $(document).ready(function () {
            $.fn.dataTable.moment('M/D/YYYY');
            $('#dataTable').DataTable({
                "order": [[2, "asc"]]
            });
        });
        $(document).ready(function () {
            $.fn.dataTable.moment('M/D/YYYY');
            $('#dataTable1').DataTable({
                "order": [[2, "asc"]]
            });
        });
        $(document).ready(function () {
            $.fn.dataTable.moment('M/D/YYYY');
            $('#dataTable2').DataTable({
                "order": [[2, "asc"]]
            });
        });
        $(document).ready(function () {
            $.fn.dataTable.moment('M/D/YYYY');
            $('#dataTable3').DataTable({
                "order": [[2, "asc"]]
            });
        });

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

    </script>
</asp:Content>