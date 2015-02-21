<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCMS.Master" AutoEventWireup="true" CodeBehind="User_Overview.aspx.cs" Inherits="portfolio.Admin.User_Overview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <p>
<asp:hyperlink runat="server" ID="Users" NavigateUrl="~/Admin/Accesses/users.aspx">Users by Name</asp:hyperlink>&nbsp;&nbsp;|&nbsp;
<asp:hyperlink runat="server" ID="UserByRole" NavigateUrl="~/Admin/Accesses/users_by_role.aspx">Users by Role</asp:hyperlink>&nbsp;&nbsp;|&nbsp;
<asp:hyperlink runat="server" ID="ActiveUsers" NavigateUrl="~/Admin/Accesses/active_users.aspx">Active Users</asp:hyperlink>&nbsp;&nbsp;|&nbsp;
<asp:hyperlink runat="server" ID="OnlineUsers" NavigateUrl="~/Admin/Accesses/online_users.aspx">Online Users</asp:hyperlink>&nbsp;&nbsp;|&nbsp;
<asp:hyperlink runat="server" ID="LockedUsers" NavigateUrl="~/Admin/Accesses/locked_users.aspx">Locked Out Users</asp:hyperlink>&nbsp;&nbsp;|&nbsp;
<asp:hyperlink runat="server" ID="AccessRules" NavigateUrl="~/Admin/Accesses/access_rules.aspx">Access Rules</asp:hyperlink>&nbsp;&nbsp;|&nbsp;
<asp:hyperlink runat="server" ID="AccessRulesSummary" NavigateUrl="~/Admin/Accesses/access_rule_summary.aspx">Access Rules Summary</asp:hyperlink>&nbsp;&nbsp;|&nbsp;
<asp:hyperlink runat="server" ID="AddUser" NavigateUrl="~/Admin/Accesses/add_user.aspx">Add User</asp:hyperlink>&nbsp;&nbsp;|&nbsp;
<asp:hyperlink runat="server" ID="Roles" NavigateUrl="~/Admin/Accesses/roles.aspx">Role Management</asp:hyperlink>
</p>
</asp:Content>
