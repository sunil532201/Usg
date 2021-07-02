<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="InventoryOrderDetails.aspx.cs" Inherits="USGClient.Admin.InventoryOrderDetails" %>


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

    
    <div class="card-header">
          <span class="card-title"> Inventory Item Details </span>&nbsp;&nbsp;&nbsp;
           <asp:Label runat="server" ID="Label1" ></asp:Label>
      </div>
    <div class="card-body bg-white" >
             <div class="table-responsive">

                <table class="table table-bordered table-striped">
                    <thead>
                          <tr>
                              <th>Quantity </th>
                              <th>Sign Type</th>
                              <th>Number Of Sides </th>
                              <th>Promotion </th>
                              <th>Image</th>

                          </tr>
                      </thead>

                    <tbody>

                     <asp:Repeater runat="server" ID="rptInventorybyID" >
                          <ItemTemplate>
                            <tr>
                                
                                <td>  <%# Eval("Quantity ") %></td> 
                                <td>   <%# Eval("SignType") %></td> 
                                <td> <%# Eval("NumberOfSides") %></td> 
                                <td>  <%# Eval("Promotion") %></td> 
                                <td> <%# GetImage(Eval("ImageUrl")) %></td> 
                            </tr>
                        </ItemTemplate>
                      </asp:Repeater>
  
                    </tbody>
                </table>

            </div>
             
        </div>

    <div class="card-header">
          <span class="card-title"> Shipping Details </span>&nbsp;&nbsp;&nbsp;
                      <asp:Label runat="server" ID="lblMessage" ></asp:Label>
    </div>

        <div class="card-body bg-white" >
             <div class="table-responsive">
                <table class="table table-bordered table-striped">
                    <tbody>
                        <tr>
                            <td>Bulk  :</td>
                            <td>
                                <asp:RadioButtonList ID="rbBulkOrder" runat="server" TabIndex="9" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Value="True">Yes</asp:ListItem>
                                    <asp:ListItem Value="False">No</asp:ListItem>
                                </asp:RadioButtonList>
                             <asp:TextBox runat="server" type="hidden" id="txtAddresslistURL" > </asp:TextBox>
                            </td>
                            
                        </tr>
                        <tr>
                            <td>Store Level :</td>
                            <td>
                                <asp:RadioButtonList ID="rbStoreLevel" runat="server" TabIndex="7" RepeatDirection="Horizontal"  RepeatLayout="Flow">
                                    <asp:ListItem Value="True" data-toggle="modal" data-target="#UploadFileModal">Yes</asp:ListItem>
                                    <asp:ListItem Value="False" >No</asp:ListItem>
                                </asp:RadioButtonList>
                                <a href='' ID="UploadedFile" visible="false" runat="server">Uploaded File</a>
                            </td>

                        </tr>

                        <asp:TableRow visible="true" ID="tblAttentionLine" runat="server">
                            <asp:TableCell>Attention Line  : </asp:TableCell>
                            <asp:TableCell><asp:TextBox ID="txtAttentionLine" TabIndex="10" runat="server" CssClass="form-control"></asp:TextBox> </asp:TableCell>   
                        </asp:TableRow>
                        <asp:TableRow visible="true" ID="tblAddress1" runat="server">
                            <asp:TableCell>Address 1 : </asp:TableCell>
                            <asp:TableCell><asp:TextBox  ID="txtAddress1" TabIndex="1" CssClass="form-control" runat="server" ></asp:TextBox></asp:TableCell>

                        </asp:TableRow>
                        <asp:TableRow visible="true" ID="tblAddress2" runat="server">
                            <asp:TableCell>Address 2 :</asp:TableCell>
                            <asp:TableCell><asp:TextBox  ID="txtAddress2" TabIndex="2" CssClass="form-control" runat="server" ></asp:TextBox></asp:TableCell>

                        </asp:TableRow>
                        <asp:TableRow visible="true" ID="tblCity" runat="server" >
                            <asp:TableCell>City  :</asp:TableCell>
                            <asp:TableCell><asp:TextBox ID="txtCity" TabIndex="3" runat="server" CssClass="form-control"></asp:TextBox></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow visible="true" class="form-group" ID="tblState" runat="server">
