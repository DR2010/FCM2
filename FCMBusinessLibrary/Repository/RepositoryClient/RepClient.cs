using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using System.Transactions;
using FCMMySQLBusinessLibrary.FCMUtils;
using FCMMySQLBusinessLibrary.Model.ModelDocument;
using FCMMySQLBusinessLibrary.Service.SVCClient.Contract;
using FCMMySQLBusinessLibrary.Service.SVCClient.ServiceContract;
using MackkadoITFramework.Utils;
using MySql.Data.MySqlClient;
using MackkadoITFramework.ErrorHandling;
using FCMUtils = FCMMySQLBusinessLibrary.FCMUtils.Utils;
using FCMMySQLBusinessLibrary.Model.ModelClient;

namespace FCMMySQLBusinessLibrary.Repository.RepositoryClient
{

    public class RepClient : Client
    {

        public RepClient(HeaderInfo headerInfo)
        {
                _headerInfo = headerInfo;
        }

        public RepClient()
        {
        }

        // -----------------------------------------------------
        //    Get Client details
        // -----------------------------------------------------
        public ResponseStatus Read()
        {

            // 
            // EA SQL database
            // 

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {
                var commandString =
                " SELECT " + 
                ClientFieldString() +
                "  FROM Client" +
                " WHERE UID = @UID";

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {
                    command.Parameters.Add("@UID", MySqlDbType.Int32).Value = UID;

                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        try
                        {
                            LoadClientObject(reader, this);
                        }
                        catch (Exception)
                        {
                            UID = 0;
                        }
                    }
                }
            }

            return new ResponseStatus();
        }

        // -----------------------------------------------------
        //    Get Client details
        // -----------------------------------------------------
        public static ClientReadResponse Read(int iUID)
        {

            // 
            // EA SQL database
            // 

            ClientReadResponse crr = new ClientReadResponse();
            crr.responseStatus = new ResponseStatus();
            crr.client = new Client();

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {
                var commandString =
                " SELECT " +
                ClientFieldString() +
                "  FROM Client" +
                " WHERE UID = @UID";

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {
                    command.Parameters.Add("@UID", MySqlDbType.Int32).Value = iUID;

                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        try
                        {
                            LoadClientObject(reader, crr.client);
                        }
                        catch (Exception)
                        {
                            crr.client.UID = 0;
                        }
                    }
                }
            }

