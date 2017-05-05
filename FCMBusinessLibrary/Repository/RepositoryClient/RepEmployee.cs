using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FCMMySQLBusinessLibrary.FCMUtils;
using FCMMySQLBusinessLibrary.Model.ModelClient;
using MackkadoITFramework.ReferenceData;
using MackkadoITFramework.Utils;
using MackkadoITFramework.ErrorHandling;
using MySql.Data.MySqlClient;

namespace FCMMySQLBusinessLibrary.Repository.RepositoryClient
{
    public class RepEmployee : Employee
    {

        /// <summary>
        /// Database fields
        /// </summary>
        public struct FieldName
        {
            public const string FKCompanyUID = "FKCompanyUID";
            public const string UID = "UID";
            public const string Name = "Name";
            public const string RoleType = "RoleType";
            public const string RoleDescription = "RoleDescription";
            public const string Address = "Address";
            public const string Phone = "Phone";
            public const string Fax = "Fax";
            public const string EmailAddress = "EmailAddress";
            public const string IsAContact = "IsAContact";
            public const string UserIdCreatedBy = "UserIdCreatedBy";
            public const string UserIdUpdatedBy = "UserIdUpdatedBy";
            public const string CreationDateTime = "CreationDateTime";
            public const string UpdateDateTime = "UpdateDateTime";
        }

        //? Missing constructor

        /// <summary>
        /// Get Employee details
        /// </summary>
        private static string Read(int clientUID, string roleType)
        {
            Employee employee = new Employee();

            // 
            // EA SQL database
            // 
            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {
                var commandString =
                    " SELECT " +
                    EmployeeFieldsString()
                    + "  FROM Employee"
                    + " WHERE FKCompanyUID = @FKCompanyUID "
                    + "   AND RoleType = @RoleType "; 


                using (var command = new MySqlCommand(
                                            commandString, connection))
                {

                    command.Parameters.Add( "@FKCompanyUID", MySqlDbType.Int32 ).Value = clientUID;
                    command.Parameters.Add( "@RoleType", MySqlDbType.String ).Value = roleType;

                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        try
                        {
                            LoadEmployeeObject(reader, employee);

                        }
                        catch (Exception)
                        {
                            employee.UID = 0;
                        }
                    }
                }
            }

            return employee.Name;
        }

        public static ClientEmployee ReadEmployees(int clientUID)
        {
            ClientEmployee clientEmployee = new ClientEmployee();
            clientEmployee.AdministrationPerson = Read( clientUID, FCMConstant.RoleTypeCode.AdministrationPerson );
            clientEmployee.ManagingDirector = Read( clientUID, FCMConstant.RoleTypeCode.ManagingDirector );
            clientEmployee.HealthAndSafetyRep = Read( clientUID, FCMConstant.RoleTypeCode.HealthAndSafetyRep );
            clientEmployee.LeadingHand1 = Read( clientUID, FCMConstant.RoleTypeCode.LeadingHand1 );
            clientEmployee.LeadingHand2 = Read( clientUID, FCMConstant.RoleTypeCode.LeadingHand2 );
            clientEmployee.LeadingHand2 = Read( clientUID, FCMConstant.RoleTypeCode.LeadingHand2 );
            clientEmployee.OHSEAuditor = Read( clientUID, FCMConstant.RoleTypeCode.OHSEAuditor );
            clientEmployee.ProjectManager = Read( clientUID, FCMConstant.RoleTypeCode.ProjectManager );
            clientEmployee.ProjectOHSRepresentative = Read( clientUID, FCMConstant.RoleTypeCode.ProjectOHSRepresentative );
            clientEmployee.SiteManager = Read( clientUID, FCMConstant.RoleTypeCode.SiteManager );
            clientEmployee.Supervisor = Read( clientUID, FCMConstant.RoleTypeCode.Supervisor );
            clientEmployee.SystemsManager = Read( clientUID, FCMConstant.RoleTypeCode.SystemsManager );
            clientEmployee.WorkersCompensationCoordinator = Read( clientUID, FCMConstant.RoleTypeCode.WorkersCompensationCoordinator );

            return clientEmployee;

        }

