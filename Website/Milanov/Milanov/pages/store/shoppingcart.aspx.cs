using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Milanov.pages.store
{
    public partial class shoppingcart : System.Web.UI.Page
    {
        decimal _TotalPrice = 0.00m;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "Winkelwagen - Milanov";
        
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

            if (Session["Cart"] != null)
            {
                List<string> productList = (List<string>)Session["Cart"];

                if (productList.Count > 0)
                {

                    ArrayList cartList = new ArrayList();
                    cartList = ConnectionClass.GetShopProducts(productList);

                    foreach (Products product in cartList)
                    {
                        _TotalPrice += product.Price;
                        sb.Append(
                            string.Format(
                                @"<tr>
                            <td><a href='/pages/store/shoppingcart.aspx?delId={0}'><img src='/images/trash.png' alt='trash' /></a></td>
                            <td><img src='/images/preview/{3}' alt='{1}' height='40px' width='40px' /></td>
                            <td><a href='/pages/store/product.aspx?productId={0}'>{1}</td>
                            <td>&euro; {2}</td>
                                </tr>",
                                product.Id, product.Name, product.Price, product.Image));
                    }

                    lblOutput.Text = sb.ToString();
                    checkForDiscount();
                }
                else
                {
                    sb.Append(
                            string.Format(@"
                            <tr>
                                <td colspan='4'>Het winkelmandje is leeg.</td>
                            </tr>"));

                    lblOutput.Text = sb.ToString();
                    ltrPrice.Text = _TotalPrice.ToString();
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
                ltrPrice.Text = _TotalPrice.ToString();
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
                string nPrice = ltrPrice.Text;
                string dPrice = ltrDiscPrice.Text;

                nPrice = nPrice.Replace(@",", @".");
                dPrice = dPrice.Replace(@",", @".");

                //Pay pal process Refer for what are the variable are need to send http://www.paypalobjects.com/IntegrationCenter/ic_std-variable-ref-buy-now.html

                string redirecturl = "";

                //Mention URL to redirect content to paypal site
                redirecturl += "https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_xclick&business=" + ConfigurationManager.AppSettings["paypalemail"].ToString();

                //First name i assign static based on login details assign this value
                redirecturl += "&first_name=milanovfirst";

                //City i assign static based on login user detail you change this value
                redirecturl += "&city=milanovcity";

                //State i assign static based on login user detail you change this value
                redirecturl += "&state=milanovstate";

                //Product Name
                redirecturl += "&item_name=" + "Pictures";

                    if ((string)Session["role"] == "2")
                    {
                        //Product Amount
                        redirecturl += "&amount=" + dPrice;
                    }
                    else
                    {
                        // Product Amount
                        redirecturl += "&amount=" + nPrice;
                    }
                 
                //Business contact id
                //redirecturl += "&business=nameatgmail.com";

                //Shipping charges if any
                redirecturl += "&shipping=0";

                //Handling charges if any
                redirecturl += "&handling=0";

                //Tax amount if any
                redirecturl += "&tax=0";

                //Add quatity i added one only statically 
                redirecturl += "&quantity=1";

                //Currency code 
                redirecturl += "&currency=EUR";

                //Success return page url
                redirecturl += "&return=" + ConfigurationManager.AppSettings["SuccessURL"].ToString() + "?orderId=" + ((string)(Session["login"]));

                //Failed return page url
                redirecturl += "&cancel_return=" + ConfigurationManager.AppSettings["FailedURL"].ToString();

                Response.Redirect(redirecturl);
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Er moet eerst een product worden toegevoegd.";
            }
        }

        private void checkForDiscount()
        {
            if ((string)Session["role"] == "2" && _TotalPrice > 0)
            {
                decimal originalPrice = _TotalPrice;
                decimal discountPrice = ((_TotalPrice / 100) * 5); // 5% korting

                _TotalPrice = ((_TotalPrice / 100) * 95); // 5% korting voor vaste klanten
                discountPrice = Math.Round(discountPrice, 2);
                _TotalPrice = Math.Round(_TotalPrice, 2);
                ltrPrice.Text = originalPrice.ToString();
                ltrDiscount.Visible = true;
                ltrDiscPrice.Visible = true;
                ltrDiscountN.Visible = true;
                ltrDiscPriceN.Visible = true;
                ltrDiscount.Text = discountPrice.ToString();
                ltrDiscPrice.Text = _TotalPrice.ToString();
            }
            else
            {
                ltrPrice.Text = _TotalPrice.ToString();
                ltrDiscount.Visible = false;
                ltrDiscPrice.Visible = false;
                ltrDiscountN.Visible = false;
                ltrDiscPriceN.Visible = false;
            }
        }
    }
}