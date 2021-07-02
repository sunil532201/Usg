<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="Liveboard.aspx.cs" Inherits="USGClient.Admin.Liveboard" %>

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

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="5000">
    </asp:Timer>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <%--<asp:Label runat="server" ID="lblMessage" ></asp:Label>--%>
            <div class="tab-content" id="myTabContentEx">
                <table class="table table-bordered table-striped" id="dataTable" width="100%">
                    <thead>
                        <tr>
                            <th id="th_custName" runat="server">Client Name</th>
                            <th>Job #</th>
                            <th>Job Name</th>
                            <th>Write Up</th>
                            <th>Design</th>
                            <th>Production</th>
                            <th>Details</th>

                        </tr>
                    </thead>

                  <tbody>
                      <asp:Repeater runat="server" ID="rptActiveJob">
                          <ItemTemplate>
                              <tr class="bold">
                                  <td id="td_custName" runat="server"><%# Eval("CustomerName") %></td>
                                  <td><%# Eval("Prefix")+"-"+Eval("JobID") %><asp:HiddenField ID="hfvalue" runat="server" Value='<%# Eval("JobID")%>' /></td>
                                  <td><%# Eval("Description") %></td>
                                  <td onclick='btnWrite_UpClick(<%# Eval("JobID") %>);' ID="WriteUp" 
                                  style="background-color:<%# (Eval("WriteUpStatus").ToString() == "0" ? "white" :Eval("WriteUpStatus").ToString() == "1" ? "yellow" : "green" )%>"  ></td>
                                  <td onclick='btnDesign_Click(<%# Eval("JobID") %>);' ID="Design" 
                                  style="background-color:<%# (Eval("DesignStatus").ToString() == "0" ? "white" :Eval("DesignStatus").ToString() == "1" ? "yellow" : "green" )%>"  ></td>
                                  <td onclick='btnProduction_Click(<%# Eval("JobID") %>);'  ID="Production" 
                                  style="background-color:<%# (Eval("Production").ToString() == "0" ? "white" :Eval("Production").ToString() == "1" ? "yellow" : "green" )%>"  ></td>
                                  <td><a href='ProductionTOS.aspx?CID=<%# Eval("CustomerID") %>&JID=<%#Eval("JobID")%>'>DETAILS</a></td>



                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </ContentTemplate>
        <Triggers>

            <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />

        </Triggers>
    </asp:UpdatePanel>




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

