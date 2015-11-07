using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VJBatangas.LomiHouse.Administration;
using VJBatangas.LomiHouse.Entity;
using System.Net.Mail;

namespace VJBatangas.LomiHouse
{
    public partial class frmMain : Form
    {

        #region Declaration
        
        #endregion

        #region Property

        public UserInfo userinfo { get; set; }

        #endregion

        #region Event

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.ShowDialog();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMain frml = new frmMain();
            frml.Close();

            this.Hide();
            frmLogin frm = new frmLogin();
            frm.Closed += (sender1, args) => this.Close();
            frm.Show();
        }

        private void miItemWithdrawal_Click(object sender, EventArgs e)
        {
            CloseCurrentChildForm();
            frmWithdrawal frm =  new frmWithdrawal();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void manageCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategory frm = Application.OpenForms["frmCategory"] as frmCategory;

            if (frm != null)
            {
                frm.WindowState = FormWindowState.Maximized;
                frm.BringToFront();
                frm.Activate();
            }
            else
            {
                frm = new frmCategory();
                frm.MdiParent = this;
                frm.Dock = DockStyle.Fill;
                frm.Show();
            }
            //Form1_MdiChildActivate(sender, e);
        }

        private void miManageBranch_Click(object sender, EventArgs e)
        {
            
            //CloseCurrentChildForm();

            frmBranch frm = new frmBranch();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.WindowState = FormWindowState.Maximized;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.userinfo = this.userinfo;
            frm.Show();
            addTab("Branch");
        }        

        private void miManageInventory_Click(object sender, EventArgs e)
        {

            //CloseCurrentChildForm();
            frmInventory frm = new frmInventory();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.WindowState = FormWindowState.Maximized;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.userinfo = this.userinfo;
            frm.Show();
            addTab("Inventory");
        }

        private void tClock_Tick(object sender, EventArgs e)
        {
            tsslTime.Text = DateTime.Now.ToString("hh:mm:sstt");
            tsslDate.Text = DateTime.Now.ToString("MMMM dd, yyyy");
        }

        
        #endregion

        #region Method
        public frmMain()
        {
            InitializeComponent();
            MainMenuStrip.Enabled = true;           
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //Hide Close Button
            this.ControlBox = false;
            //FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;

            //frmLogin login = new frmLogin();

            tsslUser.Text = userinfo.FullName.ToUpper();
        }

        private void CloseCurrentChildForm()
        {
            for (int i = 0; i < this.MdiChildren.Length; i++)
            {
                this.MdiChildren[i].Close();
            }

        }
        #endregion

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMain frml = new frmMain();
            frml.Close();

            this.Hide();
            frmLogin frm = new frmLogin();
            frm.Closed += (sender1, args) => this.Close();
            frm.Show();
        }

        private void addTab(String title)
        {

            TabPage tp = new TabPage(title);

            if (this.tcWindowTab.TabCount == 0)
            {

                tp.Tag = this.ActiveMdiChild;
                tp.Parent = tcWindowTab;
                tcWindowTab.SelectedTab = tp;
                
            }
            else
            {
                bool hasCreated = false;

                for (int i = 0; i < this.tcWindowTab.TabCount; i++)
                {
                    if (tcWindowTab.TabPages[i].Text.Contains(title))
                    {
                        hasCreated = true;  
                    }
                }

                if (hasCreated)
                {
                    tcWindowTab.SelectedTab = tp;
                } else
                {
                    tp.Tag = this.ActiveMdiChild;
                    tp.Parent = tcWindowTab;
                    tcWindowTab.SelectedTab = tp;
                }
            }
            
           
        }

        private void tcWindowTab_Selected(object sender, TabControlEventArgs e)
        {
           // this.tcWindowTab.SelectedTab.BackColor = Color.AliceBlue;
        }
        /*
private void Form1_MdiChildActivate(object sender, EventArgs e)
{
   if (this.ActiveMdiChild == null)
       tabForms.Visible = false;
   // If no any child form, hide tabControl 
   else
   {
       // Child form always maximized 
       this.ActiveMdiChild.WindowState = FormWindowState.Maximized;

       // If child form is new and no has tabPage, create new tabPage 
       if (this.ActiveMdiChild.Tag == null)
       {
           // Add a tabPage to tabControl with child form caption 
           TabPage tp = new TabPage(this.ActiveMdiChild.Text);
           tp.Tag = this.ActiveMdiChild;
           tp.Parent = tabForms;
           tabForms.SelectedTab = tp;

           this.ActiveMdiChild.Tag = tp;
           this.ActiveMdiChild.FormClosed += new FormClosedEventHandler(ActiveMdiChild_FormClosed);
       }
       else
       {
           //for (int i = 0; i < this.tabForms.TabCount; i++)
           //{
           //    if (tabForms.TabPages.Contains(this.ActivateMdiChild.Text))
           //    {

           //    }
           //}
       }

       if (!tabForms.Visible)
       {
           tabForms.Visible = true;
       }

   }
}

private void ActiveMdiChild_FormClosed(object sender, FormClosedEventArgs e)
{
   ((sender as Form).Tag as TabPage).Dispose();
}
*/
    }
}
