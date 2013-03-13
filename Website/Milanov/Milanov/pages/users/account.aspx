<%@ Page Title="" Language="C#" MasterPageFile="~/FrontEnd.Master" AutoEventWireup="true" CodeBehind="account.aspx.cs" Inherits="Milanov.pages.users.account" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <asp:Label ID="lblCU" runat="server"></asp:Label> 
    

    <!-- Change Password -->
    <asp:Button ID="btnChangePassword" runat="server" Text="Wachtwoord veranderen" OnClick="btnChangePassword_Click" />
    <asp:TextBox ID="txtPcurrent" runat="server" TextMode="Password" Visible="false"></asp:TextBox>
    <asp:TextBox ID="txtPnew" runat="server" TextMode="Password" Visible="false"></asp:TextBox>
    <asp:TextBox ID="txtPconfirm" runat="server" TextMode="Password" Visible="false"></asp:TextBox>
    <asp:Button ID="btnPsubmit" runat="server" Text="Wijzigen" Visible="false" OnClick="btnPsubmit_Click" />

    <!-- Change Email -->
    <asp:Button ID="btnChangeEmail" runat="server" Text="Email veranderen" OnClick="btnChangeEmail_Click" />
    <asp:Label ID="email" runat="server" Visible="false">
    <table>
        <tr>
            <td>
                <asp:Label ID="lblEcurrent" runat="server" Text="Huidige E-mail: " ></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEcurrent" runat="server"  ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Nieuwe E-mail: </td>
            <td>
                <asp:TextBox ID="txtEnew" runat="server"  ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Bevestig E-mail: </td>
            <td>
                <asp:TextBox ID="txtEconfirm" runat="server" ></asp:TextBox>
            </td>
        </tr>
    </table>
    <asp:Button ID="btnEsubmit" runat="server" Text="Wijzigen"  OnClick="btnEsubmit_Click" />
    </asp:Label>

    
    
    
</asp:Content>