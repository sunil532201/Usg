<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JobMenuControl.ascx.cs" Inherits="USGClient.Controls.JobMenuControl" %>
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
                        <a id="liJobBook" runat="server" class="nav-link"  onserverclick="Nav_ServerClick">
                           Job Book
                        </a>
                      </li>
                      <li class="nav-item" runat="server">
                        <a id="liJobDetails" runat="server"  class="nav-link" onserverclick="Nav_ServerClick">
                          Job Details
                        </a>
                      </li>
                     
                      <li class="nav-item" runat="server">
                        <a id="liPromotions" runat="server"  class="nav-link" onserverclick="Nav_ServerClick">
                          Promotions 
                        </a>
                      </li>
                       
                      <li class="nav-item" runat="server">
                            <a id="liSignTypes" runat="server"  class="nav-link" onserverclick="Nav_ServerClick">
                              Sign Types
                            </a>
                         </li>

<%--                         <div class="float-right card-title tab-right" id="cusName"><i class="fa fa-user-circle"></i>&nbsp;<%=Session["Name"]%> </div> --%>

</ul>

<br />