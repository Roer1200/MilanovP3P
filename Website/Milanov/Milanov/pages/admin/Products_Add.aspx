<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd.Master" AutoEventWireup="true" CodeBehind="products_add.aspx.cs" Inherits="Milanov.pages.admin.products_add" %>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <h3>Voeg een nieuw product toe:</h3>

    <table cellspacing="15" class="pictureTable">
        <tr>
            <td style="width: 80px">
                <b>Naam:</b>
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtName" ErrorMessage="*">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 80px">
                <b>Categorie:</b>
            </td>
            <td>
                <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="True" 
                DataSourceID="sds_category" DataTextField="name" DataValueField="id">
                </asp:DropDownList>
                <asp:SqlDataSource ID="sds_category" runat="server" 
                ConnectionString="<%$ ConnectionStrings:MilanovDBConnectionString %>" 
                SelectCommand="SELECT [id], [name] FROM [categories] ORDER BY [name]">
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td style="width: 80px">
                <b>Prijs:</b>
            </td>
            <td>
                <asp:TextBox ID="txtPrice" runat="server" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtPrice" ErrorMessage="*">
                </asp:RequiredFieldValidator>
                <asp:RangeValidator
                    ID="RangeValidatorPrice" runat="server" 
                    ControlToValidate="txtPrice" ForeColor="Red" 
                    Type="Double" MinimumValue="0,01" MaximumValue="9999,99" ErrorMessage="Invalid Price">
                </asp:RangeValidator>

            </td>
        </tr>
        <tr>
            <td style="width: 80px">
                <b>Foto:</b>
            </td>
            <td>
                <asp:DropDownList ID="ddlImage" runat="server" Width="300px">
                </asp:DropDownList>
                <br/>
                <asp:FileUpload ID="FileUpload1" runat="server" /> 
                <asp:Button ID="btnUploadImage" runat="server" Text="Upload" 
                    onclick="btnUploadImage_Click" CausesValidation="False" />
            </td>            
        </tr>
        <tr>
            <td style="width: 80px">
                <b>Omschrijving:</b>
            </td>
            <td>
                <asp:TextBox ID="txtDescription" runat="server" Height="98px" TextMode="MultiLine" Width="332px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtDescription" ErrorMessage="*">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
    <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
    <br />
    <asp:Button ID="btnSave" runat="server" Text="Opslaan" onclick="btnSave_Click" />
    <asp:Button ID="btnBack" runat="server" Text="Terug" CausesValidation="false" OnClick="btnBack_Click"></asp:Button>
</asp:Content>