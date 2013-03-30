using System;
using System.Collections;
using System.IO;
using System.Drawing;
using System.Collections.Specialized;
using System.Linq;

namespace Milanov.pages.admin
{
    public partial class products_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string selectedValue = ddlImage.SelectedValue;      // This is probably not necessary ...
            showImages();                                       // Execute showImages()
            ddlImage.SelectedValue = selectedValue;             // This is probably not necessary ...
        }
        
        /// <summary>
        /// Adds and shows all the available images in the DropDownList
        /// </summary>
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

        /// <summary>
        /// Clears all the textfields.
        /// </summary>
        private void ClearTextFields()
        {
            txtName.Text = "";
            txtPrice.Text = "";
            txtDescription.Text = "";
        }

        /// <summary>
        /// If button upload is clicked, try to upload the file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUploadImage_Click(object sender, EventArgs e)
        {
            try
            {
                NameValueCollection imageExtensions = new NameValueCollection();
                imageExtensions.Add(".jpg", "image/jpeg");
                imageExtensions.Add(".gif", "image/gif");
                imageExtensions.Add(".png", "image/png");
                                 
                string filename = Path.GetFileName(FileUpload1.FileName);
                string ext = "." + filename.Substring(filename.LastIndexOf(@".") + 1);
                
                if (imageExtensions.AllKeys.Contains(ext)) // check if extension is .jpg, .gif or .png
                {
                    if (ddlImage.Items.FindByText(filename) != null) // check if filename is in use
                    {
                        lblResult.Text = "Foto " + filename + " is al in gebruik, kies een andere naam.";
                    }
                    else // extension is correct, name is not in use -> upload image and make preview image
                    {
                        FileUpload1.SaveAs(Server.MapPath("~/images/products/") + filename);
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
                else  // the chosen file has an extension that is not allowed
                {                   
                    lblResult.Text = "Deze extensie wordt niet geaccepteerd, alleen bestanden met .jpg, .gif en .png mogen gebruikt worden.";
                }
            }
            catch (Exception)
            {                
                lblResult.Text = "Upload foto mislukt!";
            }
        }

        /// <summary>
        /// If button save is clicked, try to save the new product
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                int cat_id = Convert.ToInt32(ddlCategory.SelectedValue);
                decimal price = Convert.ToDecimal(txtPrice.Text);
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

        /// <summary>
        /// If button back is clicked, redirect to products_overview.aspx
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/pages/admin/products_overview.aspx");
        }
    }
}