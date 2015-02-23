<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Access_Rules.aspx.cs" Inherits="portfolio.Admin.Access.AccessRules" %>
<%@ Import Namespace="System.Web.Configuration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<table class="webparts">
<tr>
	<th>Website Access Rules</th>
</tr>
<tr>
	<td>
		<p>
		Use this page to manage access rules for your Web site. Rules are applied to folders, thus providing robust folder-level security enforced by the ASP.NET infrastructure. Rules are persisted as XML in each folder's Web.config file. <i>Page-level security and inner-page security are not handled using this tool &mdash; they are handled using specialized code that is available to the Web Developers.</i>
		</p>

		<table>
		<tr>
			<td style="padding-right: 30px;">
				<div>
				<asp:TreeView runat="server" ID="FolderTree"
					OnSelectedNodeChanged="FolderTree_SelectedNodeChanged">
					<RootNodeStyle ImageUrl="~/Images/i/folder.gif" />
					<ParentNodeStyle ImageUrl="~/Images/i/folder.gif" />
					<LeafNodeStyle ImageUrl="~/Images/i/folder.gif" />
					<SelectedNodeStyle Font-Underline="true" ForeColor="#A21818" />
				</asp:TreeView>
				</div> 
			</td>

			<td style="padding-left: 30px; border-left: 1px solid #999;">
			<asp:Panel runat="server" ID="SecurityInfoSection" Visible="false">
				<h2 runat="server" id="TitleOne"></h2>
				
				<p>
				Rules are applied in order. The first rule that matches applies, and the permission in each rule overrides the permissions in all following rules. Use the Move Up and Move Down buttons to change the order of the selected rule. Rules that appear dimmed are inherited from the parent and cannot be changed at this level. 
				</p>
				
				<asp:GridView runat="server" ID="RulesGrid" AutoGenerateColumns="false"
				CssClass="list" GridLines="none"
				OnRowDataBound="RowDataBound"
				>
					<Columns>
						<asp:TemplateField HeaderText="Action">
							<ItemTemplate>
								<%# GetAction((AuthorizationRule)Container.DataItem) %>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Roles">
							<ItemTemplate>
								<%# GetRole((AuthorizationRule)Container.DataItem) %>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="User">
							<ItemTemplate>
								<%# GetUser((AuthorizationRule)Container.DataItem) %>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Delete Rule">
							<ItemTemplate>
								<asp:Button ID="Button1" runat="server" Text="Delete Rule" CommandArgument="<%# (AuthorizationRule)Container.DataItem %>" OnClick="DeleteRule" OnClientClick="return confirm('Click OK to delete this rule.')" />
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Move Rule">
							<ItemTemplate>
								<asp:Button ID="Button2" runat="server" Text="  Up  " CommandArgument="<%# (AuthorizationRule)Container.DataItem %>" OnClick="MoveUp" />
								<asp:Button ID="Button3" runat="server" Text="Down" CommandArgument="<%# (AuthorizationRule)Container.DataItem %>" OnClick="MoveDown" />
							</ItemTemplate>
						</asp:TemplateField>
					</Columns>
				</asp:GridView>

				<br />
				<hr />
				<h2 runat="server" id="TitleTwo" class="alert"></h2>
				<b>Action:</b>
				<asp:RadioButton runat="server" ID="ActionDeny" GroupName="action" 
					Text="Deny" Checked="true" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
				<asp:RadioButton runat="server" ID="ActionAllow" GroupName="action" 
					Text="Allow" />
				
				<br /><br />
				<b>Rule applies to:</b>
				<br />
				<asp:RadioButton runat="server" ID="ApplyRole" GroupName="applyto"
					Text="This Role:" Checked="true" />
				<asp:DropDownList ID="UserRoles" runat="server" AppendDataBoundItems="true">
				<asp:ListItem>Select Role</asp:ListItem>
				</asp:DropDownList>
				<br />
					
				<asp:RadioButton runat="server" ID="ApplyUser" GroupName="applyto"
					Text="This User:" />
				<asp:DropDownList ID="UserList" runat="server" AppendDataBoundItems="true">
				<asp:ListItem>Select User</asp:ListItem>
				</asp:DropDownList>	
				<br />
				
				
				<asp:RadioButton runat="server" ID="ApplyAllUsers" GroupName="applyto"
					Text="All Users (*)"  />
				<br />
				
				
				<asp:RadioButton runat="server" ID="ApplyAnonUser" GroupName="applyto"
					Text="Anonymous Users (?)"  />
				<br /><br />
				
				<asp:Button ID="Button4" runat="server" Text="Create Rule" OnClick="CreateRule"
					OnClientClick="return confirm('Click OK to create this rule.');" />
					
				<asp:Literal runat="server" ID="RuleCreationError"></asp:Literal>
			</asp:Panel>
			</td>
		</tr>
		</table>
	</td>
</tr>
</table>
</asp:Content>


