using InBLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UmmAlQuwainIFrom.BLL;

namespace Linked_In_Program
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DataTable Groups = new Data().GetGrops();
            DataRow dr = Groups.NewRow();
            dr[0] = 0;
            dr[1] = "All";
            Groups.Rows.InsertAt(dr, 0);
            groupsBindingSource.DataSource = Groups;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {


            if (txtEmail.Text == "" || txtPassword.Text == "")
            {
                System.Windows.Forms.MessageBox.Show("please add both your email and password", "Info");

            }

            String group = (ddlGroups.SelectedItem as DataRowView).Row[0].ToString();
            if (rdpBoth.Checked)
            {
                new System.Threading.Thread(() =>
                {
                    new UmmAlQuwainIFrom.BLL.Controling(txtEmail.Text, txtPassword.Text).GetGropsUsers(group, chkSilentMode.Checked, true);
                }
                ).Start();

                new System.Threading.Thread(() =>
                {
                    new UmmAlQuwainIFrom.BLL.Controling(txtEmail.Text, txtPassword.Text).GetGropsPosts(group, chkSilentMode.Checked, true);
                    new Data().PostClassification();
                }
               ).Start();



            }
            else if (rdPost.Checked)
            {

                new System.Threading.Thread(() =>
                {
                    new UmmAlQuwainIFrom.BLL.Controling(txtEmail.Text, txtPassword.Text).GetGropsPosts(group, chkSilentMode.Checked, true);
                    new Data().PostClassification();
                }
              ).Start();

            }
            else if (rdUser.Checked)
            {

                new System.Threading.Thread(() =>
                {
                    new UmmAlQuwainIFrom.BLL.Controling(txtEmail.Text, txtPassword.Text).GetGropsUsers(group, chkSilentMode.Checked,true);
                }
             ).Start();

            }

            if (radioButton1.Checked)
            {
                new System.Threading.Thread(() =>
                             {
                                 new UmmAlQuwainIFrom.BLL.Controling(txtEmail.Text, txtPassword.Text).AutoMode(chkSilentMode.Checked);
                                 
                             }
                          ).Start();
            }

        }

        private void btnReclassification_Click(object sender, EventArgs e)
        {
            String Text = btnReclassification.Text;
            btnReclassification.Text = "Working ..";
            btnReclassification.Enabled = false;
            new Data().PostClassification();
            btnReclassification.Text = Text;
            btnReclassification.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
               
               txtEmail.Text = "jcperez2019@hushmail.com";  
               txtPassword.Text  = "Nelsonmaria1"; 
        }
    }
}
