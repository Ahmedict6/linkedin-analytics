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
    public partial class AllPosts : System.Web.UI.Page
    {
        InBLL.Data Data = new InBLL.Data();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] != null)
                {
                    //                    ddlGroups.DataBind();
                BinddlPdfs();
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
          

                dlGroupsPsot.DataSource = Data.GetGrops();
                dlGroupsPsot.DataBind();
            }
            catch (Exception)
            {


            }
        }

     


        protected void dlPdfs_PreRender(object sender, EventArgs e)
        {
            try
            {
                foreach (DataListItem item in dlGroupsPsot.Items)
                {
                    GridView gv = item.FindControl("gvrData") as GridView;
                    int GroupId = int.Parse(dlGroupsPsot.DataKeys[item.ItemIndex].ToString());
                   // int GroupId = int.Parse(ddlGroups.SelectedValue);
                    gv.DataSource = Data.getpsotsbyGropNo(GroupId);
                    gv.DataBind();
                }

            }
            catch (Exception)
            {


            }
        }

    }
}