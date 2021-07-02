<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClientMenuControl.ascx.cs" Inherits="USGClient.Controls.ClientMenuControl" %>
 <ul class="nav nav-pills">
  <li runat="server" id="liApproval" visible="false" ><a href="Default.aspx">Approval System</a></li>
  <li runat="server" id="liOrder" visible="false" ><a href="Order.aspx">Store Ordering</a></li>
  <li runat="server" id="liArt" visible="false" ><a href="FileTransfer.aspx">File Transfer</a></li>
  <li runat="server" id="liManager" visible="false" ><a href="ManagerView.aspx">Manage Orders</a></li>
</ul>
<hr />
