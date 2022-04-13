using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Text.RegularExpressions;

namespace CustomerPortal
{
    public partial class TagReport : System.Web.UI.Page
    {

        InBLL.clsTags Tags = new InBLL.clsTags();
        string Suplier = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] != null)
                {
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
            dlPdfs.DataSource = Tags.GetTagsForReport();
            dlPdfs.DataBind();
            DivNoData.Visible = (dlPdfs.Items.Count == 0);
        }


        protected void dlPdfs_PreRender(object sender, EventArgs e)
        {
            try
            {
                foreach (DataListItem item in dlPdfs.Items)
                {
                    int pdfid = int.Parse(dlPdfs.DataKeys[item.ItemIndex].ToString());

                    Chart chart = item.FindControl("Chart1") as Chart;
                    DataTable dt = Tags.GetTagsForReport(pdfid);
                    Series series = new Series();
                    series.ChartType = SeriesChartType.Bar;

                    foreach (DataRow dr in dt.Rows)
                    {
                        int y = (int)dr["countOfPosts"];
                        string replacement = Regex.Replace(dr["GroupName"].ToString(), @"\t|\n|\r", "");
                        replacement = Regex.Replace(replacement, @"  ", " ");
                        series.Points.AddXY(replacement, y);
                    }

                    series.IsValueShownAsLabel = true;
                    chart.Series.Add(series);
                    chart.ChartAreas["ChartArea1"].AxisX.LabelStyle.Angle = 90;
                }

            }
            catch (Exception)
            {


            }
        }





    }
}