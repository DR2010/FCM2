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
    public partial class UIReferenceData : Form
    {

        // private string _connectionString;
        private string _userID;
        public DataTable dtCodeValue;
        public CodeTypeList codeTypeList;

        public UIReferenceData()
        {
            InitializeComponent();

            // _connectionString = Utils.ConnectionString;
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

        }

        private void btnCodeTypeList_Click(object sender, EventArgs e)
        {

        }

        private void UIReferenceData_Load(object sender, EventArgs e)
        {

            LoadCodeType();

            cbxCodeType.SelectedIndex = 0;
            cbxCodeType.Focus();

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

            var codeList = new CodeValueList();
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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnNewType_Click(object sender, EventArgs e)
        {
            ucCodeValue1.Visible = false;
            if (ucCodeType1.Visible == true)
                ucCodeType1.Visible = false;
            else
                ucCodeType1.Visible = true;

            
        }

        private void btnCodeValueList_Click(object sender, EventArgs e)
        {

        }

        //
        // New code value
        //
        private void btnNewCodeValue_Click(object sender, EventArgs e)
        {
            CodeValueSelected(false);
        }

        private void ucCodeValue1_Load(object sender, EventArgs e)
        {

        }


        private void dgvCodeValue_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CodeValueSelected(false);
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

                    string valueSelected = cbxCodeType.SelectedItem.ToString();
                    loadCodeValue(valueSelected);

                    return;
                }

                ucCodeValue1.Visible = true;
            }

            if (dgvCodeValue.SelectedRows.Count <= 0)
                return;

            var selectedRow = dgvCodeValue.SelectedRows;

            ucCodeValue1.SetFKCodeType(
                selectedRow[0].Cells["FKCodeType"].Value.ToString());
            ucCodeValue1.SetCodeID(
                selectedRow[0].Cells["ID"].Value.ToString());
            ucCodeValue1.SetCodeDescription(
                selectedRow[0].Cells["Description"].Value.ToString());
            ucCodeValue1.SetAbbreviation(
                selectedRow[0].Cells["Abbreviation"].Value.ToString());
            ucCodeValue1.SetValueExtended(
                selectedRow[0].Cells["ValueExtended"].Value.ToString());
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
    }
}
