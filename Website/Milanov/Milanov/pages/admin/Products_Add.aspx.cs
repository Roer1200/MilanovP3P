﻿using System;
using System.Collections;
using System.IO;

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
                FileUpload1.SaveAs(Server.MapPath("~/images/products/") + filename);
                lblResult.Text = "Foto " + filename + " succesvol geupload!";
                Page_Load(sender, e);
                ddlImage.SelectedValue = "" + filename;
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