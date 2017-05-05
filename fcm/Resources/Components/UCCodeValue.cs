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
    public partial class UCCodeValue : UserControl
    {
        public CodeTypeList codeTypeList;

        public UCCodeValue()
        {
            InitializeComponent();
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

            if (cbxCodeType.SelectedItem == null)
            {
                MessageBox.Show("Select Code Type.");
                return;
            }

            cv.FKCodeType = cbxCodeType.SelectedItem.ToString();
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
            codeTypeList = new CodeTypeList();
            codeTypeList.List();

            cbxCodeType.Items.Clear();

            foreach (CodeType c in codeTypeList.codeTypeList)
            {
                cbxCodeType.Items.Add(c.Code);
            }
        }

        private void txtCodeValueCode_Leave(object sender, EventArgs e)
        {
            string CodeType = cbxCodeType.SelectedItem.ToString();
            string CodeValue = txtCodeValueCode.Text;

            this.ReadCodeValue(CodeType, CodeValue);

        }

        private void ReadCodeValue(string iCodeType, string iCodeValue)
        {
            CodeValue cv = new CodeValue();
            cv.FKCodeType = iCodeType;
            cv.ID = iCodeValue;

            cv.Read(false);

            txtCodeDescription.Text = cv.Description;
            txtValueExtended.Text = cv.ValueExtended;
            txtAbbreviation.Text = cv.Abbreviation;
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
    }
}
