using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Milanov.pages.admin
{
    public partial class categories_overview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// If button delete is clicked, here it will check what you are trying to delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // If you are trying to delete a category that is still in use by a product it will display a error message and disable you from deleting
            TableCell cell = GridView1.Rows[e.RowIndex].Cells[1];
            bool error = ConnectionClass.GetInUseCategories(cell.Text);

            if (error == true)
            {
                lblError.Visible = true;
                lblError.Text = "Deze categorie is in gebruik door één of meerdere producten en kan hierdoor niet worden verwijderd.";
            }
            else
            {
                lblError.Visible = false;
            }
        }
    }
}