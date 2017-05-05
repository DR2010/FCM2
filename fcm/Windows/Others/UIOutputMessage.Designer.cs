namespace fcm.Windows
{
    partial class UIOutputMessage
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
            this.dgvOutputMessage = new System.Windows.Forms.DataGridView();
            this.btnOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStartTime = new System.Windows.Forms.TextBox();
            this.txtEndTime = new System.Windows.Forms.TextBox();
            this.dgvErrorList = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEstimatedTime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDocsToBeGenerated = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutputMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrorList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvOutputMessage
            // 
            this.dgvOutputMessage.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvOutputMessage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOutputMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOutputMessage.Location = new System.Drawing.Point( 3, 16 );
            this.dgvOutputMessage.Name = "dgvOutputMessage";
            this.dgvOutputMessage.Size = new System.Drawing.Size( 343, 314 );
            this.dgvOutputMessage.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOk.Location = new System.Drawing.Point( 723, 444 );
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size( 75, 23 );
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler( this.btnOk_Click );
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 12, 28 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 32, 13 );
            this.label1.TabIndex = 2;
            this.label1.Text = "Start:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 12, 52 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 44, 13 );
            this.label2.TabIndex = 3;
            this.label2.Text = "Current:";
            // 
            // txtStartTime
            // 
            this.txtStartTime.Enabled = false;
            this.txtStartTime.Location = new System.Drawing.Point( 87, 25 );
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.ReadOnly = true;
            this.txtStartTime.Size = new System.Drawing.Size( 190, 20 );
            this.txtStartTime.TabIndex = 4;
            // 
            // txtEndTime
            // 
            this.txtEndTime.Enabled = false;
            this.txtEndTime.Location = new System.Drawing.Point( 87, 52 );
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.ReadOnly = true;
            this.txtEndTime.Size = new System.Drawing.Size( 190, 20 );
            this.txtEndTime.TabIndex = 5;
            // 
            // dgvErrorList
            // 
            this.dgvErrorList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvErrorList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvErrorList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvErrorList.Location = new System.Drawing.Point( 3, 16 );
            this.dgvErrorList.Name = "dgvErrorList";
            this.dgvErrorList.Size = new System.Drawing.Size( 428, 314 );
            this.dgvErrorList.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add( this.dgvOutputMessage );
            this.groupBox1.Location = new System.Drawing.Point( 15, 91 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 349, 333 );
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Processing";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add( this.dgvErrorList );
            this.groupBox2.Location = new System.Drawing.Point( 367, 91 );
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size( 434, 333 );
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Error List";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressBar1.Location = new System.Drawing.Point( 18, 454 );
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size( 346, 23 );
            this.progressBar1.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 15, 433 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 48, 13 );
            this.label3.TabIndex = 10;
            this.label3.Text = "Progress";
            // 
            // txtEstimatedTime
            // 
            this.txtEstimatedTime.Enabled = false;
            this.txtEstimatedTime.Location = new System.Drawing.Point( 438, 25 );
            this.txtEstimatedTime.Name = "txtEstimatedTime";
            this.txtEstimatedTime.ReadOnly = true;
            this.txtEstimatedTime.Size = new System.Drawing.Size( 190, 20 );
            this.txtEstimatedTime.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point( 296, 28 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 136, 13 );
            this.label4.TabIndex = 11;
            this.label4.Text = "Estimated time to complete:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point( 290, 52 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 142, 13 );
            this.label5.TabIndex = 13;
            this.label5.Text = "Documents to be generated:";
            // 
            // txtDocsToBeGenerated
            // 
            this.txtDocsToBeGenerated.Enabled = false;
            this.txtDocsToBeGenerated.Location = new System.Drawing.Point( 438, 52 );
            this.txtDocsToBeGenerated.Name = "txtDocsToBeGenerated";
            this.txtDocsToBeGenerated.ReadOnly = true;
            this.txtDocsToBeGenerated.Size = new System.Drawing.Size( 190, 20 );
            this.txtDocsToBeGenerated.TabIndex = 14;
            // 
            // UIOutputMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 813, 489 );
            this.Controls.Add( this.txtDocsToBeGenerated );
            this.Controls.Add( this.label5 );
            this.Controls.Add( this.txtEstimatedTime );
            this.Controls.Add( this.label4 );
            this.Controls.Add( this.label3 );
            this.Controls.Add( this.progressBar1 );
            this.Controls.Add( this.groupBox2 );
            this.Controls.Add( this.groupBox1 );
            this.Controls.Add( this.txtEndTime );
            this.Controls.Add( this.txtStartTime );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.label1 );
            this.Controls.Add( this.btnOk );
            this.Name = "UIOutputMessage";
            this.Text = "List of messages";
            this.Load += new System.EventHandler( this.UIOutputMessage_Load );
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutputMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrorList)).EndInit();
            this.groupBox1.ResumeLayout( false );
            this.groupBox2.ResumeLayout( false );
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOutputMessage;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStartTime;
        private System.Windows.Forms.TextBox txtEndTime;
        private System.Windows.Forms.DataGridView dgvErrorList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEstimatedTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDocsToBeGenerated;
    }
}