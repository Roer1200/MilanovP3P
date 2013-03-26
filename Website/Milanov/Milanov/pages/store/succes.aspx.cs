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
            this.Title = "Succes - Milanov";        // Change the current title

            if (!Page.IsPostBack)
            {                
                string orderId = Request.QueryString["orderId"];
                if (!String.IsNullOrEmpty(orderId))     // url contains a orderId
                {
                    if (orderId == ((string)Session["login"]))      // orderId equals to current user
                    {
                        if (Session["Cart"] != null)    // session["Cart"] is NOT null -> ShowBoughtImages();
                        {
                            List<string> boughtList = (List<string>)Session["Cart"];
                            ShowAndMailBoughtImages(boughtList);
                        }
                        else    // session["Cart"] is null, redirect to error.aspx
                        {
                            Response.Redirect("~/error.aspx");
                        }
                    }
                    else    // orderId does not equals  to current user, redirect to error.aspx
                    {
                        Response.Redirect("~/error.aspx");
                    }
                }
                else // url does not contain a orderId
                {
                    Response.Redirect("~/error.aspx");
                }
            }                    
        }

        /// <summary>
        /// Shows and e-mails all the images that are bought by the user
        /// </summary>
        /// <param name="boughtList"></param>
        private void ShowAndMailBoughtImages(List<string> boughtList)
        {  
            /*      <- This code can be used for downloading the images. ->
             * NameValueCollection imageExtensions = new NameValueCollection();            
             * imageExtensions.Add(".jpg", "image/jpeg");            
             * imageExtensions.Add(".gif", "image/gif");            
             * imageExtensions.Add(".png", "image/png");
             */

            if (boughtList.Count > 0) // If the list of bought images is > 0 (this SHOULD always be true as we check this earlier) ->
            {
                StringBuilder sb = new StringBuilder();

                ArrayList cartList = new ArrayList();
                cartList = ConnectionClass.GetShopProducts(boughtList);

                string email = ConnectionClass.GetEmail((string)Session["login"]);

                List<string> images = new List<string>();

                foreach (Products product in cartList)
                {
                    sb.Append(string.Format(@"<img src='/images/products/{1}' alt='{0}' height='20%' width='20%' /><br /><br />", product.Name, product.Image));
                    images.Add(product.Image);

                    /* <- This code can be used for downloading the images. ->
                     * string ext = "." + product.Image.Substring(product.Image.LastIndexOf(@".") + 1);                    
                     * if (imageExtensions.AllKeys.Contains(ext))                    
                     * {                        
                     *  Response.ContentType = imageExtensions.Get(ext);                        
                     *  Response.AppendHeader("Content-Disposition", "attachment; filename=" + product.Image);                        
                     *  Response.TransmitFile(Server.MapPath("~/images/products/" + product.Image));                        
                     *  Response.End();                    
                     * } 
                     */
                }

                lblImage.Text = sb.ToString(); // Shows the images

                // E-mail the images
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
            else    // The list of bought images is NOT > 0 (this SHOULD never happen)
            {
                Response.Redirect("~/error.aspx");
            }
        }
    }
}