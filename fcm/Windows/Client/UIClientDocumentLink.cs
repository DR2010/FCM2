using System;
using System.Windows.Forms;
using FCMMySQLBusinessLibrary.Model.ModelClientDocument;
using FCMMySQLBusinessLibrary.Model.ModelDocument;
using FCMMySQLBusinessLibrary.Repository.RepositoryDocument;
using FCMMySQLBusinessLibrary.Service.SVCClient;
using FCMMySQLBusinessLibrary.Model.ModelClient;
using FCMMySQLBusinessLibrary.FCMUtils;
using FCMMySQLBusinessLibrary.Service.SVCClientDocument.Service;
using FCMMySQLBusinessLibrary.Service.SVCDocument.Service;
using FCMMySQLBusinessLibrary.Service.SVCDocument.ServiceContract;
using MackkadoITFramework.Utils;
using FCMMySQLBusinessLibrary;
using FCMMySQLBusinessLibrary.Repository.RepositoryClient;


namespace fcm.Windows
{
    public partial class UIClientDocumentLink : Form
    {

        DocumentList docoList;
        int SelectedParentDocumentUID;
        private DocumentSetList dsl;
        private int documentSetUID;
        private string documentSetText;
        private Document parentDocument;
        private ClientDocument selectedClientDocument;
        private Client selectedClient;
        private ClientDocumentSet selectedClientDocumentSet;

        public UIClientDocumentLink(string clientTxt, string clientSetTxt)
        {
            InitializeComponent();
            parentDocument = new Document();

            cbxClient.Text = clientTxt;
            cbxDocumentSet.Text = clientSetTxt;

            // Get Client UID
            selectedClient = new Client(HeaderInfo.Instance);
            selectedClient.UID = Utils.ClientID;

            var repclient = RepClient.Read(selectedClient.UID);
            var response = repclient.responseStatus;

            // var response = selectedClient.Read();

            // Get Client Document Set UID
            var docSetUID = cbxDocumentSet.Text;
            string[] docoSet = docSetUID.Split(';');
            documentSetUID = Convert.ToInt32(docoSet[1]);

            selectedClientDocumentSet = new ClientDocumentSet();
            selectedClientDocumentSet.UID = documentSetUID;
            selectedClientDocumentSet.FKClientUID = selectedClient.UID;

            cbxLinkType.Items.Add(FCMConstant.DocumentLinkType.PROJECTPLAN);
            cbxLinkType.Items.Add(FCMConstant.DocumentLinkType.APPENDIX);

            cbxLinkType.Text = FCMConstant.DocumentLinkType.PROJECTPLAN; 
        }

        // -------------------------------------------------------
        //  Load Event
        // -------------------------------------------------------
        private void UIClientDocumentLink_Load(object sender, EventArgs e)
        {
            // Get client list from background and load into the list
            // -------------------------------------------------------
            foreach (Client c in Utils.ClientList)
            {
                cbxClient.Items.Add(c.UID + "; " + c.Name);
            }

            // Get selected client from the background
            // -------------------------------------------------------
            // cbxClient.SelectedIndex = Utils.ClientIndex;

            // Load document in the treeview
            // -------------------------------------------------------
            Document root = new Document();
            root.CUID = "ROOT";
            root.Name = "FCM Documents";
            root.RecordType = FCMConstant.RecordType.FOLDER;
            root.UID = 0;
            // root.Read();

            // root = RepDocument.Read(false, 0, "ROOT");

            // Using Business Layer

            root = BUSDocument.GetRootDocument();


            // Populate document list
            // -------------------------------------------------------
            PopulateDocumentCombo('N');

            // List Available Documents
            // -------------------------------------------------------
            loadDocumentList();

            // List Documents Linked to selected document
            // -------------------------------------------------------
            loadLinkedDocuments(parentDocument);

        }

        // -------------------------------------------------------
        //  Populate combo box with list of client Documents
        // -------------------------------------------------------
        private void PopulateDocumentCombo(char ProjectPlan)
        {

            // List documents
            // -------------------------------------------------------
            var documentSetList = new ClientDocument();

            // documentSetList.List(Utils.ClientID, Utils.ClientSetID);

            var cdlr = new BUSClientDocument.ClientDocumentListRequest();
            cdlr.clientUID = Utils.ClientID;
            cdlr.clientDocumentSetUID = Utils.ClientSetID;
            var response = BUSClientDocument.List( cdlr );
            documentSetList.clientDocSetDocLink = response.clientList;

            cbxDocument.Items.Clear();
            cbxDocument.SelectedText = "";

            int i = 0;
            foreach (var doco in documentSetList.clientDocSetDocLink)
            {
                string item = doco.document.UID + ";" + doco.document.CUID + ";" + doco.document.Name;
                cbxDocument.Items.Add(item);

                if (i == 0)
                {
                    cbxDocument.ResetText();
                    cbxDocument.SelectedText = item;
                }

                if (i == 0)
                {
                    cbxDocument.Text = item; 
                }
                i++;
            }

        }

