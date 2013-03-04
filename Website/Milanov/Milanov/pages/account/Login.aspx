<%@ Page Title="" Language="C#" MasterPageFile="~/FrontEnd.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Milanov.pages.account.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Milanov - Login</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <table>
        <tr>
            <td><b>Username: </b></td>
            <td>
                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="*" ControlToValidate="txtUsername"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td><b>Password: </b></td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="*" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnLogin" runat="server" Text="Login" 
                    onclick="btnLogin_Click" /><br />
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label><br />
                <asp:LinkButton ID="LinkButton2" runat="server" 
                    PostBackUrl="~/pages/account/Register.aspx">Register</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>
