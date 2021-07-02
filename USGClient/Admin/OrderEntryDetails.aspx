<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="OrderEntryDetails.aspx.cs" Inherits="USGClient.Admin.OrderEntryDetails" %>
<%@ Register Src="~/Controls/AdminDetails.ascx" TagPrefix="uc1" TagName="AdminDetails" %>
<%@ Register Src="~/Controls/JobMenuControl.ascx" TagPrefix="uc1" TagName="JobMenuControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
    <style>
   .btn-save:hover {
    background-color: #296729 !important;
    border-color: #296729 !important;
}  
   .btn-save {
    background-color: #296729 !important;
    border-color: #296729 !important;
}  
        table, tr, td, th
{
/*        border: 1px solid black;
*/        border-collapse:collapse;
}
td.arrow
{
    cursor:pointer;
}

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <uc1:AdminDetails runat="server" ID="AdminDetails" />
    <uc1:JobMenuControl runat="server" ID="JobMenuControl" />
    <div class="card mb-3">
        <div class="card-header">
            <img id="logo" runat="server" class="LogoSize"/><span class="card-title"> Order Entry Details </span>
            <div class="float-right"> <asp:LinkButton CssClass="btn btn-dark" ID="lnkBack" TabIndex="5" runat="server" Text="Back To Search" OnClick="lnkBacktoSearch_Click"/>  </div>   

            <asp:Label runat="server" ID="lblMessage" ></asp:Label>
        </div>
        <div class="card-body bg-white">
          <div class="table-responsive">
              <table class="table table-bordered table-striped" id="dataTable" width="100%" >

                  <thead>
                        <tr>
                            <td style="max-width:50px">
                                <asp:DropDownList ID="ddlPromotion"  runat="server" CssClass="form-control"  AutoPostBack="True" 
                                  OnSelectedIndexChanged="ddlPromotion_SelectedIndexChanged"></asp:DropDownList></td> 
                            <td></td>
                        </tr>                      
                        <tr>
                            <td><span class='bold'>Promotion Memo: </span> <span id="promotionMemo" runat="server"></span>  </td>
                            <td><span class='bold'>Production Memo:</span> <span id="productionMemo" runat="server"></span> </td>
                        </tr>
                        <tr> 
                        </tr>
                  </thead>                  
              </table>

           </div>
        </div>
   </div>
   <div class="card mb-3" runat="server" id="div2">
           <div class="card-header">
            <div class="float-right"> 
            
                <asp:LinkButton runat="server" ID="btnSave"  OnClick="btnUpdate_Click" CommandName="Update"  class="btn btn-dark btn-save"><i class="fa fa-floppy-o fa-2" aria-hidden="true"></i> Save All</asp:LinkButton>
                <asp:LinkButton class="btn btn-dark" OnClick="btnAddRow_Click" runat="server" >Add</asp:LinkButton>
                <a class="btn btn-dark" href='AddSignTypeFamily.aspx?CID=<%=Request.QueryString["CID"]%>&JID=<%=Request.QueryString["JID"]%>&JOID=<%=Request.QueryString["JOID"]%>' id="signtypeFamily">Add Sign Type Family</a>
