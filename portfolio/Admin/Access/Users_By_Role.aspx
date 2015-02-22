<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCMS.Master" AutoEventWireup="true" CodeBehind="Users_By_Role.aspx.cs" Inherits="portfolio.Admin.Access.Users_By_Role" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    
<table class="webparts">
<tr>
	<th>Users by Role</th>
</tr>
<tr>
<td class="details" valign="top">

Role filter:

<asp:DropDownList ID="UserRoles" runat="server" AppendDataBoundItems="true" AutoPostBack="true">
<asp:ListItem>Show All</asp:ListItem>
</asp:DropDownList>


<br /><br />

<asp:GridView runat="server" ID="Users" AutoGenerateColumns="false"
	CssClass="list" AlternatingRowStyle-CssClass="odd" GridLines="none"
	AllowSorting="true"
	>
<Columns>
	<asp:TemplateField>
		<HeaderTemplate>User Name</HeaderTemplate>
		<ItemTemplate>
		<a href="edit_user.aspx?username=<%# Eval("UserName") %>"><%# Eval("UserName") %></a>
		</ItemTemplate>
	</asp:TemplateField>
	<asp:BoundField DataField="email" HeaderText="Email" />
	<asp:BoundField DataField="comment" HeaderText="Comments" />
	<asp:BoundField DataField="creationdate" HeaderText="Creation Date" />
	<asp:BoundField DataField="lastlogindate" HeaderText="Last Login Date" />
	<asp:BoundField DataField="lastactivitydate" HeaderText="Last Activity Date" />
	<asp:BoundField DataField="isapproved" HeaderText="Is Active" />
	<asp:BoundField DataField="isonline" HeaderText="Is Online" />
	<asp:BoundField DataField="islockedout" HeaderText="Is Locked Out" />
</Columns>
</asp:GridView>

</td></tr></table>


</asp:Content>
