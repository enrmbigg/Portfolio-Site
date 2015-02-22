<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCMS.Master" AutoEventWireup="true" CodeBehind="Active_Users.aspx.cs" Inherits="portfolio.Admin.Access.Active_Users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <th>Active / Inactive Users</th>
        </tr>
        <tr>
            <td>
                <asp:DropDownList runat="server" ID="active" AutoPostBack="true">
                    <asp:ListItem>Active</asp:ListItem>
                    <asp:ListItem>Inactive</asp:ListItem>
                </asp:DropDownList>
                <br/><br/>
                <asp:GridView runat="server" ID="Users" AutoGenerateColumns="false"
                              AlternatingRowStyle-CssClass="odd" GridLines="none"
                              AllowSorting="true">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>User Name</HeaderTemplate>
                            <ItemTemplate>
                                <a href="edit_user.aspx?username=<%# Eval("UserName") %>"><%# Eval("UserName") %></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="email" HeaderText="Email"/>
                        <asp:BoundField DataField="comment" HeaderText="Comments"/>
                        <asp:BoundField DataField="creationdate" HeaderText="Creation Date"/>
                        <asp:BoundField DataField="lastlogindate" HeaderText="Last Login Date"/>
                        <asp:BoundField DataField="lastactivitydate" HeaderText="Last Activity Date"/>
                        <asp:BoundField DataField="isapproved" HeaderText="Is Active"/>
                        <asp:BoundField DataField="isonline" HeaderText="Is Online"/>
                        <asp:BoundField DataField="islockedout" HeaderText="Is Locked Out"/>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>