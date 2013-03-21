<%@ Page Title="" Language="C#" MasterPageFile="~/StoreEnd.Master" AutoEventWireup="true" CodeBehind="checkout.aspx.cs" Inherits="Milanov.pages.store.checkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    Hier kunnen we straks betalen ofzo?<br />
    <br />
    <br />
    <br />
    <br />
    Dit zijn de door u gekochte foto's (downloaden en mailen):<br />
    <asp:Label ID="lblImage" runat="server" Text="<img src='~/images/lipsum.gif' alt='lipsum' />" />
</asp:Content>
