<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="PricedPacker.aspx.cs" Inherits="USGClient.Admin.PricedPacker" ValidateRequest="false" %>

<%@ Register Src="~/Controls/AdminDetails.ascx" TagPrefix="uc1" TagName="AdminDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
      input[type="radio"], input[type="checkbox"] {
    margin-right: 5px;
    margin-left: 5px;
    border: solid white;
    border-width: 0 3px 3px 0;
    width: 15px;
    height: 15px;
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
    <asp:Button ID="Button1" runat="server" CssClass="btn btn-dark" ClientIDMode="Static" Text="Print" OnClientClick="printDiv();return false;" />
    <asp:Button ID="Button2" runat="server" CssClass="btn btn-dark " ClientIDMode="Static" Text="Export As PDF" OnClick="Button2_Click"   />
    <button id="btnExport" runat="server"  onserverclick="btnExport_Click" class="btn btn-dark" ><i class="fa fa-file-excel-o fa-2" aria-hidden="true"></i> Export To Excel</button>
    <button runat="server" id="BacktoJobs" class="btn btn-dark no-padding" title="Back" onclick="JavaScript:window.history.back(1);return false;"><i class="fa fa-arrow-circle-left fa-2" aria-hidden="true"></i> Back</button>
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
  <div class="card mb-3" id="PreviewDiv" runat="server">
      
    <div class="card-body bg-white html-content" id="PrintArea" runat="server" visible="false" >
        <div id="PrintDiv">
            <asp:PlaceHolder ID = "PlaceHolder1" runat="server" />
        </div>
    </div>
        </div>



</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <script src="../js/printThis.js"></script>
    <script>
        function printDiv() {
            debugger
            $("#PrintDiv").printThis({
            });
            return false;
        }
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
