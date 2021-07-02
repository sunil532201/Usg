<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="QuoteRequestList.aspx.cs" Inherits="USGClient.Admin.QuoteRequestList" %>
<%@ Register Src="~/Controls/AdminDetails.ascx" TagPrefix="uc1" TagName="AdminDetails" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
      <uc1:AdminDetails runat="server" visible="false" ID="AdminDetails" />

    <div class="card mb-3" runat="server" id="divClientUsers">
        <div class="card-header">
            <img id="logo" runat="server" class="LogoSize"/>
            <span class="card-title">Quotes Request</span>
           
        </div>
        <div class="card-body bg-white" >
            <div class="table-responsive">
                <table class="table table-bordered table-striped" id="dataTable" width="100%" >
                    <thead>
                        <tr>
<%--                            <th>User ID</th>--%>
                            <th>First Name</th>
                            <th>Last Name</th>
                            <th>Request Date</th>
                            <th>Status</th>
                            <th>Details </th>                            

                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="rptList">
                            <ItemTemplate>
                                <tr>
<%--                                    <td><%# Eval("QuoteRequestID ") %></td>--%>
                                    <td><%# Eval("ApproverFirstName")  %></td>
                                    <td><%# Eval("ApproverLastName")  %></td>
                                    <td><%# Convert.ToDateTime(Eval("CreateDate ")).ToString("MM/dd/yyyy") %></td>
                                    <td><%# Eval("Status")  %></td>
                                    <td><a href='QuoteRequestDetails.aspx?CID=<%=Request.QueryString["CID"]%>&QID=<%# Eval("QuoteRequestID") %>' style="color:#172C55">DETAILS</a></td>                                   

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
            $.fn.dataTable.moment('M/D/YYYY');
            $('#dataTable').DataTable({
                "order": [[1, "asc"]]
            });
        });
    </script>


</asp:Content>
