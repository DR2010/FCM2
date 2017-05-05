using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using MackkadoITFramework.Utils;
using MackkadoITFramework.ErrorHandling;
using MackkadoITFramework.Utils;
using MySql.Data.MySqlClient;
using ConnString = MackkadoITFramework.Utils.ConnString;
using HeaderInfo = MackkadoITFramework.Utils.HeaderInfo;
using Utils = MackkadoITFramework.Helper.Utils;
using FCMMySQLBusinessLibrary.Model.ModelClient;

namespace FCMMySQLBusinessLibrary.Repository.RepositoryClient
{
    public class RepClientExtraInformation : ClientExtraInformation
    {
        private HeaderInfo _headerInfo;

        public RepClientExtraInformation(HeaderInfo headerInfo)
        {
            _headerInfo = headerInfo;
        }


        /// <summary>
        /// Get Client Extra Information
        /// </summary>
        public static ResponseStatus Read( ClientExtraInformation clientExtraInfo)
        {
            // 
            // EA SQL database
            // 

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {
                var commandString =
                " SELECT " +
                ClientFieldString() +
                "  FROM ClientExtraInformation" +
                " WHERE FKClientUID = @UID";

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {

                    command.Parameters.Add("@UID", MySqlDbType.Int32).Value = clientExtraInfo.FKClientUID;

                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        try
                        {
                            LoadClientObject(reader, clientExtraInfo);
                        }
                        catch (Exception)
                        {
                            clientExtraInfo.UID = 0;
                        }
                    }
                    else
                    {
                        
                        return new ResponseStatus(){ReturnCode = 1, ReasonCode = 2, Message = "Not found",XMessageType = MessageType.Warning};                 
                    }
                }
            }

            return new ResponseStatus();
        }

        // -----------------------------------------------------
        //    Add new Client
        // -----------------------------------------------------
        public static ResponseStatus Insert(
            HeaderInfo headerInfo, 
            ClientExtraInformation clientExtraInfo,
            MySqlConnection connection)
        {

            ResponseStatus response = new ResponseStatus();
            response.ReturnCode = 1;
            response.ReasonCode = 1;
            response.Message = "Client Added Successfully";

            int _uid = 0;

            int nextUID = GetLastUID() + 1; // 2010100000
            clientExtraInfo.UID = nextUID;
            DateTime _now = DateTime.Today;

            clientExtraInfo.RecordVersion = 1;
            clientExtraInfo.IsVoid = "N";
            clientExtraInfo.CreationDateTime = headerInfo.CurrentDateTime;
            clientExtraInfo.UpdateDateTime = headerInfo.CurrentDateTime;
            clientExtraInfo.UserIdCreatedBy = headerInfo.UserID;
            clientExtraInfo.UserIdUpdatedBy = headerInfo.UserID;

            var commandString =
            (
                "INSERT INTO ClientExtraInformation " +
                "(" +
                ClientFieldString() +
                ")" +
                    " VALUES " +
                "( @UID     " +
                ", @FKClientUID    " +
                ", @DateToEnterOnPolicies    " +
                ", @ScopeOfServices " +
                ", @ActionPlanDate " +
                ", @CertificationTargetDate " +
                ", @TimeTrading " +
                ", @RegionsOfOperation " +
                ", @OperationalMeetingsFrequency " +
                ", @ProjectMeetingsFrequency " +
                ", @IsVoid " +
                ", @RecordVersion " +
                ", @UpdateDateTime " +
                ", @UserIdUpdatedBy " +
                ", @CreationDateTime  " +
                ", @UserIdCreatedBy ) "
                );



            using (var command = new MySqlCommand(commandString, connection))
            {
                clientExtraInfo.RecordVersion = 1;
                clientExtraInfo.IsVoid = "N";
                AddSQLParameters(command, MakConstant.SQLAction.CREATE, clientExtraInfo);

                if (connection.State != ConnectionState.Open)
                    connection.Open();

                command.ExecuteNonQuery();
            }

            response.Contents = _uid;

            return response;
        }


