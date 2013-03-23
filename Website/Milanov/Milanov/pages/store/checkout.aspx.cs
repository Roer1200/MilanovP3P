using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Text;
using System.Collections;
using System.Collections.Specialized;

namespace Milanov.pages.store
{
    public partial class checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "Betalen - Milanov";

            if (!Page.IsPostBack)
            {
                if (Session["Cart"] != null)
                {
                    List<string> boughtList = (List<string>)Session["Cart"];
                    ShowBoughtImages(boughtList);
                }
                else
                {
                    // Something went wrong
                }
            }                    
        }

        private void ShowBoughtImages(List<string> boughtList)
        {
            StringBuilder sb = new StringBuilder();

            /*NameValueCollection imageExtensions = new NameValueCollection();
            imageExtensions.Add(".jpg", "image/jpeg");
            imageExtensions.Add(".gif", "image/gif");
            imageExtensions.Add(".png", "image/png");*/

            if (boughtList.Count > 0)
            {

                ArrayList cartList = new ArrayList();
                cartList = ConnectionClass.GetShopProducts(boughtList);

                foreach (Products product in cartList)
                {
                    sb.Append(string.Format(@"<img src='/images/products/{1}' alt='{0}' height='20%' width='20%' />", product.Name, product.Image));
                    string ext = "." + product.Image.Substring(product.Image.LastIndexOf(@".") + 1);
                    /*if (imageExtensions.AllKeys.Contains(ext))
                    {
                        Response.ContentType = imageExtensions.Get(ext);
                        Response.AppendHeader("Content-Disposition", "attachment; filename=" + product.Image);
                        Response.TransmitFile(Server.MapPath("~/images/products/" + product.Image));
                        Response.End();
                    }*/
                }

                lblImage.Text = sb.ToString();
            }
            else
            {
                // Something went wrong
            }
        }
    }
}