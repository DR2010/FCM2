using System;
using System.Drawing;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using fcm.Windows.Others;
using FCMMySQLBusinessLibrary.Service.SVCClient.Service;
using FCMMySQLBusinessLibrary.Service.SVCClient;
using FCMMySQLBusinessLibrary.Model.ModelClient;
using FCMMySQLBusinessLibrary.FCMUtils;
using MackkadoITFramework.ReferenceData;
using MackkadoITFramework.Utils;
using fcm.Windows.Cache;
using ConnString = MackkadoITFramework.Utils.ConnString;
using HeaderInfo = MackkadoITFramework.Utils.HeaderInfo;
using Utils = FCMMySQLBusinessLibrary.FCMUtils.Utils;
using FCMMySQLBusinessLibrary.Model.ModelClient;


namespace fcm.Windows
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class UIfcm : Form
    {
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MainMenu mainMenu;
        private IContainer components;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private MenuItem menuItem2;
        private MenuItem menuItem7;

        private string _userID;
        private MenuItem miReferenceData;
        private MenuItem miReportMetadata;
        private MenuItem miProposal;
        private MenuItem miDocumentSetList;
        private PictureBox pictureBox1;
        private MenuItem miDocumentList;
        private MenuItem menuItem8;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripExit;
        private ToolStripButton toolStripClient;
        private MenuItem menuItem3;
        private MenuItem miDocumentLink;
        private MenuItem menuItem11;
        private MenuItem miDocumentSetLink;
        private MenuItem miUsers;
        private MenuItem miUserSettings;
        private MenuItem miProcessRequest;
        private MenuItem miListNew;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private MenuItem miRelatedReferenceCode;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel tslLoadedFrom;
        private MenuItem menuItem1;
        private MenuItem menuItem4;
        private MenuItem miImpacted;

        public UIfcm()
        {
            InitializeComponent();

            HeaderInfo headerInfo;
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if (components != null) 
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UIfcm));
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.miListNew = new System.Windows.Forms.MenuItem();
            this.miProposal = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.miDocumentList = new System.Windows.Forms.MenuItem();
            this.miDocumentLink = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.miDocumentSetList = new System.Windows.Forms.MenuItem();
            this.miDocumentSetLink = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.miReferenceData = new System.Windows.Forms.MenuItem();
            this.miReportMetadata = new System.Windows.Forms.MenuItem();
            this.miUsers = new System.Windows.Forms.MenuItem();
            this.miUserSettings = new System.Windows.Forms.MenuItem();
            this.miRelatedReferenceCode = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.miImpacted = new System.Windows.Forms.MenuItem();
            this.miProcessRequest = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripClient = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslLoadedFrom = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem5,
            this.menuItem2,
            this.menuItem3,
            this.menuItem11,
            this.menuItem7,
            this.menuItem8});
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 0;
            this.menuItem5.Text = "E&xit";
            this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miListNew,
            this.miProposal});
            this.menuItem2.Text = "Client";
            // 
            // miListNew
            // 
            this.miListNew.Index = 0;
            this.miListNew.Tag = "CLNTLIST";
            this.miListNew.Text = "List";
            this.miListNew.Click += new System.EventHandler(this.miListNew_Click);
            // 
            // miProposal
            // 
            this.miProposal.Index = 1;
            this.miProposal.Text = "Proposal";
            this.miProposal.Click += new System.EventHandler(this.menuItem6_Click_1);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 2;
            this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miDocumentList,
            this.miDocumentLink});
            this.menuItem3.Text = "Document";
            // 
            // miDocumentList
            // 
            this.miDocumentList.Index = 0;
            this.miDocumentList.Tag = "DOCLIST";
            this.miDocumentList.Text = "List";
            this.miDocumentList.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // miDocumentLink
            // 
            this.miDocumentLink.Index = 1;
            this.miDocumentLink.Tag = "DOCLINK";
            this.miDocumentLink.Text = "Link";
            this.miDocumentLink.Click += new System.EventHandler(this.menuItem12_Click);
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 3;
            this.menuItem11.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miDocumentSetList,
            this.miDocumentSetLink});
            this.menuItem11.Text = "Document Set";
            // 
            // miDocumentSetList
            // 
            this.miDocumentSetList.Index = 0;
            this.miDocumentSetList.Tag = "DOCSETLIST";
            this.miDocumentSetList.Text = "List";
            this.miDocumentSetList.Click += new System.EventHandler(this.menuItem9_Click);
            // 
            // miDocumentSetLink
            // 
            this.miDocumentSetLink.Index = 1;
            this.miDocumentSetLink.Tag = "DOCSETLINK";
            this.miDocumentSetLink.Text = "Link";
            this.miDocumentSetLink.Click += new System.EventHandler(this.menuItem13_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 4;
            this.menuItem7.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miReferenceData,
            this.miReportMetadata,
            this.miUsers,
            this.miUserSettings,
            this.miRelatedReferenceCode});
            this.menuItem7.Text = "Maintenance";
            // 
            // miReferenceData
            // 
            this.miReferenceData.Index = 0;
            this.miReferenceData.Tag = "REFERENCEDATA";
            this.miReferenceData.Text = "Reference Data";
            this.miReferenceData.Click += new System.EventHandler(this.miReferenceData_Click);
            // 
            // miReportMetadata
            // 
            this.miReportMetadata.Index = 1;
            this.miReportMetadata.Tag = "REPORTMETADATA";
            this.miReportMetadata.Text = "Report Metadata";
            this.miReportMetadata.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // miUsers
            // 
            this.miUsers.Index = 2;
            this.miUsers.Tag = "USERACCESS";
            this.miUsers.Text = "Users Authorisation";
            this.miUsers.Click += new System.EventHandler(this.miUsers_Click);
            // 
            // miUserSettings
            // 
            this.miUserSettings.Index = 3;
            this.miUserSettings.Tag = "USERSETTINGS";
            this.miUserSettings.Text = "User Settings";
            this.miUserSettings.Click += new System.EventHandler(this.menuItem14_Click);
            // 
            // miRelatedReferenceCode
            // 
            this.miRelatedReferenceCode.Index = 4;
            this.miRelatedReferenceCode.Text = "Related Reference Code";
            this.miRelatedReferenceCode.Click += new System.EventHandler(this.miRelatedReferenceCode_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 5;
            this.menuItem8.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miImpacted,
            this.miProcessRequest,
            this.menuItem1,
            this.menuItem4});
            this.menuItem8.Text = "Miscelaneous";
            // 
            // miImpacted
            // 
            this.miImpacted.Index = 0;
            this.miImpacted.Tag = "DOCIMP";
            this.miImpacted.Text = "Impacted Documents";
            this.miImpacted.Click += new System.EventHandler(this.miImpactedDocuments);
            // 
            // miProcessRequest
            // 
            this.miProcessRequest.Index = 1;
            this.miProcessRequest.Tag = "PROCESSREQUEST";
            this.miProcessRequest.Text = "Process Request";
            this.miProcessRequest.Click += new System.EventHandler(this.miProcessRequest_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 2;
            this.menuItem1.Text = "Send Email";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click_1);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.Title = "SAMS Parser.Net";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = global::fcm.Properties.Resources.FCMLogo;
            this.pictureBox1.Location = new System.Drawing.Point(12, 929);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(236, 74);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripExit,
            this.toolStripClient});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(587, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripExit
            // 
            this.toolStripExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripExit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripExit.Image")));
            this.toolStripExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripExit.Name = "toolStripExit";
            this.toolStripExit.Size = new System.Drawing.Size(23, 22);
            this.toolStripExit.Text = "Exit";
            this.toolStripExit.Click += new System.EventHandler(this.menuItem5_Click);
            // 
            // toolStripClient
            // 
            this.toolStripClient.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripClient.Image = ((System.Drawing.Image)(resources.GetObject("toolStripClient.Image")));
            this.toolStripClient.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripClient.Name = "toolStripClient";
            this.toolStripClient.Size = new System.Drawing.Size(23, 22);
            this.toolStripClient.Text = "Client Details";
            this.toolStripClient.Click += new System.EventHandler(this.miListNew_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.tslLoadedFrom});
            this.statusStrip1.Location = new System.Drawing.Point(0, 294);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(587, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(55, 17);
            this.toolStripStatusLabel1.Text = "Database";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(46, 17);
            this.toolStripStatusLabel2.Text = "Version";
            this.toolStripStatusLabel2.Click += new System.EventHandler(this.toolStripStatusLabel2_Click);
            // 
            // tslLoadedFrom
            // 
            this.tslLoadedFrom.Name = "tslLoadedFrom";
            this.tslLoadedFrom.Size = new System.Drawing.Size(77, 17);
            this.tslLoadedFrom.Text = "Loaded From";
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 3;
            this.menuItem4.Text = "Load Cache";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click_1);
            // 
            // UIfcm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(587, 316);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu;
            this.Name = "UIfcm";
            this.ShowIcon = false;
            this.Tag = "C:\\\\ProgramFiles\\\\FCM";
            this.Text = " ";
            this.Load += new System.EventHandler(this.frmParserMainUI_Load);
            this.Leave += new System.EventHandler(this.frmParserMainUI_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() 
        {
            Application.Run(new UIfcm());
        }

        private void menuItem5_Click(object sender, System.EventArgs e)
        {
            // Terminate the program
            LogFile.WriteToTodaysLogFile("User has logged off", Utils.UserID);

            this.Dispose();	
        }

        private void miClient_Click(object sender, EventArgs e)
        {
            UIClientDetails ClientDetails = new UIClientDetails(this);
            ClientDetails.Show();
        }

        /// <summary>
        /// Load method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmParserMainUI_Load(object sender, EventArgs e)
        {

            // Set current environment
            Utils.FCMenvironment = MackkadoITFramework.Helper.Utils.EnvironmentList.LOCAL;

            UILogon log = new UILogon();
            log.ShowDialog();

            if (log.connectedTo == "not connected" || string.IsNullOrEmpty(log.connectedTo))
                Application.Exit();

            if (log.connectedTo == "Local")
                toolStripStatusLabel1.BackColor = Color.Green;

            if (log.connectedTo == "Server")
                toolStripStatusLabel1.BackColor = Color.Red;


            // Utils.ClientList = Client.List();

            int st = ConnString.ConnectionString.IndexOf("Data Source");

            int en = ConnString.ConnectionString.IndexOf(";");

            if (st > 0 && en > 0)
            {
                string s = ConnString.ConnectionString.Substring(st, en - st);
                toolStripStatusLabel1.Text = string.Format("({0}) {1}", log.connectedTo, s);
            }
            else
            {
                toolStripStatusLabel1.Text = string.Format("({0}) {1}", log.connectedTo, ConnString.ConnectionString.Substring(0,10));
            }

            toolStripStatusLabel2.Text = @"Version: " + ControllerUtils.GetCurrentAssemblyVersion();

            tslLoadedFrom.Text = this.Tag.ToString();


            var responseCL = new BUSClient().ClientList(HeaderInfo.Instance);

            var responseClientList = responseCL.clientList;

            // Retrieve last client id
            //
            var lastClient = new CodeValue();
            lastClient.FKCodeType = "LASTINFO";
            lastClient.ID = "CLIENTID";
            lastClient.Read(false);
            try
            {
                Utils.ClientID = Convert.ToInt32(lastClient.ValueExtended);
            }
            catch
            {
                Utils.ClientID = Utils.ClientList[0].UID;
            }

            // Load HeaderInfo
            HeaderInfo.Instance.UserID = Utils.UserID;
            HeaderInfo.Instance.CurrentDateTime = DateTime.Now;

            // Remove menu items

            // Get full list of screens
            var fullListOfScreens = CachedInfo.GetListOfCodeValue(FCMConstant.CodeTypeString.SCREENCODE);

            // var listOfScreen = BUSReferenceData.GetListScreensForUser(Utils.UserID);

            foreach (var screen in fullListOfScreens)
            {
                bool found = CachedInfo.ListOfScreensAllowedToUser.Any(allowedScreen => allowedScreen.ID == screen.ID);

                //foreach (var allowedScreen in CachedInfo.ListOfScreensAllowedToUser)
                //{
                //    if (allowedScreen.ID == screen.ID)
                //    {
                //        found = true;
                //        break;
                //    }
                //}

                if (found) continue;

                // find screen disallowed and hide
                switch (screen.ID)
                {
                    case FCMConstant.ScreenCode.DocumentSetLink:
                        miDocumentSetLink.Enabled = false;
                        break;
                    case FCMConstant.ScreenCode.DocumentSetList:
                        miDocumentSetList.Enabled = false;
                        break;
                    case FCMConstant.ScreenCode.DocumentList:
                        miDocumentList.Enabled = false;
                        break;
                    case FCMConstant.ScreenCode.DocumentLink:
                        miDocumentLink.Enabled = false;
                        break;
                    case FCMConstant.ScreenCode.ClientList:
                        toolStripClient.Enabled = false;
                        miListNew.Enabled = false;
                        break;
                    case FCMConstant.ScreenCode.ReportMetadata:
                        miReportMetadata.Enabled = false;
                        break;
                    case FCMConstant.ScreenCode.ReferenceData:
                        miReferenceData.Enabled = false;
                        break;
                    //case FCMConstant.ScreenCode.UserAccess:
                    //    miUsers.Enabled = false;
                    //    break;
                    case FCMConstant.ScreenCode.UserSettings:
                        miUserSettings.Enabled = false;
                        break;
                    case FCMConstant.ScreenCode.ImpactedDocuments:
                        miImpacted.Enabled = false;
                        break;
                    case FCMConstant.ScreenCode.ProcessRequest:
                        miProcessRequest.Enabled = false;
                        break;
                }
            }

            this.Activate();

            // Utils.ClientIndex = 0;


        }

        private void miMaintainProjectDocuments_Click(object sender, EventArgs e)
        {
        }

        private void menuItem6_Click(object sender, EventArgs e)
        {
            UIReportMetadata generalMetadata = new UIReportMetadata(this);
            generalMetadata.Show();

        }

        private void menuItem4_Click(object sender, EventArgs e)
        {
            UIReportMetadata gmd = new UIReportMetadata(this);
            gmd.Show();
        }

        private void menuItem6_Click_1(object sender, EventArgs e)
        {
            UIProposal uip = new UIProposal();
            uip.Show();
        }

        private void menuItem9_Click(object sender, EventArgs e)
        {
            UIDocument utf = new UIDocument();
            utf.Show();
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            UIDocumentList uid = new UIDocumentList();
            uid.Show();
        }

        private void frmParserMainUI_Leave(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void miReferenceData_Click(object sender, EventArgs e)
        {
            UIReferenceData referenceData = new UIReferenceData(this);
            referenceData.Show();
        }

        private void miImpactedDocuments(object sender, EventArgs e)
        {
            UIImpactedDocuments uiimpactedDocuments = new UIImpactedDocuments();
            uiimpactedDocuments.Show();
        }

        private void miProjectPlan_Click(object sender, EventArgs e)
        {
            UIProjectPlan uipp = new UIProjectPlan();
            uipp.Show();
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            UIDocumentLink uidl = new UIDocumentLink();
            uidl.Show();


        }

        private void menuItem13_Click(object sender, EventArgs e)
        {
            UIDocumentSetDocumentLink uidosdl = new UIDocumentSetDocumentLink();
            uidosdl.ShowDialog();

        }

        private void menuItem12_Click(object sender, EventArgs e)
        {
            UIDocumentLink uidl = new UIDocumentLink();
            uidl.Show();

        }

        private void miUsers_Click(object sender, EventArgs e)
        {
            UIUserAccess uiua = new UIUserAccess();
            uiua.Show();
        }

        private void menuItem14_Click(object sender, EventArgs e)
        {
            UIUserSettings uius = new UIUserSettings();
            uius.Show();
        }

        private void miProcessRequest_Click(object sender, EventArgs e)
        {
            UIProcessRequest upr = new UIProcessRequest();
            upr.Show();
        }

        private void miListNew_Click(object sender, EventArgs e)
        {
            UIClientList uicl = new UIClientList(this);
            uicl.Show();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void miRelatedReferenceCode_Click(object sender, EventArgs e)
        {
            UIRelatedReferenceData uirr = new UIRelatedReferenceData();
            uirr.Show();
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }

        private void menuItem1_Click_1(object sender, EventArgs e)
        {
            UISendEmail usemail = new UISendEmail();
            usemail.Show();
        }

        private void menuItem4_Click_1(object sender, EventArgs e)
        {
            CodeType ct = new CodeType();
            ct.Redis_StoreCodeTypes();

        }

    }
}