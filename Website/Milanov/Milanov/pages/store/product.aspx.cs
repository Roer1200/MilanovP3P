using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

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
                            <th rowspan='8' width='150px'><a href='/images/preview/{4}' rel='fancybox' title='{1}'><img runat='server' src='/images/preview/{4}' alt='{1}'/></a></th>
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

                        <tr>
                            <th valign='top'>Omschrijving:</th>
                            <td>{5}</td>
                        </tr>
            
                        </table>",
                                product.Id, product.Name, product.Cname, product.Price, product.Image, product.Description));

                        btnAddToCart.Visible = true;
                        btnBack.Visible = true;
                        lblOutput.Text = sb.ToString();
                        
                        this.Title = product.Name + " - Milanov";
                    }
                }   
                else
                {
                    Response.Redirect("~/pages/error.aspx");
                }
            }
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            string productId = Request.QueryString["productId"];
            List<string> ProductsInCart = (List<string>)Session["Cart"];
            if (ProductsInCart == null)
            {
                ProductsInCart = new List<string>();
            }
            if (!ProductsInCart.Contains(productId))
            {
                ProductsInCart.Add(productId);
                Session["Cart"] = ProductsInCart;
            }
            Response.Redirect("~/pages/store/shoppingcart.aspx");

        }
    }
}