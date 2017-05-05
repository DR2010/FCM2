using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using FCMMySQLBusinessLibrary;
using FCMMySQLBusinessLibrary.Model.ModelDocument;
using FCMMySQLBusinessLibrary.Repository.RepositoryDocument;
using FCMMySQLBusinessLibrary.Model.ModelClient;
using FCMMySQLBusinessLibrary.FCMUtils;
using FCMMySQLBusinessLibrary.Service.SVCDocument.Service;
using FCMMySQLBusinessLibrary.Service.SVCDocument.ServiceContract;
using MackkadoITFramework.Utils;
using MackkadoITFramework.ReferenceData;
using Utils = FCMMySQLBusinessLibrary.FCMUtils.Utils;

namespace fcm.Windows
{
    public partial class UIDocumentList : Form
    {
        public DataTable elementSourceDataTable;
        private DocumentList documentList;
        public string ScreenCode;
        ImageList imageList16;
        ImageList imageList32;
        float tvClientDocumentListFontSize;
        int tvClientDocumentListIconSize;
        private string defaultActionDoubleClick;

        /// <summary>
        /// Constructor
        /// </summary>
        public UIDocumentList()
        {
            InitializeComponent();
            ScreenCode = FCMConstant.ScreenCode.DocumentList;

            GetValuesFromCache();

            btnSelect.Visible = false;
        }

        public UIDocumentList( DocumentList _documentList ) : this()
        {
            documentList = _documentList;
            documentList.documentList = new List<Document>();
            
            // If the intention is to select from the list, do not enable actions
            //
            btnSelect.Visible = true;
            // Delete
            cms2miDelete.Enabled = false;
            miDelete.Enabled = false;
            tbbtnDelete.Enabled = false;

            // New
            cms2miNewDocument.Enabled = false;

            // Links
            tsbtnLinks.Enabled = false;
            miLinkDocuments.Enabled = false;

            // Edit/ Open
            tbbtnOpen.Enabled = false;
            cms2miEdit.Enabled = false;
            miEdit.Enabled = false;

            // Image with delete
            btnDelete.AllowDrop = false;

            defaultActionDoubleClick = "Select";
        }

        private void UITemplateFiles_Load(object sender, EventArgs e)
        {
            // Get client list from background and load into the list
            //
            foreach (Client c in Utils.ClientList)
            {
                cbxClient.Items.Add(c.UID + "; " + c.Name);
            }

            // Get selected client from the background
            //
            if (cbxClient.Items.Count > 0)
            {
                cbxClient.SelectedIndex = Utils.ClientIndex;
            }
            
            cbxClient.Enabled = false;

            cbxType.Text = "FCM";
            cbxType.SelectedIndex = 0;

            miEdit.Enabled = false;
            miDelete.Enabled = false;

            // loadDocumentList();

        }

