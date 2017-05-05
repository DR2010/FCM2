using System;
using System.Collections.Generic;
using MackkadoITFramework.Helper;
using MackkadoITFramework.ReferenceData;
using MackkadoITFramework.Utils;
using MySql.Data.MySqlClient;

namespace FCMMySQLBusinessLibrary.Model.ModelMetadata
{
    public class ReportMetadata
    {

        private MySqlConnection _MySqlConnection;
        private string _dbConnectionString;
        private string _userID;

        public int UID { get; set; }
        public string RecordType { get; set; } // DF = Default; CS = Company Specific
        public string FieldCode { get; set; }
        public string ClientType { get; set; }
        public int ClientUID { get; set; }
        public string Description { get; set; }
        public string InformationType { get; set; }
        public string TableName { get; set; }
        public string FieldName { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string Condition { get; set; }
        public string CompareWith { get; set; }
        public char UseAsLabel { get; set; }

        public IEnumerable<string> RecordTypeListValues
        {
            get
            {
                var list = new List<string> { "Default", "Client Specific" };

                return list;
            }
        }

        public List<ReportMetadata> reportMetadataList;


        /// <summary>
        /// Indicates whether the metafield is used for the client. Only used for client specific field.
        /// </summary>
        public char Enabled;

        public bool FoundinDB;

        // -----------------------------------------------------
        //   Constructor using userId and connection string
        // -----------------------------------------------------
        public ReportMetadata()
        {
        
        }

        /// <summary>
        /// Returns the value of the metafield
        /// </summary>
        /// <returns></returns>
        public string GetValue()
        {
            string ret = "";
            string select = "";

            if (this.InformationType == Utils.InformationType.IMAGE)
            {
                select = this.Condition;
                // return select;
            }

            if (this.InformationType == Utils.InformationType.VARIABLE)
            {
                select = DateTime.Today.ToString().Substring(0,10);
                return select;
            }


            if (this.InformationType == Utils.InformationType.FIELD)
            {
                select = this.Condition;
            }

            if (string.IsNullOrEmpty(select))
            {
                return "";
            }

            // --------------------------------
            //          Get Variable
            // --------------------------------
            //if (this.CompareWith == "CLIENT.UID")
            //{
            //    // select += Utils.ClientID.ToString();
            //    select += this.ClientUID.ToString();
            //}
            
            // 
            // EA SQL database
            // 

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {
                var commandString = select;

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {
                    if (this.CompareWith == "CLIENT.UID")
                    {
                        command.Parameters.Add("@UID", MySqlDbType.Int32).Value = this.ClientUID;
                    }

                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        ret = reader[0].ToString();
                    }
                }
            }

            // If it is an image, get the final folder
            //
            if (this.InformationType == Utils.InformationType.IMAGE)
            {
                // string logoPathName = Utils.GetPathName( ret );
                string logoPathName = Utils.getFilePathName( ret );
                ret = logoPathName;
            }
            return ret;
        }


        
        /// <summary>
        /// Retrieve last Report Metadata UID
        /// </summary>
        /// <returns></returns>
        public static int GetLastUID()
        {
            int LastUID = 0;

            // 
            // EA SQL database
            // 

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {
                var commandString = "SELECT MAX(UID) LASTUID FROM ReportMetadata";

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
        /// Retrieve last Report Metadata UID
        /// </summary>
        /// <returns></returns>
        public static int GetLastUIDSubTransaction(
                    MySqlConnection connection, 
                    MySqlTransaction MySqlTransaction, 
                    HeaderInfo headerInfo)
        {
            int LastUID = 0;

            // 
            // EA SQL database
            // 

            var commandString = "SELECT MAX(UID) LASTUID FROM ReportMetadata";

            // var command = new MySqlCommand(commandString, connection, MySqlTransaction);

            var command = connection.CreateCommand();
            command.CommandText = commandString;
            command.Transaction = MySqlTransaction;

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
            return LastUID;
        }


        /// <summary>
        /// Add or update record.
        /// </summary>
        public void Save()
        {
            // Check if code value exists.
            // If it exists, update
            // Else Add a new one

            this.Read(true);

            bool results = this.FoundinDB;

            if (results)
            {
                this.Update();
            }
            else
            {
                this.Add();
            }

        }

        /// <summary>
        /// Add or update record. Sub Transactional
        /// </summary>
        public void SaveSubTransaction( MySqlConnection connection, 
                                        MySqlTransaction MySqlTransaction, 
                                        HeaderInfo headerInfo)
        {
            // Check if code value exists.
            // If it exists, update
            // Else Add a new one

            this.Read(true);

            bool results = this.FoundinDB;

            if (results)
            {
                this.UpdateSubTransaction(connection, MySqlTransaction, headerInfo);
            }
            else
            {
                this.AddSubTransaction(connection, MySqlTransaction, headerInfo);
            }

        }



        /// <summary>
        /// Add new report metadata
        /// </summary>
        private void Add()
        {

            string ret = "Item updated successfully";
            int _uid = 0;

            _uid = GetLastUID() + 1;

            DateTime _now = DateTime.Today;

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {

                var commandString =
                (

           "INSERT INTO ReportMetadata " +
           "( " +
           "  UID " +
           " ,RecordType " +
           " ,Description " +
           " ,FieldCode " +
           " ,ClientType " +
           " ,ClientUID " + 
           " ,InformationType " +
           " ,ConditionX " +
           " ,CompareWith " +
           " ,Enabled " +
           " ,UseAsLabel " +
           " ) " +
           " VALUES " +
           " ( " +
           "  @UID " +
           " ,@RecordType " +
           " ,@Description " +
           " ,@FieldCode " +
           " ,@ClientType " +
           " ,@ClientUID " + 
           " ,@InformationType " +
           " ,@Condition " +
           " ,@CompareWith " +
           " ,@Enabled " +
           " ,@UseAsLabel" +
           " )"            
           );

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {
                    command.Parameters.Add("@UID", MySqlDbType.Int32).Value = _uid;
                    command.Parameters.Add("@RecordType", MySqlDbType.VarChar).Value = RecordType;
                    command.Parameters.Add("@Description", MySqlDbType.VarChar).Value = Description;
                    command.Parameters.Add("@FieldCode", MySqlDbType.VarChar).Value = FieldCode;
                    command.Parameters.Add("@ClientType", MySqlDbType.VarChar).Value = ClientType;
                    command.Parameters.Add("@ClientUID", MySqlDbType.Int32).Value = ClientUID;
                    command.Parameters.Add("@InformationType", MySqlDbType.VarChar).Value = InformationType;
                    command.Parameters.Add("@Condition", MySqlDbType.VarChar).Value = Condition;
                    command.Parameters.Add("@CompareWith", MySqlDbType.VarChar).Value = CompareWith;
                    command.Parameters.Add("@Enabled", MySqlDbType.VarChar).Value = Enabled;
                    command.Parameters.Add("@UseAsLabel", MySqlDbType.VarChar).Value = UseAsLabel;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            return;
        }

        /// <summary>
        /// Add new report metadata
        /// </summary>
        private void AddSubTransaction(
                MySqlConnection connection, 
                MySqlTransaction MySqlTransaction,
                HeaderInfo headerInfo)
        {

            string ret = "Item updated successfully";
            int _uid = 0;

            _uid = GetLastUIDSubTransaction( connection, MySqlTransaction, headerInfo ) + 1;

            DateTime _now = DateTime.Today;

            var commandString =
            (
                "INSERT INTO ReportMetadata " +
                "( " +
                "  UID " +
                " ,RecordType " +
                " ,Description " +
                " ,FieldCode " +
                " ,ClientType " +
                " ,ClientUID " +
                " ,InformationType " +
                " ,ConditionX " +
                " ,CompareWith " +
                " ,Enabled " +
                " ) " +
                " VALUES " +
                " ( " +
                "  @UID " +
                " ,@RecordType " +
                " ,@Description " +
                " ,@FieldCode " +
                " ,@ClientType " +
                " ,@ClientUID " +
                " ,@InformationType " +
                " ,@Condition " +
                " ,@CompareWith " +
                " ,@Enabled " +
                " )"
                );

            var command = new MySqlCommand(commandString, connection, MySqlTransaction);
            command.Parameters.Add("@UID", MySqlDbType.Int32).Value = _uid;
            command.Parameters.Add("@RecordType", MySqlDbType.VarChar).Value = RecordType;
            command.Parameters.Add("@Description", MySqlDbType.VarChar).Value = Description;
            command.Parameters.Add("@FieldCode", MySqlDbType.VarChar).Value = FieldCode;
            command.Parameters.Add("@ClientType", MySqlDbType.VarChar).Value = ClientType;
            command.Parameters.Add("@ClientUID", MySqlDbType.Int32).Value = ClientUID;
            command.Parameters.Add("@InformationType", MySqlDbType.VarChar).Value = InformationType;
            command.Parameters.Add("@Condition", MySqlDbType.VarChar).Value = Condition;
            command.Parameters.Add("@CompareWith", MySqlDbType.VarChar).Value = CompareWith;
            command.Parameters.Add("@Enabled", MySqlDbType.VarChar).Value = Enabled;

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                LogFile.WriteToTodaysLogFile(ex.ToString(), headerInfo.UserID);
            }

            return;
        }


        /// <summary>
        /// Update metadata table
        /// </summary>
        private void Update()
        {

            string ret = "Item updated successfully";
            
            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {

                var commandString =
                (

           "UPDATE ReportMetadata " +
           "SET " +
           "  FieldCode        = @FieldCode " + // not setting record type...
           " ,RecordType       = @RecordType " +
           " ,Description      = @Description " +
           " ,ClientType       = @ClientType " +
           " ,ClientUID        = @ClientUID " +
           " ,InformationType  = @InformationType " +
           " ,ConditionX        = @Condition " +
           " ,CompareWith      = @CompareWith " +
           " ,Enabled          = @Enabled" +
           " ,UseAsLabel       = @UseAsLabel" +

           " WHERE UID  = @UID ");

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {
                    command.Parameters.Add("@FieldCode", MySqlDbType.VarChar ).Value = FieldCode;
                    command.Parameters.Add("@RecordType", MySqlDbType.VarChar ).Value = RecordType;
                    command.Parameters.Add("@Description", MySqlDbType.VarChar ).Value = Description;
                    command.Parameters.Add("@ClientType", MySqlDbType.VarChar ).Value = ClientType;
                    command.Parameters.Add("@InformationType", MySqlDbType.VarChar ).Value = InformationType;
                    command.Parameters.Add("@ClientUID", MySqlDbType.VarChar ).Value = ClientUID;
                    command.Parameters.Add("@UID", MySqlDbType.VarChar ).Value = UID;
                    command.Parameters.Add("@Condition", MySqlDbType.VarChar ).Value = Condition;
                    command.Parameters.Add("@CompareWith", MySqlDbType.VarChar ).Value = CompareWith;
                    command.Parameters.Add("@Enabled", MySqlDbType.VarChar).Value = Enabled;
                    command.Parameters.Add("@UseAsLabel", MySqlDbType.VarChar).Value = UseAsLabel;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            return;
        }


        /// <summary>
        /// Update metadata table
        /// </summary>
        private void UpdateSubTransaction(
                    MySqlConnection connection, 
                    MySqlTransaction MySqlTransaction,
                    HeaderInfo headerInfo)
        {

            string ret = "Item updated successfully";

            var commandString =
            (
                "UPDATE ReportMetadata " +
                "SET " +
                "  FieldCode        = @FieldCode " + // not setting record type...
                " ,RecordType       = @RecordType " +
                " ,Description      = @Description " +
                " ,ClientType       = @ClientType " +
                " ,ClientUID        = @ClientUID " +
                " ,InformationType  = @InformationType " +
                " ,ConditionX        = @Condition " +
                " ,CompareWith      = @CompareWith " +
                " ,Enabled          = @Enabled" +

                " WHERE UID  = @UID ");

            var command = new MySqlCommand(commandString, connection, MySqlTransaction);
            command.Parameters.Add("@FieldCode", MySqlDbType.VarChar).Value = FieldCode;
            command.Parameters.Add("@RecordType", MySqlDbType.VarChar).Value = RecordType;
            command.Parameters.Add("@Description", MySqlDbType.VarChar).Value = Description;
            command.Parameters.Add("@ClientType", MySqlDbType.VarChar).Value = ClientType;
            command.Parameters.Add("@InformationType", MySqlDbType.VarChar).Value = InformationType;
            command.Parameters.Add("@ClientUID", MySqlDbType.VarChar).Value = ClientUID;
            command.Parameters.Add("@UID", MySqlDbType.VarChar).Value = UID;
            command.Parameters.Add("@Condition", MySqlDbType.VarChar).Value = Condition;
            command.Parameters.Add("@CompareWith", MySqlDbType.VarChar).Value = CompareWith;
            command.Parameters.Add("@Enabled", MySqlDbType.VarChar).Value = Enabled;

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                LogFile.WriteToTodaysLogFile(ex.ToString(), headerInfo.UserID);
            }


            
            return;
        }


        /// <summary>
        /// Read metadata
        /// </summary>
        /// <param name="CheckOnly"></param>
        private void Read(bool CheckOnly)
        {
            CodeValue ret = null;

            // 
            // EA SQL database
            // 

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {
                var commandString = 
                " SELECT UID " +
                "      ,RecordType " +
                "      ,FieldCode " +
                "      ,Description " +
                "      ,ClientType " +
                "      ,ClientUID " +
                "      ,InformationType " +
                "      ,ConditionX " +
                "      ,CompareWith " +
                "      ,Enabled " +
                "      ,UseAsLabel " +
                "  FROM ReportMetadata " +
                " WHERE UID = @UID ";

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {
                    connection.Open();

                    command.Parameters.Add(new MySqlParameter("UID", this.UID));

                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        try
                        {
                            if (!CheckOnly)
                            {
                                this.UID = Convert.ToInt32( reader["UID"].ToString() );
                                this.RecordType = reader["RecordType"].ToString();
                                this.FieldCode = reader["FieldCode"].ToString();
                                this.Description = reader["Description"].ToString();
                                this.ClientType = reader["ClientType"].ToString();
                                this.ClientUID = Convert.ToInt32( reader["ClientUID"]);
                                this.InformationType = reader["InformationType"].ToString();
                                this.Condition = reader["Condition"].ToString();
                                this.CompareWith = reader["CompareWith"].ToString();
                                this.Enabled = Convert.ToChar(reader["CompareWith"]);
                                this.UseAsLabel = Convert.ToChar(reader["UseAsLabel"]);
                            }

                            this.FoundinDB = true;
                        }
                        catch (Exception ex)
                        {
                            this.Description = ex.ToString();
                        }
                    }
                    else
                    {
                        this.FoundinDB = false;
                    }
                }
            }

        }


        // ---------------------------------------------
        //            Read
        // ---------------------------------------------
        public bool Read(int clientUID, string fieldCode)
        {

            bool ret = false;

            // 
            // EA SQL database
            // 

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {
                var commandString = 
                " SELECT UID " +
                "      ,RecordType " +
                "      ,FieldCode " +
                "      ,Description " +
                "      ,ClientType " +
                "      ,ClientUID " +
                "      ,InformationType " +
                "      ,ConditionX " +
                "      ,CompareWith " +
                "      ,Enabled " +
                "      ,UseAsLabel " +
                "  FROM ReportMetadata " +
                " WHERE ClientUID = @CLIENTUID " +
                "   AND FieldCode = @FIELDCODE ";

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {
                    connection.Open();

                    command.Parameters.Add(new MySqlParameter("@CLIENTUID", clientUID));
                    command.Parameters.Add(new MySqlParameter("@FIELDCODE", fieldCode));

                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        try
                        {
                            this.UID = Convert.ToInt32(reader["UID"].ToString());
                            this.RecordType = reader["RecordType"].ToString();
                            this.FieldCode = reader["FieldCode"].ToString();
                            this.Description = reader["Description"].ToString();
                            this.ClientType = reader["ClientType"].ToString();
                            this.ClientUID = Convert.ToInt32(reader["ClientUID"]);
                            this.InformationType = reader["InformationType"].ToString();
                            this.Condition = reader["Condition"].ToString();
                            this.CompareWith = reader["CompareWith"].ToString();
                            this.Enabled = Convert.ToChar(reader["Enabled"]);
                            this.UseAsLabel = Convert.ToChar(reader["UseAsLabel"]);

                            ret = true;
                        }
                        catch (Exception ex)
                        {
                            this.Description = ex.ToString();
                        }
                    }
                }

                return ret;

            }

        }

        // ---------------------------------------------
        //            Read
        // ---------------------------------------------
        public bool ReadSubTransaction(
            int clientUID,
            string fieldCode,
            MySqlConnection connection,
            MySqlTransaction MySqlTransaction,
            HeaderInfo headerInfo)
        {

            bool ret = false;

            // 
            // EA SQL database
            // 

            var commandString = string.Format(
            " SELECT UID " +
            "      ,RecordType " +
            "      ,FieldCode " +
            "      ,Description " +
            "      ,ClientType " +
            "      ,ClientUID " +
            "      ,InformationType " +
            "      ,ConditionX " +
            "      ,CompareWith " +
            "      ,Enabled " +
            "      ,UseAsLabel " +
            "  FROM ReportMetadata " +
            " WHERE ClientUID = {0} " +
            "   AND FieldCode = '{1}' ",
            clientUID,
            fieldCode);

            var command = new MySqlCommand(commandString, connection, MySqlTransaction);
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                try
                {
                    this.UID = Convert.ToInt32(reader["UID"].ToString());
                    this.RecordType = reader["RecordType"].ToString();
                    this.FieldCode = reader["FieldCode"].ToString();
                    this.Description = reader["Description"].ToString();
                    this.ClientType = reader["ClientType"].ToString();
                    this.ClientUID = Convert.ToInt32(reader["ClientUID"]);
                    this.InformationType = reader["InformationType"].ToString();
                    this.Condition = reader["Condition"].ToString();
                    this.CompareWith = reader["CompareWith"].ToString();
                    this.Enabled = Convert.ToChar(reader["Enabled"]);
                    this.UseAsLabel = Convert.ToChar(reader["UseAsLabel"]);

                    ret = true;
                }
                catch (Exception ex)
                {
                    this.Description = ex.ToString();
                }
            }

            return ret;

        }

        // ---------------------------------------------
        //            Read
        // ---------------------------------------------
        public void FindMatch(int clientUID, string rmdItem)
        {
            CodeValue ret = null;

            // 
            // EA SQL database
            // 

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {
                var commandString = string.Format(
                " SELECT UID " +
                "      ,RecordType " +
                "      ,FieldCode " +
                "      ,Description " +
                "      ,ClientType " +
                "      ,ClientUID " +
                "      ,InformationType " +
                "  FROM ReportMetadata " +
                " WHERE " + 
                "       ClientUID =  {0} " +
                "   AND FieldCode = '{1}' ",
                clientUID,
                rmdItem);

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        try
                        {
                            this.UID = Convert.ToInt32(reader["UID"].ToString());
                            this.RecordType = reader["RecordType"].ToString();
                            this.FieldCode = reader["FieldCode"].ToString();
                            this.Description = reader["Description"].ToString();
                            this.ClientType = reader["ClientType"].ToString();
                            this.ClientUID = Convert.ToInt32(reader["ClientUID"]);
                            this.InformationType = reader["InformationType"].ToString();

                            this.FoundinDB = true;
                        }
                        catch (Exception ex)
                        {
                            this.Description = ex.ToString();
                        }
                    }
                    else
                    {
                        this.FoundinDB = false;
                    }
                }
            }

        }


