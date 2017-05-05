using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using FCMMySQLBusinessLibrary.Model.ModelClient;
using MackkadoITFramework.Utils;
using MySql.Data.MySqlClient;

namespace FCMMySQLBusinessLibrary.Repository.RepositoryClient
{
    public class RepClientEmail : ClientEmail
    {
        // -----------------------------------------------------
        //    List clients
        // -----------------------------------------------------
        public static List<ClientEmail> List(string groupType)
        {
            var clientEmailList  = new List<ClientEmail>();

            if (string.IsNullOrEmpty(groupType))
                return new List<ClientEmail>();

            using (var connection = new MySqlConnection( ConnString.ConnectionString ))
            {

                var commandString = string.Format(
                " SELECT " +
                "  UID " +
                ", FirstName " +
                ", LastName " +
                ", EmailAddress " +
                ", Type " +
                "   FROM ClientEmail " +
                "   WHERE (EmailSent is null or EmailSent = '') and Type = @groupType" +
                "  ORDER BY UID ASC " 
                );

                using (var command = new MySqlCommand(
                                      commandString, connection ))
                {
                    command.Parameters.Add("@groupType", MySqlDbType.VarChar).Value = groupType;

                    connection.Open();

                    try
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var clientEmail = new ClientEmail();

                                clientEmail.UID = Convert.ToInt32(reader["UID"]);
                                clientEmail.FirstName = reader["FirstName"].ToString();
                                clientEmail.LastName = reader["LastName"].ToString();
                                clientEmail.EmailAddress = reader["EmailAddress"].ToString();
                                clientEmail.Type = reader["Type"].ToString();

                                clientEmailList.Add(clientEmail);

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        string error = ex.ToString();
                        LogFile.WriteToTodaysLogFile(ex.ToString(), "", "", "ClientEmail.cs");

                    }
                }
            }

            return clientEmailList;
        }

        // -----------------------------------------------------
        //    List clients
        // -----------------------------------------------------
        public static List<ClientEmail> ListCertificates(string groupType)
        {
            var clientEmailList = new List<ClientEmail>();

            string certType = "Cert";

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {

                var commandString = string.Format(
                " SELECT " +
                "  UID " +
                ", FirstName " +
                ", LastName " +
                ", EmailAddress " +
                ", Type " +
                ", Document" +
                ", CertificateType " +
                "   FROM ClientEmail, temp_emailattach" +
                "   WHERE  " +
                "   FKEmailClientID = SecID and "  +
                "   Type = @groupType and CertificateType = @certType " +
                "  ORDER BY UID ASC "
                );

                using (var command = new MySqlCommand(
                                      commandString, connection))
                {
                    command.Parameters.Add("@groupType", MySqlDbType.VarChar).Value = groupType;
                    command.Parameters.Add("@certType", MySqlDbType.VarChar).Value = certType;

                    connection.Open();

                    try
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var clientEmail = new ClientEmail();

                                clientEmail.UID = Convert.ToInt32(reader["UID"]);
                                clientEmail.FirstName = reader["FirstName"].ToString();
                                clientEmail.LastName = reader["LastName"].ToString();
                                clientEmail.EmailAddress = reader["EmailAddress"].ToString();
                                clientEmail.Type = reader["Type"].ToString();
                                clientEmail.Attachment = reader["Document"].ToString();
                                clientEmail.CertificateType = reader["CertificateType"].ToString();

                                clientEmailList.Add(clientEmail);

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        string error = ex.ToString();
                        LogFile.WriteToTodaysLogFile(ex.ToString(), "", "", "ClientEmail.cs");

                    }
                }
            }

            return clientEmailList;
        }



        //
        // Set void flag
        //
        public static void UpdateToEmailSent(int clientEmailUID)
        {
            string ret = "Item updated successfully";

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {

                var commandString =
                (
                   "UPDATE ClientEmail " +
                   " SET " +
                   " EmailSent = @EmailSent" +
                   "  WHERE  " +
                   "        UID = @UID   " 
                );

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {

                    command.Parameters.Add("@UID", MySqlDbType.Int32).Value = clientEmailUID;
                    command.Parameters.Add("@EmailSent", MySqlDbType.VarChar).Value = 'Y';

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
