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
            this.Title = "Error - Milanov";

            if (!Page.IsPostBack)
            {
                string aspxerrorpath = Request.QueryString["aspxerrorpath"];
                if (!String.IsNullOrEmpty(aspxerrorpath)) // Error occured and page of error is known
                {
                    // Show error message
                    lblError.Text = String.Format(@"Er is iets foutgegaan, dit kan één of meerdere oorzaken hebben:<br />
                                    <ul>
                                        <li>De pagina die u probeerde te bezoeken bestaat niet of is niet in gebruik.</li>
                                        <li>Wat u deed mag en/of kan niet.</li>
                                    </ul>
                                    Het ging fout op pagina: <b>{0}</b>.<br />
                                    Klik <a href='javascript:history.back()'>hier</a> om terug te gaan naar deze pagina.", aspxerrorpath);
                    lblError.Visible = true;
                }

                else // Error occured and page of error is NOT known
                {
                    // Show error message                    
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
}