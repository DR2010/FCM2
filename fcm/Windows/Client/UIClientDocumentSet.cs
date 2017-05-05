using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FCMMySQLBusinessLibrary.Model.ModelClientDocument;
using FCMMySQLBusinessLibrary.Model.ModelDocument;
using FCMMySQLBusinessLibrary.Model.ModelMetadata;
using FCMMySQLBusinessLibrary.Repository.RepositoryDocument;
using FCMMySQLBusinessLibrary.Service.SVCClient.Service;
using FCMMySQLBusinessLibrary.Service.SVCClientDocument.Service;
using FCMMySQLBusinessLibrary.Service.SVCDocument.Service;
using MackkadoITFramework.APIDocument;
using FCMMySQLBusinessLibrary.Model.ModelClient;
using FCMMySQLBusinessLibrary.FCMUtils;
using MackkadoITFramework.Interfaces;
using MackkadoITFramework.ReferenceData;
using MackkadoITFramework.Utils;
using FCMMySQLBusinessLibrary;


namespace fcm.Windows
{
    public partial class UIClientDocumentSet : Form, IOutputMessage
    {
        private DocumentSet documentSet;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private string taskBarMessage;
        private string overrideDocuments;
        private TreeNode tndocSelected;
        private List<ClientDocumentSet> ListOfDocumentSets;
        ImageList imageList;
        ImageList imageList32;
        public string ScreenCode;
        float tvClientDocumentListFontSize;
        int tvClientDocumentListIconSize;

        float tvClientDocumentListADFontSize;
        int tvClientDocumentListADIconSize;

        static BackgroundWorker _backgroundWorker = new BackgroundWorker();

        //private int documentSetUID;

        public UIClientDocumentSet()
        {
            InitializeComponent();

            ScreenCode = FCMConstant.ScreenCode.ClientDocumentSet;

            CreateClientMetadataTable();
            documentSet = new DocumentSet();

            //_backgroundWorker.DoWork += GenerateDocument;

            //this.components = new System.ComponentModel.Container();

            //// Set up how the form should be displayed.
            //this.ClientSize = new System.Drawing.Size( 292, 266 );
            //this.Text = "FCM Report Generator";

            //this.notifyIcon1 = new System.Windows.Forms.NotifyIcon( this.components );
            //notifyIcon1.Icon = new Icon( "FCMIcon.ico" );
            //notifyIcon1.Text = "Form1 (NotifyIcon example)";
            //notifyIcon1.Visible = true;
            //// notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            //// notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            //notifyIcon1.MouseMove += new MouseEventHandler( notifyIcon1_MouseMove );
            //notifyIcon1.ContextMenuStrip = contextMenuStrip2;

            this.Icon = new Icon( "FCMIcon.ico" );

            ListOfDocumentSets = new List<ClientDocumentSet>();

            tvFileList.Refresh();

        }

        // ------------------------------------------
        // Load event
        // ------------------------------------------
        private void UIClientDocumentSet_Load(object sender, EventArgs e)
        {

            if (! Cache.CachedInfo.IsUserAllowedToScreen(Utils.UserID, FCMConstant.ScreenCode.ClientDocumentSet))
            {
                MessageBox.Show("User does not have access to this screen.");
                this.Dispose();
                return;
            }

            // Disable buttons
            tsbtnDelete.Enabled = false;
            tsbtnDown.Enabled = false;
            tsbtnUp.Enabled = false;
            tsbtnDelete.Enabled = false;
            tsbtnCopyAll.Enabled = false;

            // Image list
            //

            // 32 x 32
            imageList32 = ControllerUtils.GetImageList();
            imageList32.ImageSize = new Size(32, 32);

            // 16 x 16
            imageList = ControllerUtils.GetImageList();
            tvFileList.ImageList = imageList;

            // Clear nodes
            tvFileList.Nodes.Clear();

            //
            // Get client list from background and load into the list
            //
            foreach (Client c in Utils.ClientList)
            {
                cbxClient.Items.Add(c.UID + "; " + c.Name);
            }

            //
            // Get selected client from the background
            //
            cbxClient.SelectedIndex = Utils.ClientIndex;

            // List all documents
            //
            // ImageList imageList2 = Utils.GetImageList();
            tvDocumentsAvailable.ImageList = imageList;

            // Clear nodes
            tvDocumentsAvailable.Nodes.Clear();
            var docoList = new DocumentList();
            docoList.List();

            // Load document in the treeview
            //
            //docoList.ListInTree(tvDocumentsAvailable);
            Document root = new Document();
            // root.GetRoot(HeaderInfo.Instance);

            root = BUSDocument.GetRootDocument();

            DocumentList.ListInTree(tvDocumentsAvailable, docoList, root);

            if (tvDocumentsAvailable.Nodes.Count >= 0)
            {
                tvDocumentsAvailable.Nodes[0].Expand();
            }

            // Load document set list
            //
            DocumentSetList dsl = new DocumentSetList();
            dsl.ListInComboBox(cbxDocSet);
            if (cbxDocSet.Items.Count <= 0)
                return;
            cbxDocSet.SelectedIndex = 0;
            cbxDocSet.Items.Add("99; Client Specific");

            // Retrieve values from cache
            //
            GetValuesFromCache();

            // Load client document list
            //
            indexChanged();

        }
        
        public UIClientDocumentSet(string ClientID): this()
        {
            InitializeComponent();
            cbxClient.Enabled = false;
        }

        // ------------------------------------------
        // Client Metadata datatable
        // ------------------------------------------
        public void CreateClientMetadataTable()
        {
            //
            // Create datatable
            //
            var Enabled = new DataColumn("Enabled", typeof(String));
            var FieldCode = new DataColumn("FieldCode", typeof(String));
            var RecordType = new DataColumn("RecordType", typeof(String));
            var InformationType = new DataColumn("InformationType", typeof(String));
            var Condition = new DataColumn("Condition", typeof(String));
            var Description = new DataColumn("Description", typeof(String));
            var ClientType = new DataColumn("ClientType", typeof(String));
            var ClientUID = new DataColumn("ClientUID", typeof(String));
            var UID = new DataColumn("UID", typeof(String));
            var CompareWith = new DataColumn("CompareWith", typeof(String));

            //// Client Metadata
            ////
            //clientMetadataTable = new DataTable("clientMetadataTable");

            //clientMetadataTable.Columns.Add(Enabled);
            //clientMetadataTable.Columns.Add(FieldCode);
            //clientMetadataTable.Columns.Add(InformationType);
            //clientMetadataTable.Columns.Add(Condition);
            //clientMetadataTable.Columns.Add(Description);
            //clientMetadataTable.Columns.Add(RecordType);
            //clientMetadataTable.Columns.Add(ClientType);
            //clientMetadataTable.Columns.Add(ClientUID);
            //clientMetadataTable.Columns.Add(UID);
            //clientMetadataTable.Columns.Add(CompareWith);

            //dgvClientMetadata.DataSource = clientMetadataTable;

        }


        // -------------------------------------------
        //  Load project plan
        // -------------------------------------------
        private void LoadProjectPlan()
        {
            // Image list
            //
            ImageList imageList = ControllerUtils.GetImageList();
            tvProjectPlan.ImageList = imageList;

            // Clear nodes
            tvProjectPlan.Nodes.Clear();

            var cdl = new ClientDocument();
            // cdl.ListProjectPlanInTree(Utils.ClientID, Utils.ClientSetID, tvProjectPlan);

            BUSClientDocument.ListProjectPlanInTree( cdl, Utils.ClientID, Utils.ClientSetID, tvProjectPlan );

        }


        /// <summary>
        /// When client is changed or the client document set is changed
        /// </summary>
        private void indexChanged()
        {
            txtSourceFolder.Text = "";
            txtDestinationFolder.Text = "";
            txtFolderOnly.Text = "";
            txtDocumentSetDesc.Text = "";
            cbxDocumentSet.Text = "";

            // Get selected client
            //
            string[] part = cbxClient.SelectedItem.ToString().Split(';');
            Utils.ClientID = Convert.ToInt32(part[0]);

            // Retrieve list of document sets for the selected client
            //
            var documentSetList = ClientDocumentSet.List(Utils.ClientID, sortOrder: "DESC");

            cbxDocumentSet.Items.Clear();
            ListOfDocumentSets.Clear();

            int currentDocSetID = 1;
            if (documentSetList.Count > 1)
            {
                var lastDocSet = (ClientDocumentSet)documentSetList[0];
                currentDocSetID = lastDocSet.ClientSetID;
            }

            foreach (ClientDocumentSet cds in documentSetList)
            {
                // cbxDocumentSet.Items.Add(cds.FKClientUID + ";" + cds.ClientSetID + "; " + cds.Description + "; " + cds.Status);
                cbxDocumentSet.Items.Add(cds.CombinedIDName);
                ListOfDocumentSets.Add(cds);
            }

            if (cbxDocumentSet.Items.Count >= 1)
            {
                // Set full text for the client document set including id and description
                //
                Utils.ClientSetText = cbxDocumentSet.Items[0].ToString();

                //
                // Force first item to be selected
                //
                cbxDocumentSet.SelectedIndex = 0;
                cbxDocumentSet.SelectedItem = 0;

                // Get Client UID
                //
                string[] p = cbxDocumentSet.SelectedItem.ToString().Split(';');
                Utils.ClientSetID = Convert.ToInt32(p[0]);

                // Retrieve document set for a client
                //
                ClientDocumentSet clientDocSet = new ClientDocumentSet();
                // Utils.ClientSetID = 1;
                
                Utils.ClientSetID = currentDocSetID;
                
                clientDocSet.Get(Utils.ClientID, Utils.ClientSetID);
                cbxDocumentSet.SelectedIndex = 0;

                txtSourceFolder.Text = clientDocSet.SourceFolder;
                txtDestinationFolder.Text = clientDocSet.Folder;
                txtFolderOnly.Text = clientDocSet.FolderOnly;
                txtDocumentSetDesc.Text = clientDocSet.Description;

                labelStatus.Text = ListOfDocumentSets[cbxDocumentSet.SelectedIndex].Status;
                EnableDisableFields();

            }

            // 
            // Load documents for a Client Document Set
            //
            loadDocumentList();
            loadClientMetadataList();
            LoadProjectPlan();

            RemoveDocumentsAlreadySelected(tvDocumentsAvailable);


        }

