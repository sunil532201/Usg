<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="USGClient.Admin.AdminDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .Width {
            width: 185px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row">
        <a href="ClientsDashBoard.aspx">
            <div class="col-sm-6 col-md-4 col-lg-2">
                <div class="card card-block Width">
                    <h5 class="m-b-0 v-align-middle text-overflow">

                        <span id="clientCount" runat="server"></span>
                    </h5>
                    <div class="small text-overflow text-muted">
                        Active Clients
                    </div>
                    <div class="small text-overflow">
                        Updated:&nbsp;<span>05:35 AM</span>
                    </div>
                </div>
            </div>
        </a>
        <a href="JobDashBoard.aspx">
            <div class="col-sm-6 col-md-4 col-lg-2">
                <div class="card card-block Width">
                    <h5 class="m-b-0 v-align-middle text-overflow">

                        <span id="jobCount" runat="server"></span>
                    </h5>
                    <div class="small text-overflow text-muted">
                        Active Jobs
                    </div>
                    <div class="small text-overflow">
                        Updated:&nbsp;<span>12:42 PM</span>
                    </div>
                </div>
            </div>
        </a>
         <a href="QuoteRequestList.aspx">
            <div class="col-sm-6 col-md-4 col-lg-2">
                <div class="card card-block Width">
                    <h5 class="m-b-0 v-align-middle text-overflow">

                        <span id="requestCount" runat="server"></span>
                    </h5>
                    <div class="small text-overflow text-muted">
                        Active Requests
                    </div>
                    <div class="small text-overflow">
                        Updated:&nbsp;<span>11:32 PM</span>
                    </div>
                </div>
            </div>
        </a>
    </div>
    <div class="button-align mb-20">
                <asp:LinkButton  CssClass="btn btn-dark mr-2" ID="lnkRefresh" TabIndex="5" runat="server" Text="Refresh" OnClick="lnkRefresh_Click"/> 
                 <a class="btn btn-dark mr-65" href="Liveboard.aspx" id="liveBoard" >Live Board</a>
        </div>
            <div class="tab-content pt-5" id="myTabContentEx">
                <table class="table table-bordered table-striped" id="dataTable" width="100%">
                    <thead>
                        <tr>
                            <th id="th_custName" runat="server">Client Name</th>
                            <th>Job #</th>
                            <th>Job Name</th>
                            <th>Write Up</th>
                            <th>Design</th>
                            <th>Production</th>
                            <th>Design</th>
                            <th>Details</th>

                        </tr>
                    </thead>

                  <tbody>
                      <asp:Repeater runat="server" ID="rptActiveJob"  >
                          <ItemTemplate>
                              <tr>
                                  <td id="td_custName" runat="server"><%# Eval("CustomerName") %></td>
                                  <td><%# Eval("Prefix")+"-"+Eval("JobID") %><asp:HiddenField ID="hfvalue" runat="server" Value='<%# Eval("JobID")%>' /></td>
                                  <td><%# Eval("Description") %></td>
                                  <td onclick='btnWrite_UpClick(<%# Eval("JobID") %>);' ID="WriteUp" 
                                  style="background-color:<%# (Eval("WriteUpStatus").ToString() == "0" ? "white" :Eval("WriteUpStatus").ToString() == "1" ? "yellow" : "green" )%>"  ></td>
                                  <td onclick='btnDesign_Click(<%# Eval("JobID") %>);' ID="Design" 
                                  style="background-color:<%# (Eval("DesignStatus").ToString() == "0" ? "white" :Eval("DesignStatus").ToString() == "1" ? "yellow" : "green" )%>"  ></td>
                                  <td onclick='btnProduction_Click(<%# Eval("JobID") %>);'  ID="Production" 
                                  style="background-color:<%# (Eval("Production").ToString() == "0" ? "white" :Eval("Production").ToString() == "1" ? "yellow" : "green" )%>"  ></td>
                                  <td><a href='ProductionDesign.aspx?CID=<%# Eval("CustomerID") %>&JID=<%#Eval("JobID")%>'>Design</a></td>

                                  <td><a href='ProductionTOS.aspx?CID=<%# Eval("CustomerID") %>&JID=<%#Eval("JobID")%>'>DETAILS</a></td>



                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>


</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <script>
        // Call the dataTables jQuery plugin
        function btnWrite_UpClick(event) {
            var hfvalue = event;

            //var hfvalue = $(event).parent().parent().find('[id*="hfvalue"]').val();
            $.ajax({
                type: "POST",
                url: 'AdminDashboard.aspx/UpdateWriteUpStatus',
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

        };
        function btnDesign_Click(event) {
            var hfvalue = event;

         //var hfvalue = $(event).parent().parent().find('[id*="hfvalue"]').val();
         $.ajax({
             type: "POST",
             url: 'AdminDashboard.aspx/UpdateDesignStatus',
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
     };
     function btnProduction_Click(event) {
         var hfvalue = event;

         //var hfvalue = $(event).parent().parent().find('[id*="hfvalue"]').val();
         $.ajax({
             type: "POST",
             url: 'AdminDashboard.aspx/UpdateProduction',
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
        };
    </script>

</asp:Content>
