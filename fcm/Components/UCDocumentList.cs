using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FCMMySQLBusinessLibrary;
using FCMMySQLBusinessLibrary.FCMUtils;
using FCMMySQLBusinessLibrary.Model.ModelDocument;
using FCMMySQLBusinessLibrary.Repository.RepositoryDocument;
using FCMMySQLBusinessLibrary.Service.SVCDocument.Service;
using FCMMySQLBusinessLibrary.Service.SVCDocument.ServiceContract;

namespace fcm.Components
{
    public partial class UCDocumentList : UserControl
    {
        public UCDocumentList(string mode, string listType)
        {
            InitializeComponent();

            if (mode == FCMConstant.DocumentListMode.SELECT)
            {
                btnKeep.Visible = false;
                btnSaveSet.Visible = false;
                btnRemove.Visible = false;
            }

            if (listType == FCMConstant.DocumentListType.FCM)
            {
                cbxDocumentSet.Visible = false;
                label1.Visible = false;
            }

            if (listType == FCMConstant.DocumentListType.DOCUMENTSET)
            {
                cbxDocumentSet.Visible = true;
                label1.Visible = true;
            }

        }

        private void UCDocumentList_Load(object sender, EventArgs e)
        {
            DocumentSetList dsl = new DocumentSetList();
            dsl.ListInComboBox(cbxDocumentSet);
            cbxDocumentSet.SelectedIndex = 0;

            SelectIndexChanged();
        }

        public void loadDocumentList()
        {

            // Image list
            //
            ImageList imageList = ControllerUtils.GetImageList();

            // Binding
            tvFileList.ImageList = imageList;

            // Clear nodes
            tvFileList.Nodes.Clear();

            var docoList = new DocumentList();

            docoList.List();

            // Load document in the treeview
            //
            // docoList.ListInTree(tvFileList);
            Document root = new Document();
            root.CUID = "ROOT";
            root.RecordType = FCMConstant.RecordType.FOLDER;
            root.UID = 0;
            // root.Read();

            // root = RepDocument.Read(false,0, "ROOT");

            // Using Business Layer
            root = BUSDocument.GetRootDocument();

            DocumentList.ListInTree(tvFileList, docoList, root);
            // tvFileList.ExpandAll();
            tvFileList.Nodes[0].Expand();
        }

        public void loadDocumentList(int documentSetUID = 0)
        {

            // Image list
            //
            ImageList imageList = ControllerUtils.GetImageList();

            // Binding
            tvFileList.ImageList = imageList;

            // Clear nodes
            tvFileList.Nodes.Clear();

            var docoList = new DocumentList();

            docoList.ListDocSet(documentSetUID);

            // Load document in the treeview
            //
            Document root = new Document();
            root.CUID = "ROOT";
            root.RecordType = FCMConstant.RecordType.FOLDER;
            root.UID = 0;
            // root.Read();

            //root = RepDocument.Read(false, 0, "ROOT");
            root = BUSDocument.GetRootDocument();

            DocumentList.ListInTree(tvFileList, docoList, root);
            tvFileList.Nodes[0].Expand();
        }

        private void cbxDocumentSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectIndexChanged();
        }

        // Handles the selection index change
        //
        private void SelectIndexChanged()
        {

            int documentSetUID = 0;
            if (string.IsNullOrEmpty(cbxDocumentSet.Text) ||
                cbxDocumentSet.Visible == false )
            {
                documentSetUID = 0;
            }
            else
            {
                string[] ArrayDocSetText = cbxDocumentSet.Text.Split(';');

                documentSetUID = Convert.ToInt32(ArrayDocSetText[0]);
            }
            if (documentSetUID == 0)
                loadDocumentList();
            else
                loadDocumentList(documentSetUID);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

    }
}
