using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Milanov.pages
{
    public partial class Picture_Overview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["type"] != "1")
            {
                Response.Redirect("~/pages/account/Login.aspx");
            }
        }
    }
}