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
    public partial class frmWithdrawal : Form
    {
        public frmWithdrawal()
        {
            InitializeComponent();
            
            
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {

            frmWithdrawalDetail frm = new frmWithdrawalDetail();
            frm.ShowDialog();
            DialogResult result = frm.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                Withdrawal s = new Withdrawal();

                s.AvailableStock = frm.AvailableStock;
                s.ItemId = frm.ItemId;
                s.ItemName = frm.ItemName;
                s.SubTotal = frm.SubTotal;
                s.Quatity = frm.Quatity;
                
                

                dgvData.ColumnCount = 5;
                dgvData.Columns[0].Name = "Item ID";
                dgvData.Columns[1].Name = "Item Name";
                dgvData.Columns[2].Name = "Item Quantity";
                dgvData.Columns[3].Name = "Item Price";
                dgvData.Columns[4].Name = "Sub Total";

                string[] row = new string[] { s.ItemId.ToString(), s.ItemName, s.Quatity.ToString(), "", s.SubTotal.ToString() };
                dgvData.Rows.Add(row);
                //row = new string[] { "2", "Product 2", "2000" };
                //dgvData.Rows.Add(row);
                //row = new string[] { "3", "Product 3", "3000" };
                //dgvData.Rows.Add(row);
                //row = new string[] { "4", "Product 4", "4000" };
                //dgvData.Rows.Add(row);

                //DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                //dgvData.Columns.Add(chk);
                //chk.HeaderText = "Check Data";
                //chk.Name = "chk";
                //dgvData.Rows[2].Cells[3].Value = true;

                DataGridViewLinkColumn Editlink = new DataGridViewLinkColumn();
                Editlink.UseColumnTextForLinkValue = true;
                Editlink.HeaderText = "Edit";
                Editlink.DataPropertyName = "lnkColumn";
                Editlink.LinkBehavior = LinkBehavior.SystemDefault;
                Editlink.Text = "Edit";
                dgvData.Columns.Add(Editlink);

                DataGridViewLinkColumn Deletelink = new DataGridViewLinkColumn();
                Deletelink.UseColumnTextForLinkValue = true;
                Deletelink.HeaderText = "delete";
                Deletelink.DataPropertyName = "lnkColumn";
                Deletelink.LinkBehavior = LinkBehavior.SystemDefault;
                Deletelink.Text = "Delete";
                dgvData.Columns.Add(Deletelink);
            }
            else
            {
            }
            
            //frm.Dispose();

           

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (dgvData.RowCount > 0)
            {

                DialogResult diag = MessageBox.Show("You have pending items. Are you sure you want to discard the transaction?","Message",MessageBoxButtons.YesNo);

                if (diag == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void frmWithdrawal_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            LoadEmployeeNameList();
            dgvData.AutoSize = true;
        }

        #region "Methods"

        private void LoadEmployeeByEmpId(int empid)
        {
            EmployeeMaster emp = new EmployeeMaster();
            BSEmployeeMaster bsemp = new BSEmployeeMaster();

            emp = bsemp.GetEmployeeByEmpId(empid);

            txtBranchName.Text = emp.BranchName;
        }
        private void LoadEmployeeNameList()
        {
            List<EmployeeMaster> emplist = new List<EmployeeMaster>();
            BSEmployeeMaster bsemp = new BSEmployeeMaster();

            emplist = bsemp.GetEmployeeNameList();
            
            cbEmployee.DisplayMember = "FullName";
            cbEmployee.ValueMember = "EmpId";
            cbEmployee.DataSource = emplist;

            cbEmployee.SelectedValue = 0;
        }

        #endregion

        private void btnLoad_Click(object sender, EventArgs e)
        {
            
            if (cbEmployee.SelectedIndex  != -1)
            {
            LoadEmployeeByEmpId(Convert.ToInt32(cbEmployee.SelectedValue.ToString()));
            }

        }
    }
}
