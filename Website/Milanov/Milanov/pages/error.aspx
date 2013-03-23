<%@ Page Title="" Language="C#" MasterPageFile="~/FrontEnd.Master" AutoEventWireup="true" CodeBehind="error.aspx.cs" Inherits="Milanov.pages.error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="errorMSG">
        <asp:Label ID="lblError" runat="server" Visible="false" Text="ERROR"></asp:Label>
    </div>
</asp:Content>