using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FCMMySQLBusinessLibrary.FCMUtils;
using FCMMySQLBusinessLibrary.Model.ModelClientDocument;
using FCMMySQLBusinessLibrary.Service.SVCClientDocument.Service;
using Google.GData.Client;
using Google.GData.Documents;

using fcm.Windows.Google.Model;
using System.Diagnostics;
using FCMMySQLBusinessLibrary;

namespace fcm.Windows
{
    public partial class UIGoogleDocs : Form
    {
        //The parent form to this one.
        ModelGoogle modelGoogle;
        private TreeNode tndocSelected;
        string destinationFolder;

        public UIGoogleDocs(string DestinationFolder)
        {
            InitializeComponent();
            modelGoogle = new ModelGoogle();
            destinationFolder = DestinationFolder;
            Username.Text = "DanielLGMachado@gmail.com";
           
        }

        private void UIGoogleDocs_Load( object sender, EventArgs e )
        {   
            
            // Image list
            //
            ImageList imageList = ControllerUtils.GetImageList();
            tvFileList.ImageList = imageList;

            tvGoogle.ImageList = imageList;

            // Clear nodes
            tvFileList.Nodes.Clear();
            tvGoogle.Nodes.Clear();

            loadDocumentList();
        }


        //
        // Load documents for a Client Document Set
        //
        private void loadDocumentList()
        {

            // List client document list
            //
            var documentSetList = new ClientDocument();
            //documentSetList.List( Utils.ClientID, Utils.ClientSetID );
            
            var request = new BUSClientDocument.ClientDocumentListRequest();
            request.clientDocumentSetUID = Utils.ClientSetID;
            request.clientUID = Utils.ClientID;

            BUSClientDocument.List( request );

            tvFileList.Nodes.Clear();
            // documentSetList.ListInTree( tvFileList, "CLIENT" );

            BUSClientDocument.ListInTree(documentSetList, tvFileList, "CLIENT" );
            
            if (tvFileList.Nodes.Count > 0)
                tvFileList.Nodes[0].Expand();


        }

