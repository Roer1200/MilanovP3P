using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Milanov.pages.account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Users users = ConnectionClass.LoginUser(txtUsername.Text, txtPassword.Text);

            if (users != null)
            {
                //Store login variables in session
                Session["login"] = users.Username;
                Session["type"] = users.Typ_id.ToString();

                Response.Redirect("~/pages/Home.aspx");
            }
            else
            {
                lblError.Text = "Login failed";
            }
        }
    }
}