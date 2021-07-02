<%@ Page Language="C#" MasterPageFile="~/MasterPages/ClientPage.Master" EnableViewState="true" AutoEventWireup="true" CodeBehind="RequestQuoteDetails.aspx.cs" Inherits="USGClient.ClientPortal.RequestQuoteDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageTitle" runat="server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadCrumbs" runat="server"></asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphMainContent" runat="server">

        <div class="card mb-3">
        <div class="card-header" style="text-align:center"  >
           
             <span class="bold" style="font-size:35px"> REQUEST FOR QUOTE </span>
            </div>
        
            <div class="card-body bg-white" >
            <div class="table-responsive">
                              <table class="table table-bordered table-striped" id="dataTable" width="100%" >
                  <thead>
                      <tr>
                          <th>Sign Type</th>
                          <th>Size (WxH) Inches</th>
                          <th># of sides </th>
                          <th>Material </th>
                          <th>Laminant On Top </th>
                          <th>Laminant On Bottom</th>
                          <th>Finishing</th>
                          <th>Quantity</th>
                          <th>Application Of Sign </th>
                          <th>Additional Notes</th>
                          <th>Price Per Piece </th>
<%--                          <th></th>--%>

                      </tr>
                  </thead>
                  <tbody>
                      <asp:Repeater runat="server" ID="rptRequestQuote">
                          <ItemTemplate>
                              <tr>
                                  <td> <%# Eval("SignType") %></td>
                                  <td> <%# Eval("Size") %></td>
                                  <td> <%# Eval("Sides") %></td>
                                  <td> <%# Eval("Material") %></td>
                                  <td> <%# Eval("LaminantTop") %></td>
                                  <td> <%# Eval("LaminantBottom") %></td>
                                  <td> <%# Eval("Finishing") %></td>
                                  <td> <%# Eval("Quantity") %></td>
                                  <td> <%# Eval("ApplicationOfSign") %></td>
                                  <td> <%# Eval("AdditionalNotes") %></td>
                                  <td> <%# Eval("Price") %></td>

                              </tr>
                          </ItemTemplate>
                      </asp:Repeater>
                  </tbody>
              </table>

