using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FCMApplicationLoader
{
    public partial class UIFCMAppLoader : Form
    {
        public UIFCMAppLoader()
        {
            InitializeComponent();
        }

        private void btnLoadApplication_Click(object sender, EventArgs e)
        {
            AssemblyLoader load = new AssemblyLoader();

            if (load.AssemblyCanBeLoaded)
            {
                load.LoadFCMClient();
                // this.Hide();
                this.Dispose();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void UIFCMAppLoader_Leave(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
