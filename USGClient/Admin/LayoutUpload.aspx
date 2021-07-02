<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="LayoutUpload.aspx.cs" Inherits="USGClient.Admin.LayoutUpload" %>

<%--<%@ Register Src="~/Controls/AdminClientDetailsControl.ascx" TagPrefix="uc1" TagName="AdminClientDetailsControl" %>--%>
<%@ Register Src="~/Controls/AdminDetails.ascx" TagPrefix="uc1" TagName="AdminDetails" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <uc1:AdminDetails runat="server" ID="AdminDetails" />
    <%--<uc1:AdminClientDetailsControl runat="server" ID="AdminClientDetailsControl" />--%>
    <div class="card mb-3">
        <div class="card-header">
            <i class="fa fa-table"></i> <span class="card-title">Upload Layouts</span>&nbsp;&nbsp;&nbsp;
            <div class="float-right card-title">
            <i class="fa fa-user-circle"></i>&nbsp;
                <%=Session["Name"]%>
            </div>
            <asp:Label runat="server" ID="lblMessage"></asp:Label>
        </div>
        <div class="card-body" style="background-color: white !important">
            <div class="table-responsive">
                <table class="table table-bordered table-striped" cellspacing="0">
                    <tbody>
                        <%--<tr>
                        <td>Customer Users: </td>
                            <td>
                                <asp:DropDownList ID="ddlCustomerUsers" runat="server" CssClass="form-control"></asp:DropDownList>
                            </td>
                        </tr>--%>
                        <tr>
                            <td>Layout:
                            </td>
                            <td>
                                <asp:FileUpload ID="FuImage" multiple="multiple" runat="server" CssClass="form-control" />
                            </td>
                        </tr>
                        <tr>
                            <td>Optional Note:</td>
                            <td>
                                <asp:TextBox runat="server" ID="txtComment" CssClass="form-control"></asp:TextBox>
                    </tbody>
                </table>
                <asp:LinkButton ID="lnkSaveFile" Text="Create" runat="server" CssClass="btn btn-dark" OnClick="lnkSaveFile_Click" />
            </div>
        </div>
    </div>


</asp:Content>
