<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClientMenuControl2.ascx.cs" Inherits="USGClient.Controls.ClientMenuControl2" %>

<style>
a:hover{
    background-color:#172C55 !important;
    color:#e3c17e !important;
}
link{
     background-color:#172C55 !important;
    color:#e3c17e !important;
}
ul.nav-pills > li.active > a {
     background-color: #172c55 !important; 
     color: #FFF !important; 
}
</style>
<ul class="nav nav-pills">
                      <li class="nav-item" runat="server">
                        <a id="liApproval" visible="false" runat="server" style="color: #e3c17e !important" class="nav-link " onserverclick="liApproval_ServerClick">
                          Approval System
                        </a>
                      </li>
                      <li class="nav-item" runat="server">
                        <a id="liOrder" visible="false" runat="server"  style="color: #e3c17e !important" class="nav-link"  onserverclick="liApproval_ServerClick">
                          Store Ordering
                        </a>
                      </li>
                      <li class="nav-item" runat="server">
                        <a id="liFileTransfer" visible="false" runat="server" style="color: #e3c17e !important" class="nav-link" onserverclick="liApproval_ServerClick">
                          File Transfer
                        </a>
                      </li>
                      <li class="nav-item" runat="server">
                        <a id="liManager" visible="false" runat="server" style="color: #e3c17e !important" class="nav-link"  onserverclick="liApproval_ServerClick">
                          Manage Orders
                        </a>
                      </li>
                      <li class="nav-item" runat="server">
                        <a id="liInvoices" visible="false" runat="server" style="color: #e3c17e !important" class="nav-link"  onserverclick="liApproval_ServerClick">
                          Invoices
                        </a>
                      </li>
                    </ul>
<hr />