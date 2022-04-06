using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Diagnostics;

namespace Fatag_App
{
    public partial class frmLogin : Form
    {
        #region Variables

        Dal oDal;
        User oUser;

        #endregion

        #region Form Methods

        public frmLogin()
        {
            try
            {
                InitializeComponent();
                oUser = new User();
                oDal = new Dal();
            }
            catch (Exception ex)
            {
                ClsGlobal.SetErrorMessage(ex.Message, lblMessage);
            }
        }

        private void frmModelMaster_Load(object sender, EventArgs e)
        {
            try
            {
                ClsGlobal.ClearMessage(lblMessage);
                lblVersion.Text = "App Version : " + Application.ProductVersion;
                txtUserId.Focus();
            }
            catch (Exception ex)
            {
                ClsGlobal.SetErrorMessage(ex.Message, lblMessage);
            }
        }

        private void OFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            txtUserId.Text = "";
            txtPassword.Text = "";
            txtUserId.Focus();
            this.Show();
        }

        #endregion

        #region Button Event

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                ClsGlobal.ClearMessage(lblMessage);
                //if (string.IsNullOrEmpty(txtUserId.Text))
                //{
                //    ClsGlobal.SetInfoMessage("Enter User Id", lblMessage);
                //    txtUserId.Focus();
                //    return;
                //}
                //if (string.IsNullOrEmpty(txtPassword.Text))
                //{
                //    ClsGlobal.SetInfoMessage("Enter Password", lblMessage);
                //    txtPassword.Focus();
                //    return;
                //}
              
                //oUser.UserId = txtUserId.Text.Trim();
                //oUser.Password = txtPassword.Text.Trim();
                //oUser.DbType = EnumDbType.VALIDATEUSER;
                //DataTable dt = oDal.ManageUser(oUser);
                //if (dt.Rows.Count > 0)
                //{
                //    ClsGlobal.UserId = txtUserId.Text.Trim();
                //    ClsGlobal.UserName = dt.Rows[0]["UserName"].ToString();
                //    ClsGlobal.UserGroup = dt.Rows[0]["GroupName"].ToString();
                 
                    frmMenu oFrm = new frmMenu();
                    oFrm.Show();
                    oFrm.FormClosing += OFrm_FormClosing;
                    this.Hide();
                //}
                //else
                //{
                //    txtUserId.Text = "";
                //    txtPassword.Text = "";
                //    ClsGlobal.SetInfoMessage("Wrong UserId/Password", lblMessage);
                //    txtUserId.Focus();
                //}
            }
            catch (Exception ex)
            {
                ClsGlobal.SetErrorMessage(ex.Message, lblMessage);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region TextBox Event
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnLogin_Click(sender, e);
        }

        #endregion

        #region Methods


        #endregion

        #region Label Events
        private void lblMessage_Click(object sender, EventArgs e)
        {
            try
            {
                ClsGlobal.ShowInfoMessageBox(lblMessage.Text);
            }
            catch (Exception ex)
            {
                ClsGlobal.SetErrorMessage(ex.Message, lblMessage);
            }
        }

        #endregion
    }
}
