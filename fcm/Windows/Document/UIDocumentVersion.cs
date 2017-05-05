using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FCMMySQLBusinessLibrary;
using FCMMySQLBusinessLibrary.Model.ModelDocument;
using MackkadoITFramework.APIDocument;
using FCMMySQLBusinessLibrary.FCMUtils;

namespace fcm.Windows
{
    public partial class UIDocumentVersion : Form
    {
        public DataTable elementSourceDataTable;
        private Document _document;

        public UIDocumentVersion(Document document)
        {
            InitializeComponent();
            
            _document = document;

            var UID = new DataColumn("UID", typeof(String));
            var FKDocumentUID = new DataColumn("FKDocumentUID", typeof(String));
            var FKDocumentCUID = new DataColumn("FKDocumentCUID", typeof(String));
            var IssueNumber = new DataColumn("IssueNumber", typeof(String));
            var Location = new DataColumn("Location", typeof(String));
            var FileName = new DataColumn("FileName", typeof(String));

            elementSourceDataTable = new DataTable("ElementSourceDataTable");

            elementSourceDataTable.Columns.Add(IssueNumber);
            elementSourceDataTable.Columns.Add(FileName);
            elementSourceDataTable.Columns.Add(Location);
            elementSourceDataTable.Columns.Add(UID);
            elementSourceDataTable.Columns.Add(FKDocumentUID);
            elementSourceDataTable.Columns.Add(FKDocumentCUID);

            dgvIssueList.DataSource = elementSourceDataTable;

            txtDocumentID.Text = document.CUID;
            txtDocumentName.Text = document.Name;

        }

        private void UIDocumentIssue_Load(object sender, EventArgs e)
        {
            loadDocumentList();
        }

        //
        // List of issues 
        //
        public void loadDocumentList()
        {
            elementSourceDataTable.Clear();

            var docoList = DocumentVersion.List(_document);

            foreach (DocumentVersion doco in docoList)
            {
                DataRow elementRow = elementSourceDataTable.NewRow();
                elementRow["UID"] = doco.UID;
                elementRow["FileName"] = doco.FileName;
                elementRow["FKDocumentCUID"] = doco.FKDocumentCUID;
                elementRow["FKDocumentUID"] = doco.FKDocumentUID;
                elementRow["IssueNumber"] = doco.IssueNumber;
                elementRow["Location"] = doco.Location;

                elementSourceDataTable.Rows.Add(elementRow);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (dgvIssueList.SelectedRows.Count <= 0)
                return;

            var selectedRow = dgvIssueList.SelectedRows;

            var Location = selectedRow[0].Cells["Location"].Value.ToString();
            var FileName = selectedRow[0].Cells["FileName"].Value.ToString();

            string filePathName =
                     Utils.getFilePathName(Location,
                                           FileName);


            if (!string.IsNullOrEmpty(filePathName))
            {
                WordDocumentTasks.OpenDocument(filePathName, vkReadOnly: true);
            }
            else
            {
                MessageBox.Show(@"Document is empty.");
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvIssueList_CellMouseDown( object sender, DataGridViewCellMouseEventArgs e )
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                dgvIssueList.CurrentCell = dgvIssueList.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void tsmCompare_Click(object sender, EventArgs e)
        {
            // get current document
            //
            var currentLocation = _document.Location;
            var currentFileName = _document.FileName;
            var currentFileType = _document.DocumentType;

            // Get selected document from tree
            //

            //if (dgvDocumentList.SelectedRows.Count <= 0)
            //    return;


            if (dgvIssueList.SelectedRows.Count <= 0)
                return;

            var selectedRow = dgvIssueList.SelectedRows;


            var selectedLocation = "";
            var selectedFileName = "";
            var selectedFileType = "";

            foreach (var row in selectedRow)
            {
                DataGridViewRow dgvr = (DataGridViewRow)row;
                selectedLocation = dgvr.Cells["Location"].Value.ToString();
                selectedFileName = dgvr.Cells["FileName"].Value.ToString();
                selectedFileType = MackkadoITFramework.Helper.Utils.DocumentType.WORD; 
                     //  dgvr.Cells["Location"].Value.ToString();

                break;
            }

            string source = Utils.getFilePathName(currentLocation, currentFileName);
            string destination = Utils.getFilePathName(selectedLocation, selectedFileName);

            if (string.IsNullOrEmpty(source))
            {
                MessageBox.Show("Source file is empty.");
                return;
            }
            if (string.IsNullOrEmpty(destination))
            {
                MessageBox.Show("Destination file is empty.");
                return;
            }

            Utils.CompareDocuments(source, destination, MackkadoITFramework.Helper.Utils.DocumentType.WORD);

        }
    }
}
