using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using FCMMySQLBusinessLibrary;
using FCMMySQLBusinessLibrary.Model.ModelClientDocument;
using FCMMySQLBusinessLibrary.Repository.RepositoryClientDocument;
using FCMMySQLBusinessLibrary.Service.SVCClient.Service;
using FCMMySQLBusinessLibrary.Service.SVCClientDocument.Service;
using MackkadoITFramework.APIDocument;
using FCMMySQLBusinessLibrary.FCMUtils;
using MackkadoITFramework.ReferenceData;

namespace fcm.Windows
{
    public partial class UIClientDocumentEdit : Form
    {
        public UIClientDocumentEdit()
        {
            InitializeComponent();
        }

        public UIClientDocumentEdit(ClientDocument clientDocument) : this()
        {
            txtUID.Text = clientDocument.UID.ToString();
            txtClientID.Text = clientDocument.FKClientUID.ToString();
            txtClientDocumentSetID.Text = clientDocument.FKClientDocumentSetUID.ToString();
            txtDocumentID.Text = clientDocument.FKDocumentUID.ToString();
            txtIssueNumber.Text = clientDocument.SourceIssueNumber.ToString();
            txtSourceLocation.Text = clientDocument.SourceLocation;
            txtSourceFileName.Text = clientDocument.SourceFileName;
            // Destination Location
            txtLocation.Text = clientDocument.Location;
            txtFileName.Text = clientDocument.FileName;
            txtSequenceNumber.Text = clientDocument.SequenceNumber.ToString();
            txtClientDocumentVersionNumber.Text = clientDocument.ClientIssueNumber.ToString();
            txtSourceDocumentVersionNumber.Text = clientDocument.SourceIssueNumber.ToString();

            cbxIsProjectPlan.Checked = clientDocument.IsProjectPlan == "Y" ? true : false;
            cbxIsGenerated.Checked = clientDocument.Generated == 'Y' ? true : false;
            cbxIsRoot.Checked = clientDocument.IsRoot == 'Y' ? true : false;
            cbxIsFolder.Checked = clientDocument.IsFolder == 'Y' ? true : false;
            cbxIsVoid.Checked = clientDocument.IsVoid == 'Y' ? true : false;

            txtStatus.Text = "Not used";
            txtParentUID.Text = clientDocument.ParentUID.ToString();
            txtRecordType.Text = clientDocument.RecordType;
            txtDocumentType.Text = clientDocument.DocumentType;
            txtDocumentCUID.Text = clientDocument.DocumentCUID;

            if (!cbxIsGenerated.Checked)
                btnEdit.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Save details
            ClientDocument clientDocument = new ClientDocument();
            clientDocument.UID = Convert.ToInt32(txtUID.Text);
            clientDocument.FKClientDocumentSetUID = Convert.ToInt32(txtClientDocumentSetID.Text);
            clientDocument.FKDocumentUID = Convert.ToInt32(txtDocumentID.Text);
            clientDocument.FKClientUID = Convert.ToInt32(txtClientID.Text);
            clientDocument.SourceLocation = txtSourceLocation.Text;
            clientDocument.SourceFileName = txtSourceFileName.Text;
            clientDocument.Location = txtLocation.Text;
            clientDocument.FileName = txtFileName.Text;
            if (!string.IsNullOrEmpty(txtSequenceNumber.Text))
            {
                clientDocument.SequenceNumber = Convert.ToInt32(txtSequenceNumber.Text);
            }
            else
            {
                clientDocument.SequenceNumber = 0;
            }

            // clientDocument.Update();

            BUSClientDocument.ClientDocumentUpdate( clientDocument );

            MessageBox.Show("Client document updated successfully.");

            this.Close();
        }

        private void btnSourceLocation_Click(object sender, EventArgs e)
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

                // Extract File Path
                string pathOnly = fullPathFileName.Replace(fileName, "");

                txtSourceFileName.Text = fileName;
                txtSourceLocation.Text = pathOnly;

                // Get reference path
                //
                string refPath =
                    Utils.getReferenceFilePathName(txtSourceLocation.Text);
                txtSourceLocation.Text = refPath;

                // If the source folder includes %TEMPLATEFOLDER%
                // keep the normal rules
                // otherwise, reset the path to %CLIENTFOLDER%\Unique
                // make file name the same
                if (txtSourceLocation.Text.Contains(FCMConstant.SYSFOLDER.TEMPLATEFOLDER))
                {
                    txtLocation.Text = Utils.getOppositePath(txtSourceLocation.Text);
                    txtFileName.Text = txtSourceFileName.Text;
                }
                else
                {
                    txtLocation.Text = FCMConstant.SYSFOLDER.CLIENTFOLDER;
                    txtFileName.Text = txtSourceFileName.Text;
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string filePathName =
                   Utils.getFilePathName(txtLocation.Text,
                                         txtFileName.Text);
            if (!File.Exists(filePathName))
            {
                MessageBox.Show("Document not generated. " + filePathName);
                return;
            }

            WordDocumentTasks.OpenDocument(filePathName, vkReadOnly: false);
        }

        private void UIClientDocumentEdit_Load(object sender, EventArgs e)
        {

        }
    }
}
