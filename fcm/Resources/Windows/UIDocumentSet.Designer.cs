namespace fcm.Windows
{
    partial class UIDocument
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbxTemplateSet = new System.Windows.Forms.ComboBox();
            this.btnDocumentDetails = new System.Windows.Forms.Button();
            this.dgvDocumentList = new System.Windows.Forms.DataGridView();
            this.btnEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentList)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Document Set:";
            // 
            // cbxTemplateSet
            // 
            this.cbxTemplateSet.FormattingEnabled = true;
            this.cbxTemplateSet.Location = new System.Drawing.Point(96, 21);
            this.cbxTemplateSet.Name = "cbxTemplateSet";
            this.cbxTemplateSet.Size = new System.Drawing.Size(439, 21);
            this.cbxTemplateSet.TabIndex = 4;
            // 
            // btnDocumentDetails
            // 
            this.btnDocumentDetails.Location = new System.Drawing.Point(540, 399);
            this.btnDocumentDetails.Name = "btnDocumentDetails";
            this.btnDocumentDetails.Size = new System.Drawing.Size(76, 27);
            this.btnDocumentDetails.TabIndex = 7;
            this.btnDocumentDetails.Text = "Details...";
            this.btnDocumentDetails.UseVisualStyleBackColor = true;
            // 
            // dgvDocumentList
            // 
            this.dgvDocumentList.AllowUserToAddRows = false;
            this.dgvDocumentList.AllowUserToDeleteRows = false;
            this.dgvDocumentList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDocumentList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDocumentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocumentList.Location = new System.Drawing.Point(12, 48);
            this.dgvDocumentList.MultiSelect = false;
            this.dgvDocumentList.Name = "dgvDocumentList";
            this.dgvDocumentList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocumentList.Size = new System.Drawing.Size(604, 340);
            this.dgvDocumentList.TabIndex = 6;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(541, 19);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 10;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // UIDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 438);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDocumentDetails);
            this.Controls.Add(this.dgvDocumentList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxTemplateSet);
            this.Name = "UIDocument";
            this.Text = "Document Set";
            this.Load += new System.EventHandler(this.UIDocumentSett_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxTemplateSet;
        private System.Windows.Forms.Button btnDocumentDetails;
        private System.Windows.Forms.DataGridView dgvDocumentList;
        private System.Windows.Forms.Button btnEdit;
    }
}