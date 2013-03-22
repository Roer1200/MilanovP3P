<%@ Page Title="" Language="C#" MasterPageFile="~/StoreEnd.Master" AutoEventWireup="true" CodeBehind="products.aspx.cs" Inherits="Milanov.pages.store.products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <p class="storeSidebar">
        <b>Filter op categorie:</b><br /><br />

        <a href="products.aspx">Alle producten</a><br />
        <asp:ListView ID="lvCategories" runat="server" DataSourceID="sds_category">
            <ItemTemplate>
                <a href="products.aspx?categoryId=<%# Eval("cid") %>"><%# Eval("cname") %></a>
            </ItemTemplate>
            <ItemSeparatorTemplate><br /></ItemSeparatorTemplate>
        </asp:ListView>
        <asp:SqlDataSource ID="sds_category" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MilanovDBConnectionString %>" 
            SelectCommand="SELECT DISTINCT c.id AS cid, c.name AS cname FROM categories AS c INNER JOIN products AS p ON c.id = p.cat_id ORDER BY c.name">
        </asp:SqlDataSource>
        
    </p>
    <p>
        <asp:Label ID="lblOutput" runat="server" Text="Er zijn geen producten gevonden in deze categorie."></asp:Label>
    </p>
    <p>
        test
    </p>
</asp:Content>