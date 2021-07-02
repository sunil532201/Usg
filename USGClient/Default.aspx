<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="USGClient.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBreadCrumbs" runat="server">
    <span id="dnn_dnnBreadcrumb_lblBreadCrumb" itemprop="breadcrumb" itemscope="" itemtype="https://schema.org/breadcrumb">
        <span itemscope itemtype="http://schema.org/BreadcrumbList">
            <span itemprop="itemListElement" itemscope itemtype="http://schema.org/ListItem">
                <a href='<%=System.Configuration.ConfigurationManager.AppSettings["BaseURL"] %>' class=" " itemprop="item">
                    <span itemprop="name">Home</span>
                </a>
                <meta itemprop="position" content="1" />
            </span> / 
            <span itemprop="itemListElement" itemscope itemtype="http://schema.org/ListItem">
                <a href="About-USG.html" class=" " itemprop="item">
                    <span itemprop="name">About USG</span>
                </a>
                <meta itemprop="position" content="2" />
            </span>
        </span>
    </span>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMainContent" runat="server">
</asp:Content>
