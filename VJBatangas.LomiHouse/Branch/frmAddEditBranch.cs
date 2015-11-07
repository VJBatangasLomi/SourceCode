using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VJBatangas.LomiHouse.Business;
using VJBatangas.LomiHouse.Entity;
using VJBatangas.LomiHouse.Common;

namespace VJBatangas.LomiHouse.Administration
{
    public partial class frmAddEditBranch : Form
    {
        public InventoryItem item = new InventoryItem();
        public Boolean isEdit;

        public frmAddEditBranch()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        private void frmAddEditBranch_Load(object sender, EventArgs e)
        {
            

            //if (isEdit)
            //{
            //    //Edit Mode
            //    this.Text = VJConstants.MESSAGEBOX_TITLE + "Edit Inventory Item";
            //    //LoadInventoryItem(this.item.ItemId);
            //}
            //else
            //{
            //    //Add Mode
            //    this.Text = VJConstants.MESSAGEBOX_TITLE + "Add Inventory Item";
            //}
        }



        private Boolean ValidateForm()
        {
            Boolean isvalid = true;

            if (String.IsNullOrEmpty(txtBranchName.Text.Trim()))
            {
                MessageBox.Show(VJConstants.REQUIRED_BRANCH_NAME, VJConstants.MESSAGEBOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                isvalid = false;
            }
            else if (String.IsNullOrEmpty(txtStreet.Text.Trim()))
            {
                MessageBox.Show(VJConstants.REQUIRED_STREET, VJConstants.MESSAGEBOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                isvalid = false;
            }
            else if (cmbTown.SelectedIndex == 0)
            {
                MessageBox.Show(VJConstants.REQUIRED_TOWN, VJConstants.MESSAGEBOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                isvalid = false;
            }
            else if (cmbProvince.SelectedIndex == 0)
            {
                MessageBox.Show(VJConstants.REQUIRED_PROVINCE, VJConstants.MESSAGEBOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                isvalid = false;
            }

            return isvalid;
        }

    }
}
