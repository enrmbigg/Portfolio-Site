<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Blog_Overview.aspx.cs" Inherits="portfolio.Admin.Blog_Overview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h3>Availble blogs</h3>
    <p><asp:LinkButton ID="BlogAdd" runat="server" PostBackUrl="~/Admin/Blog_Add.aspx">Add Post</asp:LinkButton></p>
    
    
    <p>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Id" 
            DataSourceID="postsgrid" Width="792px">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" 
                    SortExpression="Id" />
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                <asp:BoundField DataField="Body" HeaderText="Body" SortExpression="Body" />
                <asp:BoundField DataField="Image" HeaderText="Image" SortExpression="Image" />
                <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="postsgrid" runat="server" 
            ConnectionString="<%$ ConnectionStrings:BlogPosts %>" 
            DeleteCommand="DELETE FROM [Posts] WHERE [Id] = @Id" 
            InsertCommand="INSERT INTO [Posts] ([Id], [Title], [Body], [Image], [Date]) VALUES (@Id, @Title, @Body, @Image, @Date)" 
            ProviderName="<%$ ConnectionStrings:BlogPosts.ProviderName %>" 
            SelectCommand="SELECT * FROM [Posts]" 
            UpdateCommand="UPDATE [Posts] SET [Title] = @Title, [Body] = @Body, [Image] = @Image, [Date] = @Date WHERE [Id] = @Id">
            <DeleteParameters>
                <asp:Parameter Name="Id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Id" Type="Int32" />
                <asp:Parameter Name="Title" Type="String" />
                <asp:Parameter Name="Body" Type="String" />
                <asp:Parameter Name="Image" Type="String" />
                <asp:Parameter Name="Date" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Title" Type="String" />
                <asp:Parameter Name="Body" Type="String" />
                <asp:Parameter Name="Image" Type="String" />
                <asp:Parameter Name="Date" Type="String" />
                <asp:Parameter Name="Id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </p>
</asp:Content>
