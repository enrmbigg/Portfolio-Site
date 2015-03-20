<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" MasterPageFile="~/Site.Master" Inherits="portfolio.Blog.Default" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1>Blog</h1>
    <br/>
    <h1 class="content-subhead">Pinned Post</h1>
    <asp:Label ID="lblOutput" runat="server" Text="Currently there is no posts"></asp:Label>  
</asp:Content>
