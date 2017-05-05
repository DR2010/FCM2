using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace fcm.Windows
{
    public partial class UIDocumentEdit : Form
    {
        private UIDocumentList uidl;

        public UIDocumentEdit()
        {
            InitializeComponent();
        }

        public UIDocumentEdit(UIDocumentList _uidl)
        {
            InitializeComponent();
            uidl = new UIDocumentList();
            uidl = _uidl;

            txtCUID.Enabled = false;
            txtCUID.ReadOnly = true;
            txtDirectory.Focus();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            New();
        }

        //
        // Clear fields
        //
        private void New()
        {
            txtCUID.Text = "";
            txtDirectory.Text = "";
            txtLatestIssueLocation.Text = "";
            txtLatestIssueNumber.Text = "";
            txtName.Text = "";
            txtSeqNum.Text = "";
            txtSubDirectory.Text = "";
            txtComments.Text = "";

            txtCUID.Enabled = true;
            txtCUID.ReadOnly = false;
            txtCUID.Focus();

        }

        public void SetValues(Document inDoco)
        {
            txtCUID.Text = inDoco.CUID;
            txtDirectory.Text = inDoco.Directory;
            txtLatestIssueLocation.Text = inDoco.LatestIssueLocation;
            txtLatestIssueNumber.Text = inDoco.LatestIssueNumber;
            txtName.Text = inDoco.Name;
            txtSeqNum.Text = inDoco.SequenceNumber;
            txtSubDirectory.Text = inDoco.Subdirectory;
            txtComments.Text = inDoco.Comments;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            Document docSave = new Document();

            docSave.CUID = txtCUID.Text;
            docSave.Comments = txtComments.Text;
            docSave.Directory = txtDirectory.Text;
            docSave.LatestIssueLocation = txtLatestIssueLocation.Text;
            docSave.LatestIssueNumber = txtLatestIssueNumber.Text;
            docSave.Name = txtName.Text;
            docSave.SequenceNumber = txtSeqNum.Text;
            docSave.Subdirectory = txtSubDirectory.Text;
            docSave.Comments = txtComments.Text;

            docSave.Save();

            if (uidl != null)
                uidl.Refresh();

        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            var file = openFileDialog1.ShowDialog();

            if (file == DialogResult.OK)
            {
                txtLatestIssueLocation.Text = openFileDialog1.FileName;
            }
        }

        private void UIDocumentEdit_Load(object sender, EventArgs e)
        {

        }

        private void btnNewIssue_Click(object sender, EventArgs e)
        {
            UIDocumentIssue uidi = new 
        }
    }
}
