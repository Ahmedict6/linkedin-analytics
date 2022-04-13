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
    public partial class GroupReport : System.Web.UI.Page
    {
        InBLL.Data Data = new InBLL.Data();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] != null)
                {
                    ddlGroups.DataBind();
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

            
                int GroupId = int.Parse(ddlGroups.SelectedValue);

                dlUsersPostingReport.DataSource = Data.GetMostPostingUsers(GroupId);
                dlUsersPostingReport.DataBind();

                dlGroupsPsotTags.DataSource = Data.GetGropTags(GroupId);
                dlGroupsPsotTags.DataBind();
            }
            catch (Exception)
            {


            }
        }

        protected void lblGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            int GroupId = int.Parse(ddlGroups.SelectedValue);
            dlUsersPostingReport.DataSource = Data.GetMostPostingUsers(GroupId);
            dlUsersPostingReport.DataBind();

            dlGroupsPsotTags.DataSource = Data.GetGropTags(GroupId);
            dlGroupsPsotTags.DataBind();
        }


        protected void dlPdfs_PreRender(object sender, EventArgs e)
        {
            try
            {
                foreach (DataListItem item in dlGroupsPsotTags.Items)
                {
                    GridView gv = item.FindControl("gvrData") as GridView;
                    int TagId = int.Parse(dlGroupsPsotTags.DataKeys[item.ItemIndex].ToString());
                    int GroupId = int.Parse(ddlGroups.SelectedValue);
                    gv.DataSource = Data.getpsotsbyGropNoAndTagNo(GroupId,TagId);
                    gv.DataBind();
                }

            }
            catch (Exception)
            {


            }
        }

    }
}