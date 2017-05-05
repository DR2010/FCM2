using System;
using System.Data;
using System.Windows.Forms;
using FCMMySQLBusinessLibrary.Model.ModelDocument;
using FCMMySQLBusinessLibrary.Model.ModelClient;
using FCMMySQLBusinessLibrary.FCMUtils;
using MackkadoITFramework.ReferenceData;

namespace fcm.Windows
{
    public partial class UIProposal : Form
    {
        public DataTable elementSourceDataTable;

        public UIProposal()
        {

            InitializeComponent();
            // _connectionString = connectionString;

            //
            // Create datatable
            //
            var CUID = new DataColumn("CUID", typeof(String));
            var Name = new DataColumn("Name", typeof(String));
            var Directory = new DataColumn("Directory", typeof(String));
            var Subdirectory = new DataColumn("Subdirectory", typeof(String));
            var SequenceNumber = new DataColumn("SequenceNumber", typeof(Int32));
            var IssueNumber = new DataColumn("IssueNumber", typeof(String));
            var Location = new DataColumn("Location", typeof(String));
            var Comments = new DataColumn("Comments", typeof(String));

            elementSourceDataTable = new DataTable("ElementSourceDataTable");

            elementSourceDataTable.Columns.Add(CUID);
            elementSourceDataTable.Columns.Add(Name);
            elementSourceDataTable.Columns.Add(Directory);
            elementSourceDataTable.Columns.Add(Subdirectory);
            elementSourceDataTable.Columns.Add(SequenceNumber);
            elementSourceDataTable.Columns.Add(IssueNumber);
            elementSourceDataTable.Columns.Add(Location);

            dgvDocumentList.DataSource = elementSourceDataTable;

        }

        private void UIProposal_Load(object sender, EventArgs e)
        {
            loadDocumentList();

            foreach (Client c in Utils.ClientList)
            {
                cbxClient.Items.Add(c.UID + "; " + c.Name);
            }
            cbxClient.SelectedIndex = Utils.ClientIndex;

            // Proposal Type
            
            var propTypeList = new CodeValue();
            propTypeList.ListInCombo(CodeType.CodeTypeValue.ProposalType, cbxProposalType);

            // Status
            var propStatusList = new CodeValue();
            propStatusList.ListInCombo(CodeType.CodeTypeValue.ProposalStatus, cbxStatus);

        }

        //
        // List companies
        //
        private void loadDocumentList()
        {
            elementSourceDataTable.Clear();

            var docoList = new DocumentList();
            docoList.List();

            foreach (Document doco in docoList.documentList)
            {
                DataRow elementRow = elementSourceDataTable.NewRow();
                elementRow["CUID"] = doco.CUID;
                elementRow["Name"] = doco.Name;
                //elementRow["Directory"] = doco.Directory;
                //elementRow["Subdirectory"] = doco.Subdirectory;
                elementRow["SequenceNumber"] = doco.SequenceNumber;
                elementRow["IssueNumber"] = doco.IssueNumber;
                elementRow["Location"] = doco.Location;

                elementSourceDataTable.Rows.Add(elementRow);

            }
        }

        private void cbxClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            Utils.ClientID = Utils.ClientList[cbxClient.SelectedIndex].UID;
            // Utils.ClientIndex = cbxClient.SelectedIndex;

        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var selRows in dgvDocumentList.SelectedRows)
            {
                dgvDocumentList.Rows.Remove((DataGridViewRow)selRows);
            }
        }
    }
}
