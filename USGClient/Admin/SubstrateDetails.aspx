<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="SubstrateDetails.aspx.cs" Inherits="USGClient.Admin.SubstratesDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="card mb-3">
        <div class="card-header">
            <i class="fa fa-table "></i><span class="card-title">Substrate Details </span>&nbsp;&nbsp;&nbsp;
            <asp:Label runat="server" ID="lblMessage"></asp:Label>

        </div>
        <div class="card-body bg-white">
            <div class="table-responsive">
                <table class="table table-bordered table-striped" style="width: 100%">
                    <tbody>
                        <tr>
                            <td>Substrate ID  :</td>
                            <td>
                                <asp:Label runat="server" TabIndex="0" ID="lblSubstrateID"></asp:Label></td>
                            <td>
                                <asp:CheckBox type="checkbox" ID="chkRoll" runat="server" AutoPostBack="True"
                                        OnCheckedChanged="RadioButton_SelectedRollChanged"/> Roll Substrates 

                                <%--                                <asp:CheckBox  type="checkbox" ID="chkRoll"  runat="server"  AutoPostBack="True"
                                        OnCheckedChanged="RadioButton_SelectedRollChanged"/> Roll Substrates --%>


                            </td>
                        </tr>
                        <tr>

                            <td>Product or Service  :</td>
                            <td>
                                <asp:TextBox ID="txtProductorService" TabIndex="1" CssClass="form-control" runat="server" /></td>
                            <td>
                                <asp:CheckBox type="checkbox" ID="chkFlat" runat="server" /> Flat Substrates 

                                <%--                                <asp:CheckBox  type="checkbox" ID="chkFlat"  runat="server" AutoPostBack="True"
                                      OnCheckedChanged="RadioButton_SelectedFlatChanged"/> Flat Substrates --%>

                            </td>

                        </tr>
                        <tr>
                            <td>Measurement  :</td>
                            <td>
                                <asp:DropDownList ID="ddlMeasurement" TabIndex="1" runat="server" CssClass="form-control"></asp:DropDownList></td>
                                <asp:RequiredFieldValidator ID="RequiredMeasurement" runat="server" ControlToValidate="ddlMeasurement" Display="Dynamic" ErrorMessage="Please select the measurement"   
                                ForeColor="Red"></asp:RequiredFieldValidator>  

                            <td>
                                <asp:CheckBox type="checkbox" ID="chkLaminatingFinishing" runat="server" /> Laminant & Finishing 
                            </td>
                        </tr>
                        <tr>
                            <td>Width    :</td>
                            <td>
                                <asp:TextBox ID="txtWidth" placeholder="inches" TabIndex="2" CssClass="form-control" runat="server" /></td>
                            <td>
                                <asp:CheckBox type="checkbox" ID="chkInk" runat="server" /> Ink / Toner 
                            </td>
                        </tr>
                        <tr>
                            <asp:TableCell ID="height" runat="server">Height/Length   :</asp:TableCell>
                            <td>
                                <asp:TextBox ID="txtHeight" placeholder="inches" TabIndex="3" CssClass="form-control" runat="server" /></td>
                            <td>
                                <asp:CheckBox type="checkbox" ID="chkHardware" runat="server" />Hardware 
                            </td>
                        </tr>
                        <tr>
                            <td>Volume    :</td>
                            <td>
                                <asp:TextBox ID="txtVolume" TabIndex="4" CssClass="form-control" runat="server" /></td>
                            <td>
                                <asp:CheckBox type="checkbox" ID="chkShipping" runat="server" />Shipping Materials 
                            </td>
                        </tr>
                        <tr>
                            <td>Memo :</td>
                            <td>
                                <asp:TextBox ID="txtMemo" TextMode="MultiLine" TabIndex="5" CssClass="form-control" runat="server" /></td>
                            <td>
                                <asp:CheckBox type="checkbox" ID="chkMaintenance" runat="server" />Maintenance Materials 
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                            <td>
                                <asp:CheckBox type="checkbox" ID="chkMiscellaneous" runat="server" />Miscellaneous 
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                            <td>
                                <asp:CheckBox type="checkbox" ID="chkOutsideServices" runat="server" />Outside Services 
                            </td>
                        </tr>

                        <table class="table table-bordered table-striped" style="width: 100%">

                            <tbody>
                                <tr>
                                    <th style="width: 200px; text-align: left">Set As Primary Vendor</th>
                                    <th style="width: 100px">Contact Name </th>
                                    <th style="width: 100px">Contanct Phone </th>
                                    <th style="width: 50px">Unit Price </th>
                                    <th style="width: 100px">Vendor Notes </th>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:RadioButton ID="Primary1" GroupName="RegularMenu" runat="Server" onclick="ShowHideDiv(this)"></asp:RadioButton>&nbsp;&nbsp;
                                        <%--                            <div style="float:left;" >Vendor1 :</div> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   --%>
                                         Vendor1 :
                                         <asp:DropDownList ID="ddlVendors1" TabIndex="15" Style="width: 200px; float: right; margin-right: 25px;" runat="server" CssClass="form-control" AutoPostBack="True"
                                             AppendDataBoundItems="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                         </asp:DropDownList></td>
                                    <td>
                                        <asp:Label ID="lbName1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lbPhone1" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="txtPrice1" runat="server" CssClass="form-control" TabIndex="16"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox ID="txtNotes1" runat="server" CssClass="form-control" TabIndex="17"></asp:TextBox></td>
                                    <asp:HiddenField ID="hfvendor1" runat="server" />
                                </tr>
                                <tr>
                                    <td>
