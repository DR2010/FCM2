using System;
using System.Data;
using System.Windows.Forms;
using FCMMySQLBusinessLibrary;
using FCMMySQLBusinessLibrary.Model.ModelClient;
using FCMMySQLBusinessLibrary.FCMUtils;
using FCMMySQLBusinessLibrary.Model.ModelClientDocument;
using FCMMySQLBusinessLibrary.Model.ModelMetadata;

namespace fcm.Windows
{
    public partial class UIClientMetadata : Form
    {

        public DataTable elementSourceDataTable;
        public DataTable dtAvailableMetadata;
        private Client client;
        private Form _comingFromForm;

        public UIClientMetadata(Form comingFromForm)
        {

            InitializeComponent();

            _comingFromForm = comingFromForm;

            //
            // Create datatable
            //
            var UID = new DataColumn("UID", typeof(String));
            var RecordType = new DataColumn("RecordType", typeof(String));
            var FieldCode = new DataColumn("FieldCode", typeof(String));
            var Description = new DataColumn("Description", typeof(String));
            var ClientType = new DataColumn("ClientType", typeof(String));
            var ClientUID = new DataColumn("ClientUID", typeof(String));
            var InformationType = new DataColumn("InformationType", typeof(String));
            var Condition = new DataColumn("Condition", typeof(String));
            var CompareWith = new DataColumn("CompareWith", typeof(String));

            // Client Metadata
            //
            elementSourceDataTable = new DataTable("ElementSourceDataTable");

            elementSourceDataTable.Columns.Add(UID);
            elementSourceDataTable.Columns.Add(RecordType);
            elementSourceDataTable.Columns.Add(FieldCode);
            elementSourceDataTable.Columns.Add(Description);
            elementSourceDataTable.Columns.Add(ClientType);
            elementSourceDataTable.Columns.Add(ClientUID);
            elementSourceDataTable.Columns.Add(InformationType);
            elementSourceDataTable.Columns.Add(Condition);
            elementSourceDataTable.Columns.Add(CompareWith);

            dgvClientMetadata.DataSource = elementSourceDataTable;

            //
            // Create Available Metadata datatable
            //
            var AMUID = new DataColumn("UID", typeof(String));
            var AMRecordType = new DataColumn("RecordType", typeof(String));
            var AMFieldCode = new DataColumn("FieldCode", typeof(String));
            var AMDescription = new DataColumn("Description", typeof(String));
            var AMClientType = new DataColumn("ClientType", typeof(String));
            var AMClientUID = new DataColumn("ClientUID", typeof(String));
            var AMInformationType = new DataColumn("InformationType", typeof(String));
            var AMCondition = new DataColumn("Condition", typeof(String));
            var AMCompareWith = new DataColumn("CompareWith", typeof(String));
            
            // Available Metadata
            //
            dtAvailableMetadata = new DataTable("dtAvailableMetadata");

            dtAvailableMetadata.Columns.Add(AMUID);
            dtAvailableMetadata.Columns.Add(AMRecordType);
            dtAvailableMetadata.Columns.Add(AMFieldCode);
            dtAvailableMetadata.Columns.Add(AMDescription);
            dtAvailableMetadata.Columns.Add(AMClientType);
            dtAvailableMetadata.Columns.Add(AMClientUID);
            dtAvailableMetadata.Columns.Add(AMInformationType);
            dtAvailableMetadata.Columns.Add(AMCondition);
            dtAvailableMetadata.Columns.Add(AMCompareWith);

            dgvAvailableMetadata.DataSource = dtAvailableMetadata;

        }

        private void UIClientMetadata_Load(object sender, EventArgs e)
        {
            
            // Get client list from background and load into the list
            //
            foreach (Client c in Utils.ClientList)
            {
                cbxClient.Items.Add(c.UID + "; " + c.Name);
            }

            // Get selected client from the background
            //
            cbxClient.SelectedIndex = Utils.ClientIndex;
            cbxDocumentSet.Text = Utils.ClientSetText;
            cbxDocumentSet.Enabled = false;

            cbxClient.Enabled = false;

            //
            // Retrieve document set for a client
            //
            ClientDocumentSet clientDocSet = new ClientDocumentSet();

            clientDocSet.Get(Utils.ClientID, Utils.ClientSetID);
            cbxDocumentSet.SelectedItem = 0;

            txtSourceFolder.Text = clientDocSet.SourceFolder;
            txtDestinationFolder.Text = clientDocSet.Folder;

            loadList();
        }

        private void dgvAvailableMetadata_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // This is the double-click on the available list
            //
            // Get selected row
            if (dgvAvailableMetadata.SelectedRows.Count <= 0)
                return;

            var selectedRow = dgvAvailableMetadata.SelectedRows;
            ReportMetadata rm = new ReportMetadata();

            ConvertSelectedRow(rm, selectedRow[0]);

            // Insert into db with client id

            rm.ClientUID = Utils.ClientID;
            rm.UID = 0;
            rm.RecordType = "CL";
            rm.Save();

