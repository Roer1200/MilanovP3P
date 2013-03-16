using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Milanov.pages.admin
{
    public partial class categories_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void ClearTextFields()
        {
            txtName.Text = "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // Create a new category
            Categories category = new Categories(txtName.Text);

            // Save the category and return a result message
            lblResult.Text = ConnectionClass.AddCategory(category);

            // If category is added -> ClearTextFields
            if (lblResult.Text == "Categorie toegevoegd!")
            {
                ClearTextFields();
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/pages/admin/categories_overview.aspx");
        }
    }
}