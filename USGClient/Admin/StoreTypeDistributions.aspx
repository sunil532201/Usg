<%@ Page Language="C#"  MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="StoreTypeDistributions.aspx.cs" Inherits="USGClient.Admin.StoreTypeDistributions" %>

<%@ Register Src="~/Controls/AdminDetails.ascx" TagPrefix="uc1" TagName="AdminDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <uc1:AdminDetails runat="server" ID="AdminDetails" />
   
    <div class="card mb-3" runat="server" id="div2">
        <div class="card-header">
            <img id="logo" runat="server" class="LogoSize"/> Sign Type Distribution
     
        </div>

        <div class="col-sm-6 mt-20">

                <table class="table table-bordered table-striped" cellspacing="0">
                    <tbody>
                        <tr>
                            <th colspan="1" style="width: 150px;">Sign Types :</th>
                            <th colspan="1" style="width: 750px !important;"><asp:DropDownList ID="ddlSignTypes" runat="server" CssClass="form-control" AutoPostBack="True"
                                onselectedindexchanged="Ddl_SelectedIndexChanged"></asp:DropDownList></th>
                                                                             

                            
                        </tr>
                        <tr>
                            <td  style="width: 130px;"><asp:Label ID="lblqty" runat="server" Text="Max Quantity :" Font-Bold="true"></asp:Label></td>
                            <td >  
                                <div style="float:left;"><asp:TextBox ID="txtQty"  runat="server" CssClass="form-control" ></asp:TextBox></div>
                               <asp:CheckBox runat="server" style="display: inline; width: 50px !important;" ID="chkUnlimited" Text="Unlimited" CssClass="form-check display-flex"></asp:CheckBox>
                           </td>
                                
                        </tr>

                        </tbody>
                    </table>
            </div>
        <div class="card-body" style="background-color: white !important">
            
            <div class="row">
                
                 <div class="table-responsive">
                                   
                <div class="col-sm-5 mt-20">
                     <div class="button-align">
                     <asp:LinkButton ID="lnkSaveQty" style="min-width: 100px;font-weight: 200" CssClass="btn btn-dark" runat="server" Text="Add Selected Stores" OnClick="btnSave_Click"/>

                     <asp:LinkButton ID="lnkUpdate" style="min-width: 100px;" CssClass="btn btn-dark"  runat="server" Text="Select All"  OnClick="btnSelectAll_Click" /> <br><br />
                     <asp:Button ID="btnKeySelect"  style="min-width: 100px;" CssClass="btn btn-dark"  runat="server"  Text="10 Key Select"   data-toggle="modal" data-target="#exampleModalSave" /><br><br />
                     </div> 
                     <table class="table table-bordered table-striped" id="dataTable1" width="100%">
                     
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

                <div class="col-sm-7 mt-20">
            <div class="table-responsive">
                <table class="table table-bordered table-striped" id="dataTable2" width="100%">
                    <div class="button-align">
                     
                            <span class='bold'> Show Quantity:</span>                   
                            <asp:DropDownList style="width: 200px;" ID="ddlQuantity" runat="server" CssClass="form-control"  AutoPostBack="True"
                                onselectedindexchanged="DropDownList1_SelectedIndexChanged" ></asp:DropDownList>
                          <asp:Button  ID="btnUpdateAll" style="min-width: 120px;" CssClass="btn btn-dark"  runat="server" Text="Update All"  OnClick="btnUpdateAll_Click"/> <br><br />

                      <asp:Button  ID="btnDeselectAll" style="min-width: 120px;" CssClass="btn btn-dark" TabIndex="11"   runat="server" Text="Deselect All"  OnClick="btnDeselectAll_Click"/> <br><br />
                      <asp:Button  ID="btnKeyDeselect"  style="min-width: 120px;" CssClass="btn btn-dark"  runat="server" TabIndex="12" Text="10 Key Deselect"  ClientIDMode="Static" data-toggle="modal" data-target="#exampleModalDelete" OnClientClick="return  false"/>
                    </div> 
                   
                    <thead>
                        <tr>
                        <th colspan="5" id="Selectedtore" runat="server"></th>
                        </tr>
                        <tr>
                            <th>Store</th>
                            <th>Quantity</th>
                            <th>Unlimited</th>
                           <th>Update</th>
                            <th>Delete</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="rptstoresign">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("StoreNumber") %></td>
                                    <td><asp:TextBox runat="server" ID="txtQty" CssClass="form-control"  Text='<%# Eval("MaxQuantity") %>'></asp:TextBox></td>
                                        <td><asp:CheckBox ID="chkUnlimited" runat="Server" onclick="ShowHideDiv(this)" Checked='<%#(Eval("Unlimited").ToString()== "True") ? true :false%>'  ></asp:CheckBox></td>
                                         <asp:HiddenField ID="hfStoredSignTypeID" Value='<%# Eval("StoreSignTypeID") %>' runat="server"/>

                                    <td><asp:LinkButton runat="server" ID="btnUpdate" OnClick="btnUpdate_Click"   CommandName="Update" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "StoreSignTypeID") %>'>Update</asp:LinkButton></td>
                                    <td><asp:LinkButton runat="server" ID="btnDelete"  OnClick="btnDelete_Click"  CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "StoreSignTypeID")%>'>Deselect</asp:LinkButton></td>
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
                                <asp:Button runat="server" type="submit" ID="btnSave"  CssClass="btn btn-primary" Text="Save"  OnClick="btnKeySelect_Click"></asp:Button>

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
        // Call the dataTables jQuery plugin
        $(document).ready(function () {
            $.fn.dataTable.moment('M/D/YYYY');
            $('#dataTable').DataTable({
                "order": [[1, "asc"]]
            });
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

    <script type="text/javascript">
        var soundObject = null;
        function PlaySound() {
            if (soundObject != null) {
                document.body.removeChild(soundObject);
                soundObject.removed = true;
                soundObject = null;
            }
            soundObject = document.createElement("embed");
            soundObject.setAttribute("src", "Path to wav sound file");
            soundObject.setAttribute("hidden", true);
            soundObject.setAttribute("autostart", true);
            document.body.appendChild(soundObject);
        }

    </script>
</asp:Content>