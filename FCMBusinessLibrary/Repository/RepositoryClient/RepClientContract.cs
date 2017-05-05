using System;
using System.Collections.Generic;
using System.Data;
using MackkadoITFramework.ErrorHandling;
using MackkadoITFramework.Utils;
using MySql.Data.MySqlClient;
using ConnString = MackkadoITFramework.Utils.ConnString;
using FCMMySQLBusinessLibrary.Model.ModelClient;

namespace FCMMySQLBusinessLibrary.Repository.RepositoryClient
{
    internal class RepClientContract: ClientContract
    {
        
        // var student1 = new Student{firstName = "Bruce", lastName = "Willis"};

        /// <summary>
        /// Get Employee details
        /// </summary>
        internal static ClientContract Read(int clientContractUID)
        {
            // 
            // EA SQL database
            // 

            ClientContract clientContract = new ClientContract();

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {
                var commandString =
                " SELECT " +
                ClientContractFieldsString()
                + "  FROM ClientContract" +
                " WHERE UID = @UID";

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {
                    connection.Open();

                    command.Parameters.Add("@UID", MySqlDbType.Int32).Value = clientContractUID;

                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        try
                        {
                            LoadClientContractObject(reader, clientContract);

                        }
                        catch (Exception)
                        {
                            clientContract.UID = 0;
                        }
                    }
                }
            }

            return clientContract;
        }

        /// <summary>
        /// List client contracts
        /// </summary>
        /// <param name="clientID"></param>
        internal static List<ClientContract> List(int clientID)
        {
            List<ClientContract> clientContractList = new List<ClientContract>();

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {

                var commandString = string.Format(
                " SELECT " +
                ClientContractFieldsString() +
                "   FROM ClientContract " +
                "   WHERE  FKCompanyUID = {0}",
                clientID);

                using (var command = new MySqlCommand(
                                      commandString, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ClientContract _clientContract = new ClientContract();
                            LoadClientContractObject(reader, _clientContract);

                            clientContractList.Add(_clientContract);
                        }
                    }
                }
            }

