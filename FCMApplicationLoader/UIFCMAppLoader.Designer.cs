namespace FCMApplicationLoader
{
    partial class UIFCMAppLoader
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
            this.btnLoadApplication = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLoadApplication
            // 
            this.btnLoadApplication.Location = new System.Drawing.Point(96, 50);
            this.btnLoadApplication.Name = "btnLoadApplication";
            this.btnLoadApplication.Size = new System.Drawing.Size(214, 69);
            this.btnLoadApplication.TabIndex = 0;
            this.btnLoadApplication.Text = "Start FCM Application";
            this.btnLoadApplication.UseVisualStyleBackColor = true;
            this.btnLoadApplication.Click += new System.EventHandler(this.btnLoadApplication_Click);
            // 
            // UIFCMAppLoader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 186);
            this.Controls.Add(this.btnLoadApplication);
            this.Name = "UIFCMAppLoader";
            this.Text = "FCM Application Loader";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Leave += new System.EventHandler(this.UIFCMAppLoader_Leave);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadApplication;
    }
}

