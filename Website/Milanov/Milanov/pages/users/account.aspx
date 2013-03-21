<%@ Page Title="" Language="C#" MasterPageFile="~/FrontEnd.Master" AutoEventWireup="true" CodeBehind="account.aspx.cs" Inherits="Milanov.pages.users.account" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Milanov - Profiel</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <asp:Label ID="lblCU" runat="server"></asp:Label>
    <br /><br />
    
    <!-- User Info -->
    <p>
    <asp:Button ID="btnInfo" runat="server" Text="Mijn gegevens" CausesValidation="false" OnClick="btnInfo_Click" />
    <asp:Table ID="tblInfo" runat="server" Visible="false">
        <asp:TableRow>
            <asp:TableCell>
                <b>Gebruikersnaam:</b>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblUsername" runat="server"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <b>E-mail:</b>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblEmail" runat="server"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <b>Rol:</b> 
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblRole" runat="server"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    </p>

    <!-- Change Password -->
    <p>
    <asp:Button ID="btnChangePassword" runat="server" Text="Wachtwoord veranderen"  CausesValidation="false" OnClick="btnChangePassword_Click" />
    <asp:Table ID="tblPassword" runat="server" Visible="false">
        <asp:TableRow>
            <asp:TableCell>
                <b>Huidige wachtwoord:</b>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtPcurrent" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtPcurrent" ErrorMessage="*">
                </asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <b>Nieuwe wachtwoord:</b>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtPnew" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtPnew" ErrorMessage="*">
                </asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <b>Bevestig wachtwoord:</b>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtPconfirm" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtPconfirm" ErrorMessage="*">
                </asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                   <asp:Button ID="btnPsubmit" runat="server" Text="Wijzigen"  OnClick="btnPsubmit_Click" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:Label ID="lblPoutput" runat="server"></asp:Label>
                <asp:CompareValidator ID="CompareValidator4" runat="server" 
                    ControlToCompare="txtPnew" ControlToValidate="txtPcurrent" 
                    ErrorMessage="Het nieuwe wachtwoord mag niet hetzelfde zijn als het huidige wachtwoord." Operator="NotEqual" ForeColor="Red">
                </asp:CompareValidator><br />
                <asp:CompareValidator ID="CompareValidator3" runat="server" 
                    ControlToCompare="txtPconfirm" ControlToValidate="txtPnew" 
                    ErrorMessage="Wachtwoorden moeten overeenkomen." ForeColor="Red">
                </asp:CompareValidator>                
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    </p>

    <!-- Change Email -->
    <p>
    <asp:Button ID="btnChangeEmail" runat="server" Text="Email veranderen" CausesValidation="false" OnClick="btnChangeEmail_Click" />
    <asp:Table ID="tblEmail" runat="server" Visible="false">
        <asp:TableRow>
            <asp:TableCell>
                <b>Huidige e-mail:</b>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtEcurrent" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtEcurrent" ErrorMessage="*">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator
                    ID="RegularExpressionValidatorEmail1" runat="server" 
                    ErrorMessage="Invalid E-mail" ControlToValidate="txtEcurrent" ForeColor="Red" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                </asp:RegularExpressionValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <b>Nieuwe e-mail:</b>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtEnew" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="txtEnew" ErrorMessage="*">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator
                    ID="RegularExpressionValidator2" runat="server" 
                    ErrorMessage="Invalid E-mail" ControlToValidate="txtEnew" ForeColor="Red" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                </asp:RegularExpressionValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <b>Bevestig e-mail:</b>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtEconfirm" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="txtEconfirm" ErrorMessage="*">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator
                    ID="RegularExpressionValidator3" runat="server" 
                    ErrorMessage="Invalid E-mail" ControlToValidate="txtEconfirm" ForeColor="Red" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                </asp:RegularExpressionValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                   <asp:Button ID="btnEsubmit" runat="server" Text="Wijzigen" OnClick="btnEsubmit_Click" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:Label ID="lblEoutput" runat="server"></asp:Label>                
                <asp:CompareValidator ID="CompareValidator2" runat="server" 
                    ControlToCompare="txtEnew" ControlToValidate="txtEcurrent" 
                    ErrorMessage="Het nieuwe e-mail adres mag niet hetzelfde zijn als de huidige e-mail." Operator="NotEqual" ForeColor="Red">
                </asp:CompareValidator><br />
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="txtEconfirm" ControlToValidate="txtEnew" 
                    ErrorMessage="E-mail adressen moeten overeenkomen" ForeColor="Red">
                </asp:CompareValidator>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    </p>

    <p>
    <asp:Button ID="btnCMS" runat="server" Text="Beheergedeelte" CausesValidation="false" OnClick="btnCMS_Click" />
    </p>
</asp:Content>