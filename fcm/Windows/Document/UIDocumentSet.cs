using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FCMMySQLBusinessLibrary;
using FCMMySQLBusinessLibrary.FCMUtils;
using FCMMySQLBusinessLibrary.Model.ModelDocument;
using FCMMySQLBusinessLibrary.Repository.RepositoryDocument;
using FCMMySQLBusinessLibrary.Service.SVCDocument.Service;
using FCMMySQLBusinessLibrary.Service.SVCDocument.ServiceContract;

namespace fcm.Windows
{
    public partial class UIDocument : Form
    {
        private DocumentSet documentSet;
        private DocumentSetList dsl;

        public UIDocument()
        {
            InitializeComponent();

            // Initialise DocumentSet
            documentSet = new DocumentSet();
        }

        private void UIDocumentSet_Load(object sender, EventArgs e)
        {
            dsl = new DocumentSetList();
            dsl.ListInComboBox(cbxDocumentSet);

            if (cbxDocumentSet.Items.Count > 0)
            {
                cbxDocumentSet.SelectedIndex = 0;

                SelectIndexChanged();
            }
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public void loadDocumentList()
        {

            // Image list
            //
            ImageList imageList = ControllerUtils.GetImageList();

            // Binding
            tvFileList.ImageList = imageList;

            // Clear nodes
            tvFileList.Nodes.Clear();

            var docoList = new DocumentList();

            docoList.List();

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
            
            DocumentList.ListInTree(tvFileList, docoList, root);
            // tvFileList.ExpandAll();
            tvFileList.Nodes[0].Expand();
        }

        public void loadDocumentList(int documentSetUID = 0)
        {

            // Image list
            //
            ImageList imageList = ControllerUtils.GetImageList();

            // Binding
            tvFileList.ImageList = imageList;

            // Clear nodes
            tvFileList.Nodes.Clear();

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

            // Using Business Layer
            root = BUSDocument.GetRootDocument();
            //

            DocumentList.ListInTree(tvFileList, documentSet.documentList, root);
            tvFileList.Nodes[0].Expand();
        }

        private void cbxDocumentSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectIndexChanged();
        }

        // Handles the selection index change
        //
        private void SelectIndexChanged()
        {

            int documentSetUID = 0;

            if (string.IsNullOrEmpty(cbxDocumentSet.Text) ||
                cbxDocumentSet.Visible == false)
            {
                documentSetUID = 0;
            }
            else
            {
                string[] ArrayDocSetText = cbxDocumentSet.Text.Split(';');

                documentSetUID = Convert.ToInt32(ArrayDocSetText[0]);
            }

            if (documentSetUID == 0)
                loadDocumentList();
            else
                loadDocumentList(documentSetUID);

            txtDocumentSetUID.Text = documentSet.UID.ToString();
            txtDocumentSetName.Text = documentSet.TemplateType;

        }

        private void btnLoadAllDocuments_Click(object sender, EventArgs e)
        {
            // Using private variable to load documents
            documentSet.LoadAllDocuments();

            SelectIndexChanged();

            MessageBox.Show("Document Loaded Successfully.");

        }

        private void tsbRemove_Click(object sender, EventArgs e)
        {

            TreeNode tndocSelected = tvFileList.SelectedNode;
            if (tndocSelected == null)
                return;

            TreeNode parent = tndocSelected.Parent;

            if (tndocSelected == null)
                return;
            else
            {

                if (tndocSelected.Tag.GetType().Name == "Document")
                {
                    DocumentSet.DeleteDocumentTreeNode(documentSetUID: documentSet.UID, documentSetNode: tndocSelected); 
                }

                tndocSelected.Remove();

                tvFileList.SelectedNode = parent;

            }
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            txtDocumentSetName.Text = "";
            txtDocumentSetUID.Text = "";

            txtDocumentSetName.Focus();
        }

        private void miLinkDocumentFolder_Click(object sender, EventArgs e)
        {
            LinkDocument();
        }


        private void LinkDocument()
        {
            TreeNode tnSelected = new TreeNode();
            tnSelected = tvFileList.SelectedNode;

            TreeNode parentNode = new TreeNode();
            parentNode = tnSelected.Parent;

            if (tnSelected == null)
                return;

            var nodeSelected = (Document)tnSelected.Tag;

            DocumentList docList = new DocumentList();

            UIDocumentList udl = new UIDocumentList(docList);
            udl.ShowDialog();

            foreach (var documentSelected in docList.documentList)
            {
                DocumentSetDocument docfind = new DocumentSetDocument();
                docfind.Find(documentSelected.UID, documentSet.UID, voidRead: 'N');

                if (docfind.UID > 0)
                    continue;

                DocumentSetDocument dsd = new DocumentSetDocument();
                dsd.FKDocumentSetUID = documentSet.UID;
                dsd.FKDocumentUID = documentSelected.UID;
                dsd.EndDate = System.DateTime.MaxValue;
                dsd.StartDate = System.DateTime.Today;
                dsd.UID = 0;
                dsd.Location = documentSelected.Location;
                dsd.SequenceNumber = tnSelected.Index;
                dsd.IsVoid = 'N';
                dsd.FKParentDocumentSetUID = documentSet.UID;
                dsd.FKParentDocumentUID = nodeSelected.UID;

                dsd.Add();

                TreeNode tnNew = new TreeNode();
                tnNew.Tag = documentSelected;

                tnSelected.Nodes.Add(tnNew);

            }

            // Reset sequence numbers
            ResetAllSequenceNumbers(tvFileList.Nodes[0]);

            SelectIndexChanged();
        }



        private void ResetAllSequenceNumbers(TreeNode root)
        {
            foreach (TreeNode tn in root.Nodes)
            {
                var doc = (Document)tn.Tag;
                doc.SequenceNumber = tn.Index;

                DocumentSetDocument.UpdateSequenceNumber(DocumentSetUID: documentSet.UID, DocumentUID: doc.UID, SequenceNumber: tn.Index);

                foreach (TreeNode tn2 in tn.Nodes)
                {
                    ResetAllSequenceNumbers(tn2);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tsbDown_Click(object sender, EventArgs e)
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

            ResetAllSequenceNumbers(parent);

        }

        private void tsbUp_Click(object sender, EventArgs e)
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

                ResetAllSequenceNumbers(parent);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DocumentSet ds = new DocumentSet();
            if (string.IsNullOrEmpty(txtDocumentSetUID.Text))
            {
                ds.IsVoid = 'N';
                ds.Name = txtDocumentSetName.Text;
                ds.TemplateType = txtDocumentSetName.Text;
                ds.TemplateFolder = "";
                ds.UID = 0;
                ds.Add();
            }
            else
            {
                ds.IsVoid = 'N';
                ds.TemplateType = txtDocumentSetName.Text;
                ds.UID = documentSet.UID;
                ds.Update();
            }

            // Reload document set list
            //
            cbxDocumentSet.Items.Clear();

            dsl.ListInComboBox(cbxDocumentSet);
            cbxDocumentSet.SelectedIndex = 0;

            SelectIndexChanged();
        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmManageLinks_Click(object sender, EventArgs e)
        {
            UIDocumentSetDocumentLink uidosdl = new UIDocumentSetDocumentLink(documentSet.UID, cbxDocumentSet.Text);
            uidosdl.ShowDialog();

        }

        private void tvFileList_MouseDown( object sender, MouseEventArgs e )
        {
            if (e.Button == MouseButtons.Right)
            {
                tvFileList.SelectedNode = tvFileList.GetNodeAt( e.X, e.Y );
            } 
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LinkDocument();
        }
    }
}
