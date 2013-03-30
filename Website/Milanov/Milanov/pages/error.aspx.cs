using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Milanov.pages
{
    public partial class error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "Error - Milanov";     // Change the current title

            if (!Page.IsPostBack)   // Show error message   
            {                                 
                lblError.Text = String.Format(@"Er is iets foutgegaan, dit kan één of meerdere oorzaken hebben:<br />
                                <ul>
                                    <li>De pagina die u probeerde te bezoeken bestaat niet of is niet in gebruik.</li>
                                    <li>Wat u deed mag en/of kan niet.</li>
                                </ul>
                                Klik <a href='javascript:history.back()'>hier</a> om terug te gaan naar de vorige pagina.");
                lblError.Visible = true;
            }
        }
    }
}