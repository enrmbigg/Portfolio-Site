<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" MasterPageFile="~/Site.Master" Inherits="portfolio.Blog.Default" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>Blog list</h2>
    <br />
    <asp:Label ID="lblOutput" runat="server" Text="Currently there is no posts"></asp:Label>
    <asp:BulletedList ID="BulletedList1" runat="server"  
        DataTextField="Id" DataValueField="Id" onload="BulletedList1_Load">
    </asp:BulletedList>
</asp:Content>
