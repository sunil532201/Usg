<%@ Page Language="C#" MasterPageFile="~/MasterPages/ClientPage.Master" EnableViewState="true" AutoEventWireup="true" CodeBehind="RequestQuote.aspx.cs" Inherits="USGClient.ClientPortal.RequestQuote" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageTitle" runat="server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadCrumbs" runat="server"></asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphMainContent" runat="server">
     <div class="card mb-3 pb-30" id="QuotesList" runat="server" visible="false">
        <div class="card-header">
            <i class="fa fa-table " ></i><span class="card-title"> Quotes List</span>
              <div  style="float: right;" class="card-title">
                    <div style="float:left; padding-right: 15px;">
                        <asp:Button CssClass="btn btn-dark" ID="BacktoStores" runat="server" Text="Request a Quote" TabIndex="17" OnClick="BacktoForm_Click"/>
                   </div> 
              </div>
        </div>
        <div class="card-body bg-white" >
          <div class="table-responsive">
              <table class="table table-bordered table-striped" id="dataTable" width="100%" >
                  <thead>
                      <tr>
                          <th>Quote Number</th>
                          <th>Request On</th>
                          <th>Requested By</th>
                          <th>Items </th>
                          <th>Status </th>
                          <th>Details</th>
                      </tr>
                  </thead>
                  <tbody>
                      <asp:Repeater runat="server" ID="rptRequestQuote">
                          <ItemTemplate>
                              <tr>
                                  <td> <%# Eval("QuoteRequestID") %></td>
                                  <td> <%# Eval("CreateDate") %></td>
                                  <td> <%# Eval("CustomerUserName") %></td>
                                  <td> <%# Eval("ItemCount") %></td>
                                  <td> <%# Eval("Status") %></td>
                                  <td><a href='RequestQuoteDetails.aspx?QID=<%# Eval("QuoteRequestID") %>'>Details</a></td>

                              </tr>
                          </ItemTemplate>
                      </asp:Repeater>
                  </tbody>
              </table>
            </div>
        </div>
    </div>



    <div class="card mb-3" id="RequestForm" runat="server" visible="false">
        <div class="card-header" style="text-align:center"  >
             <span class="bold" style="font-size:35px"> REQUEST FOR QUOTE </span>
            </br></br>
            <label id="lblmessage" runat="server"></label>
       </div>

        <div class="card-body bg-white" >
            <div class="table-responsive">
                        <asp:Table id="RequestTable" runat="server" class="table table-bordered table-striped"  style="width: 100%" >
<%--                            <asp:Table runant="server" Id="RequestQuote" class="table table-bordered table-striped"  style="width: 100%">--%>

                                <asp:TableRow runat="server">
<%--                                    <asp:TableCell runat="server" colspan="1" style="width:15px;text-align:left">Item</asp:TableCell>
                                    <asp:TableCell runat="server" colspan="1" style="width:100px">Description        </asp:TableCell>--%>
                                    <asp:TableCell runat="server" colspan="1" style="width:100px">Sign Type             </asp:TableCell>
                                    <asp:TableCell runat="server" colspan="1" style="width:100px">Size (WxH) Inches     </asp:TableCell>
                                    <asp:TableCell runat="server" colspan="1" style="width:100px"># of sides            </asp:TableCell>
                                    <asp:TableCell runat="server" colspan="1" style="width:100px">Material              </asp:TableCell>
                                    <asp:TableCell runat="server" colspan="1" style="width:100px">Laminant On Top       </asp:TableCell>
                                    <asp:TableCell runat="server" colspan="1" style="width:100px">Laminant On Bottom    </asp:TableCell>
                                    <asp:TableCell runat="server" colspan="1" style="width:100px">Finishing             </asp:TableCell>
                                    <asp:TableCell runat="server" colspan="1" style="width:100px">Quantity              </asp:TableCell>
                                    <asp:TableCell runat="server" colspan="1" style="width:100px">Application Of Sign   </asp:TableCell>
                                    <asp:TableCell runat="server" colspan="1" style="width:100px">Additional Notes      </asp:TableCell>

                                </asp:TableRow>
                               <asp:TableRow runat="server"> 

                                    <asp:TableCell runat="server"><asp:TextBox ID="txtSignType1"      runat="server" CssClass="form-control" TabIndex="1"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtSize1"          runat="server" CssClass="form-control" TabIndex="2"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server">
                                    
                                        <asp:RadioButtonList ID="rbNoOfSides1" TabIndex="3" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                            <asp:ListItem  Value="1">1</asp:ListItem>
                                            <asp:ListItem  Value="2">2</asp:ListItem>
                                        </asp:RadioButtonList>

