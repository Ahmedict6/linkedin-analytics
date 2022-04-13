using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;

namespace CustomerPortal
{
    public partial class MostPostingReoprt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (Session["UserId"] != null)
                //{
                    BinddlPdfs();
                //}
                //else
                //{
                //    Response.Redirect("~/LoginPage.aspx");
                //}
            }
        }
        void BinddlPdfs()
        {
            try
            {


                dlUsersPostingReport.DataSource = new InBLL.Data().GetMostPostingUsers();
                dlUsersPostingReport.DataBind();
             
                
 


            }
            catch (Exception)
            {


            }
        }

     
 
    
    }
}