<%--                                        <div style="float: left;">Vendor2 :</div> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
                                          <asp:RadioButton ID="Primary2" GroupName="RegularMenu" runat="Server" onclick="ShowHideDiv(this)"></asp:RadioButton>&nbsp;&nbsp;
                                        Vendor2 :
                                        <asp:DropDownList ID="ddlVendors2" TabIndex="18" Style="width: 200px; float: right; margin-right: 25px;" runat="server" CssClass="form-control" AutoPostBack="True"
                                            AppendDataBoundItems="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                        </asp:DropDownList></td>
                                    <td>
                                        <asp:Label ID="lbName2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lbPhone2" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="txtPrice2" runat="server" CssClass="form-control" TabIndex="19"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox ID="txtNotes2" runat="server" CssClass="form-control" TabIndex="20"></asp:TextBox></td>
                                    <asp:HiddenField ID="hfvendor2" runat="server" />

                                </tr>
                                <tr>
                                    <td>
<%--                                        <div style="float: left;">Vendor3 :</div>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
                                 
                                        <asp:RadioButton ID="Primary3" GroupName="RegularMenu" runat="Server" onclick="ShowHideDiv(this)"></asp:RadioButton>&nbsp;&nbsp;
                                        Vendor3 :
                                        <asp:DropDownList ID="ddlVendors3" TabIndex="21" Style="width: 200px; float: right; margin-right: 25px;" runat="server" CssClass="form-control" AutoPostBack="True"
                                            AppendDataBoundItems="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                        </asp:DropDownList></td>
                                    <td>
                                        <asp:Label ID="lbName3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lbPhone3" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="txtPrice3" runat="server" CssClass="form-control" TabIndex="22"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox ID="txtNotes3" runat="server" CssClass="form-control" TabIndex="23"></asp:TextBox></td>
                                    <asp:HiddenField ID="hfvendor3" runat="server" />

                                </tr>
                                <tr>
                                    <td>
<%--                                        <div style="float: left;">Vendor4 :</div>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
                                         <asp:RadioButton ID="Primary4" GroupName="RegularMenu" runat="Server" onclick="ShowHideDiv(this)"></asp:RadioButton>&nbsp;&nbsp;
                                       Vendor4 :
                                        <asp:DropDownList ID="ddlVendors4" TabIndex="24" Style="width: 200px; float: right; margin-right: 25px;" runat="server" CssClass="form-control" AutoPostBack="True"
                                            AppendDataBoundItems="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                        </asp:DropDownList></td>
                                    <td>
                                        <asp:Label ID="lbName4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lbPhone4" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="txtPrice4" runat="server" CssClass="form-control" TabIndex="25"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox ID="txtNotes4" runat="server" CssClass="form-control" TabIndex="26"></asp:TextBox></td>
                                    <asp:HiddenField ID="hfvendor4" runat="server" />

                                </tr>
                                <tr>
                                    <td>
<%--                                        <div style="float: left;">Vendor5 :</div>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
                                           <asp:RadioButton ID="Primary5" GroupName="RegularMenu" runat="Server" onclick="ShowHideDiv(this)"></asp:RadioButton>&nbsp;&nbsp;
                                        Vendor5 :
                                        <asp:DropDownList ID="ddlVendors5" TabIndex="27" Style="width: 200px; float: right; margin-right: 25px;" runat="server" CssClass="form-control" AutoPostBack="True"
                                            AppendDataBoundItems="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                        </asp:DropDownList></td>
                                    <td>
                                        <asp:Label ID="lbName5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lbPhone5" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="txtPrice5" runat="server" CssClass="form-control" TabIndex="28"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox ID="txtNotes5" runat="server" CssClass="form-control" TabIndex="29"></asp:TextBox></td>
                                    <asp:HiddenField ID="hfvendor5" runat="server" />

                                </tr>
                                <tr>
                                    <td>
<%--                                        <div style="float: left;">Vendor6 :</div>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
                                           <asp:RadioButton ID="Primary6" GroupName="RegularMenu" runat="Server" onclick="ShowHideDiv(this)"></asp:RadioButton>&nbsp;&nbsp;
                                        Vendor6 :
                                        <asp:DropDownList ID="ddlVendors6" TabIndex="30" Style="width: 200px; float: right; margin-right: 25px;" runat="server" CssClass="form-control" AutoPostBack="True"
                                            AppendDataBoundItems="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                        </asp:DropDownList></td>
                                    <td>
                                        <asp:Label ID="lbName6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lbPhone6" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="txtPrice6" runat="server" CssClass="form-control" TabIndex="31"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox ID="txtNotes6" runat="server" CssClass="form-control" TabIndex="32"></asp:TextBox></td>
                                    <asp:HiddenField ID="hfvendor6" runat="server" />

                                </tr>
                            </tbody>
                        </table>
                    </tbody>
                </table>
                <asp:LinkButton ID="lnkSaveSubstrateItemDetails" TabIndex="32" runat="server" CssClass="btn btn-dark" OnClick="lnkSaveSubstrateItemDetails_Click" Text="Update"></asp:LinkButton>
                <asp:Button CssClass="btn btn-dark" ID="BacktoSubstrateItem" TabIndex="34" runat="server" Text="Back" OnClick="BacktoSubstrateItem_Click" />
            </div>

        </div>
    </div>


</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>

    <script>
        $(".chb").change(function () {
            $(".chb").prop('checked', false);
            $(this).prop('checked', true);
        });



    </script>
</asp:Content>
