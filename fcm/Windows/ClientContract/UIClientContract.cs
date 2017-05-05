using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FCMMySQLBusinessLibrary.Service.SVCClient.Contract;
using FCMMySQLBusinessLibrary.Service.SVCClient.Service;
using FCMMySQLBusinessLibrary.Model.ModelClient;
using FCMMySQLBusinessLibrary.FCMUtils;
using MackkadoITFramework.ReferenceData;
using FCMMySQLBusinessLibrary.Repository;
using MackkadoITFramework.Utils;


namespace fcm.Windows
{
    public partial class UIClientContract : Form
    {
        private List<ClientContract> clientContractList { set; get; }
        private ClientContract clientContract { set; get; }
        private Client client;
        private Form _comingFromForm;

        public UIClientContract(Form comingFromForm, Client iclient)
        {
            InitializeComponent();
            _comingFromForm = comingFromForm;

            client = iclient;

            txtContractID.Enabled = false;
            txtContractID.ReadOnly = true;
            txtClientName.Text = client.UID + " " + client.Name;

            clientContractList = new List<ClientContract>();
            clientContract = new ClientContract();
        }

        private void UIClientContract_Load(object sender, EventArgs e)
        {
            ListClientContract();

            var contractStatus = new CodeValue();
            contractStatus.ListInCombo(CodeType.CodeTypeValue.ContractStatus, comboBoxContractStatus);

            var contractType = new CodeValue();
            contractType.ListInCombo(CodeType.CodeTypeValue.ContractType, comboBoxContractType);

        }


        /// <summary>
        /// List client contract
        /// </summary>
        private void ListClientContract()
        {
            var response = BUSClientContract.ClientContractList(Utils.ClientID);
            clientContractList = (List<ClientContract>)response.Contents;

            try
            {
                clientContractBindingSource.DataSource = clientContractList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("P2 " + ex.ToString());
            }
            return;
        }

        /// <summary>
        /// Reset screen from IClientContract
        /// </summary>
        public void ResetScreen()
        {
            // not implemented
        }

        /// <summary>
        /// Display message on client
        /// </summary>
        /// <param name="msg"></param>
        public void DisplayMessage(string msg)
        {
            MessageBox.Show(msg);
            return;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtContractID.Text = "";
            txtExternalID.Text = "";

            dtpStartDate.Text = System.DateTime.Today.ToString( "yyyyMMdd" );
            dtpEndDate.Text = System.DateTime.Now.AddDays(365).ToString();

            dtpStartDate.Focus();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            
            if (string.IsNullOrEmpty( txtContractID.Text ))
            {
                clientContract.UID = 0;
                clientContract.CreationDateTime = System.DateTime.Now;
                clientContract.UserIdCreatedBy = Utils.UserID;
            }
            else
            {
                clientContract.UID = Convert.ToInt32(txtContractID.Text);
                // clientContract.CreationDateTime = Convert.ToDateTime( txtCreationDate.Text );

                // Compare fields
                if ( clientContract.ExternalID == txtExternalID.Text &&
                     clientContract.StartDate == dtpStartDate.Value &&
                     clientContract.EndDate == dtpEndDate.Value &&
                     clientContract.Type == comboBoxContractType.Text &&
                     clientContract.Status == comboBoxContractStatus.Text 
                )
                {
                    MessageBox.Show("Data has not been updated.");
                    return;
                }
            }

            // Fill in current data.
            //

            if (clientContract.UID > 0)
            {
                var boxedClientContract = BUSClientContract.Read(clientContract.UID);
                clientContract = (ClientContract) boxedClientContract.Contents;
            }

            clientContract.FKCompanyUID = Utils.ClientID;
            clientContract.ExternalID = txtExternalID.Text;
            clientContract.StartDate = dtpStartDate.Value;
            clientContract.EndDate = dtpEndDate.Value;
            clientContract.Type = comboBoxContractType.Text;
            clientContract.Status = comboBoxContractStatus.Text;
            clientContract.UpdateDateTime = System.DateTime.Now;
            clientContract.UserIdUpdatedBy = Utils.UserID;

            if (clientContract.UID == 0)
            {
                ClientContractAddRequest clientContractAddRequest = new ClientContractAddRequest();
                clientContractAddRequest.clientContract = clientContract;
                clientContractAddRequest.headerInfo = HeaderInfo.Instance;

                var response = new BUSClientContract().ClientContractAdd(clientContractAddRequest);
                MessageBox.Show(response.responseStatus.Message);
            }
            else
            {

                ClientContractUpdateRequest clientContractUpdateRequest = new ClientContractUpdateRequest();
                clientContractUpdateRequest.clientContract = clientContract;
                clientContractUpdateRequest.headerInfo = HeaderInfo.Instance;

                var response = new BUSClientContract().ClientContractUpdate(clientContractUpdateRequest);
                MessageBox.Show(response.responseStatus.Message);
            }

            Cursor.Current = Cursors.Arrow;

            ListClientContract();

        }

