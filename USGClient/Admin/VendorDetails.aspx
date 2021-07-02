<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="VendorDetails.aspx.cs" Inherits="USGClient.Admin.VendorDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <style>

    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
    <asp:Button ID="Button1" runat="server" CssClass="btn btn-dark " ClientIDMode="Static" Text="Print" OnClientClick="printDiv('PrintArea');return false;" />
 <div class="card-body bg-white html-content" >
    <div class="card mb-3">
        <div class="card-header">
            <i class="fa fa-table "></i><span class="card-title"> Vendor Details </span>&nbsp;&nbsp;&nbsp;
            <asp:Label runat="server" ID="lblMessage" ></asp:Label>
        </div>
        <div class="card-body bg-white" >
            <div class="table-responsive">
                <table class="table table-bordered table-striped" style="width: 100%">
                    <tbody >
                        <tr>
                            <td >Vendor ID :</td>
                             <td><asp:Label runat="server" TabIndex="0"  ID="lblVendorID"></asp:Label></td>
                            <td>Company Phone :</td>
                            <td>
                                <div class="input-group">
                                    <asp:TextBox ID="txtCompanyPhone" class="removeBorder" TabIndex="9"  onBlur='addDashes(this)' CssClass="form-control" runat="server" />
                                    <div class="input-group-append">&nbsp;&nbsp;
                                        <asp:TextBox ID="txtPhoneExtension" class="removeBorder" TabIndex="9" placeholder="Extension"  CssClass="form-control" runat="server" />
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td >Vendor Name  :</td>
                            <td><asp:TextBox ID="txtVendorName" TabIndex="1" CssClass="form-control" runat="server" /></td>
                            <td >Fax   :</td>
                            <td><asp:TextBox ID="txtFax" TabIndex="10" onBlur='addDashes(this)' CssClass="form-control" runat="server" /></td>
                        </tr>
                        <tr>
                            <td >Address 1   :</td>
                            <td><asp:TextBox ID="txtAddress1" TabIndex="1" CssClass="form-control" runat="server" /></td>
                            <td >Company Email  :</td>
                            <td><asp:TextBox ID="txtCompanyEmail" TabIndex="11" CssClass="form-control" runat="server" /></td>
                        </tr>
                         <tr>
                            <td >Address 2   :</td>
                            <td><asp:TextBox ID="txtAddress2" TabIndex="4" CssClass="form-control" runat="server" /></td>
                            <td >Website   :</td>
                            <td><asp:TextBox ID="txtWebsite" TabIndex="12" CssClass="form-control" runat="server" /></td>
                        </tr>
                        <tr>
                            <td >City  :</td>
                            <td><asp:TextBox ID="txtCity" TabIndex="5" CssClass="form-control" runat="server" /></td>
                            <td >Rep Name   :</td>
                            <td><asp:TextBox ID="txtRepName" TabIndex="13" CssClass="form-control" runat="server" /></td>
                        </tr>
                        <tr>
<%--                            <td >State  :</td>--%>
<%--                            <td><asp:TextBox ID="txtState" TabIndex="6" CssClass="form-control" runat="server" /></td>--%>
<div class="form-group">
<td >State  :</td>	
    <td><div >
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
        </td>
