using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace Milanov.pages.users
{
    public partial class password_recovery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "Wachtwoord vergeten - Milanov";
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            string password = ConnectionClass.ForgotPassword(txtUsername.Text, txtEmail.Text);

            if (!password.Contains("Wachtwoord is niet verzonden"))
            {
                try
                {
                MailMessage eMailMessage = new MailMessage();
                eMailMessage.From = new MailAddress(HttpUtility.HtmlEncode("nhlemailtest@gmail.com"));
                eMailMessage.To.Add(new MailAddress(txtEmail.Text));

                eMailMessage.Subject = "Uw wachtwoord";

                eMailMessage.Body = "Beste " + HttpUtility.HtmlEncode(txtUsername.Text) + ",<br /><br />" +
                                    "Uw wachtwoord is: <b>" + password + "</b><br /><br />" +
                                    "Met vriendelijke groet," + "<br />" +
                                    "Milanov";
                eMailMessage.IsBodyHtml = true;

                eMailMessage.Priority = MailPriority.Normal;

                SmtpClient mSmtpClient = new SmtpClient();
                mSmtpClient.Send(eMailMessage);

                lblOutput.Text = "Uw wachtwoord is verzonden naar " + txtEmail.Text + ".";
                }

                catch (Exception)
                {
                    lblOutput.Text = "Er is iets fout gegaan, neem contact op met de websitebeheerder.";
                }
            }
            else
            {
                lblOutput.Text = password;
            }
        }
    }
}