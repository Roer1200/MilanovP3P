using System;
using System.Collections;
using System.Text;

namespace Milanov.pages
{
    public partial class Shop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*FillPage();*/
        }

        /*private void FillPage()
        {
            ArrayList pictureList = new ArrayList();

            if (!IsPostBack)
            {
                pictureList = ConnectionClass.GetPictureByCategory("%");
            }
            else
            {
                pictureList = ConnectionClass.GetPictureByCategory(DropDownList1.SelectedValue);
            }

            StringBuilder sb = new StringBuilder();

            foreach (Picture picture in pictureList)
            {
                sb.Append(
                    string.Format(
                        @"<table class='pictureTable'>
                <tr>
                    <th rowspan='6' width='150px'><a rel='fancybox' href='{3}' title='{0}'><img runat='server' src='{3}' height='100px' width='100px'/></th>
                    <th width='50px'>Name: </th>
                    <td>{0}</td>
                </tr> 

                <tr>
                    <th>Category: </th>
                    <td>{1}</td>
                </tr>

                <tr>
                    <th>Price: </th>
                    <td>€ {2}</td>
                </tr>

                <tr>
                    <td colspan='2'>{4}</td>
                </tr>           
            
               </table>",
                       picture.Name, picture.Category, picture.Price, picture.Image, picture.Description));

                lblOutput.Text = sb.ToString();
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillPage();
        }*/
    }
}