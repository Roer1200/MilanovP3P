<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd.Master" AutoEventWireup="true" CodeBehind="products_overview.aspx.cs" Inherits="Milanov.pages.admin.products_overview" %>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <h3>Producten:</h3>
    <p>  
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        CellSpacing="4" DataKeyNames="id" DataSourceID="sds_products" ForeColor="Black" 
        GridLines="Vertical" Width="1000px">
        <Columns>
            <asp:TemplateField HeaderText="Opties">
                <ItemTemplate>
                    <asp:Button ID="btnEdit" runat="server" CommandName="Edit" Text="Bewerken" />
                    <asp:Button ID="btnDelete" runat="server" CommandName="Delete" Text="Verwijderen" 
                    OnClientClick="return confirm('Weet u zeker dat u dit product wilt verwijderen?');" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Button ID="btnUpdate" runat="server" CommandName="Update" Text="Update" />
                    <asp:Button ID="btnCancel" runat="server" CommandName="Cancel" CausesValidation="false" Text="Annuleer" />
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />

            <asp:TemplateField HeaderText="Naam" SortExpression="name">
                    <ItemTemplate>
                        <asp:Label ID="lblName" runat="server" Text='<%# Bind("name") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Textbox ID="txtName" runat="server" Text='<%# Bind("name") %>'></asp:Textbox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtName" ErrorMessage="*">
                        </asp:RequiredFieldValidator>
                    </EditItemTemplate>
                </asp:TemplateField>

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

            <asp:TemplateField HeaderText="Prijs" SortExpression="price">
                <ItemTemplate>
                    <asp:Label ID="lblPrice" runat="server" Text='<%# Bind("price") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Textbox ID="txtPrice" runat="server" Text='<%# Bind("price") %>'></asp:Textbox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtPrice" ErrorMessage="*">
                    </asp:RequiredFieldValidator>
                    <asp:RangeValidator
                        ID="RangeValidatorPrice" runat="server" 
                        ControlToValidate="txtPrice" ForeColor="Red" 
                        Type="Currency" MinimumValue="0,01" MaximumValue="9999,99" ErrorMessage="Invalid Price">
                    </asp:RangeValidator>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Foto" SortExpression="image">
                <ItemTemplate>
                    <asp:Label ID="lblImage" runat="server" Text='<%# Bind("image") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Textbox ID="txtImage" runat="server" Text='<%# Bind("image") %>'></asp:Textbox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtImage" ErrorMessage="*">
                    </asp:RequiredFieldValidator>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Omschrijving" SortExpression="description">
                <ItemTemplate>
                    <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("description") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Textbox ID="txtDescription" runat="server" Text='<%# Bind("description") %>' TextMode="MultiLine"></asp:Textbox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="txtDescription" ErrorMessage="*">
                    </asp:RequiredFieldValidator>
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#F7F7DE" />
        <AlternatingRowStyle BackColor="White" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FBFBF2" />
        <SortedAscendingHeaderStyle BackColor="#848384" />
        <SortedDescendingCellStyle BackColor="#EAEAD3" />
        <SortedDescendingHeaderStyle BackColor="#575357" />
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
                <asp:Parameter Name="price" Type="Decimal" />
                <asp:Parameter Name="image" Type="String" />
                <asp:Parameter Name="description" Type="String" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </p>
    <br />
    <p>
        <asp:LinkButton ID="lbAdd" runat="server" PostBackUrl="/pages/admin/products_add.aspx">Klik hier om een nieuw product toe te voegen.</asp:LinkButton>
    </p>
</asp:Content>