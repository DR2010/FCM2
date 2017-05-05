using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using FCMMySQLBusinessLibrary;
using System.IO;
using FCMMySQLBusinessLibrary.FCMUtils;
using FCMMySQLBusinessLibrary.Model.ModelDocument;
using FCMMySQLBusinessLibrary.Model.ModelMetadata;
using FCMMySQLBusinessLibrary.Service.SVCClient.Contract;
using FCMMySQLBusinessLibrary.Service.SVCClient.Interface;
using FCMMySQLBusinessLibrary.Service.SVCClient.Service;
using FCMMySQLBusinessLibrary.Service.SVCClient.ServiceContract;
using MackkadoITFramework.ReferenceData;
using MackkadoITFramework.Security;
using MackkadoITFramework.Utils;
using HeaderInfo = MackkadoITFramework.Utils.HeaderInfo;
using Utils = FCMMySQLBusinessLibrary.FCMUtils.Utils;
using FCMMySQLBusinessLibrary.Model.ModelClient;

namespace fcm.Windows
{
    public partial class UIClientRegistration : Form, IBUSClientDetails
    {

        private Client _client;
        private Form _calledFrom;

        public UIClientRegistration(Form calledFrom, int icuid)
        {
            InitializeComponent();

            _calledFrom = calledFrom;

            var busClientRead = BUSClient.ClientRead(new ClientReadRequest() { clientUID = icuid,  headerInfo= HeaderInfo.Instance });
            _client = busClientRead.client;

            // Load User ID
            //
            var ua = UserAccess.List();
            foreach (var user in ua)
            {
                comboUserID.Items.Add(user.UserID);
            }

            // Load Contractor Size
            //
            var dsl = new DocumentSetList();
            dsl.List();
            foreach (var documentSet in dsl.documentSetList)
            {
                comboContractorSize.Items.Add(documentSet.UIDNameDisplay);
            }

            MapFieldsToScreen();

        }

        public UIClientRegistration(Form calledFrom)
        {
            InitializeComponent();

            _calledFrom = calledFrom;

            _client = new Client(HeaderInfo.Instance);

            // Load User ID
            //
            var ua = UserAccess.List();
            foreach (var user in ua)
            {
                comboUserID.Items.Add(user.UserID);
            }

            // Load Contractor Size
            //
            var dsl = new DocumentSetList();
            dsl.List();
            foreach (var documentSet in dsl.documentSetList)
            {
                comboContractorSize.Items.Add(documentSet.UIDNameDisplay);
            }

            ClearScreenFields();
        }

        private void miSave_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            SaveClient();

            MapFieldsToScreen();

        }

