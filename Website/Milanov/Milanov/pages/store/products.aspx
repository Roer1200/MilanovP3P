<%@ Page Title="" Language="C#" MasterPageFile="~/FrontEnd.Master" AutoEventWireup="true" CodeBehind="products.aspx.cs" Inherits="Milanov.pages.store.products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Milanov - Store</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <p>
        Select by category: 
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" 
            DataSourceID="sds_category" DataTextField="name" DataValueField="id">
        </asp:DropDownList>
        
    </p>
    <p>
        <asp:Label ID="lblOutput" runat="server" Text="Label"></asp:Label>
    </p>

    <asp:SqlDataSource ID="sds_category" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MilanovDBConnectionString %>" 
            SelectCommand="SELECT [id], [name] FROM [categories] ORDER BY [name]">
        </asp:SqlDataSource>
    <asp:ListView ID="ListView1" runat="server" DataKeyNames="id" 
        DataSourceID="sds_category">
        <ItemTemplate>
                <b style="font-size: large; font-style: normal">
                <a href="/pages/store/product.aspx?id=<%# Eval("id") %>">
                <%# Eval("name" )%></a>
                </b>
            </ItemTemplate>
            <ItemSeparatorTemplate> - </ItemSeparatorTemplate>
    </asp:ListView>
</asp:Content>