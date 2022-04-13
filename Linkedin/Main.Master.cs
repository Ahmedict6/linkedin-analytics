using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PDFS_For_letsgettoit2019
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] != null)
                {
                    User.Visible = (Session["UserTypeNo"].ToString() == "1") ?     true : false;
                    loginLog.Visible = (Session["UserTypeNo"].ToString() == "1") ? true : false;
                    lblUserName.Text = Session["UserName"].ToString();                  

                }
            }
        }
    }
}