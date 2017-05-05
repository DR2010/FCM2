namespace fcm.Windows
{
    partial class UIRelatedReferenceData
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
            this.txtRelatedCodeDescription = new System.Windows.Forms.TextBox();
            this.cbxFrom = new System.Windows.Forms.ComboBox();
            this.txtFromDescription = new System.Windows.Forms.TextBox();
            this.cbxTo = new System.Windows.Forms.ComboBox();
            this.txtToDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tvFrom = new System.Windows.Forms.TreeView();
            this.tvTo = new System.Windows.Forms.TreeView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.cbxRelatedCode = new System.Windows.Forms.ComboBox();
            this.txtNewRelatedCode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Related Code:";
            // 
            // txtRelatedCodeDescription
            // 
            this.txtRelatedCodeDescription.Location = new System.Drawing.Point(240, 51);
            this.txtRelatedCodeDescription.Name = "txtRelatedCodeDescription";
            this.txtRelatedCodeDescription.Size = new System.Drawing.Size(328, 20);
            this.txtRelatedCodeDescription.TabIndex = 2;
            // 
            // cbxFrom
            // 
            this.cbxFrom.Enabled = false;
            this.cbxFrom.FormattingEnabled = true;
            this.cbxFrom.Location = new System.Drawing.Point(74, 109);
            this.cbxFrom.Name = "cbxFrom";
            this.cbxFrom.Size = new System.Drawing.Size(205, 21);
            this.cbxFrom.TabIndex = 3;
            this.cbxFrom.SelectedIndexChanged += new System.EventHandler(this.cbxFrom_SelectedIndexChanged);
            // 
            // txtFromDescription
            // 
            this.txtFromDescription.Enabled = false;
            this.txtFromDescription.Location = new System.Drawing.Point(24, 77);
            this.txtFromDescription.Name = "txtFromDescription";
            this.txtFromDescription.ReadOnly = true;
            this.txtFromDescription.Size = new System.Drawing.Size(255, 20);
            this.txtFromDescription.TabIndex = 4;
            // 
            // cbxTo
            // 
            this.cbxTo.Enabled = false;
            this.cbxTo.FormattingEnabled = true;
            this.cbxTo.Location = new System.Drawing.Point(348, 109);
            this.cbxTo.Name = "cbxTo";
            this.cbxTo.Size = new System.Drawing.Size(220, 21);
            this.cbxTo.TabIndex = 5;
            this.cbxTo.SelectedIndexChanged += new System.EventHandler(this.cbxTo_SelectedIndexChanged);
            // 
            // txtToDescription
            // 
            this.txtToDescription.Enabled = false;
            this.txtToDescription.Location = new System.Drawing.Point(311, 77);
            this.txtToDescription.Name = "txtToDescription";
            this.txtToDescription.ReadOnly = true;
            this.txtToDescription.Size = new System.Drawing.Size(257, 20);
            this.txtToDescription.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "From:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(308, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "To:";
            // 
            // tvFrom
            // 
            this.tvFrom.AllowDrop = true;
            this.tvFrom.Location = new System.Drawing.Point(24, 136);
            this.tvFrom.Name = "tvFrom";
            this.tvFrom.Size = new System.Drawing.Size(255, 274);
            this.tvFrom.TabIndex = 9;
            this.tvFrom.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvFrom_DragDrop);
            this.tvFrom.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvFrom_DragEnter);
            // 
            // tvTo
            // 
            this.tvTo.Location = new System.Drawing.Point(311, 136);
            this.tvTo.Name = "tvTo";
            this.tvTo.Size = new System.Drawing.Size(257, 274);
            this.tvTo.TabIndex = 10;
            this.tvTo.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvTo_ItemDrag);
            this.tvTo.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvTo_DragDrop);
            this.tvTo.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvTo_DragEnter);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(24, 420);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(493, 23);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 13;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // cbxRelatedCode
            // 
            this.cbxRelatedCode.FormattingEnabled = true;
            this.cbxRelatedCode.Location = new System.Drawing.Point(113, 24);
            this.cbxRelatedCode.Name = "cbxRelatedCode";
            this.cbxRelatedCode.Size = new System.Drawing.Size(121, 21);
            this.cbxRelatedCode.TabIndex = 14;
            this.cbxRelatedCode.SelectedIndexChanged += new System.EventHandler(this.cbxRelatedCode_SelectedIndexChanged);
            // 
            // txtNewRelatedCode
            // 
            this.txtNewRelatedCode.Location = new System.Drawing.Point(240, 24);
            this.txtNewRelatedCode.Name = "txtNewRelatedCode";
            this.txtNewRelatedCode.Size = new System.Drawing.Size(121, 20);
            this.txtNewRelatedCode.TabIndex = 15;
            // 
            // UIRelatedReferenceData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 463);
            this.Controls.Add(this.txtNewRelatedCode);
            this.Controls.Add(this.cbxRelatedCode);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tvTo);
            this.Controls.Add(this.tvFrom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtToDescription);
            this.Controls.Add(this.cbxTo);
            this.Controls.Add(this.txtFromDescription);
            this.Controls.Add(this.cbxFrom);
            this.Controls.Add(this.txtRelatedCodeDescription);
            this.Controls.Add(this.label1);
            this.Name = "UIRelatedReferenceData";
            this.Text = "Related Reference Data";
            this.Load += new System.EventHandler(this.UIRelatedReferenceData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRelatedCodeDescription;
        private System.Windows.Forms.ComboBox cbxFrom;
        private System.Windows.Forms.TextBox txtFromDescription;
        private System.Windows.Forms.ComboBox cbxTo;
        private System.Windows.Forms.TextBox txtToDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TreeView tvFrom;
        private System.Windows.Forms.TreeView tvTo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.ComboBox cbxRelatedCode;
        private System.Windows.Forms.TextBox txtNewRelatedCode;
    }
}