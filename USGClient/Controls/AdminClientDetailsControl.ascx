<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminClientDetailsControl.ascx.cs" Inherits="USGClient.Controls.AdminClientDetailsControl" %>
<style>
a:hover{
    background-color:#172C55 !important;
}
    </style>
<ul class="nav nav-pills">
          <li class="nav-item" runat="server">
                        <a id="liClientDetails" runat="server" class="nav-link" onserverclick="li_ServerClick">
                          Edit Users
                        </a>
                      </li>
                      <li class="nav-item" runat="server">
                        <a id="liLayouts" runat="server" class="nav-link "  onserverclick="li_ServerClick">
                           Layouts
                        </a>
                      </li>
                      <li class="nav-item" runat="server">
                        <a id="liFileTransfers" runat="server"  class="nav-link" onserverclick="li_ServerClick">
                          Uploads
                        </a>
                      </li>
         </ul>
    <hr />