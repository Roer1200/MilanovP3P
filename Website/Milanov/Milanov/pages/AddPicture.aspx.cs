using System;
using System.Collections;
using System.IO;

namespace Milanov.pages
{
    public partial class AddPicture : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string selectedValue = ddlImage.SelectedValue;
            showImages();
            ddlImage.SelectedValue = selectedValue;
        }
        private void showImages()
        {
            string[] images = Directory.GetFiles(Server.MapPath("../images/pictures/"));

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
            txtDesc.Text = "";
        }
        protected void btnUploadFoto_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = Path.GetFileName(FileUpload1.FileName);
                FileUpload1.SaveAs(Server.MapPath("../images/pictures/") + filename);
                lblResult.Text = "Image" + filename + "succesvol geupload!";
                Page_Load(sender, e);
            }
            catch (Exception)
            {
                
                lblResult.Text = "Upload failed!";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                string category = txtCategory.Text;
                double price = Convert.ToDouble(txtPrice.Text);
                price = price / 100;
                string image = "../images/pictures/" + ddlImage.SelectedValue;
                string description = txtDesc.Text;

                Picture picture = new Picture(name,category,price,image,description);
                ConnectionClass.AddPicture(picture);

                lblResult.Text = "Upload succesvol!";
                ClearTextFields();
            }
            catch (Exception)
            {
                lblResult.Text = "Upload failed!";
                
            }
        }

    }
}