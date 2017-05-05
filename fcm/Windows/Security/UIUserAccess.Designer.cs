namespace fcm.Windows
{
    partial class UIUserAccess
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
            this.tvUserList = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeAccessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRoleDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRoleName = new System.Windows.Forms.TextBox();
            this.btnSaveRole = new System.Windows.Forms.Button();
            this.btnNewRole = new System.Windows.Forms.Button();
            this.tvAvailableRoles = new System.Windows.Forms.TreeView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsmExit = new System.Windows.Forms.ToolStripButton();
            this.tsRefresh = new System.Windows.Forms.ToolStripButton();
            this.groupBoxUserList = new System.Windows.Forms.GroupBox();
            this.groupBoxScreenList = new System.Windows.Forms.GroupBox();
            this.tvScreenList = new System.Windows.Forms.TreeView();
            this.splitContainerOuter = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainerUserDetails = new System.Windows.Forms.SplitContainer();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBoxUserList.SuspendLayout();
            this.groupBoxScreenList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerOuter)).BeginInit();
            this.splitContainerOuter.Panel1.SuspendLayout();
            this.splitContainerOuter.Panel2.SuspendLayout();
            this.splitContainerOuter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerUserDetails)).BeginInit();
            this.splitContainerUserDetails.Panel1.SuspendLayout();
            this.splitContainerUserDetails.Panel2.SuspendLayout();
            this.splitContainerUserDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvUserList
            // 
            this.tvUserList.AllowDrop = true;
            this.tvUserList.ContextMenuStrip = this.contextMenuStrip1;
            this.tvUserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvUserList.Location = new System.Drawing.Point(3, 16);
            this.tvUserList.Name = "tvUserList";
            this.tvUserList.Size = new System.Drawing.Size(214, 380);
            this.tvUserList.TabIndex = 0;
            this.tvUserList.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvUserList_ItemDrag);
            this.tvUserList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvUserList_AfterSelect);
            this.tvUserList.Click += new System.EventHandler(this.tvUserList_Click);
            this.tvUserList.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvUserList_DragDrop);
            this.tvUserList.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvUserList_DragEnter);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeAccessToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(157, 26);
            // 
            // removeAccessToolStripMenuItem
            // 
            this.removeAccessToolStripMenuItem.Name = "removeAccessToolStripMenuItem";
            this.removeAccessToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.removeAccessToolStripMenuItem.Text = "Remove Access";
            this.removeAccessToolStripMenuItem.Click += new System.EventHandler(this.removeAccessToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnResetPassword);
            this.groupBox1.Controls.Add(this.btnNew);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtNewPassword);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtUserID);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(383, 160);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Details";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(135, 69);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(55, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.Location = new System.Drawing.Point(70, 124);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(100, 23);
            this.btnResetPassword.TabIndex = 9;
            this.btnResetPassword.Text = "Save Password";
            this.btnResetPassword.UseVisualStyleBackColor = true;
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(71, 69);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(55, 23);
            this.btnNew.TabIndex = 8;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(176, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Re-type Password:";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(277, 99);
            this.txtNewPassword.MaxLength = 30;
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(100, 20);
            this.txtNewPassword.TabIndex = 6;
            this.txtNewPassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(70, 98);
            this.txtPassword.MaxLength = 30;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(70, 44);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(266, 20);
            this.txtName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "User ID:";
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(70, 19);
            this.txtUserID.MaxLength = 6;
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(100, 20);
            this.txtUserID.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtRoleDescription);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtRoleName);
            this.groupBox2.Controls.Add(this.btnSaveRole);
            this.groupBox2.Controls.Add(this.btnNewRole);
            this.groupBox2.Controls.Add(this.tvAvailableRoles);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(383, 235);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Available Roles";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Description:";
            // 
            // txtRoleDescription
            // 
            this.txtRoleDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtRoleDescription.Location = new System.Drawing.Point(77, 197);
            this.txtRoleDescription.MaxLength = 50;
            this.txtRoleDescription.Name = "txtRoleDescription";
            this.txtRoleDescription.Size = new System.Drawing.Size(176, 20);
            this.txtRoleDescription.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Role:";
            // 
            // txtRoleName
            // 
            this.txtRoleName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtRoleName.Location = new System.Drawing.Point(77, 174);
            this.txtRoleName.MaxLength = 30;
            this.txtRoleName.Name = "txtRoleName";
            this.txtRoleName.Size = new System.Drawing.Size(122, 20);
            this.txtRoleName.TabIndex = 11;
            // 
            // btnSaveRole
            // 
            this.btnSaveRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveRole.Location = new System.Drawing.Point(266, 200);
            this.btnSaveRole.Name = "btnSaveRole";
            this.btnSaveRole.Size = new System.Drawing.Size(70, 23);
            this.btnSaveRole.TabIndex = 12;
            this.btnSaveRole.Text = "Save";
            this.btnSaveRole.UseVisualStyleBackColor = true;
            this.btnSaveRole.Click += new System.EventHandler(this.btnSaveRole_Click);
            // 
            // btnNewRole
            // 
            this.btnNewRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNewRole.Location = new System.Drawing.Point(264, 174);
            this.btnNewRole.Name = "btnNewRole";
            this.btnNewRole.Size = new System.Drawing.Size(70, 23);
            this.btnNewRole.TabIndex = 11;
            this.btnNewRole.Text = "New Role";
            this.btnNewRole.UseVisualStyleBackColor = true;
            this.btnNewRole.Click += new System.EventHandler(this.btnNewRole_Click);
            // 
            // tvAvailableRoles
            // 
            this.tvAvailableRoles.AllowDrop = true;
            this.tvAvailableRoles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tvAvailableRoles.Location = new System.Drawing.Point(13, 19);
            this.tvAvailableRoles.Name = "tvAvailableRoles";
            this.tvAvailableRoles.Size = new System.Drawing.Size(323, 139);
            this.tvAvailableRoles.TabIndex = 5;
            this.tvAvailableRoles.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvAvailableRoles_ItemDrag);
            this.tvAvailableRoles.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvAvailableRoles_DragDrop);
            this.tvAvailableRoles.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvAvailableRoles_DragEnter);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmMenu,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(827, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmMenu
            // 
            this.tsmMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.tsmMenu.Name = "tsmMenu";
            this.tsmMenu.Size = new System.Drawing.Size(50, 20);
            this.tsmMenu.Text = "Menu";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.tsmExit_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 20);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmExit,
            this.tsRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(827, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsmExit
            // 
            this.tsmExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmExit.Image = global::fcm.Properties.Resources.ImageExit;
            this.tsmExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmExit.Name = "tsmExit";
            this.tsmExit.Size = new System.Drawing.Size(23, 22);
            this.tsmExit.Text = "toolStripButton1";
            this.tsmExit.Click += new System.EventHandler(this.tsmExit_Click);
            // 
            // tsRefresh
            // 
            this.tsRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsRefresh.Image = global::fcm.Properties.Resources.Refresh;
            this.tsRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsRefresh.Name = "tsRefresh";
            this.tsRefresh.Size = new System.Drawing.Size(23, 22);
            this.tsRefresh.Text = "Refresh";
            this.tsRefresh.Click += new System.EventHandler(this.tsRefresh_Click);
            // 
            // groupBoxUserList
            // 
            this.groupBoxUserList.Controls.Add(this.tvUserList);
            this.groupBoxUserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxUserList.Location = new System.Drawing.Point(0, 0);
            this.groupBoxUserList.Name = "groupBoxUserList";
            this.groupBoxUserList.Size = new System.Drawing.Size(220, 399);
            this.groupBoxUserList.TabIndex = 5;
            this.groupBoxUserList.TabStop = false;
            this.groupBoxUserList.Text = "User List";
            // 
            // groupBoxScreenList
            // 
            this.groupBoxScreenList.Controls.Add(this.tvScreenList);
            this.groupBoxScreenList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxScreenList.Location = new System.Drawing.Point(0, 0);
            this.groupBoxScreenList.Name = "groupBoxScreenList";
            this.groupBoxScreenList.Size = new System.Drawing.Size(216, 399);
            this.groupBoxScreenList.TabIndex = 6;
            this.groupBoxScreenList.TabStop = false;
            this.groupBoxScreenList.Text = "Screen List";
            // 
            // tvScreenList
            // 
            this.tvScreenList.AllowDrop = true;
            this.tvScreenList.ContextMenuStrip = this.contextMenuStrip1;
            this.tvScreenList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvScreenList.Location = new System.Drawing.Point(3, 16);
            this.tvScreenList.Name = "tvScreenList";
            this.tvScreenList.Size = new System.Drawing.Size(210, 380);
            this.tvScreenList.TabIndex = 0;
            this.tvScreenList.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvScreenList_ItemDrag);
            this.tvScreenList.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvScreenList_DragDrop);
            this.tvScreenList.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvScreenList_DragEnter);
            // 
            // splitContainerOuter
            // 
            this.splitContainerOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerOuter.Location = new System.Drawing.Point(0, 49);
            this.splitContainerOuter.Name = "splitContainerOuter";
            // 
            // splitContainerOuter.Panel1
            // 
            this.splitContainerOuter.Panel1.Controls.Add(this.groupBoxUserList);
            // 
            // splitContainerOuter.Panel2
            // 
            this.splitContainerOuter.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainerOuter.Size = new System.Drawing.Size(827, 399);
            this.splitContainerOuter.SplitterDistance = 220;
            this.splitContainerOuter.TabIndex = 7;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainerUserDetails);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBoxScreenList);
            this.splitContainer1.Size = new System.Drawing.Size(603, 399);
            this.splitContainer1.SplitterDistance = 383;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainerUserDetails
            // 
            this.splitContainerUserDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerUserDetails.Location = new System.Drawing.Point(0, 0);
            this.splitContainerUserDetails.Name = "splitContainerUserDetails";
            this.splitContainerUserDetails.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerUserDetails.Panel1
            // 
            this.splitContainerUserDetails.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainerUserDetails.Panel2
            // 
            this.splitContainerUserDetails.Panel2.Controls.Add(this.groupBox2);
            this.splitContainerUserDetails.Size = new System.Drawing.Size(383, 399);
            this.splitContainerUserDetails.SplitterDistance = 160;
            this.splitContainerUserDetails.TabIndex = 8;
            // 
            // UIUserAccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 448);
            this.Controls.Add(this.splitContainerOuter);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "UIUserAccess";
            this.Text = "User Security Maintenance";
            this.Load += new System.EventHandler(this.UIUserAccess_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBoxUserList.ResumeLayout(false);
            this.groupBoxScreenList.ResumeLayout(false);
            this.splitContainerOuter.Panel1.ResumeLayout(false);
            this.splitContainerOuter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerOuter)).EndInit();
            this.splitContainerOuter.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainerUserDetails.Panel1.ResumeLayout(false);
            this.splitContainerUserDetails.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerUserDetails)).EndInit();
            this.splitContainerUserDetails.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvUserList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmMenu;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsmExit;
        private System.Windows.Forms.Button btnResetPassword;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TreeView tvAvailableRoles;
        private System.Windows.Forms.Button btnNewRole;
        private System.Windows.Forms.Button btnSaveRole;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRoleName;
        private System.Windows.Forms.GroupBox groupBoxUserList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem removeAccessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBoxScreenList;
        private System.Windows.Forms.TreeView tvScreenList;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRoleDescription;
        private System.Windows.Forms.ToolStripButton tsRefresh;
        private System.Windows.Forms.SplitContainer splitContainerOuter;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainerUserDetails;
    }
}