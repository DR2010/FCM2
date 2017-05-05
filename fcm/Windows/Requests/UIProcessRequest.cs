using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MackkadoITFramework.ProcessRequest;

namespace fcm.Windows
{
    public partial class UIProcessRequest : Form
    {
        List<ProcessRequest> processRequestList;
        List<ProcessRequestResults> processRequestResultList;

        public UIProcessRequest()
        {
            InitializeComponent();
        }

        private void UIProcessRequest_Load(object sender, EventArgs e)
        {
            processRequestList = new List<ProcessRequest>();
            ListProcessRequest();


        }

        /// <summary>
        /// List employees
        /// </summary>
        private void ListProcessRequest()
        {
            processRequestList = ProcessRequest.List(ProcessRequest.StatusValue.ALL);

            try
            {
                bsProcessRequest.DataSource = processRequestList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Binding Error:  " + ex.ToString());
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        
        }

        private void dgvRequests_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvRequests_SelectionChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshList();
        }


        /// <summary>
        /// Refresh List
        /// </summary>
        private void RefreshList()
        {
            if (dgvRequests.SelectedRows.Count <= 0)
                return;

            var selectedRow = dgvRequests.SelectedRows;

            var uidString = selectedRow[0].Cells["dgv" + ProcessRequest.FieldName.UID].Value.ToString();
            var description = selectedRow[0].Cells["dgv" + ProcessRequest.FieldName.Description].Value.ToString();
            var fkclientuid = selectedRow[0].Cells["dgv" + ProcessRequest.FieldName.FKClientUID].Value.ToString();
            var type = selectedRow[0].Cells["dgv" + ProcessRequest.FieldName.Type].Value.ToString();
            var status = selectedRow[0].Cells["dgv" + ProcessRequest.FieldName.Status].Value.ToString();
            var whentoprocess = selectedRow[0].Cells["dgv" + ProcessRequest.FieldName.WhenToProcess].Value.ToString();
            var creationDateTime = selectedRow[0].Cells["dgv" + ProcessRequest.FieldName.CreationDateTime].Value.ToString();
            var statusDateTime = selectedRow[0].Cells["dgv" + ProcessRequest.FieldName.StatusDateTime].Value.ToString();
            var plannedDateTime = selectedRow[0].Cells["dgv" + ProcessRequest.FieldName.PlannedDateTime].Value.ToString();

            processRequestResultList = new List<ProcessRequestResults>();

            int uidInt = Convert.ToInt32(uidString);

            processRequestResultList = ProcessRequestResults.List(uidInt);

            bsProcessRequestResults.Clear();
            bsProcessRequestResults.DataSource = processRequestResultList;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
