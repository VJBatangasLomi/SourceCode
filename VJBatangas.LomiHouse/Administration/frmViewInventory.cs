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
    public partial class frmViewInventory : Form
    {
        public InventoryItem item = new InventoryItem();

        public frmViewInventory()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        private void frmAddInventory_Load(object sender, EventArgs e)
        {
            LoadInventory();
        }

        

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void LoadInventory()
        {

            BSInventoryItem bs = new BSInventoryItem();
            item = bs.getInventoryItem(this.item.ItemId);

            if (item != null)
            {
                txtItemName.Text = item.ItemName;
                txtCategory.Text = item.CategoryName;
                txtQuantity.Text = item.Quantity.ToString();
                txtPrice.Text = item.Price.ToString();
                txtAvailable.Text = item.Available;
                txtRemarks.Text = item.Remarks;
                lblCreated.Text = item.CreatedByName + " at " + String.Format("{0:MMMM dd, yyyy}", item.CreatedDate) + " " + String.Format("{0:HH:MM:sstt}", item.CreatedDate);
                
                if (String.IsNullOrEmpty(item.ModifiedByName))
                {
                    lblModified.Visible = false;
                    lblTitleCreatedBy.Visible = false;
                }
                else
                {
                    lblModified.Visible = true;
                    lblTitleCreatedBy.Visible = true;
                    lblModified.Text = item.ModifiedByName + " at " + String.Format("{0:MMMM dd, yyyy}", item.ModifiedDate) + " " + String.Format("{0:HH:MM:sstt}", item.ModifiedDate);
                }
            }


        }
    }
}
