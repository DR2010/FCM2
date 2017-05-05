using MackkadoITFramework.ProcessRequest;

namespace fcm.Windows
{
    partial class UIProcessRequest
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvRequests = new System.Windows.Forms.DataGridView();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.Results = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.fKRequestUIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fKClientUIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sequenceNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsProcessRequestResults = new System.Windows.Forms.BindingSource(this.components);
            this.dgvUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvFKClientUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvWhenToProcess = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvRequestedByUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCreationDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvStatusDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPlannedDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsProcessRequest = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsProcessRequestResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProcessRequest)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRequests
            // 
            this.dgvRequests.AllowUserToAddRows = false;
            this.dgvRequests.AllowUserToDeleteRows = false;
            this.dgvRequests.AllowUserToOrderColumns = true;
            this.dgvRequests.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRequests.AutoGenerateColumns = false;
            this.dgvRequests.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRequests.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRequests.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvUID,
            this.dgvDescription,
            this.dgvFKClientUID,
            this.dgvType,
            this.dgvStatus,
            this.dgvWhenToProcess,
            this.dgvRequestedByUser,
            this.dgvCreationDateTime,
            this.dgvStatusDateTime,
            this.dgvPlannedDateTime});
            this.dgvRequests.DataSource = this.bsProcessRequest;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRequests.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRequests.Location = new System.Drawing.Point(12, 52);
            this.dgvRequests.Name = "dgvRequests";
            this.dgvRequests.ReadOnly = true;
            this.dgvRequests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRequests.Size = new System.Drawing.Size(948, 134);
            this.dgvRequests.TabIndex = 0;
            this.dgvRequests.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dgvRequests.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRequests_CellContentDoubleClick);
            this.dgvRequests.SelectionChanged += new System.EventHandler(this.dgvRequests_SelectionChanged);
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResults.AutoGenerateColumns = false;
            this.dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fKRequestUIDDataGridViewTextBoxColumn,
            this.Results,
            this.fKClientUIDDataGridViewTextBoxColumn1,
            this.sequenceNumberDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn1});
            this.dgvResults.DataSource = this.bsProcessRequestResults;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvResults.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvResults.Location = new System.Drawing.Point(12, 221);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.Size = new System.Drawing.Size(948, 282);
            this.dgvResults.TabIndex = 1;
            // 
            // Results
            // 
            this.Results.DataPropertyName = "Results";
            this.Results.HeaderText = "Results";
            this.Results.Name = "Results";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(12, 192);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(971, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(971, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::fcm.Properties.Resources.ImageExit;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "tsbtnExit";
            this.toolStripButton1.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // fKRequestUIDDataGridViewTextBoxColumn
            // 
            this.fKRequestUIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.fKRequestUIDDataGridViewTextBoxColumn.DataPropertyName = "FKRequestUID";
            this.fKRequestUIDDataGridViewTextBoxColumn.HeaderText = "FKRequestUID";
            this.fKRequestUIDDataGridViewTextBoxColumn.Name = "fKRequestUIDDataGridViewTextBoxColumn";
            this.fKRequestUIDDataGridViewTextBoxColumn.Width = 104;
            // 
            // fKClientUIDDataGridViewTextBoxColumn1
            // 
            this.fKClientUIDDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.fKClientUIDDataGridViewTextBoxColumn1.DataPropertyName = "FKClientUID";
            this.fKClientUIDDataGridViewTextBoxColumn1.HeaderText = "FKClientUID";
            this.fKClientUIDDataGridViewTextBoxColumn1.Name = "fKClientUIDDataGridViewTextBoxColumn1";
            this.fKClientUIDDataGridViewTextBoxColumn1.Width = 90;
            // 
            // sequenceNumberDataGridViewTextBoxColumn
            // 
            this.sequenceNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.sequenceNumberDataGridViewTextBoxColumn.DataPropertyName = "SequenceNumber";
            this.sequenceNumberDataGridViewTextBoxColumn.HeaderText = "SequenceNumber";
            this.sequenceNumberDataGridViewTextBoxColumn.Name = "sequenceNumberDataGridViewTextBoxColumn";
            this.sequenceNumberDataGridViewTextBoxColumn.Width = 5;
            // 
            // typeDataGridViewTextBoxColumn1
            // 
            this.typeDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.typeDataGridViewTextBoxColumn1.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn1.HeaderText = "Type";
            this.typeDataGridViewTextBoxColumn1.Name = "typeDataGridViewTextBoxColumn1";
            this.typeDataGridViewTextBoxColumn1.Width = 5;
            // 
            // bsProcessRequestResults
            // 
            this.bsProcessRequestResults.DataSource = typeof(MackkadoITFramework.ProcessRequest.ProcessRequestResults);
            // 
            // dgvUID
            // 
            this.dgvUID.DataPropertyName = "UID";
            this.dgvUID.HeaderText = "UID";
            this.dgvUID.Name = "dgvUID";
            this.dgvUID.ReadOnly = true;
            // 
            // dgvDescription
            // 
            this.dgvDescription.DataPropertyName = "Description";
            this.dgvDescription.HeaderText = "Description";
            this.dgvDescription.Name = "dgvDescription";
            this.dgvDescription.ReadOnly = true;
            // 
            // dgvFKClientUID
            // 
            this.dgvFKClientUID.DataPropertyName = "FKClientUID";
            this.dgvFKClientUID.HeaderText = "FKClientUID";
            this.dgvFKClientUID.Name = "dgvFKClientUID";
            this.dgvFKClientUID.ReadOnly = true;
            // 
            // dgvType
            // 
            this.dgvType.DataPropertyName = "Type";
            this.dgvType.HeaderText = "Type";
            this.dgvType.Name = "dgvType";
            this.dgvType.ReadOnly = true;
            // 
            // dgvStatus
            // 
            this.dgvStatus.DataPropertyName = "Status";
            this.dgvStatus.HeaderText = "Status";
            this.dgvStatus.Name = "dgvStatus";
            this.dgvStatus.ReadOnly = true;
            // 
            // dgvWhenToProcess
            // 
            this.dgvWhenToProcess.DataPropertyName = "WhenToProcess";
            this.dgvWhenToProcess.HeaderText = "WhenToProcess";
            this.dgvWhenToProcess.Name = "dgvWhenToProcess";
            this.dgvWhenToProcess.ReadOnly = true;
            // 
            // dgvRequestedByUser
            // 
            this.dgvRequestedByUser.DataPropertyName = "RequestedByUser";
            this.dgvRequestedByUser.HeaderText = "RequestedByUser";
            this.dgvRequestedByUser.Name = "dgvRequestedByUser";
            this.dgvRequestedByUser.ReadOnly = true;
            // 
            // dgvCreationDateTime
            // 
            this.dgvCreationDateTime.DataPropertyName = "CreationDateTime";
            this.dgvCreationDateTime.HeaderText = "CreationDateTime";
            this.dgvCreationDateTime.Name = "dgvCreationDateTime";
            this.dgvCreationDateTime.ReadOnly = true;
            // 
            // dgvStatusDateTime
            // 
            this.dgvStatusDateTime.DataPropertyName = "StatusDateTime";
            this.dgvStatusDateTime.HeaderText = "StatusDateTime";
            this.dgvStatusDateTime.Name = "dgvStatusDateTime";
            this.dgvStatusDateTime.ReadOnly = true;
            // 
            // dgvPlannedDateTime
            // 
            this.dgvPlannedDateTime.DataPropertyName = "PlannedDateTime";
            this.dgvPlannedDateTime.HeaderText = "PlannedDateTime";
            this.dgvPlannedDateTime.Name = "dgvPlannedDateTime";
            this.dgvPlannedDateTime.ReadOnly = true;
            // 
            // bsProcessRequest
            // 
            this.bsProcessRequest.DataSource = typeof(MackkadoITFramework.ProcessRequest.ProcessRequest);
            // 
            // UIProcessRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 515);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.dgvRequests);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "UIProcessRequest";
            this.Text = "Process Requests";
            this.Load += new System.EventHandler(this.UIProcessRequest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsProcessRequestResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProcessRequest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRequests;
        private System.Windows.Forms.BindingSource bsProcessRequest;
        private System.Windows.Forms.BindingSource bsProcessRequestResults;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn longTextDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvUID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvFKClientUID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvWhenToProcess;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvRequestedByUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCreationDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvStatusDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPlannedDateTime;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn fKRequestUIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Results;
        private System.Windows.Forms.DataGridViewTextBoxColumn fKClientUIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sequenceNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}