using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Milanov.pages.admin
{
    public partial class users_overview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            TableCell cell = GridView1.Rows[e.RowIndex].Cells[1];
            if (cell.Text == "1")
            {
                lblError.Visible = true;
                lblError.Text = "Het ingebouwde admin account kan niet worden verwijderd.";
            }
            else
            {
                lblError.Visible = false;
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            TableCell cell = GridView1.Rows[e.NewEditIndex].Cells[1];
            if (cell.Text == "1")
            {
                lblError.Visible = true;
                e.Cancel = true;
                lblError.Text = "Het ingebouwde admin account kan niet worden bewerkt.";
            }
            else
            {
                lblError.Visible = false;
            }
        }
    }
}