<%--                                        <asp:TextBox ID="txtSide1"         runat="server" CssClass="form-control" TabIndex="4"></asp:TextBox> --%>
                                       </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtMaterial1"      runat="server" CssClass="form-control" TabIndex="4"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtLaminantOnTop1"      runat="server" CssClass="form-control" TabIndex="5"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtLaminantOnBottom1"      runat="server" CssClass="form-control" TabIndex="6"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtFinishig1"          runat="server" CssClass="form-control" TabIndex="7"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtQuantity1"          runat="server" CssClass="form-control" TabIndex="8"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtApplicationOfSign1"      runat="server" CssClass="form-control" TabIndex="9"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtAdditionalNotes1"      runat="server" CssClass="form-control" TabIndex="10"></asp:TextBox> </asp:TableCell>


                                </asp:TableRow>
                                <asp:TableRow>
                                    
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtSignType2"      runat="server" CssClass="form-control" TabIndex="11"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtSize2"          runat="server" CssClass="form-control" TabIndex="12"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"> 
                                        <asp:RadioButtonList ID="rbNoOfSides2" TabIndex="13" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                            <asp:ListItem  Value="1">1</asp:ListItem>
                                            <asp:ListItem  Value="2">2</asp:ListItem>
                                        </asp:RadioButtonList> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtMaterial2"      runat="server" CssClass="form-control" TabIndex="14"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtLaminantOnTop2"      runat="server" CssClass="form-control" TabIndex="15"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtLaminantOnBottom2"      runat="server" CssClass="form-control" TabIndex="16"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtFinishig2"          runat="server" CssClass="form-control" TabIndex="17"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtQuantity2"          runat="server" CssClass="form-control" TabIndex="18"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtApplicationOfSign2"      runat="server" CssClass="form-control" TabIndex="19"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtAdditionalNotes2"      runat="server" CssClass="form-control" TabIndex="20"></asp:TextBox> </asp:TableCell>

                                </asp:TableRow>

                                 <asp:TableRow> 
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtSignType3"      runat="server" CssClass="form-control" TabIndex="21"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtSize3"          runat="server" CssClass="form-control" TabIndex="22"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server">
                                     <asp:RadioButtonList ID="rbNoOfSides3" TabIndex="23" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                            <asp:ListItem  Value="1">1</asp:ListItem>
                                            <asp:ListItem  Value="2">2</asp:ListItem>
                                        </asp:RadioButtonList>

                                    </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtMaterial3"      runat="server" CssClass="form-control" TabIndex="24"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtLaminantOnTop3"      runat="server" CssClass="form-control" TabIndex="25"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtLaminantOnBottom3"      runat="server" CssClass="form-control" TabIndex="26"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtFinishig3"          runat="server" CssClass="form-control" TabIndex="27"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtQuantity3"          runat="server" CssClass="form-control" TabIndex="28"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtApplicationOfSign3"      runat="server" CssClass="form-control" TabIndex="29"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtAdditionalNotes3"      runat="server" CssClass="form-control" TabIndex="30"></asp:TextBox> </asp:TableCell>

                                </asp:TableRow>
                                 <asp:TableRow> 
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtSignType4"      runat="server" CssClass="form-control" TabIndex="31"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtSize4"          runat="server" CssClass="form-control" TabIndex="32"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server">
                                     <asp:RadioButtonList ID="rbNoOfSides4" TabIndex="33" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                            <asp:ListItem  Value="1">1</asp:ListItem>
                                            <asp:ListItem  Value="2">2</asp:ListItem>
                                        </asp:RadioButtonList> 

                                    </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtMaterial4"      runat="server" CssClass="form-control" TabIndex="34"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtLaminantOnTop4"      runat="server" CssClass="form-control" TabIndex="35"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtLaminantOnBottom4"      runat="server" CssClass="form-control" TabIndex="36"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtFinishig4"          runat="server" CssClass="form-control" TabIndex="37"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtQuantity4"          runat="server" CssClass="form-control" TabIndex="38"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtApplicationOfSign4"      runat="server" CssClass="form-control" TabIndex="39"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtAdditionalNotes4"      runat="server" CssClass="form-control" TabIndex="40"></asp:TextBox> </asp:TableCell>
                                    

                                </asp:TableRow>
                                 <asp:TableRow> 
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtSignType5"      runat="server" CssClass="form-control" TabIndex="41"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtSize5"          runat="server" CssClass="form-control" TabIndex="42"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"> <asp:RadioButtonList ID="rbNoOfSides5" TabIndex="43" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                            <asp:ListItem  Value="1">1</asp:ListItem>
                                            <asp:ListItem  Value="2">2</asp:ListItem>
                                        </asp:RadioButtonList>

                                    </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtMaterial5"      runat="server" CssClass="form-control" TabIndex="44"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtLaminantOnTop5"      runat="server" CssClass="form-control" TabIndex="45"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtLaminantOnBottom25"      runat="server" CssClass="form-control" TabIndex="46"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtFinishig5"          runat="server" CssClass="form-control" TabIndex="47"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtQuantity5"          runat="server" CssClass="form-control" TabIndex="48"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtApplicationOfSign5"      runat="server" CssClass="form-control" TabIndex="49"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtAdditionalNotes5"      runat="server" CssClass="form-control" TabIndex="50"></asp:TextBox> </asp:TableCell>

                                </asp:TableRow>
                                 <asp:TableRow> 
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtSignType6"      runat="server" CssClass="form-control" TabIndex="51"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtSize6"          runat="server" CssClass="form-control" TabIndex="52"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server">
                                         <asp:RadioButtonList ID="rbNoOfSides6" TabIndex="53" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                            <asp:ListItem  Value="1">1</asp:ListItem>
                                            <asp:ListItem  Value="2">2</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtMaterial6"      runat="server" CssClass="form-control" TabIndex="54"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtLaminantOnTop6"      runat="server" CssClass="form-control" TabIndex="55"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtLaminantOnBottom6"      runat="server" CssClass="form-control" TabIndex="56"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtFinishig6"          runat="server" CssClass="form-control" TabIndex="57"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtQuantity6"          runat="server" CssClass="form-control" TabIndex="58"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtApplicationOfSign6"      runat="server" CssClass="form-control" TabIndex="59"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtAdditionalNotes6"      runat="server" CssClass="form-control" TabIndex="60"></asp:TextBox> </asp:TableCell>

                                     </asp:TableRow>
                                 <asp:TableRow> 
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtSignType7"      runat="server" CssClass="form-control" TabIndex="61"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtSize7"          runat="server" CssClass="form-control" TabIndex="62"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"> <asp:RadioButtonList ID="rbNoOfSides7" TabIndex="63" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                            <asp:ListItem  Value="1">1</asp:ListItem>
                                            <asp:ListItem  Value="2">2</asp:ListItem>
                                        </asp:RadioButtonList> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtMaterial7"      runat="server" CssClass="form-control" TabIndex="64"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtLaminantOnTop7"      runat="server" CssClass="form-control" TabIndex="65"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtLaminantOnBottom7"      runat="server" CssClass="form-control" TabIndex="66"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtFinishig7"          runat="server" CssClass="form-control" TabIndex="67"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtQuantity7"          runat="server" CssClass="form-control" TabIndex="68"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtApplicationOfSign7"      runat="server" CssClass="form-control" TabIndex="69"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtAdditionalNotes7"      runat="server" CssClass="form-control" TabIndex="70"></asp:TextBox> </asp:TableCell>
                                     </asp:TableRow>
                                
                                 <asp:TableRow> 
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtSignType8"      runat="server" CssClass="form-control" TabIndex="71"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtSize8"          runat="server" CssClass="form-control" TabIndex="72"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"> <asp:RadioButtonList ID="rbNoOfSides8" TabIndex="73" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                            <asp:ListItem  Value="1">1</asp:ListItem>
                                            <asp:ListItem  Value="2">2</asp:ListItem>
                                        </asp:RadioButtonList> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtMaterial8"      runat="server" CssClass="form-control" TabIndex="74"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtLaminantOnTop8"      runat="server" CssClass="form-control" TabIndex="75"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtLaminantOnBottom8"      runat="server" CssClass="form-control" TabIndex="76"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtFinishig8"          runat="server" CssClass="form-control" TabIndex="77"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtQuantity8"          runat="server" CssClass="form-control" TabIndex="78"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtApplicationOfSign8"      runat="server" CssClass="form-control" TabIndex="79"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtAdditionalNotes8"      runat="server" CssClass="form-control" TabIndex="80"></asp:TextBox> </asp:TableCell>
                                     </asp:TableRow>
