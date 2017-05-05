using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FCMMySQLBusinessLibrary;
using MackkadoITFramework.ReferenceData;

namespace fcm.Components
{
    public partial class UCCodeValue : UserControl
    {
        public List<CodeType> codeTypeList;
        private CodeValue codeValue;


        public UCCodeValue()
        {
            InitializeComponent();

            codeValue = new CodeValue();

        }

        public UCCodeValue(string iCodeType, string iCodeValue)
        {
            InitializeComponent();

            this.ReadCodeValue(iCodeType, iCodeValue);


        }

        //
        // Set control fields
        //
        public void SetFKCodeType(string fkCodeType)
        {
            this.cbxCodeType.Text = fkCodeType;
            cbxCodeType.Enabled = false;

        }
        public void SetCodeID(string codeValueID)
        {
            this.txtCodeValueCode.Text = codeValueID;

            txtCodeValueCode.Enabled = false;

        }
        public void SetCodeDescription(string codeDescription)
        {
            this.txtCodeDescription.Text = codeDescription;
        }
        public void SetValueExtended(string valueExtended)
        {
            this.txtValueExtended.Text = valueExtended;
        }
        public void SetAbbreviation(string Abbreviation)
        {
            this.txtAbbreviation.Text = Abbreviation;
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            CodeValue cv = new CodeValue();

            if (cbxCodeType.Text == null)
            {
                MessageBox.Show("Select Code Type.");
                return;
            }

            cv.FKCodeType = cbxCodeType.Text;
            cv.ID = txtCodeValueCode.Text;
            cv.Description = txtCodeDescription.Text;
            cv.Abbreviation = txtAbbreviation.Text;
            cv.ValueExtended = txtValueExtended.Text;

            cv.Save();

            MessageBox.Show("Code Type Save Successfully.");

            ResetFields();
            
        }

        private void UCCodeValue_Load(object sender, EventArgs e)
        {
            LoadCodeType();
        }

        private void cbxCodeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valueSelected = cbxCodeType.SelectedItem.ToString();
        }

        private void UCCodeValue_Enter(object sender, EventArgs e)
        {
            var ctsel = cbxCodeType.SelectedItem;
            
            LoadCodeType();

            cbxCodeType.SelectedItem = ctsel;

        }

        private void LoadCodeType()
        {
            codeTypeList = new List<CodeType>();

            var codeType = new CodeType();

            // Fill in the code type list
            //
            codeType.List(codeTypeList);

            cbxCodeType.Items.Clear();

            foreach (CodeType c in codeTypeList)
            {
                cbxCodeType.Items.Add(c.Code);
            }
        }

        private void txtCodeValueCode_Leave(object sender, EventArgs e)
        {
            // string CodeType = cbxCodeType.SelectedItem.ToString();
            string CodeType = cbxCodeType.Text;
            string CodeValue = txtCodeValueCode.Text;

            this.ReadCodeValue(CodeType, CodeValue);

        }

        private void ReadCodeValue(string iCodeType, string iCodeValue)
        {
            //CodeValue cv = new CodeValue();
            //cv.FKCodeType = iCodeType;
            //cv.ID = iCodeValue;

            //cv.Read(false);

            codeValue.FKCodeType = iCodeType;
            codeValue.ID = iCodeValue;

            codeValue.Read(false);

            txtCodeDescription.Text = codeValue.Description;
            txtValueExtended.Text = codeValue.ValueExtended;
            txtAbbreviation.Text = codeValue.Abbreviation;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ResetFields();
        }

        private void ResetFields()
        {
            txtCodeValueCode.Enabled = true;
            cbxCodeType.Enabled = true;

            txtCodeValueCode.Text = "";
            txtCodeDescription.Text = "";
            txtAbbreviation.Text = "";
            txtValueExtended.Text = "";

            txtCodeValueCode.Focus();
        }

        private void btnSelectDestination_Click( object sender, EventArgs e )
        {
            
            // Show file dialog
            //
            openFileDialog1.InitialDirectory = "C:\\Program Files\\Adobe\\Reader 9.0\\Reader\\";
            openFileDialog1.Filter = "Executable files (*.exe)|*.exe"; //"Text files (*.txt)|*.txt|All files (*.*)|*.*"
            openFileDialog1.FileName = "*";

            var file = openFileDialog1.ShowDialog();

            if (file == DialogResult.OK)
            {
                // Only File Name
                string fileName = openFileDialog1.SafeFileName;
                // Full Path including file name
                string fullPathFileName = openFileDialog1.FileName;

                txtValueExtended.Text = fullPathFileName; 

            }

        }
    }
}
