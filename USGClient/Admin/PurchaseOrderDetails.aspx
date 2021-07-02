<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="PurchaseOrderDetails.aspx.cs" Inherits="USGClient.Admin.PurchaseOrderDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
    <div class="card mb-3">
        <div class="card-header">
            <i class="fa fa-table "></i><span class="card-title"> Purchase Order Details </span>&nbsp;&nbsp;&nbsp;
            <asp:Label runat="server" ID="lblMessage" ></asp:Label>
                         <input type="hidden" id="poId" value="<%=Request.QueryString["POID"]%>">
<%--                         <input type="hidden" runat="server" id="poStatus" value="<%# Eval("PurchaseOrderStatusTypeID") %>">--%>

        </div>
        <div class="card-body bg-white" >
            <div class="table-responsive">
                 <table class="table table-bordered table-striped" id="dataTable" width="100%" >

                  <thead>
                   <asp:HiddenField runat="server"  id="poStatus" value='<%# Eval("PurchaseOrderStatusTypeID")%>' > </asp:HiddenField>

                     <asp:Repeater runat="server" ID="rptList">
                     <ItemTemplate> 
                              <asp:HiddenField runat="server"  id="txtSelectedVendorID" value='<%# Eval("VendorID")%>' > </asp:HiddenField>
                        <tr>
                            <td><span style='font-weight:bold;' >PO Number:</span>   <%# Eval("PurchaseOrderID") %></td>                       
                            <td><span style='font-weight:bold;' >Vendor: </span> <%# Eval("VendorName") %> </td> 
                            <td><span style='font-weight:bold;' >Date:</span> <%# Eval("CreateDate") %>  </td> 
                            <td><span style='font-weight:bold;' >Status:</span> <%# Eval("PurchaseOrderStatus") %>  </td>
                        </tr>

                     </ItemTemplate>
                     </asp:Repeater>
                  </thead>                  
              </table>
                 <table class="table table-bordered table-striped" id="vendorTable" runat="server" visible=false width="100%" >
                    <thead> </thead>

                        <tbody>
                        <tr>
                            <td >Vendor :</td>
                            <td><asp:DropDownList ID="ddlVendor" runat="server" AutoPostBack="True"
                               AppendDataBoundItems="true"  onselectedindexchanged="DropDownList1_SelectedVendorChanged" CssClass="form-control" ></asp:DropDownList></td>                           
                        </tr>
                        </tbody>
                </table>
                <table class="table table-bordered table-striped" id="vendorDetails" runat="server" visible='false' width="100%" >
                    <thead> </thead>

                        <tbody>
                           
