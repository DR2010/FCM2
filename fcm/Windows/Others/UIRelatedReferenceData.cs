using System;
using System.Drawing;
using System.Windows.Forms;
using FCMMySQLBusinessLibrary.Service.SVCClient.Service;
using FCMMySQLBusinessLibrary.FCMUtils;
using MackkadoITFramework.ReferenceData;


namespace fcm.Windows
{
    public partial class UIRelatedReferenceData : Form
    {
        public UIRelatedReferenceData()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void UIRelatedReferenceData_Load(object sender, EventArgs e)
        {
            LoadInitialValues();
        }

        private void LoadInitialValues()
        {
            cbxRelatedCode.Items.Clear();
            cbxTo.Items.Clear();
            cbxFrom.Items.Clear();

            foreach (var codetype in Cache.CachedInfo.ListOfCodeTypes)
            {
                cbxFrom.Items.Add(codetype.Code);
                cbxTo.Items.Add(codetype.Code);
            }

            foreach (var relatedCode in Cache.CachedInfo.ListOfRelatedCodes)
            {
                cbxRelatedCode.Items.Add(relatedCode.RelatedCodeID);
            }
            cbxRelatedCode.Items.Add("<<New>>");

        }


        private void cbxFrom_SelectedIndexChanged(object sender, EventArgs e)
        {

            tvFrom.Nodes.Clear();

            TreeNode root = new TreeNode("From " + cbxFrom.Text);
            tvFrom.Nodes.Add(root);

            foreach(var fromcode in Cache.CachedInfo.GetListOfCodeValue(cbxFrom.Text))
            {
                TreeNode elementNode = new TreeNode(fromcode.ID);

                root.Nodes.Add(elementNode);
                elementNode.Tag = fromcode;

                // load linked values
                //
                var subitems = Cache.CachedInfo.GetListOfRelatedCodeValue(cbxRelatedCode.Text, cbxFrom.Text, fromcode.ID);

                foreach (var item in subitems)
                {
                    TreeNode subitemNode = new TreeNode(item.FKCodeValueTo);
                    subitemNode.Tag = item;

                    elementNode.Nodes.Add(subitemNode);
                }
            }

            tvFrom.ExpandAll();
        }

        private void cbxTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            tvTo.Nodes.Clear();

            TreeNode rootTo = new TreeNode("To " + cbxTo.Text);
            tvTo.Nodes.Add(rootTo);

            foreach (var tocode in Cache.CachedInfo.GetListOfCodeValue(cbxTo.Text))
            {
                TreeNode element = new TreeNode(tocode.ID);

                rootTo.Nodes.Add(element);
                element.Tag = tocode;
            }

            tvTo.ExpandAll();

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            RelatedCode relcode = new RelatedCode();
            relcode.RelatedCodeID = txtNewRelatedCode.Text;
            relcode.FKCodeTypeFrom = cbxFrom.Text;
            relcode.FKCodeTypeTo = cbxTo.Text;
            relcode.Description = txtRelatedCodeDescription.Text;

            if (string.IsNullOrEmpty(relcode.FKCodeTypeTo))
                return;
            if (string.IsNullOrEmpty(relcode.FKCodeTypeFrom))
                return;

            var response = BUSReferenceData.AddRelatedCodeType(relcode);

            ControllerUtils.ShowFCMMessage(response,Utils.UserID);

            // Reload is necessary since new code has been added.
            //
            Cache.CachedInfo.LoadRelatedCodeInCache();

            LoadInitialValues();
        }

        private void tvFrom_DragDrop(object sender, DragEventArgs e)
        {
            LinkValueToCode(sender, e);
        }

        private void LinkValueToCode(object sender, DragEventArgs e)
        {
            // Get selected document from tree
            //
            TreeNode tnDocumentSelectedTo = tvTo.SelectedNode;
            if (tnDocumentSelectedTo == null)
                return;

            var tndocselected = (CodeValue)tnDocumentSelectedTo.Tag;

            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                Point pt;
                TreeNode destinationNode;
                pt = tvFrom.PointToClient(new Point(e.X, e.Y));
                destinationNode = tvFrom.GetNodeAt(pt);
                if (destinationNode == null)
                    return;

                tnDocumentSelectedTo.Remove();

                destinationNode.Nodes.Add(tnDocumentSelectedTo);

                // Add link to the database
                //
                CodeValue itemSelectedTo = new CodeValue();
                itemSelectedTo = (CodeValue)tnDocumentSelectedTo.Tag;

                CodeValue destination = new CodeValue();
                destination = (CodeValue)destinationNode.Tag;

                // New link to be created
                RelatedCodeValue rcv = new RelatedCodeValue();
                rcv.FKRelatedCodeID = cbxRelatedCode.Text;
                rcv.FKCodeTypeFrom = destination.FKCodeType;
                rcv.FKCodeValueFrom = destination.ID;
                rcv.FKCodeTypeTo = itemSelectedTo.FKCodeType;
                rcv.FKCodeValueTo = itemSelectedTo.ID;

                var response = BUSReferenceData.AddRelatedCodeValue(rcv);

                ControllerUtils.ShowFCMMessage(response, Utils.UserID);

                Cache.CachedInfo.LoadRelatedCodeInCache();

            }
        }

        private void tvFrom_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void tvTo_DragDrop(object sender, DragEventArgs e)
        {
            //
            // Get selected document from tree
            //
            TreeNode tndocSelected = tvTo.SelectedNode;

            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                Point pt;
                TreeNode destinationNode;
                pt = tvTo.PointToClient(new Point(e.X, e.Y));

                destinationNode = tvFrom.GetNodeAt(pt);

                if (tndocSelected == null)
                    return;

                // If destination tree is the same as source tree, do nothing
                if (destinationNode.TreeView == tndocSelected.TreeView)
                    return;

            }
        }

        private void tvTo_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void tvTo_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void cbxRelatedCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxRelatedCode.Text == "<<New>>")
            {
                txtNewRelatedCode.Focus();
                cbxFrom.Enabled = true;
                cbxTo.Enabled = true;
                txtRelatedCodeDescription.Enabled = true;

            }
            else
            {
                cbxFrom.Enabled = false;
                cbxTo.Enabled = false;
                txtRelatedCodeDescription.Enabled = false;

                var relcodeinfo = Cache.CachedInfo.GetRelatedCode(cbxRelatedCode.Text);

                cbxFrom.Text = relcodeinfo.FKCodeTypeFrom;
                cbxTo.Text = relcodeinfo.FKCodeTypeTo;
            }
        }
    }
}