        /// <summary>
        /// Load documents for a Client Document Set
        /// </summary>
        [Obsolete("No longer used", true)]
        private void loadDocumentList2()
        {

            // List client document list
            //
            var documentSetList = new ClientDocument();
            //documentSetList.List(Utils.ClientID, Utils.ClientSetID);

            var cdlr = new BUSClientDocument.ClientDocumentListRequest();
            cdlr.clientUID = Utils.ClientID;
            cdlr.clientDocumentSetUID = Utils.ClientSetID;
            var response = BUSClientDocument.List(cdlr);

            documentSetList.clientDocSetDocLink = response.clientList;

            // List documents in background and show message
            //

            tvFileList.Nodes.Clear();
            // documentSetList.ListInTree(tvFileList, "CLIENT");

            BUSClientDocument.ListInTree(documentSetList, tvFileList, "CLIENT" );

            if (tvFileList.Nodes.Count > 0)
                tvFileList.Nodes[0].Expand();

        }

        /// <summary>
        /// Load documents for a Client Document Set
        /// </summary>
        private void loadDocumentList()
        {

            var clientDocumentListRequest = new BUSClientDocument.ClientDocumentListRequest();
            clientDocumentListRequest.clientDocumentSetUID = Utils.ClientSetID;
            clientDocumentListRequest.clientUID = Utils.ClientID;

            var clientDocumentListResponse = BUSClientDocument.List(clientDocumentListRequest);

            tvFileList.Nodes.Clear();
            UIHelper.ClientDocumentUIHelper.ListInTree(tvFileList, "CLIENT", clientDocumentListResponse.clientList);
           
            if (tvFileList.Nodes.Count > 0)
                tvFileList.Nodes[0].Expand();


        }

        /// <summary>
        /// Remove documents already selected from client list
        /// </summary>
        /// <param name="treeView"></param>
        private void RemoveDocumentsAlreadySelected(TreeView treeView)
        {

            foreach (TreeNode node in treeView.Nodes)
            {
                var key = (Document)node.Tag;
                TreeNode[] tn = tvFileList.Nodes.Find(key.Name, true);
                if (tn.Count() > 0)
                {
                    tn[0].Remove();
                }
            }
        }

        //
        // Load metadata
        //
        private void loadClientMetadataList()
        {
            //clientMetadataTable.Rows.Clear();

            // Load client metadata
            ReportMetadataList rmd = new ReportMetadataList();
            rmd.ListMetadataForClient( Utils.ClientID );

            //foreach (ReportMetadata metadata in rmd.reportMetadataList)
            //{

            //    DataRow elementRow = clientMetadataTable.NewRow();
            //    elementRow["Enabled"] = metadata.Enabled;
            //    elementRow["UID"] = metadata.UID;
            //    elementRow["RecordType"] = metadata.RecordType;
            //    elementRow["FieldCode"] = metadata.FieldCode;
            //    elementRow["Description"] = metadata.Description;
            //    elementRow["ClientType"] = metadata.ClientType;
            //    elementRow["ClientUID"] = metadata.ClientUID;
            //    elementRow["InformationType"] = metadata.InformationType;
            //    elementRow["Condition"] = metadata.Condition;
            //    elementRow["CompareWith"] = metadata.CompareWith;

            //    clientMetadataTable.Rows.Add(elementRow);

            //}



            // Load in tree

            // Image list
            //
            ImageList imageList = ControllerUtils.GetImageList();

            // Binding
            // tvMetadata.ImageList = imageList;

            // Clear nodes
            // tvMetadata.Nodes.Clear();

            TreeNode root = new TreeNode("Metadata", FCMConstant.Image.Checked, FCMConstant.Image.Checked);
            root.Name = "Metadata";

            //tvMetadata.Nodes.Add( root );

            foreach (ReportMetadata metadata in rmd.reportMetadataList)
            {

                ReportMetadata report = new ReportMetadata();
                report.Enabled = metadata.Enabled;
                report.UID = metadata.UID;
                report.RecordType = metadata.RecordType;
                report.FieldCode = metadata.FieldCode;
                report.Description = metadata.Description;
                report.ClientType = metadata.ClientType;
                report.ClientUID = metadata.ClientUID;
                report.InformationType = metadata.InformationType;
                report.Condition = metadata.Condition;
                report.CompareWith = metadata.CompareWith;

                var image = report.Enabled == 'Y' ? 8 : 9;

                TreeNode tn = new TreeNode( metadata.FieldCode, image, image );
                tn.Name = metadata.FieldCode;
                tn.Tag = report;

                root.Nodes.Add( tn );
            }


            //tvMetadata.ExpandAll();

        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (dgvDocumentList.SelectedRows.Count <= 0)
            //    return;

            //var selectedRow = dgvDocumentList.SelectedRows;

            //foreach (var row in selectedRow)
            //{
            //    DataGridViewRow dgvr = (DataGridViewRow)row;
            //    dgvr.Cells["Void"].Value = 'Y';
            //}
        }

        private void cbxClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxDocumentSet.Items.Clear();
            cbxDocumentSet.Text = "";
           
            indexChanged();

            if (string.IsNullOrEmpty(cbxDocumentSet.Text))
            {
                tsbtnLinks.Enabled = false;
                tsmiLinks.Enabled = false;
            }
            else
            {
                tsbtnLinks.Enabled = true;
                tsmiLinks.Enabled = true;
            }
        }

