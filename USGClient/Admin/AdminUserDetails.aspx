<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="AdminUserDetails.aspx.cs" Inherits="USGClient.Admin.AdminUserDetails1" %>

<%--<%@ Register Src="~/Controls/AdministratorMenu.ascx" TagPrefix="uc1" TagName="AdministratorMenu" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<%--    <uc1:AdministratorMenu runat="server" id="AdministratorMenu" />--%>
    <div class="card AdministratorMenu-3">
        <div class="card-header">
            <i class="fa fa-table "></i> <span class="card-title"> User Details</span>&nbsp;&nbsp;&nbsp;
      <div class="float-right card-title"><i class="fa fa-user-circle"></i>&nbsp;<%=Session["Name"]%> </div>
            <asp:Label runat="server" ID="lblMessage"></asp:Label>
        </div>
        <div class="card-body bg-white" >
            <div class="table-responsive">
                <table class="table table-bordered table-striped" cellspacing="0">
                    <tbody>
                        <tr >
                            <td class="tblWidth">User ID:
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblUserID"></asp:Label>
                            </td>
                        </tr>
                        <tr >
                            <td>Approver First Name:
                            </td>
                            <td>
                                <asp:TextBox ID="txtApproverFirstName" runat="server" CssClass="form-control"></asp:TextBox>
                            </td>
                        </tr>
                        <tr >
                            <td>Approver Last Name:
                            </td>
                            <td>
                                <asp:TextBox ID="txtApproverLastName" runat="server" CssClass="form-control"></asp:TextBox>
                            </td>
                        </tr>
                        <tr >
                            <td>Email Address:
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmailAddress" runat="server" CssClass="form-control"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Active:
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rbActive" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Value="True">Yes</asp:ListItem>
                                    <asp:ListItem Value="False">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr >
                           
                            <td>User Roles:
                            </td>
                            <td  runat="server" class="rolesDiv">
                                <asp:CheckBoxList ID="chkRoles" RepeatLayout="Flow" RepeatDirection="Horizontal" runat="server">

                                </asp:CheckBoxList>
                                <asp:PlaceHolder ID="chkRolesPanel"    runat="server"></asp:PlaceHolder>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <asp:LinkButton ID="lnkUpdateUserInfo" runat="server" CssClass="btn btn-dark" Text="Update" OnClick="lnkUpdateUserInfo_Click"></asp:LinkButton>
            </div>
        </div>
    </div>
    <%--<script src="https://code.jquery.com/jquery-1.12.4.min.js"></script>
    <script type="text/javascript">
        $(function () {
        $('input[type="checkbox"]').click(function(){
            if ($(this).is(":checked")) {
                var input = $(this).attr('id');
                alert(input);
               // $('#'+input).attr('checked','checked');
                
            } else {
                var input = $(this).attr('id');
                alert(input)
               // $('#'+input).attr('checked','checked');
            }
        });
    });
</script>--%>
</asp:Content>
