using InBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PDFS_For_letsgettoit2019
{
    public partial class ShowPdf : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["userNo"] != null)
            {


                byte[] byteArray = new Data().GetUserProfilePDFByProfileId(int.Parse(Request.QueryString["userNo"].ToString()));
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/pdf";
                Response.BinaryWrite(byteArray);
                Response.End();
            }
        }
    }
}