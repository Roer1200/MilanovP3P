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

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
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