<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="JobDetails.aspx.cs" Inherits="USGClient.Admin.JobDetails" %>
<%@ Register Src="~/Controls/AdminDetails.ascx" TagPrefix="uc1" TagName="AdminDetails" %>
<%--<%@ Register Src="~/Controls/JobMenuControl.ascx" TagPrefix="uc1" TagName="JobMenuControl" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
   <uc1:AdminDetails runat="server" visible="false" ID="AdminDetails" />
<%--    <uc1:JobMenuControl runat="server" ID="JobMenuControl" />--%>

      <div class="card-header">
            <img id="logo" src="https://usgfilestoragebeta.blob.core.windows.net/usgfiles/gonzologo.jpg" visible="true" runat="server" class="LogoSize"/><span class="card-title"> Job Book Details </span>&nbsp;&nbsp;&nbsp;


           <div class="float-right"> <a class="btn btn-dark mr-30" href="OrderEntry.aspx?CID=<%=Request.QueryString["CID"]%>&JID=<%=Request.QueryString["JID"]%>" id="orderEntryButton" >Start Order Entry</a></div>
             <input type="hidden" id="jobId" value="<%=Request.QueryString["JID"]%>">

            <asp:Label runat="server" ID="lblMessage"></asp:Label>
        </div>
        <div class="card-body bg-white" >
             <div class="table-responsive">
                <table class="table table-bordered table-striped">
                    <tbody>
                        <tr>
                            <td>Job Number: </td>
                            <td>
                                <asp:Label runat="server" ID="lblJobNumber" TabIndex="0"></asp:Label></td>
                            <td>Main Contact: </td>
                              <td>
                                  <asp:DropDownList ID="ddlMainContact" TabIndex="6" runat="server" CssClass="form-control"></asp:DropDownList>
                                  <%--<asp:RequiredFieldValidator ID="RequiredMainContact" EnableClientScript="True" runat="server" ControlToValidate="ddlMainContact" Display="Dynamic" ErrorMessage="Please select a Main Contact" ForeColor="Red"></asp:RequiredFieldValidator>--%>  
                              </td>   
                          
                        </tr>
                        <tr>
                            <td>Customer Name: </td>
                                <td>
                                 <asp:DropDownList ID="ddlCustomerName" TabIndex="1" runat="server" AutoPostBack="True"
                               AppendDataBoundItems="true"  onselectedindexchanged="DropDownList1_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>

                          </td>
                            <td>No Charge:</td>
                            <td><asp:CheckBox ID="chkNoCharge" TabIndex="7" CssClass="form-checkbox" runat="server" Text="No Charge " /></td>
                           
                        </tr>
                        <tr>
                            <td>Description:</td>
                            <td><asp:TextBox ID="txtDescription" TabIndex="1" runat="server" CssClass="form-control"></asp:TextBox>

                            </td>

                            <td>Void:</td>
                            <td><asp:CheckBox ID="chkVoid" TabIndex="8" CssClass="form-checkbox" runat="server" Text="Void " /></td>
                            
                        </tr>
                        <tr>
                            <td>Order Date: </td>
                            <td>
                                <asp:TextBox ID="txtOrderDate" TabIndex="2" runat="server" CssClass="form-control"></asp:TextBox>
                            </td>
                            <td>Art Only:</td>
                            <td><asp:RadioButtonList ID="rbArtonly" TabIndex="9" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Value="True">Yes</asp:ListItem>
                                    <asp:ListItem Value="False">No</asp:ListItem>
                                </asp:RadioButtonList></td>
                            
                        </tr>
                        <tr>
                             <td>Ship Date:</td>
                            <td> <asp:TextBox ID="txtShipDate"  TabIndex="3" runat="server" CssClass="form-control"></asp:TextBox></td>
                            <td>Outside Service</td>
                            <td><asp:RadioButtonList ID="rbOutsideService" TabIndex="10" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Value="True">Yes</asp:ListItem>
                                    <asp:ListItem Value="False">No</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                           <td>Display Date: </td>
                            <td><asp:TextBox ID="txtDisplayDate" TabIndex="4" runat="server" CssClass="form-control"></asp:TextBox></td>
                            <td>Monthly:</td>
                            <td><asp:RadioButtonList ID="rbMonthly" TabIndex="11" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Value="True">Monthly</asp:ListItem>
                                    <asp:ListItem Value="False">Non-Monthly</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                          <td>Shipping Type:</td>
                            <td><asp:DropDownList ID="ddlShippingType" TabIndex="5" runat="server" CssClass="form-control"></asp:DropDownList></td>
                            <td>Job Type</td>
                            <td>
                                <asp:DropDownList ID="ddlJobType" TabIndex="12" runat="server" CssClass="form-control"></asp:DropDownList>
                            </td>
                        </tr>
                    </tbody>
                </table>

                <asp:LinkButton ID="lnkUpdateJobDetails" TabIndex="13" runat="server" CssClass="btn btn-dark" OnClick="lnkUpdateJobDetails_Click" Text="Update"></asp:LinkButton>
                <asp:Button CssClass="btn btn-dark" ID="BacktoJobs" TabIndex="14" runat="server" Text="Back" OnClick="BacktoJobs_Click"/>          
<%--                <asp:Button CssClass="btn btn-dark" ID="BacktoJobs" TabIndex="11" runat="server" Text="Back" OnClick="lnkBackToJobDetails_Click" />          --%>

            </div>
             
        </div>
    <%--</div>--%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
   
  <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script>

        function goBack() {
            window.history.back();
        }

        $(document).ready(function (){

            var jobId =document.getElementById("jobId").value;
            if (jobId > 0) {
                $('[id$=orderEntryButton]').show();
            }
            else {
                $('[id$=orderEntryButton]').hide();
            }

        });
        $(document).ready(function () {
            var div = document.getElementById('cusName');
            div.setAttribute('style', 'display:none');
        });


        $(function () {
            $("#<%=txtOrderDate.ClientID%>").datepicker({
               showOn: "button",
               buttonImage: "https://jqueryui.com/resources/demos/datepicker/images/calendar.gif",
               buttonImageOnly: true,
               buttonText: "Select date"
           });
       });

        $(function () {
            $("#<%=txtDisplayDate.ClientID%>").datepicker({
                showOn: "button",
                buttonImage: "https://jqueryui.com/resources/demos/datepicker/images/calendar.gif",
                buttonImageOnly: true,
                buttonText: "Select date",
                beforeShow: function (input, inst) {
                    var rect = input.getBoundingClientRect();
                    setTimeout(function () {
                        inst.dpDiv.css({ top: rect.top + 40, left: rect.left + 0 });
                    }, 0);
                }
            })
        });
        $(function () {
            $("#<%=txtShipDate.ClientID%>").datepicker({
                 showOn: "button",
                 buttonImage: "https://jqueryui.com/resources/demos/datepicker/images/calendar.gif",
                 buttonImageOnly: true,
                 buttonText: "Select date"
             });
         });
    </script>
</asp:Content>
