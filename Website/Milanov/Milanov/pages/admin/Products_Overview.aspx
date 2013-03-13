﻿<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd.Master" AutoEventWireup="true" CodeBehind="products_overview.aspx.cs" Inherits="Milanov.pages.products_overview" %>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <h3>Beschikbare producten:</h3>
    <p>  
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
<<<<<<< HEAD
        AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        CellSpacing="4" DataKeyNames="id" DataSourceID="sds_products" ForeColor="Black" 
        GridLines="Vertical" Width="900px">
        <Columns>
            <asp:TemplateField HeaderText="Opties">
                <ItemTemplate>
                    <asp:Button ID="btnEdit" runat="server" CommandName="Edit" Text="Bewerken" />
                    <asp:Button ID="btnDelete" runat="server" CommandName="Delete" Text="Verwijderen" 
                    OnClientClick="return confirm('Weet u zeker dat u dit products wilt verwijderen?');" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Button ID="btnUpdate" runat="server" CommandName="Update" Text="Update" />
                    <asp:Button ID="btnCancel" runat="server" CommandName="Cancel" Text="Annuleer" />
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="name" HeaderText="Naam" SortExpression="name" />
            <asp:TemplateField HeaderText="Categorie" SortExpression="cname">
                <ItemTemplate>
                    <asp:Label ID="lblCname" runat="server" Text='<%# Bind("cname") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlCategories" runat="server" DataSourceID="sds_categories" 
                    DataTextField="name" DataValueField="name" SelectedValue='<%# Bind("cname") %>'>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="sds_categories" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:MilanovDBConnectionString %>" 
                    SelectCommand="SELECT [name] FROM [categories] ORDER BY [name]">
                    </asp:SqlDataSource>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="price" HeaderText="Prijs" SortExpression="price" />
            <asp:BoundField DataField="image" HeaderText="Foto" SortExpression="image" />
            <asp:BoundField DataField="description" HeaderText="Omschrijving" SortExpression="description" />
        </Columns>
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#F7F7DE" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FBFBF2" />
        <SortedAscendingHeaderStyle BackColor="#848384" />
        <SortedDescendingCellStyle BackColor="#EAEAD3" />
        <SortedDescendingHeaderStyle BackColor="#575357" />
=======
            AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
            BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
            CellSpacing="4" DataKeyNames="id" DataSourceID="sds_products" ForeColor="Black" 
            GridLines="Vertical" Width="858px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="Edit">
                <ItemTemplate>
                <asp:Button ID="editbutton" runat="server" CommandName="Edit" Text="Edit" />
                </ItemTemplate>
                <EditItemTemplate>  
                <asp:Button ID="LinkButton2" CommandName="Update" Text="Confirm"     
                runat="server"/>     
                <asp:Button ID="LinkButton3" CommandName="Cancel" Text="Cancel" 
                runat="server"/>           
                </EditItemTemplate> 
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                <asp:Button ID="deleteButton" runat="server" CommandName="Delete" Text="Delete"
                OnClientClick="return confirm('Are you sure you want to delete this product?');" />
                </ItemTemplate>
                </asp:TemplateField>


                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="name" HeaderText="Naam" SortExpression="name" />
                <asp:BoundField DataField="cname" HeaderText="Categorie" SortExpression="cname" />
                <asp:BoundField DataField="price" HeaderText="Prijs" SortExpression="price" />
                <asp:BoundField DataField="image" HeaderText="Foto" SortExpression="image" />
                <asp:BoundField DataField="description" HeaderText="Omschrijving" SortExpression="description" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
>>>>>>> bbe59f7d3d0bdceb8dc9b46e577a488b05e8cd65
        </asp:GridView>
        <asp:SqlDataSource ID="sds_products" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MilanovDBConnectionString %>" 
            DeleteCommand="DELETE FROM [products] WHERE [id] = @id" 
            SelectCommand="SELECT p.id, p.name, c.name AS cname, p.price, p.image, p.description FROM products AS p INNER JOIN categories AS c ON p.cat_id = c.id"
            UpdateCommand="UPDATE p SET p.name = @name, p.cat_id = c.id, p.price = @price, p.image = @image, p.description = @description FROM products AS p INNER JOIN categories AS c ON c.id = (SELECT id FROM categories WHERE name = @cname) WHERE p.id = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="cname" Type="String" />                
                <asp:Parameter Name="price" Type="Double" />
                <asp:Parameter Name="image" Type="String" />
                <asp:Parameter Name="description" Type="String" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </p>
    <br />
    <p>
<<<<<<< HEAD
        <asp:LinkButton ID="lbAdd" runat="server" PostBackUrl="/pages/admin/products_add.aspx">Klik hier om een nieuw product toe te voegen.</asp:LinkButton>
=======
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="/pages/admin/products_add.aspx">Klik hier om een nieuw product toe te voegen.</asp:LinkButton>
        
>>>>>>> bbe59f7d3d0bdceb8dc9b46e577a488b05e8cd65
    </p>
</asp:Content>