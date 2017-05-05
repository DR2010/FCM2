namespace fcm.Windows
{
    partial class UIProjectPlan
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
            this.cbxProjectPlan = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tvProjectPlanDoco = new System.Windows.Forms.TreeView();
            this.tvAvailableDocuments = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbxProjectPlan
            // 
            this.cbxProjectPlan.FormattingEnabled = true;
            this.cbxProjectPlan.Location = new System.Drawing.Point( 85, 23 );
            this.cbxProjectPlan.Name = "cbxProjectPlan";
            this.cbxProjectPlan.Size = new System.Drawing.Size( 461, 21 );
            this.cbxProjectPlan.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 12, 26 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 67, 13 );
            this.label1.TabIndex = 1;
            this.label1.Text = "Project Plan:";
            // 
            // tvProjectPlanDoco
            // 
            this.tvProjectPlanDoco.Location = new System.Drawing.Point( 15, 86 );
            this.tvProjectPlanDoco.Name = "tvProjectPlanDoco";
            this.tvProjectPlanDoco.Size = new System.Drawing.Size( 249, 164 );
            this.tvProjectPlanDoco.TabIndex = 2;
            this.tvProjectPlanDoco.MouseDown += new System.Windows.Forms.MouseEventHandler( this.tvProjectPlanDoco_MouseDown );
            // 
            // tvAvailableDocuments
            // 
            this.tvAvailableDocuments.Location = new System.Drawing.Point( 288, 86 );
            this.tvAvailableDocuments.Name = "tvAvailableDocuments";
            this.tvAvailableDocuments.Size = new System.Drawing.Size( 258, 164 );
            this.tvAvailableDocuments.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 12, 67 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 121, 13 );
            this.label2.TabIndex = 4;
            this.label2.Text = "Project Plan Documents";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 285, 67 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 107, 13 );
            this.label3.TabIndex = 5;
            this.label3.Text = "Available Documents";
            // 
            // UIProjectPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 563, 262 );
            this.Controls.Add( this.label3 );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.tvAvailableDocuments );
            this.Controls.Add( this.tvProjectPlanDoco );
            this.Controls.Add( this.label1 );
            this.Controls.Add( this.cbxProjectPlan );
            this.Name = "UIProjectPlan";
            this.Text = "Project Plan Maintenance";
            this.Load += new System.EventHandler( this.UIProjectPlan_Load );
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxProjectPlan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView tvProjectPlanDoco;
        private System.Windows.Forms.TreeView tvAvailableDocuments;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}