        private void MapFieldsToScreen()
        {
            txtUID.Text = _client.UID.ToString(CultureInfo.InvariantCulture);
            comboUserID.Text = _client.FKUserID;
            txtName.Text = _client.Name;
            txtLegalName.Text = _client.LegalName;
            comboContractorSize.Text = _client.DocSetUIDDisplay;
            // cbxAssociateInitialSet.Text = false;
            txtAddress.Text = _client.Address;
            txtPhone.Text = _client.Phone;
            txtFax.Text = _client.Fax;
            txtMobile.Text = _client.Mobile;
            txtEmailAddress.Text = _client.EmailAddress;
            txtContactPerson.Text = _client.MainContactPersonName;
            txtABN.Text = _client.ABN;
            txtRecordVersion.Text = _client.RecordVersion.ToString(CultureInfo.InvariantCulture);
            txtLogo1Location.Text = _client.Logo1Location;

            string logoLocation = Utils.GetPathName( txtLogo1Location.Text );

            var dispLogo = _client.DisplayLogo;
            checkDisplayLogo.Checked = dispLogo == 'Y' ? true : false;

            // Get Company Logo
            //
            // logoLocation = Client.GetClientLogoLocation(client.UID);

            Bitmap MyImage;

            // Check if location exists
            if (File.Exists(logoLocation))
            {
                MyImage = new Bitmap(logoLocation);
                pbxLogo.Image = (Image)MyImage;
            }
            else
            {
                LogFile.WriteToTodaysLogFile(
                    " FCMERR00000009 (01)" +
                    " Error. Client logo not found. " +
                    logoLocation +
                    " Client : " + _client.UID,
                    Utils.UserID);
            }

            if (_client.clientExtraInformation != null)
            {
                if (_client.clientExtraInformation.DateToEnterOnPolicies <= DateTime.MinValue ||
                    _client.clientExtraInformation.DateToEnterOnPolicies >= DateTime.MaxValue)
                {
                    _client.clientExtraInformation.DateToEnterOnPolicies = Utils.MinDate;
                    dtpDateToEnterOnPolicies.Value = _client.clientExtraInformation.DateToEnterOnPolicies;
                }
                else
                {
                    dtpDateToEnterOnPolicies.Value = _client.clientExtraInformation.DateToEnterOnPolicies;
                }
                
                if (_client.clientExtraInformation.ActionPlanDate <= DateTime.MinValue ||
                    _client.clientExtraInformation.ActionPlanDate >= DateTime.MaxValue)
                {
                    _client.clientExtraInformation.ActionPlanDate = Utils.MinDate;
                    dtpActionPlanDate.Value = _client.clientExtraInformation.ActionPlanDate;
                }
                else
                {
                    dtpActionPlanDate.Value = _client.clientExtraInformation.ActionPlanDate;
                }

                if (_client.clientExtraInformation.CertificationTargetDate <= DateTime.MinValue ||
                    _client.clientExtraInformation.CertificationTargetDate >= DateTime.MaxValue)
                {
                    _client.clientExtraInformation.CertificationTargetDate = Utils.MinDate;
                    dtpCertificationTargetDate.Value = _client.clientExtraInformation.CertificationTargetDate;
                }
                else
                {
                    dtpCertificationTargetDate.Value = _client.clientExtraInformation.CertificationTargetDate;
                }


                txtScopeOfServices.Text = _client.clientExtraInformation.ScopeOfServices;
                txtTimeTrading.Text = _client.clientExtraInformation.TimeTrading;
                txtRegionsOfOperation.Text = _client.clientExtraInformation.RegionsOfOperation;
                txtOperationalMeetings.Text = _client.clientExtraInformation.OperationalMeetingsFrequency;
                txtProjectMeetings.Text = _client.clientExtraInformation.ProjectMeetingsFrequency;
            }
        }


