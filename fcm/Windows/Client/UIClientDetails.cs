using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FCMMySQLBusinessLibrary;
using FCMMySQLBusinessLibrary.Model.ModelDocument;
using FCMMySQLBusinessLibrary.Model.ModelMetadata;
using FCMMySQLBusinessLibrary.Service.SVCClient.Contract;
using FCMMySQLBusinessLibrary.Service.SVCClient.Service;
using FCMMySQLBusinessLibrary.Model.ModelClient;
using FCMMySQLBusinessLibrary.FCMUtils;
using FCMMySQLBusinessLibrary.Service.SVCClient.ServiceContract;
using MackkadoITFramework.ErrorHandling;
using MackkadoITFramework.ReferenceData;
using MackkadoITFramework.Security;
using MackkadoITFramework.Utils;
using Utils = FCMMySQLBusinessLibrary.FCMUtils.Utils;
using FCMMySQLBusinessLibrary.Repository;
using FCMMySQLBusinessLibrary.Repository.RepositoryClient;

namespace fcm.Windows
{
    public partial class UIClientDetails : Form
    {
        private Form _callingForm;
        private int currentRowPosition;
        private Client original;
        private Client client;
        private ClientExtraInformation clientExtraInformation;

        public ResponseStatus response { get; set; }

        public List<Client> clientList { set; get; }

        public List<ClientContract> clientContractList { set; get; }
        public ClientContract clientContract { set; get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="callingForm"></param>
        public UIClientDetails(Form callingForm)
        {
            _callingForm = callingForm;

            InitializeComponent();
            original = new Client(HeaderInfo.Instance);
            setCurrentRowPosition(0);

            clientContractList = new List<ClientContract>();
            clientContract = new ClientContract();

            clientList = new List<Client>();

            // bindingSourceClient.DataSource = clientList;
            bsClient.DataSource = clientList;

            client = new Client(HeaderInfo.Instance);
            clientExtraInformation = new ClientExtraInformation();

            // Load User ID
            //
            var ua = UserAccess.List();
            foreach (var user in ua)
            {
                comboUserID.Items.Add(user.UserID);
            }

            // Load Contractor Size
            //
            DocumentSetList dsl = new DocumentSetList();
            dsl.List();
            foreach (var documentSet in dsl.documentSetList)
            {
                comboContractorSize.Items.Add(documentSet.UIDNameDisplay);
            }


            // ucClientOtherInfo1.PopulateData(Utils.ClientID);

        }

        /// <summary>
        /// Set current row position
        /// </summary>
        /// <param name="currRow"></param>
        private void setCurrentRowPosition(int currRow)
        {
            // Set the variable that controls the current row
            currentRowPosition = currRow;
        }


        // --------------------------------------------------
        //              Save click
        // --------------------------------------------------
        private void btnSave_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            SaveClient();

            Cursor.Current = Cursors.Arrow;
        }

        private void checkDisplayLogo_CheckedChanged( object sender, EventArgs e )
        {

            // UpdateLogoStatus();


        }

        private void ClientDetails_Load(object sender, EventArgs e)
        {
            ListClient();
            ListClientContract();
        
        }

        /// <summary>
        /// List employees
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

        private void btnAddNewClient_Click(object sender, EventArgs e)
        {
            txtABN.Text = "";
            txtAddress.Text = "";
            txtContactPerson.Text = "";
            txtEmailAddress.Text = "";
            txtFax.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            txtUID.Text = "";
            cbxAssociateInitialSet.Checked = false;
            comboContractorSize.Text = "";
            comboUserID.Text = "";

            Bitmap MyImage;
            pbxLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            string filePathName = Utils.getFilePathName(FCMConstant.SYSFOLDER.LOGOFOLDER, "imgNoImage.jpg");
            MyImage = new Bitmap(filePathName);
            pbxLogo.Image = (Image)MyImage;

            Utils.ClientID = 0;

        }

