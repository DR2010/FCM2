using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FCMMySQLBusinessLibrary;
using FCMMySQLBusinessLibrary.Model.ModelClient;
using FCMMySQLBusinessLibrary.FCMUtils;
using MackkadoITFramework.ErrorHandling;
using MackkadoITFramework.ReferenceData;


namespace fcm.Windows
{
    public partial class UIClientEmployee : Form, IEmployee
    {


        public Employee SelectedEmployee;

        // ---------------------------------------
        // 2) Event declaration
        // ---------------------------------------
        public event EventHandler<EventArgs> EmployeeList;
        public event EventHandler<EventArgs> EmployeeAdd;
        public event EventHandler<EventArgs> EmployeeUpdate;
        public event EventHandler<EventArgs> EmployeeDelete;

        public ClientContract clientContract { set; get; } 
        public Employee employee { set; get; }

        public List<Employee> employeeList { get; set; }
        public List<ClientContract> clientContractList { get; set; }
        public ResponseStatus response { get; set; }
        private Client client;

        /// <summary>
        /// Constructor
        /// </summary>
        public UIClientEmployee(Client iclient)
        {
            InitializeComponent();

            client = iclient;

            // ---------------------------------------
            // 1) Create an instance of the controller
            // ---------------------------------------
            new ControllerEmployee(this);

            employee = new Employee();
            SelectedEmployee = new Employee();
            employeeList = new List<Employee>();
            clientContract = new ClientContract();

            txtClientName.Text = client.UID + " " + client.Name;

        }

        /// <summary>
        /// Form load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UIClientEmployee_Load(object sender, EventArgs e)
        {
            var empRoleType = new CodeValue();
            empRoleType.ListInCombo(true, "ROLETYPE", cbxEmployeeRoleType);

            ListEmployee();
        }


        // ---------------------------------------
        // 4) UI Events
        // ---------------------------------------
        private void btnSaveEmployee_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmployeeUID.Text))
            {
                AddEmployee();
            }
            else
            {
                UpdateEmployee();
            }

            if (response.ReturnCode == 1 && response.ReasonCode == 1)
            {
                // Reset screen
                //
                ResetScreen();
            }

            ListEmployee();

        }

        /// <summary>
        /// Reset screen (IEmployee interface)
        /// </summary>
        public void ResetScreen()
        {
            txtEmployeeUID.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtEmployeeName.Text = "";
            txtFax.Text = "";
            txtPhone.Text = "";

            this.txtEmployeeName.Focus();

        }

        /// <summary>
        /// Save employee details
        /// </summary>
        private void AddEmployee()
        {
            if (EmployeeAdd == null)
                return;

            // Set variable details
            //
            employee.FKCompanyUID = Utils.ClientID;
            employee.Name = txtEmployeeName.Text;
            employee.Address = txtAddress.Text;
            employee.EmailAddress = txtEmail.Text;
            employee.Phone = txtPhone.Text;
            employee.Fax = txtFax.Text;
            employee.IsAContact = checkIsContact.Checked ? 'Y' : 'N';
            string[] roleType = cbxEmployeeRoleType.Text.Split(';');
            employee.RoleType = roleType[0];

            EmployeeAdd(this, EventArgs.Empty);
            return;
        }

        /// <summary>
        /// Save employee details
        /// </summary>
        private void UpdateEmployee()
        {
            if (EmployeeUpdate == null)
                return;

            // Set variable details
            //
            employee.UID = Convert.ToInt32( txtEmployeeUID.Text );
            employee.FKCompanyUID = Utils.ClientID;
            employee.Name = txtEmployeeName.Text;
            employee.Address = txtAddress.Text;
            employee.EmailAddress = txtEmail.Text;
            employee.Phone = txtPhone.Text;
            employee.Fax = txtFax.Text;
            employee.IsAContact = checkIsContact.Checked ? 'Y' : 'N';
            string[] roleType = cbxEmployeeRoleType.Text.Split(';');
            employee.RoleType = roleType[0];
            employee.UpdateDateTime = DateTime.Now;

            employee.CreationDateTime = SelectedEmployee.CreationDateTime;
            employee.UserIdCreatedBy = SelectedEmployee.UserIdCreatedBy;
            employee.UserIdUpdatedBy = SelectedEmployee.UserIdUpdatedBy;

            EmployeeUpdate(this, EventArgs.Empty);

            return;
        }

        private void btnEmployeeDelete_Click(object sender, EventArgs e)
        {
            if (EmployeeDelete == null)
                return;

            if (string.IsNullOrEmpty(txtEmployeeUID.Text))
            {
                MessageBox.Show("Employee must be selected first.");
                return;
            }

            Employee employeeNew = new Employee();
            employeeNew.UID = Convert.ToInt32(txtEmployeeUID.Text);

            EmployeeDelete(this, EventArgs.Empty);
            ListEmployee();
        }
        /// <summary>
        /// List employees
        /// </summary>
        private void ListEmployee()
        {
            if (EmployeeUpdate == null)
                return;

            employee.FKCompanyUID = Utils.ClientID;

            EmployeeList(this, EventArgs.Empty);

            try
            {
                employeeBindingSource.DataSource = employeeList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("P2 " + ex.ToString());
            }
            return;
        }

        public void DisplayMessage(string message)
        {
            MessageBox.Show(message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvEmployeeList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEmployeeList.SelectedRows.Count <= 0)
                return;

            var selectedRow = dgvEmployeeList.SelectedRows;

            txtEmployeeUID.Text = selectedRow[0].Cells["dgv"+Employee.FieldName.UID].Value.ToString();
            cbxEmployeeRoleType.Text = selectedRow[0].Cells["dgv" + Employee.FieldName.RoleType].Value.ToString() + ";" +
                                       selectedRow[0].Cells["dgv" + Employee.FieldName.RoleDescription].Value.ToString();
            txtEmployeeName.Text = selectedRow[0].Cells["dgv" + Employee.FieldName.Name].Value.ToString();
            txtEmail.Text = selectedRow[0].Cells["dgv" + Employee.FieldName.EmailAddress].Value.ToString();
            txtAddress.Text = selectedRow[0].Cells["dgv" + Employee.FieldName.Address].Value.ToString();
            txtPhone.Text = selectedRow[0].Cells["dgv" + Employee.FieldName.Phone].Value.ToString();
            txtFax.Text = selectedRow[0].Cells["dgv" + Employee.FieldName.Fax].Value.ToString();

            cbxEmployeeRoleType.Text = selectedRow[0].Cells["dgv" + Employee.FieldName.RoleType].Value.ToString() + ";" +
                selectedRow[0].Cells["dgv" + Employee.FieldName.RoleDescription].Value.ToString();

            // checkIsContact.Checked ? 'Y' : 'N';
            checkIsContact.Checked = false;
            if (Convert.ToChar(selectedRow[0].Cells["dgv" + Employee.FieldName.IsAContact].Value) == 'Y')
                checkIsContact.Checked = true;

        }

        private void btnNewEmployee_Click(object sender, EventArgs e)
        {
            ResetScreen();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetScreen();

        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
