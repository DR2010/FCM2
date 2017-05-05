namespace fcm.Windows.Others
{
    partial class UISendEmail
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
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.btnShowEmail = new System.Windows.Forms.Button();
            this.txtHTMLPath = new System.Windows.Forms.TextBox();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAttachmentLocation = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtinlineAttachment = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnToGraham = new System.Windows.Forms.Button();
            this.btnToDaniel = new System.Windows.Forms.Button();
            this.btnSendGroupEmail = new System.Windows.Forms.Button();
            this.rbtClient = new System.Windows.Forms.RadioButton();
            this.rbtSponsor = new System.Windows.Forms.RadioButton();
            this.rbtPresenter = new System.Windows.Forms.RadioButton();
            this.rbtChampion = new System.Windows.Forms.RadioButton();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.txtEmailCount = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtTotalEmail = new System.Windows.Forms.TextBox();
            this.rbtCert1 = new System.Windows.Forms.RadioButton();
            this.rbtCert2 = new System.Windows.Forms.RadioButton();
            this.btnEmailCertificates = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(12, 125);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(611, 375);
            this.webBrowser1.TabIndex = 2;
            // 
            // btnShowEmail
            // 
            this.btnShowEmail.Location = new System.Drawing.Point(12, 40);
            this.btnShowEmail.Name = "btnShowEmail";
            this.btnShowEmail.Size = new System.Drawing.Size(96, 43);
            this.btnShowEmail.TabIndex = 3;
            this.btnShowEmail.Text = "Show Email";
            this.btnShowEmail.UseVisualStyleBackColor = true;
            this.btnShowEmail.Click += new System.EventHandler(this.btnShowEmail_Click);
            // 
            // txtHTMLPath
            // 
            this.txtHTMLPath.Location = new System.Drawing.Point(114, 40);
            this.txtHTMLPath.Name = "txtHTMLPath";
            this.txtHTMLPath.Size = new System.Drawing.Size(203, 20);
            this.txtHTMLPath.TabIndex = 4;
            // 
            // txtDestination
            // 
            this.txtDestination.Location = new System.Drawing.Point(545, 44);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(274, 20);
            this.txtDestination.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(519, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "To";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtAttachmentLocation
            // 
            this.txtAttachmentLocation.Location = new System.Drawing.Point(545, 70);
            this.txtAttachmentLocation.Name = "txtAttachmentLocation";
            this.txtAttachmentLocation.Size = new System.Drawing.Size(274, 20);
            this.txtAttachmentLocation.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(771, 489);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Qty";
            this.label2.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtinlineAttachment
            // 
            this.txtinlineAttachment.Location = new System.Drawing.Point(545, 96);
            this.txtinlineAttachment.Name = "txtinlineAttachment";
            this.txtinlineAttachment.Size = new System.Drawing.Size(274, 20);
            this.txtinlineAttachment.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(501, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "inline";
            this.label3.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnToGraham
            // 
            this.btnToGraham.Location = new System.Drawing.Point(367, 23);
            this.btnToGraham.Name = "btnToGraham";
            this.btnToGraham.Size = new System.Drawing.Size(107, 23);
            this.btnToGraham.TabIndex = 7;
            this.btnToGraham.Text = "to Graham >";
            this.btnToGraham.UseVisualStyleBackColor = true;
            this.btnToGraham.Click += new System.EventHandler(this.btnToGraham_Click);
            // 
            // btnToDaniel
            // 
            this.btnToDaniel.Location = new System.Drawing.Point(367, 52);
            this.btnToDaniel.Name = "btnToDaniel";
            this.btnToDaniel.Size = new System.Drawing.Size(107, 23);
            this.btnToDaniel.TabIndex = 7;
            this.btnToDaniel.Text = "to Daniel >";
            this.btnToDaniel.UseVisualStyleBackColor = true;
            this.btnToDaniel.Click += new System.EventHandler(this.btnToDaniel_Click);
            // 
            // btnSendGroupEmail
            // 
            this.btnSendGroupEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendGroupEmail.Location = new System.Drawing.Point(741, 451);
            this.btnSendGroupEmail.Name = "btnSendGroupEmail";
            this.btnSendGroupEmail.Size = new System.Drawing.Size(159, 35);
            this.btnSendGroupEmail.TabIndex = 8;
            this.btnSendGroupEmail.Text = "Email Group";
            this.btnSendGroupEmail.UseVisualStyleBackColor = true;
            this.btnSendGroupEmail.Click += new System.EventHandler(this.btnSendGroupEmail_Click);
            // 
            // rbtClient
            // 
            this.rbtClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbtClient.AutoSize = true;
            this.rbtClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtClient.Location = new System.Drawing.Point(104, 542);
            this.rbtClient.Name = "rbtClient";
            this.rbtClient.Size = new System.Drawing.Size(75, 28);
            this.rbtClient.TabIndex = 9;
            this.rbtClient.TabStop = true;
            this.rbtClient.Text = "Client";
            this.rbtClient.UseVisualStyleBackColor = true;
            this.rbtClient.CheckedChanged += new System.EventHandler(this.rbtClient_CheckedChanged);
            // 
            // rbtSponsor
            // 
            this.rbtSponsor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbtSponsor.AutoSize = true;
            this.rbtSponsor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtSponsor.Location = new System.Drawing.Point(286, 542);
            this.rbtSponsor.Name = "rbtSponsor";
            this.rbtSponsor.Size = new System.Drawing.Size(99, 28);
            this.rbtSponsor.TabIndex = 10;
            this.rbtSponsor.TabStop = true;
            this.rbtSponsor.Text = "Sponsor";
            this.rbtSponsor.UseVisualStyleBackColor = true;
            this.rbtSponsor.CheckedChanged += new System.EventHandler(this.rbtSponsor_CheckedChanged);
            // 
            // rbtPresenter
            // 
            this.rbtPresenter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbtPresenter.AutoSize = true;
            this.rbtPresenter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtPresenter.Location = new System.Drawing.Point(286, 581);
            this.rbtPresenter.Name = "rbtPresenter";
            this.rbtPresenter.Size = new System.Drawing.Size(109, 28);
            this.rbtPresenter.TabIndex = 11;
            this.rbtPresenter.TabStop = true;
            this.rbtPresenter.Text = "Presenter";
            this.rbtPresenter.UseVisualStyleBackColor = true;
            this.rbtPresenter.CheckedChanged += new System.EventHandler(this.rbtPresenter_CheckedChanged);
            // 
            // rbtChampion
            // 
            this.rbtChampion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbtChampion.AutoSize = true;
            this.rbtChampion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtChampion.Location = new System.Drawing.Point(104, 580);
            this.rbtChampion.Name = "rbtChampion";
            this.rbtChampion.Size = new System.Drawing.Size(114, 28);
            this.rbtChampion.TabIndex = 12;
            this.rbtChampion.TabStop = true;
            this.rbtChampion.Text = "Contractor";
            this.rbtChampion.UseVisualStyleBackColor = true;
            this.rbtChampion.CheckedChanged += new System.EventHandler(this.rbtChampion_CheckedChanged);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(629, 123);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(271, 277);
            this.listBox1.TabIndex = 13;
            // 
            // txtEmailCount
            // 
            this.txtEmailCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmailCount.Location = new System.Drawing.Point(800, 489);
            this.txtEmailCount.Name = "txtEmailCount";
            this.txtEmailCount.Size = new System.Drawing.Size(100, 20);
            this.txtEmailCount.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(825, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 35);
            this.button1.TabIndex = 5;
            this.button1.Text = "Send Email";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnSendEmail_Click);
            // 
            // txtTotalEmail
            // 
            this.txtTotalEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalEmail.Location = new System.Drawing.Point(800, 411);
            this.txtTotalEmail.Name = "txtTotalEmail";
            this.txtTotalEmail.Size = new System.Drawing.Size(100, 20);
            this.txtTotalEmail.TabIndex = 14;
            // 
            // rbtCert1
            // 
            this.rbtCert1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbtCert1.AutoSize = true;
            this.rbtCert1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtCert1.Location = new System.Drawing.Point(534, 542);
            this.rbtCert1.Name = "rbtCert1";
            this.rbtCert1.Size = new System.Drawing.Size(85, 33);
            this.rbtCert1.TabIndex = 15;
            this.rbtCert1.TabStop = true;
            this.rbtCert1.Text = "WSP";
            this.rbtCert1.UseVisualStyleBackColor = true;
            this.rbtCert1.CheckedChanged += new System.EventHandler(this.rbtCert1_CheckedChanged);
            // 
            // rbtCert2
            // 
            this.rbtCert2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbtCert2.AutoSize = true;
            this.rbtCert2.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtCert2.Location = new System.Drawing.Point(535, 591);
            this.rbtCert2.Name = "rbtCert2";
            this.rbtCert2.Size = new System.Drawing.Size(69, 33);
            this.rbtCert2.TabIndex = 15;
            this.rbtCert2.TabStop = true;
            this.rbtCert2.Text = "ISS";
            this.rbtCert2.UseVisualStyleBackColor = true;
            this.rbtCert2.CheckedChanged += new System.EventHandler(this.rbtCert2_CheckedChanged);
            // 
            // btnEmailCertificates
            // 
            this.btnEmailCertificates.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmailCertificates.Location = new System.Drawing.Point(677, 542);
            this.btnEmailCertificates.Name = "btnEmailCertificates";
            this.btnEmailCertificates.Size = new System.Drawing.Size(154, 73);
            this.btnEmailCertificates.TabIndex = 16;
            this.btnEmailCertificates.Text = "Email Certificates";
            this.btnEmailCertificates.UseVisualStyleBackColor = true;
            this.btnEmailCertificates.Click += new System.EventHandler(this.btnEmailCertificates_Click);
            // 
            // UISendEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 636);
            this.Controls.Add(this.btnEmailCertificates);
            this.Controls.Add(this.rbtCert2);
            this.Controls.Add(this.rbtCert1);
            this.Controls.Add(this.txtTotalEmail);
            this.Controls.Add(this.txtEmailCount);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.rbtChampion);
            this.Controls.Add(this.rbtPresenter);
            this.Controls.Add(this.rbtSponsor);
            this.Controls.Add(this.rbtClient);
            this.Controls.Add(this.btnSendGroupEmail);
            this.Controls.Add(this.btnToDaniel);
            this.Controls.Add(this.btnToGraham);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtinlineAttachment);
            this.Controls.Add(this.txtAttachmentLocation);
            this.Controls.Add(this.txtDestination);
            this.Controls.Add(this.txtHTMLPath);
            this.Controls.Add(this.btnShowEmail);
            this.Controls.Add(this.webBrowser1);
            this.Name = "UISendEmail";
            this.Text = "UISendEmail";
            this.Load += new System.EventHandler(this.UISendEmail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button btnShowEmail;
        private System.Windows.Forms.TextBox txtHTMLPath;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAttachmentLocation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtinlineAttachment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnToGraham;
        private System.Windows.Forms.Button btnToDaniel;
        private System.Windows.Forms.Button btnSendGroupEmail;
        private System.Windows.Forms.RadioButton rbtClient;
        private System.Windows.Forms.RadioButton rbtSponsor;
        private System.Windows.Forms.RadioButton rbtPresenter;
        private System.Windows.Forms.RadioButton rbtChampion;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox txtEmailCount;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtTotalEmail;
        private System.Windows.Forms.RadioButton rbtCert1;
        private System.Windows.Forms.RadioButton rbtCert2;
        private System.Windows.Forms.Button btnEmailCertificates;
    }
}