<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCMS.Master" AutoEventWireup="true" CodeBehind="Edit_User.aspx.cs" Inherits="portfolio.Admin.Access.Edit_User" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    
<table class="webparts">
<tr>
	<th>User Information</th>
</tr>
<tr>
<td class="details">

<h3>Roles:</h3>
<asp:CheckBoxList ID="UserRoles" runat="server" />

<h3>Main Info:</h3>
<asp:DetailsView AutoGenerateRows="False" DataSourceID="MemberData"
  ID="UserInfo" runat="server" OnItemUpdating="UserInfo_ItemUpdating"
  >
  
<Fields>
	<asp:BoundField DataField="UserName" HeaderText="User Name" ReadOnly="True" HeaderStyle-CssClass="detailheader" ItemStyle-CssClass="detailitem">
	</asp:BoundField>
	<asp:BoundField DataField="Email" HeaderText="Email" HeaderStyle-CssClass="detailheader" ItemStyle-CssClass="detailitem"></asp:BoundField>
	<asp:BoundField DataField="Comment" HeaderText="Comment" HeaderStyle-CssClass="detailheader" ItemStyle-CssClass="detailitem"></asp:BoundField>
	<asp:CheckBoxField DataField="IsApproved" HeaderText="Active User" HeaderStyle-CssClass="detailheader" ItemStyle-CssClass="detailitem" />
	<asp:CheckBoxField DataField="IsLockedOut" HeaderText="Is Locked Out" ReadOnly="true" HeaderStyle-CssClass="detailheader" ItemStyle-CssClass="detailitem" />
	
	<asp:CheckBoxField DataField="IsOnline" HeaderText="Is Online" ReadOnly="True" HeaderStyle-CssClass="detailheader" ItemStyle-CssClass="detailitem" />
	<asp:BoundField DataField="CreationDate" HeaderText="CreationDate" ReadOnly="True"
	 HeaderStyle-CssClass="detailheader" ItemStyle-CssClass="detailitem"></asp:BoundField>
	<asp:BoundField DataField="LastActivityDate" HeaderText="LastActivityDate" ReadOnly="True" HeaderStyle-CssClass="detailheader" ItemStyle-CssClass="detailitem">
	</asp:BoundField>
	<asp:BoundField DataField="LastLoginDate" HeaderText="LastLoginDate" ReadOnly="True" HeaderStyle-CssClass="detailheader" ItemStyle-CssClass="detailitem">
	</asp:BoundField>
	<asp:BoundField DataField="LastLockoutDate" HeaderText="LastLockoutDate" ReadOnly="True" HeaderStyle-CssClass="detailheader" ItemStyle-CssClass="detailitem"></asp:BoundField>
	<asp:BoundField DataField="LastPasswordChangedDate" HeaderText="LastPasswordChangedDate"
	ReadOnly="True" HeaderStyle-CssClass="detailheader" ItemStyle-CssClass="detailitem"></asp:BoundField>
	<asp:CommandField ButtonType="button" ShowEditButton="true" EditText="Edit User Info" />
</Fields>
</asp:DetailsView>
<div class="alert" style="padding: 5px;">
<asp:Literal ID="UserUpdateMessage" runat="server">&nbsp;</asp:Literal>
</div>


<div style="text-align: right; width: 100%; margin: 20px;">
<asp:Button ID="Button1" runat="server" Text="Unlock User" OnClick="UnlockUser" OnClientClick="return confirm('Click OK to unlock this user.')" />
&nbsp;&nbsp;&nbsp;
<asp:Button ID="Button2" runat="server" Text="Delete User" OnClick="DeleteUser" OnClientClick="return confirm('Are Your Sure?')" />
</div>


<asp:ObjectDataSource ID="MemberData" runat="server" DataObjectTypeName="System.Web.Security.MembershipUser" SelectMethod="GetUser" UpdateMethod="UpdateUser" TypeName="System.Web.Security.Membership">
	<SelectParameters>
		<asp:QueryStringParameter Name="username" QueryStringField="username" />
	</SelectParameters>
</asp:ObjectDataSource> 
</td>

</tr></table>



</asp:Content>
