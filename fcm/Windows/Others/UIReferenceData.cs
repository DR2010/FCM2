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
using MackkadoITFramework.ReferenceData;
using MackkadoITFramework.Utils;

namespace fcm.Windows
{
    public partial class UIReferenceData : Form
    {

        private string _userID;
        public DataTable dtCodeValue;
        public List<CodeType> codeTypeList;
        private CodeValue codeValue;
        private bool listForType;
        private Form _comingFromForm;

        // This constructor is invoked when a code type list is selected.
        //
        public UIReferenceData(CodeValue _codeValue) : this()
        {
            codeValue = _codeValue;

            cbxCodeType.Enabled = false;
            listForType = true;
        }


        public UIReferenceData(Form comingFromForm): this()
        {
            _comingFromForm = comingFromForm;
        }
        // This is for an open code type listed
        //
        public UIReferenceData()
        {
            InitializeComponent();

            _userID = Utils.UserID;

            //
            // Create datatable = Code Value
            //
            var FKCodeType = new DataColumn("FKCodeType", typeof(String));
            var ID = new DataColumn("ID", typeof(String));
            var Description = new DataColumn("Description", typeof(String));
            var Abbreviation = new DataColumn("Abbreviation", typeof(String));
            var ValueExtended = new DataColumn("ValueExtended", typeof(String));

            dtCodeValue = new DataTable("dtCodeValue");

            dtCodeValue.Columns.Add(FKCodeType);
            dtCodeValue.Columns.Add(ID);
            dtCodeValue.Columns.Add(Description);
            dtCodeValue.Columns.Add(Abbreviation);
            dtCodeValue.Columns.Add(ValueExtended);

            dgvCodeValue.DataSource = dtCodeValue;

            listForType = false;
            cbxCodeType.Enabled = true;

        }

        private void btnCodeTypeList_Click(object sender, EventArgs e)
        {

        }

        private void UIReferenceData_Load(object sender, EventArgs e)
        {

            LoadCodeType();


            if ((codeValue == null) || (string.IsNullOrEmpty(codeValue.FKCodeType)))
            {
                cbxCodeType.SelectedIndex = 0;
            }
            else
            {
                cbxCodeType.SelectedText = codeValue.FKCodeType;

                // Load code values
                //
                loadCodeValue(codeValue.FKCodeType);

                //for (int i = 0; i < cbxCodeType.Items.Count; i++)
                //{
                //    if (cbxCodeType.Items[i].ToString() == codeValue.FKCodeType)
                //    {
                //        cbxCodeType.SelectedItem = i;
                //        break;
                //    }
                //}
            }

            cbxCodeType.Focus();
        }

        // Load code value selected
        //
        private bool loadCodeValueSelectedInMemory()
        {
            if (dgvCodeValue.SelectedRows.Count < 1)
                return false;

            var selectedRow = dgvCodeValue.SelectedRows;

            if (codeValue == null)
            {
                codeValue = new CodeValue();
            }

            codeValue.ID = selectedRow[0].Cells["ID"].Value.ToString();
            codeValue.FKCodeType = selectedRow[0].Cells["FKCodeType"].Value.ToString();
            codeValue.Description = selectedRow[0].Cells["Description"].Value.ToString();
            codeValue.Abbreviation = selectedRow[0].Cells["Abbreviation"].Value.ToString();
            codeValue.ValueExtended = selectedRow[0].Cells["ValueExtended"].Value.ToString();

            return true;

        }


        private void LoadCodeType()
        {

            var codeType = new CodeType();
            codeType.List(HeaderInfo.Instance);

            cbxCodeType.Items.Clear();

            foreach (CodeType c in codeType.codeTypeList)
            {
                cbxCodeType.Items.Add(c.Code);
            }
            ucCodeType1.Visible = false;
            ucCodeValue1.Visible = false;

        }


        private void cbxCodeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valueSelected = cbxCodeType.SelectedItem.ToString();
            loadCodeValue(valueSelected);
        }


        //
        // List values
        //
        private void loadCodeValue( string codeType )
        {
            dtCodeValue.Clear();

            var codeList = new CodeValue();
            codeList.List( codeType );

            foreach (CodeValue code in codeList.codeValueList)
            {
                DataRow elementRow = dtCodeValue.NewRow();
                elementRow["FKCodeType"] = code.FKCodeType;
                elementRow["ID"] = code.ID;
                elementRow["Description"] = code.Description;
                elementRow["Abbreviation"] = code.Abbreviation;
                elementRow["ValueExtended"] = code.ValueExtended;

                dtCodeValue.Rows.Add(elementRow);
            }
        }

        private void btnNewType_Click(object sender, EventArgs e)
        {
            ucCodeValue1.Visible = false;
            if (ucCodeType1.Visible == true)
                ucCodeType1.Visible = false;
            else
                ucCodeType1.Visible = true;
        }


        //
        // New code value
        //
        private void btnNewCodeValue_Click(object sender, EventArgs e)
        {
            CodeValueSelected(false);
        }

        private void dgvCodeValue_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (string.IsNullOrEmpty(codeValue.FKCodeType))
            {
                CodeValueSelected(false);
            }
            else
            {
                loadCodeValueSelectedInMemory();
                this.Close();
            }
        }

        private void cbxCodeType_Enter(object sender, EventArgs e)
        {
            LoadCodeType();
        }

        //
        // 
        //
        private void CodeValueSelected(bool RefreshOnly)
        {
            ucCodeType1.Visible = false;

            if (! RefreshOnly)
            {
                if (ucCodeValue1.Visible == true)
                {
                    ucCodeValue1.Visible = false;

                    if (cbxCodeType.SelectedItem != null)
                    {
                        string valueSelected = cbxCodeType.SelectedItem.ToString();
                        loadCodeValue(valueSelected);
                    }
                    return;
                }

                ucCodeValue1.Visible = true;
            }

            if (dgvCodeValue.SelectedRows.Count <= 0)
                return;

            var selectedRow = dgvCodeValue.SelectedRows;

            if (loadCodeValueSelectedInMemory())
            {
                ucCodeValue1.SetFKCodeType(this.codeValue.FKCodeType);
                ucCodeValue1.SetCodeID(this.codeValue.ID);
                ucCodeValue1.SetCodeDescription(this.codeValue.Description);
                ucCodeValue1.SetAbbreviation(this.codeValue.Abbreviation);
                ucCodeValue1.SetValueExtended(this.codeValue.ValueExtended);
            }
        }

        private void dgvCodeValue_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CodeValueSelected(true);

        }

        private void dgvCodeValue_SelectionChanged(object sender, EventArgs e)
        {
            CodeValueSelected(true);
        }

        private void dgvCodeValue_CellBorderStyleChanged(object sender, EventArgs e)
        {

        }

        private void newCodeValueToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gbCodeType_Enter(object sender, EventArgs e)
        {

        }

        private void dgvCodeValue_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UIReferenceData_Leave(object sender, EventArgs e)
        {
            _comingFromForm.Activate();

        }

        private void UIReferenceData_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_comingFromForm != null)
            {
                _comingFromForm.Activate();
            }
        }

        private void eToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_comingFromForm != null)
            {
                this.Close();
                _comingFromForm.Activate();
            }
        }

    }
}