        private void treeView_ItemDrag(object sender,
            System.Windows.Forms.ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void treeView_DragEnter(object sender,
            System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        override public void Refresh()
        {
            loadDocumentList(HeaderInfo.Instance);
        }

        // ------------------------------------------
        //            List Documents
        // ------------------------------------------
        public void loadDocumentList(HeaderInfo headerInfo)
        {

            // Image list
            //
            imageList16 = ControllerUtils.GetImageList();
            imageList16.ImageSize = new Size(16, 16);

            imageList32 = ControllerUtils.GetImageList();
            imageList32.ImageSize = new Size(32, 32);

            // Binding
            tvFileList.ImageList = imageList16;

            // Clear nodes
            tvFileList.Nodes.Clear();

            var docoList = new DocumentList();

            if (cbxType.Text == "FCM")
            {
                docoList.List();
            }
            else
            {
                docoList.ListClient(Utils.ClientID);
            }

            // Load document in the treeview
            //
            // docoList.ListInTree(tvFileList);
            Document root = new Document();
            // root.GetRoot(headerInfo);

            //root = RepDocument.GetRoot(HeaderInfo.Instance);

            root = BUSDocument.GetRootDocument();

            DocumentList.ListInTree(tvFileList, docoList, root);
            tvFileList.Nodes[0].Expand();

            GetValuesFromCache();

            tvFileList.Refresh();
        }


        private void GetValuesFromCache()
        {
            // Get screen values from cache
            //

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
                tvFileList.ImageList = imageList16;

            if (stringIconSize == "32")
                tvFileList.ImageList = imageList32;
        }


        private void loadDocumentList(object sender, EventArgs e)
        {
            indexChanged();
        }

        private void btnDocumentDetails_Click(object sender, EventArgs e)
        {
            //EditMetadata(false);

        }

        private void cbxClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexChanged();
        }

        // When client is changed or the client document set is changed
        //
        private void indexChanged()
        {
            // Get selected client
            //
            // Find selected item
            // Utils.ClientIndex = cbxClient.SelectedIndex;

            // Extract client id
            if (cbxClient.SelectedIndex >= 0)
            {

                Utils.ClientID = Utils.ClientList[cbxClient.SelectedIndex].UID;

                if (cbxType.Text == "CLIENT")
                {
                    cbxClient.Enabled = true;
                }
                else
                {
                    cbxClient.Enabled = false;
                }

            }

            loadDocumentList(HeaderInfo.Instance);


        }

        private void loadDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tvFileList.Nodes.Count <= 0)
            {
                MessageBox.Show("Root node is missing. Please contact technical support.");
                return;
            }
            //
            // Get selected document from tree
            //
            TreeNode tndocSelected = tvFileList.SelectedNode;
            Document treeSelectedDoco = new Document();

            if (tndocSelected == null)
            {
                tvFileList.SelectedNode = tvFileList.Nodes[0];
                tndocSelected = tvFileList.SelectedNode;
            }
            
            treeSelectedDoco = (Document)tndocSelected.Tag; // Cast 

            var templateFolder = CodeValue.GetCodeValueExtended(MakConstant.CodeTypeString.SYSTSET, MakConstant.SYSFOLDER.TEMPLATEFOLDER);

            folderBrowserDialog1.ShowNewFolderButton = false;
            folderBrowserDialog1.SelectedPath = templateFolder;
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Desktop;

            folderBrowserDialog1.ShowDialog();

            if (string.IsNullOrEmpty(folderBrowserDialog1.SelectedPath))
                return;

            string folderSelected = folderBrowserDialog1.SelectedPath;

            var resp =
                MessageBox.Show("Load Directory", "Are you sure? ", MessageBoxButtons.YesNo);
            if (resp == DialogResult.Yes)
            {

                var uioutput = new Windows.UIOutputMessage();
                uioutput.Show();

                var response = Utils.LoadFolder(folderSelected, uioutput, treeSelectedDoco.UID, 0, HeaderInfo.Instance);
                MessageBox.Show(response.Message, "Load Folder", MessageBoxButtons.OK, response.Icon);
            }

            loadDocumentList(HeaderInfo.Instance);
        }


