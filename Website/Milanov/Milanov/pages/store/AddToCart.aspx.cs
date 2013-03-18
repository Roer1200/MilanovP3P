using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Milanov
{
    public partial class AddToCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string rawId = Request.QueryString["productId"];
            int productId;
            if (!String.IsNullOrEmpty(rawId) && int.TryParse(rawId, out productId))
            {
                ShoppingCartActions usersShoppingCart = new ShoppingCartActions();
                usersShoppingCart.AddToCart(Convert.ToInt16(rawId));
                
            }
            else
            {
                Server.Transfer("~/not-found.aspx");
            }
            Response.Redirect("ShoppingCart.aspx");
        }
    }
}