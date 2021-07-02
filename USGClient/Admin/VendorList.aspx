<%@ Page Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="VendorList.aspx.cs" Inherits="USGClient.Admin.VendorList" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
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
         <div class="card mb-3">
        <div class="card-header">
            <i class="fa fa-table "></i><span class="card-title"> Vendors</span>
            <div class="float-right"><a class="btn btn-dark" href="VendorDetails.aspx" id="liLaminant">Create Vendor</a></div>
        </div>
        <div class="card-body bg-white">
          <div class="table-responsive">
<div class="tab-content pt-5" id="myTabContentEx">
 <div class="tab-pane fade active show" id="active-ex" role="tabpanel" aria-labelledby="active-tab-ex">

              <table class="table table-bordered table-striped" id="dataTable" width="100%" >
                  <thead>
                      <tr>
                          <th>Vendor ID</th>
                          <th>Vendor Name </th>
                          <th>Company Email </th>
                          <th>Website  </th>
<%--                          <th>RepName  </th>
                          <th>RepPhone  </th>
                          <th>RepEmail  </th>--%>
                          <th>Memo  </th>
                          <th>Details</th>
                          <th>Delete</th>
                      </tr>
                  </thead>

                  <tbody>
                      <asp:Repeater runat="server" ID="rptActiveVendor" >
                          <ItemTemplate>
                              <tr>
                                  <td><%# Eval("VendorID ") %></td>
                                  <td><%# Eval("VendorName ") %></td>
                                  <td><%# Eval("CompanyEmail  ") %></td>
                                  <td><%# Eval("Website  ") %></td>
<%--                                  <td><%# Eval("RepName  ") %></td>
                                  <td><%# Eval("RepPhone  ") %></td>
                                  <td><%# Eval("RepEmail  ") %></td>--%>
                                  <td><%# Eval("Memo  ") %></td>

                                  <td><a href='VendorDetails.aspx?VID=<%# Eval("VendorID") %>'>DETAILS</a></td>
                                  <td><asp:LinkButton runat="server" ID="btnDelete"  OnClick="btnDelete_Click"  OnClientClick="return confirm('Are you sure you want to delete this vendor?');" CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "VendorID")%>'>DELETE</asp:LinkButton></td>

                              </tr>
                          </ItemTemplate>
                      </asp:Repeater>
                  </tbody>
              </table>
     </div>
  <div class="tab-pane fade" id="inActive-ex" role="tabpanel" aria-labelledby="inActive-tab-ex">

             <table class="table table-bordered table-striped" id="dataTable" width="100%" >
                  <thead>
                      <tr>
                          <th>Vendor ID</th>
                          <th>Vendor Name </th>
                          <th>Company Email </th>
                          <th>Website  </th>
<%--                          <th>RepName  </th>
                          <th>RepPhone  </th>
                          <th>RepEmail  </th>--%>
                          <th>Memo  </th>
                          <th>Details</th>
                          <th>Delete</th>
                      </tr>
                  </thead>

                  <tbody>
                      <asp:Repeater runat="server" ID="rptInActiveVendors" >
                          <ItemTemplate>
                              <tr>
                                  <td><%# Eval("VendorID ") %></td>
                                  <td><%# Eval("VendorName ") %></td>
                                  <td><%# Eval("CompanyEmail  ") %></td>
                                  <td><%# Eval("Website  ") %></td>
<%--                                  <td><%# Eval("RepName  ") %></td>
                                  <td><%# Eval("RepPhone  ") %></td>
                                  <td><%# Eval("RepEmail  ") %></td>--%>
                                  <td><%# Eval("Memo  ") %></td>

                                  <td><a href='VendorDetails.aspx?VID=<%# Eval("VendorID") %>'>DETAILS</a></td>
                                  <td><asp:LinkButton runat="server" ID="btnDelete"  OnClick="btnDelete_Click"  CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "VendorID")%>'>DELETE</asp:LinkButton></td>

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

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
   <script>
        // Call the dataTables jQuery plugin
        $(document).ready(function () {
            $.fn.dataTable.moment('M/D/YYYY');
            $('#dataTable').DataTable({
                "order": [[1, "asc"]]
            });
           
        });
    </script>  
</asp:Content>