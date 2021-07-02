<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminDetails.ascx.cs" Inherits="USGClient.Controls.AdminDetails" %>
<style>
a:hover{
    background-color:#172C55 !important;
    color:#e3c17e !important;
}
link{
     background-color:#172C55 !important;
    color:#e3c17e !important;
}
</style>
<ul class="nav nav-pills">
                      <li class="nav-item" runat="server">
                        <a id="liLayouts" runat="server" class="nav-link "  onserverclick="Nav_ServerClick">
                           Approval System
                        </a>
                      </li>
                      <li class="nav-item" runat="server">
                        <a id="liOrderEntry" runat="server"  class="nav-link"  onserverclick="Nav_ServerClick">
                          Order Entry
                        </a>
                      </li>
                      <li class="nav-item" runat="server">
                        <a id="liFileTransfers" runat="server"  class="nav-link"  onserverclick="Nav_ServerClick">
                          File Transfer
                        </a>
                      </li>
                      <li class="nav-item" runat="server">
                        <a id="liJobs" runat="server"  class="nav-link"  onserverclick="Nav_ServerClick">
                          Jobs
                        </a>
                      </li>
                    <li class="nav-item" runat="server">
                        <a id="liInvoices" runat="server"  class="nav-link"  onserverclick="Nav_ServerClick">
                          Invoices
                        </a>
                      </li>
                        <li class="nav-item" runat="server">
                        <a id="liInventory" runat="server"  class="nav-link"  onserverclick="Nav_ServerClick">
                          Inventory Items 
                        </a>
                      </li>
                    <li class="nav-item" runat="server">
                        <a id="liQuoteRequest" runat="server"  class="nav-link" visible="true" onserverclick="Nav_ServerClick">
                          Quote Request
                        </a>
                      </li>                
                    <li class="nav-item dropdown">
                        <a id="liClientSetting" runat="server" class="nav-link dropdown-toggle" data-toggle="dropdown"  href="#" role="button" aria-haspopup="true" aria-expanded="false">Client Settings</a>
                        <div class="dropdown-menu">
                            <a id="ClientsDetails" runat="server"  class="dropdown-item" onserverclick="Nav_ServerClick">Client Details</a>
                            <a id="ClientUsers" runat="server"  class="dropdown-item" onserverclick="Nav_ServerClick">Client Users</a>
                            <a id="SignTypes" runat="server"  class="dropdown-item" onserverclick="Nav_ServerClick">Sign Types</a>
                            <a id="SignTypeFamily" runat="server"  class="dropdown-item" onserverclick="Nav_ServerClick"> Sign Type Families</a>
                             <a id="liStores" runat="server"  class="dropdown-item" onserverclick="Nav_ServerClick">Stores</a>
                             <a id="liPresets" runat="server"  class="dropdown-item" onserverclick="Nav_ServerClick">Presets</a>
                            <a id="liChangeLog" runat="server"  class="dropdown-item" onserverclick="Nav_ServerClick">Change Log</a>
                        </div>
                    </li>

       <div class="float-right card-title tab-right"><i class="fa fa-user-circle"></i>&nbsp;<%=Session["Name"]%> </div> 

 </ul>

<hr />