<%--                            <div class="form-group">--%>
                                <asp:TableCell>State  :</asp:TableCell>	
                                    <asp:TableCell>
                                        <div>
		                                <select class="form-control"  id="stateName" runat="server" name="state">
			                                <option value="">Select State</option>
			                                <option value="AK">Alaska</option>
			                                <option value="AL">Alabama</option>
			                                <option value="AR">Arkansas</option>
			                                <option value="AZ">Arizona</option>
			                                <option value="CA">California</option>
			                                <option value="CO">Colorado</option>
			                                <option value="CT">Connecticut</option>
			                                <option value="DC">District of Columbia</option>
			                                <option value="DE">Delaware</option>
			                                <option value="FL">Florida</option>
			                                <option value="GA">Georgia</option>
			                                <option value="HI">Hawaii</option>
			                                <option value="IA">Iowa</option>
			                                <option value="ID">Idaho</option>
			                                <option value="IL">Illinois</option>
			                                <option value="IN">Indiana</option>
			                                <option value="KS">Kansas</option>
			                                <option value="KY">Kentucky</option>
			                                <option value="LA">Louisiana</option>
			                                <option value="MA">Massachusetts</option>
			                                <option value="MD">Maryland</option>
			                                <option value="ME">Maine</option>
			                                <option value="MI">Michigan</option>
			                                <option value="MN">Minnesota</option>
			                                <option value="MO">Missouri</option>
			                                <option value="MS">Mississippi</option>
			                                <option value="MT">Montana</option>
			                                <option value="NC">North Carolina</option>
			                                <option value="ND">North Dakota</option>
			                                <option value="NE">Nebraska</option>
			                                <option value="NH">New Hampshire</option>
			                                <option value="NJ">New Jersey</option>
			                                <option value="NM">New Mexico</option>
			                                <option value="NV">Nevada</option>
			                                <option value="NY">New York</option>
			                                <option value="OH">Ohio</option>
			                                <option value="OK">Oklahoma</option>
			                                <option value="OR">Oregon</option>
			                                <option value="PA">Pennsylvania</option>
			                                <option value="PR">Puerto Rico</option>
			                                <option value="RI">Rhode Island</option>
			                                <option value="SC">South Carolina</option>
			                                <option value="SD">South Dakota</option>
			                                <option value="TN">Tennessee</option>
			                                <option value="TX">Texas</option>
			                                <option value="UT">Utah</option>
			                                <option value="VA">Virginia</option>
			                                <option value="VT">Vermont</option>
			                                <option value="WA">Washington</option>
			                                <option value="WI">Wisconsin</option>
			                                <option value="WV">West Virginia</option>
			                                <option value="WY">Wyoming</option>
		                                </select>
                                        </div>
                                    </asp:TableCell>
