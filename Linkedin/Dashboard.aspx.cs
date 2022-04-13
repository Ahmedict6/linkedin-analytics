using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace UserPortal
{
    public partial class Dashboard : System.Web.UI.Page
    {
        BLL.PdfData pdfData = new BLL.PdfData();
        InBLL.Data Data = new InBLL.Data();


        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["UserId"] != null)
            //{



            lblAllposts.Text = Data.GetallPostCount().ToString();
            lblTodayPosts.Text = Data.GetTodayPostCount().ToString();
            lblProfiles.Text = Data.GetProfileCount().ToString();
            lblTags.Text = Data.GetTagsCount().ToString();


            gvrData.DataSource = Data.GetTodayPosts();
            gvrData.DataBind();

            DataTable dt = Data.GetGropsPostCounter();
             DataTable dtTir2 = Data.GetUserMotePostingCounter();
                
                //LoadChartData(dt);

          //for (int i = 0; i < dt.Columns.Count - 1; i++)
          //         {

                       Series series = new Series();
                       series.ChartType = SeriesChartType.Bar;
                       foreach (DataRow dr in dt.Rows)
                       {
                           int y = (int)dr["Count"];
                           string replacement = Regex.Replace(dr["GroupName"].ToString(), @"\t|\n|\r", "");
                           replacement = Regex.Replace(replacement, @"  ", " ");
                           series.Points.AddXY(replacement, y);
                         //  series.Points[series.Points.Count - 1].Url = "ShowData.aspx?supplier=" + dr["SupplierQA"].ToString().Replace("&", "_");

                       }
                       series.IsValueShownAsLabel = true;
                       Chart1.Series.Add(series);
                  // }


                   //for (int i = 1; i < dtTir2.Columns.Count - 1; i++)
                   //{

                        series = new Series();
                       series.ChartType = SeriesChartType.Bar;
                       foreach (DataRow dr in dtTir2.Rows)
                       {
                           int y = (int)dr["count"];
                           string replacement = Regex.Replace(dr["UserName"].ToString(), @"\t|\n|\r", "");
                           replacement = Regex.Replace(replacement, @"  ", " ");
                           series.Points.AddXY(replacement, y);
                      //     series.Points[series.Points.Count - 1].Url = "ShowData.aspx?supplier=" + dr["SupplierQA"].ToString().Replace("&","_");
                           //series.Points[series.Points.Count - 1].= "Hello";
                       }
                       series.IsValueShownAsLabel = true;

                       Chart2.Series.Add(series);
                  // }

                   Chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
                   Chart2.ChartAreas["ChartArea1"].AxisX.Interval = 1;


               //}
               //else
               //{
               //    Response.Redirect("~/LoginPage.aspx");
               //}

              

        }

        
     
        private DataTable GetData()
        {

            DataTable dt = new DataTable();

            dt.Columns.Add("Data", Type.GetType("System.String"));

            dt.Columns.Add("All", Type.GetType("System.Int32"));

            dt.Columns.Add("Average", Type.GetType("System.Int32"));

            dt.Columns.Add("AllDuplicationPDF", Type.GetType("System.Int32"));
            dt.Columns.Add("SupplierQA", Type.GetType("System.String"));

            int AllPdfCount = pdfData.GetAllPdfCount();

            DataTable Data = pdfData.GetPdfHCPCSAllSuplier();

            foreach (DataRow drdData in Data.Rows)
            {
                DataRow dr1 = dt.NewRow();

                dr1["Data"] = drdData["Supplier_Name"];
                int All = pdfData.GetPdfHCPCSColumnAllPDFSublierName(drdData["SupplierQA"].ToString());
                dr1["All"] = All;
                dr1["Average"] = pdfData.GetPdfHCPCSColumnaverageByPDFSublierName(drdData["SupplierQA"].ToString());// All / AllPdfCount;
                dr1["AllDuplicationPDF"] = pdfData.GetPdfHCPCSDuplicatedColumnALLPDFSublierName(drdData["SupplierQA"].ToString());// drdData["HCPCS_Count"];

                dr1["SupplierQA"] = drdData["SupplierQA"];
                dt.Rows.Add(dr1);

            }


            return dt;

        }

        /*
        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            Chart1.Series.Clear();
            Chart2.Series.Clear();

            DataTable dt;
            if (ddlCountry.SelectedValue != "" || ddlYear.SelectedValue != "")
            {
                dt = getdatabycountry();
                lblSupliers.Text = pdfData.GetPdfHCPCSAllSuplierCountry(ddlCountry.SelectedValue ,ddlYear.SelectedValue).Rows.Count.ToString();
                lblHCPCS.Text = pdfData.GetAllHCPCSCountCountry(ddlCountry.SelectedValue, ddlYear.SelectedValue).ToString();
                lblAllPdf.Text = pdfData.GetAllPdfCountCountry(ddlCountry.SelectedValue, ddlYear.SelectedValue).ToString();
                lblnewPdf.Text = pdfData.GetAllPdfNewCountCountry(ddlCountry.SelectedValue, ddlYear.SelectedValue).ToString();
            }
            else
            {
                dt = GetData();
                lblSupliers.Text = pdfData.GetPdfHCPCSAllSuplier().Rows.Count.ToString();
                lblHCPCS.Text = pdfData.GetAllHCPCSCount().ToString();
                lblAllPdf.Text = pdfData.GetAllPdfCount().ToString();
                lblnewPdf.Text = pdfData.GetAllPdfNewCount().ToString();
            }

            DataTable dtTir2 = dt.Clone();

            if (dt.Rows.Count > 25)
            {
                dtTir2 = dt.Select().Where(dr => dt.Rows.IndexOf(dr) >= 25).CopyToDataTable();
            }
            if (dt.Rows.Count > 0)
            {
                dt = dt.Select().Where(dr => dt.Rows.IndexOf(dr) < 25).CopyToDataTable();
            }
            
            DivNoData.Visible = (dt.Rows.Count == 0);

            for (int i = 1; i < dt.Columns.Count - 1; i++)
            {

                Series series = new Series();
                series.ChartType = SeriesChartType.Bar;
                foreach (DataRow dr in dt.Rows)
                {
                    int y = (int)dr[i];
                    string replacement = Regex.Replace(dr["Data"].ToString(), @"\t|\n|\r", "");
                    replacement = Regex.Replace(replacement, @"  ", " ");
                    series.Points.AddXY(replacement, y);
                    series.Points[series.Points.Count - 1].Url = "ShowData.aspx?supplier=" + dr["SupplierQA"].ToString().Replace("&", "_");

                }
                series.IsValueShownAsLabel = true;
                Chart1.Series.Add(series);
            }


            for (int i = 1; i < dtTir2.Columns.Count - 1; i++)
            {

                Series series = new Series();
                series.ChartType = SeriesChartType.Bar;
                foreach (DataRow dr in dtTir2.Rows)
                {
                    int y = (int)dr[i];
                    string replacement = Regex.Replace(dr["Data"].ToString(), @"\t|\n|\r", "");
                    replacement = Regex.Replace(replacement, @"  ", " ");
                    series.Points.AddXY(replacement, y);
                    series.Points[series.Points.Count - 1].Url = "ShowData.aspx?supplier=" + dr["SupplierQA"].ToString().Replace("&", "_");
                 }
                series.IsValueShownAsLabel = true;

                Chart2.Series.Add(series);
            }

            Chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            Chart2.ChartAreas["ChartArea1"].AxisX.Interval = 1;


        }


        private DataTable getdatabycountry()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Data", Type.GetType("System.String"));

            dt.Columns.Add("All", Type.GetType("System.Int32"));

            dt.Columns.Add("Average", Type.GetType("System.Int32"));

            dt.Columns.Add("AllDuplicationPDF", Type.GetType("System.Int32"));
            dt.Columns.Add("SupplierQA", Type.GetType("System.String"));

            int AllPdfCount = pdfData.GetAllPdfCountbyCountry(ddlCountry.SelectedValue, ddlYear.SelectedValue);

            DataTable Data = pdfData.GetPdfHCPCSAllSuplierCountry(ddlCountry.SelectedValue, ddlYear.SelectedValue);

            foreach (DataRow drdData in Data.Rows)
            {
                DataRow dr1 = dt.NewRow();

                dr1["Data"] = drdData["Supplier_Name"];
                int All = pdfData.GetPdfHCPCSColumnAllPDFSublierNameandCountry(drdData["SupplierQA"].ToString(), ddlCountry.SelectedValue, ddlYear.SelectedValue);
                dr1["All"] = All;
                dr1["Average"] = pdfData.GetPdfHCPCSColumnaverageByPDFSublierName(drdData["SupplierQA"].ToString());  
                dr1["AllDuplicationPDF"] = pdfData.GetPdfHCPCSDuplicatedColumnALLPDFSublierNamebyCountry(drdData["SupplierQA"].ToString(), ddlCountry.SelectedValue, ddlYear.SelectedValue);// drdData["HCPCS_Count"];

                dr1["SupplierQA"] = drdData["SupplierQA"];
                dt.Rows.Add(dr1);

            }


            return dt;
        }
        */
    }

}

