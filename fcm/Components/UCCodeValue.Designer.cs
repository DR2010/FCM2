namespace fcm.Components
{
    partial class UCCodeValue
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
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodeDescription = new System.Windows.Forms.TextBox();
            this.lblAbbreviation = new System.Windows.Forms.Label();
            this.txtAbbreviation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodeValueCode = new System.Windows.Forms.TextBox();
            this.cbxCodeType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtValueExtended = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSelectDestination = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point( 300, 143 );
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size( 60, 37 );
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler( this.btnSave_Click );
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 14, 18 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 65, 13 );
            this.label1.TabIndex = 0;
            this.label1.Text = "Code Type: ";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point( 14, 79 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 106, 19 );
            this.label2.TabIndex = 4;
            this.label2.Text = "Code Description: ";
            // 
            // txtCodeDescription
            // 
            this.txtCodeDescription.Location = new System.Drawing.Point( 124, 76 );
            this.txtCodeDescription.MaxLength = 50;
            this.txtCodeDescription.Multiline = true;
            this.txtCodeDescription.Name = "txtCodeDescription";
            this.txtCodeDescription.Size = new System.Drawing.Size( 236, 63 );
            this.txtCodeDescription.TabIndex = 5;
            // 
            // lblAbbreviation
            // 
            this.lblAbbreviation.AutoSize = true;
            this.lblAbbreviation.Location = new System.Drawing.Point( 14, 152 );
            this.lblAbbreviation.Name = "lblAbbreviation";
            this.lblAbbreviation.Size = new System.Drawing.Size( 72, 13 );
            this.lblAbbreviation.TabIndex = 6;
            this.lblAbbreviation.Text = "Abbreviation: ";
            // 
            // txtAbbreviation
            // 
            this.txtAbbreviation.Location = new System.Drawing.Point( 124, 150 );
            this.txtAbbreviation.MaxLength = 10;
            this.txtAbbreviation.Name = "txtAbbreviation";
            this.txtAbbreviation.Size = new System.Drawing.Size( 100, 20 );
            this.txtAbbreviation.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point( 14, 51 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 38, 13 );
            this.label4.TabIndex = 2;
            this.label4.Text = "Code: ";
            // 
            // txtCodeValueCode
            // 
            this.txtCodeValueCode.Location = new System.Drawing.Point( 124, 44 );
            this.txtCodeValueCode.MaxLength = 20;
            this.txtCodeValueCode.Name = "txtCodeValueCode";
            this.txtCodeValueCode.Size = new System.Drawing.Size( 236, 20 );
            this.txtCodeValueCode.TabIndex = 3;
            this.txtCodeValueCode.Leave += new System.EventHandler( this.txtCodeValueCode_Leave );
            // 
            // cbxCodeType
            // 
            this.cbxCodeType.FormattingEnabled = true;
            this.cbxCodeType.Location = new System.Drawing.Point( 124, 14 );
            this.cbxCodeType.Name = "cbxCodeType";
            this.cbxCodeType.Size = new System.Drawing.Size( 236, 21 );
            this.cbxCodeType.TabIndex = 1;
            this.cbxCodeType.SelectedIndexChanged += new System.EventHandler( this.cbxCodeType_SelectedIndexChanged );
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 14, 193 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 88, 13 );
            this.label3.TabIndex = 8;
            this.label3.Text = "Value Extended: ";
            // 
            // txtValueExtended
            // 
            this.txtValueExtended.Location = new System.Drawing.Point( 124, 186 );
            this.txtValueExtended.MaxLength = 200;
            this.txtValueExtended.Multiline = true;
            this.txtValueExtended.Name = "txtValueExtended";
            this.txtValueExtended.Size = new System.Drawing.Size( 236, 75 );
            this.txtValueExtended.TabIndex = 9;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point( 230, 142 );
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size( 64, 38 );
            this.btnNew.TabIndex = 11;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler( this.btnNew_Click );
            // 
            // btnSelectDestination
            // 
            this.btnSelectDestination.Location = new System.Drawing.Point( 95, 240 );
            this.btnSelectDestination.Name = "btnSelectDestination";
            this.btnSelectDestination.Size = new System.Drawing.Size( 25, 21 );
            this.btnSelectDestination.TabIndex = 12;
            this.btnSelectDestination.Text = "...";
            this.btnSelectDestination.UseVisualStyleBackColor = true;
            this.btnSelectDestination.Click += new System.EventHandler( this.btnSelectDestination_Click );
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // UCCodeValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))) );
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add( this.btnSelectDestination );
            this.Controls.Add( this.btnNew );
            this.Controls.Add( this.txtValueExtended );
            this.Controls.Add( this.label3 );
            this.Controls.Add( this.cbxCodeType );
            this.Controls.Add( this.txtCodeValueCode );
            this.Controls.Add( this.label4 );
            this.Controls.Add( this.txtAbbreviation );
            this.Controls.Add( this.lblAbbreviation );
            this.Controls.Add( this.txtCodeDescription );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.label1 );
            this.Controls.Add( this.btnSave );
            this.Name = "UCCodeValue";
            this.Size = new System.Drawing.Size( 374, 273 );
            this.Load += new System.EventHandler( this.UCCodeValue_Load );
            this.Enter += new System.EventHandler( this.UCCodeValue_Enter );
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodeDescription;
        private System.Windows.Forms.Label lblAbbreviation;
        private System.Windows.Forms.TextBox txtAbbreviation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCodeValueCode;
        private System.Windows.Forms.ComboBox cbxCodeType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtValueExtended;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSelectDestination;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}