<%--                            <tr>
                                <td colspan="4" style="text-align:center;font-weight: bold;">Rep Info</td>
                            </tr>--%>
                        <tr>
                            <td >Rep Name   :</td>
                            <td><asp:TextBox ID="txtRepName" TabIndex="10" onBlur='addDashes(this)' CssClass="form-control" runat="server" /></td>
                            <td >Rep Phone :</td>
                            <td><asp:TextBox ID="txtRepPhone" TabIndex="11" CssClass="form-control" runat="server" /></td>

                        </tr>

                         <tr>
                            <td >Rep Email   :</td>
                            <td><asp:TextBox ID="txtRepEmail" TabIndex="12" CssClass="form-control" runat="server" /></td>
                            <td >Memo   :</td>
                            <td><asp:TextBox ID="txtMemo" TabIndex="13" TextMode="MultiLine" CssClass="form-control" runat="server" /></td>

                        </tr>
                        </tbody>
                </table>


   <div class="card mb-3 cus_card" runat="server" id="div2">
           <div class="card-header" id="cardHeader">
            <div class="float-right"> 
                <asp:LinkButton class="btn btn-dark" ID="lnkAddbtn" OnClick="btnAddRow_Click" runat="server" >Add</asp:LinkButton>
            </div>
            </div>

        
        <div class="card-body bg-white" >
            <div class="table-responsive">
                
                <table class="table table-bordered table-striped" id="dataTable1"  width="100%">
                    <thead>
                        <tr>
                            <th>Product or Service </th>
                            <th>Quantity </th>
                            <th>Unit Cost </th>
                            <th>Extended Cost </th>
                            <th>Update</th>
                            <th>Delete</th>

                        </tr>
                    </thead>
                    <tbody>

                    <asp:Repeater runat="server" ID="rptPurchaseOrderDetails" OnItemDataBound="OnItemDataBound">
                          <ItemTemplate> 
                              <asp:TextBox runat="server" type="hidden" id="txtSubstrateID" value='<%# Eval("SubstrateID")%>' > </asp:TextBox>
                              <asp:TextBox runat="server" type="hidden" id="txtVendorID" value='<%# Eval("VendorID")%>' > </asp:TextBox>
                               <asp:TextBox runat="server" type="hidden" id="txtPurchaseOrderItemID" value='<%# Eval("PurchaseOrderItemID")%>' > </asp:TextBox>

                       
                        <tr>

                            <td><asp:DropDownList ID="ddlSubstrateName"  runat="server" TabIndex="1" CssClass="form-control" AutoPostBack="True"
                               AppendDataBoundItems="true"  onselectedindexchanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList></td> 
                            <td><asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control" TabIndex="2" AutoPostBack="True"  AppendDataBoundItems="true"  OnTextChanged="txtQuantity_TextChanged"></asp:TextBox></td>
                            
                            <td><asp:TextBox ID="txtUnitCost" runat="server"  CssClass="form-control" TabIndex="3"></asp:TextBox></td>
                            <td><asp:Label ID="lblExtendedCost" runat="server"  TabIndex="4"></asp:Label></td>
                            <td><asp:LinkButton runat="server" ID="lnUpdate" OnClick="btnUpdate_Click" TabIndex="5" CommandName="Update" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "PurchaseOrderItemID")%>'>Update </asp:LinkButton></td>
                            <td><asp:LinkButton runat="server" ID="lbDelete" OnClick="btnDelete_Click" TabIndex="6" CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "PurchaseOrderItemID")%>'>Delete </asp:LinkButton></td>

                        </tr>

                        </ItemTemplate>
                      </asp:Repeater> 
                       <asp:TableRow visible="true" runat="server" ID="tblTotalExtendedCost" >
                            <asp:TableCell colspan="3" style="text-align:center;font-weight: bold;">Total Extended Cost</asp:TableCell>
                            <asp:TableCell style="font-weight: bold;"><asp:Label ID="lblTotalExtendedCost" runat="server" ></asp:Label></asp:TableCell>
                           <asp:TableCell></asp:TableCell> <asp:TableCell></asp:TableCell>

                        </asp:TableRow>

                    </tbody>
                         
                </table>

                            <asp:Button runat="server" ID="btnCommit" OnClick="btnCommit_Click"  Text="Commit" CssClass="btn btn-dark mr-2"/>  
                            <asp:Button runat="server" ID="btnPending" OnClick="btnPending_Click"  Text="Pending" CssClass="btn btn-dark mr-2"/>  
                            <asp:Button runat="server" ID="btnVoid" OnClick="btnVoid_Click" Text="Void"  CssClass="btn btn-dark mr-2"/>
                            <asp:Button runat="server" ID="btnPrint" CssClass="btn btn-dark " ClientIDMode="Static" Text="Print" OnClientClick="printDiv('PrintArea');return false;" />
                            <asp:Button runat="server" ID="btnBack"  OnClick="btnBack_Click"  Text="Back" CssClass="btn btn-dark mr-2"/>
     
            </div>
        </div>
        </div>      


<%--                <asp:LinkButton ID="lnkSaveVendorItemDetailsdfds" class="lbSave" style="" TabIndex="17" runat="server" CssClass="btn btn-dark" OnClick="lnkSaveVendorItemDetails_Click" Text="Update"></asp:LinkButton>
                <asp:Button CssClass="btn btn-dark" class="lbBack" style="" ID="BacktoVendorItemsd" TabIndex="18" runat="server" Text="Back" OnClick="BacktoVendorItem_Click"/>--%>
            </div>
             
        </div>
        </div>

 <div class="card-body bg-white html-content" id="PrintArea" style="visibility: hidden;">
    <div class="card mb-3">
         <div class="card-header">
            <i class="fa fa-table "></i><span class="card-title"> Purchase Order Details </span>&nbsp;&nbsp;&nbsp;
        </div>
        </br>
        <div class="card-body bg-white" >
            <div class="table-responsive">
                 <table class="table table-bordered table-striped" id="dataTable2" width="100%" >

                  <thead>

                     <asp:Repeater runat="server" ID="rptListForPrint" >
                     <ItemTemplate> 

                        <tr><td><span class='bold'>PO Number:</span>   <%# Eval("PurchaseOrderID") %></td>                       
                        <td><span class='bold'>Vendor: </span> <%# Eval("VendorName") %> </td> 
                        <td><span class='bold'>Date:</span> <%# Eval("CreateDate") %>  </td>
                        <td><span class='bold'>Status:</span> <%# Eval("PurchaseOrderStatus") %>  </td> 
                        </tr>
                     </ItemTemplate>
                     </asp:Repeater>
                  </thead>                  
              </table>

                </br>
               </br>
   <div class="card mb-3" runat="server" id="div1">
          <div class="card-header">
          </div>

        
        <div class="card-body bg-white" >
            <div class="table-responsive">
                
                <table class="table table-bordered table-striped" id="dataTable3"  width="100%">
                    <thead></thead>

                    <tbody>
                        <tr>
                            <th>Product or Service </th>
                            <th>Quantity </th>
                            <th>Unit Cost </th>
                            <th>Extended Cost </th>

                        </tr>

                    <asp:Repeater runat="server" ID="rptPurchaseOrderDetailsForPrint" >
                          <ItemTemplate> 
                        <tr>
                                  <td><%# Eval("SubstrateName") %></td>
                                  <td><%# Eval("Quantity") %></td>
                                  <td><%# Eval("UnitCost") %></td>
                                  <td><%# Eval("ExtendedCost") %></td>

                        </tr>
                        </ItemTemplate>
                      </asp:Repeater> 
                        <asp:TableRow visible="true" runat="server" ID="tblTotalExtendedCostForPrint" >
                            <asp:TableCell colspan="3" style="text-align:center;font-weight: bold;">Total Extended Cost</asp:TableCell>
                            <asp:TableCell style="font-weight: bold;"><asp:Label ID="lblTotalExtendedCostForPrint" runat="server" ></asp:Label></asp:TableCell>
                        </asp:TableRow>

                    </tbody>
                </table>
     
            </div>
        </div>
        </div>      


            </div>
             
        </div>
        </div>
