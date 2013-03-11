<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd.Master" AutoEventWireup="true" CodeBehind="administrator.aspx.cs" Inherits="Milanov.pages.administrator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <asp:Label ID="lblAuth" runat="server" Visible="true"></asp:Label>
                <div id="menu">
                    <div id="knop"><a href="/pages/admin/categories_overview.aspx"><center><img src="/images/knop.png" alt="knopC" /></center></a></div>
                    <div id="knop"><a href="/pages/admin/products_overview.aspx"><center><img src="/images/knop.png" alt="knopC" /></center></a></div>
                    <div id="knop"><a href="/pages/admin/roles_overview.aspx"><center><img src="/images/knop.png" alt="knopC" /></center></a></div>
                    <div id="knop"><a href="/pages/admin/users_overview.aspx"><center><img src="/images/knop.png" alt="knopC" /></center></a></div>
                </div>
</asp:Content>
