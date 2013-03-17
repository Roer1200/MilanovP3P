<%@ Page Title="" Language="C#" MasterPageFile="~/FrontEnd.Master" AutoEventWireup="true" CodeBehind="products.aspx.cs" Inherits="Milanov.pages.store.products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <p>
        <asp:ListView ID="lvCategories" runat="server" DataSourceID="sds_category">
            <ItemTemplate>
                <a href="products.aspx?categoryId=<%# Eval("id") %>"><%# Eval("name") %></a>
            </ItemTemplate>
            <ItemSeparatorTemplate> - </ItemSeparatorTemplate>
        </asp:ListView>
        <asp:SqlDataSource ID="sds_category" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MilanovDBConnectionString %>" 
            SelectCommand="SELECT [id], [name] FROM [categories] ORDER BY [name]">
        </asp:SqlDataSource>
        
    </p>
    <p>
        <asp:Label ID="lblOutput" runat="server" Text="Er zijn geen producten gevonden in deze categorie."></asp:Label>
    </p>
</asp:Content>