    <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="ClientDetails.aspx.cs" Inherits="USGClient.Admin.ClientDetails" %>

<%@ Register Src="~/Controls/AdminDetails.ascx" TagPrefix="uc1" TagName="AdminDetails" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <asp:HiddenField ID="hfProjectID" runat="server"/>
    <uc1:AdminDetails runat="server" ID="AdminDetails" />
 
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="Client" runat="server">
        <div class="card mb-3">
        <div class="card-header">
           <img id="logo" runat="server" class="LogoSize" /> <span class="card-title" style="font-size:20px"> Client Details </span>&nbsp;&nbsp;&nbsp;
            <asp:Label runat="server" ID="lblMessage" ></asp:Label>
        </div>
        <div class="card-body bg-white" >
            <div class="table-responsive">
                <table class="table table-bordered table-striped" cellspacing="0">
                    <tbody>
                        <tr>
                            <td>Client ID: </td>
                            <td><asp:Label runat="server" ID="lblCustomerID"  TabIndex="0"></asp:Label></td>
                            <td>Shipping ID: </td>
                            <td>
                               
                                <asp:TextBox ID="txtShippingID" runat="server" CssClass="form-control" TabIndex="6"> </asp:TextBox>  
                                <asp:RequiredFieldValidator ID="RequiredShippingID" runat="server" ControlToValidate="txtShippingID" Display="Dynamic" ErrorMessage="Please enter a Shipping ID"   
                                ForeColor="Red"></asp:RequiredFieldValidator>  
                            </td>
                            
                          
                        </tr>
                        <tr>
                            <td>Client Name: </td>
                            <td>
                                <asp:TextBox ID="txtClientName" runat="server" CssClass="form-control" TabIndex="1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredClientName" runat="server" ControlToValidate="txtClientName" Display="Dynamic" ErrorMessage="Please enter a Client Name"   
                                ForeColor="Red"></asp:RequiredFieldValidator>  
                            </td>

                            <td>Billing ID: </td>
                            <td>
                                <asp:TextBox ID="txtBillingID" runat="server" CssClass="form-control" TabIndex="7"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredBillingID" runat="server" ControlToValidate="txtBillingID" Display="Dynamic" ErrorMessage="Please enter a Billing ID"   
                                ForeColor="Red"></asp:RequiredFieldValidator>  
                            </td>
                           
                           
                        </tr>
                        <tr>
                            <td>Customer Status Type: </td>
                            <td>
                              <asp:DropDownList ID="ddlCustomerStatusType" runat="server" CssClass="form-control" TabIndex="1"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlCustomerStatusType" Display="Dynamic" ErrorMessage="Please select a Status Type"   
                                ForeColor="Red"></asp:RequiredFieldValidator>  
                            </td>
                            
                             <td>Billing Company: </td>
                            <td>
                                <asp:TextBox ID="txtBilling" runat="server" CssClass="form-control" TabIndex="8"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredBilling" runat="server" ControlToValidate="txtBilling" Display="Dynamic" ErrorMessage="Please enter a Billing"   
                                ForeColor="Red"></asp:RequiredFieldValidator>  
                            </td>
                            
                        </tr>
                        <tr>
                            <td>Terms:</td>
                              <td><asp:DropDownList ID="ddlTerms" runat="server" CssClass="form-control" TabIndex="2"></asp:DropDownList>

                                <asp:RequiredFieldValidator ID="RequiredTerms" runat="server" ControlToValidate="ddlTerms" Display="Dynamic" ErrorMessage="Please select terms"   
                                ForeColor="Red"></asp:RequiredFieldValidator>  
                            </td>
                            
                            <td>Billing First Name: </td>
                            <td>
                                <asp:TextBox ID="txtBillingFirstName" runat="server" CssClass="form-control" TabIndex="9"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredBillingFirstName" runat="server" ControlToValidate="txtBillingFirstName" Display="Dynamic" ErrorMessage="Please enter a Billing First Name"   
                                ForeColor="Red"></asp:RequiredFieldValidator>  
                            </td>
                            
                        </tr>
                        <tr>
                            <td>Account Rep: </td>
                            <td>
                                <asp:DropDownList ID="ddlAdministrators" runat="server" CssClass="form-control" TabIndex="3"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredAdministrators" runat="server" ControlToValidate="ddlAdministrators" Display="Dynamic" ErrorMessage="Please select a Account Rep"   
                                ForeColor="Red"></asp:RequiredFieldValidator>  
                            </td>
                            
                            <td>Billing Last Name: </td>
                            <td>
                                <asp:TextBox ID="txtBillingLastName" runat="server" CssClass="form-control" TabIndex="10"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredBillingLastName" runat="server" ControlToValidate="txtBillingLastName" Display="Dynamic" ErrorMessage="Please enter a Billing Last Name"   
                                ForeColor="Red"></asp:RequiredFieldValidator>  
                            </td>
                            
                           
                        </tr>
                        <tr>
                            <td>Current Logo:</td>
                            <td> <img runat="server" style="height:55px;width:55px;" alt="none" id="logoImg" src="" TabIndex="4" /></td>
                            <td>Billing Email Address: </td>
                            <td>
                                <asp:TextBox ID="txtBillingEmailAddress" TextType="email" runat="server" CssClass="form-control" TabIndex="11"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredBillingEmailAddress" runat="server" ControlToValidate="txtBillingEmailAddress" Display="Dynamic" ErrorMessage="Please enter a Billing Email Address"   
                                ForeColor="Red"></asp:RequiredFieldValidator>  
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtBillingEmailAddress" Display="Dynamic" ErrorMessage="Enter proper email format" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator> 
                            </td>
                            
                            
                        </tr>
                        <tr>
                            <td>Upload Logo:</td>
                            <td> <input class="form-control"  type="file" id="File1"  runat="server" TabIndex="5"/></td>
                            <td>Address Line 1: </td>
                            <td>
                                <asp:TextBox ID="txtAddressLine1" runat="server" CssClass="form-control" TabIndex="12"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredAddressLine1" runat="server" ControlToValidate="txtAddressLine1" Display="Dynamic" ErrorMessage="Please enter a Address Line1"   
                                ForeColor="Red"></asp:RequiredFieldValidator>  
                            </td>
                           
                        </tr>
                        <tr>
                             <td></td><td></td>
                            <td>Address Line 2: </td>
                            <td>
                                <asp:TextBox ID="txtAddressLine2" runat="server" CssClass="form-control" TabIndex="13"></asp:TextBox></td>
                            
                            
                        </tr>
                        <tr>
                            <td></td><td></td>
                            <td>City: </td>
                            <td>
                                <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" TabIndex="14" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredCity" runat="server" ControlToValidate="txtCity" Display="Dynamic" ErrorMessage="Please enter a City"   
                                ForeColor="Red"></asp:RequiredFieldValidator>  
                            </td>
                            
                            
                        </tr>
                        <tr>
                            <td></td><td></td>
                            <td>State: </td>
                            <td>
                                <asp:TextBox ID="txtState" runat="server" CssClass="form-control" TabIndex="15"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredState" runat="server" ControlToValidate="txtState" Display="Dynamic" ErrorMessage="Please enter a State"   
                                ForeColor="Red"></asp:RequiredFieldValidator>  
                            </td>
                           
                            
                        </tr>
                         <tr>
                            <td></td><td></td>
                              <td>Zip: </td>
                            <td>
                                <asp:TextBox ID="txtZip" runat="server" CssClass="form-control" TabIndex="16"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredZip" runat="server" ControlToValidate="txtZip" Display="Dynamic" ErrorMessage="Please enter a Zip"   
                                ForeColor="Red"></asp:RequiredFieldValidator>  
                            </td>
                            
                            
                        </tr>
                        <tr>
                            <td></td><td></td>
                           <%-- <td>ShiptoStore</td>
                            <td>
