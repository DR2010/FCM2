using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using FCMMySQLBusinessLibrary;
using FCMMySQLBusinessLibrary.Model.ModelClientDocument;
using FCMMySQLBusinessLibrary.Model.ModelDocument;
using FCMMySQLBusinessLibrary.Service.SVCClient.Contract;
using FCMMySQLBusinessLibrary.Service.SVCClient.Service;
using FCMMySQLBusinessLibrary.Model.ModelClient;
using System.IO;
using FCMMySQLBusinessLibrary.FCMUtils;
using FCMMySQLBusinessLibrary.Service.SVCClient.ServiceContract;
using FCMMySQLBusinessLibrary.Service.SVCClientDocument.Service;
using MackkadoITFramework.Utils;
using Utils = FCMMySQLBusinessLibrary.FCMUtils.Utils;
using FCMMySQLBusinessLibrary.Repository;
using MackkadoITFramework.ErrorHandling;

namespace fcm.Windows
{
    public partial class UIImpactedDocuments : Form
    {
        public DataTable elementSourceDataTable;
        public DataTable clientMetadataTable;
        Document document;
        Client clientDocument;

        ImageList imageList;
        ImageList imageList32;

        public UIImpactedDocuments()
        {
            InitializeComponent();

            document = new Document();

            // Image list
            //
            imageList = new ImageList();
            imageList = ControllerUtils.GetImageList();
            imageList.ImageSize = new Size(16, 16);

            // Binding
            tvDocumentList.ImageList = imageList;

            // Image list 32
            //
            imageList32 = new ImageList();
            imageList32 = ControllerUtils.GetImageList();
            imageList32.ImageSize = new Size(32, 32);

            // Binding
            // tvDocumentList.ImageList = imageList32;


        }

        public UIImpactedDocuments(Document iDocument) : this()
        {
            document = new Document();
            document = iDocument;

            txtDocumentID.Text = document.CUID;
            txtDocumentName.Text = document.Name;

            ListImpact(iDocument);

            btnDocument.Enabled = false;
            btnImpact.Enabled = false;

        }

        // --------------------------------------------
        //               Document Click
        // --------------------------------------------
        private void btnDocument_Click(object sender, EventArgs e)
        {

            loadDocumentList();

        }

        /// <summary>
        /// Load documents for a Client Document Set
        /// </summary>
        private void loadDocumentList(int w=16, int h=16)
        {

            if (elementSourceDataTable != null)
            {
                elementSourceDataTable.Clear();
            }

            DocumentList dl = new DocumentList();
            UIDocumentList uidl = new UIDocumentList(dl);
            uidl.ShowDialog();

            if (dl == null)
                return;

            if (dl.documentList == null)
                return;

            if (dl.documentList.Count > 0)
            {
                document = dl.documentList[0];

                txtDocumentID.Text = document.CUID;
                txtDocumentName.Text = document.Name;
            }

            ListImpact(document,w,h);
        }

