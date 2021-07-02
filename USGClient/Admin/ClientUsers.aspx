<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="ClientUsers.aspx.cs" Inherits="USGClient.Admin.ClientUsers" %>

<%@ Register Src="~/Controls/AdminDetails.ascx" TagPrefix="uc1" TagName="AdminDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
        .table td, .table th {
            vertical-align: middle;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <%--<li class="breadcrumb-item"><a href="Clients.aspx">Clients</a> </li>
    <li class="breadcrumb-item active">Client Details</li>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:HiddenField ID="hfProjectID" runat="server"/>
    <uc1:AdminDetails runat="server" ID="AdminDetails" />
    <div class="card mb-3" runat="server" id="divClientUsers">
        <div class="card-header">
            <img id="logo" runat="server" class="LogoSize"/><span class="card-title">Client Users</span>
            <div  style="float: right;" class="card-title">
      <div style="float:left; padding-right: 15px;"><a class="btn btn-dark" href="ClientUserDetails.aspx?CID=<%=Request.QueryString["CID"] %>&CUID=<%=Request.QueryString["CUID"] %>" id="toggleNavColor">Add User</a></div>
        
                 </div>  
        </div>
        <div class="card-body bg-white" >
            <div class="table-responsive">
                <table class="table table-bordered table-striped" id="dataTable" width="100%" >
                    <thead>
                        <tr>
                            <th>User ID</th>
                            <th>First Name</th>
                            <th>Last Name</th>
                            <th>Email Address</th>
                            <th>Active</th>
                            <th>Edit</th>
                            <th>  Impersonate  </th>                            

                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="rptList">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("CustomerUserID") %></td>
                                    <td><%# Eval("ApproverFirstName")  %></td>
                                    <td><%# Eval("ApproverLastName")  %></td>
                                    <td><%# Eval("EmailAddress") %></td>
                                    <td><%# ParseActive(Eval("Active")) %></td>
                                    <td><a href='ClientUserDetails.aspx?CID=<%# Eval("CustomerID") %>&CUID=<%# Eval("CustomerUserID") %>' style="color:#172C55">DETAILS</a></td>                                   
                                    <td><asp:LinkButton runat="server" ID="LnkLogin"  OnClick="btnLogin_Click"  CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "EmailAddress")%>'>Impersonate</asp:LinkButton></td>

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
            $('#dataTable2').DataTable({
                "order": [[1, "asc"]]
            });
        });
    </script>

    <script>
        // Delete All Checked Checkboxes Script
$(function () {
        $("#tblViewFiles [id*=chkHeader]").click(function () {
            if ($(this).is(":checked")) {
                $("#tblViewFiles [id*=chkRow]").attr("checked", "checked");
            } else {
                $("#tblViewFiles [id*=chkRow]").removeAttr("checked");
            }
        });
        $("#tblViewFiles [id*=chkRow]").click(function () {
            if ($("#tblViewFiles [id*=chkRow]").length == $("#tblViewFiles [id*=chkRow]:checked").length) {
                $("#tblViewFiles [id*=chkHeader]").attr("checked", "checked");
            } else {
                $("#tblViewFiles [id*=chkHeader]").removeAttr("checked");
            }
        });
        });


        function getProjectID(input) {
            $("#<%=hfProjectID.ClientID%>").val(input.dataset.bind); // Get ProductID  On Clicking ADD Files Button  
            <%--alert($("#<%=hfProjectID.ClientID%>").val())--%>
        }
        
    </script>

</asp:Content>
