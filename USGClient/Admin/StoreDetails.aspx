<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="StoreDetails.aspx.cs" Inherits="USGClient.Admin.StoreDetails" %>

<%@ Register Src="~/Controls/AdminDetails.ascx" TagPrefix="uc1" TagName="AdminDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
        <uc1:AdminDetails runat="server" ID="AdminDetails" />

    <div class="card mb-3">
        <div class="card-header">
            <img id="logo" runat="server" class="LogoSize"/><span class="card-title"> Store Details </span>&nbsp;&nbsp;&nbsp;
            <asp:Label runat="server" ID="lblMessage" ></asp:Label>
        </div>
        <div class="card-body bg-white" >
            <div class="table-responsive">
                <table class="table table-bordered table-striped" style="width: 100%">
                    <tbody>
                        <tr>
                            <td >Store Number:</td>
                            <td><asp:TextBox ID="txtStoreNumber" CssClass="form-control" runat="server" TabIndex="1"/></td>
							                            <td>Email:</td>
                            <td><asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" TabIndex="8"/></td>

                        </tr>
                        <tr>
							                            <td>Active:</td>
                            <td><asp:RadioButtonList ID="rbActive" TabIndex="1" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Value="True">Yes</asp:ListItem>
                                    <asp:ListItem Value="False">No</asp:ListItem>
                                </asp:RadioButtonList></td>

                            <td>Store Manager Name:</td>
                            <td><asp:TextBox ID="txtStoreManagerName"  CssClass="form-control" runat="server" TabIndex="9"/></td>
                        </tr>
                        <tr>
                            <td>Shipping Address Line1:</td>
                            <td><asp:TextBox ID="txtShippingAddressLine1" runat="server" CssClass="form-control" TabIndex="2"/></td>
                            <td >Mailing Address Line1:</td>
                            <td><asp:TextBox ID="txtMailingAddressLine1" CssClass="form-control" runat="server" TabIndex="10"/></td>
                        </tr>
                        <tr>
                            <td>Shipping Address Line2:</td>
                            <td><asp:TextBox ID="txtShippingAddressLine2" runat="server" CssClass="form-control" TabIndex="3" /></td>
                            <td >Mailing Address Line2:</td>
                            <td><asp:TextBox ID="txtMailingAddressLine2" CssClass="form-control" runat="server" TabIndex="11"/></td>
                        </tr>
                        <tr>
                            <td>Shipping City:</td>
                            <td> <asp:TextBox ID="txtShippingCity" runat="server" CssClass="form-control" TabIndex="4"/></td>
                            <td >Mailing City:</td>
                            <td><asp:TextBox ID="txtMailingCity" CssClass="form-control" runat="server" TabIndex="12"/></td>

                        </tr>
                        <tr>
                            <div class="form-group">
<td >Shipping State  :</td>	
    <td><div >
		<select class="form-control"  id="txtShippingState" TabIndex="5" runat="server" name="state">
			<option value="">Select State</option>
			<option value="AK">Alaska</option>
			<option value="AL">Alabama</option>
			<option value="AR">Arkansas</option>
			<option value="AZ">Arizona</option>
			<option value="CA">California</option>
			<option value="CO">Colorado</option>
			<option value="CT">Connecticut</option>
			<option value="DC">District of Columbia</option>
			<option value="DE">Delaware</option>
			<option value="FL">Florida</option>
			<option value="GA">Georgia</option>
			<option value="HI">Hawaii</option>
			<option value="IA">Iowa</option>
			<option value="ID">Idaho</option>
			<option value="IL">Illinois</option>
			<option value="IN">Indiana</option>
			<option value="KS">Kansas</option>
			<option value="KY">Kentucky</option>
			<option value="LA">Louisiana</option>
			<option value="MA">Massachusetts</option>
			<option value="MD">Maryland</option>
			<option value="ME">Maine</option>
			<option value="MI">Michigan</option>
			<option value="MN">Minnesota</option>
			<option value="MO">Missouri</option>
			<option value="MS">Mississippi</option>
			<option value="MT">Montana</option>
			<option value="NC">North Carolina</option>
			<option value="ND">North Dakota</option>
			<option value="NE">Nebraska</option>
			<option value="NH">New Hampshire</option>
			<option value="NJ">New Jersey</option>
			<option value="NM">New Mexico</option>
			<option value="NV">Nevada</option>
			<option value="NY">New York</option>
			<option value="OH">Ohio</option>
			<option value="OK">Oklahoma</option>
			<option value="OR">Oregon</option>
			<option value="PA">Pennsylvania</option>
			<option value="PR">Puerto Rico</option>
			<option value="RI">Rhode Island</option>
			<option value="SC">South Carolina</option>
			<option value="SD">South Dakota</option>
			<option value="TN">Tennessee</option>
			<option value="TX">Texas</option>
			<option value="UT">Utah</option>
			<option value="VA">Virginia</option>
			<option value="VT">Vermont</option>
			<option value="WA">Washington</option>
			<option value="WI">Wisconsin</option>
			<option value="WV">West Virginia</option>
			<option value="WY">Wyoming</option>
		</select>
	</div>
        </td>
