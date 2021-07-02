<%@ Page Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="MeasurementList.aspx.cs" Inherits="USGClient.Admin.MeasurementList" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

         <div class="card mb-3">
        <div class="card-header">
            <i class="fa fa-table "></i><span class="card-title"> Measurements</span>
            <div class="float-right"><a class="btn btn-dark" href="MeasurementDetails.aspx" id="liLaminant">Create Measurement</a></div>
        </div>
        <div class="card-body bg-white">
          <div class="table-responsive">
              <table class="table table-bordered table-striped" id="dataTable" width="100%" >
                  <thead>
                      <tr>
                          <th>Measurement ID</th>
                          <th>Measurement </th>
                          <th>Details</th>
                          <th>Delete</th>
                      </tr>
                  </thead>

                  <tbody>
                      <asp:Repeater runat="server" ID="rptMeasurementbyID" >
                          <ItemTemplate>
                              <tr>
                                  <td><%# Eval("MeasurementID ") %></td>
                                  <td><%# Eval("Measurement") %></td>
                                  <td><a href='MeasurementDetails.aspx?MID=<%# Eval("MeasurementID") %>'>DETAILS</a></td>
                                  <td><asp:LinkButton runat="server" ID="btnDelete"  OnClick="btnDelete_Click"  CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "MeasurementID ")%>'>DELETE</asp:LinkButton></td>

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
        // Call the dataTables jQuery plugin
        $(document).ready(function () {
            $.fn.dataTable.moment('M/D/YYYY');
            $('#dataTable').DataTable({
                "order": [[1, "asc"]]
            });
           
        });
    </script>  
</asp:Content>