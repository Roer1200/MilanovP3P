using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Milanov.pages.users
{
    public partial class account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] != null)
            {
                this.Title = Session["login"] + " - Milanov";
                lblCU.Text = "Welcome <b>" + Session["login"] + "</b>!";

                if ((string)Session["role"] != "1")
                {
                    btnCMS.Visible = false;
                }
                else
                {
                    btnCMS.Visible = true;
                }
            }
            else
            {
                Response.Redirect("/pages/users/login.aspx");              
            }
        }

        #region ShowUserInfo
        protected void btnInfo_Click(object sender, EventArgs e)
        {
            if (tblInfo.Visible != true)
            {
                string email = ConnectionClass.GetEmail(Session["login"].ToString());
                string role = ConnectionClass.GetRole(Session["login"].ToString());

                lblUsername.Text = "" + Session["login"];
                lblEmail.Text = email;
                lblRole.Text = role;
                tblInfo.Visible = true;
            }
            else
            {
                tblInfo.Visible = false;
            }
        }
        #endregion

        #region ChangePassword
        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (tblPassword.Visible != true)
            {
                lblPoutput.Text = "";
                tblEmail.Visible = false;
                tblPassword.Visible = true;
            }
            else
            {
                tblPassword.Visible = false;
            }
        }

        protected void btnPsubmit_Click(object sender, EventArgs e)
        {
            lblPoutput.Text = ConnectionClass.ChangePassword(Session["Login"].ToString(), txtPcurrent.Text, txtPnew.Text);
        }
        #endregion

        #region ChangeEmail
        private void ClearEmailTextFields()
        {
            txtEcurrent.Text = "";
            txtEnew.Text = "";
            txtEconfirm.Text = "";
        }

        protected void btnChangeEmail_Click(object sender, EventArgs e)
        {
            if (tblEmail.Visible != true)
            {
                lblEoutput.Text = "";
                tblPassword.Visible = false;
                tblEmail.Visible = true;
            }
            else
            {
                tblEmail.Visible = false;
            }
        }

        protected void btnEsubmit_Click(object sender, EventArgs e)
        {
            lblEoutput.Text = ConnectionClass.ChangeEmail(Session["Login"].ToString(), txtEcurrent.Text, txtEnew.Text);

            if (lblEoutput.Text == "Uw mail adres is aangepast!")
            {
                if (tblInfo.Visible == true)
                {
                    tblInfo.Visible = false;
                }
                ClearEmailTextFields();
            }
        }
        #endregion

        protected void btnCMS_Click(object sender, EventArgs e)
        {
            Response.Redirect("/pages/admin/administrator.aspx");
        }
    }
}