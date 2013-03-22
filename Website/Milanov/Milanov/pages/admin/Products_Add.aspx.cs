using System;
using System.Collections;
using System.IO;
using System.Drawing;

namespace Milanov.pages.admin
{
    public partial class products_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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
        }

        private void ClearTextFields()
        {
            txtName.Text = "";
            txtPrice.Text = "";
            txtDescription.Text = "";
        }

        protected void btnUploadImage_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = Path.GetFileName(FileUpload1.FileName);

                if (ddlImage.Items.FindByText(filename) != null)
                {
                    lblResult.Text = "Foto " + filename + " is al in gebruik, kies een andere naam.";
                }
                else
                {
                    FileUpload1.SaveAs(Server.MapPath("~/images/products/") + filename);          
                    lblResult.Text = "Foto " + filename + " succesvol geupload!";
                    Page_Load(sender, e);
                    ddlImage.SelectedValue = filename.ToString();

                    // Add preview layer
                    int opacity = 128; // 50% opaque (0 = invisible, 255 = fully opaque)
                    Bitmap bitmapImage = new Bitmap(Server.MapPath("~/images/products/") + filename);
                    Graphics graphicImage = Graphics.FromImage(bitmapImage);
                    for (int i = 1; i < 4; i++)
                    {
                        for (int j = 1; j < 4; j++)
                        {
                            graphicImage.DrawString("© Milanov", new Font("Verdana", 20, FontStyle.Bold), new SolidBrush(Color.FromArgb(opacity, Color.WhiteSmoke)), new Point(((bitmapImage.Width / 5) * j), ((bitmapImage.Height / 4) * i)));
                        }
                    }
                    bitmapImage.Save(Server.MapPath("~/images/preview/") + filename);

                    lblResult.Text = "Foto " + filename + " succesvol geupload!";
                }
            }

            catch (Exception)
            {                
                lblResult.Text = "Upload foto mislukt!";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                int cat_id = Convert.ToInt32(ddlCategory.SelectedValue);
                double price = Convert.ToDouble(txtPrice.Text);
                string image = ddlImage.SelectedValue;
                string description = txtDescription.Text;

                Products product = new Products(name, cat_id, price, image, description);
                ConnectionClass.AddProduct(product);

                lblResult.Text = "Upload nieuw product succesvol!";
                ClearTextFields();
            }

            catch (Exception)
            {
                lblResult.Text = "Upload new product mislukt!";                
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/pages/admin/products_overview.aspx");
        }
    }
}