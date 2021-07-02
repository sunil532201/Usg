<%@  Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master"AutoEventWireup="true" CodeBehind="OrderEntry.aspx.cs" Inherits="USGClient.Admin.OrderEntry" %>
<%@ Register Src="~/Controls/AdminDetails.ascx" TagPrefix="uc1" TagName="AdminDetails" %>

<%@ Register Src="~/Controls/JobMenuControl.ascx" TagPrefix="uc1" TagName="JobMenuControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <%-- <li class="breadcrumb-item"><a href="Clients.aspx">Clients</a> </li>
    <li class="breadcrumb-item active">Client Details</li>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:HiddenField ID="hfProjectID" runat="server"/>
    <uc1:AdminDetails runat="server" ID="AdminDetails" />
    <uc1:JobMenuControl runat="server" ID="JobMenuControl" />

    <div class="card mb-3">
         <div class="card-header">
            <img id="logo" runat="server" class="LogoSize"/><span class="card-title"> Order Entry</span>&nbsp;&nbsp;&nbsp;
            <asp:Label runat="server" ID="lblMessage"></asp:Label>
        </div>
        <div class="card-body bg-white" >
            <div class="table-responsive">
                <table class="table table-bordered table-striped" cellspacing="0">
                    <tbody>
                        <tr>
                            <td >Job Number:</td>
                            <td><asp:Label runat="server" ID="lblJobOrderID"  TabIndex="0"></asp:Label></td>
                            <td>Job Name: </td>
                            <td><asp:Label ID="lblJobName" runat="server" ></asp:Label>

                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>

    <div class="card mb-3" runat="server" id="div2">
           <div class="card-header">
            <i class="fa fa-table"></i><span class="card-title"> Order Entry List</span>
            </div>
</div>
    <div class="card-body bg-white" >
            <div class="table-responsive">
    <div>
        <table>
            <tbody>
                <tr>
                    <td>Promotion:</td>
                    <td><asp:TextBox ID="txtPromotion" runat="server" CssClass="form-control" TabIndex="1" /></td>
                    <td >Production Memo:</td>
                    <td><asp:TextBox ID="txtProductionMemo" CssClass="form-control" runat="server" TabIndex="2" /></td>

                    <td>Promotion Memo:</td>
                    <td><asp:TextBox ID="txtPromotionMemo"  CssClass="form-control" runat="server" TabIndex="3"/></td>
                    <td> <asp:LinkButton ID="lnkUpdateJobOrderInfo" runat="server" CssClass="btn btn-dark" TabIndex="4" Text="Add" OnClick="lnkUpdateJobOrderInfo_Click"></asp:LinkButton></td>
                </tr>
                
            </tbody>
           
        </table>
    </div>
                </div>
        </div>
        
        <div class="card-body bg-white" >
            <div class="table-responsive">
                <table class="table table-bordered table-striped" id="dataTable2" width="100%">
                     <thead>
                        <tr>
                            <th  style="width: 65px !important;">Promo #</th>
                            <th>Promotion</th>
                            <th>Promotion Memo</th>
                            <th>Production Memo</th>
                            <th>Update</th>
                            <th>Delete</th>
                            <th>Details</th>

                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="rptJobOrder">
                            <ItemTemplate>
                                <tr>

                                    <td><asp:TextBox CssClass="form-control" runat="server" ID="txtPromoNumber"    Text='<%# Eval("PromoNumber") %>'></asp:TextBox></td> 
                                    <td><asp:TextBox CssClass="form-control" runat="server" ID="txtPromotion"      Text='<%# Eval("Promotion") %>'></asp:TextBox></td> 
                                    <td><asp:TextBox CssClass="form-control" runat="server" ID="txtPromotionMemo"  Text='<%# Eval("PromotionMemo") %>'></asp:TextBox></td> 
                                    <td><asp:TextBox CssClass="form-control" runat="server" ID="txtProductionMemo" Text='<%# Eval("ProductionMemo") %>'></asp:TextBox></td>

                                    
                                    <td><asp:LinkButton runat="server" ID="btnUpdate" OnClick="btnUpdate_Click"   CommandName="Update" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "JobOrderID ") %>'>Update</asp:LinkButton></td>
                                    <td><asp:LinkButton runat="server" ID="btnDelete"  OnClick="btnDelete_Click"  CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "JobOrderID")%>'>Delete</asp:LinkButton></td>
                                    <td><a href='OrderEntryDetails.aspx?CID=<%=Request.QueryString["CID"]%>&JID=<%# Eval("JobID") %>&JOID=<%# Eval("JobOrderID") %>'>Details</a></td>

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
        // Call the dataTables jQuery plugin
        $(document).ready(function () {
           
            $('#dataTable2').DataTable({
                "order": [[1, "asc"]]
            });
        });
        $(document).ready(function () {
            var div = document.getElementById('cusName');
            div.setAttribute('style', 'display:none');
        });
    </script>
   
</asp:Content>