        private void dgvClientList_SelectionChanged(object sender, EventArgs e)
        {

            ShowClientDetails();

            int t = 0;
            if (dgvClientList.CurrentRow == null)
                t = 0;
            else
                t = dgvClientList.CurrentRow.Index;

            setCurrentRowPosition(t);


        }


        private void btnDocuments_Click(object sender, EventArgs e)
        {
            UIClientDocumentSet ucds = new UIClientDocumentSet();

            ucds.Show();
        }

        private void dgvClientList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            if (_callingForm != null)
            {
                _callingForm.Show();
                _callingForm.Activate();
            }

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var answer = MessageBox.Show("Are you sure? Do you really want to delete the client?",
                                         "Delete Client", 
                                         MessageBoxButtons.YesNo);

            if (answer == DialogResult.Yes)
            {

                Client client = new Client(HeaderInfo.Instance);
                client.UID = Utils.ClientID;

                var response = new BUSClient().ClientDelete(new ClientDeleteRequest() { clientUID = client.UID, headerInfo = HeaderInfo.Instance });

                ListClient();
            }
        }

        private void txtUID_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUID.Text))
            {
                pbxLogo.Enabled = false;
            }
            else
            {
                pbxLogo.Enabled = true;
            }
        }

        private void btnChangeLogo_Click(object sender, EventArgs e)
        {
            // Show file dialog
            var file = openFileDialog1.ShowDialog();

            if (file == DialogResult.OK)
            {
                // Only File Name
                string fileName = openFileDialog1.SafeFileName;
                // Full Path including file name
                string fullPathFileName = openFileDialog1.FileName;

                // Extract File Path
                string pathOnly = fullPathFileName.Replace(fileName, "");

                // Get Company Logo
                //
                ReportMetadata rmd = new ReportMetadata();
                rmd.ClientUID = Utils.ClientID;
                rmd.RecordType = FCMConstant.MetadataRecordType.CLIENT;
                rmd.FieldCode = "COMPANYLOGO";

                rmd.Read(clientUID: Utils.ClientID, fieldCode: "COMPANYLOGO");

                rmd.InformationType = MackkadoITFramework.Helper.Utils.InformationType.IMAGE;
                rmd.ClientType = "";
                rmd.CompareWith = "";
                rmd.Description = "Company";
                // rmd.Condition = fullPathFileName;
                var logoFolder =
                    CodeValue.GetCodeValueExtended(FCMConstant.CodeTypeString.SYSTSET, FCMConstant.SYSFOLDER.LOGOFOLDER);

                // rmd.Condition = logoFolder + fileName;

                // The intention is to save the reference path %XXX%
                //
                rmd.Condition = FCMConstant.SYSFOLDER.LOGOFOLDER + fileName;

                rmd.Save();

                Bitmap MyImage;
                pbxLogo.SizeMode = PictureBoxSizeMode.StretchImage;
                if (rmd.Condition != null)
                {
                    // MyImage = new Bitmap(rmd.Condition);
                    MyImage = new Bitmap(logoFolder + fileName);
                    pbxLogo.Image = (Image)MyImage;
                }
            }
        }

        private bool dataHasChanged()
        {
            bool UnsavedData;

            if (txtName.Text == original.Name &&
                txtABN.Text == original.ABN &&
                txtAddress.Text == original.Address &&
                txtContactPerson.Text == original.MainContactPersonName &&
                txtEmailAddress.Text == original.EmailAddress &&
                txtFax.Text == original.Fax &&
                txtPhone.Text == original.Phone)
            {
                UnsavedData = false;
            }
            else
            {
                UnsavedData = true;
            }

            return UnsavedData;
        }

        private void tsRefresh_Click( object sender, EventArgs e )
        {
            ListClient();
            // loadClientList( Utils.ClientID );
        }

        private void dgvClientList_CellMouseDown( object sender, DataGridViewCellMouseEventArgs e )
        {
            if( e.ColumnIndex >= 0 && e.RowIndex >= 0 )
            {
                dgvClientList.CurrentCell = dgvClientList.Rows[e.RowIndex].Cells[ e.ColumnIndex ];
            }

        }

        // ------------------------------------------------------
        // IClientDetails implemented
        // ------------------------------------------------------

        private void ListClient()
        {

            var clientList = new Client(HeaderInfo.Instance);

            // bindingSourceClient.DataSource = clientList;
            bsClient.DataSource = clientList;
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

        /// <summary>
        /// Add/ Update client
        /// </summary>
        /// <param name="client"></param>
        public void SaveClient()
        {

            if (string.IsNullOrEmpty(txtUID.Text))
                client.UID = 0;
            else
                client.UID = Convert.ToInt32(txtUID.Text);

            client.ABN = txtABN.Text;
            client.Name = txtName.Text;
            client.Address = txtAddress.Text;
            client.Phone = txtPhone.Text;
            client.Fax = txtFax.Text;
            client.EmailAddress = txtEmailAddress.Text;
            client.MainContactPersonName = txtContactPerson.Text;
            client.FKUserID = comboUserID.Text;
            client.DocSetUIDDisplay = comboContractorSize.Text;
            if (string.IsNullOrEmpty(client.DocSetUIDDisplay ))
            {
               client.FKDocumentSetUID = 0;
            }
            else
            {
                string[] part = client.DocSetUIDDisplay.Split(';');
                client.FKDocumentSetUID = Convert.ToInt32(part[0]);
            }

            client.DisplayLogo = checkDisplayLogo.Checked ? 'Y' : 'N';

            // Check if it is to add / update
            if (client.UID <= 0)
            {
                string associateInitialSet = "N";
                if (cbxAssociateInitialSet.Checked)
                    associateInitialSet = "Y";

                var response = new BUSClient().ClientAdd(new ClientAddRequest() { headerInfo = HeaderInfo.Instance, eventClient = client, linkInitialSet = associateInitialSet });

            }
            else
            {

                var response = new BUSClient().ClientUpdate( new ClientUpdateRequest() { eventClient = client, headerInfo = HeaderInfo.Instance } );

                ReplaceRowSelected();
            }

            // Refresh client list
            // 
            Utils.ClientID = client.UID;

            var responseClientList = new BUSClient().ClientList(HeaderInfo.Instance);

            Utils.ClientList = responseClientList.clientList;

            ListClient();

        }

        /// <summary>
        /// Update UI grid by replacing row selected with updated details
        /// </summary>
        public void ReplaceRowSelected()
        {
            if (dgvClientList.SelectedRows.Count <= 0)
                return;

            var selectedRow = dgvClientList.SelectedRows;

            selectedRow[0].Cells["dgv" + FCMDBFieldName.Client.UID].Value = txtUID.Text;
            selectedRow[0].Cells["dgv" + FCMDBFieldName.Client.ABN].Value = txtABN.Text;
            selectedRow[0].Cells["dgv" + FCMDBFieldName.Client.Name].Value = txtName.Text;
            selectedRow[0].Cells["dgv" + FCMDBFieldName.Client.Phone].Value = txtPhone.Text;
            selectedRow[0].Cells["dgv" + FCMDBFieldName.Client.Fax].Value = txtFax.Text;
            selectedRow[0].Cells["dgv" + FCMDBFieldName.Client.Address].Value = txtAddress.Text;
            selectedRow[0].Cells["dgv" + FCMDBFieldName.Client.MainContactPersonName].Value = txtContactPerson.Text;
            selectedRow[0].Cells["dgv" + FCMDBFieldName.Client.EmailAddress].Value = txtEmailAddress.Text;
            selectedRow[0].Cells["dgv" + FCMDBFieldName.Client.DisplayLogo].Value = checkDisplayLogo.Checked ? 'Y' : 'N';
            selectedRow[0].Cells["dgv" + FCMDBFieldName.Client.FKUserID].Value = comboUserID.Text;

        }

        /// <summary>
        /// Show Client Details
        /// </summary>
        public void ShowClientDetails()
        {
            if (dgvClientList.SelectedRows.Count <= 0)
                return;

            var selectedRow = dgvClientList.SelectedRows;

            txtUID.Text = selectedRow[0].Cells["dgv" + FCMDBFieldName.Client.UID].Value.ToString();
            txtABN.Text = selectedRow[0].Cells["dgv" + FCMDBFieldName.Client.ABN].Value.ToString();
            txtName.Text = selectedRow[0].Cells["dgv" + FCMDBFieldName.Client.Name].Value.ToString();
            txtPhone.Text = selectedRow[0].Cells["dgv" + FCMDBFieldName.Client.Phone].Value.ToString();
            txtFax.Text = selectedRow[0].Cells["dgv" + FCMDBFieldName.Client.Fax].Value.ToString();
            txtAddress.Text = selectedRow[0].Cells["dgv" + FCMDBFieldName.Client.Address].Value.ToString();
            txtContactPerson.Text = selectedRow[0].Cells["dgv" + FCMDBFieldName.Client.MainContactPersonName].Value.ToString();
            txtEmailAddress.Text = selectedRow[0].Cells["dgv" + FCMDBFieldName.Client.EmailAddress].Value.ToString();
            comboUserID.Text = selectedRow[0].Cells["dgv" + FCMDBFieldName.Client.FKUserID].Value.ToString();
            comboContractorSize.Text = selectedRow[0].Cells["dgv" + FCMDBFieldName.Client.DocSetUIDDisplay].Value.ToString();
            var dispLogo = selectedRow[0].Cells["dgv" + FCMDBFieldName.Client.DisplayLogo].Value.ToString();

            checkDisplayLogo.Checked = dispLogo == "Y" ? true : false;

            // Store original client data
            //
            original.Name = txtName.Text;
            original.ABN = txtABN.Text;
            original.Address = txtAddress.Text;
            original.EmailAddress = txtEmailAddress.Text;
            original.Fax = txtFax.Text;
            original.MainContactPersonName = txtContactPerson.Name;
            original.Phone = txtPhone.Text;
            original.FKUserID = comboUserID.Text;
            original.DocSetUIDDisplay = comboContractorSize.Text;
            original.DisplayLogo = Convert.ToChar(dispLogo);

            Utils.ClientID = Convert.ToInt32(txtUID.Text);
            original.UID = Utils.ClientID;

            // Get Company Logo
            //
            string logoLocation = RepClient.GetClientLogoLocation(Utils.ClientID, HeaderInfo.Instance);
            Bitmap MyImage;
            MyImage = new Bitmap(logoLocation);
            pbxLogo.Image = (Image)MyImage;


            // Store selected client data
            //
            client.UID = Utils.ClientID; 
            client.Name = txtName.Text;
            client.ABN = txtABN.Text;
            client.Address = txtAddress.Text;
            client.EmailAddress = txtEmailAddress.Text;
            client.Fax = txtFax.Text;
            client.MainContactPersonName = txtContactPerson.Name;
            client.Phone = txtPhone.Text;
            client.FKUserID = comboUserID.Text;
            client.DisplayLogo = Convert.ToChar(dispLogo);

            // List contracts

            ListClientContract();


        }

        // -----------------------------------------------------------------
        // Screen events
        // -----------------------------------------------------------------

        private void btnContractEdit_Click(object sender, EventArgs e)
        {
            UIClientContract uicc = new UIClientContract(this, client);
            uicc.Show();
        }

        /// <summary>
        /// Go to Employee List
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoToEmployeeList(object sender, EventArgs e)
        {
            UIClientEmployee uce = new UIClientEmployee(client);
            uce.Show();

        }


        // -----------------------------------------------------------------
        // Interface IClientContract Implementation
        // -----------------------------------------------------------------


        /// <summary>
        /// Reset screen from IClientContract
        /// </summary>
        public void ResetScreen()
        {
            // not implemented
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void pbxLogo_Click(object sender, EventArgs e)
        {

        }



        // -----------------------------------------------------------------
        // Handy methods
        // -----------------------------------------------------------------


    }
}
