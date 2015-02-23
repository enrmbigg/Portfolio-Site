<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Blog_Add.aspx.cs" Inherits="portfolio.Admin.Blog_Add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 903px;
        }
        .style2
        {
            width: 1115px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
    <tr>
        <td class="style2">Title</td>
        <td class="style1">
            <asp:TextBox ID="txtTitle" runat="server" Width="700px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtTitle" ErrorMessage="*" ForeColor="Red" Font-Size="Large"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="style2">Body</td>
        <td class="style1">
            <asp:TextBox ID="txtBody" runat="server" Height="189px" TextMode="MultiLine" 
                Width="700px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style2">Image</td>
        <td class="style1">
            <asp:DropDownList ID="ddlImage" runat="server" Width="276px">
            </asp:DropDownList>
            <br />
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Button ID="btnUploadImage" runat="server" Text="Upload Image" 
                    onclick="btnUploadImage_Click" CausesValidation="False" /> 
        </td>
    </tr>
</table>
<asp:label ID="lblResult" runat="server" Text=""></asp:label>
<br/>
<asp:Button ID="btnSave"  runat="server" Text="Save" CausesValidation="True" onclick="btnSave_Click1"  />
</asp:Content>
