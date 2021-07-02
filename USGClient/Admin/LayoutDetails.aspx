<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="LayoutDetails.aspx.cs" Inherits="USGClient.Admin.LayoutDetails" %>

<%@ Register Src="~/Controls/AdminDetails.ascx" TagPrefix="uc1" TagName="AdminDetails" %>
<%--<%@ Register Src="~/Controls/AdminClientDetailsControl.ascx" TagPrefix="uc1" TagName="AdminClientDetailsControl" %>--%>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <uc1:AdminDetails runat="server" ID="AdminDetails" />
     <div id="myModalImage" class="modalImage">
                <span class="closeImage">&times;</span>
                <img class="modalImage-content" id="img01" />
                <div id="caption"></div>
            </div>
    <%--<uc1:AdminClientDetailsControl runat="server" ID="AdminClientDetailsControl" />--%>
    <div class="card mb-3" runat="server" id="divClientUsers">
        <div class="card-header">
          <img id="logo" runat="server" class="LogoSize"/> <span class="card-title">Layout Notes</span>
           <%-- <div  class="float-right">--%>
                <div class="float-right "><a class="btn btn-dark" href="LayoutUpload.aspx?CID=<%=Request.QueryString["CID"] %>&CUID=<%=Request.QueryString["CUID"] %>&MID=<%=Request.QueryString["MID"] %>" id="toggleNavColor">Add Note</a></div>
            <%--</div>--%>
        </div>
        <div class="card-body" style="background-color: white !important">
          <div class="table-responsive">
              <table class="table table-bordered table-striped" id="dataTable" width="100%">
                  <thead>
                      <tr>
                          <th>Date</th>
                          <th>From</th>
                          <th>Notes</th>
                          <th>Image</th>
                          <th>Delete</th>
                      </tr>
                  </thead>
                  <tbody>
                      <asp:Repeater runat="server" ID="rptList" OnItemCommand="rptList_ItemCommand">
                          <ItemTemplate>
                              <tr>
                                  <td><%# Eval("CreateDate") %></td>
                                  <td><%# GetFrom(Eval("MockupNoteTypeID"),Eval("ApproverFirstName"),Eval("ApproverLastName"),Eval("AdministratorID").ToString())  %></td>
                                  <td><%# Eval("Notes") %></td>
                                  <td><%# GetImage(Eval("ImageUrl"), Eval("MockupID")) %></td>
                                  <td><asp:LinkButton runat="server" ID="lnkDelete" style="color:#172C55" Text="DELETE" CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "MockupNoteID") %>'></asp:LinkButton></td>
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
   <%-- <script>
    // Call the dataTables jQuery plugin
        $(document).ready(function () {
            //$.fn.dataTable.moment('M/D/YYYY');
            $('#dataTable').DataTable({
                "order": [[0, "asc"]]
            });
        });
    </script>--%>

    <link href="../Vendor/bootstrap/css/ModelDialog.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script>
        $(document).ready(function () {
            $(".img-thumbnail").on("click",function(e){
              e.preventDefault();
            debugger;
                var modal = document.getElementById("myModalImage");
                // Get the image and insert it inside the modal - use its "alt" text as a caption
                var img = document.getElementById(e.target.id);
                var modalImg = document.getElementById("img01");
                var captionText = document.getElementById("caption");
                //img.onclick = function () {
                modal.style.display = "block";
                modalImg.src = this.src;
                    //captionText.innerHTML = this.alt;
                //}
                // Get the <span> element that closes the modal
                var span = document.getElementsByClassName("closeImage")[0];

                // When the user clicks on <span> (x), close the modal
                span.onclick = function () {
                    modal.style.display = "none";
                }
            //}
            });
             });
    </script>
</asp:Content>