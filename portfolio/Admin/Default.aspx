<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="portfolio.Admin.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HyperLink ID="UserOverview" runat="server" NavigateUrl="User_Overview.aspx">User Overview</asp:HyperLink>
    <asp:HyperLink ID="BlogOverview" runat="server" NavigateUrl="Blog_Overview.aspx">Blog Overview</asp:HyperLink>
</asp:Content>
