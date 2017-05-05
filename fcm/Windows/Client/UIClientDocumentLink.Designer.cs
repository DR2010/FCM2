namespace fcm.Windows
{
    partial class UIClientDocumentLink
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( UIClientDocumentLink ) );
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbtnDelete = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvLinkedDocuments = new System.Windows.Forms.TreeView();
            this.tvListOfDocuments = new System.Windows.Forms.TreeView();
            this.checkProjectPlans = new System.Windows.Forms.CheckBox();
            this.removeDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxLinkType = new System.Windows.Forms.ComboBox();
            this.saveAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linkActionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.cbxDocument = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxDocumentSet = new System.Windows.Forms.ComboBox();
            this.cbxClient = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.tsbExit,
            this.tsbSave,
            this.tsbtnDelete} );
            this.toolStrip1.Location = new System.Drawing.Point( 0, 24 );
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size( 600, 25 );
            this.toolStrip1.TabIndex = 47;
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
            this.tsbExit.Click += new System.EventHandler( this.tsmiExit_Click );
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
            // tsbtnDelete
            // 
            this.tsbtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnDelete.Image = global::fcm.Properties.Resources.Delete;
            this.tsbtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDelete.Name = "tsbtnDelete";
            this.tsbtnDelete.Size = new System.Drawing.Size( 23, 22 );
            this.tsbtnDelete.Text = "toolStripButton1";
            this.tsbtnDelete.Click += new System.EventHandler( this.tsbtnDelete_Click );
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point( 12, 160 );
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add( this.tvLinkedDocuments );
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add( this.tvListOfDocuments );
            this.splitContainer1.Size = new System.Drawing.Size( 566, 146 );
            this.splitContainer1.SplitterDistance = 265;
            this.splitContainer1.TabIndex = 44;
            // 
            // tvLinkedDocuments
            // 
            this.tvLinkedDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvLinkedDocuments.Location = new System.Drawing.Point( 0, 0 );
            this.tvLinkedDocuments.Name = "tvLinkedDocuments";
            this.tvLinkedDocuments.Size = new System.Drawing.Size( 265, 146 );
            this.tvLinkedDocuments.TabIndex = 2;
            this.tvLinkedDocuments.MouseDown += new System.Windows.Forms.MouseEventHandler( this.tvLinkedDocuments_MouseDown );
            // 
            // tvListOfDocuments
            // 
            this.tvListOfDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvListOfDocuments.Location = new System.Drawing.Point( 0, 0 );
            this.tvListOfDocuments.Name = "tvListOfDocuments";
            this.tvListOfDocuments.Size = new System.Drawing.Size( 297, 146 );
            this.tvListOfDocuments.TabIndex = 3;
            this.tvListOfDocuments.DoubleClick += new System.EventHandler( this.tvListOfDocuments_DoubleClick );
            this.tvListOfDocuments.MouseDown += new System.Windows.Forms.MouseEventHandler( this.tvListOfDocuments_MouseDown );
            // 
            // checkProjectPlans
            // 
            this.checkProjectPlans.AutoSize = true;
            this.checkProjectPlans.Location = new System.Drawing.Point( 498, 106 );
            this.checkProjectPlans.Name = "checkProjectPlans";
            this.checkProjectPlans.Size = new System.Drawing.Size( 88, 17 );
            this.checkProjectPlans.TabIndex = 45;
            this.checkProjectPlans.Text = "Project Plans";
            this.checkProjectPlans.UseVisualStyleBackColor = true;
            // 
            // removeDocumentToolStripMenuItem
            // 
            this.removeDocumentToolStripMenuItem.Name = "removeDocumentToolStripMenuItem";
            this.removeDocumentToolStripMenuItem.Size = new System.Drawing.Size( 176, 22 );
            this.removeDocumentToolStripMenuItem.Text = "Remove Document";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 33, 136 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 57, 13 );
            this.label2.TabIndex = 43;
            this.label2.Text = "Link Type:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 33, 109 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 59, 13 );
            this.label1.TabIndex = 42;
            this.label1.Text = "Document:";
            // 
            // cbxLinkType
            // 
            this.cbxLinkType.FormattingEnabled = true;
            this.cbxLinkType.Location = new System.Drawing.Point( 94, 133 );
            this.cbxLinkType.Name = "cbxLinkType";
            this.cbxLinkType.Size = new System.Drawing.Size( 121, 21 );
            this.cbxLinkType.TabIndex = 41;
            this.cbxLinkType.SelectedIndexChanged += new System.EventHandler( this.cbxDocument_SelectedIndexChanged );
            // 
            // saveAllToolStripMenuItem
            // 
            this.saveAllToolStripMenuItem.Name = "saveAllToolStripMenuItem";
            this.saveAllToolStripMenuItem.Size = new System.Drawing.Size( 176, 22 );
            this.saveAllToolStripMenuItem.Text = "Save All";
            this.saveAllToolStripMenuItem.Click += new System.EventHandler( this.tsbSave_Click );
            // 
            // selectDocumentToolStripMenuItem
            // 
            this.selectDocumentToolStripMenuItem.Name = "selectDocumentToolStripMenuItem";
            this.selectDocumentToolStripMenuItem.Size = new System.Drawing.Size( 176, 22 );
            this.selectDocumentToolStripMenuItem.Text = "Select Document";
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
            // tsmiMenu
            // 
            this.tsmiMenu.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.tsmiExit} );
            this.tsmiMenu.Name = "tsmiMenu";
            this.tsmiMenu.Size = new System.Drawing.Size( 50, 20 );
            this.tsmiMenu.Text = "Menu";
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size( 92, 22 );
            this.tsmiExit.Text = "Exit";
            this.tsmiExit.Click += new System.EventHandler( this.tsmiExit_Click );
            // 
            // cbxDocument
            // 
            this.cbxDocument.FormattingEnabled = true;
            this.cbxDocument.Location = new System.Drawing.Point( 94, 106 );
            this.cbxDocument.Name = "cbxDocument";
            this.cbxDocument.Size = new System.Drawing.Size( 376, 21 );
            this.cbxDocument.TabIndex = 40;
            this.cbxDocument.SelectedIndexChanged += new System.EventHandler( this.cbxDocument_SelectedIndexChanged );
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMenu,
            this.linkActionsToolStripMenuItem} );
            this.menuStrip1.Location = new System.Drawing.Point( 0, 0 );
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size( 600, 24 );
            this.menuStrip1.TabIndex = 46;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 10, 82 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 75, 13 );
            this.label3.TabIndex = 50;
            this.label3.Text = "Client Set ID:  ";
            // 
            // cbxDocumentSet
            // 
            this.cbxDocumentSet.Enabled = false;
            this.cbxDocumentSet.FormattingEnabled = true;
            this.cbxDocumentSet.Location = new System.Drawing.Point( 94, 79 );
            this.cbxDocumentSet.Name = "cbxDocumentSet";
            this.cbxDocumentSet.Size = new System.Drawing.Size( 376, 21 );
            this.cbxDocumentSet.TabIndex = 51;
            // 
            // cbxClient
            // 
            this.cbxClient.Enabled = false;
            this.cbxClient.FormattingEnabled = true;
            this.cbxClient.Location = new System.Drawing.Point( 94, 52 );
            this.cbxClient.Name = "cbxClient";
            this.cbxClient.Size = new System.Drawing.Size( 376, 21 );
            this.cbxClient.TabIndex = 49;
            this.cbxClient.SelectedIndexChanged += new System.EventHandler( this.cbxClient_SelectedIndexChanged );
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point( 52, 55 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 36, 13 );
            this.label4.TabIndex = 48;
            this.label4.Text = "Client:";
            // 
            // UIClientDocumentLink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 600, 318 );
            this.Controls.Add( this.label3 );
            this.Controls.Add( this.cbxDocumentSet );
            this.Controls.Add( this.cbxClient );
            this.Controls.Add( this.label4 );
            this.Controls.Add( this.toolStrip1 );
            this.Controls.Add( this.splitContainer1 );
            this.Controls.Add( this.checkProjectPlans );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.label1 );
            this.Controls.Add( this.cbxLinkType );
            this.Controls.Add( this.cbxDocument );
            this.Controls.Add( this.menuStrip1 );
            this.Name = "UIClientDocumentLink";
            this.Text = "Client Document Link";
            this.Load += new System.EventHandler( this.UIClientDocumentLink_Load );
            this.toolStrip1.ResumeLayout( false );
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout( false );
            this.splitContainer1.Panel2.ResumeLayout( false );
            this.splitContainer1.ResumeLayout( false );
            this.menuStrip1.ResumeLayout( false );
            this.menuStrip1.PerformLayout();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvLinkedDocuments;
        private System.Windows.Forms.TreeView tvListOfDocuments;
        private System.Windows.Forms.CheckBox checkProjectPlans;
        private System.Windows.Forms.ToolStripMenuItem removeDocumentToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxLinkType;
        private System.Windows.Forms.ToolStripMenuItem saveAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectDocumentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linkActionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiMenu;
        private System.Windows.Forms.ComboBox cbxDocument;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxDocumentSet;
        private System.Windows.Forms.ComboBox cbxClient;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripButton tsbtnDelete;
    }
}