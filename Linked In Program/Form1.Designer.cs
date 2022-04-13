namespace Linked_In_Program
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnStart = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ddlGroups = new System.Windows.Forms.ComboBox();
            this.groupsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnReclassification = new System.Windows.Forms.Button();
            this.rdUser = new System.Windows.Forms.RadioButton();
            this.rdPost = new System.Windows.Forms.RadioButton();
            this.rdpBoth = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chkSilentMode = new System.Windows.Forms.CheckBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(98, 248);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(329, 33);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(98, 121);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(329, 20);
            this.txtEmail.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(98, 147);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(329, 20);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Email : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Scrape Type : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Groups : ";
            // 
            // ddlGroups
            // 
            this.ddlGroups.DataSource = this.groupsBindingSource;
            this.ddlGroups.DisplayMember = "GroupName";
            this.ddlGroups.FormattingEnabled = true;
            this.ddlGroups.Location = new System.Drawing.Point(98, 172);
            this.ddlGroups.Name = "ddlGroups";
            this.ddlGroups.Size = new System.Drawing.Size(329, 21);
            this.ddlGroups.TabIndex = 7;
            this.ddlGroups.ValueMember = "GroupName";
            // 
            // groupsBindingSource
            // 
            this.groupsBindingSource.DataSource = typeof(Linked_In_Program.Groups);
            // 
            // btnReclassification
            // 
            this.btnReclassification.Location = new System.Drawing.Point(98, 287);
            this.btnReclassification.Name = "btnReclassification";
            this.btnReclassification.Size = new System.Drawing.Size(329, 33);
            this.btnReclassification.TabIndex = 0;
            this.btnReclassification.Text = "Posts Reclassification";
            this.btnReclassification.UseVisualStyleBackColor = true;
            this.btnReclassification.Click += new System.EventHandler(this.btnReclassification_Click);
            // 
            // rdUser
            // 
            this.rdUser.AutoSize = true;
            this.rdUser.Location = new System.Drawing.Point(98, 198);
            this.rdUser.Name = "rdUser";
            this.rdUser.Size = new System.Drawing.Size(54, 17);
            this.rdUser.TabIndex = 8;
            this.rdUser.TabStop = true;
            this.rdUser.Tag = "G";
            this.rdUser.Text = "User\'s";
            this.rdUser.UseVisualStyleBackColor = true;
            // 
            // rdPost
            // 
            this.rdPost.AutoSize = true;
            this.rdPost.Location = new System.Drawing.Point(190, 198);
            this.rdPost.Name = "rdPost";
            this.rdPost.Size = new System.Drawing.Size(51, 17);
            this.rdPost.TabIndex = 8;
            this.rdPost.TabStop = true;
            this.rdPost.Tag = "G";
            this.rdPost.Text = "Posts";
            this.rdPost.UseVisualStyleBackColor = true;
            // 
            // rdpBoth
            // 
            this.rdpBoth.AutoSize = true;
            this.rdpBoth.Location = new System.Drawing.Point(273, 198);
            this.rdpBoth.Name = "rdpBoth";
            this.rdpBoth.Size = new System.Drawing.Size(47, 17);
            this.rdpBoth.TabIndex = 8;
            this.rdpBoth.TabStop = true;
            this.rdpBoth.Tag = "G";
            this.rdpBoth.Text = "Both";
            this.rdpBoth.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Linked_In_Program.Properties.Resources.iconfinder_LinkedIn_UI_03_2335596__1_;
            this.pictureBox1.Location = new System.Drawing.Point(190, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(117, 116);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // chkSilentMode
            // 
            this.chkSilentMode.AutoSize = true;
            this.chkSilentMode.Location = new System.Drawing.Point(98, 225);
            this.chkSilentMode.Name = "chkSilentMode";
            this.chkSilentMode.Size = new System.Drawing.Size(158, 17);
            this.chkSilentMode.TabIndex = 10;
            this.chkSilentMode.Text = "Silent Mode (  No  Browser )";
            this.chkSilentMode.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(352, 198);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(75, 17);
            this.radioButton1.TabIndex = 8;
            this.radioButton1.TabStop = true;
            this.radioButton1.Tag = "G";
            this.radioButton1.Text = "Daly mode";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 331);
            this.Controls.Add(this.chkSilentMode);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.rdpBoth);
            this.Controls.Add(this.rdPost);
            this.Controls.Add(this.rdUser);
            this.Controls.Add(this.ddlGroups);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.btnReclassification);
            this.Controls.Add(this.btnStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "                                                                            ";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ddlGroups;
        private System.Windows.Forms.Button btnReclassification;
        private System.Windows.Forms.RadioButton rdUser;
        private System.Windows.Forms.RadioButton rdPost;
        private System.Windows.Forms.RadioButton rdpBoth;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.BindingSource groupsBindingSource;
        private System.Windows.Forms.CheckBox chkSilentMode;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}

