using System;
using System.Collections;
using System.Text;

namespace Milanov.pages.store
{
    public partial class products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillPage();
        }

        private void FillPage()
        {
            ArrayList productsList = new ArrayList();

            if (!IsPostBack)
            {
                productsList = ConnectionClass.GetProductByCategory("%");
            }
            else
            {
                productsList = ConnectionClass.GetProductByCategory(DropDownList1.SelectedValue);
            }

            StringBuilder sb = new StringBuilder();

            foreach (Products product in productsList)
            {
                sb.Append(
                    string.Format(
                        @"<table class='productTable'>
                <tr>
                    <th rowspan='6' width='150px'><a rel='fancybox' href='/images/products/{3}' title='{0}'><img runat='server' src='/images/products/{3}'/></th>
                    <th width='50px'>Naam:</th>
                    <td>{0}</td>
                </tr> 

                <tr>
                    <th>Categorie:</th>
                    <td>{1}</td>
                </tr>

                <tr>
                    <th>Prijs:</th>
                    <td>€ {2}</td>
                </tr>         
            
               </table>",
                       product.Name, product.Cat_id, product.Price, product.Image));

                lblOutput.Text = sb.ToString();
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillPage();
        }
    }
}