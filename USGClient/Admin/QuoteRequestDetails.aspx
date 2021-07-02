<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="QuoteRequestDetails.aspx.cs" Inherits="USGClient.Admin.QuoteRequestDetails" %>

<%@ Register Src="~/Controls/AdminDetails.ascx" TagPrefix="uc1" TagName="AdminDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <uc1:AdminDetails runat="server" ID="AdminDetails" />
        <div class="card mb-3">
        <div class="card-header">
          <img id="logo" runat="server" class="LogoSize"/>
                        <span class="card-title">REQUEST FOR QUOTE</span>

<%--            <span class="bold" style="font-size:35px;text-align:center"> REQUEST FOR QUOTE </span>--%>
                        <div class="float-right"> 
            
                <asp:LinkButton runat="server" ID="btnSave" CommandName="Update"  class="btn btn-dark" OnClick="btnSendEmail_Click"> Send Pricing To Client</asp:LinkButton>
                <asp:LinkButton class="btn btn-dark" runat="server" OnClick="btnFinalize_Click" >Finalize Quote</asp:LinkButton>
            </div>

<%--            <div  style="text-align:center"><span class="bold" style="font-size:35px;text-align:center"> REQUEST FOR QUOTE </span></div>--%>
            <%-- <div class="row">
                 <div class="col-lg-4"> </div>
                 <div class="col-lg-4">
                   <div class="form-group row" >
                       <div class="float-right"></div>
                     <Label for="staticDate" class="col-sm-6 col-form-label" style="font-size:18px">Need Date: </Label>
                     <div class="col-sm-5 ">
                        <asp:TextBox ID="txtNeedDate" class="col-sm-4"   runat="server" CssClass="form-control" TabIndex="1"></asp:TextBox>  
                     </div>
                       </div>
                   </div>
                <div class="col-lg-3">  </div>--%>
            </div>
        
            <div class="card-body bg-white" >
            <div class="table-responsive">
                        <asp:Table id="RequestTable" runat="server" class="table table-bordered table-striped"  style="width: 100%" >
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
                                    <asp:TableCell runat="server" colspan="1" style="width:100px">Update      </asp:TableCell>

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
                                   <asp:TableCell ><asp:LinkButton ID="lnkUpdateRequestInfo1" runat="server"  TabIndex="10" Text="Update" CommandName="Update" OnClick="lnkUpdateRequestInfo_Click"></asp:LinkButton></asp:TableCell>
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
                                 <asp:TableCell runat="server"><asp:LinkButton ID="lnkUpdateRequestInfo2" runat="server"  TabIndex="10" Text="Update" CommandName="Update" OnClick="lnkUpdateRequestInfo_Click"></asp:LinkButton></asp:TableCell>

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
                                    <asp:TableCell runat="server"><asp:LinkButton ID="lnkUpdateRequestInfo3" runat="server"  TabIndex="10" Text="Update" CommandName="Update" OnClick="lnkUpdateRequestInfo_Click"></asp:LinkButton></asp:TableCell>


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
                                    <asp:TableCell runat="server"><asp:LinkButton ID="lnkUpdateRequestInfo4" runat="server"  TabIndex="10" Text="Update" CommandName="Update" OnClick="lnkUpdateRequestInfo_Click"></asp:LinkButton></asp:TableCell>

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
                                   <asp:TableCell runat="server"><asp:LinkButton ID="lnkUpdateRequestInfo5" runat="server"  TabIndex="10" Text="Update" CommandName="Update" OnClick="lnkUpdateRequestInfo_Click"></asp:LinkButton></asp:TableCell>


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
                                   <asp:TableCell runat="server"><asp:LinkButton ID="lnkUpdateRequestInfo6" runat="server"  TabIndex="10" Text="Update" CommandName="Update" OnClick="lnkUpdateRequestInfo_Click"></asp:LinkButton></asp:TableCell>

                                     
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
                                   <asp:TableCell runat="server"><asp:LinkButton ID="lnkUpdateRequestInfo7" runat="server"  TabIndex="10" Text="Update" CommandName="Update"  OnClick="lnkUpdateRequestInfo_Click"></asp:LinkButton></asp:TableCell>

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
                                   <asp:TableCell runat="server"><asp:LinkButton ID="lnkUpdateRequestInfo8" runat="server"  TabIndex="10" Text="Update" CommandName="Update"  OnClick="lnkUpdateRequestInfo_Click"></asp:LinkButton></asp:TableCell>

                                     </asp:TableRow>
                                
                                 
                                
<%--                                 <asp:TableRow> 
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
             
        </div>
        </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