        private void LoginButton_Click( object sender, EventArgs e )
        {
            if (Username.Text == "")
            {
                MessageBox.Show( "Please specify a username", "No user name", MessageBoxButtons.OK, MessageBoxIcon.Error );
                return;
            }
            if (Password.Text == "")
            {
                MessageBox.Show( "Please specify a password", "No password", MessageBoxButtons.OK, MessageBoxIcon.Error );
                return;
            }

            try
            {
                LoginButton.Text = "Logging In";
                UploaderStatus.Text = "Connecting to server...";
                LoginButton.Enabled = false;
                LogoutButton.Enabled = true;
                RefreshButton.Enabled = true;
                Username.Enabled = false;
                Password.Enabled = false;
                modelGoogle.Login( Username.Text, Password.Text );
                LoginButton.Text = "Logged In";
                UploaderStatus.Text = "Login complete";


            }
            catch (Exception ex)
            {
                LoginButton.Enabled = true;
                LogoutButton.Enabled = false;
                Username.Enabled = true;
                Password.Enabled = true;
                RefreshButton.Enabled = false;
                LoginButton.Text = "Login";
                UploaderStatus.Text = "Error authenticating";
                MessageBox.Show( "Error logging into Google Docs: " + ex.Message, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }

        }


        /// <summary>
        /// Gets a new list of documents from the server and renders
        /// them in the ListView called DocList on the form.
        /// </summary>
        public void UpdateDocList()
        {
            if (!modelGoogle.loggedIn)
            {
                MessageBox.Show( "Log in before retrieving documents.", "Log in", MessageBoxButtons.OK, MessageBoxIcon.Error );
                return;
            }

            DocList.Items.Clear();
            tvGoogle.Nodes.Clear();

            try
            {

                DocumentsFeed feed = modelGoogle.GetDocs();

                foreach (DocumentEntry entry in feed.Entries)
                {
                    string imageKey = "";
                    if (entry.IsDocument)
                    {
                        imageKey = "Document.gif";

                    }
                    else if (entry.IsSpreadsheet)
                    {
                        imageKey = "Spreadsheet.gif";
                    }
                    else
                    {
                        imageKey = "Presentation.gif";
                    }

                    ListViewItem item = new ListViewItem( entry.Title.Text, imageKey );
                    item.SubItems.Add( entry.Updated.ToString() );
                    item.Tag = entry;
                    DocList.Items.Add( item );

                
                }


                foreach (ColumnHeader column in DocList.Columns)
                {
                    column.AutoResize( ColumnHeaderAutoResizeStyle.ColumnContent );
                }


                ModelGoogle.LoadGoogleDocsInTree( tvGoogle, feed );
            
            }
            catch (Exception e)
            {
                MessageBox.Show( "Error retrieving documents: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }


        
        }

        /// <summary>
        /// Logout from google
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogoutButton_Click( object sender, EventArgs e )
        {
            modelGoogle.Logout();
            LoginButton.Enabled = true;
            LogoutButton.Enabled = false;
            Username.Enabled = true;
            Password.Enabled = true;
            RefreshButton.Enabled = false;
            LoginButton.Text = "Login";
            UploaderStatus.Text = "Logged out.";
        }

        private void uploadDocumentToolStripMenuItem_Click( object sender, EventArgs e )
        {
            if (!modelGoogle.loggedIn)
            {
                MessageBox.Show( "Please log in before uploading documents", "Upload Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                return;
            }

            //
            // Get selected document from tree
            //
            tndocSelected = tvFileList.SelectedNode;
            var rm = new scClientDocSetDocLink();

            if (tndocSelected == null)
                return;

            UploadDocument( tndocSelected );

        }

        /// <summary>
        /// Upload document list
        /// </summary>
        /// <param name="document"></param>
        private void UploadDocument( TreeNode docSelected )
        {
            var rm = new scClientDocSetDocLink();

            rm = (scClientDocSetDocLink)docSelected.Tag; // Cast 

            if (rm.document.DocumentType == MackkadoITFramework.Helper.Utils.DocumentType.FOLDER)
            {
                foreach (TreeNode tn in docSelected.Nodes)
                {
                    // Print Document
                    var docToPrint = new scClientDocSetDocLink();
                    docToPrint = (scClientDocSetDocLink)docSelected.Tag;

                    UploadDocument( tn );
                }
            }
            else
            {

                //  Utils.OpenDocument( txtDestinationFolder.Text + rm.clientDocument.Location, rm.clientDocument.FileName, rm.clientDocument.DocumentType );

                string file = Utils.getFilePathName(destinationFolder + rm.clientDocument.Location, rm.clientDocument.FileName );

                try
                {
                    UploaderStatus.Text = "Uploading " + file;
                    this.Refresh();
                    modelGoogle.UploadFile( file );
                    UploaderStatus.Text = "Successfully uploaded " + file;
                    UpdateDocList();
                }
                catch (ArgumentException)
                {
                    DialogResult result = MessageBox.Show( "Error, unable to upload the file: '" + file + "'. It is not one of the valid types.", "Upload Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error );
                    UploaderStatus.Text = "Problems uploading";
                    if (result == DialogResult.Cancel)
                    {
                        return;
                    }
                }
                catch (Exception ex)
                {
                    DialogResult result = MessageBox.Show( "Error, unable to upload the file: '" + file + "'. " + ex.Message, "Upload Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error );
                    UploaderStatus.Text = "Problems uploading";
                    if (result == DialogResult.Cancel)
                    {
                        return;
                    }
                }
            }

        }


        private void OpenMenuItem_Click( object sender, EventArgs e )
        {

           
            if (DocList.SelectedItems.Count > 0)
            {
                DocumentEntry entry = (DocumentEntry)DocList.SelectedItems[0].Tag;
                try
                {
                    Process.Start( entry.AlternateUri.ToString() );
                }
                catch (Win32Exception)
                {
                    //nothing is registered to handle URLs, so let's use IE!
                    Process.Start( "IExplore.exe", entry.AlternateUri.ToString() );
                }
            }

            TreeNode tn = tvGoogle.SelectedNode;
            if (tn != null)
            {
                DocumentEntry entry = (DocumentEntry)tn.Tag;
                try
                {
                    Process.Start( entry.AlternateUri.ToString() );
                }
                catch (Win32Exception)
                {
                    //nothing is registered to handle URLs, so let's use IE!
                    Process.Start( "IExplore.exe", entry.AlternateUri.ToString() );
                }

            }
        }

        private void DeleteMenuItem_Click( object sender, EventArgs e )
        {
            if (DocList.SelectedItems.Count > 0)
            {
                DocumentEntry entry = (DocumentEntry)DocList.SelectedItems[0].Tag;
                DialogResult result = MessageBox.Show( "Are you sure you want to delete " + entry.Title.Text + "?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning );
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        entry.Delete();
                        UpdateDocList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show( "Error when deleting: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                    }

                }
            }

            TreeNode tn = tvGoogle.SelectedNode;
            if (tn != null && tvGoogle.Tag != null)
            {
                DocumentEntry entry = (DocumentEntry)tvGoogle.Tag;
                DialogResult result = MessageBox.Show( "Are you sure you want to delete " + entry.Title.Text + "?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning );
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        entry.Delete();
                        UpdateDocList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show( "Error when deleting: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                    }

                }
            }

        
        
        }

        private void RefreshButton_Click( object sender, EventArgs e )
        {
            UpdateDocList();
        }

    }
}
