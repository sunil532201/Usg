<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="PricedTOS.aspx.cs" Inherits="USGClient.Admin.PricedTOS" ValidateRequest="false" %>

<%@ Register Src="~/Controls/AdminDetails.ascx" TagPrefix="uc1" TagName="AdminDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <style>
        .tableStyle {
    font-family: arial, sans-serif;
    border-collapse: collapse;
    width: 100%;
}

.tdstyle, .thstyle {
    border: 1px solid #dddddd;text-align: left;padding: 8px;
}

.thstyle2 {
    color: white;
}

.DropDown{
          max-width:300px;
          float:right;
      }
         </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <uc1:AdminDetails runat="server" ID="AdminDetails" />
    <div runat="server" id="DisplayStoresBtn">
    <button  type="button" class="btn btn-dark" value="Select All" id="Select"><i class="fa fa-check-square-o fa-2" aria-hidden="true"></i>Select All</button>
    <button type="button"  class="btn btn-dark" value="Deselect All" id="Deselect"><i class="fa fa-square-o fa-2" aria-hidden="true"></i>Deselect All</button>
    <asp:Button ID="btnPreview" runat="server" CssClass="btn btn-dark" ClientIDMode="Static" Text="Preview" OnClick="btnPreview_Click" />
        <button runat="server" id="Button3" class="btn btn-dark no-padding" title="Back" onclick="JavaScript:window.history.back(1);return false;"><i class="fa fa-arrow-circle-left fa-2" aria-hidden="true"></i> Back</button>
    </div>
    <div runat="server" id="DisplayPrintBtn">
    <asp:Button ID="Button1" runat="server" CssClass="btn btn-dark " ClientIDMode="Static" Text="Print" OnClientClick="printDiv('printPreview');return false;" />
    <%--<button id="Button2" runat="server" class="btn btn-dark "   onclick="CreatePDFfromHTML();return false;"><i class="fa fa-file-pdf-o fa-2" aria-hidden="true"></i> Export As PDF</button>--%>
    <button id="Button2" runat="server" class="btn btn-dark " onserverclick="Button2_Click"><i class="fa fa-file-pdf-o fa-2" aria-hidden="true"></i> Export As PDF</button>    
    <button id="btnExport" runat="server"  onserverclick="btnExport_Click" class="btn btn-dark" ><i class="fa fa-file-excel-o fa-2" aria-hidden="true"></i> Export To Excel</button>
    <button runat="server" id="BacktoJobs" class="btn btn-dark" title="Back" onclick="JavaScript:window.history.back(1);return false;"><i class="fa fa-arrow-circle-left fa-2" aria-hidden="true"></i> Back</button>
    <asp:HiddenField ID="hfGridHtml" runat="server" />
        </div>

<div class="card mb-3 mb-20" id="DivStores" runat="server">
<div class="card-header">
<img id="logo" runat="server"  class="LogoSize"/><span class="card-title"> Stores</span>&nbsp;&nbsp;&nbsp;
     <asp:DropDownList ID="ddlPreset" runat="server" OnSelectedIndexChanged="ddlPreset_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control DropDown">
    </asp:DropDownList>
</div>
<div class="card-body bg-white" >
<asp:PlaceHolder ID = "PlaceHolder2" runat="server" />
</div>
</div>

    <asp:HiddenField  ID="hfStoreNumbers" ClientIDMode="Static" runat="server"/>
      <asp:HiddenField  ID="hfStoreIDs" ClientIDMode="Static" runat="server"/>

 <div class="card mb-3" runat="server" id="PreviewDiv">
     <div id="printPreview">
    <div class="card-body bg-white html-content" runat="server" id="PrintArea" >
        
    <div class="table-responsive center ">
        <asp:PlaceHolder ID = "PlaceHolder1" runat="server" />
    </div>
        <label id="lblReportDate" runat="server" class="float-right" style="font-size:12px;font-weight:bold"></label>
    </div>
         </div>
</div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jspdf/1.5.3/jspdf.min.js"></script>
    <script type="text/javascript" src="https://html2canvas.hertzen.com/dist/html2canvas.js"></script>
    <script src="../js/printThis.js"></script>
    <script>
        function printDiv(printPreview) {
            debugger
            $("#printPreview").printThis({

            }
            );
            return false;
        }

        <%--function CreatePDFfromHTML() {
            var HTML_Width = $(".html-content").width();
            var HTML_Height = $(".html-content").height();
            var top_left_margin = 15;
            var PDF_Width = HTML_Width + (top_left_margin * 2);
            var PDF_Height = (PDF_Width * 1.5) + (top_left_margin * 2);
            var canvas_image_width = HTML_Width;
            var canvas_image_height = HTML_Height;

            var totalPDFPages = Math.ceil(HTML_Height / PDF_Height) - 1;

            html2canvas($(".html-content")[0]).then(function (canvas) {
                var imgData = canvas.toDataURL("image/jpeg", 1.0);
                var pdf = new jsPDF('p', 'pt', [PDF_Width, PDF_Height]);
                pdf.addImage(imgData, 'JPG', top_left_margin, top_left_margin, canvas_image_width, canvas_image_height);
                for (var i = 1; i <= totalPDFPages; i++) {
                    pdf.addPage(PDF_Width, PDF_Height);
                    pdf.addImage(imgData, 'JPG', top_left_margin, -(PDF_Height * i) + (top_left_margin * 4), canvas_image_width, canvas_image_height);
                }
                pdf.save(<%=Request.QueryString["CID"]%>+"_PricedTotalOrderSummary.pdf");
                return false;
            });
        }--%>
       
</script>

    <script type="text/javascript">
        // Listen for click on toggle checkbox
        $('#Select').click(function (event) {
            var someObj = {};
            someObj.SelectedStoreNumbers = [];
            someObj.SelectedStoreIds = [];
                $(':checkbox').each(function () {
                    var $this = $(this);
                    this.checked = true;
                    someObj.SelectedStoreNumbers.push($this.attr("value"));
                    someObj.SelectedStoreIds.push($this.attr("id"));
                });
           
            $("#hfStoreNumbers").val(someObj.SelectedStoreNumbers);
            $("#hfStoreIDs").val(someObj.SelectedStoreIds);  

            console.log($('#hfStoreNumbers').val());
            console.log($('#hfStoreIDs').val());
            //return flase;
        });

        $('#Deselect').click(function (event) {
            var someObj = {};
            someObj.SelectedStoreNumbers = [];
            someObj.SelectedStoreIds = [];
           
                $(':checkbox').each(function () {
                    this.checked = false;
                });
            $("#hfStoreNumbers").val(someObj.SelectedStoreNumbers);
            $("#hfStoreIDs").val(someObj.SelectedStoreIds);  

            console.log($('#hfStoreNumbers').val());
            console.log($('#hfStoreIDs').val());
            //return false;
        });

        $('.singleCheckbox').click(function (event) {
            debugger
            var someObj = {};
            someObj.SelectedStoreNumbers = [];
            someObj.SelectedStoreIds = [];
            $("input:checkbox").each(function () {
                var $this = $(this);

                if ($this.is(":checked")) {
                    someObj.SelectedStoreNumbers.push($this.attr("value"));
                    someObj.SelectedStoreIds.push($this.attr("id"));
                }
                $("#hfStoreNumbers").val(someObj.SelectedStoreNumbers);
                $("#hfStoreIDs").val(someObj.SelectedStoreIds);

                console.log($('#hfStoreNumbers').val());
                console.log($('#hfStoreIDs').val());
            });

        });
</script>
</asp:Content>
