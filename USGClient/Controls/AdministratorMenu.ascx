<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdministratorMenu.ascx.cs" Inherits="USGClient.Controls.AdministratorMenu" %>

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
                        <a id="AdminList" runat="server"  class="nav-link " onserverclick="Nav_ServerClick">
                          Admin List
                        </a>
                      </li>
</ul>
<hr />