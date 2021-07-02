<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" validateRequest="false" CodeBehind="ProductionDesign.aspx.cs" Inherits="USGClient.Admin.ProductionDesign" %>


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
    /*width:275px;*/
}

.thstyle2 {
    color: white;
}
td.arrow
{
    cursor:pointer;
}

 </style>
    <style>
       @media  print {

           table {      
    page-break-inside: avoid;
}
    #tablerow1 {
        background-color: #172C55 !important;
        -webkit-print-color-adjust: exact;
    }
    th{
        background-color: #172C55 !important;
    }
    /*#tablerow2 {
        background-color: #C19744 !important;
        -webkit-print-color-adjust: exact;
    }
    #tablerow3 {
        background-color: #C19744 !important;
        -webkit-print-color-adjust: exact;
    }*/
}
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

<%--     <input type="button" runat="server" value="" id="primaryButton" onserverclick="btnFile_Click" style="display:none"/>--%>
<%--    <span id="spnFilePath" runat="server" Value=""></span>--%>
     <asp:LinkButton class="btn btn-dark" OnClick="btnFile_Click" ClientIDMode="static"  CommandArgument ="" runat="server" id="primaryButton"  style="display:none"/>
    <asp:HiddenField ID="hfvalue" runat="server" Value=""/>
        <asp:HiddenField ID="hfFilePath" runat="server" Value=""/>


    <uc1:AdminDetails runat="server" ID="AdminDetails" />
     <asp:Button ID="Button1" runat="server" CssClass="btn btn-dark " ClientIDMode="Static" Text="Print" OnClientClick="printDiv('PrintArea');return false;" />
    <button id="Button2" runat="server" class="btn btn-dark " onclick="CreatePDFfromHTML();return false;"><i class="fa fa-file-pdf-o fa-2" aria-hidden="true"></i> Export As PDF</button>
     <button id="btnExport" runat="server"  onserverclick="btnExport_Click" class="btn btn-dark" ><i class="fa fa-file-excel-o fa-2" aria-hidden="true"></i> Export To Excel</button>
    <button runat="server" id="BacktoJobs" class="btn btn-dark" title="Back" onclick="JavaScript:window.history.back(1);return false;"><i class="fa fa-arrow-circle-left fa-2" aria-hidden="true"></i> Back</button>
<%--     <input class="form-control"  type="file" id="File2"  runat="server" TabIndex="5"/>--%>
<%--         <input class="form-control"  type="file" id="File1"  runat="server" TabIndex="5"/>--%>

<%--    <asp:LinkButton class="btn btn-dark" OnClick="btnAddRow_Click" runat="server" >Add</asp:LinkButton>--%>

    <asp:HiddenField ID="hfGridHtml" runat="server" />
      <div class="card mb-3">
          <div class="card-body bg-white html-content" id="PrintArea" >
    <div class="divstyle">
    <img id="logo" runat="server" class="LogoSize float-left" visible="false"/><label id="lblCostumerName" runat="server" class="float-left" style="text-transform: uppercase;font-weight: bold;line-height:35px;padding-left:20px"></label>
    <label id="lblSummary" runat="server" style="font-size: 25px;font-weight: bold;" class="labelstyle"></label>
    <label id="lblshipDate" runat="server" class="float-right" style="font-weight: bold;"></label>

        </div>
    <hr style="border: 1px solid;">
    <asp:Label runat="server" ID="lblMessage" ></asp:Label>

    <div>
                    
        <label id="lblOrderNumber" runat="server" style="font-weight: bold;font-size:24px" ></label>
    <label id="lblReportDate" runat="server" class="floatRight"></label>
    </div>
    <hr style="border: 1px solid;" class="mb-20">

        <div class="card-body bg-white" >
            <div class="table-responsive">
                
                <table class="table table-bordered table-striped" id="dataTable2"  width="100%">
                    <thead>
                          
                    </thead>
                    <tbody>
                    <asp:Repeater runat="server" ID="rptOrderEntry">
                          <ItemTemplate> 
<%--                              <asp:TextBox runat="server" type="hidden" id="txtJobPromoOrderID" value='<%# Eval("JobOrderPromoID")%>' > </asp:TextBox>--%>
                        <tr Id="HeaderId" class ="header">
                            <td colspan="5" class="noChange"><asp:Label ID="lbSignType" runat="server"><strong><%# Eval("SignType") %></strong></asp:Label></td>

                        </tr>
                         <tr>
                            <th>&nbsp;</th>
                            <th>Promotion</th>
                            <th>Promotion Memo </th>
                            <th>Production Memo </th>
                            <th>Upload Image </th>
                              
                        </tr>
