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

        private void UIProposal_Load(object sender, EventArgs e)
        {
            loadDocumentList();

            foreach (Client c in Utils.ClientList.clientList)
            {
                cbxClient.Items.Add(c.UID + "; " + c.Name);
            }
            cbxClient.SelectedIndex = Utils.ClientIndex;

            // Proposal Type
            
            CodeValueList propTypeList = new CodeValueList();
            propTypeList.ListInCombo("PROPTYPE", cbxProposalType);

            // Status

            CodeValueList propStatusList = new CodeValueList();
            propTypeList.ListInCombo("PROPSTATUS", cbxStatus);

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
                elementRow["Directory"] = doco.Directory;
                elementRow["Subdirectory"] = doco.Subdirectory;
                elementRow["SequenceNumber"] = doco.SequenceNumber;
                elementRow["LatestIssueNumber"] = doco.LatestIssueNumber;
                elementRow["LatestIssueLocation"] = doco.LatestIssueLocation;

                elementSourceDataTable.Rows.Add(elementRow);

            }
        }

        private void cbxClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            Utils.ClientID = Utils.ClientList.clientList[cbxClient.SelectedIndex].UID;
            Utils.ClientIndex = cbxClient.SelectedIndex;

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
