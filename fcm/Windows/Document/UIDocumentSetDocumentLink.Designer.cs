namespace fcm
{
    partial class UIDocumentSetDocumentLink
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( UIDocumentSetDocumentLink ) );
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsRemove = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvLinkedDocuments = new System.Windows.Forms.TreeView();
            this.tvListOfDocuments = new System.Windows.Forms.TreeView();
            this.checkProjectPlans = new System.Windows.Forms.CheckBox();
            this.removeDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxLinkType = new System.Windows.Forms.ComboBox();
            this.saveAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linkActionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbxDocument = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cbxDocumentSet = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
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
            this.tsRemove} );
            this.toolStrip1.Location = new System.Drawing.Point( 0, 24 );
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size( 629, 25 );
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
            // tsRemove
            // 
            this.tsRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsRemove.Image = global::fcm.Properties.Resources.Delete;
            this.tsRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsRemove.Name = "tsRemove";
            this.tsRemove.Size = new System.Drawing.Size( 23, 22 );
            this.tsRemove.Text = "Remove";
            this.tsRemove.Click += new System.EventHandler( this.removeDocumentToolStripMenuItem_Click );
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point( 16, 133 );
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add( this.tvLinkedDocuments );
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add( this.tvListOfDocuments );
            this.splitContainer1.Size = new System.Drawing.Size( 605, 261 );
            this.splitContainer1.SplitterDistance = 284;
            this.splitContainer1.TabIndex = 44;
            // 
            // tvLinkedDocuments
            // 
            this.tvLinkedDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvLinkedDocuments.Location = new System.Drawing.Point( 0, 0 );
            this.tvLinkedDocuments.Name = "tvLinkedDocuments";
            this.tvLinkedDocuments.Size = new System.Drawing.Size( 284, 261 );
            this.tvLinkedDocuments.TabIndex = 2;
            this.tvLinkedDocuments.MouseDown += new System.Windows.Forms.MouseEventHandler( this.tvLinkedDocuments_MouseDown );
            // 
            // tvListOfDocuments
            // 
            this.tvListOfDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvListOfDocuments.Location = new System.Drawing.Point( 0, 0 );
            this.tvListOfDocuments.Name = "tvListOfDocuments";
            this.tvListOfDocuments.Size = new System.Drawing.Size( 317, 261 );
            this.tvListOfDocuments.TabIndex = 3;
            this.tvListOfDocuments.DoubleClick += new System.EventHandler( this.tvListOfDocuments_DoubleClick_1 );
            this.tvListOfDocuments.MouseDown += new System.Windows.Forms.MouseEventHandler( this.tvListOfDocuments_MouseDown );
            // 
            // checkProjectPlans
            // 
            this.checkProjectPlans.AutoSize = true;
            this.checkProjectPlans.Location = new System.Drawing.Point( 501, 79 );
            this.checkProjectPlans.Name = "checkProjectPlans";
            this.checkProjectPlans.Size = new System.Drawing.Size( 88, 17 );
            this.checkProjectPlans.TabIndex = 45;
            this.checkProjectPlans.Text = "Project Plans";
            this.checkProjectPlans.UseVisualStyleBackColor = true;
            this.checkProjectPlans.CheckedChanged += new System.EventHandler( this.checkProjectPlans_CheckedChanged_1 );
            // 
            // removeDocumentToolStripMenuItem
            // 
            this.removeDocumentToolStripMenuItem.Name = "removeDocumentToolStripMenuItem";
            this.removeDocumentToolStripMenuItem.Size = new System.Drawing.Size( 176, 22 );
            this.removeDocumentToolStripMenuItem.Text = "Remove Document";
            this.removeDocumentToolStripMenuItem.Click += new System.EventHandler( this.removeDocumentToolStripMenuItem_Click );
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 36, 109 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 57, 13 );
            this.label2.TabIndex = 43;
            this.label2.Text = "Link Type:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 36, 82 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 59, 13 );
            this.label1.TabIndex = 42;
            this.label1.Text = "Document:";
            // 
            // cbxLinkType
            // 
            this.cbxLinkType.FormattingEnabled = true;
            this.cbxLinkType.Location = new System.Drawing.Point( 97, 106 );
            this.cbxLinkType.Name = "cbxLinkType";
            this.cbxLinkType.Size = new System.Drawing.Size( 121, 21 );
            this.cbxLinkType.TabIndex = 41;
            this.cbxLinkType.SelectedIndexChanged += new System.EventHandler( this.cbxLinkType_SelectedIndexChanged_1 );
            // 
            // saveAllToolStripMenuItem
            // 
            this.saveAllToolStripMenuItem.Name = "saveAllToolStripMenuItem";
            this.saveAllToolStripMenuItem.Size = new System.Drawing.Size( 176, 22 );
            this.saveAllToolStripMenuItem.Text = "Save All";
            this.saveAllToolStripMenuItem.Click += new System.EventHandler( this.tsbSave_Click );
            // 
            // linkActionsToolStripMenuItem
            // 
            this.linkActionsToolStripMenuItem.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.saveAllToolStripMenuItem,
            this.removeDocumentToolStripMenuItem} );
            this.linkActionsToolStripMenuItem.Name = "linkActionsToolStripMenuItem";
            this.linkActionsToolStripMenuItem.Size = new System.Drawing.Size( 84, 20 );
            this.linkActionsToolStripMenuItem.Text = "Link Actions";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size( 37, 20 );
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler( this.tsbExit_Click );
            // 
            // cbxDocument
            // 
            this.cbxDocument.FormattingEnabled = true;
            this.cbxDocument.Location = new System.Drawing.Point( 97, 79 );
            this.cbxDocument.Name = "cbxDocument";
            this.cbxDocument.Size = new System.Drawing.Size( 376, 21 );
            this.cbxDocument.TabIndex = 40;
            this.cbxDocument.SelectedIndexChanged += new System.EventHandler( this.cbxDocument_SelectedIndexChanged_1 );
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.linkActionsToolStripMenuItem} );
            this.menuStrip1.Location = new System.Drawing.Point( 0, 0 );
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size( 629, 24 );
            this.menuStrip1.TabIndex = 46;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cbxDocumentSet
            // 
            this.cbxDocumentSet.FormattingEnabled = true;
            this.cbxDocumentSet.Location = new System.Drawing.Point( 97, 52 );
            this.cbxDocumentSet.Name = "cbxDocumentSet";
            this.cbxDocumentSet.Size = new System.Drawing.Size( 275, 21 );
            this.cbxDocumentSet.TabIndex = 48;
            this.cbxDocumentSet.SelectedIndexChanged += new System.EventHandler( this.cbxDocumentSet_SelectedIndexChanged );
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 13, 56 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 78, 13 );
            this.label3.TabIndex = 49;
            this.label3.Text = "Document Set:";
            // 
            // UIDocumentSetDocumentLink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 629, 406 );
            this.Controls.Add( this.cbxDocumentSet );
            this.Controls.Add( this.label3 );
            this.Controls.Add( this.toolStrip1 );
            this.Controls.Add( this.splitContainer1 );
            this.Controls.Add( this.checkProjectPlans );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.label1 );
            this.Controls.Add( this.cbxLinkType );
            this.Controls.Add( this.cbxDocument );
            this.Controls.Add( this.menuStrip1 );
            this.Name = "UIDocumentSetDocumentLink";
            this.Text = "Document Set Document Link";
            this.Load += new System.EventHandler( this.UIDocumentSetDocumentLink_Load );
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
        private System.Windows.Forms.ToolStripMenuItem linkActionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbxDocument;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripButton tsRemove;
        private System.Windows.Forms.ComboBox cbxDocumentSet;
        private System.Windows.Forms.Label label3;

    }
}