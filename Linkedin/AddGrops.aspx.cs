using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing.Imaging;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using BLL;
using System.Data;
using System.Drawing;
using System.Globalization;

namespace PDFS_For_letsgettoit2019
{
    public partial class AddGrops : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserId"] != null)
                {
                    if (Session["UserTypeNo"].ToString() == "1")
                    {
                        LoadGridView();
                    }
                    else
                    {
                        Response.Redirect("~/LoginPage.aspx");
                    }

                }
                else
                {
                    Response.Redirect("~/LoginPage.aspx");
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                lblFeedback.Text = "";

                if (btnSave.Text == "Save")
                {

                    int CustomerId = new InBLL.clsGroups().AddGroups(txtGroupsName.Text, txtGroupsUrl.Text );
                    if (CustomerId > 0)
                    {
                        btnClear_Click(sender, e);
                        lblFeedback.Text = Feedback.InsertSuccessfull();
                        lblFeedback.ForeColor = Color.Green;
                        LoadGridView();

                    }
                    else
                    {
                        lblFeedback.Text = Feedback.InsertException();
                        lblFeedback.ForeColor = Color.Red;
                        return;
                    }



                }
                else //Update
                {

                    bool update =  new InBLL.clsGroups().UpdateGroups(txtGroupsName.Text, txtGroupsUrl.Text , int.Parse(gvGroups.SelectedDataKey.Values[0].ToString()), 1);
                    if (update)
                    {
                        btnClear_Click(sender, e);
                        lblFeedback.Text = Feedback.UpdateSuccessfull();
                        lblFeedback.ForeColor = Color.Green;

                    }
                    else
                    {
                        lblFeedback.Text = Feedback.UpdateException();
                        lblFeedback.ForeColor = Color.Red;
                    }
                }


            }
            catch (Exception ex)
            {
                lblFeedback.ForeColor = Color.Red;
                if (btnSave.Text == "Save")
                {
                    lblFeedback.Text = Feedback.InsertException() + " | " + ex.Message;
                }
                else
                {
                    lblFeedback.Text = Feedback.UpdateException();
                }
            }
        }

        private void LoadGridView()
        {
            gvGroups.DataSource = new InBLL.clsGroups().GetGrops();
            gvGroups.DataBind();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {

                txtGroupsName.Text = "";
                txtGroupsUrl.Text = "";
                btnSave.Text = "Save";

                gvGroups.SelectedIndex = -1;
                LoadGridView();
                
              
            }
            catch (Exception ex)
            {

                lblFeedback.Text = ex.Message;
                lblFeedback.ForeColor = Color.Red;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                lblFeedback.Text = "";
                LinkButton btnsender = sender as LinkButton;
                GridViewRow gvr = btnsender.NamingContainer as GridViewRow;
                bool Delete = new   InBLL.clsGroups().DeleteGroups(int.Parse(gvGroups.DataKeys[gvr.RowIndex].Values[0].ToString()), 1);
                if (Delete)
                {
                    btnClear_Click(sender, e);
                    lblFeedback.Text = Feedback.DeleteSuccessfull();
                    lblFeedback.ForeColor = Color.Green;
                }
                else
                {
                    lblFeedback.ForeColor = Color.Red;
                    lblFeedback.Text = Feedback.DeleteException();
                }

            }
            catch (Exception ex)
            {

                lblFeedback.Text = Feedback.DeleteException();
                lblFeedback.ForeColor = Color.Red;
            }
        }

      
        protected void gvUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblFeedback.Text = "";
                
                DataTable dtGroup =   new InBLL.clsGroups().GetGroupsById(int.Parse(gvGroups.SelectedDataKey.Values[0].ToString()));

                txtGroupsName.Text = dtGroup.Rows[0]["GroupName"].ToString();
                txtGroupsUrl.Text = dtGroup.Rows[0]["GroupUrl"].ToString();
                 
             
                btnSave.Text = "Update";

            }
            catch (Exception ex)
            {

                lblFeedback.Text = ex.Message;
                lblFeedback.ForeColor = Color.Red;
            }
        }
    }
}