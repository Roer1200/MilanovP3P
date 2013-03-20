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
            
        }

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
                                    "<b>Bericht:</b> <br />" + HttpUtility.HtmlEncode(txtMessage.Text.ToString());
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

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearTextFields();
        }

        private void ClearTextFields()
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtSubject.Text = "";
            txtMessage.Text = "";
        }
    }
}