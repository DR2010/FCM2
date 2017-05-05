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
    public partial class UIReportMetadata : Form
    {
        private string _userID;
        public DataTable elementSourceDataTable;

        public UIReportMetadata(string userID)
        {
            InitializeComponent();

            this._userID = userID;

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
            var TableName = new DataColumn("TableName", typeof(String));
            var FieldName = new DataColumn("FieldName", typeof(String));
            var FilePath = new DataColumn("FilePath", typeof(String));
            var FileName = new DataColumn("FileName", typeof(String));

            elementSourceDataTable = new DataTable("ElementSourceDataTable");

            elementSourceDataTable.Columns.Add(UID);
            elementSourceDataTable.Columns.Add(RecordType);
            elementSourceDataTable.Columns.Add(FieldCode);
            elementSourceDataTable.Columns.Add(Description);
            elementSourceDataTable.Columns.Add(ClientType);
            elementSourceDataTable.Columns.Add(ClientUID);
            elementSourceDataTable.Columns.Add(InformationType);
            elementSourceDataTable.Columns.Add(TableName);
            elementSourceDataTable.Columns.Add(FieldName);
            elementSourceDataTable.Columns.Add(FilePath);
            elementSourceDataTable.Columns.Add(FileName);

            dgvClientMetadata.DataSource = elementSourceDataTable;

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

            loadMetadataList(0);
        }

        // Toggle edit screen
        private void btnEditValue_Click(object sender, EventArgs e)
        {
            EditMetadata(false);
        }

        // Toggle edit screen
        private void dgvClientMetadata_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditMetadata(false);
        }

        // Update contents only
        private void dgvClientMetadata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EditMetadata(true);
        }

        // Using keyboard to change
        private void dgvClientMetadata_SelectionChanged(object sender, EventArgs e)
        {
            EditMetadata(true);
        }

        private void dgvClientMetadata_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditMetadata(false);

        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            EditMetadata(false);

        }

        private void ucReportMetadata1_Load(object sender, EventArgs e)
        {

        }


        //
        // List companies
        //
        public void loadMetadataList(int iUID)
        {
            elementSourceDataTable.Clear();
            int rts = 0;
            int cnt = 0;

            var metaList = new ReportMetadataList(_userID);
            metaList.List();

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
                elementRow["TableName"] = metadata.TableName;
                elementRow["FieldName"] = metadata.FieldName;
                elementRow["FilePath"] = metadata.FilePath;
                elementRow["FileName"] = metadata.FileName;

                elementSourceDataTable.Rows.Add(elementRow);

                if (metadata.UID == iUID)
                    rts = cnt;

                cnt++;
            }

            dgvClientMetadata.Rows[rts].Selected = true;
           
        }

        //
        // 
        //
        private void EditMetadata(bool RefreshOnly)
        {

            if (!RefreshOnly)
            {

                if (ucReportMetadata1.Visible == true)
                {
                    ucReportMetadata1.Visible = false;

                    loadMetadataList(0);

                    return;
                }

                ucReportMetadata1.Visible = true;

            }


            if (dgvClientMetadata.SelectedRows.Count <= 0)
                return;

            var selectedRow = dgvClientMetadata.SelectedRows;

            ReportMetadata rm = new ReportMetadata();

            rm.UID = Convert.ToInt32(selectedRow[0].Cells["UID"].Value);
            rm.RecordType = selectedRow[0].Cells["RecordType"].Value.ToString();
            rm.FieldCode = selectedRow[0].Cells["FieldCode"].Value.ToString();
            rm.ClientType = selectedRow[0].Cells["ClientType"].Value.ToString();
            rm.Description = selectedRow[0].Cells["Description"].Value.ToString();
            rm.ClientUID = Convert.ToInt32( selectedRow[0].Cells["ClientUID"].Value);
            rm.InformationType = selectedRow[0].Cells["InformationType"].Value.ToString();
            rm.TableName = selectedRow[0].Cells["TableName"].Value.ToString();
            rm.FieldName = selectedRow[0].Cells["FieldName"].Value.ToString();
            rm.FilePath = selectedRow[0].Cells["FilePath"].Value.ToString();
            rm.FileName = selectedRow[0].Cells["FileName"].Value.ToString();

            ucReportMetadata1.SetValues(rm);

        }

        private void miEdit_Click(object sender, EventArgs e)
        {
            EditMetadata(false);
        }

        private void miDelete_Click(object sender, EventArgs e)
        {

        }

    }
}
