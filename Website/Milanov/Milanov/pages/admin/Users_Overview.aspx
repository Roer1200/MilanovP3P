<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd.Master" AutoEventWireup="true" CodeBehind="users_overview.aspx.cs" Inherits="Milanov.pages.admin.users_overview" %>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <h3>Gebruikers:</h3>
    <p> 
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
            BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
            CellSpacing="4" DataKeyNames="id" DataSourceID="sds_Users" ForeColor="Black" 
            GridLines="Vertical" Width="1000px" 
            OnRowDeleting="GridView1_RowDeleting"
            OnRowEditing="GridView1_RowEditing">            
            <Columns>
                <asp:TemplateField HeaderText="Opties">
                    <ItemTemplate>
                        <asp:Button ID="btnEdit" runat="server" CommandName="Edit" Text="Bewerken" />
                        <asp:Button ID="btnDelete" runat="server" CommandName="Delete" Text="Verwijderen" 
                        OnClientClick="return confirm('Weet u zeker dat u deze gebruiker wilt verwijderen?');" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Button ID="btnUpdate" runat="server" CommandName="Update" Text="Update" />
                        <asp:Button ID="btnCancel" runat="server" CommandName="Cancel" Text="Annuleer" />
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="username" HeaderText="Naam" ReadOnly="True" SortExpression="username" />
                <asp:BoundField DataField="email" HeaderText="E-mail" ReadOnly="True" SortExpression="email" />
                <asp:TemplateField HeaderText="Rol" SortExpression="rname">
                <ItemTemplate>
                    <asp:Label ID="lblRname" runat="server" Text='<%# Bind("rname") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlRoles" runat="server" DataSourceID="sds_roles" 
                    DataTextField="name" DataValueField="name" SelectedValue='<%# Bind("rname") %>'>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="sds_roles" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:MilanovDBConnectionString %>" 
                    SelectCommand="SELECT [name] FROM [roles] ORDER BY [name]">
                    </asp:SqlDataSource>
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
        <asp:SqlDataSource ID="sds_users" runat="server" 
            ConnectionString="<%$ ConnectionStrings:MilanovDBConnectionString %>" 
            DeleteCommand="DELETE FROM [users] WHERE [id] = @id AND id <> 1" 
            SelectCommand="SELECT u.id, u.username, u.email, r.name AS rname FROM users AS u INNER JOIN roles AS r ON u.rol_id = r.id" 
            UpdateCommand="UPDATE u SET u.rol_id = r.id FROM users AS u INNER JOIN roles AS r ON r.id = (SELECT id FROM roles WHERE name = @rname) WHERE u.id = @id AND u.id <> 1">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="rname" Type="String" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </p>
    <p>
        <asp:Label ID="lblError" runat="server" Visible="false" Text="ERROR"></asp:Label>
    </p>
</asp:Content>
