using System;
using System.Collections;
using System.Text;

namespace Milanov.pages.store
{
    public partial class products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string categoryId = Request.QueryString["categoryId"];
                if (!String.IsNullOrEmpty(categoryId))
                {
                    ArrayList productsList = new ArrayList();
                    productsList = ConnectionClass.GetProductByCategory(categoryId.ToString());

                    StringBuilder sb = new StringBuilder();

                    foreach (Products product in productsList)
                    {
                        sb.Append(
                            string.Format(
                                @"<table class='productsTable'>
                        <tr>
                            <th rowspan='3' width='150px'><a href='/pages/store//product.aspx?productId={0}'><img runat='server' src='/images/products/{4}' alt='{1}'/></th>
                            <th width='50px'>Naam:</th>
                            <td>{1}</td>
                        </tr> 

                        <tr>
                            <th>Categorie:</th>
                            <td>{2}</td>
                        </tr>

                        <tr>
                            <th>Prijs:</th>
                            <td>€ {3}</td>
                        </tr>         
            
                       </table>",
                               product.Id, product.Name, product.Cat_id, product.Price, product.Image));

                        lblOutput.Text = sb.ToString();
                    }
                }
                else
                {
                    ArrayList productsList = new ArrayList();
                    productsList = ConnectionClass.GetProductByCategory("%");

                    StringBuilder sb = new StringBuilder();

                    foreach (Products product in productsList)
                    {
                        sb.Append(
                            string.Format(
                                @"<table class='productsTable'>
                        <tr>
                            <th rowspan='6' width='150px'><a href='/pages/store/product.aspx?productId={0}'><img runat='server' src='/images/products/{4}' alt='{1}'/></th>
                            <th width='50px'>Naam:</th>
                            <td>{1}</td>
                        </tr> 

                        <tr>
                            <th>Categorie:</th>
                            <td>{2}</td>
                        </tr>

                        <tr>
                            <th>Prijs:</th>
                            <td>€ {3}</td>
                        </tr>         
            
                       </table>",
                               product.Id, product.Name, product.Cat_id, product.Price, product.Image));

                        lblOutput.Text = sb.ToString();
                    }
                }
            }
        }
    }
}