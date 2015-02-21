<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCMS.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="portfolio.Admin.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="User_Overview.aspx">HyperLink</asp:HyperLink>
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="Blog_Overview.aspx">HyperLink</asp:HyperLink>
</asp:Content>
