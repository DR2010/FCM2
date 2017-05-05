namespace fcm
{
    partial class UITemplateFiles
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
            this.dgvDocumentList = new System.Windows.Forms.DataGridView();
            this.cbxTemplateSet = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDocumentDetails = new System.Windows.Forms.Button();
            this.ucDocument1 = new fcm.Resources.Components.UCDocument();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentList)).BeginInit();
            this.SuspendLayout();
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
            this.dgvDocumentList.Location = new System.Drawing.Point(12, 39);
            this.dgvDocumentList.MultiSelect = false;
            this.dgvDocumentList.Name = "dgvDocumentList";
            this.dgvDocumentList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocumentList.Size = new System.Drawing.Size(666, 408);
            this.dgvDocumentList.TabIndex = 0;
            this.dgvDocumentList.SelectionChanged += new System.EventHandler(this.dgvDocumentList_SelectionChanged);
            // 
            // cbxTemplateSet
            // 
            this.cbxTemplateSet.FormattingEnabled = true;
            this.cbxTemplateSet.Location = new System.Drawing.Point(91, 12);
            this.cbxTemplateSet.Name = "cbxTemplateSet";
            this.cbxTemplateSet.Size = new System.Drawing.Size(587, 21);
            this.cbxTemplateSet.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Template Set:";
            // 
            // btnDocumentDetails
            // 
            this.btnDocumentDetails.Location = new System.Drawing.Point(602, 453);
            this.btnDocumentDetails.Name = "btnDocumentDetails";
            this.btnDocumentDetails.Size = new System.Drawing.Size(76, 27);
            this.btnDocumentDetails.TabIndex = 5;
            this.btnDocumentDetails.Text = "Details...";
            this.btnDocumentDetails.UseVisualStyleBackColor = true;
            this.btnDocumentDetails.Click += new System.EventHandler(this.btnDocumentDetails_Click);
            // 
            // ucDocument1
            // 
            this.ucDocument1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ucDocument1.Location = new System.Drawing.Point(302, 85);
            this.ucDocument1.Name = "ucDocument1";
            this.ucDocument1.Size = new System.Drawing.Size(375, 360);
            this.ucDocument1.TabIndex = 4;
            // 
            // UITemplateFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 492);
            this.Controls.Add(this.btnDocumentDetails);
            this.Controls.Add(this.ucDocument1);
            this.Controls.Add(this.dgvDocumentList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxTemplateSet);
            this.Name = "UITemplateFiles";
            this.Text = "Template Documents";
            this.Load += new System.EventHandler(this.UITemplateFiles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDocumentList;
        private System.Windows.Forms.ComboBox cbxTemplateSet;
        private System.Windows.Forms.Label label1;
        private fcm.Resources.Components.UCDocument ucDocument1;
        private System.Windows.Forms.Button btnDocumentDetails;
    }
}