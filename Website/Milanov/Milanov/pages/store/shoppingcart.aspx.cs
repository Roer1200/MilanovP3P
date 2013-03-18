using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Milanov.pages.store
{
    public partial class shoppingcart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetProductsFromCart();
            }
        }

        private void GetProductsFromCart()
        {
            if (Session["Cart"] != null)
            {
                List<string> productList = (List<string>)Session["Cart"];
                double totalPrice = 0;
                ArrayList cartList = new ArrayList();

                    cartList = ConnectionClass.GetProductDetailss(productList);

                StringBuilder sb = new StringBuilder();

                foreach (Products product in cartList)
                {
                    totalPrice += product.Price;
                    sb.Append(
                        string.Format(
                            @"<tr>
                            <td><a href='/pages/store/shoppingcart.aspx?delId={0}'>V</a></td>
                            <td><img src='/images/products/{4}' alt='{1}' height='40px' width='40px' /></td>
                            <td><a href='/pages/store/product.aspx?productId={0}'>{1}</td>
                            <td>&euro; {3}</td>
                                </tr>",
                            product.Id, product.Name, product.Cat_id, product.Price, product.Image));

                    lblOutput.Text = sb.ToString();
                }

                debug.Text = productList.Count.ToString();
                ltrPrice.Text = totalPrice.ToString();
            }
            else
            {
                lblOutput.Text = "Het winkelmandje is leeg.";
            }
        }
    }
}
                /*protected void lbtnEmpty_Click(object sender, EventArgs e)
            {
                List<int> ProductsInCart = (List<int>)Session["cart"];
                ProductsInCart.Clear();
                Session["cart"] = ProductsInCart;
                GetProductsFromCart();
            }

            private void GetProductsFromCart()
            {
                if (Session["cart"] != null)
                {
                    List<int> Cart = new List<int>();
                    Cart = (List<int>)Session["cart"];

                    double totalPrice = 0;

                    ArrayList cartList = new ArrayList();

                    foreach (int c in Cart)
                    {
                        cartList = ConnectionClass.GetProductDetails(c.ToString());
                    }

                    StringBuilder sb = new StringBuilder();

                    foreach (Products product in cartList)
                    {
                        totalPrice += product.Price;
                        sb.Append(
                            string.Format(
                                @"<tr>
                                <td><a href='/pages/store/shoppingcart.aspx?delId={0}'>V</a></td>
                                <td><img src='/images/products/{4}' alt='{1}' height='40px' width='40px' /></td>
                                <td><a href='/pages/store/product.aspx?productId={0}'>{1}</td>
                                <td>&euro; {3}</td>
                                    </tr>",
                                product.Id, product.Name, product.Cat_id, product.Price, product.Image));

                        lblOutput.Text = sb.ToString();                    
                    }
                
                    ltrPrice.Text = totalPrice.ToString();
                }
                else
                {
                    lblOutput.Text = "Het winkelmandje is leeg.";
                }
            }*/