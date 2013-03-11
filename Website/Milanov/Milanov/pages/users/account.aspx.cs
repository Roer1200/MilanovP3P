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
            if (Session["login"] != null)
            {
                if ((string)Session["type"] != "1")
                {
                    lblCU.Text = "Here we will add the user CMS. -> Current user is: " + Session["login"];                    
                }
                else
                {
                    Response.Redirect("/pages/administrator.aspx");
                }
            }
            else
            {
                Response.Redirect("/pages/users/login.aspx");              
            }
        }
    }
}