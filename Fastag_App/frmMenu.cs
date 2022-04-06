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

namespace Fatag_App
{
    public partial class frmMenu : Form
    {
        #region Variables

        Dal oDal;
        User oUser;

        #endregion

        #region Form Methods

        public frmMenu()
        {
            try
            {
                InitializeComponent();
                oUser = new User();
                oDal = new Dal();
            }
            catch (Exception ex)
            {
                ClsGlobal.ShowErrorMessageBox(ex.Message);
            }
        }

        private void frmModelMaster_Load(object sender, EventArgs e)
        {
            try
            {
                //lblWelcome.Text = "Hi! " + ClsGlobal.UserName;
                //if (ClsGlobal.UserId.Trim().ToUpper() != "SATO")
                //{
                //    DisableMenus();
                //    SetMenuRight();
                //}
            }
            catch (Exception ex)
            {
                ClsGlobal.ShowErrorMessageBox(ex.Message);
            }
        }

        private void OFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }

        #endregion

        #region Button Event

        private void picLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Menu Click Events
        private void picChangePassword_Click(object sender, EventArgs e)
        {
            frmChangePassword oFrm = new frmChangePassword();
            oFrm.ShowDialog();
        }
        private void picUserMaster_Click(object sender, EventArgs e)
        {
            frmUserMaster frm = new frmUserMaster();
            frm.Show();
            frm.FormClosing += OFrm_FormClosing;
            this.Hide();
        }
        private void picGroupMaster_Click(object sender, EventArgs e)
        {
            frmGroupMaster frm = new frmGroupMaster();
            frm.Show();
            frm.FormClosing += OFrm_FormClosing;
            this.Hide();
        }

        #endregion

        #region Method

        private void SetMenuRight()
        {
            try
            {
                DataTable dt = oDal.GetUserRight(ClsGlobal.UserGroup);
                foreach (DataRow row in dt.Rows)
                {
                    switch (row["ModuleId"].ToString())
                    {
                        case "101":
                            picGroupMaster.Enabled = true;
                            lblGroupMaster.Enabled = true;
                            break;
                        case "102":
                            picUserMaster.Enabled = true;
                            lblUserMaster.Enabled = true;
                            break;
                        case "201":
                            picLabelPrinting.Enabled = true;
                            lblLabelPrinting.Enabled = true;
                            break;
                       

                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                ClsGlobal.ShowErrorMessageBox(ex.Message);
            }
        }

        private void DisableMenus()
        {
            try
            {
                //Master Menu
                picGroupMaster.Enabled = false;
                lblGroupMaster.Enabled = false;

                picUserMaster.Enabled = false;
                lblUserMaster.Enabled = false;

                //Process Menu
                picLabelPrinting.Enabled = false;
                lblLabelPrinting.Enabled = false;

            }
            catch (Exception ex) { throw ex; }
        }


        #endregion

        private void lblCustomerMaster_Click(object sender, EventArgs e)
        {

        }

        private void picLabelPrinting_Click(object sender, EventArgs e)
        {
            frmLabelPrinting frm = new frmLabelPrinting();
            frm.Show();
            frm.FormClosing += OFrm_FormClosing;
            this.Hide();
        }
    }
}
