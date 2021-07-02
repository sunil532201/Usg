<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DatabaseMaintenanceMenu.ascx.cs" Inherits="USGClient.Controls.DatabaseMaintenanceMenu" %>
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
                        <a id="MaterialList" runat="server"  class="nav-link " onserverclick="Nav_ServerClick">
                          Materials 
                        </a>
                      </li>
                      <li class="nav-item" runat="server">
                        <a id="FinishingList" runat="server"  class="nav-link" onserverclick="Nav_ServerClick">
                         Finishings 
                        </a>
                      </li>
                      <li class="nav-item" runat="server">
                        <a id="HardwareList" runat="server"  class="nav-link" onserverclick="Nav_ServerClick">
                          Hardware 
                        </a>
                      </li>
                      <li class="nav-item" runat="server">
                        <a id="LaminantList" runat="server"  class="nav-link" onserverclick="Nav_ServerClick">
                          Laminants 
                        </a>
                      </li>
                    </ul>
<hr />