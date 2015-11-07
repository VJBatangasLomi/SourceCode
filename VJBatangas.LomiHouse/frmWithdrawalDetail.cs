using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VJBatangas.LomiHouse.Business;
using VJBatangas.LomiHouse.Common;
using VJBatangas.LomiHouse.Entity;

namespace VJBatangas.LomiHouse
{
    public partial class frmWithdrawalDetail : Form
    {
        public int TransactionId { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int AvailableStock { get; set; }
        public int Quatity { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string Remarks { get; set; }
        public string PaymentStatus { get; set; }
        public decimal SubTotal { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public string ModifiedByName { get; set; }
        public DateTime ModifiedDate { get; set; }
        public decimal Price { get; set; }
        public frmWithdrawalDetail()
        {
            InitializeComponent();
            LoadCategory();
            txtAvailableStock.Text = "";
            txtPrice.Text = "";
            txtQuantity.Text = "0";
            txtSubTotal.Text = "0.0";            
        }

       
        #region "Events"
        private void frmWithdrawalDetail_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                AvailableStock = Convert.ToInt32(txtAvailableStock.Text);
                ItemId = Convert.ToInt32(cmbItemName.SelectedValue);
                ItemName = cmbItemName.SelectedText;
                Quatity = Convert.ToInt32(txtQuantity.Text);
                Price = Convert.ToDecimal(txtPrice.Text);
                this.Close();
            }
            else
            {

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region "Methods"

        private bool isValid()
        {
            bool result = true;

            if (cmbCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Please select Category");
                result = false;
            }

            if (cmbItemName.SelectedIndex == -1)
            {
                MessageBox.Show("Please select Item");
                result = false;
            }

            if (txtAvailableStock.Text == "0")
            {
                MessageBox.Show("No stock available for this item. Please update your inventory.");
                result = false;
            }

            if (txtQuantity.Text.Trim() == "")
            {
            }
            else
            {
                
            }
            return result;
        }

        private void LoadCategory()
        {
            BSCategory bscat = new BSCategory();
            List<Category> catList = new List<Category>();

            //catList = bscat.GetCategoryList();


            catList = bscat.GetCategoryList(0);

            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryId";
            cmbCategory.DataSource = catList;

        }

        private void GetItemList(int catid)
        {
            BSInventoryItem bs = new BSInventoryItem();
            List<InventoryItemData> itemList = new List<InventoryItemData>();

            //itemList = bs.GetItemList(catid);

            //if (itemList != null || itemList.Count > 0)
            //{
            //    cmbItemName.DisplayMember = "ItemName";
            //    cmbItemName.ValueMember = "ItemId";
            //    cmbItemName.DataSource = itemList;
            //    cmbItemName.Enabled = true;

            //}
        }

        private void GetItemDetails(int itemid)
        {
            BSInventoryItem bs = new BSInventoryItem();
            InventoryItemData item = new InventoryItemData();

            //item = bs.GetItemByID(itemid);

            //if (item != null)
            //{
                
            //    txtAvailableStock.Text = item.Quantity.ToString();
            //    txtPrice.Text = String.Format("{0:0.00}",item.Price);
            //    txtQuantity.Text = "0";
                
            //}
            //else
            //{
            //    txtAvailableStock.Text = "0";
            //    txtPrice.Text = String.Format("{0:0.00}",0);
            //    txtQuantity.Text = "0";
            //}
        }

        private void CalculateSubTotal()
        {
            decimal price = Convert.ToDecimal(txtPrice.Text);
            int qty = 0;

            if (txtQuantity.Text.Trim() != "")
            {
                qty = Convert.ToInt32(txtQuantity.Text);
            }

            txtSubTotal.Text =  (qty * price).ToString();

        }
        #endregion

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbCategory.SelectedIndex != -1)
            {
                GetItemList(Convert.ToInt32(cmbCategory.SelectedValue.ToString()));
            }
        }

        private void cmbItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbItemName.SelectedIndex != -1)
            {
                GetItemDetails(Convert.ToInt32(cmbItemName.SelectedValue.ToString()));
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            
        }

        private void txtQuantity_KeyUp(object sender, KeyEventArgs e)
        {
            
                CalculateSubTotal();
            
        }
    }
}
