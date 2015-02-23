<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Access_Rule_Summary.aspx.cs" Inherits="portfolio.Admin.Access.Access_Rule_Summary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="webparts">
    <tr>
	    <th>Website Access Security Summary</th>
    </tr>
    <tr>
	    <td>
		    <table>
		    <tr>
			    <td style="padding-right: 30px;">
				
				    <asp:DropDownList ID="UserRoles" runat="server" AppendDataBoundItems="true"
					    AutoPostBack="true" OnSelectedIndexChanged="DisplayRoleSummary">
				    <asp:ListItem>Select Role</asp:ListItem>
				    </asp:DropDownList>
				
				    &nbsp;&nbsp;&nbsp;&nbsp;<b>&mdash;&nbsp;&nbsp;OR&nbsp;&nbsp;&mdash;</b>
				    &nbsp;&nbsp;&nbsp;				
				
				    <asp:DropDownList ID="UserList" runat="server" AppendDataBoundItems="true"
					    AutoPostBack="true" OnSelectedIndexChanged="DisplayUserSummary">
				    <asp:ListItem>Select User</asp:ListItem>
				    <asp:ListItem Text="Anonymous users (?)" Value="?"></asp:ListItem>
				    <asp:ListItem Text="Authenticated users not in a role (*)" Value="*"></asp:ListItem>
				    </asp:DropDownList>	
				
				    <br />
				
				    <div class="treeview">
				    <asp:TreeView runat="server" ID="FolderTree"
					    OnSelectedNodeChanged="FolderTree_SelectedNodeChanged"
					    >
					    <RootNodeStyle ImageUrl="~/Images/i/folder.gif" />
					    <ParentNodeStyle ImageUrl="~/Images/i/folder.gif" />
					    <LeafNodeStyle ImageUrl="~/Images/i/folder.gif" />
					    <SelectedNodeStyle Font-Underline="true" ForeColor="#A21818" />
				    </asp:TreeView>
				    </div>
			    </td>
		    </tr>
		    </table>
	    </td>
    </tr>
    </table>
</asp:Content>


