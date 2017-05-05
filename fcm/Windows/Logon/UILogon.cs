using System;
using System.Windows.Forms;
using FCMMySQLBusinessLibrary.Service.SVCClient.Service;
using FCMMySQLBusinessLibrary.FCMUtils;
using MackkadoITFramework.Security;
using MackkadoITFramework.Utils;
using fcm.Windows.Cache;
using ConnString = MackkadoITFramework.Utils.ConnString;
using HeaderInfo = MackkadoITFramework.Utils.HeaderInfo;
using Utils = FCMMySQLBusinessLibrary.FCMUtils.Utils;


namespace fcm.Windows
{
    public partial class UILogon : Form
    {
        public string connectedTo;

        public UILogon()
        {
            InitializeComponent();
        }

        private void Logon_Leave(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Logon_Load(object sender, EventArgs e)
        {
            // Retrieve inital config information
            //
 
            // 1) Connection String
            //
            // ConnString.ConnectionString = FCMXmlConfig.Read(FCMConstant.fcmConfigXml.ConnectionString);
            txtConnection.Text = ConnString.ConnectionStringLocal;
            txtServerConnection.Text = ConnString.ConnectionStringServer;

            int st = 0;
            st = ConnString.ConnectionStringLocal.IndexOf("Data Source");
            if (st >= 0)
            {
                int en = ConnString.ConnectionStringLocal.IndexOf(";");
                txtConnection.Text = ConnString.ConnectionStringLocal.Substring(st, en - st);

                int st1 = ConnString.ConnectionStringServer.IndexOf("Data Source");
                int en1 = ConnString.ConnectionStringServer.IndexOf(";");
                txtServerConnection.Text = ConnString.ConnectionStringServer.Substring(st1, en1 - st1);

            }
            else
            {
                st = ConnString.ConnectionStringLocal.IndexOf("Server");
                if (st >= 0)
                {
                    int en = ConnString.ConnectionStringLocal.IndexOf(";");
                    txtConnection.Text = ConnString.ConnectionStringLocal.Substring(st, en - st);

                    int st1 = ConnString.ConnectionStringServer.IndexOf("Server");
                    int en1 = ConnString.ConnectionStringServer.IndexOf(";");
                    txtServerConnection.Text = ConnString.ConnectionStringServer.Substring(st1, en1 - st1);

                }
            }
            // ConnString.ConnectionString = ConnString.ConnectionStringLocal; 
            // Get last user id

            //ProcessRequestCodeValues cv = new ProcessRequestCodeValues();
            //cv.FKCodeType = "LASTINFO";
            //cv.ID = "USERID";
            //cv.Read(false);

            //txtUserID.Text = cv.ValueExtended;

            // Enable/ Disable dbs using xml
            //
            string enableLocalDB = FCMXmlConfig.Read(FCMConstant.fcmConfigXml.EnableLocalDB);
            string enableServerDB = FCMXmlConfig.Read(FCMConstant.fcmConfigXml.EnableServerDB);
            string defaultDB = FCMXmlConfig.Read(FCMConstant.fcmConfigXml.DefaultDB);

            rbLocal.Enabled = false;
            rbServer.Enabled = false;

            if (enableLocalDB == "Y") rbLocal.Enabled = true;
            if (enableServerDB == "Y") rbServer.Enabled = true;

            if (defaultDB == "Server")
            {
                if (enableServerDB == "Y")
                    rbServer.Checked = true;
            }
            else
                if (enableLocalDB == "Y")
                    rbLocal.Checked = true;

            // txtUserID.Focus();

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Logon_FormClosed(object sender, FormClosedEventArgs e)
        {
           Application.Exit();

        }

        private void btnLogon_Click(object sender, EventArgs e)
        {
            connectedTo = "not connected";

            if (rbLocal.Checked || rbServer.Checked)
            {//ok
            }
            else
            {
                MessageBox.Show("Please select database.");
                return;
            }


            if (rbLocal.Checked)
            {
                ConnString.ConnectionString = ConnString.ConnectionStringLocal;
                connectedTo = "Local";
            }
            if (rbServer.Checked)
            {
                ConnString.ConnectionString = ConnString.ConnectionStringServer;
                connectedTo = "Server";
            }

            // Set framework db as the same at this stage
            ConnString.ConnectionStringFramework = ConnString.ConnectionString;

            if (string.IsNullOrEmpty(ConnString.ConnectionString))
                return;

            try
            {
                Utils.UserID = txtUserID.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading database. Contact system administrator. " + ex.ToString());
                Application.Exit();
            }
            // Check if user is valid
            var uacnew = new UserAccess();

            var readuser = uacnew.Read(txtUserID.Text);
            if (readuser.ReturnCode == 0001 && readuser.ReasonCode == 0001)
            {
                // cool
            }
            if (readuser.ReturnCode == 0001 && readuser.ReasonCode == 0002)
            {
                MessageBox.Show("User not found.");
                return;
            }

            if (readuser.ReturnCode <= 000)
            {
                MessageBox.Show(readuser.Message);
                return;
            }

            if (string.IsNullOrWhiteSpace( uacnew.Password ))
            {
                MessageBox.Show( "User not found. Contact System Support." );
                return;
            }

            var response = uacnew.AuthenticateUser(txtUserID.Text, txtPassword.Text);

            if (response.ReturnCode == 0001 && response.ReasonCode == 0001)
            { 
                // Cool
            }
            else
            {
                // Invalid Password
                //

                ControllerUtils.ShowFCMMessage(response.UniqueCode, txtUserID.Text, response.Message, "UILogon.cs");
                
                return;
            }


            var responseClientList = new BUSClient().ClientList(HeaderInfo.Instance);

            Utils.ClientList = responseClientList.clientList;

            string ret = LogFile.WriteToTodaysLogFile("User has logged on", Utils.UserID);

            if (ret != "" && ret.Length > 3 && ret.Substring(0, 5) == "Error")
            {
                MessageBox.Show(ret);
                Application.Exit();
            }

            // Retrieve User Settings - Load in memory
            //

            Utils.LoadUserSettingsInCache();
            LogFile.WriteToTodaysLogFile("User Settings loaded in cache", Utils.UserID);

            // Load reference data in cache
            //
            CachedInfo.LoadReferenceDataInCache(HeaderInfo.Instance);
            LogFile.WriteToTodaysLogFile("Reference Data loaded in cache", Utils.UserID);

            CachedInfo.LoadRelatedCodeInCache();
            LogFile.WriteToTodaysLogFile("Related code loaded in cache", Utils.UserID);

            // Set Header Info
            //
            HeaderInfo.Instance.CurrentDateTime = System.DateTime.Today;
            HeaderInfo.Instance.UserID = txtUserID.Text;

            this.Hide();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUserID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
