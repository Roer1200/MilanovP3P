<%@ Page Title="" Language="C#" MasterPageFile="~/StoreEnd.Master" AutoEventWireup="true" CodeBehind="shoppingcart.aspx.cs" Inherits="Milanov.pages.store.shoppingcart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">    
    <asp:LinkButton ID="lbtnBack" runat="server" Text="<img src='/images/backtoshop.png' alt='' />&nbsp;Verder winkelen" PostBackUrl="~/pages/store/products.aspx"></asp:LinkButton>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="lbtnEmpty" runat="server" Text="<img src='/images/trashmini.png' alt='' />&nbsp;Leegmaken" OnClick="lbtnEmpty_Click" ></asp:LinkButton>

    <br /><br />
    <p>
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
                    Totaal: &euro; <asp:Literal ID="ltrPrice" runat="server" Text="ERROR"></asp:Literal><br />
                    <asp:Literal ID="ltrDiscountN" runat="server" Visible="false" Text="Korting: &euro; "></asp:Literal>
                    <asp:Literal ID="ltrDiscount" runat="server" Visible="false" Text="ERROR"></asp:Literal><br />
                    <asp:Literal ID="ltrDiscPriceN" runat="server" Visible="false" Text="Uw prijs: &euro; "></asp:Literal>
                    <asp:Literal ID="ltrDiscPrice" runat="server" Visible="false" Text="ERROR"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="right">
                    <asp:Button ID="btnCheckOut" runat="server" Text="Bestelling afronden" OnClick="btnCheckOut_Click" />
                </td>
            </tr>
        </table>
    </p>

    <p>
        <asp:Label ID="lblError" runat="server" Visible="false" Text="ERROR"></asp:Label>
    </p>
</asp:Content>