<%--                              <tr Id="HeaderId" class ="header">--%>
                            <tr >

                            <td class="arrow"><asp:Label ID="lblArrow" runat="server"><span><i class="fas fa-chevron-right"></i></span></asp:Label></td>
                            <td class="noChange"><asp:Label ID="lbPromotion" runat="server"><%# Eval("Promotion") %></asp:Label></td>
                            <td class="noChange"><asp:Label ID="lbPromotionMemo" runat="server" ></asp:Label><%# Eval("PromotionMemo") %></td>
                            <td class="noChange"><asp:Label ID="lbProductionMemo" placeholder="Quantity"  runat="server" ><%# Eval("ProductionMemo") %></asp:Label></td>
                            <td class="noChange">
                            <input class='form -control'  type='file' id='File1'  runat='server' />
                            <img class='img-thumbnail' style="width:100px; height:100px;display:<%# Eval("ImageThumbnailURL").ToString() == "0"  ? "none" :"revert" %>" src=<%# Eval("ImageThumbnailURL") %> />
                                
                                <asp:LinkButton runat="server" ID="btnAddFile" ClientIDMode="Static"  CommandArgument ='<%# Eval("JobOrderPromoID") %>' OnClick="btnFile_Click" CssClass="btn btn-dark">&nbsp;Add File</asp:LinkButton>
                            </td>
                            
                        </tr>
                        <tr class="hideTr">
                            <th colspan="1">&nbsp;</th>
                            <th colspan="1">Materials</th>
                            <th colspan="1">Laminant </th>
                            <th colspan="1">Finishings 1 </th>
                            <th colspan="1">Finishings 2 </th>

                        </tr>

                        <tr class="hideTr">
                            <td></td>
                            <td><asp:Label ID="lbmaterials"     runat="server" ><%# Eval("MaterialItem") %> </asp:Label></td>
                            <td><asp:Label ID="lbLaminant"      runat="server" ><%# Eval("LaminantItem") %> </asp:Label>  </td>
                            <td><asp:Label ID="lbFinishings1"   runat="server" ><%# Eval("Finishing1Item") %> </asp:Label></td>
                            <td><asp:Label ID="lbFinishings2"   runat="server" ><%# Eval("Finishing2Item") %> </asp:Label></td>

                           
                        </tr>
                         <tr class="hideTr">
                             <td></td>
                             <td><strong>Production Notes</strong></td>
                         <td colspan="3"><asp:Label ID="txtProductionNote" runat="server"   > <%# Eval("AdditionalProductionNotes") %></asp:Label></td>
                         
                         </tr>
                         
                        </ItemTemplate>
                      </asp:Repeater> 
                    </tbody>
                      
                         
                </table>
                </div>
          </div>



              <div class="table-responsive  " >
                  <asp:PlaceHolder ID = "PlaceHolder1" runat="server" />
            </div>
              </div>
          </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jspdf/1.5.3/jspdf.min.js"></script>
<script type="text/javascript" src="https://html2canvas.hertzen.com/dist/html2canvas.js"></script>
    <script src="../js/printThis.js"></script>
    <script>

        function goBack() {
            window.history.back();
        }


        $('#dataTable2').each(function () {

            var row = $(this).find('tr');

            row[0].style.backgroundColor = "#ffffff";
            row[1].style.backgroundColor = "#ffffff";
            row[2].style.backgroundColor = "#ffffff";
            row[3].style.backgroundColor = "#ffffff";
            row[4].style.backgroundColor = "#ffffff";
            row[5].style.backgroundColor = "#ffffff";


            if (row.length > 6) {
                row[6].style.backgroundColor = "#EEE";
                row[7].style.backgroundColor = "#EEE";
                row[8].style.backgroundColor = "#EEE";
                row[9].style.backgroundColor = "#EEE";
                row[10].style.backgroundColor = "#EEE";
                row[11].style.backgroundColor = "#EEE";

                if (row.length > 12) {
                    for (var i = 12; i < row.length; i++) {
                        var b = row[i].rowIndex;
                        var a = b % 12;
                        if (a <= 5) {
                            row[i].style.backgroundColor = "#ffffff";

                        }
                        else if (a >= 6 && a <= 11) {
                            row[i].style.backgroundColor = "#EEE";

                        }

                    }

                }

            }
            //row[9].style.backgroundColor = "#EEE"; 



        }); 




       


        $('.hideTr').slideUp(50); 
        function printDiv(PrintArea) {
            $("#PrintArea").printThis(
               
            );
            return false;
        }
        $('.arrow').click(function () {
            var a = $(this).closest('tr');

            //$(this).find('span').text(function (_, value) { return value == '↓' ? '→   ' : '↓' });
            var b = $(this).find('span').find('i').hasClass("fas fa-chevron-right");
            if (b == true) {
                $(this).find('span').find('i').removeClass('fas fa-chevron-right');
                $(this).find('span').find('i').addClass('fas fa-chevron-down');

            }
            else {
                $(this).find('span').find('i').removeClass('fas fa-chevron-down');
                $(this).find('span').find('i').addClass('fas fa-chevron-right');

            }

            $(a).nextUntil('tr.header').slideToggle(600);


        });


        //Create PDf from HTML...
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
                    pdf.addImage(imgData, 'JPG', top_left_margin, -(PDF_Height * i) + (top_left_margin * 4), canvas_image_width, canvas_image_height);
                }
                pdf.save(<%=Request.QueryString["CID"]%>+"_ProductOrderSummary.pdf");
        //$(".html-content").hide();

        return false;
    });
        }
        //$("td:empty")
        //    .text("N/A");
    </script>
</asp:Content>
