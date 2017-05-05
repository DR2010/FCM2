using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace fcm.Components
{
    public partial class UCDocument : UserControl
    {
        public UCDocument()
        {
            InitializeComponent();
        }

        private void UCDocument_Load(object sender, EventArgs e)
        {

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

        public void New()
        {
            txtCUID.Text = "";
            txtDirectory.Text = "";
            txtLatestIssueLocation.Text = "";
            txtLatestIssueNumber.Text = "";
            txtName.Text = "";
            txtSeqNum.Text = "";
            txtSubDirectory.Text = "";
            txtComments.Text = "";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            New();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            var file = openFileDialog1.ShowDialog();

            if (file == DialogResult.OK)
            {
                txtLatestIssueLocation.Text = openFileDialog1.FileName;
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            
            Document docSave = new Document();

            if (string.IsNullOrEmpty(txtCUID.Text))
            {
                docSave.Comments = txtComments.Text;
                docSave.Directory = txtDirectory.Text;
                docSave.LatestIssueLocation = txtLatestIssueLocation.Text;
                docSave.LatestIssueNumber = txtLatestIssueNumber.Text;
                docSave.Name = txtName.Text;
                docSave.SequenceNumber = txtSeqNum.Text;
                docSave.Subdirectory = txtSubDirectory.Text;

                docSave.Add();
            }
            else
            {

            }

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDirectory_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSubDirectory_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSeqNum_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLatestIssueNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLatestIssueLocation_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtComments_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtCUID_TextChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