<%--        <td><a href='ClientUserDetails.aspx?CID=<%# Eval("CustomerID") %>&CUID=<%# Eval("CustomerUserID") %>' style="color:#172C55">DETAILS</a></td>                                  --%>
            </div>
            </div>

        
        <div class="card-body bg-white" >
            <div class="table-responsive">
                
                <table class="table table-bordered table-striped" id="dataTable2"  width="100%">
                    <thead>
                          <tr>
                            <th>&nbsp;</th>
                            <th>Sign Type</th>
                            <th>Sides </th>
                            <th>Quantity </th>
                            <th>Priority </th>
                            <th>Hardware Qty</th>
                            <th>Hardware</th>
                            <th>Stores </th>
                            <th>Copy</th>
                            <th>Price </th>
                              <th></th>
                              
                        </tr>
                    </thead>
                    <tbody>
                    <asp:Repeater runat="server" ID="rptOrderEntry" OnItemDataBound="OnItemDataBound">
                          <ItemTemplate> 
                              <asp:TextBox runat="server" type="hidden" id="txtJobPromoOrderID" value='<%# Eval("JobOrderPromoID")%>' > </asp:TextBox>
                        <tr Id="HeaderId" class ="header">
                            
                            <td class="arrow"><asp:Label ID="lblArrow" runat="server"><span><i class="fas fa-chevron-right"></i></span></asp:Label></td>
                            <td class="noChange"><asp:DropDownList ID="ddlsigntypes"  runat="server" CssClass="form-control" TabIndex="1" AutoPostBack="True"
                            AppendDataBoundItems="true"  onselectedindexchanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList></td> 
                            <td class="noChange">
