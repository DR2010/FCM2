using System;
using System.Windows.Forms;
using FCMMySQLBusinessLibrary.FCMUtils;
using FCMMySQLBusinessLibrary.Model.ModelDocument;
using FCMMySQLBusinessLibrary.Service.SVCClientDocument.Service;
using FCMMySQLBusinessLibrary.Service.SVCDocument.Service;
using FCMMySQLBusinessLibrary.Service.SVCDocument.ServiceContract;
using MackkadoITFramework.ReferenceData;
using MackkadoITFramework.Utils;
using MKITHelper = MackkadoITFramework.Helper;
using Utils = FCMMySQLBusinessLibrary.FCMUtils.Utils;

namespace fcm.Windows
{
    public partial class UIDocumentEdit : Form
    {
        private UIDocumentList uidl;
        private Document docSave;
        public bool documentSavedSuccessfully;
        TreeNode treeNode;
        private string _fileName;
        private string _fullPathFileName;
        private int _clientUID;
        private Form _previousForm;


        public UIDocumentEdit(Form previousForm)
        {
            InitializeComponent();
            docSave = new Document();

            // Load record type
            //
            cbxRecordType.Items.Add(FCMConstant.RecordType.DOCUMENT);
            cbxRecordType.Items.Add(FCMConstant.RecordType.APPENDIX);
            cbxRecordType.Items.Add(FCMConstant.RecordType.FOLDER);

            cbxRecordType.Text = FCMConstant.RecordType.DOCUMENT;


            // Load document type
            //
            cbxDocumentType.Items.Add(MackkadoITFramework.Helper.Utils.DocumentType.WORD);
            cbxDocumentType.Items.Add(MackkadoITFramework.Helper.Utils.DocumentType.EXCEL);
            cbxDocumentType.Items.Add(MackkadoITFramework.Helper.Utils.DocumentType.PDF);
            cbxDocumentType.Items.Add(MackkadoITFramework.Helper.Utils.DocumentType.FOLDER);
            cbxDocumentType.Items.Add(MackkadoITFramework.Helper.Utils.DocumentType.UNDEFINED);

            cbxDocumentType.Text = MackkadoITFramework.Helper.Utils.DocumentType.UNDEFINED;

            cbxSourceCode.Enabled = false;
            
        }

        /// <summary>
        /// Constructor to allow document to be saved to client.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="fullPathFileName"></param>
        public UIDocumentEdit(
            Form previousForm,
            string fileName, 
            string fullPathFileName, 
            int clientUID
            )
            : this(previousForm)
        {
            _fileName = fileName;
            _fullPathFileName = fullPathFileName;
            _clientUID = clientUID;

        }

        public UIDocumentEdit(
            Form previousForm,
            UIDocumentList _uidl 
            )
            : this(previousForm)
        {
            InitializeComponent();
            uidl = new UIDocumentList();
            uidl = _uidl;

            txtCUID.Enabled = false;
            txtCUID.ReadOnly = true;
            // txtDirectory.Focus();

        }

        public UIDocumentEdit(
            Form previousForm,
            Document document, 
            TreeNode tn 
            )
            : this(previousForm)
        {
            
            docSave = document;

            SetValues(document);

            if (document.UID == 0)
            {
                // New document
                New();
            }

            documentSavedSuccessfully = false;
            treeNode = new TreeNode();
            treeNode = tn;

            docSave = document;

        }

        public UIDocumentEdit(Form previousForm, int clientUID)
            : this(previousForm)
        {
            cbxSourceCode.Text = FCMConstant.SourceCode.CLIENT;
            cbxSourceCode.Enabled = false;
            txtClientUID.Text = clientUID.ToString();
            btnClient.Enabled = false;
            btnNewIssue.Enabled = false;
            txtIssueNumber.Text = "001";
            txtSeqNum.Text = "001";
//            int nextClientDocument = ClientDocument.GetLastClientCUID( clientUID ) + 1;
           
            int nextClientDocument = BUSClientDocument.GetLastClientCUID( clientUID ) + 1;

            // The full name can only be added when the document is assigned to the client.
            //
            // txtCUID.Text = "CLI-" + nextClientDocument.ToString( "00" ) +"-00-" + clientUID.ToString( "0000" ) + "-01";
            txtCUID.Text = "CLI-" + nextClientDocument.ToString( "00" ); // +"-00-" + clientUID.ToString( "0000" ) + "-01";

        }

