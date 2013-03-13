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
                if ((string)Session["role"] != "1")
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

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (txtPcurrent.Visible != true && txtPnew.Visible != true && txtPconfirm.Visible != true)
            {
                txtPcurrent.Visible = true;
                txtPnew.Visible = true;
                txtPconfirm.Visible = true;
                btnPsubmit.Visible = true;
            }
            else
            {
                txtPcurrent.Visible = false;
                txtPnew.Visible = false;
                txtPconfirm.Visible = false;
                btnPsubmit.Visible = false;
            }
        }

        protected void btnPsubmit_Click(object sender, EventArgs e)
        {

        }

        protected void btnChangeEmail_Click(object sender, EventArgs e)
        {
            if (email.Visible != true)
            {
                email.Visible = true;
            }
            else
            {
                email.Visible = false;
            }
        }

        protected void btnEsubmit_Click(object sender, EventArgs e)
        {

        }
    }
}