<%--                                <input type="text" class="form-control" placeholder="1 or 2">--%>
                                 <asp:RadioButtonList ID="rbNoOfSides" TabIndex="1" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem  Value="1">1</asp:ListItem>
                                    <asp:ListItem  Value="2">2</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td class="noChange"><asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control" TabIndex="1"></asp:TextBox></td>
                            <td class="noChange"><asp:TextBox ID="txtPriority" runat="server" CssClass="form-control" TabIndex="2"></asp:TextBox></td>
                            <td class="noChange"><asp:TextBox ID="txtHardwareQuantity" placeholder="Quantity"  runat="server" TabIndex="3" CssClass="form-control" ></asp:TextBox></td>
                            <td class="noChange"><asp:DropDownList ID="ddlHardware"  runat="server" CssClass="form-control" TabIndex="4"></asp:DropDownList> </td>
                            <td class="noChange"><asp:LinkButton runat="server" ID="btnStore" OnClick="btnAdd_Click"  TabIndex="5" CommandName="Add" class="btn btn-dark"><i class="fa fa-plus fa-2" aria-hidden="true"></i> Add (<%# Eval("TotalStore").ToString() == "0" ? "#"  :Eval("TotalStore") %>) </asp:LinkButton></td>
                            <td class="noChange"><asp:LinkButton runat="server" ID="btnCopyStores" CommandArgument='<%# Eval("JobOrderPromoID")%>' OnClick="btnCopyStores_Click" class="btn btn-dark"><i class="fa fa-clone fa-2" aria-hidden="true"></i> Copy</asp:LinkButton></td>
                            <td class="noChange"><asp:TextBox ID="txtPrice" style="width: 80px !important;" runat="server" TabIndex="6" CssClass="form-control" ></asp:TextBox></td>
                            <td class="noChange" style="text-align:right;">
                            <asp:LinkButton runat="server" ID="btnUpdate"  visible="false"  CommandName ="Update"  class="btn btn-success btn-sm rounded-0"> <i ID="addEditIcon" class="fa fa-table" > </i> &nbsp;SAVE</asp:LinkButton>
                            <asp:LinkButton runat="server"   ID="btnDelete" ClientIDMode="Static"  CommandArgument ='<%# Eval("JobOrderPromoID")%>' OnClick="btnDelete_Click" TabIndex="8" OnClientClick="return confirm('Are you sure you want to delete this file?');" class="btn btn-danger btn-sm rounded-0"><i class="fa fa-trash"></i>&nbsp;DELETE</asp:LinkButton>
                            </td>
                            
                        </tr>
                        <tr class="hideTr">
                            <th colspan="1">&nbsp;</th>
                            <th colspan="1">Materials</th>
                            <th colspan="1">Finishings 1 </th>
                            <th colspan="1">Finishings 2 </th>
                            <th colspan="1">Laminant </th>
                            <th colspan="2">Laminant Type</th>
                            <th colspan="1"></th>
                            <th></th>
                            <th></th>
                            <th></th>
<%--                            <th></th>--%>

                        </tr>

                        <tr class="hideTr">
                            <td></td>
                            <td><asp:DropDownList ID="ddlmaterials" runat="server" TabIndex="9" CssClass="form-control" ></asp:DropDownList></td>
                            <td><asp:DropDownList ID="ddlFinishings1" runat="server" TabIndex="10" CssClass="form-control"> </asp:DropDownList></td>
                            <td colspan="1"><asp:DropDownList ID="ddlFinishings2" runat="server" TabIndex="11"  CssClass="form-control"> </asp:DropDownList></td>
                            <td colspan="1"> <asp:DropDownList ID="ddlLaminant" runat="server" TabIndex="12" CssClass="form-control" ></asp:DropDownList>  </td>
                            <td colspan="2"><asp:RadioButtonList ID="rbLaminantType" runat="server" TabIndex="13" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Value="1">Top</asp:ListItem>
                                    <asp:ListItem Value="2">Bottom</asp:ListItem>
                                    <asp:ListItem Value="3">Encapsulate</asp:ListItem>
                                </asp:RadioButtonList></td>
                            <td> </td>
                            <td></td>
                            <td></td>
                            <td></td>
<%--                            <td></td>--%>
                        </tr>
                         <tr class="hideTr">
                             <td></td>
                         <td colspan="9"><asp:TextBox ID="txtProductionNote"   runat="server" TabIndex="14" placeholder="Additional Production Notes" CssClass="form-control" ></asp:TextBox></td>
                          <td></td>
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
         function goBack() {
             window.history.back();
         }

        
    // Call the dataTables jQuery plugin
         $(document).ready(function () {
            $('.hideTr').slideUp(50); 
            $.fn.dataTable.moment('M/D/YYYY');
            $('#dataTable2').DataTable({
                "order": [[2, "asc"]]
             });


              $("#btnDelete").click(function () {
             debugger
   $(this).closest('tr').find('td').each(function() {
        var textval = $(this).text(); // this will be the text of each <td>
   });
});
         });

         $('#dataTable2').each(function () {

             var row = $(this).find('tr');

             row[0].style.backgroundColor = "#ffffff"; 
             row[1].style.backgroundColor = "#ffffff"; 
             row[2].style.backgroundColor = "#ffffff"; 
             row[3].style.backgroundColor = "#ffffff"; 
             row[4].style.backgroundColor = "#ffffff"; 
             if (row.length > 5) {
                 row[5].style.backgroundColor = "#EEE";
                 row[6].style.backgroundColor = "#EEE";
                 row[7].style.backgroundColor = "#EEE";
                 row[8].style.backgroundColor = "#EEE"; 


                 if (row.length > 9) {
                     for (var i = 9; i < row.length; i++) {
                         var b = row[i].rowIndex;
                         var a = b % 9;
                         if (a <= 3) {
                             row[i].style.backgroundColor = "#ffffff";

                         }
                         else if (a >= 4 && a <= 7) {
                             row[i].style.backgroundColor = "#EEE";

                         }

                     }

                 }

             }
             //row[9].style.backgroundColor = "#EEE"; 

             
            
         }); 

         $('.arrow').click(function () {
           var a=  $(this).closest('tr');

             //$(this).find('span').text(function (_, value) { return value == '↓' ? '→   ' : '↓' });
             var b = $(this).find('span').find('i').hasClass("fas fa-chevron-right");
             if (b == true) {
                 $(this).find('span').find('i').removeClass('fas fa-chevron-right');
                 $(this).find('span').find('i').addClass('fas fa-chevron-down');

             }
             else {
                 $(this).find('span').find('i').removeClass('fas fa-chevron-down');
                 $(this).find('span').find('i') .addClass('fas fa-chevron-right');

             }

            $(a).nextUntil('tr.header').slideToggle(600);


});
   
        
     </script>
</asp:Content>