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
            this.ucCodeValue1 = new fcm.Components.UCCodeValue();
            this.ucCodeType1 = new fcm.Components.UCCodeType();
            this.dgvCodeValue = new System.Windows.Forms.DataGridView();
            this.gbCodeType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCodeValue)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxCodeType
            // 
            this.cbxCodeType.FormattingEnabled = true;
            this.cbxCodeType.Location = new System.Drawing.Point(6, 26);
            this.cbxCodeType.Name = "cbxCodeType";
            this.cbxCodeType.Size = new System.Drawing.Size(440, 21);
            this.cbxCodeType.TabIndex = 3;
            this.cbxCodeType.SelectedIndexChanged += new System.EventHandler(this.cbxCodeType_SelectedIndexChanged);
            this.cbxCodeType.Enter += new System.EventHandler(this.cbxCodeType_Enter);
            // 
            // btnNewType
            // 
            this.btnNewType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewType.Location = new System.Drawing.Point(515, 21);
            this.btnNewType.Name = "btnNewType";
            this.btnNewType.Size = new System.Drawing.Size(111, 22);
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
            this.gbCodeType.Location = new System.Drawing.Point(12, 12);
            this.gbCodeType.Name = "gbCodeType";
            this.gbCodeType.Size = new System.Drawing.Size(632, 466);
            this.gbCodeType.TabIndex = 5;
            this.gbCodeType.TabStop = false;
            this.gbCodeType.Text = "Code Type";
            // 
            // btnNewCodeValue
            // 
            this.btnNewCodeValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewCodeValue.Location = new System.Drawing.Point(521, 439);
            this.btnNewCodeValue.Name = "btnNewCodeValue";
            this.btnNewCodeValue.Size = new System.Drawing.Size(106, 23);
            this.btnNewCodeValue.TabIndex = 6;
            this.btnNewCodeValue.Text = "Code Value...";
            this.btnNewCodeValue.UseVisualStyleBackColor = true;
            this.btnNewCodeValue.Click += new System.EventHandler(this.btnNewCodeValue_Click);
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
            this.ucCodeType1.Location = new System.Drawing.Point(249, 53);
            this.ucCodeType1.Name = "ucCodeType1";
            this.ucCodeType1.Size = new System.Drawing.Size(374, 148);
            this.ucCodeType1.TabIndex = 1;
            this.ucCodeType1.Visible = false;
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
            this.dgvCodeValue.Location = new System.Drawing.Point(6, 50);
            this.dgvCodeValue.Name = "dgvCodeValue";
            this.dgvCodeValue.ReadOnly = true;
            this.dgvCodeValue.Size = new System.Drawing.Size(620, 381);
            this.dgvCodeValue.TabIndex = 0;
            this.dgvCodeValue.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCodeValue_CellDoubleClick);
            this.dgvCodeValue.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCodeValue_CellClick);
            this.dgvCodeValue.CellBorderStyleChanged += new System.EventHandler(this.dgvCodeValue_CellBorderStyleChanged);
            this.dgvCodeValue.SelectionChanged += new System.EventHandler(this.dgvCodeValue_SelectionChanged);
            // 
            // UIReferenceData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 490);
            this.Controls.Add(this.gbCodeType);
            this.Name = "UIReferenceData";
            this.Text = "Reference Data";
            this.Load += new System.EventHandler(this.UIReferenceData_Load);
            this.gbCodeType.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCodeValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxCodeType;
        private System.Windows.Forms.Button btnNewType;
        private System.Windows.Forms.GroupBox gbCodeType;
        private fcm.Components.UCCodeType ucCodeType1;
        private System.Windows.Forms.DataGridView dgvCodeValue;
        private System.Windows.Forms.Button btnNewCodeValue;
        private fcm.Components.UCCodeValue ucCodeValue1;
    }
}