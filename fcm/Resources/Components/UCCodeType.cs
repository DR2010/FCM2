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
    public partial class UCCodeType : UserControl
    {
        public UCCodeType()
        {
            InitializeComponent();
        }

        private void UCCodeType_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CodeType ct = new CodeType();
            ct.Code = txtCodeType.Text;
            ct.Description = txtCodeDescription.Text;
            ct.ShortCodeType = txtShortCode.Text;

            ct.Add();

            MessageBox.Show("Code Type Save Successfully.");

            txtShortCode.Text = "";
            txtCodeType.Text = "";
            txtCodeDescription.Text = "";

            txtCodeType.Focus();

        }

        private void txtCodeType_TextChanged(object sender, EventArgs e)
        {

        }

        private void UCCodeType_Enter(object sender, EventArgs e)
        {
        }
    }
}
