<%@ Page Language="C#"  MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="StoreLevelOrderItems.aspx.cs" Inherits="USGClient.Admin.StoreLevelOrderItems" %>

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
            <img id="logo" runat="server" class="LogoSize"/><span class="card-title"> Store Level Order Items</span>&nbsp;&nbsp;&nbsp;
            <div class="float-right"><i class="fa fa-user-circle"></i>&nbsp;<%=Session["CustomerName"]%> </div>
        </div>
         <asp:Label runat="server" ID="lblMessage"></asp:Label>
         <div class="card-body bg-white" >
            <div class="table-responsive">
                <table class="table table-bordered table-striped" cellspacing="0">
                    <tbody>
                        <tr>
                        <td>Order Item ID: </td>
                            <td>
                                <asp:Label runat="server" ID="lblOrderItemID"></asp:Label></td>
                            <td>Order Reason: </td>
                            <td>
                                <asp:TextBox ID="txtOrderReason" runat="server" CssClass="form-control"></asp:TextBox></td>
                            </tr>
                       <tr>
                            <td>Sign Type: </td>
                            <td>
                                <asp:DropDownList ID="ddlSignType" runat="server"  onchange = "PopulateSignTypeSize();" CssClass="form-control" >
                                    <asp:ListItem Text = "Please select" Value = "0"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                           <td>Quantity: </td>
                            <td>
                                <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control"></asp:TextBox></td>
                           </tr>
                        <tr>
                           <%-- <td>Sign Type Size: </td>
                            <td>
                                <asp:DropDownList ID="ddlSignTypeSize" runat="server" CssClass="form-control" ></asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlSignTypeSize" 
                            InitialValue="0" ErrorMessage="Type required" ></asp:RequiredFieldValidator>
                            </td>--%>
                            
                            <td>Ship To Store Number: </td>
                            <td>

<asp:ListBox ID="StoreNumberList" runat="server"  SelectionMode="Multiple">
<%--    <asp:ListItem Text="Mango" Value="1" />
    <asp:ListItem Text="Apple" Value="2" />
    <asp:ListItem Text="Banana" Value="3" />
    <asp:ListItem Text="Guava" Value="4" />
    <asp:ListItem Text="Orange" Value="5" />--%>
</asp:ListBox>
                            </td>
<%--                                <asp:TextBox ID="txtShipToStoreNumber" runat="server"  CssClass="form-control"></asp:TextBox>--%>
<%--                                 <div class="col-md-6">

                                <div class="dropdown">
                                  <button class="btn btn-default dropdown-toggle" type="button" 
                                          Id="ddlShips" required="" runat="server" data-toggle="dropdown" 
                                          aria-haspopup="true" aria-expanded="true">
                                    <i class="glyphicon glyphicon-cog"></i>
                                    <span class="caret">Ship To Store Number</span>
                                  </button>
                                    <ul class="dropdown-menu checkbox-menu allow-focus" required="" runat="server" aria-labelledby="dropdownMenu1">
                                         <asp:Repeater runat="server" ID="rptStores">
                                            <ItemTemplate>
                                                <li>
                                                    <asp:HiddenField ID="hfValue" runat="server" Value='<%# Eval("StoreNumber") %>'/>
                                                   <asp:CheckBox  type="checkbox" ID="chkStores" runat="server" checked='<%# Eval("IsChecked") %>'/>  <%# Eval("StoreNumber") %>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                     </ul>
                            </div>
                       </div>--%>
                            </td>
                            <td></td><td></td>
                           </tr>
                        <tr>
                            <td>Promotion: </td>
                            <td>
                                <asp:TextBox ID="txtPromotion" runat="server" CssClass="form-control"></asp:TextBox></td>
                            <td></td><td></td>
                        </tr>
                        <tr>
                        </tr>
                    </tbody>
                </table>
                <asp:LinkButton ID="lnkUpdateOrderItemInfo" runat="server" CssClass="btn btn-dark" Text="Update" OnClick="lnkUpdateOrderItemInfo_Click"></asp:LinkButton>
                <asp:LinkButton ID="lnkDeleteOrder" runat="server" CssClass="btn btn-dark" Text="Delete" OnClick="lnkDeleteOrder_Click"></asp:LinkButton>

            </div>
        </div>

       
    </div>
</asp:Content>
<asp:Content runat="server" ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3">
    
       <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.0/jquery.min.js"></script>
   <script src="../js/jquery.sumoselect.min.js"></script>
   <link href="../css/sumoselect.css" rel="stylesheet">
       <link href="../css/sumoselect.min.css" rel="stylesheet">

    <script type="text/javascript">
        $(document).ready(function () {
            $(<%=StoreNumberList.ClientID%>).SumoSelect();
        });
    </script>

    <script>
        // Call the dataTables jQuery plugin
        $(document).ready(function () {
            $.fn.dataTable.moment('M/D/YYYY');
            $('#dataTable').DataTable({
                "order": [[2, "asc"]]
            });
        });
    </script>
    <%--<script>
   
        function PopulateSignTypeSize() {

            $("#<%=ddlSignTypeSize.ClientID%>").attr("disabled", "disabled");
            if ($('#<%=ddlSignType.ClientID%>').val() == "0") {
                $('#<%=ddlSignTypeSize.ClientID %>').empty().append('<option selected="selected" value="0">Please select</option>');
            }
            else {
                $('#<%=ddlSignTypeSize.ClientID %>').empty().append('<option selected="selected" value="0">Loading....</option>');
                $.ajax({
                    type: "POST",
                    url: 'StoreLevelOrderItems.aspx/PopulateSignTypeSize',
                    data: '{SignTypeID: ' + $('#<%=ddlSignType.ClientID%>').val() + '}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnPopulateSignTypeSize,
            failure: function (response) {
                alert(response.d);
            }

        });
            }


        }

        function OnPopulateSignTypeSize(response) {
            console.log(response);
            PopulateControl(response.d, $("#<%=ddlSignTypeSize.ClientID %>"));
        }

        function PopulateControl(list, control) {
            console.log(control);
            console.log(list);
            if (list.length > 0) {
                control.removeAttr("disabled");
                control.empty().append('<option selected="selected" value="0">Please select</option>');
                for (var i = 0; i < list.length; i++) {

                    control.append($("<option></option>").val(list[i]['SignTypeSizeID']).html(list[i]['SignTypeSize']));
                }
            }
            else {
                control.empty().append('<option selected="selected" value="0">Not available<option>');
            }
        }
</script>--%>
</asp:Content>