        // -----------------------------------------------------------
        //  Delete Document (Logical delete)
        // -----------------------------------------------------------
        private void deleteDocument(HeaderInfo headerInfo)
        {
            Document rm = new Document();

            // rm.SetToVoid(rm.UID);

            // RepDocument.SetToVoid(rm.UID);
            BUSDocument.SetToVoid(rm.UID);

            loadDocumentList(headerInfo);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        // ------------------------------------------------
        // Edit Document from Tree. Allow only Documents
        // ------------------------------------------------
        private void EditDocument(object sender, EventArgs e)
        {
            if (! string.IsNullOrEmpty(defaultActionDoubleClick ))
                if (defaultActionDoubleClick == "Select")
                {
                    this.btnSelect_Click(sender, e);
                    return;
                }
            //
            // Get selected document from tree
            //
            TreeNode docSelected = tvFileList.SelectedNode;
            var rm = new Document();

            if (docSelected == null)
                return;

            rm = (Document)docSelected.Tag; // Cast 

            // Show Document Screen
            //
            UIDocumentEdit uide = new UIDocumentEdit(this, rm, docSelected);
            uide.ShowDialog();

            docSelected.Text = rm.FileName;

        }

        private void NewDocument_Click(object sender, EventArgs e)
        {
            //
            // Get selected document from tree
            //
            TreeNode docSelected = tvFileList.SelectedNode;

            if (docSelected == null)
                return;

            Document treeSelectedDoco = new Document();
            treeSelectedDoco = (Document)docSelected.Tag; // Cast 

            // If current tree selected item is a document
            // issue an error saying that only folder can hold
            // an item
            if (treeSelectedDoco.RecordType.Trim() != FCMConstant.RecordType.FOLDER)
            {
                MessageBox.Show("Only folders allow items inside.");
                return;
            }

            // New Document or Folder being added
            //
            var document = new Document();

            // Set the parent uid as current tree selected
            // folder
            //
            document.ParentUID = treeSelectedDoco.UID;

            UIDocumentEdit uide = new UIDocumentEdit(this, document, docSelected);
            uide.ShowDialog();

            if (uide.documentSavedSuccessfully)
            {
                int im = FCMConstant.Image.Document;
                if (document.RecordType == FCMConstant.RecordType.FOLDER)
                    im = FCMConstant.Image.Folder;

                var treeNode = new TreeNode(document.Name, im, im);
                treeNode.Tag = document;
                treeNode.Name = document.UID.ToString();

                docSelected.Nodes.Add(treeNode);

            }

            Refresh();
        }

        private void ShowChangeImpact(object sender, EventArgs e)
        {
            //
            // Get selected document from tree
            //
            TreeNode docSelected = tvFileList.SelectedNode;
            Document treeSelectedDoco = new Document();
            treeSelectedDoco = (Document)docSelected.Tag; // Cast 

            // If current tree selected item is a document
            // issue an error saying that only folder can hold
            // an item
            if (treeSelectedDoco.RecordType != FCMConstant.RecordType.DOCUMENT)
            {
                MessageBox.Show("Only documents have issues/ versions.");
                return;
            }

            UIImpactedDocuments uid = new UIImpactedDocuments(treeSelectedDoco);
            uid.ShowDialog();

        }

        private void ShowDocumentIssues(object sender, EventArgs e)
        {
            //
            // Get selected document from tree
            //
            TreeNode docSelected = tvFileList.SelectedNode;
            Document treeSelectedDoco = new Document();
            treeSelectedDoco = (Document)docSelected.Tag; // Cast 

            // If current tree selected item is a document
            // issue an error saying that only folder can hold
            // an item
            if (treeSelectedDoco.RecordType != FCMConstant.RecordType.DOCUMENT)
            {
                MessageBox.Show("Only documents have issues/ versions.");
                return;
            }

            UIDocumentVersion uidi = new UIDocumentVersion(treeSelectedDoco);
            uidi.ShowDialog();

        }

        private void tvFileList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //
            // Get selected document from tree
            //
            TreeNode docSelected = tvFileList.SelectedNode;
            Document treeSelectedDoco = new Document();

            try
            {
                treeSelectedDoco = (Document)docSelected.Tag; // Cast 
            }
            catch (Exception ex)
            {
                return;
            }
            txtCUID.Text = treeSelectedDoco.CUID;
            txtUID.Text = treeSelectedDoco.UID.ToString();
            txtFileName.Text = treeSelectedDoco.FileName;
            txtIssueNumber.Text = treeSelectedDoco.IssueNumber.ToString();
            txtLocation.Text = treeSelectedDoco.Location;
            txtParentUID.Text = treeSelectedDoco.ParentUID.ToString();
            cbxSourceCode.Text = treeSelectedDoco.SourceCode;
            cbxRecordType.Text = treeSelectedDoco.RecordType;
            txtName.Text = treeSelectedDoco.Name;
            txtProjectPlan.Text = treeSelectedDoco.IsProjectPlan.ToString();

            txtIndex.Text = docSelected.Index.ToString();
            txtSeqNum.Text = treeSelectedDoco.SequenceNumber.ToString();

            miEdit.Enabled = true;
            miDelete.Enabled = true;

        }

