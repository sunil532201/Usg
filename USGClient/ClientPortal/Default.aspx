<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/ClientPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="USGClient.ClientPortal.Default" %>
<%@ Register src="../Controls/MockupDisplayControl.ascx" tagname="MockupDisplayControl" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../Vendor/bootstrap/css/ModelDialog.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphPageTitle" runat="server">
    <h5>Approval System</h5>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadCrumbs" runat="server">

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cphMainContent" runat="server">
   
    <div id="myModalImage" class="modalImage">
        <span class="closeImage">&times;</span>
        <img class="modalImage-content" id="img01" />
        <div id="caption"></div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <uc1:MockupDisplayControl ID="MockupDisplayControl1" runat="server" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphFooter" runat="server">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
<script>
    $(document).ready(function () {
        $(".img-thumbnail").on("click", function (e) {
            e.preventDefault();
            debugger;
            var modal = document.getElementById("myModalImage");
            // Get the image and insert it inside the modal - use its "alt" text as a caption
            var img = document.getElementById(e.target.id);
            var modalImg = document.getElementById("img01");
            var captionText = document.getElementById("caption");
            //img.onclick = function () {
            modal.style.display = "block";
            var data  = (this.href).toString();
            var mockupimage = data.replaceAll("@","'");
            modalImg.src = mockupimage;
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


