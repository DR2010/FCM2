using FCMMySQLBusinessLibrary.Service.SVCClient;
using FCMMySQLBusinessLibrary.Model.ModelClient;

namespace fcm.Windows
{
    partial class UIClientList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UIClientList));
            this.dgvClientList = new System.Windows.Forms.DataGridView();
            this.dgvUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLegalName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvABN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvMobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvFax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvEmailAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvMainContactPersonName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvFKUserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvRecordVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.clientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miClientDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.miContract = new System.Windows.Forms.ToolStripMenuItem();
            this.miDocuments = new System.Windows.Forms.ToolStripMenuItem();
            this.miNewClient = new System.Windows.Forms.ToolStripMenuItem();
            this.miMetadata = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripExit = new System.Windows.Forms.ToolStripButton();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbDocuments = new System.Windows.Forms.ToolStripButton();
            this.tsRefresh = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvClientList
            // 
            this.dgvClientList.AllowUserToAddRows = false;
            this.dgvClientList.AllowUserToDeleteRows = false;
            this.dgvClientList.AllowUserToOrderColumns = true;
            this.dgvClientList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvClientList.AutoGenerateColumns = false;
            this.dgvClientList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvClientList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvUID,
            this.dgvLegalName,
            this.dgvABN,
            this.dgvName,
            this.dgvAddress,
            this.dgvPhone,
            this.dgvMobile,
            this.dgvFax,
            this.dgvEmailAddress,
            this.dgvMainContactPersonName,
            this.dgvFKUserID,
            this.dgvRecordVersion});
            this.dgvClientList.DataSource = this.clientBindingSource;
            this.dgvClientList.Location = new System.Drawing.Point(10, 62);
            this.dgvClientList.Name = "dgvClientList";
            this.dgvClientList.ReadOnly = true;
            this.dgvClientList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientList.Size = new System.Drawing.Size(857, 410);
            this.dgvClientList.TabIndex = 1;
            this.dgvClientList.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvClientList_CellMouseDown);
            this.dgvClientList.SelectionChanged += new System.EventHandler(this.dgvClientList_SelectionChanged);
            this.dgvClientList.DoubleClick += new System.EventHandler(this.miClientDetails_Click);
            // 
            // dgvUID
            // 
            this.dgvUID.DataPropertyName = "UID";
            this.dgvUID.HeaderText = "UID";
            this.dgvUID.Name = "dgvUID";
            this.dgvUID.ReadOnly = true;
            this.dgvUID.Width = 51;
            // 
            // dgvLegalName
            // 
            this.dgvLegalName.DataPropertyName = "LegalName";
            this.dgvLegalName.HeaderText = "LegalName";
            this.dgvLegalName.Name = "dgvLegalName";
            this.dgvLegalName.ReadOnly = true;
            this.dgvLegalName.Width = 86;
            // 
            // dgvABN
            // 
            this.dgvABN.DataPropertyName = "ABN";
            this.dgvABN.HeaderText = "ABN";
            this.dgvABN.Name = "dgvABN";
            this.dgvABN.ReadOnly = true;
            this.dgvABN.Width = 54;
            // 
            // dgvName
            // 
            this.dgvName.DataPropertyName = "Name";
            this.dgvName.HeaderText = "Name";
            this.dgvName.Name = "dgvName";
            this.dgvName.ReadOnly = true;
            this.dgvName.Width = 60;
            // 
            // dgvAddress
            // 
            this.dgvAddress.DataPropertyName = "Address";
            this.dgvAddress.HeaderText = "Address";
            this.dgvAddress.Name = "dgvAddress";
            this.dgvAddress.ReadOnly = true;
            this.dgvAddress.Width = 70;
            // 
            // dgvPhone
            // 
            this.dgvPhone.DataPropertyName = "Phone";
            this.dgvPhone.HeaderText = "Phone";
            this.dgvPhone.Name = "dgvPhone";
            this.dgvPhone.ReadOnly = true;
            this.dgvPhone.Width = 63;
            // 
            // dgvMobile
            // 
            this.dgvMobile.DataPropertyName = "Mobile";
            this.dgvMobile.HeaderText = "Mobile";
            this.dgvMobile.Name = "dgvMobile";
            this.dgvMobile.ReadOnly = true;
            this.dgvMobile.Width = 63;
            // 
            // dgvFax
            // 
            this.dgvFax.DataPropertyName = "Fax";
            this.dgvFax.HeaderText = "Fax";
            this.dgvFax.Name = "dgvFax";
            this.dgvFax.ReadOnly = true;
            this.dgvFax.Width = 49;
            // 
            // dgvEmailAddress
            // 
            this.dgvEmailAddress.DataPropertyName = "EmailAddress";
            this.dgvEmailAddress.HeaderText = "Email";
            this.dgvEmailAddress.Name = "dgvEmailAddress";
            this.dgvEmailAddress.ReadOnly = true;
            this.dgvEmailAddress.Width = 57;
            // 
            // dgvMainContactPersonName
            // 
            this.dgvMainContactPersonName.DataPropertyName = "MainContactPersonName";
            this.dgvMainContactPersonName.HeaderText = "Contact Person";
            this.dgvMainContactPersonName.Name = "dgvMainContactPersonName";
            this.dgvMainContactPersonName.ReadOnly = true;
            this.dgvMainContactPersonName.Width = 96;
            // 
            // dgvFKUserID
            // 
            this.dgvFKUserID.DataPropertyName = "FKUserID";
            this.dgvFKUserID.HeaderText = "User Linked";
            this.dgvFKUserID.Name = "dgvFKUserID";
            this.dgvFKUserID.ReadOnly = true;
            this.dgvFKUserID.Width = 82;
            // 
            // dgvRecordVersion
            // 
            this.dgvRecordVersion.DataPropertyName = "RecordVersion";
            this.dgvRecordVersion.HeaderText = "RecordVersion";
            this.dgvRecordVersion.Name = "dgvRecordVersion";
            this.dgvRecordVersion.ReadOnly = true;
            this.dgvRecordVersion.Width = 102;
            // 
            // clientBindingSource
            // 
            this.clientBindingSource.DataSource = typeof(Client);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.Location = new System.Drawing.Point(12, 486);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(66, 22);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(84, 486);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(66, 22);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.toolStripExit_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.clientToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(879, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "Exit";
            // 
            // clientToolStripMenuItem
            // 
            this.clientToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miClientDetails,
            this.miContract,
            this.miDocuments,
            this.miNewClient,
            this.miMetadata});
            this.clientToolStripMenuItem.Name = "clientToolStripMenuItem";
            this.clientToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.clientToolStripMenuItem.Text = "Client";
            // 
            // miClientDetails
            // 
            this.miClientDetails.Name = "miClientDetails";
            this.miClientDetails.Size = new System.Drawing.Size(152, 22);
            this.miClientDetails.Text = "Details";
            this.miClientDetails.Click += new System.EventHandler(this.miClientDetails_Click);
            // 
            // miContract
            // 
            this.miContract.Name = "miContract";
            this.miContract.Size = new System.Drawing.Size(152, 22);
            this.miContract.Text = "Contract";
            this.miContract.Click += new System.EventHandler(this.miContract_Click);
            // 
            // miDocuments
            // 
            this.miDocuments.Name = "miDocuments";
            this.miDocuments.Size = new System.Drawing.Size(152, 22);
            this.miDocuments.Text = "Documents";
            this.miDocuments.Click += new System.EventHandler(this.miDocuments_Click);
            // 
            // miNewClient
            // 
            this.miNewClient.Name = "miNewClient";
            this.miNewClient.Size = new System.Drawing.Size(152, 22);
            this.miNewClient.Text = "New Client";
            this.miNewClient.Click += new System.EventHandler(this.miNewClient_Click);
            // 
            // miMetadata
            // 
            this.miMetadata.Name = "miMetadata";
            this.miMetadata.Size = new System.Drawing.Size(152, 22);
            this.miMetadata.Text = "Metadata";
            this.miMetadata.Click += new System.EventHandler(this.miMetadata_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripExit,
            this.tsbNew,
            this.tsbOpen,
            this.tsbDocuments,
            this.tsRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(879, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripExit
            // 
            this.toolStripExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripExit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripExit.Image")));
            this.toolStripExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripExit.Name = "toolStripExit";
            this.toolStripExit.Size = new System.Drawing.Size(23, 22);
            this.toolStripExit.Text = "Exit";
            this.toolStripExit.Click += new System.EventHandler(this.toolStripExit_Click);
            // 
            // tsbNew
            // 
            this.tsbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbNew.Image")));
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(23, 22);
            this.tsbNew.Text = "New";
            this.tsbNew.Click += new System.EventHandler(this.miNewClient_Click);
            // 
            // tsbOpen
            // 
            this.tsbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOpen.Image = global::fcm.Properties.Resources.ImageEdit;
            this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Size = new System.Drawing.Size(23, 22);
            this.tsbOpen.Text = "toolStripButton1";
            this.tsbOpen.Click += new System.EventHandler(this.miClientDetails_Click);
            // 
            // tsbDocuments
            // 
            this.tsbDocuments.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDocuments.Image = ((System.Drawing.Image)(resources.GetObject("tsbDocuments.Image")));
            this.tsbDocuments.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDocuments.Name = "tsbDocuments";
            this.tsbDocuments.Size = new System.Drawing.Size(23, 22);
            this.tsbDocuments.Text = "Documents";
            this.tsbDocuments.Click += new System.EventHandler(this.miDocuments_Click);
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
            // UIClientList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 520);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.dgvClientList);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "UIClientList";
            this.Text = "Client List";
            this.Load += new System.EventHandler(this.UIClientList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvClientList;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miClientDetails;
        private System.Windows.Forms.ToolStripMenuItem miContract;
        private System.Windows.Forms.ToolStripMenuItem miDocuments;
        private System.Windows.Forms.ToolStripMenuItem miNewClient;
        private System.Windows.Forms.BindingSource clientBindingSource;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripExit;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ToolStripButton tsbOpen;
        private System.Windows.Forms.ToolStripButton tsbDocuments;
        private System.Windows.Forms.ToolStripButton tsRefresh;
        private System.Windows.Forms.ToolStripMenuItem miMetadata;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvUID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLegalName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvABN;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvMobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvFax;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvEmailAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvMainContactPersonName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvFKUserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvRecordVersion;
    }
}