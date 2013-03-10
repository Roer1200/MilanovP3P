using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Milanov.pages.admin
{
    public partial class Categories_Overview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["type"] != "1")
            {
                GridView1.Visible = false;
                lblAuth.Visible= true;
                lblAuth.Text = "You have to login as an admin, you will be redirected to the home page in 3 seconds";
                
                Response.AddHeader("REFRESH","3;URL=/pages/Home.aspx");
            }
        }
    }
}