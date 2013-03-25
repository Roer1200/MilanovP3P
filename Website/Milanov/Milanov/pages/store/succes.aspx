<%@ Page Title="" Language="C#" MasterPageFile="~/StoreEnd.Master" AutoEventWireup="true" CodeBehind="succes.aspx.cs" Inherits="Milanov.pages.store.succes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <p>
        Dit zijn de door u gekochte foto's:<br />
        <asp:Label ID="lblImage" runat="server" Text="ERROR" />
    </p>
    <p>
        <asp:Label ID="lblOutput" runat="server"></asp:Label>
    </p>
</asp:Content>