        // ---------------------------------------------
        //            Update metadata table
        // ---------------------------------------------
        public bool Delete()
        {

            if (UID <= 0)
                return false;

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {

                var commandString =
                (

           "DELETE ReportMetadata " +
           " WHERE UID  = @UID ");

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {
                    command.Parameters.Add("@UID", MySqlDbType.VarChar).Value = UID;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            return true;
        }

        public struct MetadataFieldCode
        {
            public const string COMPANYLOGO = "COMPANYLOGO";
        }

        // -----------------------------------------------------
        //    List Global Fields
        // -----------------------------------------------------
        public void ListDefault()
        {
            this.reportMetadataList = new List<ReportMetadata>();

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {

                var commandString = string.Format(
                " SELECT " +
                "  UID " +
                " ,Description " +
                " ,RecordType " +
                " ,FieldCode " +
                " ,ClientType " +
                " ,ClientUID " +
                " ,InformationType " +
                " ,ConditionX " +
                " ,CompareWith " +
                " ,Enabled " +
                " ,UseAsLabel " +
                "   FROM ReportMetadata " +
                "  WHERE RecordType = '{0}'",
                "DF");

                using (var command = new MySqlCommand(
                                      commandString, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            ReportMetadata _reportMetadata = new ReportMetadata();
                            _reportMetadata.UID = Convert.ToInt32(reader["UID"].ToString());
                            _reportMetadata.Description = reader["Description"].ToString();
                            _reportMetadata.RecordType = reader["RecordType"].ToString();
                            _reportMetadata.FieldCode = reader["FieldCode"].ToString();
                            _reportMetadata.ClientType = reader["ClientType"].ToString();
                            _reportMetadata.Condition = reader["ConditionX"].ToString();
                            _reportMetadata.CompareWith = reader["CompareWith"].ToString();
                            _reportMetadata.Enabled = Convert.ToChar(reader["Enabled"]);
                            try
                            {
                                _reportMetadata.UseAsLabel = Convert.ToChar(reader["UseAsLabel"]);
                            }
                            catch (Exception ex)
                            {
                                _reportMetadata.UseAsLabel = 'N';
                            }
                            try
                            {
                                _reportMetadata.ClientUID = Convert.ToInt32(reader["ClientUID"]);
                            }
                            catch (Exception ex)
                            {
                                _reportMetadata.ClientUID = 0;
                            }

                            _reportMetadata.InformationType = reader["InformationType"].ToString();

                            this.reportMetadataList.Add(_reportMetadata);
                        }
                    }
                }
            }
        }

        // -----------------------------------------------------
        //    List available report metadata
        // -----------------------------------------------------
        public void ListAvailableForClient(int clientUID)
        {
            this.reportMetadataList = new List<ReportMetadata>();

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {

                var commandString = string.Format(
                " SELECT " +
                "  UID " +
                " ,Description " +
                " ,RecordType " +
                " ,FieldCode " +
                " ,ClientType " +
                " ,ClientUID " +
                " ,InformationType " +
                " ,ConditionX " +
                " ,CompareWith " +
                "   FROM ReportMetadata " +
                "  WHERE RecordType = 'DF' " +
                "    AND FieldCode not in " +
                " ( select FieldCode from reportmetadata where ClientUID = {0}) ",
                clientUID
                );

                using (var command = new MySqlCommand(
                                      commandString, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            ReportMetadata _reportMetadata = new ReportMetadata();
                            _reportMetadata.UID = Convert.ToInt32(reader["UID"].ToString());
                            _reportMetadata.Description = reader["Description"].ToString();
                            _reportMetadata.RecordType = reader["RecordType"].ToString();
                            _reportMetadata.FieldCode = reader["FieldCode"].ToString();
                            _reportMetadata.ClientType = reader["ClientType"].ToString();

                            try
                            {
                                _reportMetadata.ClientUID = Convert.ToInt32(reader["ClientUID"]);
                            }
                            catch (Exception ex)
                            {
                                _reportMetadata.ClientUID = 0;
                            }

                            _reportMetadata.InformationType = reader["InformationType"].ToString();
                            _reportMetadata.Condition = reader["ConditionX"].ToString();
                            _reportMetadata.CompareWith = reader["CompareWith"].ToString();

                            this.reportMetadataList.Add(_reportMetadata);
                        }
                    }
                }
            }
        }

