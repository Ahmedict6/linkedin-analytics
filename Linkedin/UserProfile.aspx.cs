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
    public partial class UserProfile : System.Web.UI.Page
    {
        InBLL.Data Data = new InBLL.Data();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] != null)
                {

                    if (Request.QueryString["userNo"] != null)
                        BinddlPdfs( int.Parse( Request.QueryString["userNo"].ToString()));
                }
                else
                {
                    Response.Redirect("~/LoginPage.aspx");
                }
            }
        }
        void BinddlPdfs(int profileId)
        {
            try
            {

                fvUser.DataSource = Data.GetUserByProfileId(profileId);
                fvUser.DataBind();
                pdfFream.Attributes.Add("src" , "./ShowPdf.aspx?userNo=" + profileId);
               
            }
            catch (Exception)
            {


            }
        }

     


    
    }
}