</div>

                            <div class="form-group">
<td >Mailing State  :</td>	
    <td><div >
		<select class="form-control"  id="txtMailingState" TabIndex="13" runat="server" name="state">
			<option value="">Select State</option>
			<option value="AK">Alaska</option>
			<option value="AL">Alabama</option>
			<option value="AR">Arkansas</option>
			<option value="AZ">Arizona</option>
			<option value="CA">California</option>
			<option value="CO">Colorado</option>
			<option value="CT">Connecticut</option>
			<option value="DC">District of Columbia</option>
			<option value="DE">Delaware</option>
			<option value="FL">Florida</option>
			<option value="GA">Georgia</option>
			<option value="HI">Hawaii</option>
			<option value="IA">Iowa</option>
			<option value="ID">Idaho</option>
			<option value="IL">Illinois</option>
			<option value="IN">Indiana</option>
			<option value="KS">Kansas</option>
			<option value="KY">Kentucky</option>
			<option value="LA">Louisiana</option>
			<option value="MA">Massachusetts</option>
			<option value="MD">Maryland</option>
			<option value="ME">Maine</option>
			<option value="MI">Michigan</option>
			<option value="MN">Minnesota</option>
			<option value="MO">Missouri</option>
			<option value="MS">Mississippi</option>
			<option value="MT">Montana</option>
			<option value="NC">North Carolina</option>
			<option value="ND">North Dakota</option>
			<option value="NE">Nebraska</option>
			<option value="NH">New Hampshire</option>
			<option value="NJ">New Jersey</option>
			<option value="NM">New Mexico</option>
			<option value="NV">Nevada</option>
			<option value="NY">New York</option>
			<option value="OH">Ohio</option>
			<option value="OK">Oklahoma</option>
			<option value="OR">Oregon</option>
			<option value="PA">Pennsylvania</option>
			<option value="PR">Puerto Rico</option>
			<option value="RI">Rhode Island</option>
			<option value="SC">South Carolina</option>
			<option value="SD">South Dakota</option>
			<option value="TN">Tennessee</option>
			<option value="TX">Texas</option>
			<option value="UT">Utah</option>
			<option value="VA">Virginia</option>
			<option value="VT">Vermont</option>
			<option value="WA">Washington</option>
			<option value="WI">Wisconsin</option>
			<option value="WV">West Virginia</option>
			<option value="WY">Wyoming</option>
		</select>
	</div>
        </td>
</div>


                        </tr>
                        <tr>
                            <td>Shipping Zip:</td>
                            <td> <asp:TextBox ID="txtShippingZip" runat="server" CssClass="form-control" TabIndex="6"/></td>
                            <td >Mailing Zip:</td>
                            <td><asp:TextBox ID="txtMailingZip" CssClass="form-control" runat="server" TabIndex="14"/></td>
                        </tr>
                        <tr>
                             <td>Sales Tax:</td>
                            <td> <asp:TextBox ID="txtSalesTax" runat="server" CssClass="form-control" TabIndex="7"/></td>
                            <td colspan="2"></td>
                        </tr>
                        <tr>
                            <td>Phone:</td>
                            <td><asp:TextBox ID="txtPhone" CssClass="form-control" onBlur='addDashes(this)' runat="server" TabIndex="8"/></td>
                            <td >Fax:</td>
                            <td><asp:TextBox ID="txtFax" CssClass="form-control" onBlur='addDashes(this)' runat="server" TabIndex="15"/></td>
                        </tr>
                      
                    </tbody>
                </table>
                <asp:LinkButton ID="lnkSaveStoreDetails" runat="server" CssClass="btn btn-dark" TabIndex="16" OnClick="lnkSaveStoreDetails_Click" Text="Update"></asp:LinkButton>
                <asp:Button CssClass="btn btn-dark" ID="BacktoStores" runat="server" Text="Back" TabIndex="17" OnClick="BacktoStores_Click"/>
            </div>
             
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <script>
        function addDashes(f) {
            $(f).val($(f).val().replace(/(\d{3})\-?(\d{3})\-?(\d{4})/, '$1-$2-$3'))

            //f.value = f.value.slice(0, 3) + "-" + f.value.slice(3, 6) + "-" + f.value.slice(6, 10);
        }

    </script>
</asp:Content>