        // ----------------------------------------------------------------------
        // List documents available for selection in list box tvListOfDocuments
        // ----------------------------------------------------------------------
        public void loadDocumentList()
        {

            // Image list
            //
            ImageList imageList = ControllerUtils.GetImageList();

            // Binding
            tvListOfDocuments.ImageList = imageList;

            // Clear nodes
            tvListOfDocuments.Nodes.Clear();

            var docoList = new ClientDocument();

            // docoList.List(Utils.ClientID, Utils.ClientSetID);

            var cdlr = new BUSClientDocument.ClientDocumentListRequest();
            cdlr.clientUID = Utils.ClientID;
            cdlr.clientDocumentSetUID = Utils.ClientSetID;

            var response = BUSClientDocument.List( cdlr );

            // Load document in the treeview
            //
            // docoList.ListInTree(tvListOfDocuments);
            Document root = new Document();
            root.CUID = "ROOT";
            root.RecordType = FCMConstant.RecordType.FOLDER;
            root.UID = 0;
            // root.Read();

            // root = RepDocument.Read(false, 0, "ROOT");
            root = BUSDocument.GetRootDocument();

            // docoList.ListInTree(tvListOfDocuments, "CLIENT");

            BUSClientDocument.ListInTree( docoList, tvListOfDocuments, "CLIENT" );

            tvListOfDocuments.ExpandAll();

        }

        private void ParentHasChanged()
        {
            var x = cbxDocument.Text;

            if (string.IsNullOrEmpty(x))
                return;

            string[] doco = x.Split(';');
            parentDocument.UID = Convert.ToInt32(doco[0]);
            // parentDocument.Read();

            //parentDocument = RepDocument.Read(false, parentDocument.UID);

            // Using Business Layer
            var documentReadRequest = new DocumentReadRequest();
            documentReadRequest.UID = parentDocument.UID;
            documentReadRequest.CUID = "";
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

            parentDocument = docreadresp.document;
            //

            // Get document set
            if (string.IsNullOrEmpty(cbxDocumentSet.Text))
            {
                documentSetUID = 1;
            }
            else
            {
                var docSetUID = cbxDocumentSet.Text;

                string[] docoSet = docSetUID.Split(';');
                // The first is the client id, the second is the document set id
                //
                documentSetUID = Convert.ToInt32(docoSet[1]);
            }

            ClientDocumentLinkList list = ClientDocumentLinkList.ListRelatedDocuments(
                        selectedClient.UID,
                        documentSetUID,
                        parentDocument.UID, 
                        cbxLinkType.Text);

            loadLinkedDocuments(parentDocument);
        }

        private void cbxClient_SelectedIndexChanged(object sender, EventArgs e)
        {

            ParentHasChanged();

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

            var docoList = ClientDocumentLinkList.ListRelatedDocuments(
                                selectedClient.UID,
                                documentSetUID,
                                document.UID,
                                cbxLinkType.Text);

            // Load document in the treeview
            //
            // docoList.ListInTree(tvLinkedDocuments);
            Document root = new Document();
            root.CUID = document.CUID;
            root.RecordType = FCMConstant.RecordType.FOLDER;
            root.UID = document.UID;
            // root.Read();

            // root = RepDocument.Read(false, document.UID);

            // Using Business Layer
            var documentReadRequest = new DocumentReadRequest();
            documentReadRequest.UID = document.UID;
            documentReadRequest.CUID = "";
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




            ControllerUtils.ListInTree( tvLinkedDocuments, docoList, root );
            tvLinkedDocuments.ExpandAll();
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

        private void cbxDocument_SelectedIndexChanged(object sender, EventArgs e)
        {
            ParentHasChanged();
        }

        // ---------------------------------------------------------------------------------
        //                      Save
        // ---------------------------------------------------------------------------------
        private void tsbSave_Click(object sender, EventArgs e)
        {
            if (parentDocument.UID <= 0)
            {
                MessageBox.Show("Main document is not selected.");
                return;
            }

            foreach (TreeNode tn in tvLinkedDocuments.Nodes[0].Nodes)
            {
                var nodeType = tn.Tag.GetType().Name;
                if (nodeType == "scClientDocSetDocLink")
                {
                    var doc = new scClientDocSetDocLink();
                    doc = (scClientDocSetDocLink)tn.Tag;

                    // Add parentClientDocument and childClientDocument... Daniel 17/08/2010
                    //
                    ClientDocumentLink.LinkDocuments(
                        clientUID: selectedClient.UID,
                        clientDocumentSetUID: selectedClientDocumentSet.UID,
                        parentDocumentUID: parentDocument.UID,
                        childDocumentUID: doc.document.UID,
                        LinkType: cbxLinkType.Text);
                }

                if (nodeType == "Document")
                {
                    Document doc = new Document();
                    doc = (Document)tn.Tag;

                    ClientDocumentLink.LinkDocuments(
                        clientUID: selectedClient.UID,
                        clientDocumentSetUID:  selectedClientDocumentSet.UID,
                        parentDocumentUID: parentDocument.UID,
                        childDocumentUID: doc.UID,
                        LinkType: cbxLinkType.Text);
                }
            }
            MessageBox.Show("Saved successfully.");
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbtnDelete_Click(object sender, EventArgs e)
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

                ClientDocumentLink dl = new ClientDocumentLink();

                // Logically delete the record if the record is commited.
                if (dl.Read(ParentID:parentDocument.UID, 
                            ChildID: doc.UID, 
                            LinkType: cbxLinkType.Text, 
                            clientUID: Utils.ClientID, 
                            clientDocumentSetUID: Utils.ClientSetID))
                    dl.Delete(dl.UID);

                tn.Remove();
            }

            if (nodeType == "ClientDocumentLink")
            {
                ClientDocumentLink clientDocLink = new ClientDocumentLink();
                clientDocLink = (ClientDocumentLink)tn.Tag;

                ClientDocumentLink dl = new ClientDocumentLink();

                // Logically delete the record if the record is commited.
                if (dl.Read( parentDocument.UID, 
                             clientDocLink.FKChildDocumentUID, 
                             cbxLinkType.Text, 
                             Utils.ClientID, 
                             Utils.ClientSetID))
                    dl.Delete(dl.UID);

                tn.Remove();
            }

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
