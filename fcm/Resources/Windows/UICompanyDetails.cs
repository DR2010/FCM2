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
    public partial class UIClientDetails : Form
    {
        // private string _connectionString;
        private string _userID;
        public DataTable elementSourceDataTable;
        public DataTable employeeSourceDataTable;

        public UIClientDetails(string userID)
        {
            InitializeComponent();
            // _connectionString = connectionString;
            _userID = userID;

            //
            // Create datatable (Client)
            //
            var UID = new DataColumn("UID", typeof(String));
            var ABN = new DataColumn("ABN", typeof(String));
            var Name = new DataColumn("Name", typeof(String));
            var Phone = new DataColumn("Phone", typeof(String));
            var Fax = new DataColumn("Fax", typeof(String));
            var EmailAddress = new DataColumn("EmailAddress", typeof(String));
            var MainContactPersonName = new DataColumn("MainContactPersonName", typeof(String));
            var Address = new DataColumn("Address", typeof(String));

            elementSourceDataTable = new DataTable("ElementSourceDataTable");

            elementSourceDataTable.Columns.Add(UID);
            elementSourceDataTable.Columns.Add(ABN);
            elementSourceDataTable.Columns.Add(Name);
            elementSourceDataTable.Columns.Add(Phone);
            elementSourceDataTable.Columns.Add(Fax);
            elementSourceDataTable.Columns.Add(EmailAddress);
            elementSourceDataTable.Columns.Add(MainContactPersonName);
            elementSourceDataTable.Columns.Add(Address);

            dgvClientList.DataSource = elementSourceDataTable;

            //
            // Create datatable (Employee)
            //

            var EmployeeUID = new DataColumn("EmployeeUID", typeof(String));
            var EmployeeRoleType = new DataColumn("EmployeeRoleType", typeof(String));
            var EmployeeRoleDescription = new DataColumn("EmployeeRoleDescription", typeof(String));
            var EmployeeName = new DataColumn("EmployeeName", typeof(String));
            var FK_CompanyUID = new DataColumn("FK_CompanyUID", typeof(String));

            employeeSourceDataTable = new DataTable("EmployeeSourceDataTable");

            employeeSourceDataTable.Columns.Add(EmployeeUID);
            employeeSourceDataTable.Columns.Add(EmployeeRoleDescription);
            employeeSourceDataTable.Columns.Add(EmployeeName);
            employeeSourceDataTable.Columns.Add(FK_CompanyUID);
            employeeSourceDataTable.Columns.Add(EmployeeRoleType);

            dgvEmployeeList.DataSource = employeeSourceDataTable;
        
        }

        // --------------------------------------------------
        //              Save click
        // --------------------------------------------------
        private void btnSave_Click(object sender, EventArgs e)
        {
            Client Client = new Client("Daniel");

            Client.Name = txtName.Text;
            Client.ABN = txtABN.Text;
            Client.Address = txtAddress.Text;
            Client.Phone = txtPhone.Text;
            Client.Fax = txtFax.Text;
            Client.EmailAddress = txtEmailAddress.Text;
            Client.Fax = txtFax.Text;
            Client.MainContactPersonName = txtContactPerson.Text;
            
            Client.insert();

            MessageBox.Show("Client Added Successfully.");

            loadClientList();
        }

        private void ClientDetails_Load(object sender, EventArgs e)
        {
            loadClientList();
        }

        //
        // List companies
        //
        private void loadClientList()
        {
            elementSourceDataTable.Clear();

            var compList = new ClientList(_userID);
            compList.List();

            foreach (Client Client in compList.clientList)
            {
                DataRow elementRow = elementSourceDataTable.NewRow();
                elementRow["UID"] = Client.UID;
                elementRow["ABN"] = Client.ABN;
                elementRow["Name"] = Client.Name;
                elementRow["Phone"] = Client.Phone;
                elementRow["Fax"] = Client.Fax;
                elementRow["EmailAddress"] = Client.EmailAddress;
                elementRow["MainContactPersonName"] = Client.MainContactPersonName;
                elementRow["Address"] = Client.Address;

                elementSourceDataTable.Rows.Add(elementRow);

            }

        }


        private void btnAddNewClient_Click(object sender, EventArgs e)
        {
            txtABN.Text = "";
            txtAddress.Text = "";
            txtContactPerson.Text = "";
            txtEmailAddress.Text = "";
            txtFax.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            txtUID.Text = "";
            
        }

        private void btnUpdateClientDetails_Click(object sender, EventArgs e)
        {

        }

        private void dgvClientList_SelectionChanged(object sender, EventArgs e)
        {
            LoadClientDetails();
        }

        private void LoadClientDetails()
        {
            if (dgvClientList.SelectedRows.Count <= 0)
                return;

            var selectedRow = dgvClientList.SelectedRows;

            txtUID.Text = selectedRow[0].Cells["UID"].Value.ToString();
            txtABN.Text = selectedRow[0].Cells["ABN"].Value.ToString();
            txtName.Text = selectedRow[0].Cells["Name"].Value.ToString();
            txtPhone.Text = selectedRow[0].Cells["Phone"].Value.ToString();
            txtFax.Text = selectedRow[0].Cells["Fax"].Value.ToString();
            txtAddress.Text = selectedRow[0].Cells["Address"].Value.ToString();
            txtContactPerson.Text = selectedRow[0].Cells["MainContactPersonName"].Value.ToString();
            txtEmailAddress.Text = selectedRow[0].Cells["EmailAddress"].Value.ToString();

            loadEmployeeList(Convert.ToInt32(txtUID.Text));

            Utils.ClientID = Convert.ToInt32(txtUID.Text);
            Utils.ClientIndex = Utils.ClientID-1;


        }

        //
        // List Employees
        //
        private void loadEmployeeList(int clientID)
        {
            employeeSourceDataTable.Clear();

            var employeeList = new EmployeeList();
            employeeList.List(clientID);

            foreach (Employee employee in employeeList.employeeList)
            {
                DataRow elementRow = employeeSourceDataTable.NewRow();
                elementRow["FK_CompanyUID"] = employee.FKCompanyUID;
                elementRow["EmployeeUID"] = employee.UID;
                elementRow["EmployeeName"] = employee.Name;
                elementRow["EmployeeRoleType"] = employee.RoleType;
                elementRow["EmployeeRoleDescription"] = employee.RoleDescription;

                employeeSourceDataTable.Rows.Add(elementRow);

            }

        }

        private void btnSaveEmployee_Click(object sender, EventArgs e)
        {

        }

        private void btnDocuments_Click(object sender, EventArgs e)
        {
            UIClientDocumentSet ucds = new UIClientDocumentSet();

            ucds.Show();
        }

        private void dgvClientList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
