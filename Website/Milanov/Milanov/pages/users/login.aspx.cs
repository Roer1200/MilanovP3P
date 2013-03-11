﻿using System;
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

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Users users = ConnectionClass.LoginUser(txtUsername.Text, txtPassword.Text);

            if (users != null)
            {
                //Store login variables in session
                Session["login"] = users.Username;
                Session["type"] = users.Typ_id.ToString();

                if ((string)Session["type"] != "1")
                {
                    Response.Redirect("~/pages/home.aspx");
                }
                else
                {
                    Response.Redirect("~/pages/administrator.aspx");
                }
            }
            else
            {
                lblError.Text = "Login failed";
            }
        }
    }
}