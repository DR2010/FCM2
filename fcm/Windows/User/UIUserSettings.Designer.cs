namespace fcm.Windows
{
    partial class UIUserSettings
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
            this.tvUserSettings = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // tvUserSettings
            // 
            this.tvUserSettings.Location = new System.Drawing.Point(12, 12);
            this.tvUserSettings.Name = "tvUserSettings";
            this.tvUserSettings.Size = new System.Drawing.Size(541, 434);
            this.tvUserSettings.TabIndex = 0;
            // 
            // UIUserSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 458);
            this.Controls.Add(this.tvUserSettings);
            this.Name = "UIUserSettings";
            this.Text = "User Settings";
            this.Load += new System.EventHandler(this.UIUserSettings_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvUserSettings;
    }
}