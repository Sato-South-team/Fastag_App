namespace Fatag_App
{
    partial class frmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.panel1 = new System.Windows.Forms.Panel();
            this.picChangePassword = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblGroupMaster = new System.Windows.Forms.Label();
            this.lblUserMaster = new System.Windows.Forms.Label();
            this.picGroupMaster = new System.Windows.Forms.PictureBox();
            this.picUserMaster = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblLabelPrinting = new System.Windows.Forms.Label();
            this.picLabelPrinting = new System.Windows.Forms.PictureBox();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.picLogOut = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picChangePassword)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGroupMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUserMaster)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLabelPrinting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogOut)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.picChangePassword);
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Controls.Add(this.lblWelcome);
            this.panel1.Controls.Add(this.picLogOut);
            this.panel1.Location = new System.Drawing.Point(8, 56);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(923, 435);
            this.panel1.TabIndex = 8;
            // 
            // picChangePassword
            // 
            this.picChangePassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picChangePassword.Image = global::Fatag_App.Properties.Resources.iconfinder_change_password_63985;
            this.picChangePassword.Location = new System.Drawing.Point(879, 42);
            this.picChangePassword.Name = "picChangePassword";
            this.picChangePassword.Size = new System.Drawing.Size(39, 36);
            this.picChangePassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picChangePassword.TabIndex = 18;
            this.picChangePassword.TabStop = false;
            this.picChangePassword.Click += new System.EventHandler(this.picChangePassword_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(889, 415);
            this.tabControl1.TabIndex = 140;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblGroupMaster);
            this.tabPage1.Controls.Add(this.lblUserMaster);
            this.tabPage1.Controls.Add(this.picGroupMaster);
            this.tabPage1.Controls.Add(this.picUserMaster);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(881, 383);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Master";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblGroupMaster
            // 
            this.lblGroupMaster.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblGroupMaster.AutoSize = true;
            this.lblGroupMaster.Location = new System.Drawing.Point(60, 100);
            this.lblGroupMaster.Name = "lblGroupMaster";
            this.lblGroupMaster.Size = new System.Drawing.Size(98, 19);
            this.lblGroupMaster.TabIndex = 3;
            this.lblGroupMaster.Text = "Group Master";
            // 
            // lblUserMaster
            // 
            this.lblUserMaster.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblUserMaster.AutoSize = true;
            this.lblUserMaster.Location = new System.Drawing.Point(208, 100);
            this.lblUserMaster.Name = "lblUserMaster";
            this.lblUserMaster.Size = new System.Drawing.Size(89, 19);
            this.lblUserMaster.TabIndex = 1;
            this.lblUserMaster.Text = "User Master";
            // 
            // picGroupMaster
            // 
            this.picGroupMaster.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picGroupMaster.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picGroupMaster.Image = ((System.Drawing.Image)(resources.GetObject("picGroupMaster.Image")));
            this.picGroupMaster.Location = new System.Drawing.Point(55, 24);
            this.picGroupMaster.Name = "picGroupMaster";
            this.picGroupMaster.Size = new System.Drawing.Size(100, 73);
            this.picGroupMaster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picGroupMaster.TabIndex = 2;
            this.picGroupMaster.TabStop = false;
            this.picGroupMaster.Tag = "101";
            this.picGroupMaster.Click += new System.EventHandler(this.picGroupMaster_Click);
            // 
            // picUserMaster
            // 
            this.picUserMaster.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picUserMaster.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picUserMaster.Image = ((System.Drawing.Image)(resources.GetObject("picUserMaster.Image")));
            this.picUserMaster.Location = new System.Drawing.Point(203, 24);
            this.picUserMaster.Name = "picUserMaster";
            this.picUserMaster.Size = new System.Drawing.Size(100, 73);
            this.picUserMaster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picUserMaster.TabIndex = 0;
            this.picUserMaster.TabStop = false;
            this.picUserMaster.Tag = "102";
            this.picUserMaster.Click += new System.EventHandler(this.picUserMaster_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblLabelPrinting);
            this.tabPage2.Controls.Add(this.picLabelPrinting);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(881, 383);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Process";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblLabelPrinting
            // 
            this.lblLabelPrinting.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblLabelPrinting.AutoSize = true;
            this.lblLabelPrinting.Location = new System.Drawing.Point(32, 90);
            this.lblLabelPrinting.Name = "lblLabelPrinting";
            this.lblLabelPrinting.Size = new System.Drawing.Size(98, 19);
            this.lblLabelPrinting.TabIndex = 13;
            this.lblLabelPrinting.Text = "Label Printing";
            // 
            // picLabelPrinting
            // 
            this.picLabelPrinting.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picLabelPrinting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picLabelPrinting.Image = global::Fatag_App.Properties.Resources.iconfinder_document_print_118913;
            this.picLabelPrinting.Location = new System.Drawing.Point(30, 14);
            this.picLabelPrinting.Name = "picLabelPrinting";
            this.picLabelPrinting.Size = new System.Drawing.Size(100, 73);
            this.picLabelPrinting.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLabelPrinting.TabIndex = 12;
            this.picLabelPrinting.TabStop = false;
            this.picLabelPrinting.Tag = "201";
            this.picLabelPrinting.Click += new System.EventHandler(this.picLabelPrinting_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblWelcome.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.Purple;
            this.lblWelcome.Location = new System.Drawing.Point(0, 415);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(889, 18);
            this.lblWelcome.TabIndex = 139;
            this.lblWelcome.Text = "test";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // picLogOut
            // 
            this.picLogOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picLogOut.Dock = System.Windows.Forms.DockStyle.Right;
            this.picLogOut.Image = ((System.Drawing.Image)(resources.GetObject("picLogOut.Image")));
            this.picLogOut.Location = new System.Drawing.Point(889, 0);
            this.picLogOut.Name = "picLogOut";
            this.picLogOut.Size = new System.Drawing.Size(32, 433);
            this.picLogOut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picLogOut.TabIndex = 16;
            this.picLogOut.TabStop = false;
            this.picLogOut.Click += new System.EventHandler(this.picLogOut_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Georgia", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(923, 48);
            this.label1.TabIndex = 140;
            this.label1.Text = "Label Printing";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.pictureBox11);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(8, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(923, 48);
            this.panel2.TabIndex = 9;
            // 
            // pictureBox11
            // 
            this.pictureBox11.Image = global::Fatag_App.Properties.Resources.Transparent_Barckground_Logo;
            this.pictureBox11.Location = new System.Drawing.Point(3, -3);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(195, 51);
            this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox11.TabIndex = 16;
            this.pictureBox11.TabStop = false;
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(166)))));
            this.ClientSize = new System.Drawing.Size(939, 496);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Calibri", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Menu - App Version : 1.0.0.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmModelMaster_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picChangePassword)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGroupMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUserMaster)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLabelPrinting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogOut)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblGroupMaster;
        private System.Windows.Forms.PictureBox picGroupMaster;
        private System.Windows.Forms.Label lblUserMaster;
        private System.Windows.Forms.PictureBox picUserMaster;
        private System.Windows.Forms.PictureBox picLogOut;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.PictureBox picChangePassword;
        private System.Windows.Forms.Label lblLabelPrinting;
        private System.Windows.Forms.PictureBox picLabelPrinting;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
    }
}