<%@ Page Title="Members Menu" Language="C#" AutoEventWireup="true" CodeBehind="MembersMenu.aspx.cs" MasterPageFile="~/Site.master" Inherits="portfolio.MembersOnly.MembersMenu" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:HyperLink ID="ChangePassword" NavigateUrl="~/Account/ChangePassword.aspx" runat="server">Change Password</asp:HyperLink>
</asp:Content>