</div>
<div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
<%--                            <h5 class="modal-title"  id="exampleModalLabel">List Of Jobs</h5>--%>
                            <button  class="close" type="button" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">×</span>
                            </button>
                        </div>
                         <div class="modal-header">
                        Do you want to change the Vendors price moving forward?
                              </div>
                     <asp:Table class="table table-bordered table-striped" cellspacing="0" runat="server" visible="false">

                        <asp:TableRow>
                           <asp:TableCell><asp:TextBox runat="server" type="hidden" id="tcSubstrateID" > </asp:TextBox></asp:TableCell >
                           <asp:TableCell><asp:TextBox runat="server" type="hidden" id="tcVendorID"  > </asp:TextBox></asp:TableCell >
                           <asp:TableCell><asp:TextBox ID="tcQuantity" type="hidden" runat="server" ></asp:TextBox></asp:TableCell >
                           <asp:TableCell><asp:TextBox ID="tcUnitCost"  type="hidden" runat="server"></asp:TextBox></asp:TableCell >


                        </asp:TableRow>

                        </asp:Table>       
                        <div class="modal-footer">
                            <asp:LinkButton runat="server" ID="lnkNo" class="btn btn-secondary" type="button"  OnClick="lnkNotUpdatePrice_Click">No</asp:LinkButton>
                            <asp:LinkButton runat="server" ID="lnkYes" CssClass="btn btn-primary" Text="Yes" OnClick="lnkUpdatePrice_Click"></asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>  
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <script>

        function getfoc() {
            //window.open('About.aspx', 'popUpWindow', 'height=300,width=600,left=100,top=30,resizable=Yes,scrollbars=Yes,toolbar=no,menubar=no,location=no,directories=no, status=No')

        }
        // Call the dataTables jQuery plugin
        $(document).ready(function () {
            $.fn.dataTable.moment('M/D/YYYY');
            $('#dataTable1').DataTable({
                "order": [[1, "asc"]]
            });

        });
        $('#dataTable1').each(function () {

            $("tr:even").css("background-color", "#EEE");
            $("tr:odd").css("background-color", "#ffffff");
        }); 


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

    </script>
     <script>


         $(document).ready(function () {

             var poId = document.getElementById("poId").value;
             var status = document.getElementById('<%= poStatus.ClientID%>').value;

             if (poId != "") {
                 $('[id$=btnCommit]').show();
                $('[id$=btnVoid]').show();
                $('[id$=btnPrint]').show();


            }
            else if (poId == "") {
                $('[id$=btnVoid]').hide();
                 $('[id$=btnPrint]').hide();
                 $('[id$=btnPending]').hide();
                 $('[id$=btnCommit]').hide();


            }

             if (status == "3") {
                 $('[id$=btnVoid]').hide();
                 $('[id$=lnkAddbtn]').hide();
                 $('#cardHeader').css('visibility', 'hidden');
                 $('#ContentPlaceHolder2_div2').css('border', 'none');
                 $('#ContentPlaceHolder2_div2').css('box-shadow', 'none');
                 $('#ContentPlaceHolder2_div2 .card-body').css('padding', '0');


             }
             else if (status == "1") {
                 $('[id$=lnkAddbtn]').hide();
                 $('[id$=btnCommit]').hide();
                 $('#cardHeader').css('visibility', 'hidden');
                 $('#ContentPlaceHolder2_div2').css('border', 'none');
                 $('#ContentPlaceHolder2_div2').css('box-shadow', 'none');
                 $('#ContentPlaceHolder2_div2 .card-body').css('padding', '0');

             }
             else if (status == "2") {
                 $('[id$=btnPending]').hide();

             }
        });
         </script>
</asp:Content>