<asp:ListBox ID="lstFruits" runat="server" SelectionMode="Multiple">
    <asp:ListItem Text="Mango" Value="1" />
    <asp:ListItem Text="Apple" Value="2" />
    <asp:ListItem Text="Banana" Value="3" />
    <asp:ListItem Text="Guava" Value="4" />
    <asp:ListItem Text="Orange" Value="5" />
</asp:ListBox>
                            </td>--%>
                              <td>Billing Telephone: </td>
                            <td>
                                <asp:TextBox ID="txtBillingTelephone" runat="server" onBlur='addDashes(this)' CssClass="form-control" TabIndex="17"> </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredBillingTelephone" runat="server" ControlToValidate="txtBillingTelephone" Display="Dynamic" ErrorMessage="Please enter a Billing Telephone"   
                                ForeColor="Red"></asp:RequiredFieldValidator>  
                               </td>
                            
                        </tr>
                    </tbody>
                </table>
                <asp:LinkButton ID="lnkUpdateClientInfo" runat="server" CssClass="btn btn-dark" TabIndex="18" Text="Update" OnClick="lnkUpdateClientInfo_Click"></asp:LinkButton>
            </div>
        </div>
    </div>
        </asp:View>

        <asp:View ID="Users" runat="server">
        <div class="card mb-3" runat="server" id="divClientUsers">
        <div class="card-header">
            <i class="fa fa-table"></i> Client Users
      <div style="float: right;"><a class="btn btn-dark" href="ClientUserDetails.aspx?CID=<%=Request.QueryString["CID"] %>&CUID=<%=Request.QueryString["CUID"] %>" id="toggleNavColor">Add User</a></div>
        </div>
        <div class="card-body" style="background-color: white !important">
            <div class="table-responsive">
                <table class="table table-bordered table-striped" id="dataTable" width="100%" cellspacing="0">
                    <thead>
                        <tr>
                            <th>User ID</th>
                            <th>Approver FirstName</th>
                            <th>Approver LastName</th>
                            <th>Email Address</th>
                            <th>Active</th>
                            <th>Edit</th>
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
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
        </asp:View>

        <asp:View ID="Sign" runat="server">
        <div class="card mb-3" runat="server" id="div1">
        <div class="card-header">
            <i class="fa fa-table"></i> Sign Types
      <div style="float: right;"><a class="btn btn-dark" href="SigntypeDetails.aspx?CSID=0&CID=<%=Request.QueryString["CID"]%>" id="toggleNavColor">Add Sign</a></div>
        </div>
        <div class="card-body" style="background-color: white !important">
            <div class="table-responsive">
                <table class="table table-bordered table-striped" id="dataTable2" width="100%" cellspacing="0">
                    <thead>
                        <tr>
                            <th>Customer Sign Type ID</th>
                            <th>Sign Type</th>
                            <th>Edit</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="rptAdministrator">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("CustomerSignTypeID") %></td>
                                    <td><%# Eval("SignType") %></td>
                                    <td><a href='SignTypeDetails.aspx?CSID=<%# Eval("CustomerSignTypeID") %>&CID=<%# Eval("CustomerID") %>'>EDIT</a></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
        </asp:View>

      
       
        </asp:MultiView>