        private void UIDocumentEdit_Load(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(_fileName))
            {
                txtClientUID.Text = _clientUID.ToString();
            }

            //
            // Enable or disable fields accordingly
            //
            if (string.IsNullOrEmpty(txtClientUID.Text))
            {
                btnNewIssue.Enabled = false;
                txtIssueNumber.Enabled = true;
                txtCUID.Enabled = true;
                txtCUID.ReadOnly = false;
                cbxSourceCode.SelectedIndex = 0;
                cbxSourceCode.Text = FCMConstant.SourceCode.FCM;

                txtSeqNum.Text = "1";

                tsSave.Enabled = false;
            }
            else
            {
                btnNewIssue.Enabled = true;
                txtIssueNumber.Enabled = false;
                txtCUID.Enabled = true;
            }


            if (!string.IsNullOrEmpty(_fileName))
            {
                FileSelected(_fileName, _fullPathFileName);

                enableSave(null, null);
            }
        }

        // Set directory and description
        //
        public void SetDirectory(string _directory, string _directoryDescription)
        {
            //txtDirectory.Text = _directory;
            //txtDirectoryDescription.Text = _directoryDescription;
            return;
        }

        // Set sub directory and description
        //
        public void SetSubDirectory(string _subdirectory, string _subdirectoryDescription)
        {
            //txtSubDirectory.Text = _subdirectory;
            //txtSubDirectoryDescription.Text = _subdirectoryDescription;
            return;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            New();
        }

        //
        // Clear fields
        //
        private void New()
        {
            txtUID.Text = "";
            txtSimpleFileName.Text = "";
            txtCUID.Text = "";
            txtLocation.Text = "";
            txtIssueNumber.Text = "";
            txtName.Text = "";
            txtSeqNum.Text = "";
            //txtDirectory.Text = "";
            //txtSubDirectory.Text = "";
            txtComments.Text = "";
            //txtDirectoryDescription.Text = "";
            //txtSubDirectoryDescription.Text = "";
            txtFileName.Text = "";
            // txtClientUID.Text = "";

            //cbxSourceCode.SelectedText = FCMConstant.SourceCode.FCM;
            //cbxSourceCode.SelectedIndex = 0;

            cbxRecordType.Text = FCMConstant.RecordType.DOCUMENT;
            cbxDocumentType.Text = MackkadoITFramework.Helper.Utils.DocumentType.UNDEFINED;

            txtIssueNumber.Enabled = true;
            txtIssueNumber.ReadOnly = false;

            txtCUID.Enabled = true;
            txtCUID.ReadOnly = false;
            txtCUID.Focus();
        }

        public void SetValues(Document inDoco)
        {
            txtUID.Text = inDoco.UID.ToString();
            txtCUID.Text = inDoco.CUID;
            txtLocation.Text = inDoco.Location;
            txtIssueNumber.Text = inDoco.IssueNumber.ToString();
            txtName.Text = inDoco.Name;
            txtDisplayName.Text = inDoco.DisplayName;
            txtSeqNum.Text = inDoco.SequenceNumber.ToString();
            txtComments.Text = inDoco.Comments;
            txtFileName.Text = inDoco.FileName;
            txtSimpleFileName.Text = inDoco.SimpleFileName;
            cbxSourceCode.Text = inDoco.SourceCode;
            txtClientUID.Text = inDoco.FKClientUID.ToString();
            txtParentUID.Text = inDoco.ParentUID.ToString();
            cbxRecordType.Text = inDoco.RecordType;
            cbxDocumentType.Text = inDoco.DocumentType;
            checkProjectPlan.Checked = false;
            if (inDoco.IsProjectPlan == "Y")
                checkProjectPlan.Checked = true;

        }