            // Reload lists
            //
            loadList();
        }

        private void loadList()
        {
            elementSourceDataTable.Rows.Clear();
            dtAvailableMetadata.Rows.Clear();

            // Load client metadata
            ReportMetadataList rmd = new ReportMetadataList();
            rmd.ListMetadataForClient(Utils.ClientID);

            foreach (ReportMetadata metadata in rmd.reportMetadataList)
            {

                DataRow elementRow = elementSourceDataTable.NewRow();
                elementRow["UID"] = metadata.UID;
                elementRow["RecordType"] = metadata.RecordType;
                elementRow["FieldCode"] = metadata.FieldCode;
                elementRow["Description"] = metadata.Description;
                elementRow["ClientType"] = metadata.ClientType;
                elementRow["ClientUID"] = metadata.ClientUID;
                elementRow["InformationType"] = metadata.InformationType;
                elementRow["Condition"] = metadata.Condition;
                elementRow["CompareWith"] = metadata.CompareWith;

                elementSourceDataTable.Rows.Add(elementRow);

            }

            // Load available metadata
            ReportMetadataList rmdavailable = new ReportMetadataList();
            rmdavailable.ListAvailableForClient(Utils.ClientID);

            foreach (ReportMetadata metadata in rmdavailable.reportMetadataList)
            {

                DataRow elementRow = dtAvailableMetadata.NewRow();
                elementRow["UID"] = metadata.UID;
                elementRow["RecordType"] = metadata.RecordType;
                elementRow["FieldCode"] = metadata.FieldCode;
                elementRow["Description"] = metadata.Description;
                elementRow["ClientType"] = metadata.ClientType;
                elementRow["ClientUID"] = metadata.ClientUID;
                elementRow["InformationType"] = metadata.InformationType;
                elementRow["Condition"] = metadata.Condition;
                elementRow["CompareWith"] = metadata.CompareWith;

                dtAvailableMetadata.Rows.Add(elementRow);

            }

        }

        private void GetSelectedRow(ReportMetadata rm, int rowSubscript)
        {
            if (dgvAvailableMetadata.SelectedRows.Count <= 0)
                return;

            if (dgvAvailableMetadata.SelectedRows.Count < rowSubscript)
                return;

            var selectedRow = dgvAvailableMetadata.SelectedRows;

            ConvertSelectedRow(rm, selectedRow[rowSubscript]);

            return;
        }

        private void ConvertSelectedRow(ReportMetadata rm, DataGridViewRow selectedRow)
        {

            rm.UID = Convert.ToInt32(selectedRow.Cells["UID"].Value.ToString());
            rm.RecordType = selectedRow.Cells["RecordType"].Value.ToString();
            rm.FieldCode = selectedRow.Cells["FieldCode"].Value.ToString();
            rm.Description = selectedRow.Cells["Description"].Value.ToString();
            rm.ClientType = selectedRow.Cells["ClientType"].Value.ToString();
            rm.ClientUID = Convert.ToInt32(selectedRow.Cells["ClientUID"].Value.ToString());
            rm.InformationType = selectedRow.Cells["InformationType"].Value.ToString();
            rm.Condition = selectedRow.Cells["Condition"].Value.ToString();
            rm.CompareWith = selectedRow.Cells["CompareWith"].Value.ToString();

            return;
        }

        //
        // Double click on client metadata list 
        // The idea is to remove the metadata
        // 
        private void dgvClientMetadata_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // This is the double-click on the available list
            //
            // Get selected row
            if (dgvClientMetadata.SelectedRows.Count <= 0)
                return;

            var selectedRow = dgvClientMetadata.SelectedRows;
            ReportMetadata rm = new ReportMetadata();

            ConvertSelectedRow(rm, selectedRow[0]);

            // Insert into db with client id

            rm.Delete();

            // Reload lists
            //
            loadList();

        }

        private void UIClientMetadata_FormClosed(object sender, FormClosedEventArgs e)
        {
            _comingFromForm.Activate();
            _comingFromForm.Refresh();

            UIClientDocumentSet uicds = new UIClientDocumentSet();
            uicds = (UIClientDocumentSet)_comingFromForm;
            uicds.RefreshMetadata();
        }

        // Back to previous form
        //
        private void btnBack_Click(object sender, EventArgs e)
        {
            _comingFromForm.Activate();
            _comingFromForm.Refresh();

            this.Dispose();
        }

        private void cbxClient_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
           UIReportMetadata uirmdt = new UIReportMetadata(this, Utils.ClientID);
            uirmdt.ShowDialog();

            this.loadList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void dgvClientMetadata_CellMouseDown( object sender, DataGridViewCellMouseEventArgs e )
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                dgvClientMetadata.CurrentCell = dgvClientMetadata.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void dgvAvailableMetadata_CellMouseDown( object sender, DataGridViewCellMouseEventArgs e )
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                dgvAvailableMetadata.CurrentCell = dgvAvailableMetadata.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }
    }
}
