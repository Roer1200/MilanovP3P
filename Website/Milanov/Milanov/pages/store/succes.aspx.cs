using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Text;
using System.Collections;

namespace Milanov.pages.store
{
    public partial class succes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "Succes - Milanov";

            if (!Page.IsPostBack)
            {
                string orderId = Request.QueryString["orderId"];
                if (!String.IsNullOrEmpty(orderId))
                {
                    if (orderId == ((string)Session["login"]))
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
                else
                {
                    Response.Redirect("~/error.aspx");
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

                string email = ConnectionClass.GetEmail((string)Session["login"]);

                List<string> images = new List<string>();

                foreach (Products product in cartList)
                {
                    sb.Append(string.Format(@"<img src='/images/products/{1}' alt='{0}' height='20%' width='20%' /><br /><br />", product.Name, product.Image));
                    images.Add(product.Image);

                    /* string ext = "." + product.Image.Substring(product.Image.LastIndexOf(@".") + 1);
                    if (imageExtensions.AllKeys.Contains(ext))
                    {
                        Response.ContentType = imageExtensions.Get(ext);
                        Response.AppendHeader("Content-Disposition", "attachment; filename=" + product.Image);
                        Response.TransmitFile(Server.MapPath("~/images/products/" + product.Image));
                        Response.End();
                    } */
                }

                lblImage.Text = sb.ToString();

                try
                {
                    MailMessage eMailMessage = new MailMessage();
                    eMailMessage.From = new MailAddress(HttpUtility.HtmlEncode("nhlemailtest@gmail.com"));
                    eMailMessage.To.Add(new MailAddress(email));

                    foreach(string img in images)
                    {
                        eMailMessage.Attachments.Add(new Attachment(Server.MapPath("/images/products/" + img)));
                    }

                    eMailMessage.Subject = "Uw bestelde foto's";

                    eMailMessage.Body = "Beste " + HttpUtility.HtmlEncode((string)(Session["login"])) + ",<br /><br />" +
                                        "Bedankt voor uw bestelling, in de bijlage vindt u de bestelde foto's.<br /><br />" +
                                        "Met vriendelijke groet," + "<br />" +
                                        "Milanov";
                    eMailMessage.IsBodyHtml = true;

                    eMailMessage.Priority = MailPriority.Normal;

                    SmtpClient mSmtpClient = new SmtpClient();
                    mSmtpClient.Send(eMailMessage);

                    lblOutput.Text = "Uw bestelde foto('s) zijn verzonden naar " + email + ".";
                }

                catch (Exception)
                {
                    lblOutput.Text = "Er is iets fout gegaan, neem contact op met de websitebeheerder.";
                }
            }
            else
            {
                // Something went wrong
            }
        }
    }
}