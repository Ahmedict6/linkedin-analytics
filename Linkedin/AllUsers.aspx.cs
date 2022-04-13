using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using Newtonsoft.Json;  

namespace CustomerPortal
{
    public partial class AllUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] != null)
                {
                      
                }
                else
                {
                    Response.Redirect("~/LoginPage.aspx");
                }
            }
        }
        void BinddlPdfs()
        {
            try
            {


                       
              
                
 


            }
            catch (Exception)
            {


            }
        }

         [System.Web.Services.WebMethod]
        public static string DataTableToJSONWithJSONNet(int count )
        {

              
            DataTable dtsers = new InBLL.Data().GetAllUsers( count);   
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(dtsers);
            return JSONString;
        }


       


    
    }
}