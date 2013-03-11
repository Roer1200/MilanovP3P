﻿<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd.Master" AutoEventWireup="true" CodeBehind="categories_add.aspx.cs" Inherits="Milanov.pages.admin.categories_add" %>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <h3>Voeg een nieuwe foto toe</h3>

    <table cellspacing="15" class="pictureTable">
        <tr>
            <td style="width: 80px">
                <b>Name:</b>
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtName" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>       
    </table>
    <asp:Label ID="lblResult" runat="server" Text=""></asp:Label><br />
    <asp:Button ID="btnSave" runat="server" Text="Opslaan" onclick="btnSave_Click" /></asp:Button>
    <asp:Button ID="btnBack" runat="server" Text="Terug" OnClientClick="JavaScript: windows.history.back(1); return false;" /></asp:Button>
</asp:Content>