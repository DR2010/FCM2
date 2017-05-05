namespace fcm.Windows
{
    partial class UIGoogleDocs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( UIGoogleDocs ) );
            this.LastModified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RefreshButton = new System.Windows.Forms.Button();
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DocListItemMenu = new System.Windows.Forms.ContextMenuStrip( this.components );
            this.OpenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.DeleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DocList = new System.Windows.Forms.ListView();
            this.DocIcons = new System.Windows.Forms.ImageList( this.components );
            this.LoginButton = new System.Windows.Forms.Button();
            this.Password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.UploaderStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.LogoutButton = new System.Windows.Forms.Button();
            this.Username = new System.Windows.Forms.TextBox();
            this.tvFileList = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip( this.components );
            this.uploadDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tvGoogle = new System.Windows.Forms.TreeView();
            this.DocListItemMenu.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // LastModified
            // 
            this.LastModified.Text = "Last Modified";
            this.LastModified.Width = 139;
            // 
            // RefreshButton
            // 
            this.RefreshButton.Enabled = false;
            this.RefreshButton.Location = new System.Drawing.Point( 21, 488 );
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size( 138, 24 );
            this.RefreshButton.TabIndex = 22;
            this.RefreshButton.Text = "Refresh Document List";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler( this.RefreshButton_Click );
            // 
            // Title
            // 
            this.Title.Text = "Title";
            this.Title.Width = 167;
            // 
            // DocListItemMenu
            // 
            this.DocListItemMenu.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.OpenMenuItem,
            this.toolStripSeparator1,
            this.DeleteMenuItem} );
            this.DocListItemMenu.Name = "DocListItemMenu";
            this.DocListItemMenu.ShowImageMargin = false;
            this.DocListItemMenu.Size = new System.Drawing.Size( 142, 54 );
            // 
            // OpenMenuItem
            // 
            this.OpenMenuItem.Name = "OpenMenuItem";
            this.OpenMenuItem.Size = new System.Drawing.Size( 141, 22 );
            this.OpenMenuItem.Text = "Open in Browser";
            this.OpenMenuItem.Click += new System.EventHandler( this.OpenMenuItem_Click );
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size( 138, 6 );
            // 
            // DeleteMenuItem
            // 
            this.DeleteMenuItem.Name = "DeleteMenuItem";
            this.DeleteMenuItem.Size = new System.Drawing.Size( 141, 22 );
            this.DeleteMenuItem.Text = "Delete Document";
            this.DeleteMenuItem.Click += new System.EventHandler( this.DeleteMenuItem_Click );
            // 
            // DocList
            // 
            this.DocList.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.Title,
            this.LastModified} );
            this.DocList.ContextMenuStrip = this.DocListItemMenu;
            this.DocList.FullRowSelect = true;
            this.DocList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.DocList.Location = new System.Drawing.Point( 0, 6 );
            this.DocList.MultiSelect = false;
            this.DocList.Name = "DocList";
            this.DocList.Size = new System.Drawing.Size( 312, 308 );
            this.DocList.SmallImageList = this.DocIcons;
            this.DocList.TabIndex = 21;
            this.DocList.UseCompatibleStateImageBehavior = false;
            this.DocList.View = System.Windows.Forms.View.Details;
            // 
            // DocIcons
            // 
            this.DocIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject( "DocIcons.ImageStream" )));
            this.DocIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.DocIcons.Images.SetKeyName( 0, "Document.gif" );
            this.DocIcons.Images.SetKeyName( 1, "Presentation.gif" );
            this.DocIcons.Images.SetKeyName( 2, "Spreadsheet.gif" );
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point( 21, 81 );
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size( 77, 34 );
            this.LoginButton.TabIndex = 16;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler( this.LoginButton_Click );
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point( 125, 40 );
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size( 108, 20 );
            this.Password.TabIndex = 15;
            this.Password.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 18, 49 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 53, 13 );
            this.label2.TabIndex = 14;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 18, 21 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 76, 13 );
            this.label1.TabIndex = 13;
            this.label1.Text = "E-mail Address";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.UploaderStatus} );
            this.statusStrip.Location = new System.Drawing.Point( 0, 525 );
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size( 742, 22 );
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 18;
            this.statusStrip.Text = "statusStrip1";
            // 
            // UploaderStatus
            // 
            this.UploaderStatus.Name = "UploaderStatus";
            this.UploaderStatus.Size = new System.Drawing.Size( 78, 17 );
            this.UploaderStatus.Text = "Please sign in";
            // 
            // LogoutButton
            // 
            this.LogoutButton.Enabled = false;
            this.LogoutButton.Location = new System.Drawing.Point( 104, 81 );
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size( 77, 34 );
            this.LogoutButton.TabIndex = 17;
            this.LogoutButton.Text = "Logout";
            this.LogoutButton.UseVisualStyleBackColor = true;
            this.LogoutButton.Click += new System.EventHandler( this.LogoutButton_Click );
            // 
            // Username
            // 
            this.Username.Location = new System.Drawing.Point( 125, 14 );
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size( 212, 20 );
            this.Username.TabIndex = 12;
            // 
            // tvFileList
            // 
            this.tvFileList.AllowDrop = true;
            this.tvFileList.ContextMenuStrip = this.contextMenuStrip1;
            this.tvFileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvFileList.Location = new System.Drawing.Point( 3, 3 );
            this.tvFileList.Name = "tvFileList";
            this.tvFileList.Size = new System.Drawing.Size( 684, 311 );
            this.tvFileList.TabIndex = 23;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.uploadDocumentToolStripMenuItem} );
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size( 172, 26 );
            // 
            // uploadDocumentToolStripMenuItem
            // 
            this.uploadDocumentToolStripMenuItem.Name = "uploadDocumentToolStripMenuItem";
            this.uploadDocumentToolStripMenuItem.Size = new System.Drawing.Size( 171, 22 );
            this.uploadDocumentToolStripMenuItem.Text = "Upload Document";
            this.uploadDocumentToolStripMenuItem.Click += new System.EventHandler( this.uploadDocumentToolStripMenuItem_Click );
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add( this.tabPage1 );
            this.tabControl1.Controls.Add( this.tabPage2 );
            this.tabControl1.Location = new System.Drawing.Point( 21, 130 );
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size( 698, 343 );
            this.tabControl1.TabIndex = 26;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add( this.tvGoogle );
            this.tabPage1.Controls.Add( this.DocList );
            this.tabPage1.Location = new System.Drawing.Point( 4, 22 );
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding( 3 );
            this.tabPage1.Size = new System.Drawing.Size( 690, 317 );
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Google Docs";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add( this.tvFileList );
            this.tabPage2.Location = new System.Drawing.Point( 4, 22 );
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding( 3 );
            this.tabPage2.Size = new System.Drawing.Size( 690, 317 );
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Client Documents";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tvGoogle
            // 
            this.tvGoogle.ContextMenuStrip = this.DocListItemMenu;
            this.tvGoogle.Location = new System.Drawing.Point( 318, 6 );
            this.tvGoogle.Name = "tvGoogle";
            this.tvGoogle.Size = new System.Drawing.Size( 366, 308 );
            this.tvGoogle.TabIndex = 22;
            // 
            // UIGoogleDocs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 742, 547 );
            this.Controls.Add( this.tabControl1 );
            this.Controls.Add( this.RefreshButton );
            this.Controls.Add( this.Password );
            this.Controls.Add( this.LoginButton );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.label1 );
            this.Controls.Add( this.statusStrip );
            this.Controls.Add( this.Username );
            this.Controls.Add( this.LogoutButton );
            this.Name = "UIGoogleDocs";
            this.Text = "UIGoogleDocs";
            this.Load += new System.EventHandler( this.UIGoogleDocs_Load );
            this.DocListItemMenu.ResumeLayout( false );
            this.statusStrip.ResumeLayout( false );
            this.statusStrip.PerformLayout();
            this.contextMenuStrip1.ResumeLayout( false );
            this.tabControl1.ResumeLayout( false );
            this.tabPage1.ResumeLayout( false );
            this.tabPage2.ResumeLayout( false );
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader LastModified;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ContextMenuStrip DocListItemMenu;
        private System.Windows.Forms.ToolStripMenuItem OpenMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem DeleteMenuItem;
        private System.Windows.Forms.ListView DocList;
        private System.Windows.Forms.ImageList DocIcons;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel UploaderStatus;
        private System.Windows.Forms.Button LogoutButton;
        private System.Windows.Forms.TextBox Username;
        private System.Windows.Forms.TreeView tvFileList;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem uploadDocumentToolStripMenuItem;
        private System.Windows.Forms.TreeView tvGoogle;
    }
}