using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FCMMySQLBusinessLibrary;
using FCMMySQLBusinessLibrary.FCMUtils;
using FCMMySQLBusinessLibrary.Model.ModelDocument;
using FCMMySQLBusinessLibrary.Repository.RepositoryDocument;
using FCMMySQLBusinessLibrary.Service.SVCDocument.Service;
using FCMMySQLBusinessLibrary.Service.SVCDocument.ServiceContract;

namespace fcm.Windows
{
    public partial class UIProjectPlan : Form
    {
        public UIProjectPlan()
        {
            InitializeComponent();
        }

        private void UIProjectPlan_Load(object sender, EventArgs e)
        {

        }

        // ------------------------------------------
        //            List Documents
        // ------------------------------------------
        public void loadDocumentList()
        {

            // Image list
            //
            ImageList imageList = ControllerUtils.GetImageList();

            // Binding
            tvProjectPlanDoco.ImageList = imageList;

            // Clear nodes
            tvProjectPlanDoco.Nodes.Clear();

            var docoList = new DocumentList();

            docoList.List();

            // Load document in the treeview
            //
            //docoList.ListInTree(tvProjectPlanDoco);
            Document root = new Document();
            root.CUID = "ROOT";
            root.RecordType = FCMConstant.RecordType.FOLDER;
            root.UID = 0;
            // root.Read();

            // root = RepDocument.Read(false, 0, "ROOT");

            // Using Business Layer

            root = BUSDocument.GetRootDocument();

            DocumentList.ListInTree(tvProjectPlanDoco, docoList, root); 
            tvProjectPlanDoco.ExpandAll();

        }

        private void tvProjectPlanDoco_MouseDown( object sender, MouseEventArgs e )
        {
            if (e.Button == MouseButtons.Right)
            {
                tvProjectPlanDoco.SelectedNode = tvProjectPlanDoco.GetNodeAt( e.X, e.Y );
            } 
        }

    }
}
