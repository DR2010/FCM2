using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FCMMySQLBusinessLibrary;
using FCMMySQLBusinessLibrary.Model.ModelMetadata;
using FCMMySQLBusinessLibrary.Service.SVCClient;
using FCMMySQLBusinessLibrary.Model.ModelClient;
using FCMMySQLBusinessLibrary.FCMUtils;

namespace fcm.Windows
{
    public partial class UIReportMetadata : Form
    {
        private string _userID;
        public DataTable elementSourceDataTable;
        private string listType;
        private int _clientUID;
        private Form _comingFromForm;

        public UIReportMetadata(Form comingFromForm)
            : this()
        {
            _comingFromForm = comingFromForm;
            listType = "DEFAULT";
        }
        // This constructor lists variables for a specific Client
        //
        public UIReportMetadata(Form comingFromForm, int clientUID): this()
        {
            btnList.Enabled = false;
            btnSelect.Visible = true;
            listType = "CLIENT";
            _clientUID = clientUID;
            cbxType.Enabled = false;
            cbxType.Text = listType;
            cbxClient.Enabled = false;

        }

        public UIReportMetadata(Form comingFromForm, bool DefaultOnly)
            : this()
        {
            btnList.Enabled = false;
            btnSelect.Visible = true;
            this.listType = "DEFAULT";
        }

        private UIReportMetadata()
        {
            InitializeComponent();

            btnSelect.Visible = false;

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
            var Enabled = new DataColumn("Enabled", typeof(String));
            var UseAsLabel = new DataColumn("UseAsLabel", typeof(String));

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
            elementSourceDataTable.Columns.Add(Enabled);
            elementSourceDataTable.Columns.Add(UseAsLabel);

            dgvClientMetadata.DataSource = elementSourceDataTable;

            ucReportMetadata1.Visible = false;
            cbxType.Text = "DEFAULT";
            loadMetadataList(0);

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            loadMetadataList(0);
        }

        private void UIGeneralMetadata_Load(object sender, EventArgs e)
        {
            ucReportMetadata1.Visible = false;
            // Pass this instance to the component to enable the manipulation/refresh
            // of the list
            //
            ucReportMetadata1.SetUIReportInst(this);

            // Define defaults
            cbxType.Text = "DEFAULT";

            loadMetadataList(0);

            // Get client list from background and load into the list
            //
            foreach (Client c in Utils.ClientList)
            {
                cbxClient.Items.Add(c.UID + "; " + c.Name);
            }

            // Get selected client from the background
            //
            cbxClient.SelectedIndex = Utils.ClientIndex;

        }

        // Toggle edit screen
        private void EditMetadata(object sender, DataGridViewCellEventArgs e)
        {
            EditMetadata(false);
        }

        //
        // List companies
        //
        public void loadMetadataList(int iUID)
        {
            elementSourceDataTable.Clear();
            int rts = -1;
            int cnt = 0;

            var metaList = new ReportMetadataList();

            if (string.IsNullOrEmpty(listType))
            {
                listType = "DEFAULT";
            }

            // List metadata for a client
            if (listType == "CLIENT")
            {
                metaList.ListMetadataForClient(Utils.ClientID);
            }
            else
            {
                metaList.ListDefault();
            }


            foreach (ReportMetadata metadata in metaList.reportMetadataList)
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
                elementRow["Enabled"] = metadata.Enabled;
                elementRow["UseAsLabel"] = metadata.UseAsLabel;

                elementSourceDataTable.Rows.Add(elementRow);

                if (metadata.UID == iUID)
                    rts = cnt;

                cnt++;
            }

            if (rts >= 0)
            {
                dgvClientMetadata.Rows[rts].Selected = true;
            }
        }

        //
        // 
        //
        public void EditMetadata(object sender, EventArgs e)
        {
            EditMetadata(false);
        }

        public void EditMetadataRefresh(object sender, EventArgs e)
        {
            // It only does the refresh
            EditMetadata(true);
        }

        //
        // this method shows the component to edit/ add
        // a new metadata record.
        //
        private void EditMetadata(bool RefreshOnly)
        {

            if (!RefreshOnly)
            {
                // Toggle edit component
                //
                if (ucReportMetadata1.Visible == true)
                {
                    ucReportMetadata1.Visible = false;

                    refreshList();

                    return;
                }

                ucReportMetadata1.Visible = true;

            }

            // if there are no records selected
            //
            if (dgvClientMetadata.SelectedRows.Count <= 0)
            {
                ucReportMetadata1.NewEntry(Utils.ClientID);
                return;
            }


            var selectedRow = dgvClientMetadata.SelectedRows;

            ReportMetadata rm = new ReportMetadata();

            rm.UID = Convert.ToInt32(selectedRow[0].Cells["UID"].Value);
            rm.RecordType = selectedRow[0].Cells["RecordType"].Value.ToString();
            rm.FieldCode = selectedRow[0].Cells["FieldCode"].Value.ToString();
            rm.ClientType = selectedRow[0].Cells["ClientType"].Value.ToString();
            rm.Description = selectedRow[0].Cells["Description"].Value.ToString();
            rm.ClientUID = Convert.ToInt32( selectedRow[0].Cells["ClientUID"].Value);
            rm.InformationType = selectedRow[0].Cells["InformationType"].Value.ToString();
            rm.Condition = selectedRow[0].Cells["Condition"].Value.ToString();
            rm.CompareWith = selectedRow[0].Cells["CompareWith"].Value.ToString();
            rm.Enabled = Convert.ToChar(selectedRow[0].Cells["Enabled"].Value);
            rm.UseAsLabel = Convert.ToChar(selectedRow[0].Cells["UseAsLabel"].Value);

            ucReportMetadata1.SetValues(rm);
            
        }

        private void miEdit_Click(object sender, EventArgs e)
        {
            EditMetadata(false);
        }

        private void miDelete_Click(object sender, EventArgs e)
        {

        }

        private void UIReportMetadata_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_comingFromForm == null)
            {
                // Do nothing
            }
            else
            {
                _comingFromForm.Activate();

            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            refreshList();
        }

        public void refreshList()
        {

            if (string.IsNullOrEmpty(cbxType.Text))
            { 
                if (string.IsNullOrEmpty(listType))
                    listType = "DEFAULT";
            }
            else
                listType = cbxType.Text;


            if (listType == "CLIENT")
            {
                _clientUID = Utils.ClientID;
            }

            loadMetadataList(0);
        }


        // When client is changed or the client document set is changed
        //
        private void indexChanged(object sender, EventArgs e)
        {
            listType = cbxType.Text;
            if (cbxType.Text == "DEFAULT")
            {
                cbxClient.Enabled = false;
            }
            else
            {
                cbxClient.Enabled = true;
            }
            
            if (cbxClient.SelectedIndex >= 0)
            {
                // Get selected client
                //
                // Find selected item
                // Utils.ClientIndex = cbxClient.SelectedIndex;

                // Extract client id
                Utils.ClientID = Utils.ClientList[Utils.ClientIndex].UID;
            }

            refreshList();
        
        }

        private void UIReportMetadata_Load(object sender, EventArgs e)
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
            cbxClient.Enabled = false;

            cbxType.Text = listType;
            // cbxType.SelectedIndex = 0;

            ucReportMetadata1.Visible = false;

        }

        private void btnNew_Click(object sender, EventArgs e)
        {

            ucReportMetadata1.NewEntry(0);
            ucReportMetadata1.Visible = true;
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }
}
