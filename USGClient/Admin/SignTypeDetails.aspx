<%@ Page Language="C#"  MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="SignTypeDetails.aspx.cs" Inherits="USGClient.SignTypeDetails" %>

<%@ Register Src="~/Controls/AdminDetails.ascx" TagPrefix="uc1" TagName="AdminDetails" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <uc1:AdminDetails runat="server" ID="AdminDetails" />
    <div class="card mb-3">
         <div class="card-header">
            <img id="logo" runat="server" class="LogoSize"/><span class="card-title"> Sign Type Details</span>&nbsp;&nbsp;&nbsp;
            <asp:Label runat="server" ID="lblMessage"></asp:Label>
        </div>
        <div class="card-body bg-white" >
            <div class="table-responsive">
                <table class="table table-bordered table-striped" cellspacing="0">
                    <tbody>
                        <tr>
                            <td>Sign Type ID: </td>
                            <td>
                                <asp:Label runat="server" ID="lblSignTypeID" TabIndex="0"></asp:Label>
                            </td>
                            <td>Materials:</td>
                            <td><asp:DropDownList ID="ddlmaterials" runat="server" CssClass="form-control" TabIndex="5"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td>Sign Type: </td>
                            <td>
                                <asp:TextBox ID="txtSignType" runat="server" CssClass="form-control" TabIndex="1"></asp:TextBox>
                            </td>
                           <td>Finishings 1:</td>
                             <td><asp:DropDownList ID="ddlFinishings" runat="server" CssClass="form-control" TabIndex="6"> </asp:DropDownList></td>
                        </tr>
                           
                        <tr>
                            <td>Production Notes:</td>
                            <td><asp:TextBox ID="txtProdNotes" runat="server" CssClass="form-control" TabIndex="1"></asp:TextBox></td>
                             <td>Finishings 2:</td>
                             <td><asp:DropDownList ID="ddlFinishings2" runat="server" CssClass="form-control" TabIndex="7"> </asp:DropDownList></td>
                        </tr>
                        
                        <tr>
                            <td>Price:</td>
                            <td><asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" TabIndex="2"></asp:TextBox></td>
                             <td>Hardware:</td>
                            <td><asp:DropDownList ID="ddlHardware" runat="server" CssClass="form-control" TabIndex="8"></asp:DropDownList></td> 
                            
                        </tr>
                        <tr>
                             <td>Sign Type Family:</td>
                             <td><asp:DropDownList ID="ddlSTFamily" runat="server" CssClass="form-control" TabIndex="3"> </asp:DropDownList></td>
                           <td>Laminant:</td>
                            <td><asp:DropDownList ID="ddlLaminateItem" runat="server" CssClass="form-control" TabIndex="9"></asp:DropDownList>
                                    <asp:RadioButtonList ID="rbLaminantType" runat="server" TabIndex="10" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Value="1">Top</asp:ListItem>
                                    <asp:ListItem Value="2">Bottom</asp:ListItem>
                                    <asp:ListItem Value="3">Encapsulate</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                         <tr>
                            <td>Sides : </td>
                            <td>
                                <asp:RadioButtonList ID="rbNoOfSides" TabIndex="17" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem  Value="1">1</asp:ListItem>
                                    <asp:ListItem  Value="2">2</asp:ListItem>
                                </asp:RadioButtonList>

<%--                                <asp:TextBox ID="txtSides" runat="server" CssClass="form-control" TabIndex="4"></asp:TextBox>--%>
                            </td>
                           <td>Active :</td>
                             <td><asp:RadioButtonList ID="rbActive" runat="server" TabIndex="11" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Value="True">True</asp:ListItem>
                                    <asp:ListItem Value="False">False</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                    </tbody>
                </table>
                <asp:LinkButton ID="lnkUpdateSignTypeInfo" runat="server" CssClass="btn btn-dark" TabIndex="12" Text="Update" OnClick="lnkUpdateSignTypeInfo_Click"></asp:LinkButton>
                <asp:Button CssClass="btn btn-dark" ID="BacktoJobs" TabIndex="13" runat="server" Text="Back" OnClientClick="JavaScript:window.history.back(1);return false;"/>          

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
