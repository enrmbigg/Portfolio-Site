<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="portfolio.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        About
    </h2>
    <asp:Label ID="lblHello" runat="server" Text="Label"></asp:Label>
    <p>
        <asp:Label ID="lblAbout" runat="server" Text="Label"></asp:Label>
    </p>
</asp:Content>