</div>
                            <td >Rep Phone :</td>
                            <td>
                             <div class="input-group">   
                                <asp:TextBox ID="txtRepPhone" TabIndex="14" onBlur='addDashes(this)' CssClass="form-control" runat="server" />
                                   <div class="input-group-append">&nbsp;&nbsp;
                                        <asp:TextBox ID="txtRepExtension" class="removeBorder" TabIndex="9" placeholder="Extension"  CssClass="form-control" runat="server" />
                                    </div>

                             </div>      
   
                             </td>
                        </tr>
                        <tr>
                            <td >Zip Code   :</td>
                            <td><asp:TextBox ID="txtZipCode" TabIndex="7" CssClass="form-control" runat="server" /></td>
                            <td >Rep Email   :</td>
                            <td><asp:TextBox ID="txtRepEmail" TabIndex="15" CssClass="form-control" runat="server" /></td>
                        </tr>
                        <tr>
                            <td >Memo  :</td>
                            <td><asp:TextBox ID="txtMemo" TextMode="MultiLine" TabIndex="8" CssClass="form-control" runat="server" /></td>
                            <td >Active    :</td>                          
                            <td>
                                <asp:RadioButtonList ID="rbActive" TabIndex="17" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem  Value="True">Yes</asp:ListItem>
                                    <asp:ListItem  Value="False">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>

                        </tr>
                        

                    </tbody>
                </table>
                <asp:LinkButton ID="lnkSaveVendorItemDetails" class="lbSave" style="" TabIndex="17" runat="server" CssClass="btn btn-dark" OnClick="lnkSaveVendorItemDetails_Click" Text="Update"></asp:LinkButton>
                <asp:Button CssClass="btn btn-dark" class="lbBack" style="" ID="BacktoVendorItem" TabIndex="18" runat="server" Text="Back" OnClick="BacktoVendorItem_Click"/>
            </div>
             
        </div>
        </div>

    <div class="card mb-3" runat="server" visible="false" id="liProduct" >
           <div class="card-header">
               <i class="fa fa-table "></i><span class="card-title"> Product Details </span>&nbsp;&nbsp;&nbsp;
           </div>
           <div class="card-body bg-white" >
           <div class="table-responsive">
 
              <table class="table table-bordered table-striped"  id="dataTable1" width="100%" >
                  <thead>
                      <tr>
                          <th>Product or Service</th>
                          <th>Unit of Measure </th>
                          <th>Width </th>
                          <th>Height  </th>
<%--                          <th>Primary Vendor  </th>--%>
                          <th>Price  </th>
                          
<%--                          <th>Contact Name  </th>
                          <th>Phone Number  </th>--%>
<%--                          <th>Details   </th>--%>
                      </tr>
                  </thead>

                  <tbody>
                      <asp:Repeater runat="server" ID="rptSubstratebyID" >
                          <ItemTemplate>
                              <tr>
                                  <td><%# Eval("SubstrateName") %></td>
                                  <td><%# Eval("Measurement") %></td>
                                  <td><%# Eval("Width") %></td>
                                  <td><%# Eval("Height") %></td>
<%--                                  <td><%# Eval("VendorName") %></td>--%>
                                  <td><%# Eval("Price") %></td>
<%--                                  <td><%# Eval("RepName") %></td>
                                  <td><%# Eval("RepPhone") %></td>--%>
<%--                                  <td><a href='SubstrateDetails.aspx?SID=<%# Eval("SubstrateID") %>'>DETAILS</a></td>--%>

                              </tr>
                          </ItemTemplate>
                      </asp:Repeater>
                  </tbody>
              </table>
            </div>
            </div>

    </div>
</div>

 <div class="card-body bg-white html-content" id="PrintArea" style="visibility: hidden;">
    <div class="card mb-3">
        <div class="card-header">
            <i class="fa fa-table "></i><span class="card-title;" > Vendor Details </span>&nbsp;&nbsp;&nbsp;
            </br>
            </br>
            <asp:Label runat="server" ID="Label1" ></asp:Label>
        </div>
        <div class="card-body bg-white" >
            <div class="table-responsive">
                <table>
                        <tr>
                            <td >Vendor ID :</td>
                             <td><asp:Label runat="server"  ID="lbpVendorID"></asp:Label></td>
                            <td >Company Phone   :</td>
                            <td><asp:Label ID="lbpCompanyPhone" class="removeBorder"  runat="server" /></td>
                        </tr>
                        <tr>
                            <td >Vendor Name  :</td>
                            <td><asp:Label ID="lbpVendorName"   runat="server" /></td>
                            <td >Fax   :</td>
                            <td><asp:Label ID="lbpFax"  runat="server" /></td>
                        </tr>
                        <tr>
                            <td >Address1   :</td>
                            <td><asp:Label ID="lbpAddress1"  runat="server" /></td>
                            <td >Company Email  :</td>
                            <td><asp:Label ID="lbpCompanyEmail"  runat="server" /></td>
                        </tr>
                         <tr>
                            <td >Address2   :</td>
                            <td><asp:Label ID="lbpAddress2"  runat="server" /></td>
                            <td >Website   :</td>
                            <td><asp:Label ID="lbpWebsite"  runat="server" /></td>
                        </tr>
                        <tr>
                            <td >City  :</td>
                            <td><asp:Label ID="lbpCity"  runat="server" /></td>
                            <td >Rep Name   :</td>
                            <td><asp:Label ID="lbpRepName"  runat="server" /></td>
                        </tr>
                        <tr>
                            <td >State  :</td>
                            <td><asp:Label ID="lbpState" runat="server" /></td>
                            <td >Rep Phone :</td>
                            <td><asp:Label ID="lbpRepPhone"  runat="server" /></td>
                        </tr>
                        <tr>
                            <td >ZipCode   :</td>
                            <td><asp:Label ID="lbpZipCode"  runat="server" /></td>
                            <td >Rep Email   :</td>
                            <td><asp:Label ID="lbpRepEmail"  runat="server" /></td>
                        </tr>
                        <tr>
                            <td >Memo  :</td>
                            <td><asp:Label ID="lbpMemo"   runat="server" /></td>
                            <td >Active    :</td>     
                            <td><asp:Label ID="lbpActive"   runat="server" /></td>
                        </tr>
