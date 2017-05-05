using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace fcm.Windows
{
    public partial class UIClientDocumentSet : Form
    {
        public DataTable elementSourceDataTable;
        private int documentSetID;

        public UIClientDocumentSet()
        {
            InitializeComponent();
            CreateDataTable();
        }

        public UIClientDocumentSet(string ClientID)
        {
            InitializeComponent();
            CreateDataTable();
            cbxClient.Enabled = false;
        }

        public void CreateDataTable()
        {
            //
            // Create datatable
            //
            var CUID = new DataColumn("CUID", typeof(String));
            var Name = new DataColumn("Name", typeof(String));
            var Directory = new DataColumn("Directory", typeof(String));
            var Subdirectory = new DataColumn("Subdirectory", typeof(String));
            var SequenceNumber = new DataColumn("SequenceNumber", typeof(Int32));
            var LatestIssueNumber = new DataColumn("LatestIssueNumber", typeof(String));
            var LatestIssueLocation = new DataColumn("LatestIssueLocation", typeof(String));
            var Comments = new DataColumn("Comments", typeof(String));

            elementSourceDataTable = new DataTable("ElementSourceDataTable");

            elementSourceDataTable.Columns.Add(CUID);
            elementSourceDataTable.Columns.Add(Name);
            elementSourceDataTable.Columns.Add(Directory);
            elementSourceDataTable.Columns.Add(Subdirectory);
            elementSourceDataTable.Columns.Add(SequenceNumber);
            elementSourceDataTable.Columns.Add(LatestIssueNumber);
            elementSourceDataTable.Columns.Add(LatestIssueLocation);

            dgvDocumentList.DataSource = elementSourceDataTable;

        }

        private void UIClientDocumentSet_Load(object sender, EventArgs e)
        {
            foreach (Client c in Utils.ClientList.clientList)
            {
                cbxClient.Items.Add(c.UID + "; " + c.Name);
            }
            // Retrieve current client from background
            //
            cbxClient.SelectedIndex = Utils.ClientIndex;

            // List document sets for a client
            //
            ClientDocumentSetList cdsl = new ClientDocumentSetList();
            cdsl.List(Utils.ClientID);

            foreach (ClientDocumentSet cds in cdsl.documentSetList)
            {
                cbxDocumentSet.Items.Add(cds.UID + "; "+ cds.Description);
            }
            
            // Retrieve document set for a client
            //
            ClientDocumentSet clientDocSet = new ClientDocumentSet();
            documentSetID = 1;
            clientDocSet.Get(Utils.ClientID, documentSetID);
            cbxDocumentSet.SelectedIndex = 0;

            // If this is the first time the client is selected, this program
            // will copy all documents to a client before displaying the list.
            // The list will always come from the client
            // The intention is to use the client type to get the correct
            // Document set before copying the documents to the client
            //
            
            loadDocumentList();

        }
        //
        // List companies
        //
        private void loadDocumentList()
        {
            elementSourceDataTable.Clear();

            // Check if the client has a list of documents for the template
            //
            ClientDocumentSet cds = new ClientDocumentSet();
            if (cds.Get(Utils.ClientID, documentSetID))
            {
                // Just proceed to list 
            }
            else
            {
                // Copy the recors to the client first
            }


            var docoList = new DocumentList();
            docoList.List();

            foreach (Document doco in docoList.documentList)
            {
                DataRow elementRow = elementSourceDataTable.NewRow();
                elementRow["CUID"] = doco.CUID;
                elementRow["Name"] = doco.Name;
                elementRow["Directory"] = doco.Directory;
                elementRow["Subdirectory"] = doco.Subdirectory;
                elementRow["SequenceNumber"] = doco.SequenceNumber;
                elementRow["LatestIssueNumber"] = doco.LatestIssueNumber;
                elementRow["LatestIssueLocation"] = doco.LatestIssueLocation;

                elementSourceDataTable.Rows.Add(elementRow);

            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var selRows in dgvDocumentList.SelectedRows)
            {
                dgvDocumentList.Rows.Remove((DataGridViewRow)selRows);
            }
        }

        private void cbxClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            Utils.ClientID = Utils.ClientList.clientList[cbxClient.SelectedIndex].UID;
            Utils.ClientIndex = cbxClient.SelectedIndex;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Utils.ClientIndex = cbxClient.SelectedIndex;
            Utils.ClientID = Utils.ClientList.clientList[Utils.ClientIndex].UID;

            string [] part = cbxDocumentSet.SelectedItem.ToString().Split(';');
            documentSetID = Convert.ToInt32( part[0] );


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnGenerateProjectFiles_Click(object sender, EventArgs e)
        {
            UIClientMetadata ucm = new UIClientMetadata();
            ucm.Show();

        }

        // -----------------------------------------------------
        //   This method replicates folders and files for a given
        //   folder structure (source and destination)
        // -----------------------------------------------------
        private void ReplicateFolderFilesReplace()
        {
            Cursor.Current = Cursors.WaitCursor;

            Word.ApplicationClass vkWordApp =
                                new Word.ApplicationClass();

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

        private void btnSelectDestination_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

        }


    }
}
