using System;
using System.Collections;
using System.Text;

namespace Milanov.pages
{
    public partial class Shop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillPage();
        }

        private void FillPage()
        {
            ArrayList productList = new ArrayList();

            if (!IsPostBack)
            {
                productList = ConnectionClass.GetProductByCategory(1);
            }
            else
            {
                productList = ConnectionClass.GetProductByCategory(Convert.ToInt32(DropDownList1.SelectedValue));
            }

            StringBuilder sb = new StringBuilder();

            foreach (Product product in productList)
            {
                sb.Append(
                    string.Format(
                        @"<table class='productTable'>
                <tr>
                    <th rowspan='6' width='150px'><a rel='fancybox' href='/images/product/{3}' title='{0}'><img runat='server' src='/images/product/{3}' height='100px' width='100px'/></th>
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
                       product.Name, product.Cat_id, product.Price, product.Image, product.Description));

                lblOutput.Text = sb.ToString();
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillPage();
        }
    }
}