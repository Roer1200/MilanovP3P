using System;
using System.Collections;
using System.Text;

namespace Milanov.pages.store
{
    public partial class product_details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string productId = Request.QueryString["productId"];
                if (!String.IsNullOrEmpty(productId))
                {
                    ArrayList productList = new ArrayList();
                    productList = ConnectionClass.GetProductDetails(productId);

                    StringBuilder sb = new StringBuilder();

                    foreach (Products product in productList)
                    {
                        sb.Append(
                            string.Format(
                                @"<table class='productTable'>
                        <tr>
                            <th rowspan='3' width='150px'><a href='/images/products/{4}' rel='fancybox' title='{1}'><img runat='server' src='/images/products/{4}' alt='{1}'/></a></th>
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

                        this.Title = product.Name;
                    }
                }   
                else
                {
                    Server.Transfer("~/not-found.aspx");
                }
            }
        }
    }
}