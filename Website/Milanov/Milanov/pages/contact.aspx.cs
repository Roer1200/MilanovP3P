using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace Milanov.pages
{
    public partial class contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "Contact - Milanov";       // Change the current title
        }

        /// <summary>
        /// // If send button is clicked, try to send the e-mail
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSend_Click(object sender, EventArgs e)
        {            
            try
            {
                MailMessage eMailMessage = new MailMessage();
                eMailMessage.From = new MailAddress(HttpUtility.HtmlEncode(txtEmail.Text));
                eMailMessage.To.Add(new MailAddress("nhlemailtest@gmail.com"));

                eMailMessage.Subject = "Milanov: " + HttpUtility.HtmlEncode(txtSubject.Text);

                eMailMessage.Body = "<b>Naam:</b> " + HttpUtility.HtmlEncode(txtName.Text) + "<br />" +
                                    "<b>E-mail:</b> " + HttpUtility.HtmlEncode(txtEmail.Text) + "<br />" +
                                    "<b>Onderwerp:</b> " + HttpUtility.HtmlEncode(txtSubject.Text) + "<br />" +
                                    "<b>Bericht:</b> <br />" + HttpUtility.HtmlDecode(txtMessage.Content);
                eMailMessage.IsBodyHtml = true;

                eMailMessage.Priority = MailPriority.Normal;

                SmtpClient mSmtpClient = new SmtpClient();
                mSmtpClient.Send(eMailMessage);

                lblSend.Text = "Uw bericht is verzonden, eventueel antwoord zal worden verstuurd naar: " + txtEmail.Text;
            }
            catch (Exception)
            {
                lblSend.Text = "De mail is niet verzonden, onze excuses voor het ongemak.";
            }
        }

        /// <summary>
        /// If reset button is clicked, go to ClearTextFields();
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearTextFields();
        }

        /// <summary>
        /// Clears all the textfields.
        /// </summary>
        private void ClearTextFields()
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtSubject.Text = "";
            txtMessage.Content = "";
        }
    }
}