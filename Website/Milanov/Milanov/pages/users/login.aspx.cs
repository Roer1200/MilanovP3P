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
            this.Title = "Login - Milanov";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Users users = ConnectionClass.LoginUser(txtUsername.Text, txtPassword.Text);

            if (users != null)
            {
                //Store login variables in session
                Session["login"] = users.Username;
                Session["role"] = users.Rol_id.ToString();

                if ((string)Session["role"] != "1")
                {
                    Response.Redirect("/pages/home.aspx");
                }
                else
                {
                    Response.Redirect("/pages/admin/administrator.aspx");
                }
            }
            else
            {
                lblError.Text = "Inloggen mislukt, wachtwoord vergeten? Klik <a href='/pages/users/password_recovery.aspx'>hier</a>";
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("/pages/users/register.aspx");
        }
    }
}