        /// <summary>
        /// Retrieve last Employee UID
        /// </summary>
        /// <returns></returns>
        public int GetLastUID()
        {
            int LastUID = 0;

            // 
            // EA SQL database
            // 

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {
                var commandString = "SELECT MAX(UID) LASTUID FROM Employee ";

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        try
                        {
                            LastUID = Convert.ToInt32(reader["LASTUID"]);
                        }
                        catch (Exception)
                        {
                            LastUID = 0;
                        }
                    }
                }
            }

            return LastUID;
        }

        /// <summary>
        /// Add new Employee
        /// </summary>
        /// <returns></returns>
        public ResponseStatus Insert()
        {
            var rs = new ResponseStatus();
            rs.Message = "Client Added Successfully";
            rs.ReturnCode = 1;
            rs.ReasonCode = 1;

            int _uid = 0;

            _uid = GetLastUID() + 1;
            this.UID = _uid;

            DateTime _now = DateTime.Today;
            this.CreationDateTime = _now;
            this.UpdateDateTime = _now;

            if (Name == null)
                Name = "";

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {

                var commandString =
                (
                   "INSERT INTO Employee " +
                   "( " + 
                    EmployeeFieldsString() +
                   ")" +
                        " VALUES " +
                   "( " +
                   "  @" + FieldName.FKCompanyUID +
                   ", @" + FieldName.UID +
                   ", @" + FieldName.Name +
                   ", @" + FieldName.RoleType +
                   ", @" + FieldName.Address +
                   ", @" + FieldName.Phone +
                   ", @" + FieldName.Fax +
                   ", @" + FieldName.EmailAddress +
                   ", @" + FieldName.IsAContact +
                   ", @" + FieldName.UserIdCreatedBy +
                   ", @" + FieldName.UserIdUpdatedBy +
                   ", @" + FieldName.CreationDateTime +
                   ", @" + FieldName.UpdateDateTime +
                   " )"
                   );

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {
                    AddSQLParameters(command, "CREATE");

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            return rs;
        }

        /// <summary>
        /// Update Employee Details
        /// </summary>
        /// <returns></returns>
        public ResponseStatus Update()
        {
            ResponseStatus ret = new ResponseStatus();      
            ret.Message = "Item updated successfully";

            if (Name == null)
                Name = "";

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {

                var commandString =
                (
                   "UPDATE Employee " +
                   " SET  " +
                   FieldName.Name + " = @" + FieldName.Name + ", " +
                   FieldName.RoleType + " = @" + FieldName.RoleType + ", " +
                   FieldName.Fax + " = @" + FieldName.Fax + ", " +
                   FieldName.Address + " = @" + FieldName.Address + ", " +
                   FieldName.EmailAddress + " = @" + FieldName.EmailAddress + ", " +
                   FieldName.IsAContact + " = @" + FieldName.IsAContact + ", " +
                   FieldName.Phone + " = @" + FieldName.Phone + ", " +
                   FieldName.UpdateDateTime + " = @" + FieldName.UpdateDateTime + ", " +
                   FieldName.UserIdUpdatedBy + " = @" + FieldName.UserIdUpdatedBy +
                   "   WHERE    UID = @UID "
                );

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {

                    AddSQLParameters(command, "UPDATE");

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            return ret;
        }

        /// <summary>
        /// Delete Employee 
        /// </summary>
        /// <returns></returns>
        public ResponseStatus Delete()
        {

            var ret = new ResponseStatus();
            ret.Message = "Employee Deleted successfully";

            if (Name == null)
                Name = "";

            using (var connection = new MySqlConnection( ConnString.ConnectionString ))
            {

                var commandString =
                (
                   "DELETE FROM Employee " +
                   "   WHERE UID = @UID "
                );



                using (var command = new MySqlCommand(
                                            commandString, connection ))
                {
                    command.Parameters.Add( "@UID", MySqlDbType.Int32 ).Value = UID;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            return ret;
        }

        /// <summary>
        /// List employees
        /// </summary>
        /// <param name="clientID"></param>
        public static List<Employee> List( int clientID )
        {
            List<Employee> employeeList = new List<Employee>();

            using (var connection = new MySqlConnection( ConnString.ConnectionString ))
            {

                var commandString = string.Format(
                " SELECT " +
                EmployeeFieldsString() +
                "   FROM Employee " +
                "   WHERE  FKCompanyUID = {0}",
                clientID );

                using (var command = new MySqlCommand(
                                      commandString, connection ))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Employee _employee = new Employee();
                            LoadEmployeeObject(reader, _employee);

                            employeeList.Add( _employee );
                        }
                    }
                }
            }

            return employeeList;
        }

        public static string EmployeeFieldsString()
        {
            return (
                        FieldName.FKCompanyUID
                + "," + FieldName.UID
                + "," + FieldName.Name
                + "," + FieldName.RoleType
                + "," + FieldName.Address
                + "," + FieldName.Phone
                + "," + FieldName.Fax
                + "," + FieldName.EmailAddress
                + "," + FieldName.IsAContact
                + "," + FieldName.UserIdUpdatedBy
                + "," + FieldName.UserIdCreatedBy
                + "," + FieldName.CreationDateTime
                + "," + FieldName.UpdateDateTime
                );

        }

        /// <summary>
        /// Add Employee parameters to the SQL Command.
        /// </summary>
        /// <param name="command"></param>
        private void AddSQLParameters(MySqlCommand command, string action)
        {
            command.Parameters.Add(FieldName.FKCompanyUID, MySqlDbType.Int32).Value = FKCompanyUID;
            command.Parameters.Add(FieldName.UID, MySqlDbType.Int32).Value = UID;
            command.Parameters.Add(FieldName.Name, MySqlDbType.VarChar).Value = Name;
            command.Parameters.Add(FieldName.RoleType, MySqlDbType.VarChar).Value = RoleType;
            command.Parameters.Add(FieldName.Address, MySqlDbType.VarChar).Value = Address;
            command.Parameters.Add(FieldName.Phone, MySqlDbType.VarChar).Value = Phone;
            command.Parameters.Add(FieldName.Fax, MySqlDbType.VarChar).Value = Fax;
            command.Parameters.Add(FieldName.EmailAddress, MySqlDbType.VarChar).Value = EmailAddress;
            command.Parameters.Add(FieldName.IsAContact, MySqlDbType.VarChar).Value = IsAContact;
            command.Parameters.Add(FieldName.UserIdUpdatedBy, MySqlDbType.VarChar).Value = UserIdUpdatedBy;
            command.Parameters.Add(FieldName.UpdateDateTime, MySqlDbType.DateTime).Value = UpdateDateTime;

            if (action == "CREATE")
            {
                command.Parameters.Add(FieldName.UserIdCreatedBy, MySqlDbType.VarChar).Value = UserIdCreatedBy;
                command.Parameters.Add(FieldName.CreationDateTime, MySqlDbType.DateTime).Value = CreationDateTime;
            }

        }
        
        /// <summary>
        /// This method loads the information from the sqlreader into the Employee object
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="employee"></param>
        private static void LoadEmployeeObject(MySqlDataReader reader, Employee employee)
        {
            employee.FKCompanyUID = Convert.ToInt32(reader[FieldName.FKCompanyUID]);
            employee.UID = Convert.ToInt32(reader[FieldName.UID].ToString());
            employee.Name = reader[FieldName.Name].ToString();
            employee.RoleType = reader[FieldName.RoleType].ToString();
            employee.Address = reader[FieldName.Address].ToString();
            employee.Phone = reader[FieldName.Phone].ToString();
            employee.Fax = reader[FieldName.Fax].ToString();
            employee.UserIdCreatedBy = reader[FieldName.UserIdCreatedBy].ToString();
            employee.UserIdUpdatedBy = reader[FieldName.UserIdCreatedBy].ToString();
            employee.RoleDescription = CodeValue.GetCodeValueDescription(MakConstant.CodeTypeString.RoleType, employee.RoleType);

            try  { employee.IsAContact = Convert.ToChar(reader[FieldName.IsAContact].ToString()); }
            catch { employee.IsAContact = 'N'; }
            try { employee.EmailAddress = reader[FieldName.EmailAddress].ToString(); }
            catch { employee.EmailAddress = ""; }
            try
            {
                employee.UpdateDateTime = Convert.ToDateTime(reader[FieldName.UpdateDateTime].ToString());
            }
            catch
            {
                employee.UpdateDateTime = DateTime.Now;
            }
            try
            {
                employee.CreationDateTime = Convert.ToDateTime(reader[FieldName.CreationDateTime].ToString());
            }
            catch
            {
                employee.CreationDateTime = DateTime.Now;
            }

        }

    }
}