<%--                        <asp:Table id="RequestTable" runat="server" class="table table-bordered table-striped"  style="width: 100%" >
                                <asp:TableRow runat="server">
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
                                    <asp:TableCell runat="server" colspan="1" style="width:100px">Price Per Piece   </asp:TableCell>

                                </asp:TableRow>
                               <asp:TableRow runat="server"> 
                                    <asp:TableCell ><asp:TextBox ID="txtSignType1" runat="server" CssClass="form-control" TabIndex="2"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell ><asp:TextBox ID="txtSize1"     runat="server" CssClass="form-control" TabIndex="3"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell >
                                    
                                        <asp:RadioButtonList ID="rbNoOfSides1" TabIndex="17" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                            <asp:ListItem  Value="1">1</asp:ListItem>
                                            <asp:ListItem  Value="2">2</asp:ListItem>
                                        </asp:RadioButtonList>

                                       </asp:TableCell>
                                    <asp:TableCell ><asp:TextBox ID="txtMaterial1"      runat="server" CssClass="form-control" TabIndex="6"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell ><asp:TextBox ID="txtLaminantOnTop1"      runat="server" CssClass="form-control" TabIndex="8"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell ><asp:TextBox ID="txtLaminantOnBottom1"      runat="server" CssClass="form-control" TabIndex="2"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell ><asp:TextBox ID="txtFinishig1"          runat="server" CssClass="form-control" TabIndex="3"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell ><asp:TextBox ID="txtQuantity1"          runat="server" CssClass="form-control" TabIndex="4"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell ><asp:TextBox ID="txtApplicationOfSign1"      runat="server" CssClass="form-control" TabIndex="6"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell ><asp:TextBox ID="txtAdditionalNotes1"      runat="server" CssClass="form-control" TabIndex="8"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell ><asp:TextBox ID="txtPricePerPiece1"      runat="server" CssClass="form-control" TabIndex="8"></asp:TextBox> </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtSignType2"      runat="server" CssClass="form-control" TabIndex="2"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtSize2"          runat="server" CssClass="form-control" TabIndex="3"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"> 
                                        <asp:RadioButtonList ID="rbNoOfSides2" TabIndex="17" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                            <asp:ListItem  Value="1">1</asp:ListItem>
                                            <asp:ListItem  Value="2">2</asp:ListItem>
                                        </asp:RadioButtonList> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtMaterial2"      runat="server" CssClass="form-control" TabIndex="6"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtLaminantOnTop2"      runat="server" CssClass="form-control" TabIndex="8"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtLaminantOnBottom2"      runat="server" CssClass="form-control" TabIndex="2"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtFinishig2"          runat="server" CssClass="form-control" TabIndex="3"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtQuantity2"          runat="server" CssClass="form-control" TabIndex="4"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtApplicationOfSign2"      runat="server" CssClass="form-control" TabIndex="6"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtAdditionalNotes2"      runat="server" CssClass="form-control" TabIndex="8"></asp:TextBox> </asp:TableCell>
                                   <asp:TableCell runat="server"><asp:TextBox ID="txtPricePerPiece2"      runat="server" CssClass="form-control" TabIndex="8"></asp:TextBox> </asp:TableCell>

                                </asp:TableRow>

                                 <asp:TableRow> 
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtSignType3"      runat="server" CssClass="form-control" TabIndex="2"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtSize3"          runat="server" CssClass="form-control" TabIndex="3"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server">
                                     <asp:RadioButtonList ID="rbNoOfSides3" TabIndex="17" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                            <asp:ListItem  Value="1">1</asp:ListItem>
                                            <asp:ListItem  Value="2">2</asp:ListItem>
                                        </asp:RadioButtonList>

                                    </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtMaterial3"      runat="server" CssClass="form-control" TabIndex="6"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtLaminantOnTop3"      runat="server" CssClass="form-control" TabIndex="8"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtLaminantOnBottom3"      runat="server" CssClass="form-control" TabIndex="2"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtFinishig3"          runat="server" CssClass="form-control" TabIndex="3"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtQuantity3"          runat="server" CssClass="form-control" TabIndex="4"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtApplicationOfSign3"      runat="server" CssClass="form-control" TabIndex="6"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtAdditionalNotes3"      runat="server" CssClass="form-control" TabIndex="8"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtPricePerPiece3"      runat="server" CssClass="form-control" TabIndex="8"></asp:TextBox> </asp:TableCell>


                                </asp:TableRow>
                                 <asp:TableRow> 
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtSignType4"      runat="server" CssClass="form-control" TabIndex="2"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtSize4"          runat="server" CssClass="form-control" TabIndex="3"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server">
                                     <asp:RadioButtonList ID="rbNoOfSides4" TabIndex="17" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                            <asp:ListItem  Value="1">1</asp:ListItem>
                                            <asp:ListItem  Value="2">2</asp:ListItem>
                                        </asp:RadioButtonList> 

                                    </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtMaterial4"      runat="server" CssClass="form-control" TabIndex="6"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtLaminantOnTop4"      runat="server" CssClass="form-control" TabIndex="8"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtLaminantOnBottom4"      runat="server" CssClass="form-control" TabIndex="2"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtFinishig4"          runat="server" CssClass="form-control" TabIndex="3"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtQuantity4"          runat="server" CssClass="form-control" TabIndex="4"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtApplicationOfSign4"      runat="server" CssClass="form-control" TabIndex="6"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtAdditionalNotes4"      runat="server" CssClass="form-control" TabIndex="8"></asp:TextBox> </asp:TableCell>
                                   <asp:TableCell runat="server"><asp:TextBox ID="txtPricePerPiece4"  runat="server" CssClass="form-control" TabIndex="8"></asp:TextBox> </asp:TableCell>

                                </asp:TableRow>
                                 <asp:TableRow> 
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtSignType5"      runat="server" CssClass="form-control" TabIndex="2"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtSize5"          runat="server" CssClass="form-control" TabIndex="3"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"> <asp:RadioButtonList ID="rbNoOfSides5" TabIndex="17" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                            <asp:ListItem  Value="1">1</asp:ListItem>
                                            <asp:ListItem  Value="2">2</asp:ListItem>
                                        </asp:RadioButtonList>

                                    </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtMaterial5"      runat="server" CssClass="form-control" TabIndex="6"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtLaminantOnTop5"      runat="server" CssClass="form-control" TabIndex="8"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtLaminantOnBottom5"      runat="server" CssClass="form-control" TabIndex="2"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtFinishig5"          runat="server" CssClass="form-control" TabIndex="3"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtQuantity5"          runat="server" CssClass="form-control" TabIndex="4"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtApplicationOfSign5"      runat="server" CssClass="form-control" TabIndex="6"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtAdditionalNotes5"      runat="server" CssClass="form-control" TabIndex="8"></asp:TextBox> </asp:TableCell>
                                   <asp:TableCell runat="server"><asp:TextBox ID="txtPricePerPiece5"      runat="server" CssClass="form-control" TabIndex="8"></asp:TextBox> </asp:TableCell>


                                </asp:TableRow>
                                 <asp:TableRow> 
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtSignType6"      runat="server" CssClass="form-control" TabIndex="2"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtSize6"          runat="server" CssClass="form-control" TabIndex="3"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server">
                                         <asp:RadioButtonList ID="rbNoOfSides6" TabIndex="17" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                            <asp:ListItem  Value="1">1</asp:ListItem>
                                            <asp:ListItem  Value="2">2</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtMaterial6"      runat="server" CssClass="form-control" TabIndex="6"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtLaminantOnTop6"      runat="server" CssClass="form-control" TabIndex="8"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtLaminantOnBottom6"      runat="server" CssClass="form-control" TabIndex="2"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtFinishig6"          runat="server" CssClass="form-control" TabIndex="3"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtQuantity6"          runat="server" CssClass="form-control" TabIndex="4"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtApplicationOfSign6"      runat="server" CssClass="form-control" TabIndex="6"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtAdditionalNotes6"      runat="server" CssClass="form-control" TabIndex="8"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtPricePerPiece6"      runat="server" CssClass="form-control" TabIndex="8"></asp:TextBox> </asp:TableCell>

                                     
                                 </asp:TableRow>
                                 <asp:TableRow> 
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtSignType7"      runat="server" CssClass="form-control" TabIndex="2"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtSize7"          runat="server" CssClass="form-control" TabIndex="3"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"> <asp:RadioButtonList ID="rbNoOfSides7" TabIndex="17" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                            <asp:ListItem  Value="1">1</asp:ListItem>
                                            <asp:ListItem  Value="2">2</asp:ListItem>
                                        </asp:RadioButtonList> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtMaterial7"      runat="server" CssClass="form-control" TabIndex="6"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtLaminantOnTop7"      runat="server" CssClass="form-control" TabIndex="8"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtLaminantOnBottom7"      runat="server" CssClass="form-control" TabIndex="2"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtFinishig7"          runat="server" CssClass="form-control" TabIndex="3"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtQuantity7"          runat="server" CssClass="form-control" TabIndex="4"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtApplicationOfSign7"      runat="server" CssClass="form-control" TabIndex="6"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtAdditionalNotes7"      runat="server" CssClass="form-control" TabIndex="8"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtPricePerPiece7"      runat="server" CssClass="form-control" TabIndex="8"></asp:TextBox> </asp:TableCell>

                                     </asp:TableRow>
                                
                                 <asp:TableRow> 
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtSignType8"      runat="server" CssClass="form-control" TabIndex="2"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtSize8"          runat="server" CssClass="form-control" TabIndex="3"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"> <asp:RadioButtonList ID="rbNoOfSides8" TabIndex="17" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                            <asp:ListItem  Value="1">1</asp:ListItem>
                                            <asp:ListItem  Value="2">2</asp:ListItem>
                                        </asp:RadioButtonList> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtMaterial8"      runat="server" CssClass="form-control" TabIndex="6"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtLaminantOnTop8"      runat="server" CssClass="form-control" TabIndex="8"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtLaminantOnBottom8"      runat="server" CssClass="form-control" TabIndex="2"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtFinishig8"          runat="server" CssClass="form-control" TabIndex="3"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtQuantity8"          runat="server" CssClass="form-control" TabIndex="4"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtApplicationOfSign8"      runat="server" CssClass="form-control" TabIndex="6"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtAdditionalNotes8"      runat="server" CssClass="form-control" TabIndex="8"></asp:TextBox> </asp:TableCell>
                                    <asp:TableCell runat="server"><asp:TextBox ID="txtPricePerPiece8"      runat="server" CssClass="form-control" TabIndex="8"></asp:TextBox> </asp:TableCell>

                                     </asp:TableRow>
                            </asp:Table>--%>
            </div>
                                <asp:Button CssClass="btn btn-dark" ID="BacktoMaterialItem" runat="server" Text="Back" OnClick="lnkBackToQuotesList_Click"/>

        </div>
        </div>

  <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>

    <script>
    </script>
</asp:Content>
