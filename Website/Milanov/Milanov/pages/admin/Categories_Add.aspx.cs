using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Milanov.pages.admin
{
    public partial class Categories_Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["type"] != "1")
            {
                Response.Redirect("~/pages/account/Login.aspx");
            }
        }

        private void ClearTextFields()
        {
            txtName.Text = "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;

                Categories category = new Categories(name);
                ConnectionClass.AddCategory(category);

                lblResult.Text = "Upload new item succesvol!";
                ClearTextFields();
            }

            catch (Exception)
            {
                lblResult.Text = "Upload new item failed!";                
            }
        }
    }
}