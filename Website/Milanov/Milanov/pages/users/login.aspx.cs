using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Milanov.pages.users
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "Login - Milanov";         // Change the current title
        }

        /// <summary>
        /// If button login is clicked, try to login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Check user credentials
            Users users = ConnectionClass.LoginUser(txtUsername.Text, txtPassword.Text);

            if (users != null)  // If user credentials are correct -> login
            {
                // Store login variables in session
                Session["login"] = users.Username;
                Session["role"] = users.Rol_id.ToString();

                if ((string)Session["role"] != "1")     // If user is NOT admin -> redirect to home.aspx
                {
                    Response.Redirect("/pages/home.aspx");
                }
                else    // If user is admin -> redirect to administrator.aspx
                {
                    Response.Redirect("/pages/admin/administrator.aspx");
                }
            }
            else    // If user credentials are incorrect -> error message
            {
                lblError.Text = "Inloggen mislukt, wachtwoord vergeten? Klik <a href='/pages/users/forgotpassword.aspx'>hier</a>";
            }
        }

        /// <summary>
        /// If button register is clicked, redirect to register.aspx
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("/pages/users/register.aspx");
        }
    }
}