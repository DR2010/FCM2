using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace fcm.Windows
{
    public partial class UICompanyMetadata : Form
    {

        private string _connectionString;
        private string _userID;
        public DataTable elementSourceDataTable;

        public UICompanyMetadata(string userID, string connectionString)
        {
            InitializeComponent();

            _connectionString = connectionString;
            _userID = userID;


            //
            // Create datatable
            //

            var UID = new DataColumn("UID", typeof(String));
            var InformationType = new DataColumn("InformationType", typeof(String));
            var FieldCode = new DataColumn("FieldCode", typeof(String));
            var TableName = new DataColumn("TableName", typeof(String));
            var FieldName = new DataColumn("FieldName", typeof(String));
            var FilePath = new DataColumn("FilePath", typeof(String));
            var FileName = new DataColumn("FileName", typeof(String));

            elementSourceDataTable = new DataTable("ElementSourceDataTable");

            elementSourceDataTable.Columns.Add(UID);
            elementSourceDataTable.Columns.Add(InformationType);
            elementSourceDataTable.Columns.Add(FieldCode);
            elementSourceDataTable.Columns.Add(TableName);
            elementSourceDataTable.Columns.Add(FieldName);
            elementSourceDataTable.Columns.Add(FilePath);
            elementSourceDataTable.Columns.Add(FileName);

            dgvGlobalFields.DataSource = elementSourceDataTable;

        }

        private void DocumentTemplate_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'managementDataSet.DocumentTemplateType' table. You can move, or remove it, as needed.



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSaveModifications_Click(object sender, EventArgs e)
        {
            // documentTemplateTypeTableAdapter.Updatep
        }

        // -------------------------------------------------------
        // This method copies one document 
        // -------------------------------------------------------
        private void btnCopyDocument_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Copy document FROM";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                object fromFileName = openFileDialog1.FileName;
                object destinationFileName = fromFileName + "_v01.doc";
                var fromString = new List<string>();
                var toString = new List<string>();

                fromString.Add("<<Company Name>>");
                toString.Add("Hey Name");

                WordDocumentTasks.CopyDocument(
                    fromFileName,
                    destinationFileName,
                    fromString,
                    toString
                    );
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReplicateFolderFilesReplace();
            MessageBox.Show("Folder replicated successfully");
        }


        // --------------------------------------------------------
        //  This method copies the whole folder structure
        // --------------------------------------------------------
        private void btnCopyFolder_Click(object sender, EventArgs e)
        {
            string newFolder = "C:\\projects\\Systems\\TemplateCopy";

            WordDocumentTasks.CopyFolder(
                 "C:\\projects\\Research\\TestTemplate\\TemplateFrom",
                 newFolder);

            var parentFolder = Directory.GetParent(newFolder);
            if (parentFolder != null) 
                parentFolder.Refresh();
        }

        // -----------------------------------------------------------------------
        // This method replicates an entire folder structure including files
        // It also replaces the metadata by database fields
        // -----------------------------------------------------------------------
        private void ReplicateFolderFilesReplace()
        {
             Word.ApplicationClass vkWordApp = 
                                 new Word.ApplicationClass();

            string sourceFolder = 
                "C:\\projects\\Research\\TestTemplate\\TemplateFrom";

            string destinationFolder = 
                "C:\\projects\\Research\\TestTemplate\\TemplateTo";

            var ts = new List<WordDocumentTasks.TagStructure>();
            ts.Add(new WordDocumentTasks.TagStructure(){Tag="<<XX>>", TagValue="VV1"});
            ts.Add(new WordDocumentTasks.TagStructure(){Tag="<<YY>>", TagValue="VV2"});
            ts.Add(new WordDocumentTasks.TagStructure(){Tag="<<VV>>", TagValue="VV3"});

            WordDocumentTasks.CopyFolder(sourceFolder, destinationFolder);
            WordDocumentTasks.ReplaceStringInAllFiles(destinationFolder, ts, vkWordApp);
        }

        // ------------------------------------------------------
        //  Display list of companies on the datatable
        // ------------------------------------------------------
        private void loadFieldList()
        {
            elementSourceDataTable.Clear();

            var compList = new CompanyList(_userID, _connectionString);
            compList.List();

            foreach (Company company in compList.companyList)
            {
                DataRow elementRow = elementSourceDataTable.NewRow();
                elementRow["UID"] = company.UID;
                elementRow["Name"] = company.Name;
                elementRow["Phone"] = company.Phone;
                elementRow["Fax"] = company.Fax;
                elementRow["EmailAddress"] = company.EmailAddress;
                elementRow["MainContactPersonName"] = company.MainContactPersonName;
                elementRow["Address"] = company.Address;

                elementSourceDataTable.Rows.Add(elementRow);

            }

        }

    }
}