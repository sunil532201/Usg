<%@ Page Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="Substrates.aspx.cs" Inherits="USGClient.Admin.Substrates" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
         <div class="card mb-3">
        <div class="card-header">
            <i class="fa fa-table "></i><span class="card-title"> Substrates</span>
            <div class="float-right"><a class="btn btn-dark" href="SubstrateDetails.aspx" id="liLaminant">Adding New Product</a></div>
        </div>
        <div class="card-body bg-white">
          <div class="table-responsive">
              <table class="table table-bordered table-striped" id="dataTable" width="100%" >
                <div class="button-align">
                    <span class='bold'> Filter By:</span>   
                    <asp:DropDownList style="width: 200px;" ID="ddlQuantity" runat="server" CssClass="form-control"  AutoPostBack="True"
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged" ></asp:DropDownList>
                </div>
                  </br>
                  <thead>
                      <tr>
                          <th>Product or Service</th>
                          <th>Unit of Measure </th>
                          <th>Width </th>
                          <th>Height  </th>
                          <th>Volume </th>
                          <th>Primary Vendor  </th>
                          <th>Price  </th>
                          <th>Contact Name  </th>
                          <th>Phone Number  </th>
                          <th>Details   </th>
                      </tr>
                  </thead>

                  <tbody>
                      <asp:Repeater runat="server" ID="rptSubstratebyID" >
                          <ItemTemplate>
                              <tr>
                                  <td><%# Eval("SubstrateName") %></td>
                                  <td><%# Eval("Measurement") %></td>
                                  <td><%# Eval("Width") %></td>
                                  <td><%# Eval("Height") %></td>
                                  <td><%# Eval("Volume") %></td>
                                  <td><%# Eval("VendorName") %></td>
                                  <td><%# Eval("Price") %></td>
                                  <td><%# Eval("RepName") %></td>
                                  <td><%# Eval("RepPhone") %></td>
                                  <td><a href='SubstrateDetails.aspx?SID=<%# Eval("SubstrateID") %>'>DETAILS</a></td>

                              </tr>
                          </ItemTemplate>
                      </asp:Repeater>
                  </tbody>
              </table>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">

   <script>
        //// Call the dataTables jQuery plugin
        //$(document).ready(function () {
        //    $.fn.dataTable.moment('M/D/YYYY');
        //    $('#dataTable').DataTable({
        //        "order": [[1, "asc"]]
        //    });
           
        //});
    </script>  
</asp:Content>