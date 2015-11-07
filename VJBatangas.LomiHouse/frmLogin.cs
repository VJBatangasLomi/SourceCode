using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VJBatangas.LomiHouse.Common;
using VJBatangas.LomiHouse.Entity;
using VJBatangas.LomiHouse.Business;

namespace VJBatangas.LomiHouse
{
    public partial class frmLogin : Form
    {
        VJUtility util = new VJUtility();
        public UserInfo user = new UserInfo();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            ProcessLogin();
        }


        private void ProcessLogin()
        {
            if (String.IsNullOrEmpty(txtUsername.Text.Trim()) || string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                util.ShowMessage(VJConstants.MSG_LOGIN_FAILED, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                BSUser bs = new BSUser();
                UserInfo objuser = new UserInfo();

                objuser = bs.ValidateLogin(txtUsername.Text.Trim(), txtPassword.Text.Trim());

                if (objuser != null)
                {

                    frmMain frm = new frmMain();
                    frm.userinfo = objuser;
                    frm.Closed += (sender1, args) => this.Close();
                    this.Hide();

                    frm.Show();
                }
                else
                {
                    util.ShowMessage(VJConstants.MSG_LOGIN_FAILED, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnLogin;
        }
    }
}
