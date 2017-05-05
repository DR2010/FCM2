namespace fcm.Components
{
    partial class UCCodeType
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodeType = new System.Windows.Forms.TextBox();
            this.txtCodeDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtShortCode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(285, 108);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Code Type: ";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(14, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Code Description: ";
            // 
            // txtCodeType
            // 
            this.txtCodeType.Location = new System.Drawing.Point(124, 15);
            this.txtCodeType.MaxLength = 20;
            this.txtCodeType.Name = "txtCodeType";
            this.txtCodeType.Size = new System.Drawing.Size(236, 20);
            this.txtCodeType.TabIndex = 1;
            this.txtCodeType.TextChanged += new System.EventHandler(this.txtCodeType_TextChanged);
            // 
            // txtCodeDescription
            // 
            this.txtCodeDescription.Location = new System.Drawing.Point(124, 41);
            this.txtCodeDescription.MaxLength = 50;
            this.txtCodeDescription.Multiline = true;
            this.txtCodeDescription.Name = "txtCodeDescription";
            this.txtCodeDescription.Size = new System.Drawing.Size(236, 63);
            this.txtCodeDescription.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Short Code: ";
            // 
            // txtShortCode
            // 
            this.txtShortCode.Location = new System.Drawing.Point(124, 110);
            this.txtShortCode.MaxLength = 3;
            this.txtShortCode.Name = "txtShortCode";
            this.txtShortCode.Size = new System.Drawing.Size(69, 20);
            this.txtShortCode.TabIndex = 5;
            // 
            // UCCodeType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.txtShortCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCodeDescription);
            this.Controls.Add(this.txtCodeType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "UCCodeType";
            this.Size = new System.Drawing.Size(372, 141);
            this.Load += new System.EventHandler(this.UCCodeType_Load);
            this.Enter += new System.EventHandler(this.UCCodeType_Enter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodeType;
        private System.Windows.Forms.TextBox txtCodeDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtShortCode;
    }
}
