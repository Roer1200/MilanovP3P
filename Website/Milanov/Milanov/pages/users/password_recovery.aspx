<%@ Page Title="" Language="C#" MasterPageFile="~/FrontEnd.Master" AutoEventWireup="true" CodeBehind="password_recovery.aspx.cs" Inherits="Milanov.pages.users.password_recovery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
<asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
<asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
<asp:Button ID="btnSend" runat="server" onclick="btnSend_Click" />
</asp:Content>
