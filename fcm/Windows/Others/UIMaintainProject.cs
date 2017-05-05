using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MackkadoITFramework.APIDocument;
using FCMMySQLBusinessLibrary.Model.ModelClient;

namespace fcm.Windows
{
    public partial class UIMaintainProject : Form
    {
        private Client _Client;

        public UIMaintainProject( Client iClient )
        {
            InitializeComponent();
            _Client = iClient;
            txtClientID.Text = _Client.UID.ToString();
            txtClientName.Text = _Client.Name;
        
        }

        private void btnGenerateProjectFiles_Click(object sender, EventArgs e)
        {
            ReplicateFolderFilesReplace();

        }

        // -----------------------------------------------------
        //   This method replicates folders and files for a given
        //   folder structure (source and destination)
        // -----------------------------------------------------
        private void ReplicateFolderFilesReplace()
        {
            Cursor.Current = Cursors.WaitCursor;

            Word.Application vkWordApp =
                                new Word.Application();

            string sourceFolder = txtSourceFolder.Text;
            string destinationFolder = txtDestinationFolder.Text;

            if (sourceFolder == "" || destinationFolder == "")
            {
                return;
            }

            var ts = new List<WordDocumentTasks.TagStructure>();
            ts.Add(new WordDocumentTasks.TagStructure() { Tag = "<<XX>>", TagValue = "VV1" });
            ts.Add(new WordDocumentTasks.TagStructure() { Tag = "<<YY>>", TagValue = "VV2" });
            ts.Add(new WordDocumentTasks.TagStructure() { Tag = "<<VV>>", TagValue = "VV3" });
            ts.Add(new WordDocumentTasks.TagStructure() { Tag = "<<ClientNAME>>", TagValue = "Client 2" });
            ts.Add(new WordDocumentTasks.TagStructure() { Tag = "<<ClientADDRESS>>", TagValue = "St Street" });
            ts.Add(new WordDocumentTasks.TagStructure() { Tag = "<<ClientEMAILADDRESS>>", TagValue = "Email@com" });
            ts.Add(new WordDocumentTasks.TagStructure() { Tag = "<<ClientPHONE>>", TagValue = "09393893" });

            WordDocumentTasks.CopyFolder(sourceFolder, destinationFolder);
            WordDocumentTasks.ReplaceStringInAllFiles(destinationFolder, ts, vkWordApp);
        
            Cursor.Current = Cursors.Arrow;
            MessageBox.Show("Project Successfully Created.");
        }

        private void MaintainProject_Load(object sender, EventArgs e)
        {
            txtSourceFolder.Text = "C:\\Research\\TestTemplate\\TemplateFrom";
            txtDestinationFolder.Text = "C:\\Research\\TestTemplate\\TemplateTo";

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

    }
}
