<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="Job.aspx.cs" Inherits="USGClient.Admin.Job" %>

<%@ Register Src="~/Controls/AdminDetails.ascx" TagPrefix="uc1" TagName="AdminDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
        <uc1:AdminDetails runat="server" ID="AdminDetails" Visible="false" />
   
   <ul class="nav nav-tabs md-tabs" id="myTabEx" role="tablist">
  <li class="nav-item">
    <a class="nav-link active show" id="active-tab-ex" data-toggle="tab" href="#active-ex" role="tab" aria-controls="active-ex"
      aria-selected="true">Active</a>
  </li>
  <li class="nav-item">
    <a class="nav-link" id="inActive-tab-ex" data-toggle="tab" href="#inActive-ex" role="tab" aria-controls="inActive-ex"
      aria-selected="false">Shipped</a>
  </li>
  <li class="nav-item">
    <a class="nav-link" id="charged-tab-ex" data-toggle="tab" href="#Archieved-ex" role="tab" aria-controls="charged-ex"
      aria-selected="false">Archived</a>
  </li>
 
</ul>    
    <div class="card mb-3">
            <div class="card-header">
                <img id="logo" runat="server" class="LogoSize"/><span class="card-title"> Job Book</span>
                 <div class="float-right"><a class="btn btn-dark" href="JobDetails.aspx?CID=<%=Request.QueryString["CID"]%>" id="toggleNavColor">Create Job</a></div>
            </div>
            <div class="card-body bg-white" >

              <div class="table-responsive">

