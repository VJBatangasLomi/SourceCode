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
    public partial class frmAddEditInventory : Form
    {
        public InventoryItem item = new InventoryItem();
        public Boolean isEdit;

        public frmAddEditInventory()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        private void frmAddEditInventory_Load(object sender, EventArgs e)
        {
            LoadCategory();
            LoadAvailable();

            if (isEdit)
            {
                //Edit Mode
                this.Text = VJConstants.MESSAGEBOX_TITLE + "Edit Inventory Item";
                LoadInventoryItem(this.item.ItemId);
            }
            else
            {
                //Add Mode
                this.Text = VJConstants.MESSAGEBOX_TITLE + "Add Inventory Item";
            }
        }

        private void LoadCategory()
        {
            BSCategory bs = new BSCategory();
            List<Category> datalist = new List<Category>();

            Category cat = new Category();
            cat.CategoryId = 0;
            cat.CategoryName = "Select category";
            datalist.Add(cat);

            foreach (Category c in bs.GetCategoryList(0))
            {
                datalist.Add(c);
            }

            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryId";
            cmbCategory.DataSource = datalist;

            cmbCategory.SelectedIndex = 0;
        }

        private void LoadAvailable()
        {
            List<Available> avail = new List<Available>();
            avail.Add(new Available() { Key = "Y", Value ="Yes"});
            avail.Add(new Available() { Key = "N", Value ="No"});
            cmbAvailable.DisplayMember = "Value";
            cmbAvailable.ValueMember = "Key";
            cmbAvailable.DataSource = avail;

            cmbAvailable.SelectedIndex = 0;
        }

        private void LoadInventoryItem(int itemid)
        {
            BSInventoryItem bs = new BSInventoryItem();
            InventoryItem data = new InventoryItem();

            data = bs.getInventoryItem(itemid);

            if (data != null)
            {
                txtItemName.Text = data.ItemName;
                cmbCategory.SelectedValue = data.CategoryId;
                cmbAvailable.SelectedValue = data.Available;
                npdQuantity.Value = data.Quantity;
                txtPrice.Text = data.Price.ToString();
                txtRemarks.Text = data.Remarks;
            }

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                BSInventoryItem bs = new BSInventoryItem();
                Boolean isExists = false;

                isExists = bs.checkInventoryItemByName(txtItemName.Text.Trim());

                if (isExists)
                {
                    VJUtility util = new VJUtility();
                    util.ShowMessage(VJConstants.MSG_ITEM_ALREADY_EXISTS, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {

                    this.item.ItemName = txtItemName.Text;
                    this.item.CategoryId = Convert.ToInt32(cmbCategory.SelectedValue);
                    this.item.Price = Convert.ToDecimal(txtPrice.Text);
                    this.item.Quantity = Convert.ToInt32(npdQuantity.Value);
                    this.item.Remarks = txtRemarks.Text;
                    if (cmbAvailable.SelectedItem.ToString() == "Yes")
                    {
                        this.item.Available = VJConstants.CONST_YES;
                    }
                    else
                    {
                        this.item.Available = VJConstants.CONST_NO;
                    }
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }

            
        }


        private Boolean ValidateForm()
        {
            Boolean isvalid = true;

            if (String.IsNullOrEmpty(txtItemName.Text.Trim()))
            {
                MessageBox.Show(VJConstants.REQUIRED_ITEM_NAME, VJConstants.MESSAGEBOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                isvalid = false;
            }
            else if (npdQuantity.Value == 0)
            {
                MessageBox.Show(VJConstants.REQUIRED_QUANTITY, VJConstants.MESSAGEBOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                isvalid = false;
            }
            else if (cmbCategory.SelectedIndex == 0)
            {
                MessageBox.Show(VJConstants.REQUIRED_CATEGORY, VJConstants.MESSAGEBOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                isvalid = false;
            }
            else if (String.IsNullOrEmpty(txtPrice.Text.Trim()))
            {
                MessageBox.Show(VJConstants.REQUIRED_PRICE, VJConstants.MESSAGEBOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                isvalid = false;
            }

            return isvalid;
        }

    }
}