        private void ListImpact(Document document, int h=16, int w=16)
        {


            // Clear nodes
            tvDocumentList.Nodes.Clear();

            var impacted = new ClientDocument();
            // impacted.ListImpacted(document);

            BUSClientDocument.ListImpacted( impacted, document );

            TreeNode rootNode = new TreeNode("Impacted List", FCMConstant.Image.Folder, FCMConstant.Image.Folder);
            rootNode.Name = "Impacted List";
            tvDocumentList.Nodes.Add(rootNode);

            foreach (var doco in impacted.clientDocSetDocLink)
            {
                // string clientName = Client.ReadFieldClient(DBFieldName.Client.Name, doco.clientDocument.FKClientUID);

                var clientField = new Client(HeaderInfo.Instance);

                // string clientName = clientField.ReadFieldClient(DBFieldName.Client.Name, doco.clientDocument.FKClientUID);
                var readFieldClientResponse = new BUSClient().ReadFieldClient(
                    new ReadFieldRequest() {clientUID = doco.clientDocument.FKClientUID, field = FCMDBFieldName.Client.Name,  headerInfo = HeaderInfo.Instance });

                string clientName = readFieldClientResponse.fieldContents;

                // 1) Add client to tree
                //
                // 1.1) Find out current contract information
                // 1.2) Display document version
                // 1.3) Check if document has been further updated
                var response =
                    BUSClientContract.GetValidContractOnDate(doco.clientDocument.FKClientUID, System.DateTime.Today);

                // Successful
                ClientContract clientContractValid = new ClientContract();
                string validContract = @";Contract=N/A";
                if (response.ReturnCode == 0001 && response.ReasonCode == 0001)
                {
                    clientContractValid = (ClientContract)response.Contents;
                    validContract = ";Contract=Valid";
                }

                int imageClient = Utils.GetClientLogoImageSeqNum(doco.clientDocument.FKClientUID);

                string NameToDisplay = clientName + " ==> " +
                                  validContract +
                                  "; Version: " + 
                                  doco.clientDocument.ClientIssueNumber.ToString();

                TreeNode clientNode = new TreeNode(NameToDisplay, imageClient, imageClient);
                clientNode.Name = doco.clientDocument.FKClientUID.ToString();
                clientNode.Tag = doco;
                rootNode.Nodes.Add(clientNode);

                // Add Client Document Set to tree
                //
                TreeNode clientDocumentSetNode = new TreeNode("Set "+doco.clientDocument.FKClientDocumentSetUID.ToString(), FCMConstant.Image.Folder, FCMConstant.Image.Folder);
                clientDocumentSetNode.Name = "Set " + doco.clientDocument.FKClientDocumentSetUID.ToString("0000");
                clientDocumentSetNode.Tag = doco;
                clientNode.Nodes.Add(clientDocumentSetNode);

                // Add document to tree
                //
                int image = Utils.GetFileImage(doco.clientDocument.SourceFilePresent, doco.clientDocument.DestinationFilePresent, doco.clientDocument.DocumentType);
                TreeNode documentNode = new TreeNode(txtDocumentName.Text, image, image);
                documentNode.Name = txtDocumentName.Text;
                documentNode.Tag = doco;
                clientDocumentSetNode.Nodes.Add(documentNode);

            }

            if (tvDocumentList.Nodes.Count > 0)
                tvDocumentList.Nodes[0].Expand();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            //
            // Get selected document from tree
            //
            TreeNode tndocSelected = tvDocumentList.SelectedNode;

            if (tndocSelected == null)
                return;

            var cds = new scClientDocSetDocLink();
            cds = (scClientDocSetDocLink)tndocSelected.Tag;

            var Location = cds.clientDocument.Location;
            var FileName = cds.clientDocument.FileName;
            var FileType = cds.clientDocument.DocumentType;

            //string filePathName =
            //         Utils.getFilePathName(Location,
            //                               FileName);


            //if (!string.IsNullOrEmpty(filePathName))
            //{
            //    WordDocumentTasks.OpenDocument(filePathName);
            //}
            //else
            //{
            //    MessageBox.Show("Document is empty.");
            //}

            Utils.OpenDocument(Location, FileName, FileType, vkReadOnly: false);

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UIImpactedDocuments_Load(object sender, EventArgs e)
        {

        }

        private void btnImpact_Click(object sender, EventArgs e)
        {
            txtDocumentID.Text = document.CUID;
            txtDocumentName.Text = document.Name;

            ListImpact(document);

            btnDocument.Enabled = false;
            btnImpact.Enabled = false;
        }

        private void tvDocumentList_MouseDown( object sender, MouseEventArgs e )
        {
            if (e.Button == MouseButtons.Right)
            {
                tvDocumentList.SelectedNode = tvDocumentList.GetNodeAt( e.X, e.Y );
            } 
        }

        private void tvDocumentList_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void tsmIconSize16_Click(object sender, EventArgs e)
        {
            tvDocumentList.ImageList = imageList;
            tvDocumentList.Refresh();

        }

        private void tsmIconSize32_Click(object sender, EventArgs e)
        {
            tvDocumentList.ImageList = imageList32;
            tvDocumentList.Refresh();

        }

        private void tsmIcon16_Click(object sender, EventArgs e)
        {
            tvDocumentList.ImageList = imageList;
            tvDocumentList.Refresh();
        }

        private void tsmIconSize32x_Click(object sender, EventArgs e)
        {
            tvDocumentList.ImageList = imageList32;
            tvDocumentList.Refresh();
        }

        private void tsmFontSize825_Click(object sender, EventArgs e)
        {
            tvDocumentList.Font =
                    new System.Drawing.Font("Microsoft Sans Serif",
                           825F,
                           System.Drawing.FontStyle.Regular,
                           System.Drawing.GraphicsUnit.Point,
                           ((System.Byte)(0)));
        }

        private void tsmFontSize12_Click(object sender, EventArgs e)
        {
            tvDocumentList.Font =
               new System.Drawing.Font("Microsoft Sans Serif",
                   12F,
                   System.Drawing.FontStyle.Regular,
                   System.Drawing.GraphicsUnit.Point,
                   ((System.Byte)(0)));
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var answer = MessageBox.Show("Would you like to send emails to impacted clients?",
                "Send email",
                MessageBoxButtons.YesNo);

            if (answer != DialogResult.Yes)
            {
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            
            List<Client> listOfClients = new List<Client>();

            // Get file name
            //
            string filePathName = Utils.getFilePathName(
                        document.Location,
                        document.FileName);

            if (!File.Exists(filePathName))
            {
                MessageBox.Show("File not found. " + filePathName);
                return;
            }


            // Select client to send email and show before send
            //
            var impacted = new ClientDocument();
            // impacted.ListImpacted(document);

            BUSClientDocument.ListImpacted(impacted, document);

            foreach (var doco in impacted.clientDocSetDocLink)
            {
                var response =
                    BUSClientContract.GetValidContractOnDate(doco.clientDocument.FKClientUID, System.DateTime.Today);

                if (response.ReturnCode == 0001 && response.ReasonCode == 0001)
                {
                    //Client client = new Client(HeaderInfo.Instance);
                    //client.UID = doco.clientDocument.FKClientUID;

                    ClientReadRequest crr = new ClientReadRequest();
                    crr.clientUID = doco.clientDocument.FKClientUID;
                    crr.headerInfo = HeaderInfo.Instance;

                    var busClientResponse = BUSClient.ClientRead( crr );

                    //var busClientResponse = client.Read();

                    listOfClients.Add(busClientResponse.client);
                }
            }

            if (listOfClients.Count <= 0)
                return;

            string subject = "Document updated";
            string body = "The document "+document.Name+" has been updated.";

            var resp = SendEmailToGroup(
                clientList: listOfClients, 
                iSubject: subject, 
                iBody: body, 
                Attachment: filePathName);

            MessageBox.Show(resp.Message);

            Cursor.Current = Cursors.Arrow;
        }

        /// <summary>
        /// Send email to group
        /// </summary>
        /// <param name="clientList"></param>
        public static ResponseStatus SendEmailToGroup(
                        List<Client> clientList,
                        string iSubject,
                        string iBody,
                        string Attachment)
        {
            ResponseStatus resp = new ResponseStatus();


            // FCM Dropbox
            // fcmdropbox01@gmail.com


            string from = "fcmnoreply@gmail.com";
            string password = "grahamc1";

            foreach (var client in clientList)
            {
                resp = FCMEmail.SendEmail(
                    iPassword: password,
                    iFrom: from,
                    iRecipient: client.EmailAddress,
                    iSubject: iSubject,
                    iBody: iBody,
                    iAttachmentLocation: Attachment);

                if (resp.ReturnCode < 0001)
                {
                    break;
                }
            }

            return resp;
        }
    }
}
