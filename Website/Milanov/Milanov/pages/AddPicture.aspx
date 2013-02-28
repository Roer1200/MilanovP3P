<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd.Master" AutoEventWireup="true" CodeBehind="AddPicture.aspx.cs" Inherits="Milanov.pages.AddPicture" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 79px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <h3>Voeg een nieuwe foto toe</h3>

    <table cellspaccing="15" class="pictureTable">
        <tr>
            <td class="style1">
                Name</td>
            <td>
                <asp:TextBox ID="txtName" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
           <tr>
            <td class="style1">
                Category</td>
            <td>
                <asp:TextBox ID="txtCategory" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
           <tr>
            <td class="style1">
                Price</td>
            <td>
                <asp:TextBox ID="txtPrice" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
           <tr>
            <td class="style1">
                Image</td>
            <td>
                <asp:DropDownList ID="ddlImage" runat="server" Width="300px">
                </asp:DropDownList>
                <br />
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:Button ID="btnUploadFoto" runat="server" Text="Upload foto" 
                    onclick="btnUploadFoto_Click" />
                </td>
            </td>
        </tr>
           <tr>
            <td class="style1">
                Description</td>
            <td>
                <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Width="300px"></asp:TextBox>
            </td>
    </table>
    <asp:Label ID="lblResult" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" />
</asp:Content>
