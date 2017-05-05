using MackkadoITFramework.ReferenceData;
using FCMMySQLBusinessLibrary.Model.ModelClient;

namespace fcm.Components
{
    partial class UCClientOtherInfo
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.codeValueBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.clientOtherInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvFieldName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.fieldValueTextDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fKClientUIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rCFieldCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeValueBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientOtherInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvFieldName,
            this.fieldValueTextDataGridViewTextBoxColumn,
            this.uIDDataGridViewTextBoxColumn,
            this.fKClientUIDDataGridViewTextBoxColumn,
            this.rCFieldCodeDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.clientOtherInfoBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(362, 168);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            // 
            // codeValueBindingSource
            // 
            this.codeValueBindingSource.DataSource = typeof(CodeValue);
            // 
            // clientOtherInfoBindingSource
            // 
            this.clientOtherInfoBindingSource.DataSource = typeof(ClientOtherInfo);
            // 
            // dgvFieldName
            // 
            this.dgvFieldName.DataSource = this.codeValueBindingSource;
            this.dgvFieldName.DisplayMember = "Description";
            this.dgvFieldName.HeaderText = "Field Name";
            this.dgvFieldName.Name = "dgvFieldName";
            // 
            // fieldValueTextDataGridViewTextBoxColumn
            // 
            this.fieldValueTextDataGridViewTextBoxColumn.DataPropertyName = "dgvFieldValueText";
            this.fieldValueTextDataGridViewTextBoxColumn.HeaderText = "Value";
            this.fieldValueTextDataGridViewTextBoxColumn.Name = "fieldValueTextDataGridViewTextBoxColumn";
            this.fieldValueTextDataGridViewTextBoxColumn.Width = 200;
            // 
            // uIDDataGridViewTextBoxColumn
            // 
            this.uIDDataGridViewTextBoxColumn.DataPropertyName = "dgvUID";
            this.uIDDataGridViewTextBoxColumn.HeaderText = "UID";
            this.uIDDataGridViewTextBoxColumn.Name = "uIDDataGridViewTextBoxColumn";
            this.uIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fKClientUIDDataGridViewTextBoxColumn
            // 
            this.fKClientUIDDataGridViewTextBoxColumn.DataPropertyName = "dgvFKClientUID";
            this.fKClientUIDDataGridViewTextBoxColumn.HeaderText = "Client UID";
            this.fKClientUIDDataGridViewTextBoxColumn.Name = "fKClientUIDDataGridViewTextBoxColumn";
            this.fKClientUIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rCFieldCodeDataGridViewTextBoxColumn
            // 
            this.rCFieldCodeDataGridViewTextBoxColumn.DataPropertyName = "dgvRCFieldCode";
            this.rCFieldCodeDataGridViewTextBoxColumn.HeaderText = "Field";
            this.rCFieldCodeDataGridViewTextBoxColumn.Name = "rCFieldCodeDataGridViewTextBoxColumn";
            this.rCFieldCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // UCClientOtherInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Name = "UCClientOtherInfo";
            this.Size = new System.Drawing.Size(362, 168);
            this.Load += new System.EventHandler(this.UCClientOtherInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeValueBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientOtherInfoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource clientOtherInfoBindingSource;
        private System.Windows.Forms.BindingSource codeValueBindingSource;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvFieldName;
        private System.Windows.Forms.DataGridViewTextBoxColumn fieldValueTextDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fKClientUIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rCFieldCodeDataGridViewTextBoxColumn;
    }
}
