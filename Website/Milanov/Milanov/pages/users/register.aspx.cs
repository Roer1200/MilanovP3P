using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Milanov.pages.users
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //Create a new user
            Users users = new Users(txtUsername.Text, txtPassword.Text, txtEmail.Text, 3);

            //Register the user and return a result message
            lblResult.Text = ConnectionClass.RegisterUser(users);
        }
    }
}