        private void tvFileList_DragDrop(object sender, DragEventArgs e)
        {
            // Get selected document from tree
            //
            TreeNode tndocSelected = tvFileList.SelectedNode;
            Document treeSelectedDoco = new Document();
            treeSelectedDoco = (Document)tndocSelected.Tag; // Cast 

            // Clone selected document
            //
            TreeNode tndocSelectedMoved = (TreeNode)tndocSelected.Clone();
            
            Document moveToFolderLocation = new Document();

            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                Point pt;
                TreeNode destinationNode;
                pt = tvFileList.PointToClient(new Point(e.X, e.Y));
                destinationNode = tvFileList.GetNodeAt(pt);

                // If the destination folder is the same, just move the order of
                // elements

                if (tndocSelected.Parent == destinationNode.Parent)
                {
                    if (!destinationNode.Equals(tndocSelectedMoved))
                    {
                        //Insert original node to new location
                        tvFileList.Nodes.Insert(destinationNode.Index, tndocSelectedMoved);

                        //Remove original node
                        tndocSelected.Remove();
                    }
                }
                else
                {

                    // Check if destination is a folder
                    //
                    moveToFolderLocation = (Document)destinationNode.Tag;
                    if (moveToFolderLocation.RecordType != FCMConstant.RecordType.FOLDER)
                        return;

                    if (!destinationNode.Equals(tndocSelectedMoved))
                    {
                        destinationNode.Nodes.Add(tndocSelectedMoved);
                        destinationNode.Expand();
                        //Remove original node
                        tndocSelected.Remove();
                    }
                }
            }
        }

        //
        // Drag'n'Drop
        //
        private void tree_DragDrop(object sender, DragEventArgs e)
        {

            //
            // Get selected document from tree
            //
            TreeNode tndocSelected = tvFileList.SelectedNode;

            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                Point pt;
                TreeNode destinationNode;
                pt = tvFileList.PointToClient(new Point(e.X, e.Y));
                destinationNode = tvFileList.GetNodeAt(pt);

                // Get parent
                //
                if (destinationNode == null)
                    return;

                Document parent = new Document();
                parent = (Document)destinationNode.Tag;

                // Get current document
                //
                if (tndocSelected == null)
                    return;

                Document documentSelected = new Document();
                documentSelected = (Document)tndocSelected.Tag;

                // If destination is a document, only allow APPENDIX
                // If destination is a folder, allow DOCUMENT and FOLDER
                //
                if (parent.RecordType.Trim() == FCMConstant.RecordType.FOLDER)
                {
                    if (documentSelected.RecordType == FCMConstant.RecordType.DOCUMENT ||
                        documentSelected.RecordType == FCMConstant.RecordType.FOLDER)
                    {
                        // allow document or folder
                        //
                    }
                    else
                        return;
                }

                if (parent.RecordType.Trim() == FCMConstant.RecordType.DOCUMENT)
                {
                    if (documentSelected.RecordType == FCMConstant.RecordType.APPENDIX)
                    {
                        // allow appendix
                        //
                    }
                    else
                        return;
                }


                //if (parent.RecordType.Trim() != Utils.RecordType.FOLDER)
                //    return;

                // Remove node from source
                //
                tndocSelected.Remove();

                destinationNode.Nodes.Add(tndocSelected);

                // Save document details
                //


                // Get current
                Document document = new Document();
                document = (Document)tndocSelected.Tag;
                document.ParentUID = parent.UID;
                document.SequenceNumber = tndocSelected.Index;

                txtParentUID.Text = document.ParentUID.ToString();
                txtSeqNum.Text = document.SequenceNumber.ToString();

                tvFileList.SelectedNode = tndocSelected;

                SaveSequenceParent(HeaderInfo.Instance, document);

            }
        }

        // ---------------------------------------
        // Move document or folder down
        // ---------------------------------------
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

            Document document = new Document();
            document = (Document)tndocSelected.Tag;
            document.SequenceNumber = tndocSelected.Index;
            txtSeqNum.Text = document.SequenceNumber.ToString();

            // Save document details
            // SaveSequenceParent(document);

            UpdateSequence(parent);

        }

        // ---------------------------------------
        // Move document or folder up
        // ---------------------------------------
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

                // Save document details
                Document document = new Document();
                document = (Document)tndocSelected.Tag;
                document.SequenceNumber = tndocSelected.Index;
                txtSeqNum.Text = document.SequenceNumber.ToString();

                UpdateSequence(parent);

            }

        }

        // ---------------------------------------
        // Save sequence number and parent
        // ---------------------------------------
        private void SaveSequenceParent(HeaderInfo headerInfo, Document document)
        {
            // document.Save(headerInfo, FCMConstant.SaveType.UPDATE);

            //RepDocument.Save(headerInfo, document, FCMConstant.SaveType.UPDATE);

            var documentSaveRequest = new DocumentSaveRequest();
            documentSaveRequest.inDocument = document;
            documentSaveRequest.headerInfo = HeaderInfo.Instance;
            documentSaveRequest.saveType = FCMConstant.SaveType.UPDATE;

            var resp = BUSDocument.DocumentSave(documentSaveRequest);
            document.UID = resp.document.UID;

        }

        private void UIDocumentList_DragDrop(object sender, DragEventArgs e)
        {


        }

        private void tvFileList_DragLeave(object sender, EventArgs e)
        {

        }

        private void btnDelete_DragEnter(object sender, DragEventArgs e)
        {
           e.Effect = DragDropEffects.Move;

        }

        // ----------------------------------------------
        //  Removing an element from the tree
        // ----------------------------------------------
        private void btnDelete_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode tndocSelected = tvFileList.SelectedNode;
            TreeNode parent = tndocSelected.Parent;

            tndocSelected.Remove();
            
            // Update database with new sequence numbers
            //
            UpdateSequence(parent);

            // Delete element
            Document document = new Document();
            document = (Document)tndocSelected.Tag;
            // document.SetToVoid(document.UID);

            // RepDocument.SetToVoid(document.UID);

            BUSDocument.SetToVoid(document.UID);

            tvFileList.SelectedNode = parent;
        }

        // ----------------------------------------------
        // After an element has been draged away, update 
        // remaining sequence numbers
        // ----------------------------------------------
        private void UpdateSequence(TreeNode parent)
        {
            foreach (TreeNode node in parent.Nodes)
            {
                TreeNode parentNode = node.Parent;

                // Cast current document
                Document document = new Document();
                document = (Document)node.Tag;

                // Get parent
                Document parentDoco = new Document();
                parentDoco = (Document)parentNode.Tag;

                document.SequenceNumber = node.Index;
                document.ParentUID = parentDoco.UID;

                SaveSequenceParent(HeaderInfo.Instance, document);
                
            }


        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tvFileList_MouseHover(object sender, EventArgs e)
        {
        }

        private void tvFileList_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
            //Document document = (Document)e.Node.Tag;
            //string info = "Document \n" +
            //              document.CUID + "\n" +
            //              document.UID + "\n" +
            //              document.Name + "\n";
            //toolTip1.Show(info, tvFileList, 10, 10, 20000);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            TreeNode tndocSelected = tvFileList.SelectedNode;

            if (tndocSelected != null)
            {
                if (tndocSelected.Tag.GetType().Name == "Document")
                {
                    Document document = (Document)tndocSelected.Tag;
                    documentList.documentList.Add(document);

                    this.Dispose();
                }
            }
        }

        /// <summary>
        /// Delete document selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteDocument_Click(object sender, EventArgs e)
        {
            
            var resp =
            MessageBox.Show("Are you sure?", "Delete Document", MessageBoxButtons.YesNo);
           
            if (resp != DialogResult.Yes)
            {
                return;
            }

            //
            // Get selected document from tree
            //
            TreeNode docSelected = tvFileList.SelectedNode;

            if (docSelected == null)
                return;

            if (docSelected.Tag.GetType().Name == "scClientDocSetDocLink")
            {
                var rm = new scClientDocSetDocLink();
                rm = (scClientDocSetDocLink)docSelected.Tag; // Cast 

                try
                {
                    // rm.document.Delete( rm.document.UID );

                    // RepDocument.Delete(rm.document.UID);
                    BUSDocument.DeleteDocument(rm.document.UID);
                }
                catch 
                {
                    // Using Logical Deletion
                    // rm.document.SetToVoid( rm.document.UID );

                    // RepDocument.SetToVoid(rm.document.UID);
                    BUSDocument.SetToVoid(rm.document.UID);
                }

            }

            if (docSelected.Tag.GetType().Name == "Document")
            {
                var rm = new Document();
                rm = (Document)docSelected.Tag; // Cast 

                try
                {
                    // rm.Delete( rm.UID );

                    // RepDocument.Delete(rm.UID);
                    BUSDocument.DeleteDocument(rm.UID);
                }
                catch
                {
                    // rm.SetToVoid( rm.UID );
                    // RepDocument.SetToVoid(rm.UID);
                    BUSDocument.SetToVoid(rm.UID);
                }
            }

            // Physically delete items

            // Remove item
            docSelected.Remove();


        }

        private void linkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIDocumentLink uidl = new UIDocumentLink();
            uidl.Show();

        }

        private void tvFileList_Leave(object sender, EventArgs e)
        {
            miEdit.Enabled = false;
            miDelete.Enabled = false;
        }

        private void tvFileList_MouseDown( object sender, MouseEventArgs e )
        {
            if (e.Button == MouseButtons.Right)
            {
                tvFileList.SelectedNode = tvFileList.GetNodeAt( e.X, e.Y );
            } 
        }

        private void tsmFontSize825_Click(object sender, EventArgs e)
        {
            tvFileList.Font =
               new System.Drawing.Font("Microsoft Sans Serif",
                           8.25F,
                           System.Drawing.FontStyle.Regular,
                           System.Drawing.GraphicsUnit.Point,
                           ((System.Byte)(0)));

            // Save setting (Font Size to 8.25)
            //
            var userSetting = new UserSettings();
            userSetting.FKUserID = Utils.UserID;
            userSetting.FKScreenCode = this.ScreenCode;
            userSetting.FKControlCode = FCMConstant.ScreenControl.TreeViewDocumentList;
            userSetting.FKPropertyCode = FCMConstant.ScreenProperty.FontSize;
            userSetting.Value = "8.25";

            BUSUserSetting.Save(userSetting);

        }

        private void tsmFontSize12_Click(object sender, EventArgs e)
        {
            tvFileList.Font =
                    new System.Drawing.Font("Microsoft Sans Serif",
               12F,
               System.Drawing.FontStyle.Regular,
               System.Drawing.GraphicsUnit.Point,
               ((System.Byte)(0)));

            // Save setting (Font Size to 8.25)
            //
            var userSetting = new UserSettings();
            userSetting.FKUserID = Utils.UserID;
            userSetting.FKScreenCode = this.ScreenCode;
            userSetting.FKControlCode = FCMConstant.ScreenControl.TreeViewDocumentList;
            userSetting.FKPropertyCode = FCMConstant.ScreenProperty.FontSize;
            userSetting.Value = "12";

            BUSUserSetting.Save(userSetting);

        }

        private void tsmFontSize14_Click(object sender, EventArgs e)
        {
            tvFileList.Font =
               new System.Drawing.Font("Microsoft Sans Serif",
               14F,
               System.Drawing.FontStyle.Regular,
               System.Drawing.GraphicsUnit.Point,
               ((System.Byte)(0)));

            // Save setting (Font Size to 8.25)
            //
            var userSetting = new UserSettings();
            userSetting.FKUserID = Utils.UserID;
            userSetting.FKScreenCode = this.ScreenCode;
            userSetting.FKControlCode = FCMConstant.ScreenControl.TreeViewDocumentList;
            userSetting.FKPropertyCode = FCMConstant.ScreenProperty.FontSize;
            userSetting.Value = "14";

            BUSUserSetting.Save(userSetting);

        }

        private void tsmIconSize16_Click(object sender, EventArgs e)
        {
            tvFileList.ImageList = imageList16;
            tvFileList.Refresh();

            // Save setting (Icon Size to 16)
            //
            var userSetting = new UserSettings();
            userSetting.FKUserID = Utils.UserID;
            userSetting.FKScreenCode = this.ScreenCode;
            userSetting.FKControlCode = FCMConstant.ScreenControl.TreeViewClientDocumentList;
            userSetting.FKPropertyCode = FCMConstant.ScreenProperty.IconSize;
            userSetting.Value = "16";
            BUSUserSetting.Save(userSetting);
        }

        private void tsmIconSize32_Click(object sender, EventArgs e)
        {
            tvFileList.ImageList = imageList32;
            tvFileList.Refresh();

            // Save setting (Icon Size to 32)
            //
            var userSetting = new UserSettings();
            userSetting.FKUserID = Utils.UserID;
            userSetting.FKScreenCode = this.ScreenCode;
            userSetting.FKControlCode = FCMConstant.ScreenControl.TreeViewClientDocumentList;
            userSetting.FKPropertyCode = FCMConstant.ScreenProperty.IconSize;
            userSetting.Value = "32";
            BUSUserSetting.Save(userSetting);
        }

        private void btnFixLocation_Click( object sender, EventArgs e )
        {

            int documentUID = Convert.ToInt32(txtUID.Text);
            var drr = new DocumentReadRequest();
            drr.UID = documentUID;

            var docread = BUSDocument.DocumentRead( drr );

            if ( docread.document.RecordType == "FOLDER" )
                return;

            var documentSaveRequest = new DocumentSaveRequest();
           
            documentSaveRequest.inDocument = docread.document;
            documentSaveRequest.inDocument.Name =
                UIHelper.ClientDocumentUIHelper.SetDocumentName(
                    documentSaveRequest.inDocument.SimpleFileName,
                    documentSaveRequest.inDocument.IssueNumber.ToString(),
                    documentSaveRequest.inDocument.CUID, 
                    documentSaveRequest.inDocument.RecordType,
                    documentSaveRequest.inDocument.FileName);
            documentSaveRequest.headerInfo = HeaderInfo.Instance;
            documentSaveRequest.saveType = FCMConstant.SaveType.UPDATE;

            var resp = BUSDocument.DocumentSave( documentSaveRequest );

            txtLocation.Text = resp.document.Location;
            txtName.Text = resp.document.Name;

            TreeNode tndocSelected = tvFileList.SelectedNode;

            if ( tndocSelected != null )
            {
                if ( tndocSelected.Tag.GetType().Name == "Document" )
                {
                    tndocSelected.Tag = resp.document;
                }
            }
        }

        private void fixLocationToolStripMenuItem_Click( object sender, EventArgs e )
        {

            TreeNode tndocSelected = tvFileList.SelectedNode;

            if ( tndocSelected != null )
            {
                fixDocumentLocation( tndocSelected );
            }
        }

        private void fixDocumentLocation(TreeNode tn)
        {
            
            if (tn.Tag == null)
                return;

            Document document = (Document) tn.Tag;

            if (document.RecordType == "FOLDER")
            {
                foreach ( TreeNode node in tn.Nodes )
                {
                    fixDocumentLocation(node);   
                }

            }

            var drr = new DocumentReadRequest();
            drr.UID = document.UID;

            var docread = BUSDocument.DocumentRead( drr );

            var documentSaveRequest = new DocumentSaveRequest();

            documentSaveRequest.inDocument = docread.document;

            documentSaveRequest.inDocument.Name =
                UIHelper.ClientDocumentUIHelper.SetDocumentName(
                    documentSaveRequest.inDocument.SimpleFileName,
                    documentSaveRequest.inDocument.IssueNumber.ToString(),
                    documentSaveRequest.inDocument.CUID,
                    documentSaveRequest.inDocument.RecordType,
                    documentSaveRequest.inDocument.FileName);

            documentSaveRequest.headerInfo = HeaderInfo.Instance;
            documentSaveRequest.saveType = FCMConstant.SaveType.UPDATE;

            var resp = BUSDocument.DocumentSave( documentSaveRequest );

            tn.Tag = resp.document;

        }

        private void locateInExplorerToolStripMenuItem_Click( object sender, EventArgs e )
        {
            //
            // Get selected document from tree
            //
            TreeNode docSelected = tvFileList.SelectedNode;
            var rm = new Document();

            if ( docSelected == null )
                return;

            rm = (Document) docSelected.Tag; // Cast 

            // Show file dialog
            string filePathName = Utils.getFilePathName( rm.Location, rm.FileName );
            string filePath = Utils.GetPathName( rm.Location );

            openFileDialog1.FileName = rm.FileName;
            openFileDialog1.InitialDirectory = filePath;

            var file = openFileDialog1.ShowDialog();
        }   
    }
}