</asp:Content>
<asp:Content runat="server" ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3">
  <%-- <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.0/jquery.min.js"></script>
   <script src="../jquery.sumoselect.min.js"></script>
   <link href="../sumoselect.css" rel="stylesheet">
       <link href="../sumoselect.min.css" rel="stylesheet">

    <script type="text/javascript">
        $(document).ready(function () {
            $(<%=lstFruits.ClientID%>).SumoSelect();
        });
    </script>--%>
 
<%--<script type="text/javascript">
    $(function () {
        $('[id*=lstFruits]').multiselect({
            includeSelectAllOption: true
        });
    });
</script>--%>
    
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
        function addDashes(f) {
            $(f).val($(f).val().replace(/(\d{3})\-?(\d{3})\-?(\d{4})/, '$1-$2-$3'))

            //f.value = f.value.slice(0, 3) + "-" + f.value.slice(3, 6) + "-" + f.value.slice(6, 10);
        }

    </script>

    <script>
        // Delete All Checked Checkboxes Script
$(function () {
        $("#tblViewFiles [id*=chkHeader]").click(function () {
            if ($(this).is(":checked")) {
                $("#tblViewFiles [id*=chkRow]").attr("checked", "checked");
            } else {
                $("#tblViewFiles [id*=chkRow]").removeAttr("checked");
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