<%--                            </div>--%>
                        </asp:TableRow>
                        <asp:TableRow visible="true" ID="tblZip" runat="server">
                            <asp:TableCell>Zip :</asp:TableCell>
                            <asp:TableCell><asp:TextBox  ID="txtZip" TabIndex="5" CssClass="form-control" runat="server" ></asp:TextBox></asp:TableCell>
                        </asp:TableRow>

                        <tr>
                           <td>Notes  : </td>
                           <td><asp:TextBox ID="txtNotes" TextMode="MultiLine" TabIndex="11" runat="server" CssClass="form-control"></asp:TextBox> </td> 
                        </tr>
                        <tr>
                           <td>Date Needed : </td>
                           <td><asp:TextBox ID="txtDateNeeded" TabIndex="12" runat="server" CssClass="form-control"></asp:TextBox> </td> 
                        </tr>

                    </tbody>
                </table>
                <asp:Button runat="server" ID="btnPrint" CssClass="btn btn-dark " ClientIDMode="Static" Text="Print" OnClientClick="printDiv('PrintArea');return false;" />
                <asp:LinkButton ID="lnkSubmitOrderDetails" TabIndex="11" runat="server" CssClass="btn btn-dark" OnClick="lnkSubmitOrder_Click" Text="Update"></asp:LinkButton>
                <asp:Button CssClass="btn btn-dark" ID="BacktoInventoryItems" TabIndex="12" runat="server" Text="Back" OnClick="BacktoInventory_Click"/>          

            </div>
             
        </div>
     <div class="modal fade" id="UploadFileModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title"  id="exampleModalLabel">Please upload an excel file with a list of store, addresses, and quantity per store.</h5>

                            
                            <button  class="close" type="button" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">×</span>
                            </button>
                        </div>
                         <table class="table table-bordered table-striped" cellspacing="0">
                             <tbody>
                                 <tr><td>Sample File</td>

                                     <td><a href='https://usgfilestoragebeta.blob.core.windows.net/usgfiles/USGInventorySampleFile.xlsx'>Please click here to download Sample File</a></td>
                                 </tr>
                                 <tr>
                                 <td>Upload File</td>l
                                 <td>
                                     <input class="form-control"  type="file" id="File1" multiple runat="server"/>
                                 </td>
                                 </tr>
                             </tbody>
                         </table>
                        <div class="modal-footer">
                            <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancel</button>
                            <asp:Button ID="btnFileupload" runat="server" CssClass="btn btn-dark" OnClick="btnFileupload_Click" Text="Upload Files" />
                        </div>
                    </div>
                </div>
            </div>
<div class="card-body bg-white html-content" id="PrintArea" style="visibility: hidden;">
<div class="card-header">
          <span class="card-title"> Inventory Item Details </span>&nbsp;&nbsp;&nbsp;
           <asp:Label runat="server" ID="Label2" ></asp:Label>

        <div class="card-body bg-white" >
             <div class="table-responsive">

                <table class="table table-bordered table-striped">
                    <tbody>
                     <asp:Repeater runat="server" ID="rptForPrint" >
                          <ItemTemplate>
                            <tr>
                                <td><span class='bold'>Sign Type:</span>   <%# Eval("SignType") %></td> 
                                <td><span class='bold'>Number Of Sides:</span>   <%# Eval("NumberOfSides") %></td> 
                                <td><span class='bold'>Promotion:</span>   <%# Eval("Promotion") %></td> 
                                <td><span class='bold'>Image:</span>   <%# GetImage(Eval("ImageUrl")) %></td> 
                            </tr>
                        </ItemTemplate>
                      </asp:Repeater>
  
                    </tbody>
                </table>

            </div>
             
        </div>
    </div>
    </br>
    <div class="card-header">
          <span class="card-title"> Shipping Details </span>&nbsp;&nbsp;&nbsp;
                      <asp:Label runat="server" ID="Label3" ></asp:Label>


        <div class="card-body bg-white" >
             <div class="table-responsive">
                <table class="table table-bordered table-striped">
                    <tbody>
                        <tr>
                            <td>Bulk  :</td>
                            <td>
                                <asp:Label runat="server" ID="lblBulk"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Store Level :</td>
                            <td>
                                <asp:Label runat="server" ID="lblStoreLevel"></asp:Label>
                            </td>
                        </tr>
                        <asp:TableRow visible="true" ID="tblAttentionLinePrint" runat="server">
                            <asp:TableCell>Attention Line  : </asp:TableCell>
                            <asp:TableCell><asp:Label ID="lblAttentionLine" runat="server" ></asp:Label> </asp:TableCell>   
                        </asp:TableRow>
                        <asp:TableRow visible="true" ID="tblAddress1Print" runat="server">
                            <asp:TableCell>Address 1 : </asp:TableCell>
                            <asp:TableCell><asp:Label runat="server" ID="lblAddress1"  ></asp:Label></asp:TableCell>

                        </asp:TableRow>
                        <asp:TableRow visible="true" ID="tblAddress2Print" runat="server">
                            <asp:TableCell>Address 2 :</asp:TableCell>
                            <asp:TableCell><asp:Label  ID="lblAddress2"  runat="server" ></asp:Label></asp:TableCell>

                        </asp:TableRow>
                        <asp:TableRow visible="true" ID="tblCityPrint" runat="server" >
                            <asp:TableCell>City  :</asp:TableCell>
                            <asp:TableCell><asp:Label ID="lblCity"  runat="server" ></asp:Label></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow visible="true"  ID="tblStatePrint" runat="server">
                                <asp:TableCell>State  :</asp:TableCell>	
                                <asp:TableCell><asp:Label ID="lblState"  runat="server" ></asp:Label></asp:TableCell>

                        </asp:TableRow>
                        <asp:TableRow visible="true" ID="tblZipPrint" runat="server">
                            <asp:TableCell>Zip :</asp:TableCell>
                            <asp:TableCell><asp:Label  ID="lblZip"  runat="server" ></asp:Label></asp:TableCell>
                        </asp:TableRow>

                        <tr>
                            <td>Total Quantity  : </td>
                            <td> <asp:Label runat="server" ID="lblQuantity"></asp:Label></td>
                        </tr>
                        <tr>
                           <td>Notes  : </td>
                           <td><asp:Label runat="server" ID="lblNotes"></asp:Label> </td> 
                        </tr>
                        <tr>
                           <td>Date Needed : </td>
                           <td> <asp:Label runat="server" ID="lblDateNeeded"></asp:Label> </td> 
                        </tr>

                    </tbody>
                </table>

            </div>
             
        </div>
    </div>
