<%@ Page Language="C#"  MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="JobOrderPromoStores.aspx.cs" Inherits="USGClient.Admin.JobOrderPromoStores" %>
<%@ Register Src="~/Controls/AdminDetails.ascx" TagPrefix="uc1" TagName="AdminDetails" %>
<%@ Register Src="~/Controls/JobMenuControl.ascx" TagPrefix="uc1" TagName="JobMenuControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
   <uc1:AdminDetails runat="server" ID="AdminDetails" />
   <uc1:JobMenuControl runat="server" ID="JobMenuControl" />
    <div class="card mb-3">
        <div class="card-header">
            <img id="logo" runat="server" class="LogoSize"/><span class="card-title"> Order Entry Details </span>
            <asp:Label runat="server" ID="lblMessage" ></asp:Label>
        </div>
        <div class="card-body bg-white">
          <div class="table-responsive">
              <table class="table table-bordered table-striped" id="dataTable" width="100%" >

                  <thead>
                     <asp:Repeater runat="server" ID="rptOderEntryID" >
                     <ItemTemplate> 
                        <tr>
                            <td><span class='bold'>Sign Type:</span>   <%# Eval("SignType") %></td> 
                            <td><span class='bold'>Promotion:</span>   <%# Eval("Promotion") %></td> 
                            <td><span class='bold'>Quantity:</span>   <%# Eval("Quantity") %></td>
                        </tr>                      
                     </ItemTemplate>
                     </asp:Repeater>
                  </thead>                  
              </table>
           </div>
        </div>
   </div>
   <div class="card mb-3" runat="server" id="div2">
          <%-- <div class="card-header">
            <div class="float-right"> <asp:LinkButton class="btn btn-dark" OnClick="btnAddRow_Click" runat="server" >Add</asp:LinkButton></div>
            </div>--%>

        
        <div class="card-body bg-white" >
                             <div class="col-sm-10 mt-20">
                     <asp:Label runat="server" style="text-align:center;" ID="lblPreset"></asp:Label>

                     <table class="table table-bordered table-striped" id="dataTable1" width="100%">
                    <thead>
                        <tr>
                            <td><span class='bold'>Preset:</span> </td>
                                <td>
                                <asp:RadioButtonList ID="rbActive" runat="server" RepeatDirection="Vertical" RepeatLayout="Flow">
                                    <asp:ListItem Value="True">Select Preset Stores</asp:ListItem>
                                    <asp:ListItem Value="False">Select All Stores Except</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>


                            <td><asp:DropDownList ID="ddlPreset" runat="server" CssClass="form-control"></asp:DropDownList></td>
                            <td><asp:LinkButton ID="lnkSavePreset" CssClass="btn btn-dark" runat="server" Text="Add Stores" OnClick="btnSavePreset_Click"/></td>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="Repeater1">
                            <ItemTemplate>
                                <tr>
                                    <td><asp:HiddenField ID="hfValue" runat="server" Value='<%# Eval("StoreID") %>'/><asp:CheckBox  type="checkbox" ID="chkStores"  runat="server" />  <%# Eval("StoreNumber") %></td>
                                </tr>

                            </ItemTemplate>
                        </asp:Repeater>

                    </tbody>

                </table>
                     </div>

            <div class="table-responsive">
                 <div class="col-sm-6 mt-20">
                     <div class="button-align">
                     <asp:LinkButton ID="lnkSaveQty" style="min-width: 100px;" CssClass="btn btn-dark" runat="server" Text="Add Selected Stores" OnClick="btnSave_Click"/>

                     <asp:LinkButton ID="lnkSelectAll" style="min-width: 100px;" CssClass="btn btn-dark" TabIndex="9" runat="server" Text="Select All"  OnClick="btnSelectAll_Click" /> <br><br />
                     <asp:Button ID="btnKeySelect"  style="min-width: 100px;" CssClass="btn btn-dark" TabIndex="10"   runat="server"  Text="10 Key Select"   data-toggle="modal" data-target="#exampleModalSave" /><br><br />
                    
                     </div> 

                     <table class="table table-bordered table-striped" id="dataTable2" width="100%">
                    <thead>
                        <tr>
                            <th>Availabe Store</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="rptStores">
                            <ItemTemplate>
                                <tr>
                                    <td><asp:HiddenField ID="hfValue" runat="server" Value='<%# Eval("StoreID") %>'/> <asp:CheckBox  type="checkbox" ID="chkStores"  runat="server" />  <%# Eval("StoreNumber") %></td >
                                </tr>

                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>

                </div>
             <div class="col-sm-6 mt-20">
            <div class="table-responsive">
                <table class="table table-bordered table-striped" id="dataTable3" width="100%">
                    <div class="button-align">
                      <asp:Button  ID="btnDeleteSelectedStores" style="min-width: 120px;" CssClass="btn btn-dark" TabIndex="11"   runat="server" Text="Delete Selected Stores"  OnClick="btnDeleteSelectedStores_Click"/> <br><br />
                      <asp:Button  ID="btnDeselectAll" style="min-width: 120px;" CssClass="btn btn-dark" TabIndex="12"   runat="server" Text="Deselect All"  OnClick="btnDeselectAll_Click"/> <br><br />
                      <asp:Button  ID="btnKeyDeselect"  style="min-width: 120px;" CssClass="btn btn-dark"  runat="server" TabIndex="13" Text="10 Key Deselect"  ClientIDMode="Static" data-toggle="modal" data-target="#exampleModalDelete" OnClientClick="return  false"/>
                      <asp:Button  ID="btnPasteDistribution" style="min-width: 120px;" CssClass="btn btn-dark" TabIndex="14" Enabled="false"   runat="server" Text="Paste Distribution"  OnClick="btnPasteDistribution_Click" /> <br><br />
                        </div> 

                    <thead>
                        <tr>
                            <th>Store</th>
                            <th>Deselect</th>
                        </tr>
                    </thead>
                    <tbody>
                     <asp:Label runat="server" ID="lblRowCount" style="display: none;"></asp:Label>
                        <asp:Repeater runat="server" ID="rptstoresign">
                            <ItemTemplate>
                                <tr>
                                   <td><asp:HiddenField ID="hfValue1" runat="server" Value='<%# Eval("StoreID") %>'/> <asp:CheckBox  type="checkbox" ID="chkSelectedStores"  runat="server" />  <%# Eval("StoreNumber") %></td >
                                    <td><asp:LinkButton runat="server" ID="btnDeselect"  OnClick="btnDelete_Click" OnClientClick="return confirm('Are you sure you want to delete this file?');"  CommandName="Deselect" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "JobOrderPromoStoreID")%>'>Deselect</asp:LinkButton></td>

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
<asp:Content runat="server" ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3">
    <script>

        $(document).ready(function (){
            var count = document.getElementById('<%=lblRowCount.ClientID%>').innerText;
            if (count > 0) {
                $('[id$=btnDeselectAll]').show();
            }
        });
        $('#exampleModalSave').on('shown.bs.modal', function () {
            $('#<%= txtSaveStoreNo.ClientID %>').focus();
        }) 
        $('#exampleModalDelete').on('shown.bs.modal', function () {
            $('#<%= txtDeleteStoreNo.ClientID %>').focus();
                }) 

        $("#txtSaveStoreNo").focus();

        $("#txtDeleteStoreNo").focus();

        function EnterSaveEvent(e) {
            if (event.which == 13) {
                __doPostBack('<%=btnSave.UniqueID%>', "");
            }
        }

        function EnterDeleteEvent(e) {
            if (event.which == 13) {
                __doPostBack('<%=btnDelete.UniqueID%>', "");
            }
        }


    </script>
</asp:Content>
