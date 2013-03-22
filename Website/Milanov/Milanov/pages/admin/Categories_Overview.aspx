<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd.Master" AutoEventWireup="true" CodeBehind="categories_overview.aspx.cs" Inherits="Milanov.pages.admin.categories_overview" %>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <h3>Categorieën:</h3>
    <p>  
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
            BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
            CellSpacing="4" DataKeyNames="id" DataSourceID="sds_categories" ForeColor="Black" 
            GridLines="Vertical" Width="900px"
            OnRowDeleting="GridView1_RowDeleting">
            <Columns>
                <asp:TemplateField HeaderText="Opties">
                    <ItemTemplate>
                        <asp:Button ID="btnEdit" runat="server" CommandName="Edit" Text="Bewerken" />
                        <asp:Button ID="btnDelete" runat="server" CommandName="Delete" Text="Verwijderen"
                        OnClientClick="return confirm('Weet u zeker dat u deze categorie wilt verwijderen?');" />
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
        <asp:SqlDataSource ID="sds_categories" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MilanovDBConnectionString %>" 
            DeleteCommand="DELETE FROM categories WHERE id = @id AND '0' = (SELECT COUNT(cat_id) FROM products WHERE cat_id = @id)" 
            SelectCommand="SELECT * FROM [categories]" 
            UpdateCommand="UPDATE [categories] SET [name] = @name WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </p>
    <p>
        <asp:Label ID="lblError" runat="server" Visible="false" Text="ERROR"></asp:Label>
    </p>
    <br />
    <p>
        <asp:LinkButton ID="lbtnAdd" runat="server" PostBackUrl="/pages/admin/categories_add.aspx">Klik hier om een nieuwe categorie toe te voegen.</asp:LinkButton>
    </p>
</asp:Content>