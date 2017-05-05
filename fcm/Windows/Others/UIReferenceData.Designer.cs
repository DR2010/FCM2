namespace fcm.Windows
{
    partial class UIReferenceData
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
            this.cbxCodeType = new System.Windows.Forms.ComboBox();
            this.btnNewType = new System.Windows.Forms.Button();
            this.gbCodeType = new System.Windows.Forms.GroupBox();
            this.btnNewCodeValue = new System.Windows.Forms.Button();
            this.dgvCodeValue = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ucCodeValue1 = new fcm.Components.UCCodeValue();
            this.ucCodeType1 = new fcm.Components.UCCodeType();
            this.codeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.codeTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.codeValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbCodeType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCodeValue)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxCodeType
            // 
            this.cbxCodeType.FormattingEnabled = true;
            this.cbxCodeType.Location = new System.Drawing.Point(6, 24);
            this.cbxCodeType.Name = "cbxCodeType";
            this.cbxCodeType.Size = new System.Drawing.Size(440, 21);
            this.cbxCodeType.TabIndex = 3;
            this.cbxCodeType.SelectedIndexChanged += new System.EventHandler(this.cbxCodeType_SelectedIndexChanged);
            this.cbxCodeType.Enter += new System.EventHandler(this.cbxCodeType_Enter);
            // 
            // btnNewType
            // 
            this.btnNewType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewType.Location = new System.Drawing.Point(515, 23);
            this.btnNewType.Name = "btnNewType";
            this.btnNewType.Size = new System.Drawing.Size(108, 22);
            this.btnNewType.TabIndex = 4;
            this.btnNewType.Text = "Code Type...";
            this.btnNewType.UseVisualStyleBackColor = true;
            this.btnNewType.Click += new System.EventHandler(this.btnNewType_Click);
            // 
            // gbCodeType
            // 
            this.gbCodeType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCodeType.Controls.Add(this.btnNewCodeValue);
            this.gbCodeType.Controls.Add(this.ucCodeValue1);
            this.gbCodeType.Controls.Add(this.ucCodeType1);
            this.gbCodeType.Controls.Add(this.btnNewType);
            this.gbCodeType.Controls.Add(this.dgvCodeValue);
            this.gbCodeType.Controls.Add(this.cbxCodeType);
            this.gbCodeType.Location = new System.Drawing.Point(12, 29);
            this.gbCodeType.Name = "gbCodeType";
            this.gbCodeType.Size = new System.Drawing.Size(632, 465);
            this.gbCodeType.TabIndex = 5;
            this.gbCodeType.TabStop = false;
            this.gbCodeType.Text = "Code Type";
            this.gbCodeType.Enter += new System.EventHandler(this.gbCodeType_Enter);
            // 
            // btnNewCodeValue
            // 
            this.btnNewCodeValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewCodeValue.Location = new System.Drawing.Point(521, 432);
            this.btnNewCodeValue.Name = "btnNewCodeValue";
            this.btnNewCodeValue.Size = new System.Drawing.Size(106, 23);
            this.btnNewCodeValue.TabIndex = 6;
            this.btnNewCodeValue.Text = "Code Value...";
            this.btnNewCodeValue.UseVisualStyleBackColor = true;
            this.btnNewCodeValue.Click += new System.EventHandler(this.btnNewCodeValue_Click);
            // 
            // dgvCodeValue
            // 
            this.dgvCodeValue.AllowUserToAddRows = false;
            this.dgvCodeValue.AllowUserToDeleteRows = false;
            this.dgvCodeValue.AllowUserToOrderColumns = true;
            this.dgvCodeValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCodeValue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCodeValue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCodeValue.Location = new System.Drawing.Point(6, 58);
            this.dgvCodeValue.Name = "dgvCodeValue";
            this.dgvCodeValue.ReadOnly = true;
            this.dgvCodeValue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCodeValue.Size = new System.Drawing.Size(620, 370);
            this.dgvCodeValue.TabIndex = 0;
            this.dgvCodeValue.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCodeValue_CellDoubleClick);
            this.dgvCodeValue.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCodeValue_CellClick);
            this.dgvCodeValue.CellBorderStyleChanged += new System.EventHandler(this.dgvCodeValue_CellBorderStyleChanged);
            this.dgvCodeValue.SelectionChanged += new System.EventHandler(this.dgvCodeValue_SelectionChanged);
            this.dgvCodeValue.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCodeValue_CellContentClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.codeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(656, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // eToolStripMenuItem
            // 
            this.eToolStripMenuItem.Name = "eToolStripMenuItem";
            this.eToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.eToolStripMenuItem.Text = "Exit";
            this.eToolStripMenuItem.Click += new System.EventHandler(this.eToolStripMenuItem_Click);
            // 
            // ucCodeValue1
            // 
            this.ucCodeValue1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ucCodeValue1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ucCodeValue1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucCodeValue1.Location = new System.Drawing.Point(249, 154);
            this.ucCodeValue1.Name = "ucCodeValue1";
            this.ucCodeValue1.Size = new System.Drawing.Size(374, 272);
            this.ucCodeValue1.TabIndex = 5;
            // 
            // ucCodeType1
            // 
            this.ucCodeType1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucCodeType1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ucCodeType1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucCodeType1.Location = new System.Drawing.Point(249, 66);
            this.ucCodeType1.Name = "ucCodeType1";
            this.ucCodeType1.Size = new System.Drawing.Size(374, 148);
            this.ucCodeType1.TabIndex = 1;
            this.ucCodeType1.Visible = false;
            // 
            // codeToolStripMenuItem
            // 
            this.codeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.codeTypeToolStripMenuItem,
            this.codeValueToolStripMenuItem});
            this.codeToolStripMenuItem.Name = "codeToolStripMenuItem";
            this.codeToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.codeToolStripMenuItem.Text = "Code";
            // 
            // codeTypeToolStripMenuItem
            // 
            this.codeTypeToolStripMenuItem.Name = "codeTypeToolStripMenuItem";
            this.codeTypeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.codeTypeToolStripMenuItem.Text = "Code Type";
            this.codeTypeToolStripMenuItem.Click += new System.EventHandler(this.btnNewType_Click);
            // 
            // codeValueToolStripMenuItem
            // 
            this.codeValueToolStripMenuItem.Name = "codeValueToolStripMenuItem";
            this.codeValueToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.codeValueToolStripMenuItem.Text = "Code Value";
            this.codeValueToolStripMenuItem.Click += new System.EventHandler(this.btnNewCodeValue_Click);
            // 
            // UIReferenceData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 502);
            this.Controls.Add(this.gbCodeType);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "UIReferenceData";
            this.Text = "Reference Data";
            this.Load += new System.EventHandler(this.UIReferenceData_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UIReferenceData_FormClosed);
            this.Leave += new System.EventHandler(this.UIReferenceData_Leave);
            this.gbCodeType.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCodeValue)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxCodeType;
        private System.Windows.Forms.Button btnNewType;
        private System.Windows.Forms.GroupBox gbCodeType;
        private fcm.Components.UCCodeType ucCodeType1;
        private System.Windows.Forms.DataGridView dgvCodeValue;
        private System.Windows.Forms.Button btnNewCodeValue;
        private fcm.Components.UCCodeValue ucCodeValue1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem codeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem codeTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem codeValueToolStripMenuItem;
    }
}