            return crr;
        }

        /// <summary>
        /// Check if user is already connected to a client
        /// </summary>
        /// <returns></returns>
        internal ResponseStatus ReadLinkedUser()
        {

            var response = new ResponseStatus();

            // 
            // EA SQL database
            // 

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {
                var commandString =
                " SELECT " +
                ClientFieldString() +
                "  FROM Client" +
                " WHERE FKUserID = @FKUserID ";

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {
                    command.Parameters.Add("@FKUserID", MySqlDbType.String).Value = FKUserID;

                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        try
                        {
                            int cliendUIDRead = Convert.ToInt32(reader[FCMDBFieldName.Client.UID]);
                            // If client uid read is the same as user id passed in
                            // no issues
                            if (cliendUIDRead == this.UID)
                            {
                                // User ID is already connect to a client.
                                // User is connected to client supplied
                                //
                                response.ReturnCode = 0001;
                                response.ReasonCode = 0003;
                                response.Message = "User is linked to client supplied.";
                            }
                            else
                            {
                                // User ID is already connect to a client.
                                // User is NOT connected to client supplied
                                //
                                response.ReturnCode = 0001;
                                response.ReasonCode = 0001;
                                response.Message = "User is linked to a different client.";
                            }
                            LoadClientObject(reader, this);
                        }
                        catch (Exception)
                        {
                            UID = 0;
                            response.ReturnCode = -0010;
                            response.ReasonCode = 0001;
                            response.Message = "Error retrieving client.";
                        }
                    }
                    else
                    {
                        UID = 0;
                        response.ReturnCode = 0001;
                        response.ReasonCode = 0010;
                        response.Message = "User ID is not linked to a Client.";
                    }
                }

            }

            return response;
        }

        /// <summary>
        /// Check if user is already connected to a client
        /// </summary>
        /// <returns></returns>
        public static ResponseStatus ReadLinkedUser(Client client)
        {

            var response = new ResponseStatus();

            // 
            // EA SQL database
            // 

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {
                var commandString =
                " SELECT " +
                ClientFieldString() +
                "  FROM Client" +
                " WHERE FKUserID = @FKUserID ";

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {
                    command.Parameters.Add("@FKUserID", MySqlDbType.String).Value = client.FKUserID;

                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        try
                        {
                            int cliendUIDRead = Convert.ToInt32(reader[FCMDBFieldName.Client.UID]);
                            // If client uid read is the same as user id passed in
                            // no issues
                            if (cliendUIDRead == client.UID)
                            {
                                // User ID is already connect to a client.
                                // User is connected to client supplied
                                //
                                response.ReturnCode = 0001;
                                response.ReasonCode = 0003;
                                response.Message = "User is linked to client supplied.";
                            }
                            else
                            {
                                // User ID is already connect to a client.
                                // User is NOT connected to client supplied
                                //
                                response.ReturnCode = 0001;
                                response.ReasonCode = 0001;
                                response.Message = "User is linked to a different client.";
                            }
                            LoadClientObject(reader, client);
                        }
                        catch (Exception)
                        {
                            client.UID = 0;
                            response.ReturnCode = -0010;
                            response.ReasonCode = 0001;
                            response.Message = "Error retrieving client.";
                        }
                    }
                    else
                    {
                        client.UID = 0;
                        response.ReturnCode = 0001;
                        response.ReasonCode = 0010;
                        response.Message = "User ID is not linked to a Client.";
                    }
                }

            }

            return response;
        }


        /// <summary>
        /// Check if user is already connected to a client
        /// </summary>
        /// <returns></returns>
        public static int ReadLinkedClient( string userID )
        {

            int clientUID = 0;

            // 
            // EA SQL database
            // 

            using ( var connection = new MySqlConnection( ConnString.ConnectionString ) )
            {
                var commandString =
                " SELECT " +
                ClientFieldString() +
                "  FROM Client" +
                " WHERE FKUserID = @FKUserID ";

                using ( var command = new MySqlCommand(
                                            commandString, connection ) )
                {
                    command.Parameters.Add( "@FKUserID", MySqlDbType.String ).Value = userID;

                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    if ( reader.Read() )
                    {
                        try
                        {
                            clientUID = Convert.ToInt32( reader [FCMDBFieldName.Client.UID] );
                            // If client uid read is the same as user id passed in
                            // no issues
                        }
                        catch ( Exception )
                        {
                        }
                    }
                }
            }

            return clientUID;
        }



        /// <summary>
        /// Retrieve client's field information
        /// </summary>
        /// <param name="field">Field name - use Client.FieldName</param>
        /// <param name="clientUID"></param>
        /// <returns></returns>
        internal static ReadFieldResponse ReadFieldClient(ReadFieldRequest readFieldRequest)
        {
            var ret = "";
            // 
            // EA SQL database
            // 

            ReadFieldResponse rfr = new ReadFieldResponse();

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {
                const string commandString = " SELECT @field FROM Client " +
                                             " WHERE UID = @clientUID ";

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {

                    command.Parameters.AddWithValue("@field", readFieldRequest.field);
                    command.Parameters.AddWithValue("@clientUID", readFieldRequest.clientUID);

                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        try
                        {
                            ret = reader[readFieldRequest.field].ToString();
                        }
                        catch (Exception)
                        {
                            rfr.responseStatus.Message = "Error retrieving data. (ReadFieldClient) " + commandString;
                        }
                    }
                }
            }
            return rfr;

        }

        /// <summary>
        /// Retrieve client's field information
        /// </summary>
        /// <param name="field">Field name - use Client.FieldName</param>
        /// <param name="clientUID"></param>
        /// <returns></returns>
        internal static string GetClientName( int clientUID )
        {
            var ret = "";
            // 
            // EA SQL database
            // 

            using ( var connection = new MySqlConnection( ConnString.ConnectionString ) )
            {
                const string commandString = " SELECT NAME FROM Client " +
                                             " WHERE UID = @clientUID ";

                using ( var command = new MySqlCommand(
                                            commandString, connection ) )
                {

                    command.Parameters.AddWithValue( "@clientUID", clientUID );

                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    if ( reader.Read() )
                    {
                        try
                        {
                            ret = reader ["NAME"].ToString();
                        }
                        catch ( Exception )
                        {
                        }
                    }
                }
            }
            return ret;

        }



        //// -----------------------------------------------------
        ////    Get Client details
        //// -----------------------------------------------------
        //public ResponseStatus Read(int iUID)
        //{
        //    var response = new ResponseStatus();

        //    var retClient = new Client( _headerInfo );

        //    // 
        //    // EA SQL database
        //    // 

        //    using (var connection = new MySqlConnection(ConnString.ConnectionString))
        //    {
        //        var commandString =
        //        " SELECT " +
        //        ClientFieldString() +
        //        "  FROM Client" +
        //        " WHERE UID = @UID " ;

        //        using (var command = new MySqlCommand(
        //                                    commandString, connection))
        //        {

        //            command.Parameters.Add("@UID", MySqlDbType.Int32).Value = UID;

        //            connection.Open();
        //            MySqlDataReader reader = command.ExecuteReader();

        //            if (reader.Read())
        //            {
        //                try
        //                {
        //                    LoadClientObject(reader, retClient);
        //                }
        //                catch (Exception)
        //                {
        //                    UID = 0;
        //                }
        //            }
        //        }

        //    }

        //    response.Contents = retClient;
        //    return response;
        //}

        /// <summary>
        /// Add new Client
        /// </summary>
        /// <returns></returns>
        public static ResponseStatus Insert(HeaderInfo headerInfo, Client client, MySqlConnection connection = null )
        {

            var response = new ResponseStatus();
            response.ReturnCode = 1;
            response.ReasonCode = 1;
            response.Message = "Client Added Successfully";


            int uid = 0;

            int nextUID = GetLastUID() + 1; // 2010100000

            if (nextUID == 1)
            {
                nextUID = DateTime.Now.Year * 100000 + 1;
            }

            uid =  DateTime.Now.Year * 100000 + ( Convert.ToInt32( nextUID.ToString(CultureInfo.InvariantCulture).Substring(4,5) ) );

            client.UID = uid;

            client.RecordVersion = 1;

            if (String.IsNullOrEmpty(client.Name))
            {
                response.ReturnCode = -10;
                response.ReasonCode = 1;
                 response.Message = "Error: Client Name is Mandatory.";
                return response;
            }
            if (client.Address == null)
                client.Address = "";

            if (client.MainContactPersonName == null)
                client.MainContactPersonName = "";

//            using (var connection = new MySqlConnection(ConnString.ConnectionString))

            if (connection == null)
            {
                connection = new MySqlConnection(ConnString.ConnectionString);
                connection.Open();
            }

            var commandString = 
            (
                "INSERT INTO Client " +
                "(" +
                ClientFieldString() +
                ")" +
                    " VALUES " +
                ClientFieldValue()

                ); 

            using (var command = new MySqlCommand(
                                            commandString, connection))
                {
                    client.RecordVersion = 1;
                    AddSqlParameters(command, MackkadoITFramework.Helper.Utils.SQLAction.CREATE, headerInfo, client);

                    command.ExecuteNonQuery();
                }

            response.Contents = uid;

            return response;
        }

        /// <summary>
        /// Update client details
        /// </summary>
        /// <returns></returns>
        public static ResponseStatus Update(HeaderInfo headerInfo, Client client, MySqlConnection conn = null)
        {

            var response = new ResponseStatus();
            response.ReturnCode = 1;
            response.ReasonCode = 1;
            response.Message = "Client Updated Successfully.";

            if (client.Name == null)
                client.Name = "";

            if (client.Address == null)
                client.Address = "";

            if (client.MainContactPersonName == null)
                client.MainContactPersonName = "";


            // Check record version. Do not allow update if version is different

            if (!IsTheSameRecordVersion(client.UID, client.RecordVersion))
            {
                response.ReturnCode = -0010;
                response.ReasonCode = 0001;
                response.Message = "Record updated previously by another user.";
                return response;
            }

            string commandString = (
                                             "UPDATE Client " +
                                             " SET  " +
                                             FCMDBFieldName.Client.ABN + " = @" + FCMDBFieldName.Client.ABN + ", " +
                                             FCMDBFieldName.Client.RecordVersion + " = @" + FCMDBFieldName.Client.RecordVersion + ", " +
                                             FCMDBFieldName.Client.Name + " = @" + FCMDBFieldName.Client.Name + ", " +
                                             FCMDBFieldName.Client.LegalName + " = @" + FCMDBFieldName.Client.LegalName + ", " +
                                             FCMDBFieldName.Client.Address + " = @" + FCMDBFieldName.Client.Address + ", " +
                                             FCMDBFieldName.Client.Phone + " = @" + FCMDBFieldName.Client.Phone + ", " +
                                             FCMDBFieldName.Client.Fax + " = @" + FCMDBFieldName.Client.Fax + ", " +
                                             FCMDBFieldName.Client.Mobile + " = @" + FCMDBFieldName.Client.Mobile + ", " +
                                             FCMDBFieldName.Client.Logo1Location + " = @" + FCMDBFieldName.Client.Logo1Location + ", " +
                                             FCMDBFieldName.Client.Logo2Location + " = @" + FCMDBFieldName.Client.Logo2Location + ", " +
                                             FCMDBFieldName.Client.Logo3Location + " = @" + FCMDBFieldName.Client.Logo3Location + ", " +
                                             FCMDBFieldName.Client.FKUserID + " = @" + FCMDBFieldName.Client.FKUserID + ", " +
                                             FCMDBFieldName.Client.FKDocumentSetUID + " = @" + FCMDBFieldName.Client.FKDocumentSetUID + ", " +
                                             FCMDBFieldName.Client.EmailAddress + " = @" + FCMDBFieldName.Client.EmailAddress + ", " +
                                             FCMDBFieldName.Client.MainContactPersonName + " = @" + FCMDBFieldName.Client.MainContactPersonName + ", " +
                                             FCMDBFieldName.Client.DisplayLogo + " = @" + FCMDBFieldName.Client.DisplayLogo + ", " +
                                             FCMDBFieldName.Client.UpdateDateTime + " = @" + FCMDBFieldName.Client.UpdateDateTime + ", " +
                                             FCMDBFieldName.Client.UserIdUpdatedBy + " = @" + FCMDBFieldName.Client.UserIdUpdatedBy +
                                             "    WHERE UID = @UID "
                                         );

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {
                using (var command = new MySqlCommand(cmdText: commandString, connection: connection))
                {
                    client.RecordVersion++;
                    AddSqlParameters(command, MackkadoITFramework.Helper.Utils.SQLAction.UPDATE, headerInfo, client);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        LogFile.WriteToTodaysLogFile(ex.ToString(), headerInfo.UserID);

                        response.ReturnCode = -0020;
                        response.ReasonCode = 0001;
                        response.Message = "Error saving client. " + ex.ToString();
                        return response;

                    }
                }
            }

            return response;
        }

        /// <summary>
        /// Logical Delete client
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        internal static ResponseStatus Delete(Client client)
        {

            var response = new ResponseStatus();
            response.UniqueCode = ResponseStatus.MessageCode.Informational.FCMINF00000007;

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {

                var commandString =
                (
                   "UPDATE Client " +
                   " SET  " +
                   "     IsVoid = @IsVoid " +
                   "    WHERE UID = @UID "
                );

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {
                    command.Parameters.Add("@UID", MySqlDbType.Int32).Value = client.UID;
                    command.Parameters.Add("@IsVoid", MySqlDbType.VarChar).Value = "Y";

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            return response;
        }

        // -----------------------------------------------------
        //          Retrieve last Client UID
        // -----------------------------------------------------
        private static int GetLastUID()
        {
            int lastUID = 0;

            // 
            // EA SQL database
            // 

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {
                var commandString = "SELECT MAX(UID) LASTUID FROM Client";

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        try
                        {
                            lastUID = Convert.ToInt32(reader["LASTUID"]);
                        }
                        catch (Exception)
                        {
                            lastUID = 0;
                        }
                    }
                }
            }

            return lastUID;
        }

        /// <summary>
        /// Check if the record version is the same. If it is not, deny update
        /// </summary>
        /// <param name="clientUID"></param>
        /// <param name="recordVersion"></param>
        /// <returns></returns>
        private static bool IsTheSameRecordVersion(int clientUID, int recordVersion)
        {
            // 
            // EA SQL database
            // 
            int currentVersion = 0;

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {
                var commandString = "SELECT recordversion FROM Client WHERE UID = " + clientUID.ToString(CultureInfo.InvariantCulture);

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        try
                        {
                            currentVersion = Convert.ToInt32(reader["recordversion"]);
                        }
                        catch (Exception)
                        {
                            currentVersion = 0;
                        }
                    }
                }
            }

            bool ret = false;
            if (currentVersion == 0 || currentVersion != recordVersion)
                ret = false;
            else
                ret = true;

            return ret;
        }

        // -----------------------------------------------------
        //    List clients
        // -----------------------------------------------------
        public static List<Client> List(HeaderInfo _headerInfo)
        {
            var clientList  = new List<Client>();

            using (var connection = new MySqlConnection( ConnString.ConnectionString ))
            {

                var commandString = string.Format(
                " SELECT " +
                ClientFieldString() +
                "   FROM Client " +
                "  WHERE IsVoid = 'N' " +
                "  ORDER BY UID ASC " 
                );

                using (var command = new MySqlCommand(
                                      commandString, connection ))
                {
                    connection.Open();

                    try
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var client = new Client(_headerInfo);
                                RepClient.LoadClientObject(reader, client);

                                // Retrieve status of the logo. Enabled or disabled
                                //
                                // 26.01.2013
                                // The attribute is now stored on the Client Table
                                //
                                //var rmd = new ReportMetadata();
                                //rmd.Read(client.UID, ReportMetadata.MetadataFieldCode.COMPANYLOGO);

                                //client.DisplayLogo = rmd.Enabled;

                                clientList.Add(client);

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        string error = ex.ToString();
                        LogFile.WriteToTodaysLogFile(ex.ToString(), _headerInfo.UserID, "", "Client.cs");

                    }
                }
            }

            return clientList;
        }


        /// <summary>
        /// Get Logo location for a client.
        /// </summary>
        /// <param name="clientUID"></param>
        /// <param name="curEnvironment"> </param>
        /// <returns></returns>
        public static string GetClientLogoLocation(int clientUID, HeaderInfo headerInfo, string curEnvironment = MackkadoITFramework.Helper.Utils.EnvironmentList.LOCAL )
        {

            string logoPath = "";
            string logoName = "";
            string logoPathName = "";

            Utils.FCMenvironment = curEnvironment;

            // Get Company Logo
            //
            //ReportMetadata rmd = new ReportMetadata();
            //rmd.ClientUID = clientUID;
            //rmd.RecordType = Utils.MetadataRecordType.CLIENT;
            //rmd.FieldCode = "COMPANYLOGO";

            //rmd.Read(clientUID: clientUID, fieldCode: "COMPANYLOGO");

            //Client client = new Client(headerInfo);
            //client.UID = clientUID;
            //client.Read();

            var resp = RepClient.Read(clientUID);
            Client client = new Client();
            client = resp.client;

            // Set no icon image if necessary
            //
            logoPath = FCMConstant.SYSFOLDER.LOGOFOLDER;
            logoName = "imgNoImage.jpg";

            if (client.Logo1Location != null)
            {
                logoName = client.Logo1Location.Replace(FCMConstant.SYSFOLDER.LOGOFOLDER, string.Empty);
            }

            logoPathName = Utils.getFilePathName(logoPath, logoName);

            return logoPathName;
        }


        /// <summary>
        /// Load client object
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="client"> </param>
        private static void LoadClientObject(MySqlDataReader reader, Client client)
        {
            client.UID = Convert.ToInt32(reader[FCMDBFieldName.Client.UID]);
            client.RecordVersion = Convert.ToInt32(reader[FCMDBFieldName.Client.RecordVersion]);
            client.ABN = reader[FCMDBFieldName.Client.ABN].ToString();
            client.Name = reader[FCMDBFieldName.Client.Name].ToString();
            client.LegalName = reader[FCMDBFieldName.Client.LegalName].ToString();
            client.Address = reader[FCMDBFieldName.Client.Address].ToString();
            client.EmailAddress = reader[FCMDBFieldName.Client.EmailAddress].ToString();
            client.Phone = reader[FCMDBFieldName.Client.Phone].ToString();
            try { client.FKUserID = reader[FCMDBFieldName.Client.FKUserID].ToString(); }
            catch { client.FKUserID = ""; }
            try { client.FKDocumentSetUID = Convert.ToInt32(reader[FCMDBFieldName.Client.FKDocumentSetUID]); }
            catch { client.FKDocumentSetUID = 0; }
            try { client.Fax = reader[FCMDBFieldName.Client.Fax].ToString(); }
            catch { client.Fax = ""; }
            try { client.Mobile = reader[FCMDBFieldName.Client.Mobile].ToString(); }
            catch { client.Mobile = ""; }
            try { client.Logo1Location = reader[FCMDBFieldName.Client.Logo1Location].ToString(); }
            catch { client.Logo1Location = ""; }
            try { client.Logo2Location = reader[FCMDBFieldName.Client.Logo2Location].ToString(); }
            catch { client.Logo2Location = ""; }
            try { client.Logo3Location = reader[FCMDBFieldName.Client.Logo3Location].ToString(); }
            catch { client.Logo3Location = ""; }

            try { client.MainContactPersonName = reader[FCMDBFieldName.Client.MainContactPersonName].ToString(); }
            catch { client.MainContactPersonName = ""; }

            try { client.DisplayLogo = Convert.ToChar(reader[FCMDBFieldName.Client.DisplayLogo]); }
            catch { client.DisplayLogo = ' '; }

            try { client.UpdateDateTime = Convert.ToDateTime(reader[FCMDBFieldName.Client.UpdateDateTime].ToString()); } 
            catch  { client.UpdateDateTime = DateTime.Now;  }
            try { client.CreationDateTime = Convert.ToDateTime(reader[FCMDBFieldName.Client.CreationDateTime].ToString()); }
            catch { client.CreationDateTime = DateTime.Now; }
            try { client.IsVoid = reader[FCMDBFieldName.Client.IsVoid].ToString(); }
            catch { client.IsVoid = "N"; }
            try { client.UserIdCreatedBy = reader[FCMDBFieldName.Client.UserIdCreatedBy].ToString(); }
            catch { client.UserIdCreatedBy = "N"; }
            try { client.UserIdUpdatedBy = reader[FCMDBFieldName.Client.UserIdCreatedBy].ToString(); }
            catch { client.UserIdCreatedBy = "N"; }

            client.DocSetUIDDisplay = "0; 0";
            if (client.FKDocumentSetUID > 0)
            {
                DocumentSet ds = new DocumentSet();
                ds.UID = client.FKDocumentSetUID;
                ds.Read('N');
                client.DocSetUIDDisplay = ds.UID + "; " + ds.TemplateType;
            }

        }


        /// <summary>
        /// Add SQL Parameters
        /// </summary>
        /// <param name="_uid"></param>
        /// <param name="command"></param>
        /// <param name="action"></param>
        /// <param name="headerInfo"> </param>
        private static void AddSqlParameters(MySqlCommand command, string action, HeaderInfo headerInfo, Client client)
        {

            if (string.IsNullOrEmpty(headerInfo.UserID))
                headerInfo.UserID = "UNDEF";

            command.Parameters.Add("@UID", MySqlDbType.Int32).Value = client.UID;
            command.Parameters.Add("@ABN", MySqlDbType.VarChar).Value = client.ABN;
            command.Parameters.Add("@Name", MySqlDbType.VarChar).Value = client.Name;
            command.Parameters.Add("@LegalName", MySqlDbType.VarChar).Value = client.LegalName;
            command.Parameters.Add("@Address", MySqlDbType.VarChar).Value = client.Address;
            command.Parameters.Add("@Phone", MySqlDbType.VarChar).Value = client.Phone;
            command.Parameters.Add("@EmailAddress", MySqlDbType.VarChar).Value = client.EmailAddress;
            command.Parameters.Add("@Fax", MySqlDbType.VarChar).Value = client.Fax;
            command.Parameters.Add("@Mobile", MySqlDbType.VarChar).Value = client.Mobile;
            command.Parameters.Add("@Logo1Location", MySqlDbType.VarChar).Value = client.Logo1Location;
            command.Parameters.Add("@Logo2Location", MySqlDbType.VarChar).Value = client.Logo2Location;
            command.Parameters.Add("@Logo3Location", MySqlDbType.VarChar).Value = client.Logo3Location;
            command.Parameters.Add("@MainContactPersonName", MySqlDbType.VarChar).Value = client.MainContactPersonName;
            command.Parameters.Add("@DisplayLogo", MySqlDbType.VarChar).Value = client.DisplayLogo;
            command.Parameters.Add("@IsVoid", MySqlDbType.VarChar).Value = "N";
            command.Parameters.Add("@FKUserID", MySqlDbType.VarChar).Value = client.FKUserID;
            command.Parameters.Add("@FKDocumentSetUID", MySqlDbType.Int32).Value = client.FKDocumentSetUID;
            command.Parameters.Add("@UpdateDateTime", MySqlDbType.DateTime, 8).Value = System.DateTime.Today;
            command.Parameters.Add("@UserIdUpdatedBy", MySqlDbType.VarChar).Value = headerInfo.UserID;

            if (action == MackkadoITFramework.Helper.Utils.SQLAction.CREATE)
            {
                command.Parameters.Add("@CreationDateTime", MySqlDbType.DateTime, 8).Value = System.DateTime.Today;
                command.Parameters.Add("@UserIdCreatedBy", MySqlDbType.VarChar).Value = headerInfo.UserID;
            }

            command.Parameters.Add("@recordVersion", MySqlDbType.Int32).Value = client.RecordVersion;

        }


        /// <summary>
        /// Client string of fields.
        /// </summary>
        /// <returns></returns>
        private static string ClientFieldString()
        {
            string ret =
                        FCMDBFieldName.Client.UID
                + "," + FCMDBFieldName.Client.ABN
                + "," + FCMDBFieldName.Client.Name
                + "," + FCMDBFieldName.Client.LegalName
                + "," + FCMDBFieldName.Client.Address
                + "," + FCMDBFieldName.Client.Phone
                + "," + FCMDBFieldName.Client.EmailAddress
                + "," + FCMDBFieldName.Client.Fax
                + "," + FCMDBFieldName.Client.Mobile
                + "," + FCMDBFieldName.Client.Logo1Location
                + "," + FCMDBFieldName.Client.Logo2Location
                + "," + FCMDBFieldName.Client.Logo3Location
                + "," + FCMDBFieldName.Client.MainContactPersonName
                + "," + FCMDBFieldName.Client.DisplayLogo
                + "," + FCMDBFieldName.Client.IsVoid
                + "," + FCMDBFieldName.Client.FKUserID
                + "," + FCMDBFieldName.Client.FKDocumentSetUID
                + "," + FCMDBFieldName.Client.UpdateDateTime
                + "," + FCMDBFieldName.Client.UserIdUpdatedBy
                + "," + FCMDBFieldName.Client.CreationDateTime
                + "," + FCMDBFieldName.Client.UserIdCreatedBy
                + "," + FCMDBFieldName.Client.RecordVersion;

            return ret;
        }

        /// <summary>
        /// Client string of fields.
        /// </summary>
        /// <returns></returns>
        private static string ClientFieldValue()
        {
            string ret =
                "( @UID     " +
                ", @ABN    " +
                ", @Name    " +
                ", @LegalName    " +
                ", @Address " +
                ", @Phone " +
                ", @EmailAddress " +
                ", @Fax " +
                ", @Mobile " +
                ", @Logo1Location " +
                ", @Logo2Location " +
                ", @Logo3Location " +
                ", @MainContactPersonName " +
                ", @DisplayLogo " +
                ", @IsVoid " +
                ", @FKUserID " +
                ", @FKDocumentSetUID " +
                ", @UpdateDateTime " +
                ", @UserIdUpdatedBy " +
                ", @CreationDateTime  " +
                ", @UserIdCreatedBy " +
                ", @recordVersion ) ";

            return ret;
        }

    }

}
