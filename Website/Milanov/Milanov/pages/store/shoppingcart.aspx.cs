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
                string delId = Request.QueryString["delId"];
                if (!String.IsNullOrEmpty(delId))
                {
                    List<string> delList = (List<string>)Session["Cart"];
                    if (delList != null && delList.Contains(delId))
                    {
                        delList.Remove(delId);
                        Session["Cart"] = delList;
                    }
                }
                GetProductsFromCart();
            }
        }

        private void GetProductsFromCart()
        {
            StringBuilder sb = new StringBuilder();
            double totalPrice = 0.00;

            if (Session["Cart"] != null)
            {
                List<string> productList = (List<string>)Session["Cart"];

                if (productList.Count > 0)
                {

                    ArrayList cartList = new ArrayList();
                    cartList = ConnectionClass.GetShopProducts(productList);

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


                    }

                    lblOutput.Text = sb.ToString() + "!null";
                    debug.Text = productList.Count.ToString() + "!null";
                    ltrPrice.Text = totalPrice.ToString() + "!null";
                }
                else
                {
                    sb.Append(
                            string.Format(@"
                            <tr>
                                <td colspan='4'>Het winkelmandje is leeg. !> 0</td>
                            </tr>"));

                    lblOutput.Text = sb.ToString();
                    ltrPrice.Text = totalPrice.ToString();
                }
            }
            else
            {
                sb.Append(
                        string.Format(@"
                            <tr>
                                <td colspan='4'>Het winkelmandje is leeg.</td>
                            </tr>"));

                lblOutput.Text = sb.ToString();
                ltrPrice.Text = totalPrice.ToString();
            }
        }

        protected void lbtnEmpty_Click(object sender, EventArgs e)
        {
            if (Session["Cart"] != null)
            {
                List<string> delList = (List<string>)Session["Cart"];
                if (delList.Count > 0)
                {
                    delList.Clear();
                    Session["Cart"] = delList;
                }
            }
            GetProductsFromCart();
        }

        protected void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (!lblOutput.Text.Contains("Het winkelmandje is leeg."))
            {
                Response.Redirect("~/pages/store/checkout.aspx");
            }
        }
    }
}