<div class="tab-content pt-5" id="myTabContentEx">
 <div class="tab-pane fade active show" id="active-ex" role="tabpanel" aria-labelledby="active-tab-ex">
     <asp:Label runat="server" ID="lblError" ForeColor="Red"></asp:Label>
 <table class="table table-bordered table-striped" id="dataTable" width="100%" >
                  <thead>
                      <tr>
                          <th>No Charge</th>
                          <th>Job Number</th>
                          <th id="th_custName" runat="server">Customer Name</th>
                          <th>Description</th>
                          <th>Order Date</th>
                          <th>Display Date</th>
                          <th>Shipped</th>
                          <th>Date Shipped</th>
                          <%--<th>Update</th>--%>
                          <th>Details</th>
                      </tr>
                  </thead>

                  <tbody>
                      <asp:Repeater runat="server" ID="rptActiveJob"  >
                          <ItemTemplate>
                              <tr>
                                  <td><%#(Eval("NoCharge").ToString()== "True") ?"NC":""%></td>
                                  <td><%#Eval("Prefix").ToString() +"-" + Eval("JobID").ToString()%><asp:HiddenField ID="hfvalue" runat="server" Value='<%# Eval("JobID")%>' /></td>
                                  <td id="td_custName" runat="server"><%# Eval("CustomerName") %></td>
                                  <td><%# Eval("Description") %></td>
                                  <td><%# Eval("OrderDate","{0: MM/dd/yyyy}") %></td>
                                  <td><%# Eval("DisplayDate","{0: MM/dd/yyyy}") %> </td>
                                  <td><%#(Eval("Shipped").ToString()== "True") ? "<input type='checkbox' name='chkShipped'   runat='server' checked>":"<input type='checkbox' name='chkShipped'   runat='server' >" %></td>
                                  <td><%#(Eval("DateShipped").ToString().Contains("1900")) ?"":Eval("DateShipped","{0: MM/dd/yyyy}")%></td>
                                       
                                  <%--<td><asp:LinkButton runat="server" ID="btnUpdate" OnClick="btnUpdateNote_Click"  CommandName="UpdateNotes" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "JobID") %>'>Update</asp:LinkButton></td>--%>
                                  <td><a href='JobDetails.aspx?JID=<%# Eval("JobID") %>&CID=<%#Eval("CustomerID")%>'>DETAILS</a></td>
                              </tr>
                          </ItemTemplate>
                      </asp:Repeater>
                  </tbody>
              </table>     </div>

  <div class="tab-pane fade" id="inActive-ex" role="tabpanel" aria-labelledby="inActive-tab-ex">

              <table class="table table-bordered table-striped" id="dataTable1" width="100%" >
                  <thead>
                      <tr>
                          <th>No Charge</th>
                          <th>Job Number</th>
                          <th id="th1" runat="server">Customer Name</th>
                          <th>Description</th>
                          <th>Order Date</th>
                          <th>Display Date</th>
                          <th>Shipped</th>
                          <th>Date Shipped</th>
                          <%--<th>Update</th>--%>
                          <th>Details</th>
                      </tr>
                  </thead>

                  <tbody>
                      <asp:Repeater runat="server" ID="rptShippedJob"  >
                          <ItemTemplate>
                              <tr>
                                  <td><%#(Eval("NoCharge").ToString()== "True") ?"NC":""%></td>
                                  <td><%#Eval("Prefix").ToString() +"-" + Eval("JobID").ToString()%><asp:HiddenField ID="hfvalue" runat="server" Value='<%# Eval("JobID")%>' /></td>
                                  <td id="td_custName" runat="server"><%# Eval("CustomerName") %></td>
                                  <td><%# Eval("Description") %></td>
                                  <td><%# Eval("OrderDate","{0: MM/dd/yyyy}") %></td>
                                  <td><%# Eval("DisplayDate","{0: MM/dd/yyyy}") %> </td>
                                  <td><%#(Eval("Shipped").ToString()== "True") ? "<input type='checkbox' name='chkShipped'   runat='server' checked>":"<input type='checkbox' name='chkShipped'   runat='server' >" %></td>
                                  <td><%#(Eval("DateShipped").ToString().Contains("1900")) ?"":Eval("DateShipped","{0: MM/dd/yyyy}")%></td>
                                       
                                  <%--<td><asp:LinkButton runat="server" ID="btnUpdate" OnClick="btnUpdateNote_Click"  CommandName="UpdateNotes" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "JobID") %>'>Update</asp:LinkButton></td>--%>
                                  <td><a href='JobDetails.aspx?JID=<%# Eval("JobID") %>&CID=<%#Eval("CustomerID")%>'>DETAILS</a></td>
                              </tr>
                          </ItemTemplate>
                      </asp:Repeater>
                  </tbody>
              </table>
  </div>
  <div class="tab-pane fade" id="charged-ex" role="tabpanel" aria-labelledby="charged-tab-ex">
        <table class="table table-bordered table-striped" id="dataTable2" width="100%" >
                  <thead>
                      <tr>
                          <th>Client ID</th>
                          <th>Date</th>
                          <th>Client Name</th>
                          <th>View</th>
                      </tr>
                  </thead>
                  <tbody>
                      <asp:Repeater runat="server" ID="chargeList">
                          <ItemTemplate>
                              <tr>
                                  <td><%# Eval("CustomerID") %></td>
                                  <td><%# Convert.ToDateTime(Eval("CreateDate")).ToString("MM/dd/yyyy") %></td>
                                  <td><%# Eval("CustomerName") %></td>
                                  <td><a href='ClientDetails.aspx?CID=<%# Eval("CustomerID") %>' style="color:#172C55" >DETAILS</a></td>
                              </tr>
                          </ItemTemplate>
                      </asp:Repeater>
                  </tbody>
              </table>

  </div>
  <div class="tab-pane fade" id="Archieved-ex" role="tabpanel" aria-labelledby="noCharged-tab-ex">