        private void btnSave_Click( object sender, EventArgs e )
        {
            //Document docSave = new Document();

            if (string.IsNullOrEmpty( cbxSourceCode.Text ))
            {
                MessageBox.Show( "Source code must be set." );
                return;
            }

            if (string.IsNullOrEmpty( cbxDocumentType.Text ))
            {
                MessageBox.Show( "Document Type must be set." );
                return;
            }



            if (string.IsNullOrEmpty( txtUID.Text ))
                docSave.UID = 0;
            else
                docSave.UID = Convert.ToInt32( txtUID.Text );

            if (checkProjectPlan.Checked)
                docSave.IsProjectPlan = "N";
            else
                docSave.IsProjectPlan = "N";

            docSave.CUID = txtCUID.Text;
            docSave.Comments = txtComments.Text;
            docSave.Location = txtLocation.Text;
            docSave.Status = "ACTIVE";

            if (string.IsNullOrEmpty(txtIssueNumber.Text))
                docSave.IssueNumber = 0;
            else
                docSave.IssueNumber = Convert.ToInt32(txtIssueNumber.Text);
            docSave.Name = txtName.Text;
            docSave.DisplayName = txtDisplayName.Text;
            docSave.RecordType = cbxRecordType.Text;
            docSave.SimpleFileName = txtSimpleFileName.Text;

            if (cbxRecordType.Text == FCMConstant.RecordType.FOLDER)
                cbxDocumentType.Text = MackkadoITFramework.Helper.Utils.DocumentType.FOLDER;

            docSave.DocumentType = cbxDocumentType.Text;

            if (string.IsNullOrEmpty( cbxRecordType.Text ))
            {
                MessageBox.Show( "Record Type is mandatory." );
                return;
            }
            if (string.IsNullOrEmpty( cbxDocumentType.Text ))
            {
                MessageBox.Show( "Document Type is mandatory." );
                return;
            }


            // Parent UID is sourced from document tree
            //
            if (string.IsNullOrEmpty( txtParentUID.Text ))
                docSave.ParentUID = 0;
            else
                docSave.ParentUID = Convert.ToInt32( txtParentUID.Text );

            if (string.IsNullOrEmpty( txtSeqNum.Text ))
                docSave.SequenceNumber = 0;
            else
                docSave.SequenceNumber = Convert.ToInt32( txtSeqNum.Text );

            docSave.Comments = txtComments.Text;
            docSave.FileName = txtFileName.Text;

            docSave.FileExtension = MKITHelper.Utils.GetFileExtensionString( txtFileName.Text );
                
            docSave.SourceCode = cbxSourceCode.Text;

            if (string.IsNullOrEmpty( txtClientUID.Text ))
                docSave.FKClientUID = 0;
            else
                docSave.FKClientUID = Convert.ToInt32( txtClientUID.Text );

            if (docSave.SourceCode == "CLIENT" && docSave.FKClientUID == 0)
            {
                MessageBox.Show( "Client ID is mandatory if source type is CLIENT" );
                return;
            }

            // docSave.Save(HeaderInfo.Instance, FCMConstant.SaveType.UPDATE);

            // RepDocument.Save(HeaderInfo.Instance, docSave, FCMConstant.SaveType.UPDATE);

            var documentSaveRequest = new DocumentSaveRequest();
            documentSaveRequest.inDocument = docSave;
            documentSaveRequest.headerInfo = HeaderInfo.Instance;
            documentSaveRequest.saveType = FCMConstant.SaveType.UPDATE;

            var resp = BUSDocument.DocumentSave(documentSaveRequest);
            docSave.UID = resp.document.UID;

            if (uidl != null)
                uidl.Refresh();

            txtLocation.Text = resp.document.Location;


            MessageBox.Show( resp.response.Message);

            txtCUID.Enabled = false;
            txtCUID.ReadOnly = true;
            //txtDirectory.Focus();

            documentSavedSuccessfully = true;

            if (treeNode == null)
            {
                // There is no need to set the treenode unless it is passed in.
            }
            else
            {
                treeNode.Tag = docSave;
                treeNode.Name = docSave.FileName;
            }

        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            // Separate the file name from the path
            // Store both in separate fields
            //

            // Get template folder 
            var templateFolder =
                CodeValue.GetCodeValueExtended(FCMConstant.CodeTypeString.SYSTSET, FCMConstant.SYSFOLDER.TEMPLATEFOLDER);

            // Show file dialog
            openFileDialog1.InitialDirectory = templateFolder;
            openFileDialog1.Filter = "*.doc|*.xls|*.xlsx|*.docx";
            openFileDialog1.FileName = "*";

            var file = openFileDialog1.ShowDialog();

            if (file == DialogResult.OK)
            {
                // Only File Name
                string fileName = openFileDialog1.SafeFileName;
                // Full Path including file name
                string fullPathFileName = openFileDialog1.FileName;

                // Extract File Path
                string pathOnly = fullPathFileName.Replace(fileName, "");

                txtFileName.Text = fileName;
                txtLocation.Text = pathOnly;

                string pathPartToCheck = "";

                if (pathOnly.Length >= templateFolder.Length)
                    pathPartToCheck = pathOnly.Substring(0, templateFolder.Length);
                else
                    pathPartToCheck = pathOnly;

                if (pathPartToCheck != templateFolder)
                {
                    txtFileName.Text = "";
                    txtLocation.Text = "";

                    MessageBox.Show("Please select file from allowed folder. " + templateFolder);
                    return;
                }

                // Get reference path
                //
                string refPath =
                    Utils.getReferenceFilePathName(txtLocation.Text);
                txtLocation.Text = refPath;

                // This is the name of the document and not the file name
                // If it is already set for the client, there is no need
                // to replace it. The idea here is to suggest a name only
                // when the document is being created.
                //
                if (string.IsNullOrEmpty(txtName.Text))
                {
                    txtName.Text = openFileDialog1.SafeFileName.Substring(0,
                                   openFileDialog1.SafeFileName.Length - 4);
                }

                txtFileName.Text = openFileDialog1.SafeFileName;

                // 03.04.2013
                // CLA-00-00
                txtDisplayName.Text = txtFileName.Text;
                txtCUID.Text = txtFileName.Text.Substring(0, 6);
                cbxDocumentType.Text = "WORD";
                cbxRecordType.Text = FCMConstant.RecordType.DOCUMENT;

                if ( txtFileName.Text.Length >= 10 )
                {
                    txtSimpleFileName.Text = txtFileName.Text.Substring(10, txtFileName.Text.Length - 10);
                }

                enableSave(sender, e);

            }

        }


