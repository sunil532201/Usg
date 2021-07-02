<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="AdminLog.aspx.cs" Inherits="USGClient.Admin.AdminLog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="card mb-3">
                <div class="card-header">
                    <i class="fa fa-table "></i><span class="card-title">Admin Log </span>
                </div>
                <div class="card-body bg-white">
                    <br />
                    <div>
                        <table class="table table-bordered table-striped" id="dataTable">
                            <thead>
                                <tr>
                                    <th>Created Date</th>
                                    <th>Admin FirstName</th>
                                    <th>Admin LastName</th>
                                    <th>Admin LogType</th>
                                    <th>Change Details</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="rptAdministratorLog" >
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Convert.ToDateTime(Eval("CreateDate")).ToString("MM/dd/yyyy") %></td>
                                            <td><%# Eval("AdminFirstName")%></td>
                                            <td><%# Eval("AdminLastName")%></td>
                                            <td><%# Eval("AdminLogType")%></td>
                                            <td><%# Eval("ChangeDetails")%></td>
                                           </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
                <br />
            </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <script>
       $(document).ready(function () {
           
            $('#dataTable').DataTable({
            });
        });
    </script>
</asp:Content>