<table class="table table-bordered table-striped" id="dataTable3" width="100%" >
                  <thead>
                      <tr>
                          <th>No Charge</th>
                          <th>Job Number</th>
                          <th id="th2" runat="server">Customer Name</th>
                          <th>Description</th>
                          <th>Order Date</th>
                          <th>Display Date</th>
                          <th>Shipped</th>
                          <th>Date Shipped</th>
                          <%--<th>Update</th>--%>
                          <th>Details</th>
                      </tr>
                  </thead>

                  <tbody>
                      <asp:Repeater runat="server" ID="rptArchivedJob"  >
                          <ItemTemplate>
                              <tr>
                                  <td><%#(Eval("NoCharge").ToString()== "True") ?"NC":""%></td>
                                  <td><%#Eval("Prefix").ToString() +"-" + Eval("JobID").ToString()%><asp:HiddenField ID="hfvalue" runat="server" Value='<%# Eval("JobID")%>' /></td>
                                  <td id="td_custName" runat="server"><%# Eval("CustomerName") %></td>
                                  <td><%# Eval("Description") %></td>
                                  <td><%# Eval("OrderDate","{0: MM/dd/yyyy}") %></td>
                                  <td><%# Eval("DisplayDate","{0: MM/dd/yyyy}") %> </td>
                                  <td><%#(Eval("Shipped").ToString()== "True") ? "<input type='checkbox' name='chkShipped'   runat='server' checked>":"<input type='checkbox' name='chkShipped'   runat='server' >" %></td>
                                  <td><%#(Eval("DateShipped").ToString().Contains("1900")) ?"":Eval("DateShipped","{0: MM/dd/yyyy}")%></td>
                                       
                                  <%--<td><asp:LinkButton runat="server" ID="btnUpdate" OnClick="btnUpdateNote_Click"  CommandName="UpdateNotes" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "JobID") %>'>Update</asp:LinkButton></td>--%>
                                  <td><a href='JobDetails.aspx?JID=<%# Eval("JobID") %>&CID=<%#Eval("CustomerID")%>'>DETAILS</a></td>
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
                "order": [[1, "desc"]]
            });
         });
         $(document).ready(function () {
             $.fn.dataTable.moment('M/D/YYYY');
             $('#dataTable1').DataTable({
                 "order": [[1, "desc"]]
             });
         });
         $(document).ready(function () {
             $.fn.dataTable.moment('M/D/YYYY');
             $('#dataTable2').DataTable({
                 "order": [[1, "desc"]]
             });
         });

         $(document).ready(function () {
             $.fn.dataTable.moment('M/D/YYYY');
             $('#dataTable3').DataTable({
                 "order": [[1, "desc"]]
             });
         });



         $('input[name="chkShipped"]').click(function () {
             if (!$(this).is(':checked')) {     //If Unchecked
                 $(this).closest('tr').find('td .txtWidth').val("");
                 var hfvalue = $(this).parents('tr').find('td input[type="hidden"]').val();
                 $.ajax({
                     type: "POST",
                     url: 'Job.aspx/SetShippedDateFalse',
                     data: '{JobID: ' + hfvalue + '}',
                     contentType: "application/json; charset=utf-8",
                     dataType: "json",
                     success: function (data) {
                         location.reload();
                     },
                     failure: function (response) {
                         //alert(response.d);
                     }

                 });
             }
             else {
                 var date = $(this).closest('tr').find('td .txtWidth').val(moment().format("MM/DD/YYYY"));
                 var hfvalue = $(this).parents('tr').find('td input[type="hidden"]').val();
                 $.ajax({
                     type: "POST",
                     url: 'Job.aspx/UpdateShippedDate',
                     data: '{JobID: ' + hfvalue + '}',
                     contentType: "application/json; charset=utf-8",
                     dataType: "json",
                     success: function (data) {
                         location.reload();
                     },
                     failure: function (response) {
                         //alert(response.d);
                     }

                 });
             }
         });

<%--         $(document).ready(function () {
             var CID = window.location.href.slice(window.location.href.indexOf('=') + 1)
             var href = $("#<%=toggleNavColor.ClientID%>").attr('href');
             var username = '<%= Session["CID"] %>';
             if (username != null && username != "" && username !="0") {
                
                     $("#<%=toggleNavColor.ClientID%>").attr("href", "JobDetails.aspx?CID=" + username);
                
             }
             else {
                 
                     $("#<%=toggleNavColor.ClientID%>").attr("href", "JobDetails.aspx");
                
             }
         });--%>

    </script>


    
</asp:Content>
