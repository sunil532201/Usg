<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="SignTypes.aspx.cs" Inherits="USGClient.Admin.SignTypes" %>

<%@ Register Src="~/Controls/AdminDetails.ascx" TagPrefix="uc1" TagName="AdminDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <%-- <li class="breadcrumb-item"><a href="Clients.aspx">Clients</a> </li>
    <li class="breadcrumb-item active">Client Details</li>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:HiddenField ID="hfProjectID" runat="server"/>
    <uc1:AdminDetails runat="server" ID="AdminDetails" />

  <ul class="nav nav-tabs md-tabs" id="myTabEx" role="tablist">
  <li class="nav-item">
    <a class="nav-link active show" id="active-tab-ex" data-toggle="tab" href="#active-ex" role="tab" aria-controls="active-ex"
      aria-selected="true">Active</a>
  </li>
  <li class="nav-item">
    <a class="nav-link" id="inActive-tab-ex" data-toggle="tab" href="#inActive-ex" role="tab" aria-controls="inActive-ex"
      aria-selected="false">Inactive</a>
  </li>
  </ul> 
         <div class="card mb-3" runat="server" id="div1">
        <div class="card-header">
            <img id="logo" runat="server" class="LogoSize"/><span class="card-title"> Sign Types</span>
             <div  style="float: right;" class="card-title">
             <div style="float:left; padding-right: 15px;">
                <asp:Button runat="server" ID="btnSelectAll" CssClass="btn btn-dark " ClientIDMode="Static" Text="Select All"  OnClick="loadSelectedAll" />

                <asp:Button runat="server" ID="btnPrint" CssClass="btn btn-dark " ClientIDMode="Static" Text="Print"  OnClick="loadSelectedSigntypes" />
                 <asp:Button runat="server" ID="btnPrintFn"   CssClass="btn btn-dark " ClientIDMode="Static" Text="Test" visible="false"  />

                 <a class="btn btn-dark" href="SigntypeDetails.aspx?CSID=0&CID=<%=Request.QueryString["CID"]%>" id="toggleNavColor">Add Sign</a></div>
             </div>
        </div>
        <div class="card-body bg-white">
          <div class="table-responsive">
<div class="tab-content" id="myTabContentEx">
 <div class="tab-pane fade active show" id="active-ex" role="tabpanel" aria-labelledby="active-tab-ex">

 <table class="table table-bordered table-striped" id="dataTable" width="100%">
                    <thead>
                        <tr>
                            <th>Customer Sign Type ID</th>
                            <th>Sign Type</th>
                            <th>Edit</th>
                            <th>Distribution</th>
                            <th>Print</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="rptActiveSignType">
                            
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("CustomerSignTypeID") %></td>
                                    <td><%# Eval("SignType") %></td>
                                    <td><a href='SignTypeDetails.aspx?CSID=<%# Eval("CustomerSignTypeID") %>&CID=<%# Eval("CustomerID") %>' style="color:#172C55">Edit</a></td>
                                    <td><a href='StoreTypeDistributions.aspx?CSID=<%# Eval("CustomerSignTypeID") %>&CID=<%# Eval("CustomerID") %>' style="color:#172C55">Distribution</a></td>
                                    <td> <asp:HiddenField ID="hfvalue" runat="server" Value='<%# Eval("CustomerSignTypeID") %>'/><asp:CheckBox ID="chkIsChecked" runat="Server"  Text="" ></asp:CheckBox></td>

                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>     </div>
  <div class="tab-pane fade" id="inActive-ex" role="tabpanel" aria-labelledby="inActive-tab-ex">

 <table class="table table-bordered table-striped" id="dataTable1" width="100%">
                    <thead>
                        <tr>
                            <th>Customer Sign Type ID</th>
                            <th>Sign Type</th>
                            <th>Edit</th>
                            <th>Distribution</th>
                            <th>Print</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="rptInActiveSignType">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("CustomerSignTypeID") %></td>
                                    <td><%# Eval("SignType") %></td>
                                    <td><a href='SignTypeDetails.aspx?CSID=<%# Eval("CustomerSignTypeID") %>&CID=<%# Eval("CustomerID") %>' style="color:#172C55">Edit</a></td>
                                    <td><a href='StoreTypeDistributions.aspx?CSID=<%# Eval("CustomerSignTypeID") %>&CID=<%# Eval("CustomerID") %>' style="color:#172C55">Distribution</a></td>
                                    <td> <asp:HiddenField ID="hfvalue" runat="server" Value='<%# Eval("CustomerSignTypeID") %>'/><asp:CheckBox ID="chkIsChecked" Checked='<%#(Eval("IsChecked").ToString()== "True") ? true :false%>' runat="Server" onclick="ShowHideDiv(this)" Text="Print" ></asp:CheckBox></td>

                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>     </div>
    </div>

            </div>
        </div>
             <asp:HiddenField id="hfPrint" runat="server"/>
    </div>
     <div class="card mb-3" runat="server" id="SignType">
          <div class="card-body bg-white html-content" id="PrintArea">
              <asp:PlaceHolder ID = "PlaceHolder1" runat="server" />
   
      </div>
       </div>
   
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">

    <script src="../js/printThis.js"></script>
    <script>
        // Call the dataTables jQuery plugin
        $(document).ready(function () {
           // $.fn.dataTable.moment('M/D/YYYY');
            //$('#dataTable').DataTable({
            //    "order": [[1, "asc"]]
            //});
            //$('#dataTable1').DataTable({
            //    "order": [[1, "asc"]]
            //});
            var value = $('#<%=hfPrint.ClientID%>').val();
            if (value == 'true') {
                function printDiv() { $("#PrintArea").printThis(); return false; }
                printDiv();
            }
            $('#<%=hfPrint.ClientID%>').val("");
           $('#<%=SignType.ClientID%>').hide();
        });
       
    </script>
    <script>
        // Delete All Checked Checkboxes Script
$(function () {
        $("#tblViewFiles [id*=chkHeader]").click(function () {
            if ($(this).is(":checked")) {
                $("#tblViewFiles [id*=chkRow]").attr("checked", "checked");
            } else {
                $("#tblViewFiles [id*=chkRow]").removeAttr("checked");
            }
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
        }
        
    </script>

</asp:Content>
