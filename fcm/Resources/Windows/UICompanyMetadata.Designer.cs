namespace fcm.Windows
{
    partial class UICompanyMetadata
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
            this.btnSaveModifications = new System.Windows.Forms.Button();
            this.btnCopyDocument = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnCopyFolder = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvGlobalFields = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGlobalFields)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSaveModifications
            // 
            this.btnSaveModifications.Location = new System.Drawing.Point(16, 389);
            this.btnSaveModifications.Name = "btnSaveModifications";
            this.btnSaveModifications.Size = new System.Drawing.Size(175, 23);
            this.btnSaveModifications.TabIndex = 1;
            this.btnSaveModifications.Text = "Save Modifications";
            this.btnSaveModifications.UseVisualStyleBackColor = true;
            this.btnSaveModifications.Click += new System.EventHandler(this.btnSaveModifications_Click);
            // 
            // btnCopyDocument
            // 
            this.btnCopyDocument.Location = new System.Drawing.Point(197, 388);
            this.btnCopyDocument.Name = "btnCopyDocument";
            this.btnCopyDocument.Size = new System.Drawing.Size(175, 23);
            this.btnCopyDocument.TabIndex = 2;
            this.btnCopyDocument.Text = "Copy Document";
            this.btnCopyDocument.UseVisualStyleBackColor = true;
            this.btnCopyDocument.Click += new System.EventHandler(this.btnCopyDocument_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnCopyFolder
            // 
            this.btnCopyFolder.Location = new System.Drawing.Point(197, 357);
            this.btnCopyFolder.Name = "btnCopyFolder";
            this.btnCopyFolder.Size = new System.Drawing.Size(175, 25);
            this.btnCopyFolder.TabIndex = 3;
            this.btnCopyFolder.Text = "Copy Folder";
            this.btnCopyFolder.UseVisualStyleBackColor = true;
            this.btnCopyFolder.Click += new System.EventHandler(this.btnCopyFolder_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 356);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 27);
            this.button1.TabIndex = 4;
            this.button1.Text = "Replicate Folders and Files";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvGlobalFields
            // 
            this.dgvGlobalFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGlobalFields.Location = new System.Drawing.Point(16, 19);
            this.dgvGlobalFields.Name = "dgvGlobalFields";
            this.dgvGlobalFields.Size = new System.Drawing.Size(582, 247);
            this.dgvGlobalFields.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvGlobalFields);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(615, 290);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Global Fields";
            // 
            // UICompanyMetadata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 423);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCopyFolder);
            this.Controls.Add(this.btnCopyDocument);
            this.Controls.Add(this.btnSaveModifications);
            this.Name = "UICompanyMetadata";
            this.Text = "Company Metadata";
            this.Load += new System.EventHandler(this.DocumentTemplate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGlobalFields)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSaveModifications;
        private System.Windows.Forms.Button btnCopyDocument;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnCopyFolder;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvGlobalFields;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}