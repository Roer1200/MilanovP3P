using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Milanov
{
    public partial class BackEnd : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if a user is logged in
            if (Session["login"] != null)
            {
                lblLogin.Text = "Welcome " + Session["login"];
                lblLogin.Visible = true;
                lbLogin.Text = "Logout";

                // If user is not admin, send him to home
                if ((string)Session["role"] != "1")
                {
                    Response.Redirect("/pages/home.aspx");
                }
            }
            else
            {
                lblLogin.Visible = false;
                lbLogin.Text = "Login";
                Response.Redirect("/pages/users/login.aspx");
            }
        }

        protected void lbLogin_Click(object sender, EventArgs e)
        {
            if (lbLogin.Text == "Login") // User logs in
            {
                Response.Redirect("~/pages/users/login.aspx");
            }
            else // User logs out
            {
                Session.Clear();
                Response.Redirect("~/pages/home.aspx");
            }
        }
    }
}