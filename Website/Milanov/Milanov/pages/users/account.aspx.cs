using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Milanov.pages.users
{
    public partial class account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                lblAuth.Visible = true;
                lblAuth.Text = "You have to login to view this page, you will be redirected to the home page in 3 seconds";

                Response.AddHeader("REFRESH", "3;URL=/pages/Home.aspx");
            }
            else
            {
                lblCU.Text = "Here we will add the user CMS. -> Current user is: " + Session["login"];
            }
        }
    }
}