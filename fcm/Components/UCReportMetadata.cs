using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FCMMySQLBusinessLibrary.FCMUtils;
using FCMMySQLBusinessLibrary.Model.ModelMetadata;
using MackkadoITFramework.ReferenceData;
using fcm.Windows;
using FCMMySQLBusinessLibrary;
using Utils = MackkadoITFramework.Helper.Utils;

namespace fcm.Components
{
    public partial class UCReportMetadata : UserControl
    {
        UIReportMetadata uiReportMetadata;
        private Form _callingFrom;
        public UCReportMetadata(Form callingFrom)
        {
            InitializeComponent();
            _callingFrom = callingFrom;
        }

        public UCReportMetadata()
        {
            InitializeComponent();
            _callingFrom = null;
        }


        public void SetUIReportInst(UIReportMetadata inst)
        {
            uiReportMetadata = inst;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {

            NewEntry(0);

        }
        public void NewEntry(int clientID)
        {
            ClearFields();

            // Generate new Unique ID
            txtUID.Text = (ReportMetadata.GetLastUID() + 1).ToString();
            txtClientUID.Text = clientID.ToString();
            
            txtRecordType.Text = "DF";
        
        }
       

        private void ClearFields()
        {
            
            txtRecordType.Text = "DF";
            txtFieldCode.Text = "";
            txtClientUID.Text = "";
            txtDescription.Text = "";
            cbxType.Text = "";
            txtCondition.Text = "";
            txtCompareWith.Text = "";

        }

        public void SetValues(ReportMetadata input)
        {
            txtUID.Text = input.UID.ToString();
            txtRecordType.Text = input.RecordType;
            txtFieldCode.Text = input.FieldCode;
            txtClientUID.Text = input.ClientUID.ToString();
            txtDescription.Text = input.Description;
            cbxType.Text = input.InformationType;
            txtCondition.Text = input.Condition;
            txtCompareWith.Text = input.CompareWith;
            checkEnabled.Checked = input.Enabled == 'Y' ? true : false;
            checkUseLabel.Checked = input.UseAsLabel == 'Y' ? true : false;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ReportMetadata rmd = new ReportMetadata();
            rmd.UID = Convert.ToInt32( txtUID.Text );
            rmd.RecordType = txtRecordType.Text;

            if (string.IsNullOrEmpty(txtClientUID.Text))
            {
                rmd.ClientUID = 0;
            }
            else
                rmd.ClientUID = Convert.ToInt32(txtClientUID.Text);

            rmd.ClientType = txtClientType.Text;
            rmd.Description = txtDescription.Text;
            rmd.InformationType = cbxType.Text;
            rmd.FieldCode = txtFieldCode.Text;
            rmd.Condition = txtCondition.Text;
            rmd.Condition = txtCondition.Text;
            rmd.CompareWith = txtCompareWith.Text;
            rmd.Enabled = checkEnabled.Checked ? 'Y' : 'N';
            rmd.UseAsLabel = checkUseLabel.Checked ? 'Y' : 'N';

            rmd.Save();

            MessageBox.Show("Code Type Save Successfully.");

            if (uiReportMetadata != null)
            {
                uiReportMetadata.Show();
            }

            this.Visible = false;


            if (_callingFrom != null && 
                _callingFrom.GetType().Name == "UIReportMetadata")
            {
                UIReportMetadata uirmd = (UIReportMetadata)_callingFrom;
                uirmd.refreshList();
            }

        }

        private void UCReportMetadata_Load(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            var conf = MessageBox.Show("Are you sure?", "Delete Item", MessageBoxButtons.YesNo);
            if (conf != DialogResult.Yes)
                return;
            
            ReportMetadata rmd = new ReportMetadata();
            rmd.UID = Convert.ToInt32(txtUID.Text);

            bool ret = rmd.Delete();

            if (ret)
            {
                MessageBox.Show("Item Deleted Successfully.");
            }
            else
            {
                MessageBox.Show("Deletion was unsuccessful.");
            }

            if (uiReportMetadata != null)
            {
                uiReportMetadata.loadMetadataList(rmd.UID);
            }

            this.Visible = false;

        }

        private void cbxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxType.Text == Utils.InformationType.IMAGE)
                btnLocation.Enabled = true;
            else
                btnLocation.Enabled = false;
        }

        private void btnLocation_Click(object sender, EventArgs e)
        {
            // Separate the file name from the path
            // Store both in separate fields
            //

            // Get template folder 
            var templateFolder =
                CodeValue.GetCodeValueExtended(FCMConstant.CodeTypeString.SYSTSET, FCMConstant.SYSFOLDER.TEMPLATEFOLDER);

            // Show file dialog
            var file = openFileDialog1.ShowDialog();

            if (file == DialogResult.OK)
            {
                // Only File Name
                string fileName = openFileDialog1.SafeFileName;
                // Full Path including file name
                string fullPathFileName = openFileDialog1.FileName;

                txtCondition.Text = fullPathFileName;
            }
        }

    }
}