        /// <summary>
        /// Map fields from screen to object.
        /// </summary>
        private void MapScreenToObject()
        {
            _client.UID = Convert.ToInt32( txtUID.Text );
            _client.FKUserID = comboUserID.Text;
            _client.Name = txtName.Text;
            _client.LegalName = txtLegalName.Text;
            _client.DocSetUIDDisplay = comboContractorSize.Text;

            _client.Address = txtAddress.Text;
            _client.Phone = txtPhone.Text;
            _client.Fax = txtFax.Text;
            _client.Mobile = txtMobile.Text;
            _client.EmailAddress = txtEmailAddress.Text;
            _client.MainContactPersonName = txtContactPerson.Text;
            _client.ABN = txtABN.Text;
            _client.RecordVersion = Convert.ToInt32( txtRecordVersion.Text );

            if (_client.clientExtraInformation != null)
            {
                _client.clientExtraInformation.DateToEnterOnPolicies = dtpDateToEnterOnPolicies.Value;
                _client.clientExtraInformation.ActionPlanDate = dtpActionPlanDate.Value;
                _client.clientExtraInformation.CertificationTargetDate = dtpCertificationTargetDate.Value;

                _client.clientExtraInformation.ScopeOfServices = txtScopeOfServices.Text;
                _client.clientExtraInformation.TimeTrading = txtTimeTrading.Text;
                _client.clientExtraInformation.RegionsOfOperation = txtRegionsOfOperation.Text;
                _client.clientExtraInformation.OperationalMeetingsFrequency = txtOperationalMeetings.Text;
                _client.clientExtraInformation.ProjectMeetingsFrequency = txtProjectMeetings.Text;

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            SaveClient();

            Cursor.Current = Cursors.Arrow;
        }

        /// <summary>
        /// Add/ Update client
        /// </summary>
        /// <param name="client"></param>
        public void SaveClient()
        {

            if (cbxAssociateInitialSet.Checked)
            {
                if (comboContractorSize.SelectedIndex < 0)
                {
                    MessageBox.Show("Please select contractor size.");
                    return;
                }
            }


            // Check if the client is new.
            // If the UID is empty, it is a new client.
            // If the UID is populated, it is an existing client.
            //
            if (string.IsNullOrEmpty(txtUID.Text))
                _client.UID = 0;
            else
                _client.UID = Convert.ToInt32(txtUID.Text);

            _client.ABN = txtABN.Text;
            _client.Name = txtName.Text;
            _client.LegalName = txtLegalName.Text;
            _client.Address = txtAddress.Text;
            _client.Phone = txtPhone.Text;
            _client.Fax = txtFax.Text;
            _client.Mobile = txtMobile.Text;
            _client.Logo1Location = txtLogo1Location.Text;
            _client.Logo2Location = "";
            _client.Logo3Location = "";
            _client.EmailAddress = txtEmailAddress.Text;
            _client.MainContactPersonName = txtContactPerson.Text;
            _client.FKUserID = comboUserID.Text;
            _client.DocSetUIDDisplay = comboContractorSize.Text;
            _client.DisplayLogo = checkDisplayLogo.Checked ? 'Y' : 'N';

            if (string.IsNullOrEmpty(_client.DocSetUIDDisplay))
            {
                _client.FKDocumentSetUID = 0;
            }
            else
            {
                string[] part = _client.DocSetUIDDisplay.Split(';');
                _client.FKDocumentSetUID = Convert.ToInt32(part[0]);
            }

            _client.DisplayLogo = checkDisplayLogo.Checked ? 'Y' : 'N';

            _client.clientExtraInformation = new ClientExtraInformation();
            _client.clientExtraInformation.FKClientUID = _client.UID; 
            _client.clientExtraInformation.DateToEnterOnPolicies = dtpDateToEnterOnPolicies.Value;
            _client.clientExtraInformation.ActionPlanDate = dtpActionPlanDate.Value;
            _client.clientExtraInformation.CertificationTargetDate = dtpCertificationTargetDate.Value;

            _client.clientExtraInformation.ScopeOfServices = txtScopeOfServices.Text;
            _client.clientExtraInformation.TimeTrading = txtTimeTrading.Text;
            _client.clientExtraInformation.RegionsOfOperation = txtRegionsOfOperation.Text;
            _client.clientExtraInformation.OperationalMeetingsFrequency = txtOperationalMeetings.Text;
            _client.clientExtraInformation.ProjectMeetingsFrequency = txtProjectMeetings.Text;

            // Check if it is to add / update
            if (_client.UID <= 0)
            {
                string associateInitialSet = "N";
                if (cbxAssociateInitialSet.Checked)
                    associateInitialSet = "Y";


                var clientAddRequest = new ClientAddRequest();
                clientAddRequest.headerInfo = HeaderInfo.Instance;
                clientAddRequest.eventClient = _client;
                clientAddRequest.linkInitialSet = associateInitialSet;

                // var response = new BUSClient().ClientAdd(clientAddRequest);
                var response = ClientAdd(clientAddRequest);

                ControllerUtils.ShowFCMMessage(response.responseStatus, Utils.UserID);

                _client.UID = 0;

                if (response.responseStatus.Successful)
                {
                    _client.UID = response.clientUID;
                    txtUID.Text = _client.UID.ToString();
                    txtRecordVersion.Text = _client.RecordVersion.ToString();
                }
            }
            else
            {

                var requestClientUpdate = new ClientUpdateRequest();
                requestClientUpdate.headerInfo = HeaderInfo.Instance;
                requestClientUpdate.eventClient = _client;

                // var response = new BUSClient().ClientUpdate(requestClientUpdate);
                var response = ClientUpdate(requestClientUpdate);

                txtRecordVersion.Text = _client.RecordVersion.ToString(CultureInfo.InvariantCulture);

                ControllerUtils.ShowFCMMessage( response.response, Utils.UserID );
            }

            // Refresh client list
            // 
            Utils.ClientID = _client.UID;

            var responseClientList = new BUSClient().ClientList(HeaderInfo.Instance);

            Utils.ClientList = responseClientList.clientList;

        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            _calledFrom.Refresh();
            _calledFrom.Activate();
            this.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showDocumentsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void miDocuments_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUID.Text))
                return;

            Utils.ClientID = Convert.ToInt32(txtUID.Text);

