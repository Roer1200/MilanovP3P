using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Milanov.pages.account
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //Create a new user
            User user = new User(txtUsername.Text, txtPassword.Text, txtEmail.Text, "user");

            //Register the user and return a result message
            lblResult.Text = ConnectionClass.RegisterUser(user);
        }
    }
}