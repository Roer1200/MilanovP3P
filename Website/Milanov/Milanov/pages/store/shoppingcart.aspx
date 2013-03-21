<%@ Page Title="" Language="C#" MasterPageFile="~/StoreEnd.Master" AutoEventWireup="true" CodeBehind="shoppingcart.aspx.cs" Inherits="Milanov.pages.store.shoppingcart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">    
    <asp:LinkButton ID="lbtnBack" runat="server" Text="Verder winkelen" PostBackUrl="~/pages/store/products.aspx"></asp:LinkButton>
    <asp:LinkButton ID="lbtnEmpty" runat="server" Text="Leegmaken" OnClick="lbtnEmpty_Click" ></asp:LinkButton>
    
    <table class="cartTable">
        <tr>
            <th>Verwijderen</th>
            <th></th>
            <th>Artikel</th>
            <th>Subtotaal</th>
        </tr>
        <asp:Label ID="lblOutput" runat="server" Text="FOUT!!!!"></asp:Label>
        <tr>
            <td colspan="4" align="right">
                Totaal: &euro; <asp:Literal ID="ltrPrice" runat="server" Text="fout"></asp:Literal><br />
                <asp:Literal ID="ltrDiscount" runat="server" Visible="false" Text="fout"></asp:Literal><br />
                <asp:Literal ID="ltrDiscPrice" runat="server" Visible="false" Text="fout"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td colspan="4" align="right">
                <asp:Button ID="btnCheckOut" runat="server" Text="Bestelling afronden" OnClick="btnCheckOut_Click" />
            </td>
        </tr>
    </table>
    <asp:Label ID="lblError" runat="server" Visible="false" Text="ERROR"></asp:Label>
</asp:Content>