<%@ Page Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="SignTypeSize.aspx.cs" Inherits="USGClient.Admin.SignTypeSize" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
        .table td, .table th {
            vertical-align: middle;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="card mb-3">
         <div class="card-header">
            <img id="logo" runat="server" class="LogoSize"/><span class="card-title"> Sign Type Size</span>&nbsp;&nbsp;&nbsp;
      <div class="float-right"><i class="fa fa-user-circle"></i>&nbsp;<%=Session["Name"]%> </div>
            <asp:Label runat="server" ID="lblMessage"></asp:Label>
        </div>
        <div class="card-body bg-white">
            <div class="table-responsive">
                <table class="table table-bordered table-striped" cellspacing="0">
                    <tbody>
                        <tr>
                            <td>Sign Type SizeID:
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblSignTypeSizeID"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Sign Type Size:
                            </td>
                            <td>
                                <asp:TextBox ID="txtSignTypeSize" runat="server" CssClass="form-control"></asp:TextBox>
                            </td>
                    </tbody>
                </table>
                <asp:LinkButton ID="lnkUpdateSignTypeSizeInfo" runat="server" CssClass="btn btn-dark" Text="Update" OnClick="lnkUpdateSignTypeSizeInfo_Click"></asp:LinkButton>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content runat="server" ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3">
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
