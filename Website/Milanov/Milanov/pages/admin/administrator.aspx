<%@ Page Title="" Language="C#" MasterPageFile="~/BackEnd.Master" AutoEventWireup="true" CodeBehind="administrator.aspx.cs" Inherits="Milanov.pages.admin.administrator" %>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <img id="Img1" runat="server" src="~/images/lipsum.gif" alt="lipsum" class="imgLeft" />
    <h3>Title 1</h3>
    <p>
        Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum lectus urna,
        viverra in luctus quis, ullamcorper quis lorem. Vestibulum vulputate pellentesque
        velit, et placerat dolor pulvinar in. Class aptent taciti sociosqu ad litora torquent
        per conubia nostra, per inceptos himenaeos. Sed sit amet velit at purus elementum
        dapibus. Nulla dapibus auctor vulputate. Sed cursus nisi at mauris mollis semper.
        Vestibulum consectetur cursus dui sit amet pretium.</p><br /><br />
    <center>
        <table>
            <tr>
                <td>
                    <a href="/pages/admin/categories_overview.aspx"><p class="cmsIcon"><img src="/images/icon_c.png" alt="categories" /><span>Categoriebeheer</span></p></a>
                </td>
                <td>    
                    <a href="/pages/admin/products_overview.aspx"><p class="cmsIcon"><img src="/images/icon_p.png" alt="products" /><span>Productbeheer</span></p></a>
                </td>
                <td>
                    <a href="/pages/admin/users_overview.aspx"><p class="cmsIcon"><img src="/images/icon_u.png" alt="users" /><span>Gebruikersbeheer</span></p></a>
                </td>
            </tr>
        </table>
    </center>
</asp:Content>