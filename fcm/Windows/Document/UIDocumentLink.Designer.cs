namespace fcm.Windows
{
    partial class UIDocumentLink
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( UIDocumentLink ) );
            this.cbxDocument = new System.Windows.Forms.ComboBox();
            this.cbxLinkType = new System.Windows.Forms.ComboBox();
            this.tvLinkedDocuments = new System.Windows.Forms.TreeView();
            this.tvListOfDocuments = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.checkProjectPlans = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linkActionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxDocument
            // 
            this.cbxDocument.FormattingEnabled = true;
            this.cbxDocument.Location = new System.Drawing.Point( 79, 55 );
            this.cbxDocument.Name = "cbxDocument";
            this.cbxDocument.Size = new System.Drawing.Size( 376, 21 );
            this.cbxDocument.TabIndex = 0;
            this.cbxDocument.SelectedIndexChanged += new System.EventHandler( this.cbxDocument_SelectedIndexChanged );
            // 
            // cbxLinkType
            // 
            this.cbxLinkType.FormattingEnabled = true;
            this.cbxLinkType.Location = new System.Drawing.Point( 79, 82 );
            this.cbxLinkType.Name = "cbxLinkType";
            this.cbxLinkType.Size = new System.Drawing.Size( 121, 21 );
            this.cbxLinkType.TabIndex = 1;
            this.cbxLinkType.SelectedIndexChanged += new System.EventHandler( this.cbxLinkType_SelectedIndexChanged );
            // 
            // tvLinkedDocuments
            // 
            this.tvLinkedDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvLinkedDocuments.Location = new System.Drawing.Point( 0, 0 );
            this.tvLinkedDocuments.Name = "tvLinkedDocuments";
            this.tvLinkedDocuments.Size = new System.Drawing.Size( 289, 188 );
            this.tvLinkedDocuments.TabIndex = 2;
            this.tvLinkedDocuments.AfterSelect += new System.Windows.Forms.TreeViewEventHandler( this.tvLinkedDocuments_AfterSelect );
            this.tvLinkedDocuments.DoubleClick += new System.EventHandler( this.tvLinkedDocuments_DoubleClick );
            this.tvLinkedDocuments.Leave += new System.EventHandler( this.tvLinkedDocuments_Leave );
            this.tvLinkedDocuments.MouseDown += new System.Windows.Forms.MouseEventHandler( this.tvLinkedDocuments_MouseDown );
            // 
            // tvListOfDocuments
            // 
            this.tvListOfDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvListOfDocuments.Location = new System.Drawing.Point( 0, 0 );
            this.tvListOfDocuments.Name = "tvListOfDocuments";
            this.tvListOfDocuments.Size = new System.Drawing.Size( 322, 188 );
            this.tvListOfDocuments.TabIndex = 3;
            this.tvListOfDocuments.AfterSelect += new System.Windows.Forms.TreeViewEventHandler( this.tvListOfDocuments_AfterSelect );
            this.tvListOfDocuments.DoubleClick += new System.EventHandler( this.tvListOfDocuments_DoubleClick );
            this.tvListOfDocuments.Leave += new System.EventHandler( this.tvListOfDocuments_Leave );
            this.tvListOfDocuments.MouseDown += new System.Windows.Forms.MouseEventHandler( this.tvListOfDocuments_MouseDown );
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 18, 58 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 59, 13 );
            this.label1.TabIndex = 4;
            this.label1.Text = "Document:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 18, 85 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 57, 13 );
            this.label2.TabIndex = 5;
            this.label2.Text = "Link Type:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point( 21, 112 );
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add( this.tvLinkedDocuments );
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add( this.tvListOfDocuments );
            this.splitContainer1.Size = new System.Drawing.Size( 615, 188 );
            this.splitContainer1.SplitterDistance = 289;
            this.splitContainer1.TabIndex = 6;
            // 
            // checkProjectPlans
            // 
            this.checkProjectPlans.AutoSize = true;
            this.checkProjectPlans.Location = new System.Drawing.Point( 483, 55 );
            this.checkProjectPlans.Name = "checkProjectPlans";
            this.checkProjectPlans.Size = new System.Drawing.Size( 88, 17 );
            this.checkProjectPlans.TabIndex = 37;
            this.checkProjectPlans.Text = "Project Plans";
            this.checkProjectPlans.UseVisualStyleBackColor = true;
            this.checkProjectPlans.CheckedChanged += new System.EventHandler( this.checkProjectPlans_CheckedChanged );
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.linkActionsToolStripMenuItem} );
            this.menuStrip1.Location = new System.Drawing.Point( 0, 0 );
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size( 649, 24 );
            this.menuStrip1.TabIndex = 38;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size( 37, 20 );
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler( this.exitToolStripMenuItem_Click );
            // 
            // linkActionsToolStripMenuItem
            // 
            this.linkActionsToolStripMenuItem.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.saveAllToolStripMenuItem,
            this.removeDocumentToolStripMenuItem,
            this.selectDocumentToolStripMenuItem} );
            this.linkActionsToolStripMenuItem.Name = "linkActionsToolStripMenuItem";
            this.linkActionsToolStripMenuItem.Size = new System.Drawing.Size( 84, 20 );
            this.linkActionsToolStripMenuItem.Text = "Link Actions";
            // 
            // saveAllToolStripMenuItem
            // 
            this.saveAllToolStripMenuItem.Name = "saveAllToolStripMenuItem";
            this.saveAllToolStripMenuItem.Size = new System.Drawing.Size( 176, 22 );
            this.saveAllToolStripMenuItem.Text = "Save All";
            // 
            // removeDocumentToolStripMenuItem
            // 
            this.removeDocumentToolStripMenuItem.Name = "removeDocumentToolStripMenuItem";
            this.removeDocumentToolStripMenuItem.Size = new System.Drawing.Size( 176, 22 );
            this.removeDocumentToolStripMenuItem.Text = "Remove Document";
            this.removeDocumentToolStripMenuItem.Click += new System.EventHandler( this.removeDocumentToolStripMenuItem_Click );
            // 
            // selectDocumentToolStripMenuItem
            // 
            this.selectDocumentToolStripMenuItem.Name = "selectDocumentToolStripMenuItem";
            this.selectDocumentToolStripMenuItem.Size = new System.Drawing.Size( 176, 22 );
            this.selectDocumentToolStripMenuItem.Text = "Select Document";
            this.selectDocumentToolStripMenuItem.Click += new System.EventHandler( this.selectDocumentToolStripMenuItem_Click );
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.tsbExit,
            this.tsbSave} );
            this.toolStrip1.Location = new System.Drawing.Point( 0, 24 );
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size( 649, 25 );
            this.toolStrip1.TabIndex = 39;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbExit
            // 
            this.tsbExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbExit.Image = ((System.Drawing.Image)(resources.GetObject( "tsbExit.Image" )));
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size( 23, 22 );
            this.tsbExit.Text = "Exit";
            this.tsbExit.Click += new System.EventHandler( this.tsbExit_Click );
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = global::fcm.Properties.Resources.Save;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size( 23, 22 );
            this.tsbSave.Text = "Save";
            this.tsbSave.Click += new System.EventHandler( this.tsbSave_Click );
            // 
            // UIDocumentLink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 649, 312 );
            this.Controls.Add( this.toolStrip1 );
            this.Controls.Add( this.checkProjectPlans );
            this.Controls.Add( this.splitContainer1 );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.label1 );
            this.Controls.Add( this.cbxLinkType );
            this.Controls.Add( this.cbxDocument );
            this.Controls.Add( this.menuStrip1 );
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "UIDocumentLink";
            this.Text = "Document Link";
            this.Load += new System.EventHandler( this.UIDocumentLink_Load );
            this.splitContainer1.Panel1.ResumeLayout( false );
            this.splitContainer1.Panel2.ResumeLayout( false );
            this.splitContainer1.ResumeLayout( false );
            this.menuStrip1.ResumeLayout( false );
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout( false );
            this.toolStrip1.PerformLayout();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxDocument;
        private System.Windows.Forms.ComboBox cbxLinkType;
        private System.Windows.Forms.TreeView tvLinkedDocuments;
        private System.Windows.Forms.TreeView tvListOfDocuments;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox checkProjectPlans;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linkActionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeDocumentToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.ToolStripMenuItem selectDocumentToolStripMenuItem;
    }
}