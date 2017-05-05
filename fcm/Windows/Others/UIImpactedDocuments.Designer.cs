namespace fcm.Windows
{
    partial class UIImpactedDocuments
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.compareWithLatestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmFontSize825 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmFontSize12 = new System.Windows.Forms.ToolStripMenuItem();
            this.iconSizeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmIcon16 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmIconSize32x = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listImpactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendEmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDocument = new System.Windows.Forms.Button();
            this.txtDocumentID = new System.Windows.Forms.TextBox();
            this.btnImpact = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.txtDocumentName = new System.Windows.Forms.TextBox();
            this.tvDocumentList = new System.Windows.Forms.TreeView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsmExit = new System.Windows.Forms.ToolStripButton();
            this.tsmSelectDocument = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem1,
            this.compareWithLatestToolStripMenuItem,
            this.fontSizeToolStripMenuItem,
            this.iconSizeToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 92);
            // 
            // editToolStripMenuItem1
            // 
            this.editToolStripMenuItem1.Name = "editToolStripMenuItem1";
            this.editToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.editToolStripMenuItem1.Text = "Edit";
            this.editToolStripMenuItem1.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // compareWithLatestToolStripMenuItem
            // 
            this.compareWithLatestToolStripMenuItem.Name = "compareWithLatestToolStripMenuItem";
            this.compareWithLatestToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.compareWithLatestToolStripMenuItem.Text = "Compare with latest";
            // 
            // fontSizeToolStripMenuItem
            // 
            this.fontSizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmFontSize825,
            this.tsmFontSize12});
            this.fontSizeToolStripMenuItem.Name = "fontSizeToolStripMenuItem";
            this.fontSizeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fontSizeToolStripMenuItem.Text = "Font Size";
            // 
            // tsmFontSize825
            // 
            this.tsmFontSize825.Name = "tsmFontSize825";
            this.tsmFontSize825.Size = new System.Drawing.Size(144, 22);
            this.tsmFontSize825.Text = "8.25 (Default)";
            this.tsmFontSize825.Click += new System.EventHandler(this.tsmFontSize825_Click);
            // 
            // tsmFontSize12
            // 
            this.tsmFontSize12.Name = "tsmFontSize12";
            this.tsmFontSize12.Size = new System.Drawing.Size(144, 22);
            this.tsmFontSize12.Text = "12";
            this.tsmFontSize12.Click += new System.EventHandler(this.tsmFontSize12_Click);
            // 
            // iconSizeToolStripMenuItem1
            // 
            this.iconSizeToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmIcon16,
            this.tsmIconSize32x});
            this.iconSizeToolStripMenuItem1.Name = "iconSizeToolStripMenuItem1";
            this.iconSizeToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.iconSizeToolStripMenuItem1.Text = "Icon Size";
            // 
            // tsmIcon16
            // 
            this.tsmIcon16.Name = "tsmIcon16";
            this.tsmIcon16.Size = new System.Drawing.Size(158, 22);
            this.tsmIcon16.Text = "16 x 16 (Default)";
            this.tsmIcon16.Click += new System.EventHandler(this.tsmIcon16_Click);
            // 
            // tsmIconSize32x
            // 
            this.tsmIconSize32x.Name = "tsmIconSize32x";
            this.tsmIconSize32x.Size = new System.Drawing.Size(158, 22);
            this.tsmIconSize32x.Text = "32 x 32";
            this.tsmIconSize32x.Click += new System.EventHandler(this.tsmIconSize32x_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.documentToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(581, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // documentToolStripMenuItem
            // 
            this.documentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listImpactToolStripMenuItem,
            this.editToolStripMenuItem,
            this.sendEmailToolStripMenuItem});
            this.documentToolStripMenuItem.Name = "documentToolStripMenuItem";
            this.documentToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.documentToolStripMenuItem.Text = "Document";
            // 
            // listImpactToolStripMenuItem
            // 
            this.listImpactToolStripMenuItem.Name = "listImpactToolStripMenuItem";
            this.listImpactToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.listImpactToolStripMenuItem.Text = "List Impact";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // sendEmailToolStripMenuItem
            // 
            this.sendEmailToolStripMenuItem.Name = "sendEmailToolStripMenuItem";
            this.sendEmailToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.sendEmailToolStripMenuItem.Text = "Send Email";
            this.sendEmailToolStripMenuItem.Click += new System.EventHandler(this.sendEmailToolStripMenuItem_Click);
            // 
            // btnDocument
            // 
            this.btnDocument.Location = new System.Drawing.Point(12, 60);
            this.btnDocument.Name = "btnDocument";
            this.btnDocument.Size = new System.Drawing.Size(75, 23);
            this.btnDocument.TabIndex = 2;
            this.btnDocument.Text = "Document...";
            this.btnDocument.UseVisualStyleBackColor = true;
            this.btnDocument.Click += new System.EventHandler(this.btnDocument_Click);
            // 
            // txtDocumentID
            // 
            this.txtDocumentID.Enabled = false;
            this.txtDocumentID.Location = new System.Drawing.Point(93, 62);
            this.txtDocumentID.Name = "txtDocumentID";
            this.txtDocumentID.ReadOnly = true;
            this.txtDocumentID.Size = new System.Drawing.Size(75, 20);
            this.txtDocumentID.TabIndex = 3;
            // 
            // btnImpact
            // 
            this.btnImpact.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImpact.Location = new System.Drawing.Point(490, 60);
            this.btnImpact.Name = "btnImpact";
            this.btnImpact.Size = new System.Drawing.Size(75, 23);
            this.btnImpact.TabIndex = 4;
            this.btnImpact.Text = "List Impact";
            this.btnImpact.UseVisualStyleBackColor = true;
            this.btnImpact.Click += new System.EventHandler(this.btnImpact_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(470, 337);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(95, 23);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "Edit Document";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // txtDocumentName
            // 
            this.txtDocumentName.Enabled = false;
            this.txtDocumentName.Location = new System.Drawing.Point(174, 63);
            this.txtDocumentName.Name = "txtDocumentName";
            this.txtDocumentName.ReadOnly = true;
            this.txtDocumentName.Size = new System.Drawing.Size(310, 20);
            this.txtDocumentName.TabIndex = 6;
            // 
            // tvDocumentList
            // 
            this.tvDocumentList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvDocumentList.ContextMenuStrip = this.contextMenuStrip1;
            this.tvDocumentList.Location = new System.Drawing.Point(12, 88);
            this.tvDocumentList.Name = "tvDocumentList";
            this.tvDocumentList.Size = new System.Drawing.Size(553, 243);
            this.tvDocumentList.TabIndex = 7;
            this.tvDocumentList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDocumentList_AfterSelect);
            this.tvDocumentList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvDocumentList_MouseDown);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmExit,
            this.tsmSelectDocument});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(581, 25);
            this.toolStrip1.TabIndex = 8;
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
            this.tsmExit.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // tsmSelectDocument
            // 
            this.tsmSelectDocument.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmSelectDocument.Image = global::fcm.Properties.Resources.ImageWordDocument;
            this.tsmSelectDocument.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmSelectDocument.Name = "tsmSelectDocument";
            this.tsmSelectDocument.Size = new System.Drawing.Size(23, 22);
            this.tsmSelectDocument.Text = "toolStripButton1";
            this.tsmSelectDocument.Click += new System.EventHandler(this.btnDocument_Click);
            // 
            // UIImpactedDocuments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 372);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tvDocumentList);
            this.Controls.Add(this.txtDocumentName);
            this.Controls.Add(this.btnImpact);
            this.Controls.Add(this.txtDocumentID);
            this.Controls.Add(this.btnDocument);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "UIImpactedDocuments";
            this.Text = "Changes Impacting Clients";
            this.Load += new System.EventHandler(this.UIImpactedDocuments_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button btnDocument;
        private System.Windows.Forms.TextBox txtDocumentID;
        private System.Windows.Forms.Button btnImpact;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ToolStripMenuItem documentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listImpactToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.TextBox txtDocumentName;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem1;
        private System.Windows.Forms.TreeView tvDocumentList;
        private System.Windows.Forms.ToolStripMenuItem sendEmailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compareWithLatestToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsmExit;
        private System.Windows.Forms.ToolStripButton tsmSelectDocument;
        private System.Windows.Forms.ToolStripMenuItem fontSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmFontSize825;
        private System.Windows.Forms.ToolStripMenuItem tsmFontSize12;
        private System.Windows.Forms.ToolStripMenuItem iconSizeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmIcon16;
        private System.Windows.Forms.ToolStripMenuItem tsmIconSize32x;
    }
}