        /// <summary>
        /// Get file details from file name
        /// </summary>
        private void FileSelected(string fileName, string fullPathFileName)
        {
            // Get template folder 
            var templateFolder =
                CodeValue.GetCodeValueExtended(FCMConstant.CodeTypeString.SYSTSET, FCMConstant.SYSFOLDER.TEMPLATEFOLDER);

            // Extract File Path
            string pathOnly = fullPathFileName.Replace(fileName, "");

            txtFileName.Text = fileName;
            txtLocation.Text = pathOnly;

            string pathPartToCheck = "";

            if (pathOnly.Length >= templateFolder.Length)
                pathPartToCheck = pathOnly.Substring(0, templateFolder.Length);
            else
                pathPartToCheck = pathOnly;

            if (pathPartToCheck != templateFolder)
            {
                txtFileName.Text = "";
                txtLocation.Text = "";

                MessageBox.Show("Please select file from allowed folder. " + templateFolder);
                return;
            }

            // Get reference path
            //
            string refPath =
                Utils.getReferenceFilePathName(txtLocation.Text);
            txtLocation.Text = refPath;

            // This is the name of the document and not the file name
            // If it is already set for the client, there is no need
            // to replace it. The idea here is to suggest a name only
            // when the document is being created.
            //
            if (string.IsNullOrEmpty(txtName.Text))
            {
                txtName.Text = fileName.Substring(0, fileName.Length - 4);
            }

            txtFileName.Text = fileName;

        }

        private void btnNewIssue_Click(object sender, EventArgs e)
        {
            Document document = new Document();
            document.UID = Convert.ToInt32( txtUID.Text );
            document.CUID = txtCUID.Text;
            document.Location = txtLocation.Text;
            document.IssueNumber = Convert.ToInt32( txtIssueNumber.Text );
            document.Name = txtName.Text;
            document.SequenceNumber = Convert.ToInt32( txtSeqNum.Text );
            document.FileName = txtFileName.Text;
            document.ParentUID = Convert.ToInt32(txtParentUID.Text);

            // var response = document.NewVersion(HeaderInfo.Instance);

            // var response = RepDocument.NewVersion(HeaderInfo.Instance, document);

            //
            var documentNewVersionRequest = new DocumentNewVersionRequest();
            documentNewVersionRequest.headerInfo = HeaderInfo.Instance;
            documentNewVersionRequest.inDocument = document;
            var respNewVersion = BUSDocument.DocumentNewVersion(documentNewVersionRequest);

            if (respNewVersion.response.ReturnCode != 0001)
            {
                ControllerUtils.ShowFCMMessage(respNewVersion.response.UniqueCode, Utils.UserID);
                return;
            }

            var i = respNewVersion.response.Contents.ToString();
            MessageBox.Show("New issue #" + i + " created successfully.");

            txtFileName.Text = document.FileName;
            txtName.Text = document.Name;
            txtIssueNumber.Text = document.IssueNumber.ToString();

        }