        private void dgvClientContract_SelectionChanged(object sender, EventArgs e)
        {
            SetScreenFieldsFromObject(clientContract);
        }

        private void SetScreenFieldsFromObject(ClientContract clientContract)
        {

            if (dgvClientContract.SelectedRows.Count <= 0)
                return;

            var selectedRow = dgvClientContract.SelectedRows;
            txtContractID.Text = selectedRow[0].Cells[FCMDBFieldName.ClientContract.UID].Value.ToString();
            txtExternalID.Text = selectedRow[0].Cells[FCMDBFieldName.ClientContract.ExternalID].Value.ToString();
            dtpStartDate.Value = Convert.ToDateTime(selectedRow[0].Cells[FCMDBFieldName.ClientContract.StartDate].Value);
            dtpEndDate.Value = Convert.ToDateTime(selectedRow[0].Cells[FCMDBFieldName.ClientContract.EndDate].Value);
            comboBoxContractType.Text = selectedRow[0].Cells[FCMDBFieldName.ClientContract.Type].Value.ToString();
            comboBoxContractStatus.Text = selectedRow[0].Cells[FCMDBFieldName.ClientContract.Status].Value.ToString();

            //txtCreationDate.Text = selectedRow[0].Cells[ClientContract.FieldName.CreationDateTime].Value.ToString();
            //txtUpdatedDate.Text = selectedRow[0].Cells[ClientContract.FieldName.UpdateDateTime].Value.ToString();
            //txtCreatedBy.Text = selectedRow[0].Cells[ClientContract.FieldName.UserIdCreatedBy].Value.ToString();
            //txtUpdatedBy.Text = selectedRow[0].Cells[ClientContract.FieldName.UserIdUpdatedBy].Value.ToString();

            // Load current object
            //
            LoadObjectFromUIFields();

        }

        private void txtCancel_Click(object sender, EventArgs e)
        {
            _comingFromForm.Activate();

            this.Dispose();
        }

        /// <summary>
        /// Load object from UI fields
        /// </summary>
        private void LoadObjectFromUIFields()
        {

            clientContract.FKCompanyUID = Utils.ClientID;
            clientContract.UID = Convert.ToInt32(txtContractID.Text);
            clientContract.ExternalID = txtExternalID.Text;
            clientContract.StartDate = dtpStartDate.Value;
            clientContract.EndDate = dtpEndDate.Value;
            clientContract.Type = comboBoxContractType.Text;
            clientContract.Status = comboBoxContractStatus.Text;
            //clientContract.UpdateDateTime = Convert.ToDateTime(txtUpdatedDate.Text);
            //clientContract.UserIdUpdatedBy = txtUpdatedBy.Text;
            //clientContract.CreationDateTime = Convert.ToDateTime(txtCreationDate.Text);
            // clientContract.UserIdCreatedBy = txtCreatedBy.Text;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            ClientContractDeleteRequest clientContractDeleteRequest = new ClientContractDeleteRequest();
            clientContractDeleteRequest.clientContract = clientContract;
            clientContractDeleteRequest.headerInfo = HeaderInfo.Instance;

            var response = BUSClientContract.ClientContractDelete(clientContractDeleteRequest);
            MessageBox.Show(response.responseStatus.Message);

            ListClientContract();

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _comingFromForm.Activate();

            this.Dispose();
        }
    }
}
