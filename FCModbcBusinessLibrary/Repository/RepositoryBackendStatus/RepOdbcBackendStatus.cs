using System;
using System.Collections.Generic;
using FCMMySQLBusinessLibrary.Model.ModelBackendStatus;
using FCMMySQLBusinessLibrary.Repository;
using MackkadoITFramework.Utils;
using System.Data.Odbc;

namespace FCModbcBusinessLibrary.Repository.RepositoryBackendStatus
{
    public class RepBackendStatus : BackendStatus
    {

        // -----------------------------------------------------
        //    List clients
        // -----------------------------------------------------
        public static BackendStatus ReadLast( HeaderInfo headerInfo, string processName )
        {
            var retBackendStatus  = new BackendStatus();

            using (var connection = new OdbcConnection(ConnString.ConnectionStringODBC))   
            {

                var commandString = string.Format(
                " SELECT " +
                " UID, " +
                " ProcessName, " +
                " ReportDateTime, " +
                " Details, " +
                " Status " +
                "  FROM backendstatus" +
                " WHERE ProcessName = @processName" +
                "  ORDER BY UID DESC "
                );

                using (var command = new OdbcCommand(
                                      commandString, connection ) )
                {
                    connection.Open();

                    command.Parameters.Add("@processName", OdbcType.VarChar).Value = processName;

                    try
                    {
                        using ( OdbcDataReader reader = command.ExecuteReader() )
                        {
                            while ( reader.Read() )
                            {

                                try { retBackendStatus.UID = Convert.ToInt32( reader [FCMDBFieldName.BackendStatus.UID] ); }
                                catch { retBackendStatus.UID = 0; }
                                try { retBackendStatus.ReportDateTime = Convert.ToDateTime( reader [FCMDBFieldName.BackendStatus.ReportDateTime] ); }
                                catch { retBackendStatus.ReportDateTime = DateTime.Today; }

                                retBackendStatus.ProcessName = reader [FCMDBFieldName.BackendStatus.ProcessName] as string;
                                retBackendStatus.Details = reader [FCMDBFieldName.BackendStatus.Details] as string;
                                retBackendStatus.Status = reader [FCMDBFieldName.BackendStatus.Status] as string;

                                break;
                            }
                        }
                    }
                    catch ( Exception ex )
                    {
                        string error = ex.ToString();
                        LogFile.WriteToTodaysLogFile( ex.ToString(), headerInfo.UserID, "", "Client.cs" );

                    }
                }
            }

            return retBackendStatus;
        }


        // -----------------------------------------------------
        //    List clients
        // -----------------------------------------------------
        public static List<BackendStatus> List(HeaderInfo headerInfo)
        {
            List<BackendStatus> retBackendStatusList  = new List<BackendStatus>();

            using (var connection = new OdbcConnection(ConnString.ConnectionString))
            {

                var commandString = string.Format(
                " SELECT " +
                " UID, " +
                " ProcessName, " +
                " ReportDateTime, " +
                " Details, " +
                " Status " +
                "  FROM backendstatus" +
                " WHERE ProcessName = @processName" +
                "  ORDER BY UID DESC "
                );

                using (var command = new OdbcCommand(
                                      commandString, connection ) )
                {
                    connection.Open();

                    try
                    {
                        using ( OdbcDataReader reader = command.ExecuteReader())
                        {
                            while ( reader.Read() )
                            {

                                BackendStatus backendStatus = new BackendStatus();

                                try { backendStatus.UID = Convert.ToInt32( reader [FCMDBFieldName.BackendStatus.UID] ); }
                                catch { backendStatus.UID = 0; }

                                backendStatus.ProcessName = reader [FCMDBFieldName.BackendStatus.ProcessName] as string;
                                backendStatus.Details = reader [FCMDBFieldName.BackendStatus.Details] as string;
                                backendStatus.Status = reader [FCMDBFieldName.BackendStatus.Status] as string;

                                try { backendStatus.ReportDateTime = Convert.ToDateTime( reader [FCMDBFieldName.BackendStatus.UID] ); }
                                catch { backendStatus.ReportDateTime = DateTime.Today; }

                                retBackendStatusList.Add( backendStatus );
                            }
                        }
                    }
                    catch ( Exception ex )
                    {
                        string error = ex.ToString();
                        LogFile.WriteToTodaysLogFile( ex.ToString(), headerInfo.UserID, "", "Client.cs" );

                    }
                }
            }

            return retBackendStatusList;
        }

        /// <summary>
        /// Add new status line
        /// </summary>
        /// <returns></returns>
        public static void Insert(HeaderInfo headerInfo, BackendStatus backendStatus, OdbcConnection connection = null)
        {

            int uid = 0;

            int nextUID = GetLastUID() + 1; 

            backendStatus.UID = uid;

            if ( connection == null )
            {
                connection = new OdbcConnection(ConnString.ConnectionString);
                connection.Open();
            }

            var commandString = 
            (
                "INSERT INTO backendstatus " +
                "(" +
                        FCMDBFieldName.BackendStatus.UID
                + "," + FCMDBFieldName.BackendStatus.ProcessName
                + "," + FCMDBFieldName.BackendStatus.ReportDateTime
                + "," + FCMDBFieldName.BackendStatus.Details
                + "," + FCMDBFieldName.BackendStatus.Status
                + ")" +
                    " VALUES " +
                "( @UID     " +
                ", @ProcessName    " +
                ", @ReportDateTime    " +
                ", @Details    " +
                ", @Status    " +
                " )" 

                );

            using (var command = new OdbcCommand(
                                            commandString, connection ) )
            {
                command.Parameters.Add( "@UID", OdbcType.BigInt ).Value = nextUID;
                command.Parameters.Add("@ProcessName", OdbcType.VarChar).Value = backendStatus.ProcessName;
                command.Parameters.Add("@Status", OdbcType.VarChar).Value = backendStatus.Status;
                command.Parameters.Add("@Details", OdbcType.VarChar).Value = backendStatus.Details;
                command.Parameters.Add("@ReportDateTime", OdbcType.DateTime, 8).Value = backendStatus.ReportDateTime;

                command.ExecuteNonQuery();
            }

            backendStatus.UID = nextUID;

            return;
        }

        /// <summary>
        /// Retrieve last UID
        /// </summary>
        /// <returns></returns>
        private static int GetLastUID()
        {
            int lastUID = 0;

            // 
            // EA SQL database
            // 

            using ( var connection = new OdbcConnection( ConnString.ConnectionString ) )
            {
                var commandString = "SELECT MAX(UID) LASTUID FROM backendstatus";

                using ( var command = new OdbcCommand(
                                            commandString, connection ) )
                {
                    connection.Open();
                    OdbcDataReader reader = command.ExecuteReader();

                    if ( reader.Read() )
                    {
                        try
                        {
                            lastUID = Convert.ToInt32( reader ["LASTUID"] );
                        }
                        catch ( Exception )
                        {
                            lastUID = 0;
                        }
                    }
                }
            }

            return lastUID;
        }


    }
}
