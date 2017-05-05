namespace fcm.Windows
{
    partial class UIReportMetadata
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
            this.dgvClientMetadata = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.miEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnList = new System.Windows.Forms.Button();
            this.btnEditValue = new System.Windows.Forms.Button();
            this.btnDetails = new System.Windows.Forms.Button();
            this.ucReportMetadata1 = new fcm.Components.UCReportMetadata();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientMetadata)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvClientMetadata
            // 
            this.dgvClientMetadata.AllowUserToAddRows = false;
            this.dgvClientMetadata.AllowUserToDeleteRows = false;
            this.dgvClientMetadata.AllowUserToOrderColumns = true;
            this.dgvClientMetadata.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvClientMetadata.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvClientMetadata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientMetadata.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvClientMetadata.Location = new System.Drawing.Point(12, 12);
            this.dgvClientMetadata.MultiSelect = false;
            this.dgvClientMetadata.Name = "dgvClientMetadata";
            this.dgvClientMetadata.ReadOnly = true;
            this.dgvClientMetadata.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientMetadata.Size = new System.Drawing.Size(634, 442);
            this.dgvClientMetadata.TabIndex = 0;
            this.dgvClientMetadata.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientMetadata_CellDoubleClick);
            this.dgvClientMetadata.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientMetadata_CellContentDoubleClick);
            this.dgvClientMetadata.SelectionChanged += new System.EventHandler(this.dgvClientMetadata_SelectionChanged);
            this.dgvClientMetadata.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientMetadata_CellContentClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miDelete,
            this.miEdit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 70);
            // 
            // miDelete
            // 
            this.miDelete.Name = "miDelete";
            this.miDelete.Size = new System.Drawing.Size(152, 22);
            this.miDelete.Text = "Delete";
            this.miDelete.Click += new System.EventHandler(this.miDelete_Click);
            // 
            // miEdit
            // 
            this.miEdit.Name = "miEdit";
            this.miEdit.Size = new System.Drawing.Size(152, 22);
            this.miEdit.Text = "Edit";
            this.miEdit.Click += new System.EventHandler(this.miEdit_Click);
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Location = new System.Drawing.Point(12, 460);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(75, 23);
            this.btnList.TabIndex = 1;
            this.btnList.Text = "List";
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // btnEditValue
            // 
            this.btnEditValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditValue.Location = new System.Drawing.Point(93, 460);
            this.btnEditValue.Name = "btnEditValue";
            this.btnEditValue.Size = new System.Drawing.Size(75, 23);
            this.btnEditValue.TabIndex = 3;
            this.btnEditValue.Text = "Edit";
            this.btnEditValue.UseVisualStyleBackColor = true;
            this.btnEditValue.Click += new System.EventHandler(this.btnEditValue_Click);
            // 
            // btnDetails
            // 
            this.btnDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetails.Location = new System.Drawing.Point(571, 460);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(75, 23);
            this.btnDetails.TabIndex = 4;
            this.btnDetails.Text = "Details...";
            this.btnDetails.UseVisualStyleBackColor = true;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // ucReportMetadata1
            // 
            this.ucReportMetadata1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ucReportMetadata1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ucReportMetadata1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ucReportMetadata1.Location = new System.Drawing.Point(274, 137);
            this.ucReportMetadata1.Name = "ucReportMetadata1";
            this.ucReportMetadata1.Size = new System.Drawing.Size(372, 317);
            this.ucReportMetadata1.TabIndex = 2;
            this.ucReportMetadata1.Load += new System.EventHandler(this.ucReportMetadata1_Load);
            // 
            // UIReportMetadata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 499);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.btnEditValue);
            this.Controls.Add(this.ucReportMetadata1);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.dgvClientMetadata);
            this.Name = "UIReportMetadata";
            this.Text = "Report Metadata";
            this.Load += new System.EventHandler(this.UIGeneralMetadata_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientMetadata)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvClientMetadata;
        private System.Windows.Forms.Button btnList;
        private fcm.Components.UCReportMetadata ucReportMetadata1;
        private System.Windows.Forms.Button btnEditValue;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem miDelete;
        private System.Windows.Forms.ToolStripMenuItem miEdit;
    }
}