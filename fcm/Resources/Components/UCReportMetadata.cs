using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using fcm.Windows;

namespace fcm.Components
{
    public partial class UCReportMetadata : UserControl
    {
        UIReportMetadata uiReportMetadata;

        public UCReportMetadata()
        {
            InitializeComponent();
        }

        public void SetUIReportInst(UIReportMetadata inst)
        {
            uiReportMetadata = inst;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();

            // Generate new Unique ID
            txtUID.Text = (ReportMetadata.GetLastUID() + 1).ToString();

        }

        private void ClearFields()
        {
            
            txtRecordType.Text = "DF";
            txtFieldCode.Text = "";
            txtClientUID.Text = "";
            txtDescription.Text = "";
            txtInformationType.Text = "";
            txtTableName.Text = "";
            txtFieldName.Text = "";
            txtFilePath.Text = "";
            txtFileName.Text = "";
        }

        public void SetValues(ReportMetadata input)
        {
            txtUID.Text = input.UID.ToString();
            txtRecordType.Text = input.RecordType;
            txtFieldCode.Text = input.FieldCode;
            txtClientUID.Text = input.ClientUID.ToString();
            txtDescription.Text = input.Description;
            txtInformationType.Text = input.InformationType;
            txtTableName.Text = input.TableName;
            txtFieldName.Text = input.FieldName;
            txtFilePath.Text = input.FilePath;
            txtFileName.Text = input.FileName;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ReportMetadata rmd = new ReportMetadata();
            rmd.UID = Convert.ToInt32( txtUID.Text );
            rmd.RecordType = txtRecordType.Text;

            if (string.IsNullOrEmpty (txtClientUID.Text) )
                rmd.ClientUID = 0;
            else
                rmd.ClientUID = Convert.ToInt32(txtClientUID.Text );

            rmd.ClientType = txtClientType.Text;
            rmd.Description = txtDescription.Text;
            rmd.InformationType = txtInformationType.Text;
            rmd.FieldCode = txtFieldCode.Text;
            rmd.TableName = txtTableName.Text;
            rmd.FieldName = txtFieldName.Text;
            rmd.FilePath = txtFilePath.Text;
            rmd.FileName = txtFileName.Text;

            rmd.Save();

            MessageBox.Show("Code Type Save Successfully.");

            if (uiReportMetadata != null)
            {
                uiReportMetadata.loadMetadataList(rmd.UID);
            }

            this.Visible = false;
            
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

    }
}
