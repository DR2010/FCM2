using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using fcm.Windows;
using fcm.Components;

namespace fcm.Windows
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class frmParserMainUI : System.Windows.Forms.Form
    {
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MainMenu mainMenu;
        private IContainer components;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private MenuItem menuItem2;
        private MenuItem miClient;
        private MenuItem miEmployee;
        private MenuItem menuItem7;

        private string _userID;
        // private string _connectionString;
        // private ClientList _ClientList;
        private MenuItem menuItem3;
        private MenuItem menuItem4;
        private MenuItem menuItem6;
        private MenuItem menuItem9;
        private PictureBox pictureBox1;
        private MenuItem menuItem1;

        /// <summary>
        /// MS Word COM Object
        /// </summary>
        private Word.ApplicationClass vk_word_app = new Word.ApplicationClass();

        public frmParserMainUI()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

             _userID = "Daniel";

            //_connectionString =
            //"Data Source=FNOA0189\\SQL2005;Initial Catalog=DanMacTest;integrated security=True";

            
            //_connectionString =
            //    "Data Source=TOSHIBAMACHADO\\SQLEXPRESS;" +
            //    "Initial Catalog=management;" +
            //    "Persist Security info=false;" +
            //    "integrated security=sspi;";

            //_connectionString =
            //    "Data Source=DESKTOPMACHADO\\SQLEXPRESS;" +
            //    "Initial Catalog=management;" +
            //    "Persist Security info=false;" +
            //    "integrated security=sspi;";

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmParserMainUI));
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.miClient = new System.Windows.Forms.MenuItem();
            this.miEmployee = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem5,
            this.menuItem7,
            this.menuItem2});
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 0;
            this.menuItem5.Text = "E&xit";
            this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 1;
            this.menuItem7.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem3,
            this.menuItem4,
            this.menuItem1,
            this.menuItem9});
            this.menuItem7.Text = "Maintenance";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 0;
            this.menuItem3.Text = "Reference Data";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 1;
            this.menuItem4.Text = "Report Metadata";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 3;
            this.menuItem9.Text = "Document Set";
            this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 2;
            this.menuItem1.Text = "Document";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 2;
            this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miClient,
            this.miEmployee,
            this.menuItem6});
            this.menuItem2.Text = "Client";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // miClient
            // 
            this.miClient.Index = 0;
            this.miClient.Text = "Details";
            this.miClient.Click += new System.EventHandler(this.miClient_Click);
            // 
            // miEmployee
            // 
            this.miEmployee.Index = 1;
            this.miEmployee.Text = "Employees";
            this.miEmployee.Click += new System.EventHandler(this.miEmployee_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 2;
            this.menuItem6.Text = "Proposal";
            this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click_1);
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
            this.pictureBox1.Location = new System.Drawing.Point(12, 315);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(236, 74);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmParserMainUI
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(718, 401);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu;
            this.Name = "frmParserMainUI";
            this.ShowIcon = false;
            this.Text = " ";
            this.Load += new System.EventHandler(this.frmParserMainUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() 
        {
            Application.Run(new frmParserMainUI());
        }

        /// <summary>
        /// Get source document. Open a FileDialog window for user to select single/multiple files for
        /// parsing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butSourceDocument_Click(object sender, System.EventArgs e)
        {
            if( openFileDialog.ShowDialog() == DialogResult.OK )
            {
                object	fileName = openFileDialog.FileName;
                object	saveFile = fileName + "_Vk.doc";
				
				
                object	vk_read_only	= false;
                object	vk_visible		= true;
                object	vk_false			= false;
                object	vk_true			= true;
                object	vk_dynamic		= 2;
				

                object	vk_missing		= System.Reflection.Missing.Value;

                // Let make the word application visible
                vk_word_app.Visible = true;
                vk_word_app.Activate();

                // Let's open the document
                Word.Document vk_my_doc = vk_word_app.Documents.Open( ref fileName,
                                                                      ref vk_missing, ref vk_read_only, ref vk_missing, ref vk_missing,
                                                                      ref vk_missing, ref vk_missing, ref vk_missing, ref vk_missing,
                                                                      ref vk_missing, ref vk_missing, ref vk_visible );

                // Let's create a new document
                Word.Document vk_new_doc = vk_word_app.Documents.Add( ref vk_missing,
                                                                      ref vk_missing, ref vk_missing, ref vk_visible );

                // Select and Copy from the original document
                vk_my_doc.Select();
                vk_word_app.Selection.Copy();

                // Paste into new document as unformatted text
                vk_new_doc.Select();
                vk_word_app.Selection.PasteSpecial( ref vk_missing, ref vk_false,
                                                    ref vk_missing, ref vk_false, ref vk_dynamic, ref vk_missing, ref vk_missing );

                // close the original document
                vk_my_doc.Close( ref vk_false, ref vk_missing, ref vk_missing );

                // Let try to replace Vahe with VAHE in the new document
                object	vk_find			= "^l";
                object	vk_replace		= " ";
                object	vk_num			= 1;

                vk_new_doc.Select();
				
                WordDocumentTasks.FindAndReplace( 
                    "<<Client Name>>", 
                    "tEST", 
                    vk_num,
                    vk_word_app);

                // Save the new document
                vk_new_doc.SaveAs( ref saveFile, ref vk_missing, ref vk_missing, ref vk_missing, ref vk_missing,
                                   ref vk_missing, ref vk_missing, ref vk_missing, ref vk_missing, ref vk_missing, ref vk_missing );

                // close the new document
                vk_new_doc.Close( ref vk_false, ref vk_missing, ref vk_missing );

/*
				// Let's get the content from the document
				Word.Paragraphs vk_my_doc_p = vk_new_doc.Paragraphs;
				// Count number of paragraphs in the file
				long p_count = vk_my_doc_p.Count;
				// step through the paragraphs
				for( int i=1; i<=p_count; i++ )
				{
					Word.Paragraph vk_p = vk_my_doc_p.Item( i );
					Word.Range vk_r = vk_p.Range;
					string text = vk_r.Text;

					MessageBox.Show( text );
				}
*/


                // close word application
                vk_word_app.Quit( ref vk_false, ref vk_missing, ref vk_missing );
            }
        }

        private void menuItem5_Click(object sender, System.EventArgs e)
        {
            // Terminate the program
            this.Close();	
        }


        private void menuItem2_Click(object sender, EventArgs e)
        {

        }

        private void miClient_Click(object sender, EventArgs e)
        {
            UIClientDetails ClientDetails = new UIClientDetails(_userID);
            ClientDetails.Show();
        }

        private void frmParserMainUI_Load(object sender, EventArgs e)
        {

            //Utils.ClientList = new ClientList(_userID);
            //Utils.ClientList.List();

            //foreach (Client c in Utils.ClientList.clientList)
            //{
            //    cbxClientName.Items.Add(c.UID + "; " + c.Name);
            //}
            //cbxClientName.SelectedIndex = 0;

            //Utils.ClientID = Utils.ClientList.clientList[cbxClientName.SelectedIndex].UID;
            //Utils.ClientIndex = cbxClientName.SelectedIndex;

            UILogon log = new UILogon();
            log.ShowDialog();

        }

        private void miMaintainProjectDocuments_Click(object sender, EventArgs e)
        {
        }

        private void miMaintainProject_Click(object sender, EventArgs e)
        {

            //var i = cbxClientName.SelectedIndex;

            //if (i > 0)
            //{
            //    var ClientSelected = Utils.ClientList.clientList[i];

            //    UIMaintainProject mproject = new UIMaintainProject(ClientSelected);
            //    mproject.Show();
            //}
            //else
            //{
            //    MessageBox.Show("Please select a Client.");
            //}
        }

        private void menuItem6_Click(object sender, EventArgs e)
        {
            UIReportMetadata generalMetadata = new UIReportMetadata(_userID);
            generalMetadata.Show();

        }

        private void miCreateNewSet_Click(object sender, EventArgs e)
        {
            // UIMaintainProject maintainProject = new  UIMaintainProject( 

        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            UIReferenceData referenceData = new UIReferenceData();
            referenceData.Show();
        }

        private void menuItem8_Click(object sender, EventArgs e)
        {

        }

        private void miDocument_Click(object sender, EventArgs e)
        {

        }

        private void menuItem4_Click(object sender, EventArgs e)
        {
            UIReportMetadata gmd = new UIReportMetadata(_userID);
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

        private void cbxClientName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Utils.ClientID = Utils.ClientList.clientList[cbxClientName.SelectedIndex].UID;
            //Utils.ClientIndex = cbxClientName.SelectedIndex;
        }

        private void miEmployee_Click(object sender, EventArgs e)
        {

        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            UIDocumentList uid = new UIDocumentList();
            uid.Show();
        }

    }
}