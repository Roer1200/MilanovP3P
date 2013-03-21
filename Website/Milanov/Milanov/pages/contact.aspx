<%@ Page Title="" Language="C#" MasterPageFile="~/FrontEnd.Master" AutoEventWireup="true" CodeBehind="contact.aspx.cs" Inherits="Milanov.pages.contact" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Milanov - Contact</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h3>Contact</h3>
    <p>
        Milanov<br />
        Straatnaam XX<br />
        XXXX XX Woonplaats<br />
        T: 0123 - 456789<br />
        M: 06 - 12345678<br />    
        E:<a href="mailto:info@milanov.nl">info@milanov.nl</a>
    </p>
    <br />
    <br />
    <table>
        <tr>
            <td style="width: 90px">Naam: </td>
            <td>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="*" ControlToValidate="txtName"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 90px">E-mail: </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtEmail" ErrorMessage="*">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator
                    ID="RegularExpressionValidatorEmail" runat="server" 
                    ErrorMessage="Invalid E-mail" ControlToValidate="txtEmail" ForeColor="Red" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                </asp:RegularExpressionValidator>                
            </td>
        </tr>
        <tr>
            <td style="width: 90px">Onderwerp:</td>
            <td>
                <asp:TextBox ID="txtSubject" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="*" ControlToValidate="txtSubject"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 90px">Uw bericht: </td>
            <td>                
                <cc1:Editor ID="txtMessage" runat="server" Width="740px"/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ErrorMessage="U bent verplicht een bericht te schrijven." ControlToValidate="txtMessage"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
    <asp:Button ID="btnSend" runat="server" Text="Verzenden" OnClick="btnSend_Click" />
    <asp:Button ID="btnReset" runat="server" Text="Wis velden" CausesValidation="false" OnClick="btnReset_Click" /><br />
    <asp:Label ID="lblSend" runat="server"></asp:Label>
</asp:Content>