        // -----------------------------------------------------
        //    List metadata for a given client
        // -----------------------------------------------------
        public void ListMetadataForClient(int clientUID, bool onlyEnabled = false)
        {
            this.reportMetadataList = new List<ReportMetadata>();

            var enabledOnlyCriteria = "";
            if (onlyEnabled)
            {
                enabledOnlyCriteria = " AND Enabled = 'Y' ";
            }


            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {

                var commandString = string.Format(
                " SELECT " +
                "  UID " +
                " ,Description " +
                " ,RecordType " +
                " ,FieldCode " +
                " ,ClientType " +
                " ,ClientUID " +
                " ,InformationType " +
                " ,ConditionX " +
                " ,CompareWith " +
                " ,Enabled " +
                "   FROM ReportMetadata " +
                "  WHERE RecordType = 'CL' " +
                enabledOnlyCriteria +
                "    AND ClientUID = {0} ",
                clientUID
                );

                using (var command = new MySqlCommand(
                                      commandString, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            ReportMetadata _reportMetadata = new ReportMetadata();
                            _reportMetadata.UID = Convert.ToInt32(reader["UID"].ToString());
                            _reportMetadata.Description = reader["Description"].ToString();
                            _reportMetadata.RecordType = reader["RecordType"].ToString();
                            _reportMetadata.FieldCode = reader["FieldCode"].ToString();
                            _reportMetadata.ClientType = reader["ClientType"].ToString();
                            _reportMetadata.InformationType = reader["InformationType"].ToString();
                            _reportMetadata.Enabled = Convert.ToChar(reader["Enabled"]);

                            try
                            {
                                _reportMetadata.ClientUID = Convert.ToInt32(reader["ClientUID"]);
                            }
                            catch (Exception ex)
                            {
                                _reportMetadata.ClientUID = 0;
                            }

                            _reportMetadata.InformationType = reader["InformationType"].ToString();
                            _reportMetadata.Condition = reader["ConditionX"].ToString();
                            _reportMetadata.CompareWith = reader["CompareWith"].ToString();

                            this.reportMetadataList.Add(_reportMetadata);
                        }
                    }
                }
            }
        }


    }
}
