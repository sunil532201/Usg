<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="Layouts.aspx.cs" Inherits="USGClient.Admin.Layouts" %>

<%--<%@ Register Src="~/Controls/AdminClientDetailsControl.ascx" TagPrefix="uc1" TagName="AdminClientDetailsControl" %>--%>
<%@ Register Src="~/Controls/AdminDetails.ascx" TagPrefix="uc1" TagName="AdminDetails" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <uc1:AdminDetails runat="server" ID="AdminDetails" />
    <%--<uc1:AdminClientDetailsControl runat="server" id="AdminClientDetailsControl" />--%>
    <div class="card mb-3">
        <div class="card-header">
            <img id="logo" runat="server" class="LogoSize"/><span class="card-title"> Layouts</span>
            <div  style="float: right;" class="card-title">
                <div style="float:left; padding-right: 15px;"><a class="btn btn-dark" href='LayoutUpload.aspx?CID=<%=Request.QueryString["CID"] %>&CUID=<%=Request.QueryString["CUID"] %>' id="toggleNavColor">Add New Layout</a></div>
                    
            </div>
        </div>
        <div class="card-body" style="background-color: white !important">
            
          <div class="table-responsive">
              <a href="#" runat="server" onclick="return confirm('Are you sure you want to delete this layout?');" class="btn btn-danger" style="float:right" onserverclick="CheckedDelete_Click">Delete Checked</a>
              <table class="table table-bordered table-striped" id="dataTable" width="100%" cellspacing="0">
                  <thead>
                      <tr>
                          <th>Create Date</th>
                          <th>Order</th>
                          <th>Title</th>
                          <th>Promo Month</th>
                          <th>Promo Year</th>
                          <th>Approval Date</th>
                          <th>First Name</th>
                          <th>Last Name</th>
                          <th>View</th>
                          <th><asp:CheckBox ID="chkHeader" runat="server" /></th>
                      </tr>
                  </thead>
                  <tbody>
                      <asp:Repeater runat="server" ID="rptList" OnItemCommand="rptList_ItemCommand">
                          <ItemTemplate>
                              <tr>
                                  <td><%# Convert.ToDateTime(Eval("CreateDate")).ToString("MM/dd/yyyy") %></td>
                                  <td><%# Eval("OrderNumber") %></td>
                                  <td><%# Eval("Title") %></td>
                                  <td><%# Eval("PromoMonth") %></td>
                                  <td><%# Eval("PromoYear") %></td>
                                  <td><%# GetDate(Convert.ToDateTime(Eval("ApprovalDate")).ToString("MM/dd/yyyy")) %></td>
                                  <td><%# Eval("ApproverFirstName") %></td>
                                   <td><%# Eval("ApproverLastName") %></td>
                                  <td><a href='LayoutDetails.aspx?CID=<%=Request.QueryString["CID"] %>&CUID=<%# Eval("CustomerID") %>&MID=<%# Eval("MockupID") %>' style="color:#172C55">DETAILS</a></td>
                                 <%-- <td><asp:LinkButton runat="server" ID="lnkDelete" Text="DELETE" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "MockupID") %>' onclientclick="return confirm('Are you sure you want to delete this layout?');"></asp:LinkButton></td>--%>
                                  <td><asp:CheckBox type="checkbox"  ID="chkRow" runat="server" /><asp:HiddenField ID="hfValue" runat="server" Value='<%# Eval("MockupID") %>'/></td>
                              </tr>
                          </ItemTemplate>
                      </asp:Repeater>
                  </tbody>
              </table>
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
                "order": [[0, "desc"]]
            });
        });

        $(function () {
        $("#dataTable [id*=chkHeader]").click(function () {
            if ($(this).is(":checked")) {
                $("#dataTable [id*=chkRow]").attr("checked", "checked");
            } else {
                $("#dataTable [id*=chkRow]").removeAttr("checked");
            }
        });
        $("#dataTable [id*=chkRow]").click(function () {
            if ($("#dataTable [id*=chkRow]").length == $("#dataTable [id*=chkRow]:checked").length) {
                $("#dataTable [id*=chkHeader]").attr("checked", "checked");
            } else {
                $("#dataTable [id*=chkHeader]").removeAttr("checked");
            }
        });
    });
    </script>
</asp:Content>
