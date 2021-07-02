<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="JobDashboard.aspx.cs" Inherits="USGClient.Admin.JobDashBoard" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <%--<uc1:AdminDetails runat="server" ID="AdminDetails" />--%>
    <ul class="nav nav-pills mb-20" id="jobUl"  runat="server" visible="false">
        <li runat="server" id="lblActive" class="nav-item">
            <asp:LinkButton runat="server" ID="lnkActive" OnClick="lnkActive_Click"  Text="Active"></asp:LinkButton></li>
        <li runat="server" id="lblShipped" class="nav-item" >
            <asp:LinkButton runat="server" ID="lnkShipped" OnClick="lnkShipped_Click" Text="Shipped"></asp:LinkButton></li>
        <li runat="server" id="lblArchive" class="nav-item">
            <asp:LinkButton runat="server" ID="lnkArchive" OnClick="lnkArchive_Click"  Text="Archived"></asp:LinkButton></li>
    </ul>
     <ul class="nav nav-pills mb-20" id="jobUlByID" runat="server" visible="false">
        <li runat="server" id="lblActiveByCustID" class="nav-item">
            <asp:LinkButton runat="server" ID="lnkActiveByCustID" OnClick="lnkActiveByCustID_Click" Text="Active"></asp:LinkButton></li>
        <li runat="server" id="lblShippedByCustID" class="nav-item" >
            <asp:LinkButton runat="server" ID="lnkShippedByCustID" OnClick="lnkShippedByCustID_Click" Text="Shipped"></asp:LinkButton></li>
        <li runat="server" id="lblArchiveByCustID" class="nav-item">
            <asp:LinkButton runat="server" ID="lnkArchiveByCustID" OnClick="lnkArchiveByCustID_Click"  Text="Archived"></asp:LinkButton></li>
    </ul>

    <asp:MultiView ID="MultiView1" runat="server">
         <asp:View ID="Jobs" runat="server">
    <div class="card mb-3">
        <div class="card-header">
           <%--<img id="logo" runat="server" class="LogoSize"/>--%> <span class="card-title">  Job Book</span>
                  <div  style="float: right;" class="card-title">
                    <div style="float:left; padding-right: 15px;"><a class="btn btn-dark mr-30" id="toggleNavColor" runat="server">Create Job</a></div>
                 </div>  
        </div>
        <div class="card-body bg-white">
          <div class="table-responsive">
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
                      <asp:Repeater runat="server" ID="rptJob"  >
                          <ItemTemplate>
                              <tr>
                                  <td><%#(Eval("NoCharge").ToString()== "True") ?"NC":""%></td>
                                  <td><%# Eval("Prefix")+"-"+Eval("JobID") %><asp:HiddenField ID="hfvalue" runat="server" Value='<%# Eval("JobID")%>' /></td>
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
             </asp:View>
         <asp:View ID="JobsbyID" runat="server">
              <div class="card mb-3">
        <div class="card-header">
            <i class="fa fa-table "></i><span class="card-title">Job Book</span>
              <div  style="float: right;" class="card-title">

            <div style="float:left; padding-right: 15px;"><a class="btn btn-dark mr-30" href="JobDetails.aspx" id="A1" runat="server">Create Job</a></div>
              <div style ="float:left; padding-top: 5px;">
                <i class="fa fa-user-circle"></i>&nbsp;
                <%=Session["Name"]%>
             </div>      
              </div>
        </div>
        <div class="card-body bg-white">
          <div class="table-responsive">
              <table class="table table-bordered table-striped" id="dataTable" width="100%" >
                  <thead>
                      <tr>
                          <td>No Charge</td>
                          <th>Job Number</th>
                          <th>Description</th>
                          <th>Order Date</th>
                          <th>Display Date</th>
                          <th>Shipped</th>
                          <th>Date Shipped</th>
                          <th>Update</th>
                          <th>Details</th>
                      </tr>
                  </thead>

                  <tbody>
                      <asp:Repeater runat="server" ID="rptJobsbyID" >
                          <ItemTemplate>
                              <tr>
                                  <td><%#(Eval("NoCharge").ToString()== "True") ?"NC":""%></td>
                                  <td><%# Eval("JobID") %><asp:HiddenField ID="hfvalue" runat="server" Value='<%# Eval("JobID")%>' /></td>
                                  <td><%# Eval("Description") %></td>
                                  <td><%# Eval("OrderDate","{0: MM/dd/yyyy}") %></td>
                                  <td><%# Eval("DisplayDate","{0: MM/dd/yyyy}") %> </td>
                                  <td><%#(Eval("Shipped").ToString()== "True") ? "<input type='checkbox' name='chkShipped'   runat='server' checked>":"<input type='checkbox' name='chkShipped'   runat='server' >" %></td>
                                  <td><asp:TextBox ID='txtShippedDate' Text='<%# Eval("DateShipped","{0: MM/dd/yyyy}") %>' runat="server" CssClass="form-control txtWidth"  ></asp:TextBox>  </td>

                                  <td><asp:LinkButton runat="server" ID="btnUpdate" OnClick="btnUpdateNote_Click"  CommandName="UpdateNotes" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "JobID") %>'>Update</asp:LinkButton></td>
                                  <td><a href='JobDetails.aspx?JID=<%# Eval("JobID") %>'>DETAILS</a></td>
                              </tr>
                          </ItemTemplate>
                      </asp:Repeater>
                  </tbody>
              </table>
            </div>
        </div>
    </div>
             </asp:View>
       </asp:MultiView>
    
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

         $(document).ready(function () {
             var CID = window.location.href.slice(window.location.href.indexOf('=') + 1)
             var href = $("#<%=toggleNavColor.ClientID%>").attr('href');
             var username = '<%= Session["CID"] %>';
             if (username != null && username != "" && username !="0") {
                
                     $("#<%=toggleNavColor.ClientID%>").attr("href", "JobDetails.aspx?CID=" + username);
                
             }
             else {
                 
                     $("#<%=toggleNavColor.ClientID%>").attr("href", "JobDetails.aspx");
                
             }
         });
    </script>
</asp:Content>
