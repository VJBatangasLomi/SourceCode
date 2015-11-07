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
//using Excel = Microsoft.Office.Interop.Excel;

namespace VJBatangas.LomiHouse.Administration
{
    public partial class frmInventory : Form
    {
        public UserInfo userinfo { get; set; }
        private VJUtility util = new VJUtility();

        public frmInventory()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        private void frmInventory_Load(object sender, EventArgs e)
        {
            LoadInventory();
           
        }

        private void LoadInventory()
        {
            BSInventoryItem bs = new BSInventoryItem();
            List<InventoryItem> itemlist = new List<InventoryItem>();
            InventoryItem s = new InventoryItem();

           



            DataGridViewLinkColumn Editlink = new DataGridViewLinkColumn();
            Editlink.UseColumnTextForLinkValue = true;
            Editlink.HeaderText = "";
            Editlink.DataPropertyName = "lnkColumn";
            Editlink.LinkBehavior = LinkBehavior.SystemDefault;
            Editlink.Text = "Edit";
            dgvData.Columns.Add(Editlink);

            DataGridViewLinkColumn Deletelink = new DataGridViewLinkColumn();
            Deletelink.UseColumnTextForLinkValue = true;
            Deletelink.HeaderText = "";
            Deletelink.DataPropertyName = "lnkColumn";
            Deletelink.LinkBehavior = LinkBehavior.SystemDefault;
            Deletelink.Text = "Delete";
            dgvData.Columns.Add(Deletelink);

            itemlist = bs.getInventoryItem(0, 0);
            dgvData.DataSource = null;
            dgvData.Rows.Clear();
            dgvData.Columns.Clear();
            dgvData.Refresh();
            dgvData.DataSource = itemlist;

            for (int i = 0; i < dgvData.ColumnCount; i++)
            {
                if (dgvData.Columns[i].HeaderText.ToUpper() == VJColumnName.CONST_ITEM_ID.ToUpper() ||
                    dgvData.Columns[i].HeaderText.ToUpper() == VJColumnName.CONST_CATEGORY_ID.ToUpper()||
                    dgvData.Columns[i].HeaderText.ToUpper() == VJColumnName.CONST_CREATED_BY.ToUpper()||
                    dgvData.Columns[i].HeaderText.ToUpper() == VJColumnName.CONST_MODIFIED_BY.ToUpper())
                {
                    dgvData.Columns[i].Visible = false;
                }
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (dgvData.RowCount > 0)
            {

                DialogResult diag = MessageBox.Show("Are you sure you want to close the form?", "Message", MessageBoxButtons.YesNo);

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


        //private void dgvData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    for (Int32 i = 0; i < this.dgvData.ColumnCount; i++)
        //    {
        //        if (this.dgvData.Rows[e.RowIndex].Cells[i].ValueType == typeof(Int32))
        //        {
        //            this.dgvData.Rows[e.RowIndex].Cells[i].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //        }
        //        else if (this.dgvData.Rows[e.RowIndex].Cells[i].ValueType == typeof(decimal))
        //        {
        //            this.dgvData.Rows[e.RowIndex].Cells[i].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        //        }

        //        if (this.dgvData.Columns[i].HeaderText.ToUpper() == VJColumnName.CONST_AVAILABLE.ToUpper())
        //        {
        //            DataGridViewCell cell = this.dgvData.Rows[e.RowIndex].Cells[i];
        //            DataGridViewCellStyle style = new DataGridViewCellStyle();
        //            style.Font = new Font(dgvData.Font, FontStyle.Bold);
        //            cell.Style.ApplyStyle(style);
        //            cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        //            if (cell.Value.ToString().ToUpper() == VJConstants.CONST_YES.ToUpper())
        //            {
        //                cell.Style.ForeColor = Color.Green;
                        
        //            }
        //            else
        //            {
        //                cell.Style.ForeColor = Color.Red;
        //            }
        //        }
        //    }
        //}

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int id = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["ItemId"].Value);

                frmAddEditInventory frm = new frmAddEditInventory();
                frm.item.ItemId = id;
                frm.isEdit = true;
                frm.ShowDialog();
            }

            else if (e.ColumnIndex == 1 || e.ColumnIndex == 15)
            {
                if (MessageBox.Show("Are you wure you want to delete the record?",VJConstants.MESSAGEBOX_TITLE ,MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["ItemId"].Value);

                    if (DeleteInventoryItem(id))
                    {
                        util.ShowMessage("Item successfully deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadInventory();
                    }
                    else
                    {
                        util.ShowMessage("There something wrong while deleting the record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                
            }
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["ItemId"].Value);

            frmViewInventory frm = new frmViewInventory();
            frm.item.ItemId = id;
            frm.ShowDialog();
        }

        /*
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            Int16 i, j;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);

            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            for (i = 0; i <= dgvData.RowCount - 2; i++)
            {
                for (j = 0; j <= dgvData.ColumnCount - 1; j++)
                {
                    xlWorkSheet.Cells[i + 1, j + 1] = dgvData[j, i].Value.ToString();
                }
            }

            xlWorkBook.SaveAs(@"d:\vjlomi.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
        }
        */
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private Boolean DeleteInventoryItem(int itemid)
        {
            Boolean result = false;

            BSInventoryItem bs = new BSInventoryItem();

            result = bs.DeleteInventoryItem(itemid);


            return result;
        }

        private void tsbAddItem_Click(object sender, EventArgs e)
        {
            frmAddEditInventory frm = new frmAddEditInventory();

            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                InventoryItem objItem = frm.item;
                BSInventoryItem bs = new BSInventoryItem();

                Boolean result = false;

                result = bs.InsertInventoryItem(objItem.ItemName, objItem.CategoryId, objItem.Quantity, objItem.Price, objItem.Available, objItem.Remarks, this.userinfo.EmployeeID);

                if (result)
                {
                    MessageBox.Show(VJConstants.MSG_ITEM_SUCCESSFULLY_ADDED, VJConstants.MESSAGEBOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadInventory();
                }
                else
                {
                    MessageBox.Show(VJConstants.MSG_ERROR_ENCOUNTERED, VJConstants.MESSAGEBOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

            frm.Dispose();
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            LoadInventory();
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void dgvData_MouseClick(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Right)
        //    {
                
        //        this.dgvData.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvData_MouseDown);
        //        this.tsmiDelete.Click += new System.EventHandler(this.DeleteRow_Click);

        //    }

            
        //}

        //private void dgvData_MouseDown(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Right)
        //    {
        //        var hti = dgvData.HitTest(e.X, e.Y);
        //        if (hti.RowIndex >= 0)
        //        {
        //            cmsContextMenu.Show(dgvData, new Point(e.X, e.Y));
        //            dgvData.ClearSelection();
        //            dgvData.Rows[hti.RowIndex].Selected = true;
        //        }
        //    }
        //}

        //private void DeleteRow_Click(object sender, EventArgs e)
        //{
        //    Int32 rowToDelete = dgvData.Rows.GetFirstRow(DataGridViewElementStates.Selected);
        //    dgvData.Rows.RemoveAt(rowToDelete);
        //    dgvData.ClearSelection();
        //}

        //private void dgvData_Scroll(object sender, ScrollEventArgs e)
        //{
        //    cmsContextMenu.Show(dgvData, new Point(e..X, e.Y));
        //}
    }
}