            UIClientDocumentSet uicds = new UIClientDocumentSet();
            uicds.Show();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            ClearScreenFields();
        }


        private void ClearScreenFields()
        {
            txtUID.Text = "";
            comboUserID.Text = "";
            txtName.Text = "";
            txtLegalName.Text = "";
            comboContractorSize.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            txtFax.Text = "";
            txtMobile.Text = "";
            txtEmailAddress.Text = "";
            txtContactPerson.Text = "";
            txtABN.Text = "";
            txtRecordVersion.Text = "";

            //dtpDateToEnterOnPolicies.Value = Utils.MinDate;
            //dtpActionPlanDate.Value = Utils.MinDate;
            //dtpCertificationTargetDate.Value = Utils.MinDate;

            dtpDateToEnterOnPolicies.Value = System.DateTime.Today;
            dtpActionPlanDate.Value = System.DateTime.Today;
            dtpCertificationTargetDate.Value = System.DateTime.Today;

            txtScopeOfServices.Text = "";
            txtTimeTrading.Text = "";
            txtRegionsOfOperation.Text = "";
            txtOperationalMeetings.Text = "";
            
        }

        private void pbxLogo_Click(object sender, EventArgs e)
        {

        }

        private void pbxLogo_DoubleClick(object sender, EventArgs e)
        {
            // Show file dialog
            var logoFolder =
                    CodeValue.GetCodeValueExtended(FCMConstant.CodeTypeString.SYSTSET, FCMConstant.SYSFOLDER.LOGOFOLDER);

            openFileDialog1.InitialDirectory = logoFolder;

            var file = openFileDialog1.ShowDialog();

            if (file == DialogResult.OK)
            {
                // Only File Name
                string fileName = openFileDialog1.SafeFileName;
                // Full Path including file name
                string fullPathFileName = openFileDialog1.FileName;

                // Extract File Path
                string pathOnly = fullPathFileName.Replace(fileName, "");

                if (pathOnly.ToUpper() != logoFolder.ToUpper())
                {
                    MessageBox.Show("Logo must be selected from folder " + logoFolder);
                    return;
                }


                txtLogo1Location.Text = FCMConstant.SYSFOLDER.LOGOFOLDER + fileName;

                Bitmap MyImage;
                pbxLogo.SizeMode = PictureBoxSizeMode.StretchImage;
                if (logoFolder != null)
                {
                    // MyImage = new Bitmap(rmd.Condition);
                    string logoLocation = logoFolder + fileName;
                    try
                    {
                        MyImage = new Bitmap(logoLocation);
                        pbxLogo.Image = (Image)MyImage;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error importing file. Please try another file type. File Location: " + logoLocation + " >> System Message " + ex.ToString());
                    }
                }
            }
        }

        private void OLDLogoDoubleClick(object sender, EventArgs e)
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

                txtLogo1Location.Text = rmd.Condition;

                rmd.Save();

                Bitmap MyImage;
                pbxLogo.SizeMode = PictureBoxSizeMode.StretchImage;
                if (rmd.Condition != null)
                {
                    // MyImage = new Bitmap(rmd.Condition);
                    string logoLocation = logoFolder + fileName;
                    MyImage = new Bitmap(logoLocation);
                    pbxLogo.Image = (Image)MyImage;
                }
            }
        }

        private void tsmMetadata_Click(object sender, EventArgs e)
        {
            UIClientMetadata ucm = new UIClientMetadata(this);
            ucm.Show();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var answer = MessageBox.Show("Are you sure? Do you really want to delete the client?",
                             "Delete Client",
                             MessageBoxButtons.YesNo);

            if (answer == DialogResult.Yes)
            {

                Client client = new Client(HeaderInfo.Instance);
                client.UID = Convert.ToInt32( txtUID.Text );

                var response = new BUSClient().ClientDelete(
                    new ClientDeleteRequest() { clientUID = client.UID, headerInfo = HeaderInfo.Instance });

                ControllerUtils.ShowFCMMessage(response.responseStatus, Utils.UserID);
            }
        }

        private void tsRefresh_Click(object sender, EventArgs e)
        {

            ClientReadRequest crr = new ClientReadRequest();
            crr.clientUID = _client.UID;

            var crresponse = BUSClient.ClientRead( crr );

            _client = crresponse.client;

            //var bclient = _client.Read();
            //if (_client == null)
            //    _client = new Client(HeaderInfo.Instance);
            
            MapFieldsToScreen();

            MessageBox.Show("Client details reloaded from database.");

        }

        private void UIClientRegistration_Load(object sender, EventArgs e)
        {

        }

        private void tsEmployees_Click(object sender, EventArgs e)
        {
            UIClientEmployee uce = new UIClientEmployee(_client);
            uce.Show();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }


        public ClientAddResponse ClientAdd(ClientAddRequest clientAddRequest)
        {
            var response = new BUSClient().ClientAdd(clientAddRequest);

            return response;
        }

        public ClientUpdateResponse ClientUpdate(ClientUpdateRequest clientUpdateRequest)
        {
            var response = new BUSClient().ClientUpdate(clientUpdateRequest);

            return response;
        }
    }
}

