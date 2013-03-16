<%@ Page Title="" Language="C#" MasterPageFile="~/FrontEnd.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Milanov.pages.users.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Milanov - Login</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <h3>Inloggen:</h3>
    <table>
        <tr>
            <td>
                <b>Gebruikersnaam:</b>
            </td>
            <td>
                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="*" ControlToValidate="txtUsername"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <b>Password:</b>
            </td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="*" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnLogin" runat="server" Text="Inloggen" OnClick="btnLogin_Click" />                         
            </td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Registeren" CausesValidation="false" OnClick="btnRegister_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblError" runat="server" ></asp:Label><br />  
            </td>
        </tr>
    </table>
</asp:Content>