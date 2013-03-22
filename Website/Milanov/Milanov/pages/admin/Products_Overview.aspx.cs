using System;
using System.Collections;
using System.IO;
using System.Web.UI.WebControls;

namespace Milanov.pages.admin
{
    public partial class products_overview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /*protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string selectedValue = ddlImage.SelectedValue;
            showImages();
            ddlImage.SelectedValue = selectedValue;
        }

        private void showImages()
        {
            string[] images = Directory.GetFiles(Server.MapPath("~/images/products/"));

            ArrayList imagelist = new ArrayList();

            foreach (string image in images)
            {
                string imageName = image.Substring(image.LastIndexOf(@"\") + 1);
                imagelist.Add(imageName);
            }

            ddlImage.DataSource = imagelist;
            ddlImage.DataBind();
        }*/
    }
}