</div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
   
  <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>

     <script>
         $(function () {
             $("#<%=txtDateNeeded.ClientID%>").datepicker({
                showOn: "button",
                buttonImage: "https://jqueryui.com/resources/demos/datepicker/images/calendar.gif",
                buttonImageOnly: true,
                buttonText: "Select date"

            })
         });
     </script>
     <link href="../Vendor/bootstrap/css/ModelDialog.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>

    <script>
       
        function printDiv(PrintArea) {
            debugger
            var mywindow = window.open('', 'PRINT', 'height=800,width=1000');

            mywindow.document.write('<html><head>');
            mywindow.document.write('</head><body >');
            //mywindow.document.write('<style type="text/css">.center {margin: auto;border: 1px solid black;padding: 30px;}');
            //mywindow.document.write('.labelstyle{text-align:center;margin: auto;font-weight: bold;width: fit-content;margin-bottom: .5rem;}</style>');
            var style = "<style>";
            style = style + "table {width: 100%; font: 17px Calibri;}";
            style = style + "table, th, td {border: solid 1px #DDD; border-collapse: collapse;";
            style = style + "padding: 2px 3px; text-align: left;}";
            style = style + "</style>";

            mywindow.document.write(style);
            mywindow.document.write(document.getElementById(PrintArea).innerHTML);


            mywindow.document.write('</body></html>');

            mywindow.document.close(); // necessary for IE >= 10
            mywindow.focus(); // necessary for IE >= 10*/

            mywindow.print();
            mywindow.close();
            var hfvalue = document.getElementById("poId").value;

            //var hfvalue = $(this).parents('tr').find('td input[type="hidden"]').val();
            $.ajax({
                type: "POST",
                url: 'PurchaseOrderDetails.aspx/UpdatePurchaseOrder',
                data: '{nPurchaseOrderID: ' + hfvalue + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    location.reload();
                },
                failure: function (response) {
                    //alert(response.d);
                }

            });

            return false;
        }
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