</table>
            </div>
        </div>
        </div>
     </br>
    <div class="card mb-3" runat="server"  visible="false" id="lipProduct">
            <div class="card-header">
                  <i class="fa fa-table "></i><span class="card-title"> Product Details </span>&nbsp;&nbsp;&nbsp;
            </br>
            </br>
            </div>
           <div class="card-body bg-white" >
           <div class="table-responsive">
               
              <table class="table table-bordered table-striped"  id="dataTable2" width="100%" >
                  
                      <tr>
                          <td>Product or Service</td>
                          <td>Unit of Measure </td>
                          <td>Width </td>
                          <td>Height  </td>
                          <td>Price  </td>
                          
                      </tr>
                      <asp:Repeater runat="server" ID="rbpProduct" >
                          <ItemTemplate>
                              <tr>
                                  <td><%# Eval("SubstrateName") %></td>
                                  <td><%# Eval("Measurement") %></td>
                                  <td><%# Eval("Width") %></td>
                                  <td><%# Eval("Height") %></td>
                                  <td><%# Eval("Price") %></td>
                              </tr>
                          </ItemTemplate>
                      </asp:Repeater>
              </table>
            </div>
        </div>

    </div>
</div>


</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
   <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jspdf/1.5.3/jspdf.min.js"></script>
<script type="text/javascript" src="https://html2canvas.hertzen.com/dist/html2canvas.js"></script>
    <script>
       

        //$('#txtRepPhone').keyup(function () {
        //    $(this).val($(this).val().replace(/(\d{3})\-?(\d{3})\-?(\d{4})/, '$1-$2-$3'))
        //});

        function addDashes(f) {
            $(f).val($(f).val().replace(/(\d{3})\-?(\d{3})\-?(\d{4})/, '$1-$2-$3'))
            //f.value = f.value.slice(0, 3) + "-" + f.value.slice(3, 6) + "-" + f.value.slice(6, 10);
        }
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

            return false;
        }

<%--        function CreatePDFfromHTML() {
    var HTML_Width = $(".html-content").width();
    var HTML_Height = $(".html-content").height();
    var top_left_margin = 15;
    var PDF_Width = HTML_Width + (top_left_margin * 2);
    var PDF_Height = (PDF_Width * 1.5) + (top_left_margin * 2);
    var canvas_image_width = HTML_Width;
    var canvas_image_height = HTML_Height;

    var totalPDFPages = Math.ceil(HTML_Height / PDF_Height) - 1;

    html2canvas($(".html-content")[0]).then(function (canvas) {
        var imgData = canvas.toDataURL("image/jpeg", 1.0);
        var pdf = new jsPDF('p', 'pt', [PDF_Width, PDF_Height]);
        pdf.addImage(imgData, 'JPG', top_left_margin, top_left_margin, canvas_image_width, canvas_image_height);
        for (var i = 1; i <= totalPDFPages; i++) { 
            pdf.addPage(PDF_Width, PDF_Height);
            pdf.addImage(imgData, 'JPG', top_left_margin, -(PDF_Height*i)+(top_left_margin*4),canvas_image_width,canvas_image_height);
        }
        pdf.save(<%=Request.QueryString["CID"]%>+"_ShippingTotalOrderSummary.pdf");
        return false;
    });
        }
        $("td:empty")
            .text("N/A");--%>
</script>

</asp:Content>