        //
        // Index change on client document set
        //
        private void cbxDocumentSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedIndexChange();
        }

        /// <summary>
        /// Refresh list
        /// </summary>
        private void SelectedIndexChange()
        {

            // Get document set UID
            //
            string[] part = cbxDocumentSet.SelectedItem.ToString().Split(';');
            //  documentSetUID = Convert.ToInt32(part[1]);
            Utils.ClientSetID = Convert.ToInt32(part[1]);

            // Retrieve document set for a client
            //
            var clientDocSet = new ClientDocumentSet();
            // documentSetUID = 1;

            clientDocSet.Get(Utils.ClientID, Utils.ClientSetID);

            txtSourceFolder.Text = clientDocSet.SourceFolder;
            txtDestinationFolder.Text = clientDocSet.Folder;
            txtFolderOnly.Text = clientDocSet.FolderOnly;
            txtDocumentSetDesc.Text = clientDocSet.Description;

            // Load documents for a Client Document Set
            //
            loadDocumentList();
            loadClientMetadataList();

            labelStatus.Text = ListOfDocumentSets[cbxDocumentSet.SelectedIndex].Status;

            EnableDisableFields();
        }

        private void btnSelectSource_Click(object sender, EventArgs e)
        {

            
            folderBrowserDialog1.ShowNewFolderButton = true;
            folderBrowserDialog1.ShowDialog();
            txtSourceFolder.Text = folderBrowserDialog1.SelectedPath;

            if (folderBrowserDialog1.SelectedPath == String.Empty)
                return;

            var folderSource = "";

            var templateFolder =
                CodeValue.GetCodeValueExtended(FCMConstant.CodeTypeString.SYSTSET, FCMConstant.SYSFOLDER.TEMPLATEFOLDER);

            if (txtSourceFolder.Text.Contains(templateFolder))
            {
                folderSource = txtSourceFolder.Text.Replace(templateFolder, FCMConstant.SYSFOLDER.TEMPLATEFOLDER);
                txtSourceFolder.Text = folderSource;
            }
        }

        private void btnSelectDestination_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowNewFolderButton = true;
            folderBrowserDialog1.ShowDialog();

            if (folderBrowserDialog1.SelectedPath == String.Empty)
                return;

            txtDestinationFolder.Text = folderBrowserDialog1.SelectedPath;

            var folderDestination = "";

            var clientFolder =
                CodeValue.GetCodeValueExtended(FCMConstant.CodeTypeString.SYSTSET, FCMConstant.SYSFOLDER.CLIENTFOLDER);

            if (txtDestinationFolder.Text.Contains(clientFolder))
            {
                folderDestination = txtDestinationFolder.Text.Replace(clientFolder, FCMConstant.SYSFOLDER.CLIENTFOLDER);
                txtDestinationFolder.Text = folderDestination;
            }
        }

        // Save Click
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();

            UpdateDocumentLocation();

            MessageBox.Show("Client document set saved successfully.");

        }

        // ----------------------------------------------------------
        //                 Save client documents
        // ----------------------------------------------------------
        private void Save()
        {
            ClientDocument cdsl = new ClientDocument();
            ClientDocumentSet docSet = new ClientDocumentSet();

            var lodsl = new ListOfscClientDocSetDocLink();
            lodsl.list = new List<scClientDocSetDocLink>();

            // Move data into views..

            if (string.IsNullOrEmpty( cbxDocumentSet.Text ) )
            {
                MessageBox.Show("Document set not selected or created.");
                return;
            }

            string[] docSetUIDrude = cbxDocumentSet.Text.Split(';');

            string docSetUIDText = docSetUIDrude[1];
            int selUID = Convert.ToInt32(docSetUIDText);

            docSet.Get(Utils.ClientID, selUID);
            docSet.ClientSetID = selUID;
            docSet.Folder = txtDestinationFolder.Text;
            docSet.SourceFolder = txtSourceFolder.Text;
            if (string.IsNullOrEmpty(txtSourceFolder.Text))
            {
                MessageBox.Show("Source Folder is Empty. Please fix and save again.");
            }
            docSet.Description = txtDocumentSetDesc.Text;
            var response = docSet.Update();

            if (response.ReturnCode <= 0)
            {
                MessageBox.Show("Error saving document. " + response.Message);
                return;
            }

            // Save complete tree...

            SaveTreeNodeToClient(tvFileList, 0);

            // Save all the document types
            //

            loadDocumentList();
            loadClientMetadataList();

        }


        // -------------------------------------------------------------------
        //                Saves each node of a client tree
        // -------------------------------------------------------------------
        private void SaveTreeNodeToClient(TreeView treeView, int parentID)
        {
            foreach (TreeNode node in treeView.Nodes)
            {
                var documentLink = (scClientDocSetDocLink)node.Tag;

                SaveTreeNodeToClient(node, documentLink.clientDocument.UID);
            }
        }


        private TreeNode SaveTreeNodeToClient(TreeNode treeNode, int parentID)
        {
            TreeNode ret = new TreeNode();
            ClientDocument cdsl = new ClientDocument();
            
            var t = treeNode.Tag.GetType();

            // If the type is not document, it is an existing document
            //
            // var documentLink = new FCMStructures.scClientDocSetDocLink();
            var documentLink = new scClientDocSetDocLink();

            if (t.Name == "scClientDocSetDocLink")
            {
                documentLink = (scClientDocSetDocLink)treeNode.Tag;
                documentLink.clientDocument.SequenceNumber = treeNode.Index;

                if (documentLink.document.UID == 0)
                {
                    LogFile.WriteToTodaysLogFile("Document UID is empty." + documentLink.clientDocument.FKClientUID);
                    return ret;

                }
            }

            //
            // If the type is Document, it means a new document added to the client
            // list
            //
            if (t.Name == "Document")
            #region Document
            {
                documentLink.document = new Document();
                documentLink.document = (Document)treeNode.Tag;

                documentLink.clientDocument = new ClientDocument();
                documentLink.clientDocumentSet = new ClientDocumentSet();

                // Fill in the extra details...
                //

                documentLink.clientDocument.EndDate = System.DateTime.MaxValue;
                documentLink.clientDocument.FKClientDocumentSetUID = Utils.ClientSetID;
                documentLink.clientDocument.FKClientUID = Utils.ClientID;
                if (Utils.ClientID <= 0)
                {
                    MessageBox.Show("Client ID is invalid.");
                    return null;
                }
                documentLink.clientDocument.FKDocumentUID = documentLink.document.UID;
                documentLink.clientDocument.Generated = 'N';
                documentLink.clientDocument.SourceIssueNumber = documentLink.document.IssueNumber;
                documentLink.clientDocument.ClientIssueNumber = 00;

                // When the source is client, the name will have already all the numbers
                //
                //if (documentLink.document.SourceCode == Utils.SourceCode.CLIENT)
                //{
                //    documentLink.clientDocument.ComboIssueNumber = documentLink.document.CUID;
                //}
                //else
                //{

                //}

                if (documentLink.document.RecordType == FCMConstant.RecordType.FOLDER)
                {
                    documentLink.clientDocument.ComboIssueNumber = documentLink.document.CUID;
                    documentLink.clientDocument.FileName = documentLink.document.SimpleFileName;
                }
                else
                {
                    //documentLink.clientDocument.ComboIssueNumber =
                    //ClientDocument.GetComboIssueNumber(documentLink.document.CUID, 
                    //                                   documentLink.document.IssueNumber, 
                    //                                   Utils.ClientID);

                    documentLink.clientDocument.ComboIssueNumber =
                    BUSClientDocument.GetComboIssueNumber( documentLink.document.CUID,
                                                           documentLink.document.IssueNumber,
                                                           Utils.ClientID );
 

                    documentLink.clientDocument.FileName = documentLink.clientDocument.ComboIssueNumber + " " +
                                                       documentLink.document.SimpleFileName;
                } 
                documentLink.clientDocument.IsProjectPlan = documentLink.document.IsProjectPlan;
                documentLink.clientDocument.DocumentCUID = documentLink.document.CUID;
                documentLink.clientDocument.DocumentType = documentLink.document.DocumentType;
                // The client document location includes the client path (%CLIENTFOLDER%) plus the client document set id
                // %CLIENTFOLDER%\CLIENTSET201000001R0001\


                // How to identify the parent folder
                //
                // documentLink.clientDocument.ParentUID = destFolder.clientDocument.UID;
                documentLink.clientDocument.ParentUID = parentID;

                //  documentLink.clientDocument.Location = txtDestinationFolder.Text +
                //                                         Utils.GetClientPathInside(documentLink.document.Location);

                // documentLink.clientDocument.Location = GetClientDocumentLocation( parentID );

                documentLink.clientDocument.Location = BUSClientDocument.GetClientDocumentLocation( parentID );

                documentLink.clientDocument.RecordType = documentLink.document.RecordType;
                documentLink.clientDocument.SequenceNumber = treeNode.Index;
                documentLink.clientDocument.SourceFileName = documentLink.document.FileName;
                documentLink.clientDocument.SourceLocation = documentLink.document.Location;

                documentLink.clientDocument.StartDate = System.DateTime.Today;
                documentLink.clientDocument.UID = 0;

                documentLink.clientDocumentSet.UID = Utils.ClientSetID;
                documentLink.clientDocumentSet.SourceFolder = txtSourceFolder.Text;
                documentLink.clientDocumentSet.ClientSetID = Utils.ClientSetID;
                documentLink.clientDocumentSet.FKClientUID = Utils.ClientID;
                documentLink.clientDocumentSet.Folder = txtDestinationFolder.Text;
            }
            #endregion Document

            // Save link to database
            //
            // documentLink.clientDocument.UID = cdsl.LinkDocumentToClientSet(documentLink);

            documentLink.clientDocument.UID = BUSClientDocument.LinkDocumentToClientSet( documentLink );

            foreach (TreeNode children in treeNode.Nodes)
            {
                SaveTreeNodeToClient(children, documentLink.clientDocument.UID);
            }


            return ret;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var response = BUSClientDocumentSet.ClientDocumentSetAdd(HeaderInfo.Instance);

            indexChanged();

            SelectedIndexChange();

            MessageBox.Show( response.Message, "No password", MessageBoxButtons.OK, response.Icon );

            Cursor.Current = Cursors.Arrow;

        }

        private void UIClientDocumentSet_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        public void RefreshMetadata()
        {
            loadClientMetadataList();
        }

        /// <summary>
        /// Generate document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            GenerateDocument("ONLINE");
        }

        /// <summary>
        /// Generate documents.
        /// </summary>
        /// <param name="how"></param>
        public void GenerateDocument(string how)
        {
            // Initial checks
            if (string.IsNullOrEmpty(txtDestinationFolder.Text))
            {
                MessageBox.Show("Destination folder for client documents not defined.");
                return;
            }

            var answer = MessageBox.Show("Would you like to proceed with the document generation?",
                "Generate Documents",
                MessageBoxButtons.YesNo);

            overrideDocuments = "No";

            if (answer == DialogResult.Yes)
            {
                var over = MessageBox.Show("Would you like to replace generated documents?",
                    "Override Documents",
                    MessageBoxButtons.YesNo);

                if (over == DialogResult.Yes)
                {
                    overrideDocuments = "Yes";
                }

            }
            else
                return;

            if (how == "ONLINE")
                GenerateDocumentOnline();
            if (how == "BACKGROUND")
                GenerateDocumentBackground();
           
        }

        /// <summary>
        /// Online Document Generation
        /// </summary>
        public void GenerateDocumentOnline()
        {

            var uioutput = new Windows.UIOutputMessage();
            uioutput.Show();
            uioutput.WindowState = FormWindowState.Maximized;

            uioutput.AddOutputMessage( "Document generation starting...", "UI", Utils.UserID );

            DocumentGeneration wdt = new DocumentGeneration(ClientID: Utils.ClientID, 
                                                            ClientDocSetID: Utils.ClientSetID,
                                                            UIoutput: uioutput,
                                                            OverrideDocuments: overrideDocuments,
                                                            inprocessName:"UI",
                                                            inuserID: Utils.UserID);

            tndocSelected = tvFileList.SelectedNode;

            if (tndocSelected == null)
            {
                // Try to select the root folder when no item has been selected
                //
                tndocSelected = tvDocumentsAvailable.Nodes[0];


                // MessageBox.Show( "Folder not selected in tree" );
                // return;
            }

            // If document selected is SRG-01 - Generate System Register
            var document = new scClientDocSetDocLink();

            document = (scClientDocSetDocLink) tndocSelected.Tag;

            // toolStripStatusLabel1.Text = "Please wait while documents are generated...";

            uioutput.AddOutputMessage( "Please wait...", "UI", Utils.UserID );
            Cursor.Current = Cursors.WaitCursor;

            // Save first or make
            //
            uioutput.AddOutputMessage( "Saving documents...", "UI", Utils.UserID );
            Save();

            // Update Location
            //
            uioutput.AddOutputMessage( "Fixing document location...", "UI", Utils.UserID );
            UpdateDocumentLocation();

            // Generate document
            //
            wdt.GenerateDocumentsForClient( tndocSelected );

            //// Generate Register of Systems Documents
            ////
            //if ( document.document.CUID == "SRG-01" )
            //{
            //    WordReport wr = new WordReport( ClientID: Utils.ClientID, ClientDocSetID: Utils.ClientSetID,
            //                                                    UIoutput: uioutput,
            //                                                    OverrideDocuments: overrideDocuments );

            //    // var response = wr.RegisterOfSytemDocuments2( tvFileList, txtDestinationFolder.Text, wr.FullFileNamePath, document );
                
            //    var response = wr.RegisterOfSytemDocuments2( tvFileList, txtDestinationFolder.Text, wr.FullFileNamePath );
            //    uioutput.AddOutputMessage( response.Message );
            
            //}

            Cursor.Current = Cursors.Arrow;
            toolStripStatusLabel1.Text = "Document generation completed.";

            // Update list
            SelectedIndexChange();

            // uioutput.AddOutputMessage( "Generation completed." );

        }

        public void GenerateDocumentBackground()
        {
            Cursor.Current = Cursors.WaitCursor;
            BUSProcessRequest.GenerateDocumentClient(Utils.ClientID, Utils.ClientSetID, overrideDocuments,0, HeaderInfo.Instance.UserID);

            Cursor.Current = Cursors.Arrow;
            MessageBox.Show("Document Process Requested.");
        }


        /// <summary>
        /// This process will initiate a thread to run the report. Under construction.
        /// </summary>
        private void GenerateDocument(object sender, DoWorkEventArgs e)
        {

            var uioutput = new Windows.UIOutputMessage();
            uioutput.Show();
            // uioutput.WindowState = FormWindowState.Maximized;

            //DocumentGeneration wdt = new DocumentGeneration( ClientID: Utils.ClientID, ClientDocSetID: Utils.ClientSetID,
            //                                                UIoutput: uioutput,
            //                                                OverrideDocuments: overrideDocuments);

            DocumentGeneration wdt = new DocumentGeneration( 
                                                ClientID: Utils.ClientID, 
                                                ClientDocSetID: Utils.ClientSetID,
                                                UIoutput: this,
                                                OverrideDocuments: overrideDocuments,
                                                inprocessName:"UI",
                                                inuserID:Utils.UserID );

            wdt.GenerateDocumentsForClient( tndocSelected );

            return;
        }

        // It shows the progress of the generation on the taskbar
        //

        private void ShowInTaskBar()
        {

            return;
        }

        private void notifyIcon1_MouseMove( object sender, MouseEventArgs e )
        {
            // notifyIcon1.Text = "it will be updated...";

            return;
        }


        // -----------------------------------------------------
        //   This method replicates folders and files for a given
        //   folder structure (source and destination)
        // -----------------------------------------------------
        private void ReplicateFolderFilesReplace()
        {
            Cursor.Current = Cursors.WaitCursor;

            Word.Application vkWordApp =
                                new Word.Application();

            string sourceFolder = txtSourceFolder.Text;
            string destinationFolder = txtDestinationFolder.Text;

            if (sourceFolder == "" || destinationFolder == "")
            {
                return;
            }

            // Retrieve client metadata
            //
            // 1...
            // 2...
            // Find client metadata
            ReportMetadataList clientMetadata = new ReportMetadataList();
            clientMetadata.ListMetadataForClient(Utils.ClientID);

            var ts = new List<WordDocumentTasks.TagStructure>();

            // Load variables/ metadata into memory
            //
            foreach (ReportMetadata metadata in clientMetadata.reportMetadataList)
            {
                // Source Information
                // Create a class to source the information
                //...
                // string value = DataColector.Get(metadata);

                string value = metadata.GetValue();

                ts.Add(new WordDocumentTasks.TagStructure() { Tag = metadata.FieldCode, TagValue = value });

            }



            return;

            
            //WordDocumentTasks.CopyFolder(sourceFolder, destinationFolder);
            //WordDocumentTasks.ReplaceStringInAllFiles(destinationFolder, ts, vkWordApp);

            //Cursor.Current = Cursors.Arrow;
            //MessageBox.Show("Project Successfully Created.");
        }


        // -----------------------------------------------------
        //   This method replicates folders and files for a given
        //   folder structure (source and destination)
        // -----------------------------------------------------
        private void ReplicateFolderFilesReplaceOld()
        {
            Cursor.Current = Cursors.WaitCursor;

            Word.Application vkWordApp =
                                new Word.Application();

            // The source comes from the document set
            // The destination is selected and stored also
            //

            string sourceFolder = txtSourceFolder.Text;
            string destinationFolder = txtDestinationFolder.Text;

            if (sourceFolder == "" || destinationFolder == "")
            {
                return;
            }

            var ts = new List<WordDocumentTasks.TagStructure>();
            ts.Add(new WordDocumentTasks.TagStructure() { Tag = "<<XX>>", TagValue = "VV1" });
            ts.Add(new WordDocumentTasks.TagStructure() { Tag = "<<YY>>", TagValue = "VV2" });
            ts.Add(new WordDocumentTasks.TagStructure() { Tag = "<<VV>>", TagValue = "VV3" });
            ts.Add(new WordDocumentTasks.TagStructure() { Tag = "<<ClientNAME>>", TagValue = "Client 2" });
            ts.Add(new WordDocumentTasks.TagStructure() { Tag = "<<ClientADDRESS>>", TagValue = "St Street" });
            ts.Add(new WordDocumentTasks.TagStructure() { Tag = "<<ClientEMAILADDRESS>>", TagValue = "Email@com" });
            ts.Add(new WordDocumentTasks.TagStructure() { Tag = "<<ClientPHONE>>", TagValue = "09393893" });

            WordDocumentTasks.CopyFolder(sourceFolder, destinationFolder);
            WordDocumentTasks.ReplaceStringInAllFiles(destinationFolder, ts, vkWordApp);

            Cursor.Current = Cursors.Arrow;
            MessageBox.Show("Project Successfully Created.");
        }

        private void btnDefineClient_Click(object sender, EventArgs e)
        {
            UIClientMetadata ucm = new UIClientMetadata(this);
            ucm.Show();
        }

        private void UIClientDocumentSet_Leave(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dgvDocumentList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDelete_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode tndocSelected = tvFileList.SelectedNode;
            TreeNode parent = tndocSelected.Parent;

            if (tndocSelected == null)
                return;

            tndocSelected.Remove();

            // Update database with new sequence numbers
            //
            // UpdateSequence(parent);

            // Delete element (If it is already commited
            // The scClientDocSetDocLink is only stored for commited documents
            // The "Document" type is new one, so just ignore
            //
            if (tndocSelected.Tag.GetType().Name == "scClientDocSetDocLink")
            {
                SetToVoid( tndocSelected );
            }

            tvFileList.SelectedNode = parent;

        }

        // --------------------------------------------------
        // Each element under the main node should be deleted
        // --------------------------------------------------
        private void SetToVoid(TreeNode node)
        {
            var document = new scClientDocSetDocLink();
            document = (scClientDocSetDocLink)node.Tag;

            BUSClientDocument.SetToVoid( clientUID: Utils.ClientID, clientDocumentSetUID: document.clientDocumentSet.UID, documentUID: document.clientDocument.FKDocumentUID );
            BUSClientDocument.DeleteFile( document.clientDocument.UID );

            //document.clientDocument.SetToVoid( clientUID: Utils.ClientID, clientDocumentSetUID: document.clientDocumentSet.UID, documentUID: document.clientDocument.FKDocumentUID );
            //document.clientDocument.DeleteFile();

            ClientDocumentLinkList.VoidLinks( Utils.ClientID, document.clientDocumentSet.UID, document.clientDocument.FKDocumentUID ); 

            // Daniel: 01/06/2010
            // Remover/ Inabilitar todos os links
            // 

            foreach (TreeNode nodeToDelete in node.Nodes)
            {
                SetToVoid(nodeToDelete);
            }
        }

        // --------------------------------------------------
        // Each element under the main node should be deleted
        // --------------------------------------------------
        private void DeleteClientDocument( TreeNode node )
        {
            var document = new scClientDocSetDocLink();

            if ( node.Tag.GetType().Name != "scClientDocSetDocLink" )
                return;

            document = (scClientDocSetDocLink)node.Tag;

            ClientDocumentLinkList.DeleteLinks( Utils.ClientID, document.clientDocumentSet.UID, document.clientDocument.FKDocumentUID );
            
            // try physical delete first.
            //
            //var deleteResponse = document.clientDocument.Delete( clientUID: Utils.ClientID, clientDocumentSetUID: document.clientDocumentSet.UID, documentUID: document.clientDocument.FKDocumentUID );

            var deleteResponse = BUSClientDocument.ClientDocumentDelete(
                HeaderInfo.Instance, 
                clientUID: Utils.ClientID, 
                clientDocumentSetUID: document.clientDocumentSet.UID, 
                clientDocumentUID: document.clientDocument.UID );

            if (deleteResponse.ReturnCode < 0001)
            {
                // If it can't be physically delete, void it.
                //
                // document.clientDocument.SetToVoid( clientUID: Utils.ClientID, clientDocumentSetUID: document.clientDocumentSet.UID, documentUID: document.clientDocument.FKDocumentUID );

                BUSClientDocument.SetToVoid( clientUID: Utils.ClientID, clientDocumentSetUID: document.clientDocumentSet.UID, documentUID: document.clientDocument.FKDocumentUID );

                // If the document can't be physically deleted it is likely that is has versions (issues).
                // In this scenario the document will be set to void but the issues will remain active.

            }

            // Determine file location
            //

            //document.clientDocument.DeleteFile();

            BUSClientDocument.DeleteFile(document.clientDocument.UID);

            // Daniel: 01/06/2010
            // Remover/ Inabilitar todos os links
            // 

            foreach (TreeNode nodeToDelete in node.Nodes)
            {
                DeleteClientDocument( nodeToDelete );
            }
        }



        private void tvDocumentsAvailable_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void tvFileList_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void tvFileList_DragDrop(object sender, DragEventArgs e)
        {
            AddDocumentToClient(sender, e);
        }

        private void AddDocumentToClient(object sender, DragEventArgs e)
        {
            // Get selected document from tree
            //
            TreeNode tnDocumentAvailableSelected = tvDocumentsAvailable.SelectedNode;
            if (tnDocumentAvailableSelected == null)
                return;

            tndocSelected = tvFileList.SelectedNode;

            Document documentSelected = (Document)tnDocumentAvailableSelected.Tag;
            //  tndocselected.ComboIssueNumber = tndocselected.CUID + "-00-" + Utils.ClientID.ToString( "0000" ) + "-00";


            // Only if client document is selected
            // If it is a document from the regular set, keep it
            //
            if ( documentSelected.Name.Substring( 0, 3 ) == "CLI" )
            {
                documentSelected.Name = documentSelected.CUID +
                                        "-00-" +
                                        Utils.ClientID.ToString("0000") +
                                        "-00" +
                                        " " +
                                        documentSelected.SimpleFileName;
            }

            // tndocselected.FileName = tndocselected.Name;
            documentSelected.FileName = documentSelected.FileName;

            tnDocumentAvailableSelected.Text = documentSelected.Name;

            #region Available Selected
            // If root hasn't been created
            //
            if (tvFileList.Nodes.Count == 0)
            #region Create Root Node
            {
                // Add root node
                //
                ClientDocument clientDocument = new ClientDocument();
                // clientDocument.AddRootFolder(Utils.ClientID, Utils.ClientSetID, txtDestinationFolder.Text);

                BUSClientDocument.AddRootFolder( clientDocument, Utils.ClientID, Utils.ClientSetID, txtDestinationFolder.Text );
                
                loadDocumentList();

                // Remove from available tree
                //
                tnDocumentAvailableSelected.Remove();

                // Save to client tree
                //
                tvFileList.TopNode.Nodes.Add(tnDocumentAvailableSelected);

            }
            #endregion Create Root Node
            else
            #region Root Node Exists
            {

                if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
                {
                    Point pt;
                    TreeNode destinationNode;
                    pt = tvFileList.PointToClient(new Point(e.X, e.Y));
                    destinationNode = tvFileList.GetNodeAt(pt);
                    if (destinationNode == null)
                        return;
                    var destFolder = new scClientDocSetDocLink();
                    destFolder = (scClientDocSetDocLink)destinationNode.Tag;


                    if (tnDocumentAvailableSelected != null)
                    {
                        // Remove from available tree
                        //
                        tnDocumentAvailableSelected.Remove();

                        // Save to client tree
                        //
                        destinationNode.Nodes.Add(tnDocumentAvailableSelected);
                    }
                    else
                    {
                        if (tndocSelected != null)
                        {
                            // Remove from available tree
                            //
                            tndocSelected.Remove();

                            // Save to client tree
                            //
                            destinationNode.Nodes.Add(tndocSelected);
                        }
                    }

                }
            #endregion Root Node Exists
            }

            #endregion Available Selected
        }
         
        private void tvDocumentsAvailable_DragDrop(object sender, DragEventArgs e)
        {
            //
            // Get selected document from tree
            //
            TreeNode tndocSelected = tvDocumentsAvailable.SelectedNode;

            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                Point pt;
                TreeNode destinationNode;
                pt = tvDocumentsAvailable.PointToClient(new Point(e.X, e.Y));
                
                destinationNode = tvFileList.GetNodeAt(pt);

                if (tndocSelected == null)
                    return;

                // If destination tree is the same as source tree, do nothing
                if (destinationNode.TreeView == tndocSelected.TreeView)
                    return;

                // If the destination folder is the same, just move the order of
                // elements
                tndocSelected.Remove();

                destinationNode.Nodes.Add(tndocSelected);



            }

        }

        private void tvFileList_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void tvDocumentsAvailable_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void tvFileList_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
            var t = e.Node.Tag.GetType();

            if (t.Name == "scClientDocSetDocLink")
            {
                var document = (scClientDocSetDocLink)e.Node.Tag;
                string info = "Document \n" +
                              "Index: " + e.Node.Index + " \n" +
                              "Sequence Number : " + document.clientDocument.SequenceNumber + " \n" +
                              "Client Doco UID: " + document.clientDocument.UID + "\n" +
                              "Document UID: " + document.document.UID + "\n" +
                              "Document CUID: " + document.document.CUID + "\n" +
                              "Parent UID: " + document.clientDocument.ParentUID + "\n" +
                              "Client Source File Name: " + document.clientDocument.SourceFileName + "\n" +
                              "Client Report Type: " + document.clientDocument.RecordType;

                toolTip1.Show(info, tvFileList, 400, 10, 20000);
            }

            if (t.Name == "Document")
            {
                var document = (Document)e.Node.Tag;
                string info = "Document \n" +
                              "Document UID: " + document.UID + "\n" +
                              "Document CUID: " + document.CUID + "\n";

                toolTip1.Show(info, tvFileList, 400, 10, 20000);
            }

        }

        private void addRootToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var clientDocument = new ClientDocument();
            //clientDocument.AddRootFolder(Utils.ClientID, Utils.ClientSetID, txtDestinationFolder.Text);

            BUSClientDocument.AddRootFolder( clientDocument, Utils.ClientID, Utils.ClientSetID, txtDestinationFolder.Text );
            
            loadDocumentList();

        }

        private void picUp_Click(object sender, EventArgs e)
        {
            //
            // Get selected document from tree
            //
            TreeNode tndocSelected = tvFileList.SelectedNode;
            TreeNode parent = tndocSelected.Parent;

            if (tndocSelected.Index > 0)
            {
                int i = tndocSelected.Index - 1;
                tndocSelected.Remove();
                parent.Nodes.Insert(i, tndocSelected);

                tvFileList.SelectedNode = tndocSelected;

                // Update sequence number
                var document = new scClientDocSetDocLink();
                document = (scClientDocSetDocLink)tndocSelected.Tag;
                document.clientDocument.SequenceNumber = tndocSelected.Index;

            }
        }

        private void picDown_Click(object sender, EventArgs e)
        {
            //
            // Get selected document from tree
            //
            TreeNode tndocSelected = tvFileList.SelectedNode;
            TreeNode parent = tndocSelected.Parent;

            int i = tndocSelected.Index + 1;
            tndocSelected.Remove();
            parent.Nodes.Insert(i, tndocSelected);

            tvFileList.SelectedNode = tndocSelected;

            // Update sequence number
            var document = new scClientDocSetDocLink();
            document = (scClientDocSetDocLink)tndocSelected.Tag;
            document.clientDocument.SequenceNumber = tndocSelected.Index;
        }

        private void btnDelete_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        // ------------------------------------------------------
        //          Select all documents for a client
        // ------------------------------------------------------
        private void btnCopyAll_Click(object sender, EventArgs e)
        {
            CopyAll();

            SelectedIndexChange();

            // Clear nodes
            tvDocumentsAvailable.Nodes.Clear();
            var docoList = new DocumentList();
            docoList.List();

            // Reload Available Documents
            //
            Document root = new Document();
            // root.GetRoot(HeaderInfo.Instance);

            // root = RepDocument.GetRoot(HeaderInfo.Instance);

            root = BUSDocument.GetRootDocument();

            DocumentList.ListInTree(tvDocumentsAvailable, docoList, root);
        }

        // This method copies all documents to a client
        //
        private void CopyAll()
        {
            tsbtnDelete.Enabled = false;
            tsbtnCopyAll.Enabled = false;

            if (tvFileList.Nodes.Count <= 0)
            {
                ClientDocument clientDocument = new ClientDocument();
                // clientDocument.AddRootFolder(Utils.ClientID, Utils.ClientSetID, txtDestinationFolder.Text);
                //clientDocument.AddRootFolder(Utils.ClientID, Utils.ClientSetID, txtFolderOnly.Text);

                BUSClientDocument.AddRootFolder( clientDocument, Utils.ClientID, Utils.ClientSetID, txtFolderOnly.Text );
                
                loadDocumentList();

            }

            while (tvDocumentsAvailable.Nodes[0].Nodes.Count > 0)
            {
                TreeNode tn = tvDocumentsAvailable.Nodes[0].Nodes[0];
                tn.Remove();

                //TreeNode clone = new TreeNode();
                //clone = (TreeNode)tn.Clone();

                tvFileList.Nodes[0].Nodes.Add(tn);
            }

            tvFileList.SelectedNode = tvFileList.Nodes[0];

            // -------------------------------------------------------------------
            // The documents have been moved from the available to client's tree
            // Now it is time to save the documents
            // -------------------------------------------------------------------
            Save();

            ClientDocumentLink cloneLinks = new ClientDocumentLink();
            cloneLinks.ReplicateDocSetDocLinkToClient(Utils.ClientID, Utils.ClientSetID, documentSet.UID);

            indexChanged();
        }

        private void viewDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
            // Get selected document from tree
            //
            TreeNode docSelected = tvFileList.SelectedNode;
            var rm = new scClientDocSetDocLink();

            if (docSelected == null)
                return;

            rm = (scClientDocSetDocLink)docSelected.Tag; // Cast 

            Utils.OpenDocument( 
                rm.clientDocument.Location, 
                rm.clientDocument.FileName,
                rm.clientDocument.DocumentType, 
                vkReadOnly: true);
        
        }

        private void documentsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void tsbtnRemoveDocument_Click(object sender, EventArgs e)
        {
            TreeNode tndocSelected = tvFileList.SelectedNode;
            TreeNode parent = tndocSelected.Parent;

            if (tndocSelected == null)
            {
                return;
            }
            else
            {
                var results = MessageBox.Show("Are you sure?", "Confirm document delete", MessageBoxButtons.YesNo);

                if (results == DialogResult.Yes)
                {
                    tndocSelected.Remove();

                    // Delete element (If it is already commited
                    // The scClientDocSetDocLink is only stored for commited documents
                    // The "Document" type is new one, so just ignore
                    //
                    if (tndocSelected.Tag.GetType().Name == "scClientDocSetDocLink")
                    {
                        SetToVoid(tndocSelected);
                    }

                    tvFileList.SelectedNode = parent;
                }
            }
        }

        private void RemoveDocument(object sender, EventArgs e)
        {
            TreeNode tndocSelected = tvFileList.SelectedNode;
            if (tndocSelected == null)
                return;

            TreeNode parent = tndocSelected.Parent;

            if (tndocSelected == null)
            {
                return;
            }
            else
            {

                // Check if document set is completed. Do not allow changes.
                //

                if (labelStatus.Text == "COMPLETED")
                {
                    MessageBox.Show("Document set is finalised. It can't be changed.");
                    return;
                }
                
                var results = MessageBox.Show("Are you sure?", "Confirm document delete", MessageBoxButtons.YesNo);

                if (results == DialogResult.Yes)
                {
             
                    // Delete element (If it is already commited
                    // The scClientDocSetDocLink is only stored for commited documents
                    // The "Document" type is new one, so just ignore
                    //
                    if (tndocSelected.Tag.GetType().Name == "scClientDocSetDocLink")
                    {
                        // SetToVoid(tndocSelected);
                        DeleteClientDocument( tndocSelected );
                    }

                    tvFileList.SelectedNode = parent;

                    // Remove after
                    //
                    tndocSelected.Remove();


                }
            }

            // Refresh screen
            indexChanged();

        }


        private void tvFileList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
            if (labelStatus.Text != "COMPLETED")
            {
                tsbtnDelete.Enabled = true;
                tsbtnDown.Enabled = true;
                tsbtnUp.Enabled = true;
            }
            //
            // Get selected document from tree
            //
            TreeNode docSelected = tvFileList.SelectedNode;
            var rm = new scClientDocSetDocLink();

            if (docSelected == null)
                return;


            if (docSelected.Tag is scClientDocSetDocLink)
            {
                rm = (scClientDocSetDocLink)docSelected.Tag; // Cast 

                if (rm.document.DocumentType == MackkadoITFramework.Helper.Utils.DocumentType.PDF)
                {

                    string  filePathName = Utils.getFilePathName(  rm.clientDocument.Location, rm.clientDocument.FileName );

                    // webBrowser1.Url = new Uri( filePathName );
                    //webBrowser1.Navigate( filePathName );
                    //webBrowser1.AllowWebBrowserDrop = true;
                }


                // Display full path on status bar
                //

                var parentLocation = BUSClientDocument.GetClientDocumentLocation(rm.clientDocument.ParentUID);

                // toolStripStatusLabel1.Text = rm.clientDocument.Location;
                // toolStripStatusLabel1.Text = "CD: " + rm.clientDocument.Location + " >> PL: " + parentLocation;
                toolStripStatusLabel1.Text = rm.clientDocument.Location;
            
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvFileList_Leave(object sender, EventArgs e)
        {
            tsbtnDelete.Enabled = false;
            tsbtnDown.Enabled = false;
            tsbtnUp.Enabled = false;

        }

        //
        // Delete action - toolbar
        //
        private void toolStripButton3_Click(object sender, EventArgs e)
        {

        }

        private void viewDocumentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //
            // Get selected document from tree
            //
            TreeNode docSelected = tvProjectPlan.SelectedNode;
            var rm = new ClientDocumentLink(); 

            if (docSelected == null)
                return;

            rm = (ClientDocumentLink)docSelected.Tag; // Cast 
            if (rm.childClientDocument.RecordType.Trim() == FCMConstant.RecordType.DOCUMENT)
            {
                string filePathName =
                       Utils.getFilePathName(txtDestinationFolder.Text +
                                             rm.childClientDocument.Location,
                                             rm.childClientDocument.FileName);

                WordDocumentTasks.OpenDocument(filePathName, vkReadOnly: true);
            }

        }

        // Document List index change
        //
        private void cbxDocSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectIndexChanged();
        }

        // This index handles the document list
        //
        private void SelectIndexChanged()
        {

            int documentSetUID = 0;

            if (string.IsNullOrEmpty(cbxDocSet.Text) ||
                cbxDocumentSet.Visible == false)
            {
                documentSetUID = 0;
            }
            else
            {
                string[] ArrayDocSetText = cbxDocSet.Text.Split(';');

                documentSetUID = Convert.ToInt32(ArrayDocSetText[0]);
            }

            if (documentSetUID == 0)
                loadDocumentList();
            else
            {
                if (documentSetUID == 99)
                {
                    // Load document specific for a client
                    //
                    loadDocumentListClient();

                }
                else
                {
                    loadDocumentList(documentSetUID);
                }
            }
        }

        // 
        // Load document list for a client set
        //
        public void loadDocumentList(int documentSetUID = 0)
        {

            // Image list
            //
            ImageList imageList = ControllerUtils.GetImageList();

            // Binding
            tvDocumentsAvailable.ImageList = imageList;

            // Clear nodes
            tvDocumentsAvailable.Nodes.Clear();

            // List Document Set
            documentSet.UID = documentSetUID;
            documentSet.Read(IncludeDocuments: 'Y');

            // Load document in the treeview
            //
            Document root = new Document();
            root.CUID = "ROOT";
            root.RecordType = FCMConstant.RecordType.FOLDER;
            root.UID = 0;
            // root.Read();

            // root = RepDocument.Read(false, 0, "ROOT");
            root = BUSDocument.GetRootDocument();

            DocumentList.ListInTree(tvDocumentsAvailable, documentSet.documentList, root);
            tvDocumentsAvailable.Nodes[0].Expand();
        }

        //
        // Load document list for a client
        //
        // ------------------------------------------
        //            List Documents
        // ------------------------------------------
        public void loadDocumentListClient()
        {

            // Image list
            //
            ImageList imageList = ControllerUtils.GetImageList();

            // Binding
            tvDocumentsAvailable.ImageList = imageList;

            // Clear nodes
            tvDocumentsAvailable.Nodes.Clear();

            var docoList = new DocumentList();

            docoList.ListClient(Utils.ClientID);

            // Load document in the treeview
            //
            // docoList.ListInTree(tvFileList);
            Document root = new Document();
            root.CUID = "ROOT";
            root.RecordType = FCMConstant.RecordType.FOLDER;
            root.UID = 0;
            // root.Read();

            // root = RepDocument.Read(false, 0, "ROOT");
            root = BUSDocument.GetRootDocument();

            DocumentList.ListInTree(tvDocumentsAvailable, docoList, root);
            tvDocumentsAvailable.ExpandAll();

        }

        private void tsmiLinks_Click(object sender, EventArgs e)
        {
            UIClientDocumentLink uicdl = new UIClientDocumentLink(cbxClient.Text, cbxDocumentSet.Text);
            uicdl.ShowDialog();

        }

        private void tsmiAddDocument_Click(object sender, EventArgs e)
        {
            UIDocumentEdit uide = new UIDocumentEdit(this, Utils.ClientID);
            uide.ShowDialog();

        }

        private void newVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //
            // Get selected document from tree
            //
            TreeNode docSelected = tvFileList.SelectedNode;
            var rm = new scClientDocSetDocLink();

            if (docSelected == null)
                return;

            rm = (scClientDocSetDocLink)docSelected.Tag; // Cast 
            

            if (rm.clientDocument.RecordType == FCMConstant.RecordType.DOCUMENT)
            {
                if (rm.clientDocument.Generated != 'Y')
                {
                    MessageBox.Show("A version can only be created after the file is generated.");
                    return;
                }

                //var results = rm.clientDocument.NewVersion();

                var results = BUSClientDocument.NewVersion( rm.clientDocument );

                if ( !string.IsNullOrEmpty( results ) )
                {
                    MessageBox.Show("New version created: " + results);
                }
            }

            indexChanged();
        }

        private void tvDocumentsAvailable_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
            return;

            // Enable if necessary

            var t = e.Node.Tag.GetType();

            if (t.Name == "scClientDocSetDocLink")
            {
                var document = (scClientDocSetDocLink)e.Node.Tag;
                string info = "Document \n" +
                              "Index: " + e.Node.Index + " \n" +
                              "Sequence Number : " + document.clientDocument.SequenceNumber + " \n" +
                              "Client Doco UID: " + document.clientDocument.UID + "\n" +
                              "Document UID: " + document.document.UID + "\n" +
                              "Document CUID: " + document.document.CUID + "\n" +
                              "Parent UID: " + document.clientDocument.ParentUID + "\n" +
                              "Client Source File Name: " + document.clientDocument.SourceFileName + "\n" +
                              "Client Report Type: " + document.clientDocument.RecordType;

                toolTip1.Show(info, tvFileList, 400, 10, 20000);
            }

            if (t.Name == "Document")
            {
                var document = (Document)e.Node.Tag;
                string info = "Document \n" +
                              "Document UID: " + document.UID + "\n" +
                              "Document CUID: " + document.CUID + "\n"+
                              "Simple Name:   " + document.SimpleFileName + "\n"+
                              "Name:          " + document.FileName + "\n";


                toolTip1.Show(info, tvFileList, 400, 10, 20000);
            }
        }

        private void enableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ReportMetadata rmd = new ReportMetadata();
           
            //var selected = dgvClientMetadata.SelectedRows;
            //if (selected.Count > 0)
            //{
            //    GetSelectedRow(rmd, 0);
            //    rmd.Enabled = 'Y';
            //    rmd.Save();
                
            //    // Update selected row
            //    selected[0].Cells["Enabled"].Value = 'Y';
            //}
        }

        /// <summary>
        /// Retrieve selected row from client metadata
        /// </summary>
        /// <param name="rm"></param>
        /// <param name="rowSubscript"></param>
        private void GetSelectedRow(ReportMetadata rm, int rowSubscript)
        {
            //if (dgvClientMetadata.SelectedRows.Count <= 0)
            //    return;

            //if (dgvClientMetadata.SelectedRows.Count < rowSubscript)
            //    return;

            //var selectedRow = dgvClientMetadata.SelectedRows;

            //ConvertSelectedRow(rm, selectedRow[rowSubscript]);

            //return;
        }


        private void ConvertSelectedRow(ReportMetadata rm, DataGridViewRow selectedRow)
        {

            rm.UID = Convert.ToInt32(selectedRow.Cells["UID"].Value.ToString());
            rm.RecordType = selectedRow.Cells["RecordType"].Value.ToString();
            rm.FieldCode = selectedRow.Cells["FieldCode"].Value.ToString();
            rm.Description = selectedRow.Cells["Description"].Value.ToString();
            rm.ClientType = selectedRow.Cells["ClientType"].Value.ToString();
            rm.ClientUID = Convert.ToInt32(selectedRow.Cells["ClientUID"].Value.ToString());
            rm.InformationType = selectedRow.Cells["InformationType"].Value.ToString();
            rm.Condition = selectedRow.Cells["Condition"].Value.ToString();
            rm.CompareWith = selectedRow.Cells["CompareWith"].Value.ToString();
            rm.Enabled = Convert.ToChar(selectedRow.Cells["Enabled"].Value);

            return;
        }

        private void disableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ReportMetadata rmd = new ReportMetadata();

            //var selected = dgvClientMetadata.SelectedRows;
            //if (selected.Count > 0)
            //{
            //    GetSelectedRow(rmd, 0);
            //    rmd.Enabled = 'N';
            //    rmd.Save();

            //    // Update selected row
            //    selected[0].Cells["Enabled"].Value = 'N';
            //}

        }

        private void selectToolStripMenuItem_Click( object sender, EventArgs e )
        {

            //
            // Get selected document from tree
            //
            // 01-Jan-2012 - Commented out after removal of client metadata
            //

            //TreeNode docSelected = tvMetadata.SelectedNode;
            //var rmd = new ReportMetadata();

            //if (docSelected == null)
            //    return;

            //rmd = (ReportMetadata)docSelected.Tag; 
            //rmd.Enabled = 'Y';
            //rmd.Save();

            //docSelected.ImageIndex = FCMConstant.Image.Checked;
            //docSelected.SelectedImageIndex = FCMConstant.Image.Checked;
        }

        private void unselectToolStripMenuItem_Click( object sender, EventArgs e )
        {
            //
            // Get selected document from tree
            //
            // 01-Jan-2012
            // Removed after client metadata
            //

            //TreeNode docSelected = tvMetadata.SelectedNode;
            //var rmd = new ReportMetadata();

            //if (docSelected == null)
            //    return;

            //rmd = (ReportMetadata)docSelected.Tag;
            //rmd.Enabled = 'N';
            //rmd.Save();

            //docSelected.ImageIndex = FCMConstant.Image.Unchecked;
            //docSelected.SelectedImageIndex = FCMConstant.Image.Unchecked;
        }

        /// <summary>
        /// Double click to change the state of the field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvMetadata_DoubleClick( object sender, EventArgs e )
        {
            //
            // Get selected document from tree
            //
            //TreeNode docSelected = tvMetadata.SelectedNode;
            //var rmd = new ReportMetadata();

            //if (docSelected == null)
            //    return;

            //rmd = (ReportMetadata)docSelected.Tag;
            
            //if (rmd == null)
            //    return;

            //if (rmd.Enabled == 'Y')
            //{
            //    rmd.Enabled = 'N';
            //    docSelected.Checked = false;
            //    docSelected.ImageIndex = FCMConstant.Image.Unchecked;
            //    docSelected.SelectedImageIndex = FCMConstant.Image.Unchecked;
            //}
            //else
            //{
            //    rmd.Enabled = 'Y';
            //    docSelected.ImageIndex = FCMConstant.Image.Checked;
            //    docSelected.SelectedImageIndex = FCMConstant.Image.Checked;
            //}
            //rmd.Save();

        }

        private void printToolStripMenuItem_Click( object sender, EventArgs e )
        {
            //
            // Get selected document from tree
            //
            TreeNode docSelected = tvFileList.SelectedNode;
            var rm = new scClientDocSetDocLink();

            if (docSelected == null)
                return;

            PrintDocument( docSelected );
        }

        /// <summary>
        /// Print document or complete folder list
        /// </summary>
        /// <param name="document"></param>
        public void PrintDocument( TreeNode docSelected )
        {

            var rm = new scClientDocSetDocLink();

            rm = (scClientDocSetDocLink)docSelected.Tag; // Cast 

            if (rm.document.DocumentType == MackkadoITFramework.Helper.Utils.DocumentType.FOLDER)
            {
                foreach (TreeNode tn in docSelected.Nodes)
                {
                    // Print Document
                    var docToPrint = new scClientDocSetDocLink();
                    docToPrint = (scClientDocSetDocLink)docSelected.Tag;

                    PrintDocument( tn );
                }
            }
            else
            {
                Utils.PrintDocument( rm.clientDocument.Location, 
                                     rm.clientDocument.FileName, 
                                     rm.clientDocument.DocumentType );

            }

        }

        private void tvProjectPlan_MouseDown( object sender, MouseEventArgs e )
        {
            if (e.Button == MouseButtons.Right)
            {
                tvProjectPlan.SelectedNode = tvProjectPlan.GetNodeAt( e.X, e.Y );
            } 
        }

        private void tvFileList_MouseDown( object sender, MouseEventArgs e )
        {
            if (e.Button == MouseButtons.Right)
            {
                tvFileList.SelectedNode = tvFileList.GetNodeAt( e.X, e.Y );
            } 
        }

        private void tvDocumentsAvailable_MouseDown( object sender, MouseEventArgs e )
        {
            if (e.Button == MouseButtons.Right)
            {
                tvDocumentsAvailable.SelectedNode = tvDocumentsAvailable.GetNodeAt( e.X, e.Y );
            } 
        }

        private void tvMetadata_MouseDown( object sender, MouseEventArgs e )
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    tvMetadata.SelectedNode = tvMetadata.GetNodeAt( e.X, e.Y );
            //} 
        }

        private void gbDocuments_Enter( object sender, EventArgs e )
        {

        }

        private void tsbtnRefresh_Click( object sender, EventArgs e )
        {
            indexChanged();
        }

        private void showDetailsToolStripMenuItem_Click( object sender, EventArgs e )
        {

        }

        //
        // Implementing UIOutput implementation
        //

        public void AddOutputMessage( string outputMessage, string processName, string userID)
        {
            string msg = userID + " > " + processName + " > " + DateTime.Now + " > " + outputMessage;
            if (outputMessage.Length > 63)
                msg = outputMessage.Substring( 0, 63 );

            //notifyIcon1.Text = msg;

            toolStripStatusLabel1.Text = msg;

            LogFile.WriteToTodaysLogFile( msg );

            return;
        }
        public void AddErrorMessage( string errorMessage, string processName, string userID )
        {

            return;
        }
        public void UpdateProgressBar( double value, DateTime estimatedTime, int documentsToBeGenerated = 0 )
        {

            // toolStripProgressBar1.Value = (int)value;

            return;
        }

        private void googleDocsToolStripMenuItem_Click( object sender, EventArgs e )
        {
            UIGoogleDocs uigoogledocs = new UIGoogleDocs( txtDestinationFolder.Text );
            uigoogledocs.Show();
        }

        private void locateInExploreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
            // Get selected document from tree
            //
            TreeNode docSelected = tvFileList.SelectedNode;
            var rm = new scClientDocSetDocLink();

            if (docSelected == null)
                return;

            rm = (scClientDocSetDocLink)docSelected.Tag; // Cast 

            // Show file dialog
            string filePathName = Utils.getFilePathName(rm.clientDocument.Location, rm.clientDocument.FileName);
            string filePath = Utils.GetPathName(rm.clientDocument.Location);

            openFileDialog1.FileName = rm.clientDocument.FileName;
            openFileDialog1.InitialDirectory = filePath;

            var file = openFileDialog1.ShowDialog();

        }

        private void EnableDisableFields()
        {

            saveToolStripMenuItem.Enabled = true;
            removeToolStripMenuItem1.Enabled = true;
            addToolStripMenuItem.Enabled = true;
            generateToolStripMenuItem.Enabled = true;
            defineElementsToolStripMenuItem.Enabled = true;

            // Context
            removeToolStripMenuItem.Enabled = true;
            generateToolStripMenuItem1.Enabled = true;

            // Toolbar
            tsbtnGenerateDocument.Enabled = true;
            tsbtnNew.Enabled = true;
            tsbtnSave.Enabled = true;

            if (tvFileList.Nodes.Count == 0)
            {
                tsbtnDelete.Enabled = true;
                tsbtnCopyAll.Enabled = true;
            }

            if (labelStatus.Text == FCMConstant.DocumentSetStatus.COMPLETED)
            {
                saveToolStripMenuItem.Enabled = false;
                removeToolStripMenuItem1.Enabled = false;
                addToolStripMenuItem.Enabled = false;
                generateToolStripMenuItem.Enabled = false;
                defineElementsToolStripMenuItem.Enabled = false;

                // Context
                removeToolStripMenuItem.Enabled = false;
                generateToolStripMenuItem1.Enabled = false;

                // Toolbar
                tsbtnGenerateDocument.Enabled = false;
                tsbtnCopyAll.Enabled = false;
                tsbtnDelete.Enabled = false;
                tsbtnNew.Enabled = false;
                tsbtnSave.Enabled = false;


            }
        }

        private void menuItemGenerateMOS_Click(object sender, EventArgs e)
        {
            // Generate master of system documents
            //


            //var answer = MessageBox.Show(
            //    "Would you like to proceed? (Y/N)",
            //"Register of System Documents",
            //MessageBoxButtons.YesNo);

            //if (answer != DialogResult.Yes)
            //{
            //    return;
            //}

            //var uioutput = new Windows.UIOutputMessage();
            //uioutput.Show();
            //uioutput.WindowState = FormWindowState.Maximized;

            //WordReport wr = new WordReport(ClientID: Utils.ClientID, ClientDocSetID: Utils.ClientSetID,
            //                                                UIoutput: uioutput,
            //                                                OverrideDocuments: overrideDocuments);

            //var fileName = wr.RegisterOfSytemDocuments(tvFileList, txtDestinationFolder.Text, wr.FullFileNamePath);

            //UIDocumentEdit uide = new UIDocumentEdit(fileName: wr.FileName, 
            //                                         fullPathFileName: wr.FullFileNamePath,
            //                                         clientUID: Utils.ClientID);
            //uide.Show();


        }

        private void showFullPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UpdateDocumentLocation();
            Cursor.Current = Cursors.Arrow;
        }

       
        /// <summary>
        /// Update document location
        /// </summary>
        private void UpdateDocumentLocation()
        {
            //
            // Get selected document from tree
            //
            TreeNode docSelected = tvFileList.SelectedNode;
            var rm = new scClientDocSetDocLink();

            if (docSelected == null)
                return;

            rm = (scClientDocSetDocLink)docSelected.Tag; // Cast 

            var pathResult = BUSClientDocumentGeneration.UpdateLocation(rm.clientDocument.FKClientUID, rm.clientDocument.FKClientDocumentSetUID);

            string path = pathResult.Contents.ToString();

            MessageBox.Show(path);

        }

        private void editDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
            // Get selected document from tree
            //
            TreeNode docSelected = tvFileList.SelectedNode;
            var rm = new scClientDocSetDocLink();

            if (docSelected == null)
                return;

            rm = (scClientDocSetDocLink)docSelected.Tag; // Cast 

            Utils.OpenDocument(
                rm.clientDocument.Location, 
                rm.clientDocument.FileName, 
                rm.clientDocument.DocumentType,
                vkReadOnly: false);
        
        }

        /// <summary>
        /// Retrieve values from cache
        /// </summary>
        private void GetValuesFromCache()
        {
            // Get screen values from cache
            //

            #region ClientDocumentList 
            // ----------------------------------------
            // Get font size for client document list
            // ----------------------------------------
            var userSettingsCache = new UserSettings();
            userSettingsCache.FKUserID = Utils.UserID;
            userSettingsCache.FKScreenCode = ScreenCode;
            userSettingsCache.FKControlCode = FCMConstant.ScreenControl.TreeViewClientDocumentList;
            userSettingsCache.FKPropertyCode = FCMConstant.ScreenProperty.FontSize;

            var stringValue = Utils.UserSettingGetCacheValue(userSettingsCache);

            if (string.IsNullOrEmpty(stringValue))
                stringValue = "8.25";

            // Convert to float
            tvClientDocumentListFontSize = float.Parse(stringValue);

            tvFileList.Font =
               new System.Drawing.Font("Microsoft Sans Serif",
                   tvClientDocumentListFontSize,
                   System.Drawing.FontStyle.Regular,
                   System.Drawing.GraphicsUnit.Point,
                   ((System.Byte)(0)));
            // ----------------------------------------

            // ----------------------------------------
            // Get icon size for client document list
            // ----------------------------------------
            userSettingsCache.FKPropertyCode = FCMConstant.ScreenProperty.IconSize;

            var stringIconSize = Utils.UserSettingGetCacheValue(userSettingsCache);

            if (string.IsNullOrEmpty(stringIconSize))
                stringIconSize = "16";

            if (stringIconSize == "16")
                tvFileList.ImageList = imageList;

            if (stringIconSize == "32")
                tvFileList.ImageList = imageList32;

            #endregion ClientDocumentList

            #region Available Documents
            // ----------------------------------------
            // Get font size for Available Documents List
            // ----------------------------------------
            var userSettingsCacheAD = new UserSettings();
            userSettingsCacheAD.FKUserID = Utils.UserID;
            userSettingsCacheAD.FKScreenCode = ScreenCode;
            userSettingsCacheAD.FKControlCode = FCMConstant.ScreenControl.TreeViewClientDocumentListDocSet;
            userSettingsCacheAD.FKPropertyCode = FCMConstant.ScreenProperty.FontSize;

            var stringValueAD = Utils.UserSettingGetCacheValue(userSettingsCacheAD);

            if (string.IsNullOrEmpty(stringValueAD))
                stringValueAD = "8.25";

            // Convert to float
            tvClientDocumentListADFontSize = float.Parse(stringValueAD);

            tvDocumentsAvailable.Font =
               new System.Drawing.Font("Microsoft Sans Serif",
                   tvClientDocumentListADFontSize,
                   System.Drawing.FontStyle.Regular,
                   System.Drawing.GraphicsUnit.Point,
                   ((System.Byte)(0)));
            // ----------------------------------------

            // ----------------------------------------
            // Get icon size for client document list
            // ----------------------------------------
            userSettingsCacheAD.FKPropertyCode = FCMConstant.ScreenProperty.IconSize;

            var stringADIconSize = Utils.UserSettingGetCacheValue(userSettingsCacheAD);

            if (string.IsNullOrEmpty(stringADIconSize))
                stringADIconSize = "16";

            if (stringADIconSize == "16")
                tvDocumentsAvailable.ImageList = imageList;

            if (stringADIconSize == "32")
                tvDocumentsAvailable.ImageList = imageList32;

            #endregion Available Documents
        }

        //--------------------------------------------------------------------
        //
        //          ICON and FONT sizes
        //
        //-------------------------------------------------------------------- 

        /// <summary>
        /// Update font size for AVAILABLE DOCUMENTS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmTVAvailableDocumentsListFontSizeSet(object sender, EventArgs e)
        {

            float size = 8.25F;

            ToolStripMenuItem b = (ToolStripMenuItem)sender;
            switch (b.Name)
            {
                case "tsmDocSetFontSize825":
                    size = 8.25F;
                    break;
                case "tsmDocSetFontSize12":
                    size = 12F;
                    break;
                case "tsmDocSetFontSize14":
                    size = 14F;
                    break;
            }

            tvDocumentsAvailable.Font =
               new System.Drawing.Font("Microsoft Sans Serif",
                                       size,
                                       System.Drawing.FontStyle.Regular,
                                       System.Drawing.GraphicsUnit.Point,
                                       ((System.Byte)(0)));

            // Save setting (Font Size to 8.25)
            //
            var userSetting = new UserSettings();
            userSetting.FKUserID = Utils.UserID;
            userSetting.FKScreenCode = this.ScreenCode;
            userSetting.FKControlCode = FCMConstant.ScreenControl.TreeViewClientDocumentListDocSet;
            userSetting.FKPropertyCode = FCMConstant.ScreenProperty.FontSize;
            userSetting.Value = size.ToString();

            BUSUserSetting.Save(userSetting);
        }

        /// <summary>
        /// Set icon size for AVAILABLE DOCUMENTS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmTVAvailableDocumentsListIconSizeSet(object sender, EventArgs e)
        {

            var userSetting = new UserSettings();
            userSetting.Value = "16";

            ToolStripMenuItem b = (ToolStripMenuItem)sender;

            switch (b.Name)
            {
                case "tsmDocumentSetVIewIconSize16":
                    tvDocumentsAvailable.ImageList = imageList;
                    tvDocumentsAvailable.Refresh();
                    userSetting.Value = "16";

                    break;
                case "tsmDocumentSetVIewIconSize32":
                    tvDocumentsAvailable.ImageList = imageList32;
                    tvDocumentsAvailable.Refresh();
                    userSetting.Value = "32";
                    break;
            }

            // Save setting 
            //
            userSetting.FKUserID = Utils.UserID;
            userSetting.FKScreenCode = this.ScreenCode;
            userSetting.FKControlCode = FCMConstant.ScreenControl.TreeViewClientDocumentListDocSet;
            userSetting.FKPropertyCode = FCMConstant.ScreenProperty.IconSize;
            BUSUserSetting.Save(userSetting);


        }

        /// <summary>
        /// Update font size for client document list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmTVFileListFontSizeSet_Click(object sender, EventArgs e)
        {

            float size = 8.25F;

            ToolStripMenuItem b = (ToolStripMenuItem)sender;
            switch (b.Name)
            {
                case "tsmFontSize825":
                    size = 8.25F;
                    break;
                case "tsmFontSize12":
                    size = 12F;
                    break;
                case "tsmFontSize14":
                    size = 14F;
                    break;
            }

            tvFileList.Font =
               new System.Drawing.Font("Microsoft Sans Serif",
                                       size,
                                       System.Drawing.FontStyle.Regular,
                                       System.Drawing.GraphicsUnit.Point,
                                       ((System.Byte)(0)));

            // Save setting (Font Size to 8.25)
            //
            var userSetting = new UserSettings();
            userSetting.FKUserID = Utils.UserID;
            userSetting.FKScreenCode = this.ScreenCode;
            userSetting.FKControlCode = FCMConstant.ScreenControl.TreeViewClientDocumentList;
            userSetting.FKPropertyCode = FCMConstant.ScreenProperty.FontSize;
            userSetting.Value = size.ToString();

            BUSUserSetting.Save(userSetting);
        }

        /// <summary>
        /// Set icon size for File List Tree View
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmTVFileListIconSizeSet(object sender, EventArgs e)
        {

            var userSetting = new UserSettings();
            userSetting.Value = "16";

            ToolStripMenuItem b = (ToolStripMenuItem)sender;

            switch (b.Name)
            {
                case "x16DefaultToolStripMenuItem":
                    tvFileList.ImageList = imageList;
                    tvFileList.Refresh();
                    userSetting.Value = "16";

                    break;
                case "x32ToolStripMenuItem":
                    tvFileList.ImageList = imageList32;
                    tvFileList.Refresh();
                    userSetting.Value = "32";
                    break;
            }

            // Save setting 
            //
            userSetting.FKUserID = Utils.UserID;
            userSetting.FKScreenCode = this.ScreenCode;
            userSetting.FKControlCode = FCMConstant.ScreenControl.TreeViewClientDocumentList;
            userSetting.FKPropertyCode = FCMConstant.ScreenProperty.IconSize;
            BUSUserSetting.Save(userSetting);


        }

        private void menuItemGenerateDocBackground_Click(object sender, EventArgs e)
        {
            GenerateDocument("BACKGROUND");
        }

        private void viewClientDocumentRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
                        //
            // Get selected document from tree
            //
            TreeNode docSelected = tvFileList.SelectedNode;
            var rm = new scClientDocSetDocLink();

            if (docSelected == null)
                return;

            rm = (scClientDocSetDocLink)docSelected.Tag; // Cast 

            UIClientDocumentEdit uicd = new UIClientDocumentEdit(rm.clientDocument);
            uicd.ShowDialog();

        }

        private void tsEditClientDocument_Click(object sender, EventArgs e)
        {
            //
            // Get selected document from tree
            //
            TreeNode docSelected = tvFileList.SelectedNode;
            var rm = new scClientDocSetDocLink();

            if (docSelected == null)
                return;

            rm = (scClientDocSetDocLink)docSelected.Tag; // Cast 

            Utils.OpenDocument(
                rm.clientDocument.Location,
                rm.clientDocument.FileName,
                rm.clientDocument.DocumentType,
                vkReadOnly: false);
        }

        private void tsViewSourceDocument_Click(object sender, EventArgs e)
        {
            //
            // Get selected document from tree
            //
            TreeNode docSelected = tvFileList.SelectedNode;
            var rm = new scClientDocSetDocLink();

            if (docSelected == null)
                return;

            rm = (scClientDocSetDocLink)docSelected.Tag; // Cast 

            // Show Document Screen
            //
            UIDocumentEdit uide = new UIDocumentEdit(this, rm.document, docSelected);
            uide.ShowDialog();

        }


        /// <summary>
        /// Check if source/ destination file exists
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvFileList_Click(object sender, EventArgs e)
        {
            // Turn the source file on if the source file exists, also, turn the client destination file on
            //
            //

            //
            // Get selected document from tree
            //
            //TreeNode docSelected = tvFileList.SelectedNode;
            //var docItem = new scClientDocSetDocLink();

            //if (docSelected == null)
            //    return;

            //docItem = (scClientDocSetDocLink)docSelected.Tag; // Cast 

            //bool CheckForSourceFile = true;
            //bool CheckForDestinationFile = true;

            //if (CheckForSourceFile)
            //{
            //    // SOURCE FILE is present?
            //    // 
            //    docItem.clientDocument.SourceFilePresent = 'N';

            //    if (string.IsNullOrEmpty(docItem.clientDocument.SourceLocation))
            //    {
            //        docItem.clientDocument.SourceFilePresent = 'N';
            //    }
            //    else
            //    {
            //        string filePathName = Utils.getFilePathName(docItem.clientDocument.SourceLocation,
            //                                                    docItem.clientDocument.SourceFileName);
            //        // This is the source client file name
            //        //
            //        string clientSourceFileLocationName = Utils.getFilePathName(
            //                        docItem.clientDocument.SourceLocation.Trim(),
            //                        docItem.clientDocument.SourceFileName.Trim());

            //        if (File.Exists(clientSourceFileLocationName))
            //        {
            //            docItem.clientDocument.SourceFilePresent = 'Y';
            //        }
            //    }
            //}

            //if (CheckForDestinationFile)
            //{
            //    // DESTINATION FILE is present?
            //    // 
            //    docItem.clientDocument.DestinationFilePresent = 'N';

            //    if (string.IsNullOrEmpty(docItem.clientDocument.Location))
            //    {
            //        docItem.clientDocument.DestinationFilePresent = 'N';
            //    }
            //    else
            //    {
            //        string filePathName = Utils.getFilePathName(docItem.clientDocument.Location,
            //                                                    docItem.clientDocument.FileName);
            //        // This is the destination client file name
            //        //
            //        string clientDestinationFileLocationName = Utils.getFilePathName(
            //                        docItem.clientDocument.Location.Trim(),
            //                        docItem.clientDocument.FileName.Trim());

            //        if (File.Exists(clientDestinationFileLocationName))
            //        {
            //            docItem.clientDocument.DestinationFilePresent = 'Y';
            //        }
            //    }
            //}

            //int image = Utils.GetFileImage(docItem.clientDocument.SourceFilePresent, docItem.clientDocument.DestinationFilePresent, docItem.clientDocument.DocumentType);

            //docSelected.ImageIndex = image;

        }

        private void addNewDocumentToolStripMenuItem_Click( object sender, EventArgs e )
        {

            // Get selected document and add to the client set
            // This client document will not be related to a Document 
            //
            var file = openFileDialog1.ShowDialog();

            // Set the name of the client document
            //
            string filenameext = openFileDialog1.SafeFileName;
            var parts = filenameext.Split( '.' );
            string filenameonly = parts[0];

            string filenamefinal = "CLA" + "-00-" +
                        Utils.ClientID.ToString( "0000" ) + "-00" +
                        " " + filenameonly;


            ClientDocument clientDocument = new ClientDocument();
            clientDocument.IsLocked = 'Y';
            clientDocument.IsChecked = false;
            clientDocument.IsRoot = 'N';
            clientDocument.FileName = filenameext;
            clientDocument.ClientIssueNumber = 0;
            clientDocument.DocumentCUID = ""; // It is not related to a document. It is client specific.
            clientDocument.DocumentType = "WORD"; // Add condition, it could be EXCEL, FOLDER, 

            // Add document to tree

            // Wait for save action to save the document

            // Make sure the Document UID is not mandatory when saving the client document
            // This can cause problems in some specific file retrieves, in case of joins,
            // which I think it happens

            // Should I force the document to be added initially to the document list?
            // Maybe not because it will force unique number CLA-01, CLA-02 etc
            // 



        }

    }
}
