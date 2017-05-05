using System;
using System.Windows.Forms;
using FCMMySQLBusinessLibrary.Service.SVCClient.Contract;
using FCMMySQLBusinessLibrary.Service.SVCClient.Interface;
using FCMMySQLBusinessLibrary.Service.SVCClient.Service;
using FCMMySQLBusinessLibrary.Service.SVCClient.ServiceContract;
using MackkadoITFramework.ErrorHandling;
using MackkadoITFramework.Utils;
using HeaderInfo = MackkadoITFramework.Utils.HeaderInfo;
using Utils = FCMMySQLBusinessLibrary.FCMUtils.Utils;
using FCMMySQLBusinessLibrary.Repository;

// using fcm.ProxyAsync;

namespace fcm.Windows
{
    public partial class UIClientList : Form, IBUSClientList
    {
        private Form _sourceWindow;
        
        // ClientAsync m_Proxy = new ClientAsync();

        int clientUID;
        private Form _comingFromForm;

        public UIClientList(Form comingFromForm)
        {
            InitializeComponent();
            _comingFromForm = comingFromForm;

            clientUID = Utils.ClientID;
        }

        private void UIClientList_Load(object sender, EventArgs e)
        {
            ClientList(HeaderInfo.Instance);
        }

        /// <summary>
        /// List companies Async
        /// </summary>
        private void loadClientListAsync()
        {

            // m_Proxy.BeginClientList(HeaderInfo.Instance, OnClientListCompletion, null);

        }


        //void OnClientListCompletion(IAsyncResult result)
        //{
        //    var responseClientList = m_Proxy.EndClientList(result);
        //    result.AsyncWaitHandle.Close();

        //    var clientList = responseClientList.clientList;

        //    try
        //    {
        //        clientBindingSource.DataSource = clientList;
        //    }
        //    catch (Exception ex)
        //    {
        //        LogFile.WriteToTodaysLogFile(
        //            "Error binding response. " + ex.ToString(),
        //            Utils.UserID,
        //            ResponseStatus.MessageCode.Error.FCMERR00009999,
        //            "UIClientList.cs");
        //    }

        //    m_Proxy.Close();

        //}


        private void btnOk_Click(object sender, EventArgs e)
        {

            clientUID = GetClientUIDSelected();

            if (clientUID <= 0)
                return;

            Utils.ClientID = clientUID;

            this.Close();
            if (_sourceWindow != null)
                _sourceWindow.Activate();

        }

        private void dgvClientList_CellMouseDown( object sender, DataGridViewCellMouseEventArgs e )
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                dgvClientList.CurrentCell = dgvClientList.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void miClientDetails_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            GetClientUIDSelected();

            UIClientRegistration uicr = new UIClientRegistration(this, clientUID);
            uicr.Show();

            Cursor.Current = Cursors.Arrow;
        }

        private void miContract_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            clientUID = GetClientUIDSelected();

            if (clientUID <= 0) 
                return;

            //Client client = new Client(HeaderInfo.Instance);
            //client.UID = Utils.ClientID;

            ClientReadRequest crr = new ClientReadRequest();
            crr.clientUID = Utils.ClientID;
            crr.headerInfo = HeaderInfo.Instance;

            var crresponse = BUSClient.ClientRead( crr );
            
            if (crresponse.client.UID <= 0)
                return;

            UIClientContract uicc = new UIClientContract(this, crresponse.client);
            uicc.Show();

            Cursor.Current = Cursors.Arrow;

        }

        /// <summary>
        /// Get Client Selected
        /// </summary>
        /// <returns></returns>
        private int GetClientUIDSelected()
        {

            if (dgvClientList.SelectedRows.Count <= 0)
                return 0;

            var selectedRow = dgvClientList.SelectedRows;

            //String textClientUID = selectedRow[0].Cells["dgv" + DBFieldName.Client.UID].Value.ToString();
            String textClientUID = selectedRow[0].Cells["dgv" + FCMDBFieldName.Client.UID].Value.ToString();

            clientUID = Convert.ToInt32(textClientUID);

            Utils.ClientID = clientUID;

            return clientUID;

        }

        private void miDocuments_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;

            GetClientUIDSelected();

            UIClientDocumentSet uicds = new UIClientDocumentSet();
            uicds.Show();

            Cursor.Current = Cursors.Arrow;

        }

        private void toolStripExit_Click(object sender, EventArgs e)
        {
            _comingFromForm.Activate();
            _comingFromForm.Refresh();

            this.Dispose(); 
        }

        private void miNewClient_Click(object sender, EventArgs e)
        {
            UIClientRegistration uicr = new UIClientRegistration(this);
            uicr.Show();
        }

        private void tsRefresh_Click(object sender, EventArgs e)
        {
            ClientList(HeaderInfo.Instance);
        }

        public override void Refresh()
        {
            ClientList(HeaderInfo.Instance);
        }

        private void miMetadata_Click(object sender, EventArgs e)
        {
            UIClientMetadata ucm = new UIClientMetadata(this);
            ucm.Show();
        }

        private void dgvClientList_SelectionChanged(object sender, EventArgs e)
        {
            GetClientUIDSelected();
        }

        /// Implementing Interface

        /// <summary>
        /// List Companies Sync
        /// </summary>
        public ClientListResponse ClientList(HeaderInfo headerInfo)
        {

            //loadClientListAsync();
            //return;


            var responseClientList = new BUSClient().ClientList(HeaderInfo.Instance);

            if (responseClientList.response.ReturnCode < 0000)
            {
                LogFile.WriteToTodaysLogFile("Error loading client list", HeaderInfo.Instance.UserID, "", "UIClientList.cs");
                return responseClientList;
            }

            var clientList = responseClientList.clientList;

            try
            {
                clientBindingSource.DataSource = clientList;
            }
            catch (Exception ex)
            {
                LogFile.WriteToTodaysLogFile(
                    "Error binding response. " + ex.ToString(),
                    Utils.UserID,
                    ResponseStatus.MessageCode.Error.FCMERR00009999,
                    "UIClientList.cs");
            }
            return responseClientList;

        }


    }
}
