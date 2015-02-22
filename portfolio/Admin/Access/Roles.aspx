<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCMS.Master" AutoEventWireup="true" CodeBehind="Roles.aspx.cs" Inherits="portfolio.Admin.Access.Roles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="webparts">
<tr>
	<th>Roles</th>
</tr>
<tr>
<td class="details" valign="top" style="width: 450px;">

<br />

<asp:GridView runat="server" ID="UserRoles" AutoGenerateColumns="false"
	CssClass="list" AlternatingRowStyle-CssClass="odd" GridLines="none"
	>
	<Columns>
		<asp:TemplateField>
			<HeaderTemplate>Role Name</HeaderTemplate>
			<ItemTemplate>
				<%# Eval("Role Name") %>
			</ItemTemplate>
		</asp:TemplateField>
		<asp:TemplateField>
			<HeaderTemplate>User Count</HeaderTemplate>
			<ItemTemplate>
				<%# Eval("User Count") %>
			</ItemTemplate>
		</asp:TemplateField>
		<asp:TemplateField>
			<HeaderTemplate>Delete Role</HeaderTemplate>
			<ItemTemplate>
				<asp:Button ID="Button1" runat="server" OnCommand="DeleteRole" CommandName="DeleteRole" CommandArgument='<%# Eval("Role Name") %>' Text="Delete" OnClientClick="return confirm('Are you sure?')" />
			</ItemTemplate>
		</asp:TemplateField>
	</Columns>
</asp:GridView>


<p>
New Role:
<asp:TextBox runat="server" ID="NewRole"></asp:TextBox>

<asp:Button ID="Button2" runat="server" OnClick="AddRole" Text="Add Role" />
</p>

<div runat="server" id="ConfirmationMessage" class="alert">
</div>

</td>

</tr></table>
</asp:Content>
