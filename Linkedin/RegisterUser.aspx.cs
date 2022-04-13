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
    public partial class RegisterUser : System.Web.UI.Page
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
                byte[] bResultImage= new Byte[0] ;
                bool IsMale = rdMale.Checked;
                if (btnSave.Text == "Save")
                {
                    if (fuPhoto.HasFile)
                    {
                        FileInfo file = new FileInfo(fuPhoto.FileName);
                        if (file.Extension.ToLower() == ".jpg" || file.Extension.ToLower() == ".gif" || file.Extension.ToLower() == ".bmp" || file.Extension.ToLower() == ".png")
                        {

                            System.IO.MemoryStream myMemStream = new System.IO.MemoryStream(fuPhoto.FileBytes);
                            System.Drawing.Image fullsizeImage = System.Drawing.Image.FromStream(myMemStream);
                            System.IO.MemoryStream myResult = new System.IO.MemoryStream();

                            var qualityParam = new EncoderParameter(Encoder.Quality, 100L);
                            var jpegCodec = ImageCodecInfo.GetImageEncoders().FirstOrDefault(t => t.MimeType == "image/jpeg");
                            var encoderParams = new EncoderParameters(1);
                            encoderParams.Param[0] = qualityParam;

                            fullsizeImage.Save(myResult, jpegCodec, encoderParams);
                            bResultImage = myResult.ToArray();

                            myMemStream.Close();
                            myResult.Close();
                            fullsizeImage.Dispose();
                        }
                    }


                    HttpPostedFile Photo = fuPhoto.PostedFile;
                    if (Photo.ContentLength > (500 * 1024))
                    {
                        lblFeedback.Text = Feedback.PhotoSizeExceedingAllowedSize();
                        lblFeedback.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        int CustomerId = new clsUser().InsertUsers(txtFirstName.Text, txtMiddleName.Text, txtLastName.Text, txtEmail.Text, txtPhoneNo.Text,  bResultImage, int.Parse(ddlCustomerType.SelectedValue), txtMartialStatus.Text, txtLocation.Text, IsMale, "null", 1);
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


                }
                else //Update
                {
                    if (fuPhoto.HasFile)
                    {
                        FileInfo file = new FileInfo(fuPhoto.FileName);
                        if (file.Extension.ToLower() == ".jpg" || file.Extension.ToLower() == ".gif" || file.Extension.ToLower() == ".bmp" || file.Extension.ToLower() == ".png")
                        {

                            System.IO.MemoryStream myMemStream = new System.IO.MemoryStream(fuPhoto.FileBytes);
                            System.Drawing.Image fullsizeImage = System.Drawing.Image.FromStream(myMemStream);
                            System.IO.MemoryStream myResult = new System.IO.MemoryStream();

                            var qualityParam = new EncoderParameter(Encoder.Quality, 100L);
                            var jpegCodec = ImageCodecInfo.GetImageEncoders().FirstOrDefault(t => t.MimeType == "image/jpeg");
                            var encoderParams = new EncoderParameters(1);
                            encoderParams.Param[0] = qualityParam;

                            fullsizeImage.Save(myResult, jpegCodec, encoderParams);
                            bResultImage = myResult.ToArray();

                            myMemStream.Close();
                            myResult.Close();
                            fullsizeImage.Dispose();



                            HttpPostedFile Photo = fuPhoto.PostedFile;
                            if (Photo.ContentLength > (500 * 1024))
                            {
                                lblFeedback.Text = Feedback.PhotoSizeExceedingAllowedSize();
                                lblFeedback.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                bool update = new clsUser().UpdateUsers(txtFirstName.Text, txtMiddleName.Text, txtLastName.Text, txtEmail.Text, txtPhoneNo.Text, bResultImage, int.Parse(ddlCustomerType.SelectedValue), txtMartialStatus.Text, txtLocation.Text, IsMale, "Null", int.Parse(gvUser.SelectedDataKey.Values[0].ToString()), 1);
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
                    }
                    else //Update without Photo
                    {
                        bool Update = new clsUser().UpdateUsersWithoutPhoto(txtFirstName.Text, txtMiddleName.Text, txtLastName.Text, txtEmail.Text, txtPhoneNo.Text, int.Parse(ddlCustomerType.SelectedValue), txtMartialStatus.Text, txtLocation.Text, IsMale, "Null", int.Parse(gvUser.SelectedDataKey.Values[0].ToString()), 1);
                        if (Update)
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
            gvUser.DataSource = new clsUser().GetAllUsers();
            gvUser.DataBind();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                // txtBirthDate.Text = "";
                txtLocation.Text = "";
                txtMartialStatus.Text = "";
                rdFemale.Checked = false;
                rdMale.Checked = true;
                lblFeedback.Text = "";
                txtEmail.Text = "";
                txtMiddleName.Text = "";
                txtLastName.Text = "";
                txtFirstName.Text = "";
                btnSave.Text = "Save";
                txtPhoneNo.Text = "";
                fuPhoto.Dispose();
                ddlCustomerType.SelectedIndex = 0;
                gvUser.SelectedIndex = -1;
                LoadGridView();
                imgPhoto.ImageUrl = string.Format("~/Images/NoImageFound.jpg");
                imgPhoto.Visible = true;
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
                Button btnsender = sender as Button;
                GridViewRow gvr = btnsender.NamingContainer as GridViewRow;
                bool Delete = new clsUser().DeleteUser(int.Parse(gvUser.DataKeys[gvr.RowIndex].Values[0].ToString()), 1);
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

        protected void chkIsActive_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                lblFeedback.Text = "";
                CheckBox chkSender = sender as CheckBox;
                GridViewRow gvr = chkSender.NamingContainer as GridViewRow;
                bool Update = new clsUser().UpdateUserStatus(chkSender.Checked, int.Parse(gvUser.DataKeys[gvr.RowIndex].Values[0].ToString()), 1);
                if (Update)
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
            catch (Exception ex)
            {

                lblFeedback.Text = ex.Message;
                lblFeedback.ForeColor = Color.Red;
            }
        }

        protected void gvUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblFeedback.Text = "";
                DataTable dtCustomers = new clsUser().GetUsersbyId(int.Parse(gvUser.SelectedDataKey.Values[0].ToString()));

                txtFirstName.Text = dtCustomers.Rows[0]["FirstName"].ToString();
                txtLastName.Text = dtCustomers.Rows[0]["LastName"].ToString();
                txtMiddleName.Text = dtCustomers.Rows[0]["MiddleName"].ToString();
                txtPhoneNo.Text = dtCustomers.Rows[0]["PhoneNo"].ToString();
                txtEmail.Text = dtCustomers.Rows[0]["Email"].ToString();
                txtMartialStatus.Text = dtCustomers.Rows[0]["password"].ToString();
                txtLocation.Text = dtCustomers.Rows[0]["Location"].ToString();
                if (bool.Parse(dtCustomers.Rows[0]["IsMale"].ToString()))
                {
                    rdMale.Checked = true;
                    rdFemale.Checked = false;
                }
                else
                {
                    rdMale.Checked = false;
                    rdFemale.Checked = true;
                }
                //DateTime BirthDate= DateTime.Parse(dtCustomers.Rows[0]["BirthDate"].ToString());
                // txtBirthDate.Text = BirthDate.ToString("MM/dd/yyyy");

                //(Convert.ToDateTime(DateTime.ParseExact(BirthDate.ToShortDateString(), "dd/MM/yyyy", CultureInfo.InvariantCulture))).ToString();

                ddlCustomerType.SelectedValue = dtCustomers.Rows[0]["UserTypeNo"].ToString();
                imgPhoto.ImageUrl = string.Format("LoadCustomerImage.aspx?id={0}", int.Parse(gvUser.SelectedDataKey.Values[0].ToString()));
                imgPhoto.Visible = true;
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