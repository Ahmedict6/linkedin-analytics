using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BLL;


namespace Eco_Pay
{
    public partial class LoadCustomerImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Byte[] bytes = null;
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != "0")
                {
                        
                            bytes = new clsUser().LoadUserPhoto(Int32.Parse(Request.QueryString["id"].ToString()));
                }
                else
                {
                    bytes = System.IO.File.ReadAllBytes(Server.MapPath("Images/NoImageFound.jpg"));
                   
                }
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = @"image/gif";
                Response.BinaryWrite(bytes);
                Response.Flush();
            }
            catch (Exception)
            {
                Byte[] bytes = null;
                bytes = System.IO.File.ReadAllBytes(Server.MapPath("Images/NoImageFound.jpg"));
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = @"image/gif";
                Response.BinaryWrite(bytes);
                Response.Flush();
            }
        }


    }
}