            return clientContractList;
        }

        // -----------------------------------------------------
        //          Retrieve last Contract UID
        // -----------------------------------------------------
        private static int GetLastUID()
        {
            int LastUID = 0;

            // 
            // EA SQL database
            // 

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {
                var commandString = "SELECT MAX(UID) LASTUID FROM ClientContract ";

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
        /// Add new contract
        /// </summary>
        /// <returns></returns>
        public static ResponseStatus Insert(
            HeaderInfo headerInfo, 
            ClientContract clientContract)
        {
            var rs = new ResponseStatus();
            rs.Message = "Client Contract Added Successfully";
            rs.ReturnCode = 1;
            rs.ReasonCode = 1;

            int _uid = 0;

            _uid = GetLastUID() + 1;
            clientContract.UID = _uid;

            DateTime _now = DateTime.Today;
            clientContract.CreationDateTime = _now;
            clientContract.UpdateDateTime = _now;

            if (clientContract.ExternalID == null)
                clientContract.ExternalID = "";

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {

                var commandString =
                (
                   "INSERT INTO ClientContract " +
                   "( " +
                    ClientContractFieldsString() +
                   ")" +
                        " VALUES " +
                   "( " +
                   "  @" + FCMDBFieldName.ClientContract.FKCompanyUID +
                   ", @" + FCMDBFieldName.ClientContract.UID +
                   ", @" + FCMDBFieldName.ClientContract.ExternalID +
                   ", @" + FCMDBFieldName.ClientContract.Status +
                   ", @" + FCMDBFieldName.ClientContract.Type +
                   ", @" + FCMDBFieldName.ClientContract.StartDate +
                   ", @" + FCMDBFieldName.ClientContract.EndDate +
                   ", @" + FCMDBFieldName.ClientContract.UserIdCreatedBy +
                   ", @" + FCMDBFieldName.ClientContract.UserIdUpdatedBy +
                   ", @" + FCMDBFieldName.ClientContract.CreationDateTime +
                   ", @" + FCMDBFieldName.ClientContract.UpdateDateTime +
                   " )"
                   );

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {
                    AddSQLParameters(command, clientContract, headerInfo);
                    command.Parameters.Add(FCMDBFieldName.ClientContract.CreationDateTime, MySqlDbType.DateTime).Value = headerInfo.CurrentDateTime;
                    command.Parameters.Add(FCMDBFieldName.ClientContract.UserIdCreatedBy, MySqlDbType.VarChar).Value = headerInfo.UserID;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            return rs;
        }

        /// <summary>
        /// Update Contract
        /// </summary>
        /// <returns></returns>
        public static ResponseStatus Update(
            HeaderInfo headerInfo,
            ClientContract clientContract )
        {
            ResponseStatus ret = new ResponseStatus();
            ret.Message = "Item updated successfully";

            if (clientContract.ExternalID == null)
                clientContract.ExternalID = "";

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {

                var commandString =
                (
                   "UPDATE ClientContract " +
                   " SET  " +
                   FCMDBFieldName.ClientContract.ExternalID + " = @" + FCMDBFieldName.ClientContract.ExternalID + ", " +
                   FCMDBFieldName.ClientContract.UpdateDateTime + " = @" + FCMDBFieldName.ClientContract.UpdateDateTime + ", " +
                   FCMDBFieldName.ClientContract.Type + " = @" + FCMDBFieldName.ClientContract.Type + ", " +
                   FCMDBFieldName.ClientContract.UserIdUpdatedBy + " = @" + FCMDBFieldName.ClientContract.UserIdUpdatedBy + ", " +
                   FCMDBFieldName.ClientContract.Status + " = @" + FCMDBFieldName.ClientContract.Status +
                   "   WHERE    UID = @UID "
                );

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {

                    AddSQLParameters(command, clientContract, headerInfo);

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
        public static ResponseStatus Delete(
            HeaderInfo headerInfo,
            ClientContract clientContract)
        {

            var ret = new ResponseStatus();
            ret.Message = "Employee Deleted successfully";

            if (clientContract.ExternalID == null)
                clientContract.ExternalID = "";

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {

                var commandString =
                (
                   "DELETE ClientContract " +
                   "   WHERE    UID = @UID "
                );

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {
                    command.Parameters.Add("@UID", MySqlDbType.VarChar).Value = clientContract.UID;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            return ret;
        }

        /// <summary>
        /// Add Employee parameters to the SQL Command.
        /// </summary>
        /// <param name="command"></param>
        private static void AddSQLParameters(MySqlCommand command, ClientContract clientContract, HeaderInfo headerInfo)
        {
            command.Parameters.Add(FCMDBFieldName.ClientContract.FKCompanyUID, MySqlDbType.Int32).Value = clientContract.FKCompanyUID;
            command.Parameters.Add(FCMDBFieldName.ClientContract.UID, MySqlDbType.Int32).Value = clientContract.UID;
            command.Parameters.Add(FCMDBFieldName.ClientContract.ExternalID, MySqlDbType.VarChar).Value = clientContract.ExternalID;
            command.Parameters.Add(FCMDBFieldName.ClientContract.Status, MySqlDbType.VarChar).Value = clientContract.Status;
            command.Parameters.Add(FCMDBFieldName.ClientContract.Type, MySqlDbType.VarChar).Value = clientContract.Type;
            command.Parameters.Add(FCMDBFieldName.ClientContract.StartDate, MySqlDbType.DateTime).Value = clientContract.StartDate;
            command.Parameters.Add(FCMDBFieldName.ClientContract.EndDate, MySqlDbType.DateTime).Value = clientContract.EndDate;
            command.Parameters.Add(FCMDBFieldName.ClientContract.UserIdUpdatedBy, MySqlDbType.VarChar).Value = headerInfo.UserID;
            command.Parameters.Add(FCMDBFieldName.ClientContract.UpdateDateTime, MySqlDbType.DateTime).Value = headerInfo.CurrentDateTime;

        }


        private static string ClientContractFieldsString()
        {
            return (
                        FCMDBFieldName.ClientContract.FKCompanyUID
                + "," + FCMDBFieldName.ClientContract.UID
                + "," + FCMDBFieldName.ClientContract.ExternalID
                + "," + FCMDBFieldName.ClientContract.Status
                + "," + FCMDBFieldName.ClientContract.Type
                + "," + FCMDBFieldName.ClientContract.StartDate
                + "," + FCMDBFieldName.ClientContract.EndDate
                + "," + FCMDBFieldName.ClientContract.UserIdUpdatedBy
                + "," + FCMDBFieldName.ClientContract.UserIdCreatedBy
                + "," + FCMDBFieldName.ClientContract.CreationDateTime
                + "," + FCMDBFieldName.ClientContract.UpdateDateTime
                );

        }

        /// <summary>
        /// This method loads the information from the sqlreader into the Employee object
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="clientContract"> </param>
        private static void LoadClientContractObject(MySqlDataReader reader, ClientContract clientContract)
        {
            clientContract.FKCompanyUID = Convert.ToInt32(reader[FCMDBFieldName.ClientContract.FKCompanyUID]);
            clientContract.UID = Convert.ToInt32(reader[FCMDBFieldName.ClientContract.UID].ToString());
            clientContract.ExternalID = reader[FCMDBFieldName.ClientContract.ExternalID].ToString();
            try { clientContract.Status = reader[FCMDBFieldName.ClientContract.Status].ToString(); }
            catch { clientContract.Status = "ACTIVE"; }
            try { clientContract.Type = reader[FCMDBFieldName.ClientContract.Type].ToString(); }
            catch { clientContract.Type = "BASIC"; }
            try { clientContract.StartDate = Convert.ToDateTime(reader[FCMDBFieldName.ClientContract.StartDate].ToString()); }
            catch { clientContract.StartDate = DateTime.Now; }
            try { clientContract.EndDate = Convert.ToDateTime(reader[FCMDBFieldName.ClientContract.EndDate].ToString()); }
            catch { clientContract.EndDate = DateTime.Now; }

            clientContract.UserIdCreatedBy = reader[FCMDBFieldName.ClientContract.UserIdCreatedBy].ToString();
            clientContract.UserIdUpdatedBy = reader[FCMDBFieldName.ClientContract.UserIdUpdatedBy].ToString();

            try { clientContract.UpdateDateTime = Convert.ToDateTime(reader[FCMDBFieldName.ClientContract.UpdateDateTime].ToString()); }
            catch { clientContract.UpdateDateTime = DateTime.Now; }
            try { clientContract.CreationDateTime = Convert.ToDateTime(reader[FCMDBFieldName.ClientContract.CreationDateTime].ToString()); }
            catch { clientContract.CreationDateTime = DateTime.Now; }
        
        }

        public static ResponseStatus GetValidContractOnDate(int clientID, DateTime date)
        {
            ResponseStatus ret = new ResponseStatus();

            ret.Message = "Valid contract not found.";
            ret.ReturnCode = 0001;
            ret.ReasonCode = 0002;
            ret.UniqueCode = ResponseStatus.MessageCode.Warning.FCMWAR00000002;

            ClientContract clientContract = new ClientContract();

            string dateString = date.ToString().Substring(0, 10);

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {

                var commandString =
                " SELECT " +
                ClientContractFieldsString() +
                "   FROM ClientContract " +
                "   WHERE  FKCompanyUID  = @FKCompanyUID " +
                "     AND  StartDate    <= @StartDate    " +
                "     AND  EndDate      >= @EndDate      ";

                using (var command = new MySqlCommand(commandString, connection))
                {

                    command.Parameters.Add("@FKCompanyUID", MySqlDbType.Int32).Value = clientID;
                    command.Parameters.Add("@StartDate", MySqlDbType.DateTime).Value = date;
                    command.Parameters.Add("@EndDate", MySqlDbType.DateTime).Value = date;

                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ClientContract _clientContract = new ClientContract();
                            LoadClientContractObject(reader, _clientContract);

                            clientContract = _clientContract;

                            ret.Message = "Valid contract found.";
                            ret.ReturnCode = 0001;
                            ret.ReasonCode = 0001;
                            ret.XMessageType = MessageType.Informational;
                            ret.UniqueCode = ResponseStatus.MessageCode.Informational.FCMINF00000001;

                            break;
                        }
                    }
                }
            }

            ret.Contents = clientContract;

            return ret;
        }


    }
}

