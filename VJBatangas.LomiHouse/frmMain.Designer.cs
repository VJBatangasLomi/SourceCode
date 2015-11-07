namespace VJBatangas.LomiHouse
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miView = new System.Windows.Forms.ToolStripMenuItem();
            this.miItemWithdrawal = new System.Windows.Forms.ToolStripMenuItem();
            this.miInventory = new System.Windows.Forms.ToolStripMenuItem();
            this.miAdministration = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ssStatus = new System.Windows.Forms.StatusStrip();
            this.tsslTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslWelcome = new System.Windows.Forms.ToolStripStatusLabel();
            this.tClock = new System.Windows.Forms.Timer(this.components);
            this.miManageBranch = new System.Windows.Forms.ToolStripMenuItem();
            this.miManageCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.miManageEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.miManageInventory = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.ssStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.miView,
            this.miAdministration,
            this.reportToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(962, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStripMain";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // miView
            // 
            this.miView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miItemWithdrawal,
            this.miInventory});
            this.miView.Name = "miView";
            this.miView.Size = new System.Drawing.Size(44, 20);
            this.miView.Text = "&View";
            // 
            // miItemWithdrawal
            // 
            this.miItemWithdrawal.Name = "miItemWithdrawal";
            this.miItemWithdrawal.Size = new System.Drawing.Size(161, 22);
            this.miItemWithdrawal.Text = "Item Withdrawal";
            this.miItemWithdrawal.Click += new System.EventHandler(this.miItemWithdrawal_Click);
            // 
            // miInventory
            // 
            this.miInventory.Name = "miInventory";
            this.miInventory.Size = new System.Drawing.Size(161, 22);
            this.miInventory.Text = "Inventory";
            this.miInventory.Click += new System.EventHandler(this.manageCategoryToolStripMenuItem_Click);
            // 
            // miAdministration
            // 
            this.miAdministration.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miManageBranch,
            this.miManageCategory,
            this.miManageEmployee,
            this.miManageInventory});
            this.miAdministration.Name = "miAdministration";
            this.miAdministration.Size = new System.Drawing.Size(98, 20);
            this.miAdministration.Text = "&Administration";
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.reportToolStripMenuItem.Text = "Report";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // ssStatus
            // 
            this.ssStatus.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ssStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslTime,
            this.tsslDate,
            this.toolStripStatusLabel1,
            this.tsslUser,
            this.tsslWelcome});
            this.ssStatus.Location = new System.Drawing.Point(0, 403);
            this.ssStatus.Name = "ssStatus";
            this.ssStatus.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.ssStatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ssStatus.Size = new System.Drawing.Size(962, 22);
            this.ssStatus.TabIndex = 1;
            // 
            // tsslTime
            // 
            this.tsslTime.Name = "tsslTime";
            this.tsslTime.Size = new System.Drawing.Size(40, 17);
            this.tsslTime.Text = "Time";
            // 
            // tsslDate
            // 
            this.tsslDate.Name = "tsslDate";
            this.tsslDate.Size = new System.Drawing.Size(37, 17);
            this.tsslDate.Text = "Date";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(284, 17);
            this.toolStripStatusLabel1.Text = "                                                                     ";
            // 
            // tsslUser
            // 
            this.tsslUser.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsslUser.ForeColor = System.Drawing.Color.Blue;
            this.tsslUser.Name = "tsslUser";
            this.tsslUser.Size = new System.Drawing.Size(35, 17);
            this.tsslUser.Text = "User";
            // 
            // tsslWelcome
            // 
            this.tsslWelcome.ForeColor = System.Drawing.Color.Blue;
            this.tsslWelcome.LinkColor = System.Drawing.Color.Red;
            this.tsslWelcome.Name = "tsslWelcome";
            this.tsslWelcome.Size = new System.Drawing.Size(68, 17);
            this.tsslWelcome.Text = "Welcome";
            // 
            // tClock
            // 
            this.tClock.Enabled = true;
            this.tClock.Tick += new System.EventHandler(this.tClock_Tick);
            // 
            // miManageBranch
            // 
            this.miManageBranch.Image = global::VJBatangas.LomiHouse.Properties.Resources.branch;
            this.miManageBranch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.miManageBranch.Name = "miManageBranch";
            this.miManageBranch.Size = new System.Drawing.Size(172, 22);
            this.miManageBranch.Text = "Manage Branch";
            this.miManageBranch.Click += new System.EventHandler(this.miManageBranch_Click);
            // 
            // miManageCategory
            // 
            this.miManageCategory.Image = global::VJBatangas.LomiHouse.Properties.Resources.category;
            this.miManageCategory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.miManageCategory.Name = "miManageCategory";
            this.miManageCategory.Size = new System.Drawing.Size(172, 22);
            this.miManageCategory.Text = "Manage Category";
            // 
            // miManageEmployee
            // 
            this.miManageEmployee.Image = global::VJBatangas.LomiHouse.Properties.Resources.employee;
            this.miManageEmployee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.miManageEmployee.Name = "miManageEmployee";
            this.miManageEmployee.Size = new System.Drawing.Size(172, 22);
            this.miManageEmployee.Text = "Manage Employee";
            // 
            // miManageInventory
            // 
            this.miManageInventory.Image = global::VJBatangas.LomiHouse.Properties.Resources.inventory;
            this.miManageInventory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.miManageInventory.Name = "miManageInventory";
            this.miManageInventory.Size = new System.Drawing.Size(172, 22);
            this.miManageInventory.Text = "Manage Inventory";
            this.miManageInventory.Click += new System.EventHandler(this.miManageInventory_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(962, 425);
            this.Controls.Add(this.ssStatus);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "VJ Batangas Lomi House";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ssStatus.ResumeLayout(false);
            this.ssStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miView;
        private System.Windows.Forms.StatusStrip ssStatus;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miItemWithdrawal;
        private System.Windows.Forms.ToolStripMenuItem miInventory;
        private System.Windows.Forms.ToolStripMenuItem miAdministration;
        private System.Windows.Forms.ToolStripMenuItem miManageCategory;
        private System.Windows.Forms.ToolStripMenuItem miManageInventory;
        private System.Windows.Forms.Timer tClock;
        private System.Windows.Forms.ToolStripStatusLabel tsslTime;
        private System.Windows.Forms.ToolStripStatusLabel tsslDate;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslUser;
        private System.Windows.Forms.ToolStripStatusLabel tsslWelcome;
        private System.Windows.Forms.ToolStripMenuItem miManageBranch;
        private System.Windows.Forms.ToolStripMenuItem miManageEmployee;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
    }
}

