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
    public partial class UIDocumentLink : Form
    {
        DocumentList docoList;
        int SelectedParentDocumentUID;

        public UIDocumentLink()
        {
            InitializeComponent();
        }

        private void UIDocumentLink_Load(object sender, EventArgs e)
        {
            PopulateDocumentCombo('N');

            cbxLinkType.Items.Add(FCMConstant.DocumentLinkType.PROJECTPLAN);
            cbxLinkType.Items.Add(FCMConstant.DocumentLinkType.APPENDIX);

            removeDocumentToolStripMenuItem.Enabled = false;
            selectDocumentToolStripMenuItem.Enabled = false;
        }

        private void PopulateDocumentCombo(char ProjectPlan)
        {
            docoList = new DocumentList();
            if (ProjectPlan == 'Y')
                docoList.ListProjectPlans();
            else
                docoList.List();

            cbxDocument.Items.Clear();
            cbxDocument.SelectedText = "";

            int i = 0;
            foreach (Document doco in docoList.documentList)
            {
                string item = doco.UID + ";" + doco.CUID + ";" + doco.Name;
                cbxDocument.Items.Add(item);

                if (i == 0)
                {
                    cbxDocument.ResetText();
                    cbxDocument.SelectedText = item;
                }
                i++;
            }

            cbxLinkType.Text = FCMConstant.DocumentLinkType.PROJECTPLAN;

            ParentHasChanged();
            loadDocumentList();
        }
        
        private void cbxDocument_SelectedIndexChanged(object sender, EventArgs e)
        {
            ParentHasChanged();
        }

        private void ParentHasChanged()
        {
            // Get selected document
            // List documents connected to selected document
            // ... for selected link type

            var x = cbxDocument.Text;

            string[] doco = x.Split(';');
            Document document = new Document();
            document.UID = Convert.ToInt32(doco[0]);
            SelectedParentDocumentUID = document.UID;

            DocumentLinkList list = DocumentLinkList.ListRelatedDocuments(document.UID,
                                            cbxLinkType.Text);
            loadLinkedDocuments(document);
        }

        // ------------------------------------------
        //            List Documents
        // ------------------------------------------
        public void loadDocumentList()
        {

            // Image list
            //
            ImageList imageList = ControllerUtils.GetImageList();

            // Binding
            tvListOfDocuments.ImageList = imageList;

            // Clear nodes
            tvListOfDocuments.Nodes.Clear();

            var docoList = new DocumentList();

            docoList.List();

            // Load document in the treeview
            //
            // docoList.ListInTree(tvListOfDocuments);
            Document root = new Document();
            root.CUID = "ROOT";
            root.RecordType = FCMConstant.RecordType.FOLDER;
            root.UID = 0;

            // root.Read();
            // root = RepDocument.Read(false, 0, "ROOT");
            // Using Business Layer
            root = BUSDocument.GetRootDocument();

            DocumentList.ListInTree(tvListOfDocuments, docoList, root);
            tvListOfDocuments.ExpandAll();

        }

        // ------------------------------------------
        //            List Documents
        // ------------------------------------------
        public void loadLinkedDocuments(Document document)
        {

            // Image list
            //
            ImageList imageList = ControllerUtils.GetImageList();

            // Binding
            tvLinkedDocuments.ImageList = imageList;

            // Clear nodes
            tvLinkedDocuments.Nodes.Clear();

            var docoList = DocumentLinkList.ListRelatedDocuments(document.UID,
                                cbxLinkType.Text);

            // Load document in the treeview
            //
            // docoList.ListInTree(tvLinkedDocuments);
            Document root = new Document();
            root.CUID = document.CUID;
            root.RecordType = FCMConstant.RecordType.FOLDER;
            root.UID = document.UID;
            // root.Read();

            // root = RepDocument.Read(false, document.UID, document.CUID);

            // Using Business Layer
            var documentReadRequest = new DocumentReadRequest();
            documentReadRequest.UID = document.UID;
            documentReadRequest.CUID = document.CUID;
            documentReadRequest.retrieveVoidedDocuments = false;

            var docreadresp = BUSDocument.DocumentRead(documentReadRequest);

            if (docreadresp.response.ReturnCode == 0001)
            {
                // all good
            }
            else
            {
                MessageBox.Show(docreadresp.response.Message);
                return;
            }

            root = docreadresp.document;
            //


            DocumentLinkList.ListInTree(tvLinkedDocuments, docoList, root);
            tvLinkedDocuments.ExpandAll();
        }

        private void checkProjectPlans_CheckedChanged(object sender, EventArgs e)
        {
            char projectplan = 'N';
            if (checkProjectPlans.Checked)
                projectplan = 'Y';


            PopulateDocumentCombo(projectplan);

        }

        private void tvListOfDocuments_DoubleClick(object sender, EventArgs e)
        {
            AddSelectedDocument();
        }

        private void AddSelectedDocument()
        {
            TreeNode tn = new TreeNode();
            tn = tvListOfDocuments.SelectedNode;

            TreeNode clone = new TreeNode();
            clone = (TreeNode)tn.Clone();

            tvLinkedDocuments.Nodes[0].Nodes.Add(clone);

        }

        // ------------------------------------------------
        //      Save details
        // ------------------------------------------------
        private void tsbSave_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            
            foreach (TreeNode tn in tvLinkedDocuments.Nodes[0].Nodes)
            {
                var nodeType = tn.Tag.GetType().Name;
                if (nodeType == "DocumentLink")
                {
                    DocumentLink doc = new DocumentLink();
                    doc = (DocumentLink)tn.Tag;

                    DocumentLink.LinkDocuments(
                        SelectedParentDocumentUID,
                        doc.documentTo.UID,
                        cbxLinkType.Text);
                }

                if (nodeType == "Document")
                {
                    Document doc = new Document();
                    doc = (Document)tn.Tag;

                    DocumentLink.LinkDocuments(
                        SelectedParentDocumentUID,
                        doc.UID,
                        cbxLinkType.Text);
                }
            }
            Cursor.Current = Cursors.Arrow;

            MessageBox.Show("Saved successfully.");
        }

        private void tvLinkedDocuments_DoubleClick(object sender, EventArgs e)
        {
            RemoveDocument();
        }

        // Remove document from selected list
        //
        private void RemoveDocument()
        {
            TreeNode tn = new TreeNode();
            tn = tvLinkedDocuments.SelectedNode;

            var nodeType = tn.Tag.GetType().Name;
            if (nodeType == "Document")
            {
                Document doc = new Document();
                doc = (Document)tn.Tag;

                DocumentLink dl = new DocumentLink();

                // Logically delete the record if the record is commited.
                if (dl.Read(SelectedParentDocumentUID, doc.UID, cbxLinkType.Text))
                    dl.Delete(dl.UID);

                tn.Remove();
            }

            if (nodeType == "DocumentLink")
            {
                DocumentLink doc = new DocumentLink();
                doc = (DocumentLink)tn.Tag;

                DocumentLink dl = new DocumentLink();

                // Logically delete the record if the record is commited.
                if (dl.Read(SelectedParentDocumentUID, doc.documentTo.UID, cbxLinkType.Text))
                    dl.Delete(dl.UID);

                tn.Remove();
            }

        }
        
        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxLinkType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ParentHasChanged();
        }

        private void selectDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSelectedDocument();

        }

        private void tvLinkedDocuments_AfterSelect(object sender, TreeViewEventArgs e)
        {
            removeDocumentToolStripMenuItem.Enabled = true;
        }

        private void tvListOfDocuments_AfterSelect(object sender, TreeViewEventArgs e)
        {
            selectDocumentToolStripMenuItem.Enabled = true;
        }

        private void tvLinkedDocuments_Leave(object sender, EventArgs e)
        {
            removeDocumentToolStripMenuItem.Enabled = false;
        }

        private void tvListOfDocuments_Leave(object sender, EventArgs e)
        {
            selectDocumentToolStripMenuItem.Enabled = false;
        }

        private void removeDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveDocument();
        }

        private void tvLinkedDocuments_MouseDown( object sender, MouseEventArgs e )
        {
            if (e.Button == MouseButtons.Right)
            {
                tvLinkedDocuments.SelectedNode = tvLinkedDocuments.GetNodeAt( e.X, e.Y );
            } 
        }

        private void tvListOfDocuments_MouseDown( object sender, MouseEventArgs e )
        {
            if (e.Button == MouseButtons.Right)
            {
                tvListOfDocuments.SelectedNode = tvListOfDocuments.GetNodeAt( e.X, e.Y );
            } 
        }


    }
}
