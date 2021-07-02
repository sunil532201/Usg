<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MockupDisplayControl.ascx.cs" Inherits="USGClient.Controls.MockupDisplayControl" %>

<script runat="server">
    
   
</script>
<ul class="nav nav-pills">
    <li class="nav-item" runat="server">
        <asp:LinkButton runat="server" ID="Search" CssClass="nav-link navActive" OnClick="lnk_click" Visible="false">Search</asp:LinkButton>
    </li>
    <li class="nav-item" runat="server">
        <asp:LinkButton runat="server" ID="Pending" CssClass="nav-link" OnClick="lnk_click" Visible="false">Pending</asp:LinkButton>
    </li>
    <li class="nav-item" runat="server">
        <asp:LinkButton runat="server" ID="Approved" CssClass="nav-link" OnClick="lnk_click" Visible="false">Approved</asp:LinkButton>
    </li>
    <li class="nav-item" runat="server">
        <asp:LinkButton runat="server" ID="Archived" CssClass="nav-link" OnClick="lnk_click" Visible="false">Archived</asp:LinkButton>
    </li>
</ul>
<hr />
<br />


<asp:MultiView runat="server" ID="mvMockup">

    <asp:View runat="server" ID="SearchLayouts">
        <div class="card mb-3">
            <div class="card-header">
                <i class="fa fa-table "></i><span class="card-title">Layouts</span>
            </div>
            <div class="card-body">
                <br />
                <div class="row" runat="server" id="divSearch">
                    <div class="col-md-2">
                        <label for="ddlPromoMonth">Promo Month:</label><br />
                        <asp:DropDownList runat="server" ID="ddlPromoMonth" CssClass="form-control">
                            <asp:ListItem Text="MONTH" Value="0"></asp:ListItem>
                            <asp:ListItem Text="JAN" Value="1"></asp:ListItem>
                            <asp:ListItem Text="FEB" Value="2"></asp:ListItem>
                            <asp:ListItem Text="MAR" Value="3"></asp:ListItem>
                            <asp:ListItem Text="APR" Value="4"></asp:ListItem>
                            <asp:ListItem Text="MAY" Value="5"></asp:ListItem>
                            <asp:ListItem Text="JUN" Value="6"></asp:ListItem>
                            <asp:ListItem Text="JUL" Value="7"></asp:ListItem>
                            <asp:ListItem Text="AUG" Value="8"></asp:ListItem>
                            <asp:ListItem Text="SEP" Value="9"></asp:ListItem>
                            <asp:ListItem Text="OCT" Value="10"></asp:ListItem>
                            <asp:ListItem Text="NOV" Value="11"></asp:ListItem>
                            <asp:ListItem Text="DEC" Value="12"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-2">
                        <label for="ddlPromddlPromoYearoMonth">Promo Year:</label><br />
                        <asp:DropDownList runat="server" ID="ddlPromoYear" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-4">
                        <label for="txtPromotext">Title:</label><br />
                        <asp:TextBox runat="server" ID="txtPromotext" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <label for="btnSearch">&nbsp;</label><br />
                        <asp:LinkButton CssClass="btn btn-dark mr-xs mb-sm" Text="Search" runat="server" ID="lnkSearch" OnClick="lnkSearch_Click"></asp:LinkButton>
                        <asp:LinkButton CssClass="btn btn-secondary mr-xs mb-sm" Text="Upload to Azure" runat="server" Visible="false" ID="lnkUploadImagesAzure" OnClick="lnkUploadImagesAzure_Click"></asp:LinkButton>
                    </div>

                </div>
                <br />
                <div class="row">
                    <div >
                        <strong>
                            <asp:Literal runat="server" ID="Literal1" Text="&nbsp;"></asp:Literal></strong>
                    </div>
                    <%-- <div class="col-sm-6" style="text-align: right;">
                        <asp:Label runat="server" ID="Label1" EnableViewState="false"></asp:Label></div>
                </div>--%>
                    <div class="mockupContainer">
                        <div runat="server" id="div1" enableviewstate="false" class="lightbox mb-lg" data-plugin-options="{ 'delegate': 'a', 'type': 'image', 'gallery': { 'enabled': true} }">

                            <asp:Repeater runat="server" ID="rptSearch">
                                <ItemTemplate>
                                    <div class="col-sm-3 float-left">
                                        <div class="ImageContainer">
                                            <a class="img-thumbnail mb-xs mr-xs SelectImg" href='<%# GetURL(Eval("MockupNoteID"),Eval("MockupID"))%>'>
                                                <%# GetImage(Eval("MockupNoteID"), Eval("MockupID")) %>
                                            </a>
                                        </div>
                                        <div class="PromoDateContainer">
                                            <%#Eval("PromoMonth") + "-" + Eval("PromoYear") %>
                                        </div>
                                        <div class="MockNameContainer">
                                            <%#Eval("Title") %>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                    <%--  </div>--%>
                </div>
            </div>
        </div>
    </asp:View>

    <asp:View runat="server" ID="ApprovedLayouts">
        <div class="card mb-3">
            <div class="card-header">
                <i class="fa fa-table "></i><span class="card-title">Layouts</span>
            </div>
            <div class="card-body">
                <div class="row mb-20">
                    <div class="col-sm-6">
                        <strong>
                            <asp:Literal runat="server" ID="litMessage" Text="&nbsp;"></asp:Literal></strong>
                    </div>
                    <div class="col-sm-6 text-right">
                        <asp:Label runat="server" ID="lblCount" EnableViewState="false"></asp:Label>
                    </div>
                </div>
                <div class="mockupContainer" style="">
                    <div runat="server" id="divLightbox" enableviewstate="false" class="lightbox mb-lg" data-plugin-options="{ 'delegate': 'a', 'type': 'image', 'gallery': { 'enabled': true} }">

                        <asp:Repeater runat="server" ID="rptList">
                            <ItemTemplate>
                                <div class="col-sm-3 float-left">
                                    <div class="ImageContainer">
                                        <a class="img-thumbnail mb-xs mr-xs " href='<%# GetURL(Eval("MockupNoteID"),Eval("MockupID"))%>'> 
                                            <%# GetImage(Eval("MockupNoteID"), Eval("MockupID")) %>
                                        </a>
                                    </div>
                                    <div class="PromoDateContainer">
                                        <%#Eval("PromoMonth") + "-" + Eval("PromoYear") %>
                                    </div>
                                    <div class="MockNameContainer">
                                        <%#Eval("Title") %>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                <%--  </div>--%>
            </div>
        </div>
    </asp:View>


    <asp:View runat="server" ID="viewPending">
        <div class="card mb-3">
            <div class="card-header">
                <i class="fa fa-table "></i><span class="card-title">Pending Layouts</span>
                 <asp:Button class="btn btn-dark float-right"  ID="btnApprove" Text="Approve Selected Images" runat="server" OnClick="btnApprove_Click"/>
            </div>
            <div class="card-body">
                <ul style="list-style-type: disc;">
                    <li>Click on image below to approve or make changes to a layout.</li>
                    <li>To approve multiple images you have already reviewed click on the checkbox for each image and click the <strong>"Approve Selected Images"</strong> button.</li>
                    <li><b>NOTE:</b> Once you have approved a layout, you will be responsible for any reprints due to errors</li>
                </ul>
                <div class="row mb-20">
                    <div class="col-sm-6">
                        <strong>
                            <asp:Literal runat="server" ID="litPendingMessage" Text="&nbsp;"></asp:Literal></strong>
                    </div>
                    <div class="col-sm-6 text-right">
                        <asp:Label runat="server" ID="lblPendingCount" EnableViewState="false"></asp:Label>
                    </div>
                </div>
                <div class="mockupContainer">
                    
                    <div>
                        <div class="table-striped">
                            <asp:Repeater runat="server" ID="rptPending" OnItemCommand="rptPending_ItemCommand">
                                <ItemTemplate>
                                    
                                    <div class="col-sm-3 float-left">
                                        <div class="ImageContainer">
                                            <asp:CheckBox CssClass="float-right" type="checkbox" ID="chkPending" runat="server" /><asp:HiddenField ID="hfValue" runat="server" Value='<%# Eval("ImageUrl") %>' /><asp:HiddenField ID="hfNoteID" runat="server" Value='<%# Eval("MockupNoteID") %>' />
                                            <asp:ImageButton runat="server" CssClass="square-thumb" ID="ibtnImage" ImageUrl='<%# GetPendingImage(Eval("MockupNoteID"), Eval("MockupID")) %>' CommandName="Details" CommandArgument='<%#Eval("MockupNoteID") %>' />
                                        </div>
                                        <div class="PromoDateContainer">
                                            <%#Eval("PromoMonth") + "-" + Eval("PromoYear") %>
                                        </div>
                                        <div class="MockNameContainer">
                                            <%#Eval("Title") %>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:View>

    <asp:View runat="server" ID="viewDetails">
        <div class="card mb-3">
            <div class="card-header">
                <i class="fa fa-table "></i><span class="card-title">Pending Layouts</span>
            </div>
            <div class="card-body">
                <div class="row ">
                    <div class="col-sm-6">
                        <asp:TextBox runat="server" ID="txtMockupID" Visible="false"></asp:TextBox>
                        <asp:CheckBox ID="cbApproved" runat="server" Text="&nbsp;Layout Approved" CssClass="form-control" /><br />
                        <label for="txtNotes">Reject Reason:</label><br />
                        <asp:TextBox runat="server" ID="txtNotes" CssClass="form-control" TextMode="MultiLine" Rows="4"></asp:TextBox>
                        <div class="mt-5 mb-20">
                            <asp:Button runat="server" ID="btnAddNote" Text="Submit" CssClass="btn btn-dark mr-xs mb-sm" OnClick="btnAddNote_Click" />
                            <asp:Button runat="server" ID="btnReset" Text="Cancel" CssClass="btn btn-dark mr-xs mb-sm" OnClick="btnReset_Click" />
                        </div>
                        <div class="featured-box featured-box-primary">
                            <div class="box-content pre">
                                <asp:Repeater runat="server" ID="rptNotes">
                                    <ItemTemplate>
                                        <div class="text-xl-left">
                                            <strong><%# Eval("CreateDate","{0: MM/dd/yyyy}") %></strong><br />
                                            <strong>From <%# GetFrom(Eval("MockupNoteTypeID"),Eval("ApproverFirstName"),Eval("ApproverLastName"),Eval("EmailAddress"))  %>:</strong>
                                            <br />
                                            <%# Eval("Notes") %>
                                        </div>
                                    </ItemTemplate>
                                    <SeparatorTemplate>
                                        <hr />
                                    </SeparatorTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="lightbox mb-lg" data-plugin-options="{ 'delegate': 'a', 'type': 'image', 'gallery': { 'enabled': true} }">
                            <a runat="server" id="lnkPendingImage" class="img-thumbnail mb-xs mr-xs" href='#'>
                                <asp:Image runat="server" ID="EmailAttachment" CssClass="img-responsive EmailAttachment" />
                            </a>
                        </div>
                        <%--<asp:Repeater runat="server" ID="rptApprovedImages" >
                            <ItemTemplate>
                                <div class="col-sm-3 float-left">
                                    <div class="ImageContainer">
                                        <asp:ImageButton runat="server" CssClass="square-thumb" ID="ibtnImage" ImageUrl='<%# Eval("PendingImage") %>' />
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>--%>
                    </div>
                </div>
            </div>
        </div>

    </asp:View>

    
</asp:MultiView>
<script>
    $(function () {
        debugger
        $('#<%= btnApprove.ClientID %>').click(function (event) {
            if ($('input[type=checkbox]').is(":checked")) {
                return confirm('Did you review the layout for correct spelling, placement & design?  Once you have approved the layout, you will be responsible for any reprints due to errors.');
            }
            else {
                alert('No items selected.  You must first select items to be approved.');
                 event.preventDefault(); 
                
            }
        });
    });

</script>

