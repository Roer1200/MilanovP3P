<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd.Master" AutoEventWireup="true" CodeBehind="Products_Overview.aspx.cs" Inherits="Milanov.pages.Picture_Overview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <h3>Available Picture:</h3>
    <p>        
        <asp:LinkButton ID="LinkButton1" runat="server" 
            PostBackUrl="/pages/admin/Picture_Add.aspx">Voeg nieuwe foto toe</asp:LinkButton>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
            BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
            CellSpacing="4" DataKeyNames="id" DataSourceID="sds_picture" ForeColor="Black" 
            GridLines="Vertical" Width="858px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                <asp:BoundField DataField="cat_id" HeaderText="cat_id" SortExpression="cat_id" />
                <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
                <asp:BoundField DataField="image" HeaderText="image" SortExpression="image" />
                <asp:BoundField DataField="description" HeaderText="description" SortExpression="description" />
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
        </asp:GridView>
        <asp:SqlDataSource ID="sds_picture" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MilanovDBConnectionString %>" 
            DeleteCommand="DELETE FROM [products] WHERE [id] = @id" 
            InsertCommand="INSERT INTO [products] ([name], [cat_id], [price], [image], [description]) VALUES (@name, @cat_id, @price,  @image, @description)" 
            SelectCommand="SELECT * FROM [products]" 
            UpdateCommand="UPDATE [products] SET [name] = @name, [cat_id] = @cat_id, [price] = @price, [image] = @image, [description] = @description WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="cat_id" Type="String" />
                <asp:Parameter Name="price" Type="Double" />
                <asp:Parameter Name="image" Type="String" />
                <asp:Parameter Name="description" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="cat_id" Type="String" />
                <asp:Parameter Name="price" Type="Double" />
                <asp:Parameter Name="image" Type="String" />
                <asp:Parameter Name="description" Type="String" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </p>
</asp:Content>