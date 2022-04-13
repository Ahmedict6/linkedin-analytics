using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using BLL;
using System.Data;


namespace PDFS_For_letsgettoit2019
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Abandon();
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new BLL.clsUser().Login(txtEmail.Text, txtPassword.Text);
                if (dt.Rows.Count == 1)
                {
                    Session["UserId"] = dt.Rows[0]["UserId"];
                    Session["UserTypeNo"] = dt.Rows[0]["UserTypeNo"];
                    Session["UserName"] = dt.Rows[0]["Full_Name"];
                    new BLL.clsUser().AddLoginLog(txtEmail.Text, true);
                    Response.Redirect("~/Dashboard.aspx");
                   
                }
                else
                {
                    new BLL.clsUser().AddLoginLog(txtEmail.Text, false);
                    lblFeedback.Text = Feedback.IncorrectUsernameOrPassword();
                    lblFeedback.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {

                lblFeedback.Text = Feedback.LoginFailed();
                lblFeedback.ForeColor = Color.Red;
            }
        }
    }
}