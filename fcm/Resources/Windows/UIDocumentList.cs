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
    public partial class UIDocumentList : Form
    {
        public DataTable elementSourceDataTable;

        public UIDocumentList()
        {
            InitializeComponent();
            // _connectionString = connectionString;

            // Create datatable
            
            var CUID = new DataColumn("CUID", typeof(String));
            var Name = new DataColumn("Name", typeof(String));
            var Directory = new DataColumn("Directory", typeof(String));
            var Subdirectory = new DataColumn("Subdirectory", typeof(String));
            var SequenceNumber = new DataColumn("SequenceNumber", typeof(String));
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
            elementSourceDataTable.Columns.Add(Comments);

            dgvDocumentList.DataSource = elementSourceDataTable;
        }

        private void UITemplateFiles_Load(object sender, EventArgs e)
        {
            // ucDocument1.Visible = false;
            
            loadDocumentList();

        }

        override public void Refresh()
        {
            loadDocumentList();
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
                elementRow["Comments"] = doco.Comments;

                elementSourceDataTable.Rows.Add(elementRow);

            }

        }

        private void dgvDocumentList_SelectionChanged(object sender, EventArgs e)
        {

        }


        private void btnDocumentDetails_Click(object sender, EventArgs e)
        {
            //EditMetadata(false);

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditMetadata();
        }

        private void EditMetadata()
        {

            UIDocumentEdit uide = new UIDocumentEdit(this);

            if (dgvDocumentList.SelectedRows.Count <= 0)
                return;

            var selectedRow = dgvDocumentList.SelectedRows;

            Document rm = new Document();

            rm.CUID = selectedRow[0].Cells["CUID"].Value.ToString();
            rm.Directory = selectedRow[0].Cells["Directory"].Value.ToString();
            rm.LatestIssueLocation = selectedRow[0].Cells["LatestIssueLocation"].Value.ToString();
            rm.LatestIssueNumber = selectedRow[0].Cells["LatestIssueNumber"].Value.ToString();
            rm.Name = selectedRow[0].Cells["Name"].Value.ToString();
            rm.SequenceNumber = selectedRow[0].Cells["SequenceNumber"].Value.ToString();
            rm.Subdirectory = selectedRow[0].Cells["Subdirectory"].Value.ToString();
            rm.Comments = selectedRow[0].Cells["Comments"].Value.ToString();

            uide.SetValues(rm);

            uide.Show();


        }

        private void dgvDocumentList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditMetadata();
        }
    }
}
