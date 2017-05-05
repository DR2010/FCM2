namespace fcm.Components
{
    partial class UCReportMetadata
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtUID = new System.Windows.Forms.TextBox();
            this.txtFieldCode = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtClientType = new System.Windows.Forms.TextBox();
            this.txtClientUID = new System.Windows.Forms.TextBox();
            this.txtRecordType = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtCondition = new System.Windows.Forms.TextBox();
            this.txtCompareWith = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnLocation = new System.Windows.Forms.Button();
            this.cbxType = new System.Windows.Forms.ComboBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.checkEnabled = new System.Windows.Forms.CheckBox();
            this.checkUseLabel = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Unique ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Field Code: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Description: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Client Type: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Client UID:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Type (field, image): ";
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(105, 288);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(80, 21);
            this.btnNew.TabIndex = 21;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(187, 288);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 21);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtUID
            // 
            this.txtUID.Enabled = false;
            this.txtUID.Location = new System.Drawing.Point(105, 9);
            this.txtUID.Name = "txtUID";
            this.txtUID.ReadOnly = true;
            this.txtUID.Size = new System.Drawing.Size(100, 20);
            this.txtUID.TabIndex = 1;
            // 
            // txtFieldCode
            // 
            this.txtFieldCode.Location = new System.Drawing.Point(105, 34);
            this.txtFieldCode.MaxLength = 50;
            this.txtFieldCode.Name = "txtFieldCode";
            this.txtFieldCode.Size = new System.Drawing.Size(152, 20);
            this.txtFieldCode.TabIndex = 3;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(105, 56);
            this.txtDescription.MaxLength = 50;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(171, 20);
            this.txtDescription.TabIndex = 7;
            // 
            // txtClientType
            // 
            this.txtClientType.Location = new System.Drawing.Point(105, 78);
            this.txtClientType.MaxLength = 10;
            this.txtClientType.Name = "txtClientType";
            this.txtClientType.Size = new System.Drawing.Size(171, 20);
            this.txtClientType.TabIndex = 10;
            this.txtClientType.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // txtClientUID
            // 
            this.txtClientUID.Location = new System.Drawing.Point(105, 100);
            this.txtClientUID.Name = "txtClientUID";
            this.txtClientUID.Size = new System.Drawing.Size(258, 20);
            this.txtClientUID.TabIndex = 12;
            // 
            // txtRecordType
            // 
            this.txtRecordType.Location = new System.Drawing.Point(263, 34);
            this.txtRecordType.MaxLength = 2;
            this.txtRecordType.Name = "txtRecordType";
            this.txtRecordType.Size = new System.Drawing.Size(100, 20);
            this.txtRecordType.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(263, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Record Type";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(266, 288);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 21);
            this.btnDelete.TabIndex = 23;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtCondition
            // 
            this.txtCondition.Location = new System.Drawing.Point(105, 148);
            this.txtCondition.MaxLength = 300;
            this.txtCondition.Multiline = true;
            this.txtCondition.Name = "txtCondition";
            this.txtCondition.Size = new System.Drawing.Size(258, 82);
            this.txtCondition.TabIndex = 16;
            // 
            // txtCompareWith
            // 
            this.txtCompareWith.Location = new System.Drawing.Point(105, 232);
            this.txtCompareWith.MaxLength = 100;
            this.txtCompareWith.Name = "txtCompareWith";
            this.txtCompareWith.Size = new System.Drawing.Size(258, 20);
            this.txtCompareWith.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(45, 148);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Condition:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(25, 235);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "Compare With:";
            // 
            // btnLocation
            // 
            this.btnLocation.Location = new System.Drawing.Point(24, 164);
            this.btnLocation.Name = "btnLocation";
            this.btnLocation.Size = new System.Drawing.Size(75, 23);
            this.btnLocation.TabIndex = 17;
            this.btnLocation.Text = "Location:";
            this.btnLocation.UseVisualStyleBackColor = true;
            this.btnLocation.Click += new System.EventHandler(this.btnLocation_Click);
            // 
            // cbxType
            // 
            this.cbxType.FormattingEnabled = true;
            this.cbxType.Items.AddRange(new object[] {
            "FIELD",
            "IMAGE",
            "VARIABLE"});
            this.cbxType.Location = new System.Drawing.Point(105, 123);
            this.cbxType.Name = "cbxType";
            this.cbxType.Size = new System.Drawing.Size(163, 21);
            this.cbxType.TabIndex = 14;
            this.cbxType.SelectedIndexChanged += new System.EventHandler(this.cbxType_SelectedIndexChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // checkEnabled
            // 
            this.checkEnabled.AutoSize = true;
            this.checkEnabled.Location = new System.Drawing.Point(105, 258);
            this.checkEnabled.Name = "checkEnabled";
            this.checkEnabled.Size = new System.Drawing.Size(65, 17);
            this.checkEnabled.TabIndex = 20;
            this.checkEnabled.Text = "Enabled";
            this.checkEnabled.UseVisualStyleBackColor = true;
            // 
            // checkUseLabel
            // 
            this.checkUseLabel.AutoSize = true;
            this.checkUseLabel.Location = new System.Drawing.Point(282, 60);
            this.checkUseLabel.Name = "checkUseLabel";
            this.checkUseLabel.Size = new System.Drawing.Size(88, 17);
            this.checkUseLabel.TabIndex = 8;
            this.checkUseLabel.Text = "Use as Label";
            this.checkUseLabel.UseVisualStyleBackColor = true;
            // 
            // UCReportMetadata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.checkUseLabel);
            this.Controls.Add(this.checkEnabled);
            this.Controls.Add(this.cbxType);
            this.Controls.Add(this.btnLocation);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCompareWith);
            this.Controls.Add(this.txtCondition);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtRecordType);
            this.Controls.Add(this.txtClientUID);
            this.Controls.Add(this.txtClientType);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtFieldCode);
            this.Controls.Add(this.txtUID);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UCReportMetadata";
            this.Size = new System.Drawing.Size(373, 312);
            this.Load += new System.EventHandler(this.UCReportMetadata_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtUID;
        private System.Windows.Forms.TextBox txtFieldCode;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtClientType;
        private System.Windows.Forms.TextBox txtClientUID;
        private System.Windows.Forms.TextBox txtRecordType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtCondition;
        private System.Windows.Forms.TextBox txtCompareWith;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnLocation;
        private System.Windows.Forms.ComboBox cbxType;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox checkEnabled;
        private System.Windows.Forms.CheckBox checkUseLabel;
    }
}