        private void btnEditDocument_Click(object sender, EventArgs e)
        {

            Utils.OpenDocument(txtLocation.Text, txtFileName.Text, cbxDocumentType.Text, vkReadOnly: true);

        }

        private void btnDirectory_Click(object sender, EventArgs e)
        {
            CodeValue cv = new CodeValue();
            cv.FKCodeType = "DIRECTORY";
            UIReferenceData uird = new UIReferenceData(cv);
            uird.ShowDialog();

            //txtDirectory.Text = cv.ID;
            //txtDirectoryDescription.Text = cv.Description;

        }

        private void btnSubDirectory_Click(object sender, EventArgs e)
        {
            CodeValue cv = new CodeValue();
            cv.FKCodeType = "SUBDIRECTORY";
            UIReferenceData uird = new UIReferenceData(cv);
            uird.ShowDialog();

            //txtSubDirectory.Text = cv.ID;
            //txtSubDirectoryDescription.Text = cv.Description;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            UIClientList uicl = new UIClientList(this);
            uicl.ShowDialog();

            txtClientUID.Text = Utils.ClientID.ToString();
        }

        private void enableSave(object sender, EventArgs e)
        {
            bool enable = true;

            // Check conditions to enable the save
            if (string.IsNullOrEmpty(txtIssueNumber.Text))
                enable = false;

            if (string.IsNullOrEmpty(txtSeqNum.Text))
                enable = false;

            if (string.IsNullOrEmpty(txtName.Text))
                enable = false;

            if (string.IsNullOrEmpty(txtCUID.Text))
                enable = false;

            if (cbxRecordType.Text == FCMConstant.RecordType.FOLDER)
            { 
                // file name is not mandatory for folders
                //
            }
            else
            {
                if (string.IsNullOrEmpty(txtFileName.Text))
                    enable = false;
            }
            // Enable if that's the case
            if (enable)
                tsSave.Enabled = true;
            else
                tsSave.Enabled = false;

            txtName.Text = UIHelper.ClientDocumentUIHelper.SetDocumentName( 
                txtSimpleFileName.Text, 
                txtIssueNumber.Text, 
                txtCUID.Text,
                cbxRecordType.Text,
                txtFileName.Text);

        }

        private void cbxSourceCode_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbxSourceCode.Text == FCMConstant.SourceCode.CLIENT)
            {
                btnClient.Enabled = true;
            }
            else
            {
                btnClient.Enabled = false;
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void cbxRecordType_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnNewIssue.Enabled = true;
            txtSeqNum.Enabled = true;
            cbxSourceCode.Enabled = true;
            lblDocumentUID.Text = "Document ID:";

            if (cbxRecordType.Text == FCMConstant.RecordType.FOLDER)
            {
                btnNewIssue.Enabled = false;
                txtSeqNum.Enabled = false;
                cbxSourceCode.Text = FCMConstant.SourceCode.FCM;
                cbxSourceCode.Enabled = false;
                lblDocumentUID.Text = "Folder ID:";
            }

            enableSave(sender, e);
        }

        private void cbxDocumentType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtSimpleFileName_TextChanged(object sender, EventArgs e)
        {

            txtName.Text = UIHelper.ClientDocumentUIHelper.SetDocumentName( 
                txtSimpleFileName.Text, 
                txtIssueNumber.Text,
                txtCUID.Text,
                cbxRecordType.Text,
                txtFileName.Text);
            enableSave( sender, e );
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_previousForm != null)
                _previousForm.Activate();

            this.Dispose();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Utils.OpenDocument(txtLocation.Text, txtFileName.Text, cbxDocumentType.Text, vkReadOnly: false);

        }
    }
}
