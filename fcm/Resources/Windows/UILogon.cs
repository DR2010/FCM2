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
    public partial class UILogon : Form
    {
        public UILogon()
        {
            InitializeComponent();
        }

        private void Logon_Leave(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Logon_Load(object sender, EventArgs e)
        {
            cbxDB.Items.Add(ConnString.Toshiba);
            cbxDB.Items.Add(ConnString.DeanPC);
            cbxDB.Items.Add(ConnString.HPLaptop);
            cbxDB.Items.Add(ConnString.Desktop);
            cbxDB.Items.Add(ConnString.HPMINI);

            cbxDB.SelectedIndex = 0;

        }

        private void Logon_FormClosed(object sender, FormClosedEventArgs e)
        {
            if ( String.IsNullOrEmpty( txtUserID.Text ))
                Application.Exit();

        }

        private void btnLogon_Click(object sender, EventArgs e)
        {
            Utils.UserID = txtUserID.Text;
            ConnString.ConnectionString = cbxDB.SelectedItem.ToString();

            Utils.ClientList = new ClientList();
            Utils.ClientList.List();

            this.Close();

        }
    }
}
