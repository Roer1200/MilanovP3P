using System;
using System.Collections;
using System.IO;

namespace Milanov.pages
{
    public partial class Picture_Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["type"] != "administrator")
            {
                Response.Redirect("~/pages/account/Login.aspx");
            }
            string selectedValue = ddlImage.SelectedValue;
            showImages();
            ddlImage.SelectedValue = selectedValue;
        }

        private void showImages()
        {
            string[] images = Directory.GetFiles(Server.MapPath("~/images/pictures/"));

            ArrayList imagelist = new ArrayList();

            foreach (string image in images)
            {
                string imageName = image.Substring(image.LastIndexOf(@"\") + 1);
                imagelist.Add(imageName);
            }

            ddlImage.DataSource = imagelist;
            ddlImage.DataBind();
        }

        private void ClearTextFields()
        {
            txtName.Text = "";
            txtCategory.Text = "";
            txtPrice.Text = "";
            txtDescription.Text = "";
        }

        protected void btnUploadImage_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = Path.GetFileName(FileUpload1.FileName);
                FileUpload1.SaveAs(Server.MapPath("~/images/pictures/") + filename);
                lblResult.Text = "Image " + filename + " succesvol geupload!";
                Page_Load(sender, e);
            }

            catch (Exception)
            {                
                lblResult.Text = "Upload image failed!";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                int cat_id = Convert.ToInt32(txtCategory.Text);
                double price = Convert.ToDouble(txtPrice.Text);
                price = price / 100;
                string image = "~/images/pictures/" + ddlImage.SelectedValue;
                string description = txtDescription.Text;

                Products product = new Products(name, cat_id, price, image, description);
                ConnectionClass.AddProduct(product);

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