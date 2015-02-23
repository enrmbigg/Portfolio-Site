<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="User_Overview.aspx.cs" Inherits="portfolio.Admin.User_Overview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <p>
<asp:hyperlink runat="server" ID="Users" NavigateUrl="~/Admin/Access/users.aspx">Users by Name</asp:hyperlink>&nbsp;&nbsp;|&nbsp;
<asp:hyperlink runat="server" ID="UserByRole" NavigateUrl="~/Admin/Access/users_by_role.aspx">Users by Role</asp:hyperlink>&nbsp;&nbsp;|&nbsp;
<asp:hyperlink runat="server" ID="ActiveUsers" NavigateUrl="~/Admin/Access/active_users.aspx">Active Users</asp:hyperlink>&nbsp;&nbsp;|&nbsp;
<asp:hyperlink runat="server" ID="OnlineUsers" NavigateUrl="~/Admin/Access/online_users.aspx">Online Users</asp:hyperlink>&nbsp;&nbsp;|&nbsp;
<asp:hyperlink runat="server" ID="LockedUsers" NavigateUrl="~/Admin/Access/locked_users.aspx">Locked Out Users</asp:hyperlink>&nbsp;&nbsp;|&nbsp;
<asp:hyperlink runat="server" ID="AccessRules" NavigateUrl="~/Admin/Access/access_rules.aspx">Access Rules</asp:hyperlink>&nbsp;&nbsp;|&nbsp;
<asp:hyperlink runat="server" ID="AccessRulesSummary" NavigateUrl="~/Admin/Access/access_rule_summary.aspx">Access Rules Summary</asp:hyperlink>&nbsp;&nbsp;|&nbsp;
<asp:hyperlink runat="server" ID="AddUser" NavigateUrl="~/Admin/Access/add_user.aspx">Add User</asp:hyperlink>&nbsp;&nbsp;|&nbsp;
<asp:hyperlink runat="server" ID="Roles" NavigateUrl="~/Admin/Access/roles.aspx">Role Management</asp:hyperlink>
</p>
</asp:Content>