        /// <summary>
        /// Update client details
        /// </summary>
        /// <returns></returns>
        public static ResponseStatus Update(
            HeaderInfo headerInfo,
            ClientExtraInformation clientExtraInfo,
            MySqlConnection connection)
        {

            var response = new ResponseStatus {ReturnCode = 1, ReasonCode = 1, Message = "Client Updated Successfully."};

            // using (var connection = new MySqlConnection(ConnString.ConnectionString))

            using (connection)
            {

                var commandString = (
                                        "UPDATE ClientExtraInformation " +
                                        " SET  " +
                                        FCMDBFieldName.ClientExtraInformation.ActionPlanDate + " = @" + FCMDBFieldName.ClientExtraInformation.ActionPlanDate + ", " +
                                        FCMDBFieldName.ClientExtraInformation.CertificationTargetDate + " = @" + FCMDBFieldName.ClientExtraInformation.CertificationTargetDate + ", " +
                                        FCMDBFieldName.ClientExtraInformation.DateToEnterOnPolicies + " = @" + FCMDBFieldName.ClientExtraInformation.DateToEnterOnPolicies + ", " +
                                        FCMDBFieldName.ClientExtraInformation.OperationalMeetingsFrequency + " = @" + FCMDBFieldName.ClientExtraInformation.OperationalMeetingsFrequency + ", " +
                                        FCMDBFieldName.ClientExtraInformation.ProjectMeetingsFrequency + " = @" + FCMDBFieldName.ClientExtraInformation.ProjectMeetingsFrequency + ", " +
                                        FCMDBFieldName.ClientExtraInformation.RecordVersion + " = @" + FCMDBFieldName.ClientExtraInformation.RecordVersion + ", " +
                                        FCMDBFieldName.ClientExtraInformation.RegionsOfOperation + " = @" + FCMDBFieldName.ClientExtraInformation.RegionsOfOperation + ", " +
                                        FCMDBFieldName.ClientExtraInformation.ScopeOfServices + " = @" + FCMDBFieldName.ClientExtraInformation.ScopeOfServices + ", " +
                                        FCMDBFieldName.ClientExtraInformation.TimeTrading + " = @" + FCMDBFieldName.ClientExtraInformation.TimeTrading + ", " +
                                        FCMDBFieldName.ClientExtraInformation.IsVoid + " = @" + FCMDBFieldName.ClientExtraInformation.IsVoid + ", " +
                                        FCMDBFieldName.ClientExtraInformation.UpdateDateTime + " = @" + FCMDBFieldName.ClientExtraInformation.UpdateDateTime + ", " +
                                        FCMDBFieldName.ClientExtraInformation.UserIdUpdatedBy + " = @" + FCMDBFieldName.ClientExtraInformation.UserIdUpdatedBy +
                                        "    WHERE FKClientUID = @FKClientUID "
                                    );


                clientExtraInfo.RecordVersion++;
                clientExtraInfo.UpdateDateTime = DateTime.Now;
                clientExtraInfo.UserIdUpdatedBy = headerInfo.UserID;
                clientExtraInfo.IsVoid = "N";

                using (var command = new MySqlCommand(
                                            cmdText: commandString,
                                            connection: connection))
                {

                    AddSQLParameters(command, MakConstant.SQLAction.UPDATE, clientExtraInfo);
                    
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                            connection.Open();
                        
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        LogFile.WriteToTodaysLogFile(ex.ToString(), headerInfo.UserID);

                        response.ReturnCode = -0020;
                        response.ReasonCode = 0001;
                        response.Message = "Error saving Client Extra Information. " + ex.ToString();
                        return response;
                    }
                }
            }
            return response;
        }


        /// <summary>
        /// Retrieve last UID
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
                var commandString = "SELECT MAX(UID) LASTUID FROM ClientExtraInformation";

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
        /// Add SQL Parameters
        /// </summary>
        /// <param name="_uid"></param>
        /// <param name="command"></param>
        /// <param name="action"></param>
        private static void AddSQLParameters(MySqlCommand command, string action, ClientExtraInformation clientExtraInfo)
        {

            command.Parameters.Add("@UID", MySqlDbType.Int32).Value = clientExtraInfo.UID;
            command.Parameters.Add("@FKClientUID", MySqlDbType.VarChar).Value = clientExtraInfo.FKClientUID;
            command.Parameters.Add("@ActionPlanDate", MySqlDbType.Date).Value = clientExtraInfo.ActionPlanDate;
            command.Parameters.Add("@CertificationTargetDate", MySqlDbType.Date).Value = clientExtraInfo.CertificationTargetDate;
            command.Parameters.Add("@DateToEnterOnPolicies", MySqlDbType.Date).Value = clientExtraInfo.DateToEnterOnPolicies;
            command.Parameters.Add("@OperationalMeetingsFrequency", MySqlDbType.VarChar).Value = clientExtraInfo.OperationalMeetingsFrequency;
            command.Parameters.Add("@ProjectMeetingsFrequency", MySqlDbType.VarChar).Value = clientExtraInfo.ProjectMeetingsFrequency;
            command.Parameters.Add("@RegionsOfOperation", MySqlDbType.VarChar).Value = clientExtraInfo.RegionsOfOperation;
            command.Parameters.Add("@ScopeOfServices", MySqlDbType.VarChar).Value = clientExtraInfo.ScopeOfServices;
            command.Parameters.Add("@TimeTrading", MySqlDbType.VarChar).Value = clientExtraInfo.TimeTrading;

            command.Parameters.Add("@UpdateDateTime", MySqlDbType.DateTime).Value = clientExtraInfo.UpdateDateTime;
            command.Parameters.Add("@UserIdUpdatedBy", MySqlDbType.VarChar).Value = clientExtraInfo.UserIdUpdatedBy;
            command.Parameters.Add("@IsVoid", MySqlDbType.VarChar).Value = clientExtraInfo.IsVoid;
            command.Parameters.Add("@RecordVersion", MySqlDbType.Int32).Value = clientExtraInfo.RecordVersion;

            if (action == MakConstant.SQLAction.CREATE)
            {
                command.Parameters.Add("@CreationDateTime", MySqlDbType.DateTime, 8).Value = clientExtraInfo.CreationDateTime;
                command.Parameters.Add("@UserIdCreatedBy", MySqlDbType.VarChar).Value = clientExtraInfo.UserIdCreatedBy;
            }

        }


        /// <summary>
        /// Client string of fields.
        /// </summary>
        /// <returns></returns>
        private static string ClientFieldString()
        {
            string ret =
                        FCMDBFieldName.ClientExtraInformation.UID
                + "," + FCMDBFieldName.ClientExtraInformation.FKClientUID
                + "," + FCMDBFieldName.ClientExtraInformation.DateToEnterOnPolicies
                + "," + FCMDBFieldName.ClientExtraInformation.ScopeOfServices
                + "," + FCMDBFieldName.ClientExtraInformation.ActionPlanDate
                + "," + FCMDBFieldName.ClientExtraInformation.CertificationTargetDate
                + "," + FCMDBFieldName.ClientExtraInformation.TimeTrading
                + "," + FCMDBFieldName.ClientExtraInformation.RegionsOfOperation
                + "," + FCMDBFieldName.ClientExtraInformation.OperationalMeetingsFrequency
                + "," + FCMDBFieldName.ClientExtraInformation.ProjectMeetingsFrequency
                + "," + FCMDBFieldName.ClientExtraInformation.IsVoid
                + "," + FCMDBFieldName.ClientExtraInformation.RecordVersion
                + "," + FCMDBFieldName.ClientExtraInformation.UpdateDateTime
                + "," + FCMDBFieldName.ClientExtraInformation.UserIdUpdatedBy
                + "," + FCMDBFieldName.ClientExtraInformation.CreationDateTime
                + "," + FCMDBFieldName.ClientExtraInformation.UserIdCreatedBy;

            return ret;
        }

        /// <summary>
        /// Load client object
        /// </summary>
        /// <param name="reader"></param>
        private static void LoadClientObject(MySqlDataReader reader, ClientExtraInformation clientExtraInfo)
        {
            clientExtraInfo.UID = Convert.ToInt32(reader[FCMDBFieldName.ClientExtraInformation.UID]);
            try { clientExtraInfo.ActionPlanDate = Convert.ToDateTime(reader[FCMDBFieldName.ClientExtraInformation.ActionPlanDate].ToString()); }
            catch { clientExtraInfo.ActionPlanDate = Utils.MinDate; }
            try { clientExtraInfo.CertificationTargetDate = Convert.ToDateTime(reader[FCMDBFieldName.ClientExtraInformation.CertificationTargetDate].ToString()); }
            catch { clientExtraInfo.CertificationTargetDate = Utils.MinDate; }
            try { clientExtraInfo.DateToEnterOnPolicies = Convert.ToDateTime(reader[FCMDBFieldName.ClientExtraInformation.DateToEnterOnPolicies].ToString()); }
            catch { clientExtraInfo.DateToEnterOnPolicies = Utils.MinDate; }
            clientExtraInfo.FKClientUID = Convert.ToInt32(reader[FCMDBFieldName.ClientExtraInformation.FKClientUID]);
            clientExtraInfo.OperationalMeetingsFrequency = (reader[FCMDBFieldName.ClientExtraInformation.OperationalMeetingsFrequency].ToString());
            clientExtraInfo.ProjectMeetingsFrequency = (reader[FCMDBFieldName.ClientExtraInformation.ProjectMeetingsFrequency].ToString());

            clientExtraInfo.RegionsOfOperation = (reader[FCMDBFieldName.ClientExtraInformation.RegionsOfOperation].ToString());
            clientExtraInfo.ScopeOfServices = (reader[FCMDBFieldName.ClientExtraInformation.ScopeOfServices].ToString());
            clientExtraInfo.TimeTrading = (reader[FCMDBFieldName.ClientExtraInformation.TimeTrading].ToString());

            // Audit Info
            //
            try { clientExtraInfo.UpdateDateTime = Convert.ToDateTime(reader[FCMDBFieldName.ClientExtraInformation.UpdateDateTime].ToString()); }
            catch { clientExtraInfo.UpdateDateTime = DateTime.Now; }
            try { clientExtraInfo.CreationDateTime = Convert.ToDateTime(reader[FCMDBFieldName.ClientExtraInformation.CreationDateTime].ToString()); }
            catch { clientExtraInfo.CreationDateTime = DateTime.Now; }
            try { clientExtraInfo.IsVoid = reader[FCMDBFieldName.ClientExtraInformation.IsVoid].ToString(); }
            catch { clientExtraInfo.IsVoid = "N"; }
            try { clientExtraInfo.UserIdCreatedBy = reader[FCMDBFieldName.ClientExtraInformation.UserIdCreatedBy].ToString(); }
            catch { clientExtraInfo.UserIdCreatedBy = "N"; }
            try { clientExtraInfo.UserIdUpdatedBy = reader[FCMDBFieldName.ClientExtraInformation.UserIdCreatedBy].ToString(); }
            catch { clientExtraInfo.UserIdCreatedBy = "N"; }
            clientExtraInfo.RecordVersion = Convert.ToInt32(reader[FCMDBFieldName.ClientExtraInformation.RecordVersion]);
        }
    }
}
