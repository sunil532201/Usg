<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminPage1.Master" AutoEventWireup="true" CodeBehind="StoreLabels.aspx.cs" Inherits="USGClient.Admin.StoreLabels" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Button ID="Button1" runat="server" CssClass="btn btn-dark " ClientIDMode="Static" Text="Print" OnClientClick="printDiv('PrintArea');return false;" />
    <asp:Button ID="ExportAsPDF" runat="server" CssClass="btn btn-dark " ClientIDMode="Static" Text="Export As PDF" OnClick="ExportAsPDF_Click" />
    <button runat="server" id="BacktoJobs" class="btn btn-dark" title="Back" onclick="JavaScript:window.history.back(1);return false;"><i class="fa fa-arrow-circle-left fa-2" aria-hidden="true"></i> Back</button>

    <div class="card mb-3">
          <div class="card-body bg-white html-content" id="PrintArea" runat="server" >
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
            $("#PrintDiv").printThis(
               
            );
            return false;
        }
</script>
</asp:Content>