<%--                                
                                 <asp:TableRow> 
                                    <asp:TableCell><div style="float:left;" >I :</div>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:TableCell> 
                                      
                                    <asp:TableCell><asp:TextBox ID="txtDescription9"   runat="server" CssClass="form-control" TabIndex="46"></asp:TextBox></asp:TableCell>
                                    <asp:TableCell><asp:TextBox ID="txtSignType9"  runat="server" CssClass="form-control" TabIndex="47"></asp:TextBox></asp:TableCell>
                                    <asp:TableCell><asp:TextBox ID="txtSize9"  runat="server" CssClass="form-control" TabIndex="48"></asp:TextBox></asp:TableCell>
                                    <asp:TableCell><asp:TextBox ID="txtSide9"  runat="server" CssClass="form-control" TabIndex="49"></asp:TextBox></asp:TableCell>
                                    <asp:TableCell><asp:TextBox ID="txtQty9"   runat="server" CssClass="form-control" TabIndex="50" ></asp:TextBox></asp:TableCell>
                                    <asp:TableCell><asp:TextBox ID="txtMaterial9"   runat="server" CssClass="form-control" TabIndex="51"></asp:TextBox></asp:TableCell>
                                    <asp:TableCell><asp:TextBox ID="txtColor9"   runat="server" CssClass="form-control" TabIndex="52"></asp:TextBox></asp:TableCell>
                                    <asp:TableCell><asp:TextBox ID="txtFinishig9"   runat="server" CssClass="form-control" TabIndex="53"></asp:TextBox></asp:TableCell>
                                    <asp:TableCell><asp:TextBox ID="txtShipTo9"   runat="server" CssClass="form-control" TabIndex="54"></asp:TextBox></asp:TableCell>

                                     </asp:TableRow>
                                
                                 <asp:TableRow> 
                                    <asp:TableCell><div style="float:left;" >J :</div>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:TableCell> 
                                      
                                    <asp:TableCell><asp:TextBox ID="txtDescription10"   runat="server" CssClass="form-control" TabIndex="46"></asp:TextBox></asp:TableCell>
                                    <asp:TableCell><asp:TextBox ID="txtSignType10"  runat="server" CssClass="form-control" TabIndex="47"></asp:TextBox></asp:TableCell>
                                    <asp:TableCell><asp:TextBox ID="txtSize10"  runat="server" CssClass="form-control" TabIndex="48"></asp:TextBox></asp:TableCell>
                                    <asp:TableCell><asp:TextBox ID="txtSide10"  runat="server" CssClass="form-control" TabIndex="49"></asp:TextBox></asp:TableCell>
                                    <asp:TableCell><asp:TextBox ID="txtQty10"   runat="server" CssClass="form-control" TabIndex="50" ></asp:TextBox></asp:TableCell>
                                    <asp:TableCell><asp:TextBox ID="txtMaterial10"   runat="server" CssClass="form-control" TabIndex="51"></asp:TextBox></asp:TableCell>
                                    <asp:TableCell><asp:TextBox ID="txtColor10"   runat="server" CssClass="form-control" TabIndex="52"></asp:TextBox></asp:TableCell>
                                    <asp:TableCell><asp:TextBox ID="txtFinishig10"   runat="server" CssClass="form-control" TabIndex="53"></asp:TextBox></asp:TableCell>
                                    <asp:TableCell><asp:TextBox ID="txtShipTo10"   runat="server" CssClass="form-control" TabIndex="54"></asp:TextBox></asp:TableCell>

                                     </asp:TableRow>
                                

                                <asp:TableRow>
                                    <asp:TableCell colspan="2">Where is this graphic going to be displayed?</asp:TableCell>
                                    <asp:TableCell colspan="8" ><asp:TextBox ID="txtGrapics" TextMode="MultiLine" runat="server" CssClass="form-control" TabIndex="55"></asp:TextBox></asp:TableCell>

                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell colspan="2">Special Instructions:</asp:TableCell>
                                    <asp:TableCell colspan="8"><asp:TextBox ID="txtInstruction"  TextMode="MultiLine"  runat="server" CssClass="form-control" TabIndex="56"></asp:TextBox></asp:TableCell>

                                </asp:TableRow>--%>

                            </asp:Table>
            </div>
                   <asp:Button CssClass="btn btn-dark" ID="BacktoMaterialItem" TabIndex="81" runat="server" Text="Submit" OnClick="lnkSaveRequestItemDetails_Click"/>

        </div>

    </div>

  <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>

    <script>
<%--        $(function () {
            $("#<%=txtNeedDate.ClientID%>").datepicker({
         showOn: "button",
         buttonImage: "https://jqueryui.com/resources/demos/datepicker/images/calendar.gif",
         buttonImageOnly: true,
         buttonText: "Select date"
     });
 });--%>
    </script>
</asp:Content>
