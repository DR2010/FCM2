﻿using System;
using MackkadoITFramework.Utils;
using MySql.Data.MySqlClient;

namespace FCMMySQLBusinessLibrary.Model.ModelClientDocument
{
    public class ClientDocumentVersion
    {
        public int UID;
        public int FKClientDocumentUID;
        public int FKClientUID;         //
        public int ClientIssueNumber;   // 03 - This is the version number of the client
        public int SourceIssueNumber;   // 01
        public string IssueNumberText;  // 03 - This is the version number of the client in text
        public string Location;         // %LOCATION%\TEST\TEST
        public string FileName;         // POL-05-01-0001-01 FILENAME.DOC
        public string ComboIssueNumber; // POL-05-01-0002-03
        public string DocumentCUID;     // POL-05-01

        // -----------------------------------------------------
        //    Get Client details
        // -----------------------------------------------------
        public bool Read()
        {
            // 
            // EA SQL database
            // 
            bool ret = false;

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {
                var commandString = string.Format(
                " SELECT UID " +
                "       ,FKClientDocumentUID " +
                "       ,DocumentCUID " +
                "       ,FKClientUID " +
                "       ,IssueNumberText " +
                "       ,ClientIssueNumber " +
                "       ,SourceIssueNumber " +
                "       ,Location " +
                "       ,FileName " +
                "       ,ComboIssueNumber " +
                "  FROM ClientDocumentVersion" +
                " WHERE CUID = '{0}'", this.UID);

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        try
                        {
                            this.UID = Convert.ToInt32( reader["UID"].ToString());
                            this.FKClientDocumentUID = Convert.ToInt32(reader["FKClientDocumentUID"].ToString());
                            this.FKClientUID = Convert.ToInt32(reader["FKClientUID"].ToString());
                            this.IssueNumberText = reader["IssueNumberText"].ToString();
                            this.ClientIssueNumber = Convert.ToInt32(reader["ClientIssueNumber"].ToString());
                            this.SourceIssueNumber = Convert.ToInt32(reader["SourceIssueNumber"].ToString());
                            this.Location = reader["Location"].ToString();
                            this.FileName = reader["FileName"].ToString();
                            this.ComboIssueNumber = reader["ComboIssueNumber"].ToString();
                            ret = true;
                        }
                        catch (Exception)
                        {
                            UID = 0;
                        }
                    }
                }
            }
            return ret;
        }

        // -----------------------------------------------------
        //   Retrieve last Document Set id
        // -----------------------------------------------------
        private int GetLastUID()
        {
            int LastUID = 0;

            // 
            // EA SQL database
            // 

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {
                var commandString =
                    "SELECT MAX(UID) LASTUID FROM ClientDocumentVersion";

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

        // -----------------------------------------------------
        //    Add new Issue
        // -----------------------------------------------------
        public void Add()
        {

            string ret = "Item updated successfully";

            int _uid = 0;

            _uid = GetLastUID() + 1;

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {

                var commandString =
                (
                   "INSERT INTO ClientDocumentVersion " +
                   " ( " +
                   " UID " +
                   ",FKClientDocumentUID " +
                   ",FKClientUID " +
                   ",IssueNumberText" +
                   ",ComboIssueNumber" +
                   ",ClientIssueNumber" +
                   ",SourceIssueNumber" +
                   ",Location" +
                   ",FileName" +
                   ")" +
                        " VALUES " +
                   " ( " +
                   "  @UID    " +
                   ", @FKClientDocumentUID  " +
                   ", @FKClientUID  " +
                   ", @IssueNumberText " +
                   ", @ComboIssueNumber " +
                   ", @ClientIssueNumber " +
                   ", @SourceIssueNumber " +
                   ", @Location " +
                   ", @FileName " +
                   " ) "
                   );

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {
                    command.Parameters.Add("@UID", MySqlDbType.Int32).Value = _uid;
                    command.Parameters.Add("@FKClientDocumentUID", MySqlDbType.Int32).Value = FKClientDocumentUID;
                    command.Parameters.Add("@FKClientUID", MySqlDbType.Int32).Value = FKClientUID;
                    command.Parameters.Add("@IssueNumberText", MySqlDbType.VarChar).Value = IssueNumberText;
                    command.Parameters.Add("@ComboIssueNumber", MySqlDbType.VarChar).Value = ComboIssueNumber;
                    command.Parameters.Add("@ClientIssueNumber", MySqlDbType.Decimal).Value = ClientIssueNumber;
                    command.Parameters.Add("@SourceIssueNumber", MySqlDbType.VarChar).Value = SourceIssueNumber;
                    command.Parameters.Add("@Location", MySqlDbType.VarChar).Value = Location;
                    command.Parameters.Add("@FileName", MySqlDbType.VarChar).Value = FileName;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            return;
        }
    }
}
