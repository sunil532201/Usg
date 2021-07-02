<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="ShippingTOS.aspx.cs" Inherits="USGClient.Admin.ShippingTOS" ValidateRequest="false" %>
<%@ Register Src="~/Controls/AdminDetails.ascx" TagPrefix="uc1" TagName="AdminDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .tablestyle {
    font-family: arial, sans-serif;
    border-collapse: collapse;
    width: 100%;
}

.tdstyle, .thstyle {
    border: 1px solid #dddddd;
    text-align: left;
    padding: 8px;
}

.th {
    color: white;
}

    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
        <uc1:AdminDetails runat="server" ID="AdminDetails" />

    <asp:Button ID="Button1" runat="server" CssClass="btn btn-dark " ClientIDMode="Static" Text="Print" OnClientClick="printDiv('PrintArea');return false;" />
    <button id="Button2" runat="server" class="btn btn-dark "   onclick="CreatePDFfromHTML();return false;"><i class="fa fa-file-pdf-o fa-2" aria-hidden="true"></i> Export As PDF</button>
    <button id="btnExport" runat="server"  onserverclick="btnExport_Click" class="btn btn-dark" ><i class="fa fa-file-excel-o fa-2" aria-hidden="true"></i> Export To Excel</button>
    <button runat="server" id="BacktoJobs" class="btn btn-dark" title="Back" onclick="JavaScript:window.history.back(1);return false;"><i class="fa fa-arrow-circle-left fa-2" aria-hidden="true"></i> Back</button>
     <asp:HiddenField ID="hfGridHtml" runat="server" />

    <div class="card mb-3">
    <div class="card-body bg-white html-content" id="PrintArea" >
        <div style="display: flow-root">
            <img id="logo" runat="server" class="LogoSize float-left"/>
            <label id="lblCostumerName" runat="server" class="float-left" style="text-transform: uppercase;font-weight: bold;font-size:20px"></label>
             <label id="lblOrderNumber" runat="server" class="float-right" style="font-size:23px;font-weight:bold;" ></label>
        </div>
    <hr style="border: 1px solid;"/>
    <div>
        <label id="lblSummary" runat="server" style="font-size: 25px;font-weight: bold;" class="labelstyle"></label>
        <label id="lblshipDate" runat="server" class="float-right" style="font-weight: bold;font-size:20px"></label>
    </div>
    <hr style="border: 1px solid;" />

              <div class="table-responsive center ">
                  <asp:PlaceHolder ID = "PlaceHolder1" runat="server" />
            </div>
        <label id="lblReportDate" runat="server" class="float-right" style="font-size:12px;font-weight:bold"></label>
      
              </div>
          </div>
    
  
    
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
   <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jspdf/1.5.3/jspdf.min.js"></script>
<script type="text/javascript" src="https://html2canvas.hertzen.com/dist/html2canvas.js"></script>
    <script src="../js/printThis.js"></script>
    <script>
       //$(window).on('load', function() {
       //     debugger
       //     //$("#campaign-alert").show();
       //     $('#ExcelReportHeaderRow').attr('style','display: none');
       // });
        
       
        function printDiv(PrintArea) {
            debugger
            $("#PrintArea").printThis({

            }
            );
            return false;
        }

        function CreatePDFfromHTML() {
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
            pdf.addImage(imgData, 'JPG', top_left_margin, -(PDF_Height*i)+(top_left_margin*4),canvas_image_width,canvas_image_height);
        }
        pdf.save(<%=Request.QueryString["CID"]%>+"_ShippingTotalOrderSummary.pdf");
        return false;
    });
        }
       
</script>
</asp:Content>
