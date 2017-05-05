using System;
using MackkadoITFramework.Utils;
using MySql.Data.MySqlClient;

namespace FCMMySQLBusinessLibrary.Model.ModelDocument
{
    public class DocumentLink
    {
        public int UID;
        public int FKParentDocumentUID;
        public int FKChildDocumentUID;
        public string LinkType;
        public Model.ModelDocument.Document documentFrom;
        public Model.ModelDocument.Document documentTo;

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
                    "SELECT MAX(UID) LASTUID FROM DocumentLink";

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
        //    Add new Link
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
                   "INSERT INTO DocumentLink " +
                   " ( " +
                   " UID " +
                   ",FKParentDocumentUID " +
                   ",FKChildDocumentUID" +
                   ",LinkType" +
                   ",IsVoid" +
                   ")" +
                        " VALUES " +
                   " ( " +
                   "  @UID    " +
                   ", @FKParentDocumentUID " +
                   ", @FKChildDocumentUID " +
                   ", @LinkType " +
                   ", @IsVoid" +
                   " ) "
                   );

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {
                    command.Parameters.Add("@UID", MySqlDbType.Int32).Value = _uid;
                    command.Parameters.Add("@FKParentDocumentUID", MySqlDbType.Int32).Value = FKParentDocumentUID;
                    command.Parameters.Add("@FKChildDocumentUID", MySqlDbType.Int32).Value = FKChildDocumentUID;
                    command.Parameters.Add("@LinkType", MySqlDbType.VarChar).Value = LinkType;
                    command.Parameters.Add("@IsVoid", MySqlDbType.VarChar).Value = 'N';

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            return;
        }

        // -----------------------------------------------------
        // Logical Delete
        // -----------------------------------------------------
        public void Delete(int UID)
        {
            string ret = "Item updated successfully";

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {

                var commandString =
                (
                   "UPDATE DocumentLink " +
                   " SET " +
                   " IsVoid = @IsVoid" +
                   " WHERE UID = @UID "
                );

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {
                    command.Parameters.Add("@UID", MySqlDbType.Int32).Value = UID;
                    command.Parameters.Add("@IsVoid", MySqlDbType.VarChar).Value = 'Y';

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            return;
        }

        // -----------------------------------------------------
        //    Save Links
        // -----------------------------------------------------
        public static void LinkDocuments(int ParentID, int ChildID, string LinkType)
        {
            DocumentLink findOne = new DocumentLink();
            if (findOne.Read(ParentID, ChildID, LinkType))
            {
                // Already exists
            }
            else
            {
                findOne.LinkType = LinkType;
                findOne.FKParentDocumentUID = ParentID;
                findOne.FKChildDocumentUID = ChildID;

                findOne.Add();
            }

        }

        // -----------------------------------------------------
        //    Get Link details
        // -----------------------------------------------------
        public bool Read(int ParentID, int ChildID, string LinkType)
        {
            // 
            // EA SQL database
            // 
            bool ret = false;

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {
                var commandString = string.Format(
                " SELECT UID " +
                "       ,FKParentDocumentUID " +
                "       ,FKChildDocumentUID " +
                "       ,LinkType " +
                "  FROM DocumentLink" +
                " WHERE IsVoid = 'N' " +
                "   AND FKParentDocumentUID = '{0}'" +
                "   AND FKChildDocumentUID   = '{1}'" +
                "   AND LinkType = '{2}' ",
                ParentID,
                ChildID,
                LinkType);

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
                            this.FKParentDocumentUID = Convert.ToInt32(reader["FKParentDocumentUID"].ToString());
                            this.FKChildDocumentUID = Convert.ToInt32(reader["FKChildDocumentUID"].ToString());
                            this.LinkType = reader["LinkType"].ToString();
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
        //    Get Link details
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
                "       ,FKParentDocumentUID " +
                "       ,FKChildDocumentUID " +
                "       ,LinkType " +
                "  FROM DocumentLink" +
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
                            this.UID = Convert.ToInt32(reader["UID"].ToString());
                            this.FKParentDocumentUID = Convert.ToInt32(reader["FKParentDocumentUID "].ToString());
                            this.FKChildDocumentUID = Convert.ToInt32(reader["FKChildDocumentUID"].ToString());
                            this.LinkType = reader["LinkType"].ToString();
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
    }
}
