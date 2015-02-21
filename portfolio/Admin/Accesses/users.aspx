<%@ Page Language="C#" MasterPageFile="~/MasterPageCMS.Master" %>

<script runat="server">
	private void Page_PreRender()
	{
		Users.DataSource = Membership.GetAllUsers();
		Users.DataBind();
	}
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <table>
        <tr>
	        <th>Users by Name</th>
        </tr>
        <tr>
            <td>
                <br/>
                <asp:GridView runat="server" ID="Users" AutoGenerateColumns="false">
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
            </td>
        </tr>
    </table>
</asp:Content>
