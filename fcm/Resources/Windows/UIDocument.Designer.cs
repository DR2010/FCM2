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
            this.cbxTemplateSet = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ucDocumentList1 = new fcm.Components.UCDocumentList();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Document Set:";
            // 
            // ucDocumentList1
            // 
            this.ucDocumentList1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ucDocumentList1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ucDocumentList1.Location = new System.Drawing.Point(11, 39);
            this.ucDocumentList1.Name = "ucDocumentList1";
            this.ucDocumentList1.Size = new System.Drawing.Size(672, 394);
            this.ucDocumentList1.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(588, 439);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save Doc Set";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // UIDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 471);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.ucDocumentList1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxTemplateSet);
            this.Name = "UIDocument";
            this.Text = "Document";
            this.Load += new System.EventHandler(this.UITemplateFiles_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxTemplateSet;
        private System.Windows.Forms.Label label1;
        private fcm.Components.UCDocumentList ucDocumentList1;
        private System.Windows.Forms.Button btnSave;
    }
}