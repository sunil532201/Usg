<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master"  AutoEventWireup="true" CodeBehind="InventoryItemDetails.aspx.cs" Inherits="USGClient.Admin.InventoryItemDetails" %>
<%@ Register Src="~/Controls/AdminDetails.ascx" TagPrefix="uc1" TagName="AdminDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
   <uc1:AdminDetails runat="server" visible="false" ID="AdminDetails" />

    <div class="card-header">
                  <img id="logo" runat="server" class="LogoSize"/>
          <span class="card-title"> Inventory Item Details </span>&nbsp;&nbsp;&nbsp;
                      <asp:Label runat="server" ID="lblMessage" ></asp:Label>
        </div>

        <div class="card-body bg-white" >
             <div class="table-responsive">
                <table class="table table-bordered table-striped">
                    <tbody>
                        <tr>
                            <td>Inventory Item ID : </td>
                            <td><asp:Label runat="server" ID="lblInventoryItemID" TabIndex="0"></asp:Label></td>
                             <td>Quantity On Hand:</td>
                            <td>
                                <asp:TextBox  ID="txtQuantityOnHand" TabIndex="4" CssClass="form-control" runat="server" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Sign Type: </td>
                                <td>
                                 <asp:DropDownList ID="ddlCustomerSignTypes" TabIndex="1" runat="server" CssClass="form-control"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredCustomerSignTypes" runat="server" ControlToValidate="ddlCustomerSignTypes" Display="Dynamic" ErrorMessage="Please select sign type."   
                                ForeColor="Red"></asp:RequiredFieldValidator>

                          </td>
                            
                           <td>Number Of Sides :</td>
                            <td>   
                                <asp:RadioButtonList ID="rbNoOfSides" TabIndex="5" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem  Value="1">1</asp:ListItem>
                                    <asp:ListItem  Value="2">2</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                           <td>Current Image:</td>
                           <td> <img runat="server" style='max-width:150px;' alt="none" id="logoImg" src="" /></td>

                            <td>Promotion :</td>
                            <td><asp:TextBox ID="txtPromotion" TabIndex="6" runat="server" CssClass="form-control"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Upload Image :</td>
                            <td> <input class="form-control"  type="file" id="imgFile"  runat="server" TabIndex="2"/></td>

                            <td>ReorderPoint : </td>
                            <td><asp:TextBox ID="txtReorderPoint" TabIndex="7" runat="server" CssClass="form-control"></asp:TextBox> </td>
                        </tr>

                        <tr>
                            <td>Active :</td>
                             <td><asp:RadioButtonList ID="rbActive" runat="server" TabIndex="3" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Value="True">True</asp:ListItem>
                                    <asp:ListItem Value="False">False</asp:ListItem>
                                </asp:RadioButtonList></td>

                            <td>Max Order Quantity  : </td>
                            <td><asp:TextBox ID="txtMaxOrderQuantity" TabIndex="8" runat="server" CssClass="form-control"></asp:TextBox> </td>
                        </tr>
                       
                    </tbody>
                </table>

                <asp:LinkButton ID="lnkUpdateInventoryItemDetails" TabIndex="9" runat="server" CssClass="btn btn-dark" OnClick="lnkUpdateInventoryItem_Click" Text="Update"></asp:LinkButton>
                <asp:Button CssClass="btn btn-dark" ID="BacktoInventoryItems" TabIndex="10" runat="server" Text="Back" OnClick="BacktoInventoryItems_Click"/>          

            </div>
             
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
   
  <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script>

    </script>
</asp:Content>

