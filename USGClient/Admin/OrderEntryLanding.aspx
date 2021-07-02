<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="OrderEntryLanding.aspx.cs" Inherits="USGClient.Admin.OrderEntryLanding" %>


<%@ Register Src="~/Controls/AdminDetails.ascx" TagPrefix="uc1" TagName="AdminDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <uc1:AdminDetails runat="server" ID="AdminDetails" />
    <div class="card mb-3">
        <div class="card-header">
            <img id="logo" runat="server" class="LogoSize" /><span class="card-title"> Order Entry</span>
            <div style="float: right;" class="card-title">
            </div>
        </div>
        <div class="card-body bg-white">
            <table class="table table-bordered table-striped" cellspacing="0">
                <tbody>
                    <tr></tr>
                    <tr>
                        <td class="tblWidth">Job Number: </td>
                        <td>
                            <asp:DropDownList ID="ddljob" runat="server" AutoPostBack="True"
                                AppendDataBoundItems="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" CssClass="form-control">
                            </asp:DropDownList></td>
                        <td>Job Name: </td>
                        <td>
                            <asp:TextBox ID="txtJobName" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td>
                            <asp:LinkButton ID="lnkUpdateUserInfo" runat="server" CssClass="btn btn-dark" Text="Copy Entire Order" data-toggle="modal" data-target="#exampleModal"></asp:LinkButton>
                        </td>
                    </tr>

                </tbody>
            </table>
            <asp:Label runat="server" ID="lblMessage"></asp:Label>
        </div>
        <div class="card-body bg-white">
            <div class="table-responsive">
                <table cellspacing="6">
                    <tbody>
                        <tr>
                            <td style="padding: 30px;">
                                <asp:LinkButton ID="lnkJobDetails" runat="server" CssClass="btn btn-dark" Text="Job Details" OnClick="lnkJobDetailsInfo_Click"></asp:LinkButton>
                            </td>
                           <td style="padding: 30px;">
                               <asp:LinkButton ID="lnkOrderDetails" runat="server" CssClass="btn btn-dark" Text="Order Details" OnClick="lnkOrderDetailsInfo_Click"></asp:LinkButton>
                            </td>
                           <td style="padding: 30px;">
                               <asp:LinkButton ID="lnkOrderEntry" runat="server" CssClass="btn btn-dark" Text="Order Entry Reports" OnClick="lnkOrderEntryInfo_Click"></asp:LinkButton>
                            </td>
                           <td style="padding: 30px;">
                               <asp:DropDownList ID="ddlShipping" runat="server" AutoPostBack="True"   OnSelectedIndexChanged="ddlShipping_SelectedIndexChanged" CssClass="form-control">
                                   <asp:ListItem Value="0">Select Shipping Report</asp:ListItem>
                                    <asp:ListItem Value="1">Shipping TOS</asp:ListItem>
                                    <asp:ListItem Value="2">Packing Slips</asp:ListItem>
                                   <asp:ListItem Value="3">Print Labels</asp:ListItem>
                            </asp:DropDownList>
                               <%--<asp:LinkButton ID="lnkShipping" runat="server" CssClass="btn btn-dark" Text="Shipping Report" OnClick="lnkShippingInfo_Click"></asp:LinkButton>--%>
                            </td>
                           <td style="padding: 30px;">
                               <asp:DropDownList ID="ddlProduction" runat="server" AutoPostBack="True"   OnSelectedIndexChanged="ddlProduction_SelectedIndexChanged" CssClass="form-control">
                                        <asp:ListItem Value="0">Select Production Report</asp:ListItem>
                                        <asp:ListItem Value="1">Production TOS</asp:ListItem>
                                        
                               </asp:DropDownList>
                               <%--<asp:LinkButton ID="lnkProduction" runat="server" CssClass="btn btn-dark" Text="Production Report" OnClick="lnkProductionInfo_Click"></asp:LinkButton>--%>
                            </td>
                           <td style="padding: 30px;">
                               <asp:DropDownList ID="ddlAccount" runat="server" AutoPostBack="True"   OnSelectedIndexChanged="ddlAccount_SelectedIndexChanged" CssClass="form-control">
                                    <asp:ListItem Value="0">Select Accounting Report</asp:ListItem>
                                    <asp:ListItem Value="1">Priced TOS</asp:ListItem>
                                    <asp:ListItem Value="2">Priced Packing</asp:ListItem>
                               </asp:DropDownList>
                               <%--<asp:LinkButton ID="lnkAccount" runat="server" CssClass="btn btn-dark" Text="Accounting Report" OnClick="lnkAccountInfo_Click"></asp:LinkButton>--%>
                            </td>
                               
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
        <div class="card-body bg-white">
            <table class="table table-bordered table-striped" id="dataTable1" width="100%">
                <asp:Label runat="server" ID="lblmessage1"></asp:Label>

                <thead>
                    <tr>
                        <td>
                            <asp:RadioButtonList ID="rbActive" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                <asp:ListItem Value="True">Promo</asp:ListItem>
                                <asp:ListItem Value="False">Sign Type</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control"></asp:TextBox></td>


                        <td>Ship Date From:</td>
                        <td>
                            <asp:TextBox ID="txtFromDate" TabIndex="3" Style="width: 150px" runat="server" CssClass="form-control"></asp:TextBox></td>
                        <td>Ship Date To:</td>
                        <td>
                            <asp:TextBox ID="txtToDate" TabIndex="3" Style="width: 150px" runat="server" CssClass="form-control"></asp:TextBox></td>


                        <td>
                            <asp:LinkButton ID="lnkSearch" CssClass="btn btn-dark" runat="server" Text="Search" OnClick="btnSearch_Click" /></td>
                        <td>
                            <asp:LinkButton ID="lnkClear" CssClass="btn btn-dark" runat="server" Text="Clear" OnClick="btnClear_Click" /></td>

                    </tr>
                </thead>
            </table>
        </div>


        <div class="card-body bg-white" runat="server" id="joborderGrid" visible="false">
            <div class="table-responsive">
                <table class="table table-bordered table-striped" id="dataTable2" width="100%">
                    <asp:Label runat="server" ID="lblmessage2"></asp:Label>

                    <thead>
                        <tr>
                            <th>Job #</th>
                            <th>Job Name</th>
                            <th>Promotion</th>
                            <th>Sign Type</th>
                            <th>Ship Date</th>
                            <th>Details</th>

                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="rptJobOrder">
                            <ItemTemplate>
                                <div class="test">
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" ID="lblJobID" Text='<%# Eval("JobType")+"-"+Eval("JobID") %>'></asp:Label></td>
                                        <td>
                                            <asp:Label runat="server" ID="lblPromotion" Text='<%# Eval("Description") %>'></asp:Label></td>
                                        <td>
                                            <asp:Label runat="server" ID="lblPromotionMemo" Text='<%# Eval("Promotion") %>'></asp:Label></td>
                                        <td>
                                            <asp:Label runat="server" ID="lblSignType" Text='<%# Eval("SignType") %>'></asp:Label></td>
                                        <td>
                                            <asp:Label runat="server" ID="lblShipDate" Text='<%# Eval("shipDate") %>'></asp:Label></td>


                                        <td><a href='OrderEntryDetails.aspx?CID=<%=Request.QueryString["CID"]%>&JID=<%# Eval("JobIDCount") %>&JOID=<%# Eval("JobOrderID") %>'>Details</a></td>

                                    </tr>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">List Of Jobs</h5>
                    <button class="close" type="button" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                </div>
                <table class="table table-bordered table-striped" cellspacing="0">
                    <tr></tr>
                    <tr>
                        <td class="tblWidth">Job Number: </td>
                        <td>
                            <asp:DropDownList ID="ddlActivejob" runat="server" CssClass="form-control"></asp:DropDownList></td>
                    </tr>


                </table>
                <div class="modal-footer">
                    <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancel</button>
                    <asp:LinkButton runat="server" OnClientClick="return confirm('Are you sure you want to copy the entire order for this job?');" ID="lnkLogout" CssClass="btn btn-primary" Text="Save" OnClick="lnkCopyOrderInfo_Click"></asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">

    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script>
        $(document).ready(function () {
            //var div = document.getElementsByClassName('content-footer');
            //div.style.minHeight = "0rem";
            document.getElementById('ContentFooter').style.minHeight = "0px";

        });


        $(function () {
            $("#<%=txtFromDate.ClientID%>").datepicker({
                showOn: "button",
                buttonImage: "https://jqueryui.com/resources/demos/datepicker/images/calendar.gif",
                buttonImageOnly: true,
                buttonText: "Select date",
            });
        });

        $(function () {
            $("#<%=txtToDate.ClientID%>").datepicker({
                showOn: "button",
                buttonImage: "https://jqueryui.com/resources/demos/datepicker/images/calendar.gif",
                buttonImageOnly: true,
                buttonText: "Select date"

            })
        });

        $('#dataTable2').DataTable({
            "order": []
        });

        $('#dataTable2').each(function () {

            var row = $(this).find('tr');
            var table = $('#dataTable2').DataTable();

            var oddcolor = "#ffffff";
            var evencolor = "#EEE";
            var color = evencolor;
            // row[0].style.backgroundColor = color;
            for (var i = 0; i < row.length; i++) {
                a = table.row(i).data()[0];
                var b = a.replace(/<span[^/>]*>/g, "").replace("</span>", "")

                if (b == "") {
                    row[(i + 1)].style.backgroundColor = color;
                }
                else {
                    if (color == "#ffffff") {
                        var color = evencolor;

                    }
                    else {
                        var color = oddcolor;

                    }
                    row[(i + 1)].style.backgroundColor = color;
                }
            }
        });
        //let myElements = document.getElementsByClassName("content-footer");
        ////myElements.style.minHeight = "0rem";

    </script>

</asp:Content>
