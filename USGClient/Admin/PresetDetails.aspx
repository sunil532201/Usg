<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="PresetDetails.aspx.cs" Inherits="USGClient.Admin.PresetDetails" %>

<%@ Register Src="~/Controls/AdminDetails.ascx" TagPrefix="uc1" TagName="AdminDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <uc1:AdminDetails runat="server" ID="AdminDetails" />

    <div class="card mb-3" runat="server" id="div2">
        <div class="card-header">
            <img id="logo" runat="server" class="LogoSize"/> <span class="card-title">Preset Details</span>
                  <div class="float-right"> 
                      <asp:LinkButton CssClass="btn btn-dark" ID="lnkBacktoStores" runat="server" Text="Back"  OnClick="BacktoPresets_Click"/> 

                  </div>   
<%--                        <div class="float-right"> <asp:LinkButton CssClass="btn btn-dark" ID="lnkBack" TabIndex="5" runat="server" Text="Back To Search" OnClick="lnkBacktoSearch_Click"/>  </div>   --%>

        </div>
        <div class="card-body" style="background-color: white !important">
            <div class="row">
               
                <div class="col-sm-5 ">
                    <div class="button-align">
                         <asp:LinkButton ID="lnkSaveQty" style="min-width: 100px;font-weight: 200" CssClass="btn btn-dark" runat="server" Text="Add Selected Stores" OnClick="btnSave_Click"/>

                         <asp:LinkButton ID="lnkUpdate" style="min-width: 100px;" CssClass="btn btn-dark"  runat="server" Text="Select All"  OnClick="btnSelectAll_Click" /> <br><br />
                         <asp:Button ID="btnKeySelect"  style="min-width: 100px;" CssClass="btn btn-dark"  runat="server"  Text="10 Key Select"   data-toggle="modal" data-target="#exampleModalSave" /><br><br />
                     </div> 

                     <table class="table table-bordered table-striped" id="dataTable2" width="100%">
                    <thead>
                        <tr>
                            <th colspan="4" id="AvailbleStore" runat="server"></th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="rptStores">
                            <ItemTemplate>
                                <tr>
                                    <td><asp:HiddenField ID="hfValue1" runat="server" Value='<%# Eval("S1") %>'/><asp:CheckBox  type="checkbox" ID="chkStore1" runat="server" Visible='<%# Eval("SN1").ToString() != "" ? true : false %>' />  <%# Eval("SN1") %></td>
                                    <td><asp:HiddenField ID="hfValue2" runat="server" Value='<%# Eval("S2") %>'/><asp:CheckBox  type="checkbox" ID="chkStore2" runat="server" Visible='<%# Eval("SN2").ToString() != "" ? true : false %>' />  <%# Eval("SN2") %></td>
                                    <td><asp:HiddenField ID="hfValue3" runat="server" Value='<%# Eval("S3") %>'/><asp:CheckBox  type="checkbox" ID="chkStore3" runat="server" Visible='<%# Eval("SN3").ToString() != "" ? true : false %>' />  <%# Eval("SN3") %></td>
                                    <td><asp:HiddenField ID="hfValue4" runat="server" Value='<%# Eval("S4") %>'/><asp:CheckBox  type="checkbox" ID="chkStore4" runat="server" Visible='<%# Eval("SN4").ToString() != "" ? true : false %>' />  <%# Eval("SN4") %></td>
                                        
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                </div>
                <div class="col-sm-7 ">
            <div class="table-responsive">
                <table class="table table-bordered table-striped" id="dataTable1" width="100%">
                    <div class="button-align">
                      <asp:Button  ID="btnDeselectAll" style="min-width: 120px;" CssClass="btn btn-dark" TabIndex="11"   runat="server" Text="Deselect All"  OnClick="btnDeselectAll_Click"/> <br><br />
                      <asp:Button  ID="btnKeyDeselect"  style="min-width: 120px;" CssClass="btn btn-dark"  runat="server" TabIndex="12" Text="10 Key Deselect"  ClientIDMode="Static" data-toggle="modal" data-target="#exampleModalDelete" OnClientClick="return  false"/>
                    </div> 
                    <thead>
                         <tr>
                        <th colspan="7" id="Selectedtore" runat="server"></th>
                        </tr>
                        <tr>
                            <th>Store Number</th>
                            <th>Store Manager</th>
                            <th>City</th>
                            <th>State</th>
                           <th>Phone</th>
                            <th>Email</th>
                           <%-- <th>Update</th>--%>
                            <th>Delete</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="rptstoresign">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("StoreNumber") %></td>
                                   <td><%# Eval("StoreManagerName") %></td>
                                    <td><%# Eval("ShippingCity") %></td>
                                    <td><%# Eval("ShippingState") %></td>
                                    <td><%# Eval("Phone") %></td>
                                    <td><%# Eval("Email") %></td>
                                    <%--<td><asp:LinkButton runat="server" ID="btnUpdate"   CommandName="Update" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "PresetStoreID") %>'>Update</asp:LinkButton></td>--%>
                                    <td><asp:LinkButton runat="server" ID="btnDelete" OnClick="btnDelete_Click"  OnClientClick="return confirm('Are you sure you want to delete this file?');"   CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "PresetStoreID")%>'>Remove</asp:LinkButton></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
                    </div>
                </div>
        </div>
    </div>
    <div class="modal fade" id="exampleModalSave" tabindex="-1" data-keyboard="false" data-backdrop="static" role="dialog"  aria-labelledby="exampleModalSaveLabel" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="modal-content">
                     <asp:Label runat="server" style="text-align:center;" ID="lblSave"></asp:Label>

                        <div class="modal-header">
                            <h5 class="modal-title"  id="exampleModalSaveLabel">Store Number to Select</h5>
                            <button  class="close" type="button" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">×</span>
                            </button>
                        </div>
                        <table class="table table-bordered table-striped" cellspacing="0">
                                <tr >
                                    <td class="tblWidth" >Store Number: </td>
                                    <td><asp:TextBox ID="txtSaveStoreNo"  autocomplete="off" clientidmode="Static" runat="server" onkeypress="return EnterSaveEvent(event)"  CssClass="form-control"></asp:TextBox></td>

                                </tr>
                        </table>    
                               <div class="modal-footer">
                                <button class="btn btn-secondary" type="button" data-dismiss="modal" >Cancel</button>
                                <asp:Button runat="server" type="submit" ID="btnSave"  CssClass="btn btn-primary" Text="Save" OnClick="btnKeySelect_Click"></asp:Button>

                            </div>


                    </div>
                </div>
            </div>

    <div class="modal fade" id="exampleModalDelete" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabelDelete" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="modal-content">
                  <asp:Label runat="server" style="text-align:center;" ID="lblDelete"></asp:Label>

                        <div class="modal-header">
                            <h5 class="modal-title"  id="exampleModalLabelDelete">Store Number to Deselect</h5>
                            <button  class="close" type="button" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">×</span>
                            </button>
                        </div>
                        <table class="table table-bordered table-striped" cellspacing="0">
                                <tr >
                                    <td class="tblWidth">Store Number: </td>
                                    <td><asp:TextBox ID="txtDeleteStoreNo" autocomplete="off" clientidmode="Static" runat="server" onkeypress="return EnterDeleteEvent(event)" CssClass="form-control"></asp:TextBox></td>
                                </tr>
                      
                            
                        </table>        
                        <div class="modal-footer">
                            <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancel</button>
                            <asp:Button runat="server"  ID="btnDelete" AutoPostBack="true" CssClass="btn btn-primary" Text="Delete" OnClick="btnKeyDeselect_Click"></asp:Button>

                        </div>
                    </div>
                </div>
            </div>


</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
     
</asp:Content>
