using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using FCMMySQLBusinessLibrary.Model.ModelClientDocument;
using FCMMySQLBusinessLibrary.Repository.RepositoryDocument;
using MackkadoITFramework.ReferenceData;
using MackkadoITFramework.Utils;
using FCMMySQLBusinessLibrary.FCMUtils;
using MackkadoITFramework.ErrorHandling;
using MySql.Data.MySqlClient;
using System.IO;

namespace FCMMySQLBusinessLibrary.Repository.RepositoryClientDocument
{
    public class RepClientDocument: ClientDocument
    {
        private RepClientDocument()
        {
            clientDocumentSet = new ClientDocumentSet();
        }

        /// <summary>
        /// Retrieve client document
        /// </summary>
        /// <param name="clientDocumentUid"></param>
        /// <returns></returns>
        internal static ClientDocument Read(int clientDocumentUid)
        {

            var clientDocument = new ClientDocument();
            bool ret = false;

            using ( var connection = new MySqlConnection( ConnString.ConnectionString ) )
            {
                var commandString = string.Format(
                " SELECT " +
                  SQLConcat( "CD" ) +
                "  FROM ClientDocument CD" +
                " WHERE CD.UID = {0} "
                , clientDocumentUid
                );

                using ( var command = new MySqlCommand(
                                            commandString, connection ) )
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    if ( reader.Read() )
                    {
                        clientDocument.UID = Convert.ToInt32( reader ["CDUID"].ToString() );
                        clientDocument.FKClientUID = Convert.ToInt32( reader ["CDFKClientUID"].ToString() );
                        clientDocument.DocumentCUID = reader ["CDDocumentCUID"].ToString();
                        clientDocument.ParentUID = Convert.ToInt32( reader ["CDParentUID"].ToString() );
                        clientDocument.FKDocumentUID = Convert.ToInt32( reader ["CDFKDocumentUID"].ToString() );
                        clientDocument.SourceIssueNumber = Convert.ToInt32( reader ["CDSourceIssueNumber"].ToString() );
                        clientDocument.ClientIssueNumber = Convert.ToInt32( reader ["CDClientIssueNumber"].ToString() );
                        clientDocument.FKClientDocumentSetUID = Convert.ToInt32( reader ["CDFKClientDocumentSetUID"].ToString() );
                        clientDocument.SequenceNumber = Convert.ToInt32( reader ["CDSequenceNumber"].ToString() );
                        clientDocument.SourceLocation = reader ["CDSourceLocation"].ToString();
                        clientDocument.SourceFileName = reader ["CDSourceFileName"].ToString();
                        clientDocument.Location = reader ["CDLocation"].ToString();
                        clientDocument.FileName = reader ["CDFileName"].ToString();
                        clientDocument.StartDate = Convert.ToDateTime( reader ["CDStartDate"].ToString() );

                        try
                        {
                            clientDocument.EndDate = Convert.ToDateTime( reader ["CDEndDate"].ToString() );
                        }
                        catch ( Exception )
                        {
                            clientDocument.EndDate = DateTime.MaxValue;
                        }

                        clientDocument.IsVoid = Convert.ToChar( reader ["CDIsVoid"] );
                        clientDocument.IsLocked = Convert.ToChar( reader ["CDIsLocked"] );
                        clientDocument.IsProjectPlan = reader ["CDIsProjectPlan"].ToString();
                        clientDocument.DocumentType = reader ["CDDocumentType"].ToString();
                        clientDocument.RecordType = reader ["CDRecordType"].ToString();

                    }
                }
            }

            // -----------------------------------------
            //       Populate client document set
            // -----------------------------------------
            clientDocument.clientDocumentSet.UID = clientDocument.FKClientDocumentSetUID;
            clientDocument.FKClientUID = clientDocument.FKClientUID;
            clientDocument.clientDocumentSet.Read();

            return clientDocument;
        }

        /// <summary>
        /// Retrieve client document
        /// </summary>
        /// <param name="clientDocumentUid"></param>
        /// <returns></returns>
        internal static ClientDocument GetRoot( int clientUID, int documentSetUID )
        {

            var clientDocument = new ClientDocument();
            bool ret = false;

            using ( var connection = new MySqlConnection( ConnString.ConnectionString ) )
            {
                var commandString = 
                " SELECT " +
                  SQLConcat( "CD" ) +
                "  FROM ClientDocument CD" +
                " WHERE CD.DocumentCUID = @DocumentCUID "+
                " AND   CD.FKClientUID = @FKClientUID " +
                " AND   CD.FKClientDocumentSetUID = @FKClientDocumentSetUID ";

                using ( var command = new MySqlCommand(
                                            commandString, connection ) )
                {

                    command.Parameters.Add( "@DocumentCUID", MySqlDbType.VarChar ).Value = "ROOT";
                    command.Parameters.Add( "@FKClientUID", MySqlDbType.Int32 ).Value = clientUID;
                    command.Parameters.Add( "@FKClientDocumentSetUID", MySqlDbType.Int32 ).Value = documentSetUID;

                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    if ( reader.Read() )
                    {
                        clientDocument.UID = Convert.ToInt32( reader ["CDUID"].ToString() );
                        clientDocument.FKClientUID = Convert.ToInt32( reader ["CDFKClientUID"].ToString() );
                        clientDocument.DocumentCUID = reader ["CDDocumentCUID"].ToString();
                        clientDocument.ParentUID = Convert.ToInt32( reader ["CDParentUID"].ToString() );
                        clientDocument.FKDocumentUID = Convert.ToInt32( reader ["CDFKDocumentUID"].ToString() );
                        clientDocument.SourceIssueNumber = Convert.ToInt32( reader ["CDSourceIssueNumber"].ToString() );
                        clientDocument.ClientIssueNumber = Convert.ToInt32( reader ["CDClientIssueNumber"].ToString() );
                        clientDocument.FKClientDocumentSetUID = Convert.ToInt32( reader ["CDFKClientDocumentSetUID"].ToString() );
                        clientDocument.SequenceNumber = Convert.ToInt32( reader ["CDSequenceNumber"].ToString() );
                        clientDocument.SourceLocation = reader ["CDSourceLocation"].ToString();
                        clientDocument.SourceFileName = reader ["CDSourceFileName"].ToString();
                        clientDocument.Location = reader ["CDLocation"].ToString();
                        clientDocument.FileName = reader ["CDFileName"].ToString();
                        clientDocument.StartDate = Convert.ToDateTime( reader ["CDStartDate"].ToString() );

                        try
                        {
                            clientDocument.EndDate = Convert.ToDateTime( reader ["CDEndDate"].ToString() );
                        }
                        catch ( Exception )
                        {
                            clientDocument.EndDate = DateTime.MaxValue;
                        }

                        clientDocument.IsVoid = Convert.ToChar( reader ["CDIsVoid"] );
                        clientDocument.IsLocked = Convert.ToChar( reader ["CDIsLocked"] );
                        clientDocument.IsProjectPlan = reader ["CDIsProjectPlan"].ToString();
                        clientDocument.DocumentType = reader ["CDDocumentType"].ToString();
                        clientDocument.RecordType = reader ["CDRecordType"].ToString();

                    }
                }
            }

            // -----------------------------------------
            //       Populate client document set
            // -----------------------------------------
            clientDocument.clientDocumentSet.UID = clientDocument.FKClientDocumentSetUID;
            clientDocument.FKClientUID = clientDocument.FKClientUID;
            clientDocument.clientDocumentSet.Read();

            return clientDocument;
        }


        /// <summary>
        /// Get Document for a client. This method locates a ClientDocument using DocumentUID
        /// </summary>
        /// <param name="documentUID"></param>
        /// <param name="clientDocSetUID"></param>
        /// <param name="voidRead"></param>
        /// <param name="clientUID"> </param>
        /// <returns></returns>
        internal static ClientDocument Find( int documentUID,
                    int clientDocSetUID,
                    char voidRead,
                    int clientUID)
        {
            // 
            // EA SQL database
            // 
            bool ret = false;

            ClientDocument clientDocument = new ClientDocument();

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {
                var commandString = string.Format(
                " SELECT "+
                  SQLConcat("CD") +
                "  FROM ClientDocument CD" +
                " WHERE CD.FKDocumentUID = {0} " +
                " AND   CD.FKClientDocumentSetUID = {1} " +
                " AND   CD.IsVoid = '{2}' " +
                " AND   CD.FKClientUID = {3} "
                , documentUID
                , clientDocSetUID
                , voidRead
                , clientUID);

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        clientDocument.UID = Convert.ToInt32( reader ["CDUID"].ToString() );
                        clientDocument.FKDocumentUID = Convert.ToInt32( reader ["CDFKDocumentUID"].ToString() );
                        clientDocument.SequenceNumber = Convert.ToInt32( reader ["CDSequenceNumber"].ToString() );
                        clientDocument.FKClientDocumentSetUID = Convert.ToInt32( reader ["CDFKClientDocumentSetUID"].ToString() );
                        clientDocument.StartDate = Convert.ToDateTime( reader ["CDStartDate"].ToString() );

                        // Tentar....
                        //this.EndDate = (reader.IsDBNull(10) ? DateTime.MaxValue : Convert.ToDateTime(reader["CDEndDate"].ToString()));

                        // instead if this...

                        try
                        {
                            clientDocument.EndDate = Convert.ToDateTime( reader ["CDEndDate"].ToString() );
                        }
                        catch (Exception)
                        {
                            clientDocument.EndDate = DateTime.MaxValue;
                        }

                        clientDocument.IsVoid = Convert.ToChar( reader ["CDIsVoid"] );

                        ret = true;
                    }
                }
            }
            return clientDocument;

        }

        // -----------------------------------------------------
        //    Associate documents with document set
        // -----------------------------------------------------
        internal void LinkDocumentListToSet( ListOfscClientDocSetDocLink docListToLink )
        {
            // for each document in the list
            // check if it is already linked with document set
            // if it is not linked, add a new link record
            // otherwise, ignore link.

            foreach (var doco in docListToLink.list)
            {
                LinkDocumentToClientSet(doco);
            }
        }


        // -----------------------------------------------------
        //    Associate documents with document set
        // -----------------------------------------------------
        internal static int LinkDocumentToClientSet( scClientDocSetDocLink doco )
        {
            int clientDocumentUID = 0;

            var dslLocate = new ClientDocument();
            dslLocate.StartDate = DateTime.Today;
            dslLocate.IsVoid = 'N';
            dslLocate.IsLocked = 'N';
            dslLocate.IsProjectPlan = doco.clientDocument.IsProjectPlan;
            dslLocate.DocumentType = doco.clientDocument.DocumentType;
            dslLocate.FKDocumentUID = doco.document.UID;
            dslLocate.FKClientDocumentSetUID = doco.clientDocumentSet.UID;
            dslLocate.FKClientUID = doco.clientDocumentSet.FKClientUID;
            dslLocate.DocumentCUID = doco.clientDocument.DocumentCUID;
            dslLocate.SourceLocation = doco.clientDocument.SourceLocation;
            dslLocate.SourceFileName = doco.clientDocument.SourceFileName;
            dslLocate.Location = doco.clientDocument.Location;
            dslLocate.FileName = doco.clientDocument.FileName;
            dslLocate.SequenceNumber = doco.clientDocument.SequenceNumber;
            dslLocate.SourceIssueNumber = doco.clientDocument.SourceIssueNumber;
            dslLocate.Generated = 'N';
            dslLocate.ParentUID = doco.clientDocument.ParentUID;
            dslLocate.RecordType = doco.clientDocument.RecordType;
            dslLocate.IsRoot = doco.clientDocument.IsRoot;
            dslLocate.IsFolder = doco.clientDocument.IsFolder;

            // Prepare data to add or update
            var dslAddUpdate = new ClientDocument();
            dslAddUpdate.StartDate = DateTime.Today;
            dslAddUpdate.IsVoid = 'N';
            dslAddUpdate.IsLocked = 'N';
            dslAddUpdate.IsProjectPlan = doco.clientDocument.IsProjectPlan;
            dslAddUpdate.DocumentType = doco.clientDocument.DocumentType;
            dslAddUpdate.FKDocumentUID = doco.document.UID;
            dslAddUpdate.FKClientDocumentSetUID = doco.clientDocumentSet.UID;
            dslAddUpdate.FKClientUID = doco.clientDocumentSet.FKClientUID;
            dslAddUpdate.DocumentCUID = doco.clientDocument.DocumentCUID;
            dslAddUpdate.SourceLocation = doco.clientDocument.SourceLocation;
            dslAddUpdate.SourceFileName = doco.clientDocument.SourceFileName;

            dslAddUpdate.Location = doco.clientDocument.Location;

            if (dslAddUpdate.DocumentType == "FOLDER")
            {
                if ( dslAddUpdate.IsRoot == 'Y')
                    dslAddUpdate.FileName = doco.clientDocument.FileName;
                else
                    dslAddUpdate.FileName = doco.document.FileName;
            }

            else
                dslAddUpdate.FileName = doco.clientDocument.FileName;

            
            dslAddUpdate.SequenceNumber = doco.clientDocument.SequenceNumber;
            dslAddUpdate.SourceIssueNumber = doco.clientDocument.SourceIssueNumber;
            dslAddUpdate.ClientIssueNumber = 0;
            dslAddUpdate.ComboIssueNumber = doco.clientDocument.ComboIssueNumber;
            dslAddUpdate.Generated = 'N';
            dslAddUpdate.ParentUID = doco.clientDocument.ParentUID;
            dslAddUpdate.RecordType = doco.clientDocument.RecordType;
            dslAddUpdate.IsRoot = doco.clientDocument.IsRoot;
            dslAddUpdate.IsFolder = doco.clientDocument.IsFolder;

            dslLocate = Find(doco.document.UID, doco.clientDocumentSet.UID, 'N',
                                               doco.clientDocumentSet.FKClientUID);


            if ( dslLocate.UID > 0 )
            {
                // Fact: There is an existing non-voided row
                // Intention (1): Make it void
                // Intention (2): Do nothing
                //

                // Check for Intention (1)
                //
                if (doco.clientDocument.IsVoid == 'Y')
                {
                    // Update row to make it voided...
                    //
                    SetToVoid( Utils.ClientID, doco.clientDocumentSet.UID, doco.clientDocument.UID );

                }
                else
                {
                    // Update details
                    //
                    dslAddUpdate.UID = doco.clientDocument.UID;

                    Update(dslAddUpdate);
                    // dslAddUpdate.Update();

                    clientDocumentUID = doco.clientDocument.UID;
                }

            }
            else
            {

                // if the pair does not exist, check if it is void.
                // If void = Y, just ignore.

                if (doco.clientDocument.IsVoid == 'Y')
                {
                    // just ignore. The pair was not saved initially.
                }
                else
                {
                    // add document to set

                    //clientDocumentUID = dslAddUpdate.Add();

                    clientDocumentUID = Add( dslAddUpdate );

                }
            }

            return clientDocumentUID;
        }

        /// <summary>
        /// Calculate the number of documents in the set
        /// </summary>
        /// <param name="clientUID"> </param>
        /// <param name="clientDocumentSetUID"> </param>
        /// <returns></returns>
        internal static int GetNumberOfDocuments( int clientUID, int clientDocumentSetUID )
        {
            int DocoCount = 0;

            // 
            // EA SQL database
            // 

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {
                var commandString =
                    "SELECT COUNT(*) SETCOUNT FROM ClientDocument" +
                    " WHERE FKClientUID = " + clientUID +
                    "   AND FKClientDocumentSetUID  = " + clientDocumentSetUID
                    ;

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        try
                        {
                            DocoCount = Convert.ToInt32(reader["SETCOUNT"]);
                        }
                        catch (Exception)
                        {
                            DocoCount = 0;
                        }
                    }
                }
            }

            return DocoCount;
        }

        /// <summary>
        /// This method returns the complete logical path of a given Client Document.
        /// It walk through the structure, up, and then comes down
        /// It requires the root to be correctly set.
        /// </summary>
        /// <param name="clientDocument"></param>
        /// <returns></returns>
        internal static ResponseStatus GetDocumentPath( ClientDocument clientDocument )
        {
            var rs = new ResponseStatus();
            var clientDocList = new List<ClientDocument>();

            string documentPath = "";

            // If root is supplied, return location
            //
            if (clientDocument.IsRoot == 'Y')
            {
                // documentPath = clientDocument.Location;
                documentPath = "%CLIENTFOLDER%";
                rs.Contents = documentPath;
                return rs;
            }

            int currentClientID = clientDocument.UID;

            int count = currentClientID;

            // walk up until it finds the root
            // 
            while (currentClientID > 0)
            {
                var client = Read( currentClientID );

                if (client == null)
                    break;
                if (client.RecordType == null)
                    break;

                clientDocList.Add(client);

                currentClientID = client.ParentUID;
            }

            // walk down building the path
            //
            for (int x = clientDocList.Count - 1;x > 0;x--)
            {
                var doco = clientDocList[x];
                if (doco.IsRoot == 'Y')
                {
                    documentPath = doco.Location + @"\" + doco.FileName;
                }
                else
                {
                    if (doco.IsFolder == 'Y')
                        documentPath = documentPath + @"\" + doco.FileName;
                }
            }


            rs.Contents = documentPath;

            return rs;
        }


        // -----------------------------------------------------
        //          Retrieve last Client UID
        // -----------------------------------------------------
        private static int GetLastUID()
        {
            int LastUID = 0;

            // 
            // EA SQL database
            // 

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {
                var commandString = "SELECT MAX(UID) LASTUID FROM ClientDocument";

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
        //        Retrieve last document id for a client
        // -----------------------------------------------------
        internal static int GetLastClientCUID( int clientUID )
        {
            int LastUID = 0;

            // 
            // EA SQL database
            // 

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {
                var commandString = "SELECT count(*) CNTCLIENT FROM Document WHERE FKClientUID = " + clientUID.ToString();

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        try
                        {
                            LastUID = Convert.ToInt32(reader["CNTCLIENT"]);
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
        //          Retrieve Unlink Document
        // -----------------------------------------------------
        internal void UnlinkDocument( ClientDocument clientDocument )
        {
            // This method deletes a document set link
            //

            // 1) Look for connection that is not voided
            // 2) Update the IsVoid flag to "Y"; EndDate to Today

            string ret = "Item updated successfully";

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {

                var commandString =
                (
                   "UPDATE ClientDocument " +
                   " SET " +
                   " EndDate = @EndDate" +
                   ",IsVoid = @IsVoid " +
                   " WHERE UID = @UID "
                );

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {
                    command.Parameters.Add("@UID", MySqlDbType.VarChar).Value = UID;
                    command.Parameters.Add("@EndDate", MySqlDbType.DateTime).Value = DateTime.Today;
                    command.Parameters.Add("@IsVoid", MySqlDbType.VarChar).Value = 'Y';

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            return;
        }

        // -----------------------------------------------------
        //    Add root folder for client
        // -----------------------------------------------------
        internal static void AddRootFolder( ClientDocument clientDocument, int clientUID, int DocSetUID, string DestinationFolder )
        {
            clientDocument.RecordType = "FOLDER";
            clientDocument.ParentUID = 0;
            clientDocument.DocumentCUID = "ROOT";
            clientDocument.FKClientDocumentSetUID = DocSetUID;
            clientDocument.FKClientUID = clientUID;
            clientDocument.FKDocumentUID = 1;
            clientDocument.FileName = DestinationFolder;
            clientDocument.Location = FCMConstant.SYSFOLDER.CLIENTFOLDER;
            clientDocument.Generated = 'N';
            clientDocument.SourceIssueNumber = 1;
            clientDocument.SourceFileName = "Folder Source File Name";
            clientDocument.SourceLocation = "Folder Source File Location";
            clientDocument.StartDate = System.DateTime.Today;
            clientDocument.EndDate = System.DateTime.MaxValue;
            clientDocument.IsVoid = 'N';
            clientDocument.IsLocked = 'N';
            clientDocument.IsProjectPlan = "N";
            clientDocument.DocumentType = MackkadoITFramework.Helper.Utils.DocumentType.FOLDER;
            clientDocument.ComboIssueNumber = "Root";
            Add( clientDocument );

        }

        // -----------------------------------------------------
        //    Fix root folder for client
        // -----------------------------------------------------
        internal static void FixRootFolder( int clientUID, int DocSetUID)
        {
            ClientDocument clientDocument = GetRoot( clientUID, DocSetUID );
            if ( clientDocument.UID < 0 )
            {
                LogFile.WriteToTodaysLogFile("RepClientDocument.FixRootFolder: Root is empty.");
                return;
            }

            clientDocument.RecordType = "FOLDER";
            clientDocument.ParentUID = 0;
            clientDocument.DocumentCUID = "ROOT";
            clientDocument.FKClientDocumentSetUID = DocSetUID;
            clientDocument.FKClientUID = clientUID;
            clientDocument.FKDocumentUID = 1;
            clientDocument.FileName = "CLIENT"+clientUID.ToString("000000000")+"SET"+DocSetUID.ToString("0000");
            clientDocument.Location = FCMConstant.SYSFOLDER.CLIENTFOLDER;
            clientDocument.Generated = 'N';
            clientDocument.SourceIssueNumber = 1;
            clientDocument.SourceFileName = "Folder Source File Name";
            clientDocument.SourceLocation = "Folder Source File Location";
            clientDocument.StartDate = System.DateTime.Today;
            clientDocument.EndDate = System.DateTime.MaxValue;
            clientDocument.IsVoid = 'N';
            clientDocument.IsLocked = 'N';
            clientDocument.IsProjectPlan = "N";
            clientDocument.DocumentType = MackkadoITFramework.Helper.Utils.DocumentType.FOLDER;
            clientDocument.ComboIssueNumber = "Root";
            Update( clientDocument );

        }



        // -----------------------------------------------------
        //    Prepare root folder for client
        // -----------------------------------------------------
        internal void PrepareRootFolder( int clientUID, int DocSetUID, string DestinationFolder )
        {
            this.RecordType = "FOLDER";
            this.ParentUID = 0;
            this.DocumentCUID = "ROOT";
            this.FKClientDocumentSetUID = DocSetUID;
            this.FKClientUID = clientUID;
            this.FKDocumentUID = 1;
            this.FileName = DestinationFolder;
            this.Location = FCMConstant.SYSFOLDER.CLIENTFOLDER;
            this.Generated = 'N';
            this.SourceIssueNumber = 1;
            this.SourceFileName = "Folder Source File Name";
            this.SourceLocation = "Folder Source File Location";
            this.StartDate = System.DateTime.Today;
            this.EndDate = System.DateTime.MaxValue;
            this.IsVoid = 'N';
            this.IsLocked = 'N';
            this.IsProjectPlan = "N";
            this.DocumentType = MackkadoITFramework.Helper.Utils.DocumentType.FOLDER;
            this.ComboIssueNumber = "Root";
        }

        // -----------------------------------------------------
        //    Add new Client Document
        // -----------------------------------------------------
        internal static int Add( ClientDocument clientDocument )
        {

            string ret = "Client Document Added Successfully";
            int _uid = 0;

            _uid = GetLastUID() + 1;

            // Default values
            DateTime _now = DateTime.Today;

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {

                var commandString =
                (

                   "INSERT INTO ClientDocument " +
                   "( UID, " +
                   "  FKClientUID, " +
                   "  FKClientDocumentSetUID, " +
                   "  FKDocumentUID, " +
                   "  DocumentCUID, " +
                   "  SequenceNumber, " +
                   "  SourceLocation, " +
                   "  SourceFileName, " +
                   "  Location, " +
                   "  FileName, " +
                   "  StartDate, " +
                   "  EndDate, " +
                   "  IsVoid, " +
                   "  IsLocked, " +
                   "  IsProjectPlan, " +
                   "  DocumentType, " +
                   "  Generated, " +
                   "  SourceIssueNumber, " +
                   "  ClientIssueNumber, " +
                   "  ComboIssueNumber, " +
                   "  ParentUID, " +
                   "  RecordType, " +
                   "  IsRoot, " +
                   "  IsFolder " +
                   ")" +
                        " VALUES " +
                   "( @UID     " +
                   ", @FKClientUID    " +
                   ", @FKClientDocumentSetUID " +
                   ", @FKDocumentUID " +
                   ", @DocumentCUID " +
                   ", @SequenceNumber " +
                   ", @SourceLocation " +
                   ", @SourceFileName " +
                   ", @Location " +
                   ", @FileName " +
                   ", @StartDate " +
                   ", @EndDate " +
                   ", @IsVoid " +
                   ", @IsLocked " +
                   ", @IsProjectPlan " +
                   ", @DocumentType " +
                   ", @Generated " +
                   ", @SourceIssueNumber " +
                   ", @ClientIssueNumber " +
                   ", @ComboIssueNumber " +
                   ", @ParentUID " +
                   ", @RecordType " +
                   ", @IsRoot " +
                   ", @IsFolder " +
                   ")"
                   );

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {
                    command.Parameters.Add("@UID", MySqlDbType.Int32).Value = _uid;
                    command.Parameters.Add( "@FKClientUID", MySqlDbType.Int32 ).Value = clientDocument.FKClientUID;
                    command.Parameters.Add( "@FKClientDocumentSetUID", MySqlDbType.Int32 ).Value = clientDocument.FKClientDocumentSetUID;
                    command.Parameters.Add( "@FKDocumentUID", MySqlDbType.Int32 ).Value = clientDocument.FKDocumentUID;
                    command.Parameters.Add( "@SequenceNumber", MySqlDbType.Int32 ).Value = clientDocument.SequenceNumber;
                    command.Parameters.Add( "@SourceLocation", MySqlDbType.VarChar ).Value = ( string.IsNullOrEmpty( clientDocument.SourceLocation ) ) ? " " : clientDocument.SourceLocation;
                    command.Parameters.Add( "@DocumentCUID", MySqlDbType.VarChar ).Value = ( string.IsNullOrEmpty( clientDocument.DocumentCUID ) ) ? " " : clientDocument.DocumentCUID;
                    command.Parameters.Add( "@SourceFileName", MySqlDbType.VarChar ).Value = ( string.IsNullOrEmpty( clientDocument.SourceFileName ) ) ? " " : clientDocument.SourceFileName;
                    command.Parameters.Add( "@Location", MySqlDbType.VarChar ).Value = ( string.IsNullOrEmpty( clientDocument.Location ) ) ? " " : clientDocument.Location;
                    command.Parameters.Add( "@FileName", MySqlDbType.VarChar ).Value = ( string.IsNullOrEmpty( clientDocument.FileName ) ) ? " " : clientDocument.FileName;
                    command.Parameters.Add("@StartDate", MySqlDbType.DateTime).Value = _now;
                    command.Parameters.AddWithValue("@EndDate", "9999-12-31");
                    command.Parameters.Add( "@IsVoid", MySqlDbType.VarChar ).Value = clientDocument.IsVoid;
                    command.Parameters.Add( "@IsLocked", MySqlDbType.VarChar ).Value = clientDocument.IsLocked;
                    command.Parameters.Add( "@IsProjectPlan", MySqlDbType.VarChar ).Value = clientDocument.IsProjectPlan;
                    command.Parameters.Add( "@DocumentType", MySqlDbType.VarChar ).Value = clientDocument.DocumentType;
                    command.Parameters.Add( "@Generated", MySqlDbType.VarChar ).Value = clientDocument.Generated;
                    command.Parameters.Add( "@SourceIssueNumber", MySqlDbType.Int32 ).Value = clientDocument.SourceIssueNumber;
                    command.Parameters.Add( "@ClientIssueNumber", MySqlDbType.Int32 ).Value = clientDocument.ClientIssueNumber;
                    command.Parameters.Add( "@ComboIssueNumber", MySqlDbType.Text ).Value = clientDocument.ComboIssueNumber;
                    command.Parameters.Add( "@ParentUID", MySqlDbType.Decimal ).Value = clientDocument.ParentUID;
                    command.Parameters.Add( "@RecordType", MySqlDbType.VarChar ).Value = clientDocument.RecordType;
                    command.Parameters.Add( "@IsRoot", MySqlDbType.VarChar ).Value = clientDocument.IsRoot;
                    command.Parameters.Add( "@IsFolder", MySqlDbType.VarChar ).Value = clientDocument.IsFolder;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            return _uid;
        }

        // -----------------------------------------------------
        //    Update Client Document
        // -----------------------------------------------------
        internal static ResponseStatus Update( ClientDocument clientDocument )
        {

            string ret = "Item updated successfully";

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {

                var commandString =
                (
                   "UPDATE ClientDocument " +
                   " SET " +
                   " SequenceNumber = @SequenceNumber" +
                   ",SourceLocation =  @SourceLocation " +
                   ",SourceFileName = @SourceFileName " +
                   ",Location = @Location" +
                   ",FileName = @FileName  " +
                   ",ParentUID = @ParentUID " +
                   ",RecordType = @RecordType " +
                   ",IsLocked = @IsLocked" +
                   " WHERE UID = @UID "
                );

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {
                    command.Parameters.Add( "@UID", MySqlDbType.Int32 ).Value = clientDocument.UID;
                    command.Parameters.Add( "@SequenceNumber", MySqlDbType.Int32 ).Value = clientDocument.SequenceNumber;
                    command.Parameters.Add( "@SourceLocation", MySqlDbType.VarChar ).Value = clientDocument.SourceLocation;
                    command.Parameters.Add( "@SourceFileName", MySqlDbType.VarChar ).Value = clientDocument.SourceFileName;
                    command.Parameters.Add( "@Location", MySqlDbType.VarChar ).Value = clientDocument.Location;
                    command.Parameters.Add( "@FileName", MySqlDbType.VarChar ).Value = clientDocument.FileName;
                    command.Parameters.Add( "@ParentUID", MySqlDbType.Int32 ).Value = clientDocument.ParentUID;
                    command.Parameters.Add( "@RecordType", MySqlDbType.VarChar ).Value = clientDocument.RecordType;
                    command.Parameters.Add( "@IsLocked", MySqlDbType.VarChar ).Value = clientDocument.IsLocked;

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch( Exception ex)
                    {
                        LogFile.WriteToTodaysLogFile(ex.ToString(), "", "", "RepClientDocument.cs");
                        return new ResponseStatus( MessageType.Error ) { Message = ex.ToString(), ReturnCode = -0010, ReasonCode = 0001 };
                    }
                }
            }
            return new ResponseStatus(MessageType.Informational);
        }

        // -----------------------------------------------------
        //    Update Client Document
        // -----------------------------------------------------
        internal static void UpdateFieldString( int UID, string fieldName, string contents )
        {

            string ret = "Item updated successfully";

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {

                var commandString =
                (
                   "UPDATE ClientDocument " +
                   " SET " +
                   fieldName + "= @contents "+
                   " WHERE UID = @UID "
                );

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {
                    command.Parameters.Add("@UID", MySqlDbType.Int32).Value = UID;
                    command.Parameters.Add("@contents", MySqlDbType.VarChar).Value = contents;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            return;
        }


        // Physically Delete a file from windows
        internal static void DeleteFile( int clientDocumentUID )
        {
            var clientDocument = Read(clientDocumentUID);

            var fileNamePath = Utils.getFilePathName( clientDocument.clientDocumentSet.Folder + clientDocument.Location, clientDocument.FileName );

            if (File.Exists( fileNamePath ))
                File.Delete( fileNamePath );

        }

        //
        // Set void flag
        //
        internal static void SetToVoid( int clientUID, int clientDocumentSetUID, int documentUID )
        {
            string ret = "Item updated successfully";

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {

                var commandString =
                (
                   "UPDATE ClientDocument " +
                   " SET " +    
                   " IsVoid = @IsVoid" +
                   "  WHERE  " +
                   "        FKClientDocumentSetUID = @FKClientDocumentSetUID    " +
                   "    AND FKClientUID = @FKClientUID  " +
                   "    AND FKDocumentUID = @FKDocumentUID " +
                   "    " 
                );

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {

                    command.Parameters.Add( "@FKClientDocumentSetUID", MySqlDbType.Int32 ).Value = clientDocumentSetUID;
                    command.Parameters.Add( "@FKClientUID", MySqlDbType.Int32 ).Value = clientUID;
                    command.Parameters.Add( "@FKDocumentUID", MySqlDbType.Int32 ).Value = documentUID;

                    command.Parameters.Add( "@IsVoid", MySqlDbType.VarChar ).Value = 'Y';

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        //
        // Set void flag
        //
        internal static ResponseStatus Delete( int clientUID, int clientDocumentSetUID, int clientDocumentUID )
        {
            var ret = new ResponseStatus();

            ret.Message = "Item updated successfully";
            ret.ReturnCode = 0001;
            ret.ReasonCode = 0001;

            using (var connection = new MySqlConnection( ConnString.ConnectionString ))
            {

                var commandString =
                (
                   "DELETE FROM ClientDocument " +
                   "  WHERE  " +
                   "        FKClientDocumentSetUID = @FKClientDocumentSetUID    " +
                   "    AND FKClientUID = @FKClientUID  " +
                   "    AND UID = @UID" +
                   "    "
                );


                try
                {
                    using (var command = new MySqlCommand(
                                                commandString, connection ))
                    {

                        command.Parameters.Add( "@FKClientDocumentSetUID", MySqlDbType.Int32 ).Value = clientDocumentSetUID;
                        command.Parameters.Add( "@FKClientUID", MySqlDbType.Int32 ).Value = clientUID;
                        command.Parameters.Add( "@UID", MySqlDbType.Int32 ).Value = clientDocumentUID;

                        command.Parameters.Add( "@IsVoid", MySqlDbType.VarChar ).Value = 'Y';

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    ret.Message = "Error deleting client document.";
                    ret.ReturnCode = -0010;
                    ret.ReasonCode =  0001;
                }
            }
            return ret;
        }

        /// <summary>
        /// Retrieve combo issue number
        /// </summary>
        /// <param name="documentCUID"></param>
        /// <param name="documentVersionNumber"></param>
        /// <param name="clientUID"></param>
        /// <returns></returns>
        internal static string GetComboIssueNumber( string documentCUID, int documentVersionNumber, int clientUID )
        {
            string comboIssueNumber = "";

            comboIssueNumber = documentCUID + '-' +
                           documentVersionNumber.ToString("00") + "-" +
                           clientUID.ToString("0000") + '-' +
                           "00"; // client issue number;

            return comboIssueNumber;
        }


        /// <summary>
        /// It sets all the destination names for a client document from source name.
        /// </summary>
        /// <param name="documentCUID"></param>
        /// <param name="documentVersionNumber"></param>
        /// <param name="clientUID"></param>
        /// <param name="sourceVersionNumber"> </param>
        /// <param name="simpleFileName"> </param>
        /// <returns></returns>
        internal static ClientDocument SetClientDestinationFile(
                ClientDocument clientDocument,
                int clientUID,
                string documentCUID,
                int sourceVersionNumber,
                string simpleFileName)
        {
            clientDocument.ComboIssueNumber = 
                           documentCUID + '-' +
                           sourceVersionNumber.ToString("00") + "-" +
                           clientUID.ToString("0000") + '-' +
                           "00"; // client issue number;

            clientDocument.FileName = clientDocument.ComboIssueNumber + " " +
                                       simpleFileName;
                                       
            return clientDocument;
        }

        //
        // Update document to Generated
        //
        internal static ResponseStatus SetFlagToGenerationRequested( int clientDocumentUID, int processRequestUID )
        {
            using ( var connection = new MySqlConnection( ConnString.ConnectionString ) )
            {

                var commandString =
                   "UPDATE ClientDocument " +
                   " SET " +
                   " Generated = @Generated" +
                   " ,GenerationMessage = @GenerationMessage" +
                   " ,FKProcessRequestUID = @FKProcessRequestUID" +
                   " WHERE UID = @UID "
                ;

                using ( var command = new MySqlCommand( commandString, connection ) )
                {
                    command.Parameters.Add( "@UID", MySqlDbType.Int32 ).Value = clientDocumentUID;
                    command.Parameters.Add( "@Generated", MySqlDbType.VarChar ).Value = "R";
                    command.Parameters.Add( "@GenerationMessage", MySqlDbType.VarChar ).Value = "";
                    command.Parameters.Add( "@FKProcessRequestUID", MySqlDbType.Int32 ).Value = processRequestUID;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            return new ResponseStatus( MessageType.Informational );
        }



        //
        // Update document to Generated
        //
        internal static ResponseStatus SetGeneratedFlagVersion( ClientDocument clientDocument, char generated, decimal issueNumber, string message )
        {
            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {

                var commandString =
                   "UPDATE ClientDocument " +
                   " SET " +
                   " Generated = @Generated" +
                   " ,SourceIssueNumber = @SourceIssueNumber" +
                   " ,GenerationMessage = @GenerationMessage" +
                   " WHERE UID = @UID "
                ;

                using (var command = new MySqlCommand(commandString, connection))
                {
                    command.Parameters.Add( "@UID", MySqlDbType.Int32 ).Value = clientDocument.UID;
                    command.Parameters.Add("@Generated", MySqlDbType.VarChar).Value = generated;
                    command.Parameters.Add( "@SourceIssueNumber", MySqlDbType.Decimal ).Value = issueNumber;
                    command.Parameters.Add( "@GenerationMessage", MySqlDbType.VarChar ).Value = message;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            return new ResponseStatus(MessageType.Informational);
        }

        //
        // Update file name
        //
        internal void UpdateFileName()
        {

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {

                var commandString =
                (
                   "UPDATE ClientDocument " +
                   " SET " +
                   " FileName = @FileName" +
                   " WHERE UID = @UID "
                );

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {
                    command.Parameters.Add("@UID", MySqlDbType.Int32).Value = UID;
                    command.Parameters.Add("@FileName", MySqlDbType.VarChar).Value = FileName;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            return;
        }


        //
        // Update document to Generate
        //
        internal static ResponseStatus UpdateSourceFileName( ClientDocument clientDocument )
        {
            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {

                var commandString =
                (
                   "UPDATE ClientDocument " +
                   " SET " +
                   " SourceFileName = @SourceFileName" +
                   " ,ComboIssueNumber = @ComboIssueNumber" +
                   " ,FileName = @FileName" +
                   " ,SourceIssueNumber = @SourceIssueNumber" +
                   " WHERE UID = @UID "
                );

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {
                    command.Parameters.Add( "@UID", MySqlDbType.Int32 ).Value = clientDocument.UID;
                    command.Parameters.Add( "@SourceFileName", MySqlDbType.VarChar ).Value = clientDocument.SourceFileName;
                    command.Parameters.Add( "@ComboIssueNumber", MySqlDbType.VarChar ).Value = clientDocument.ComboIssueNumber;
                    command.Parameters.Add( "@FileName", MySqlDbType.VarChar ).Value = clientDocument.FileName;
                    command.Parameters.Add( "@SourceIssueNumber", MySqlDbType.Int32 ).Value = clientDocument.SourceIssueNumber;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            return new ResponseStatus(MessageType.Informational);
        }
        // -----------------------------------------------------
        //    Create new client document version
        // -----------------------------------------------------
        internal static string NewVersion( ClientDocument clientDocument )
        {
            // 24.02.2013 - The paths must be physical when dealing with web
            // 


            // string ClientDocSourceFolder

            // 1) Create a copy of current version in the version folder
            // 2) Create a Client Document Issue record to point to the versioned document in version folder
            // 3) Update the current client document with new details (file name, issue number etc)

            // Copy existing version to old folder version
            //
            // Old folder comes from %VERSIONFOLDER%
            // 
            var versionFolder = CodeValue.GetCodeValueExtended(FCMConstant.CodeTypeString.SYSTSET, FCMConstant.SYSFOLDER.VERSIONFOLDER);

            // Create a record to point to the old version
            //
            ClientDocumentVersion documentIssue = new ClientDocumentVersion();
            documentIssue.FKClientDocumentUID = clientDocument.UID;
            documentIssue.ClientIssueNumber = clientDocument.ClientIssueNumber; // Client Version
            documentIssue.SourceIssueNumber = clientDocument.SourceIssueNumber; // FCM Version
            documentIssue.IssueNumberText = documentIssue.ClientIssueNumber.ToString("0000");
            documentIssue.ComboIssueNumber = clientDocument.FileName.Substring( 0, 22 );
            documentIssue.FKClientUID = clientDocument.FKClientUID;
            documentIssue.Location = Utils.GetVersionPath( "%VERSIONFOLDER%" + "\\Client" + clientDocument.FKClientUID.ToString( "000000000" ) + clientDocument.Location );
            documentIssue.FileName = clientDocument.FileName;

            documentIssue.Add();
            
            // Copy the current document into the version folder
            //
            // string sourceLocationFileName = Utils.getFilePathName(ClientDocSourceFolder + this.Location, this.FileName);
            string sourceLocationFileName = Utils.getFilePathName( clientDocument.Location, clientDocument.FileName );
            string destinationLocationFileName = Utils.getFilePathName( documentIssue.Location, documentIssue.FileName);
            string destinationLocation = Utils.GetPathName( documentIssue.Location);

            if (string.IsNullOrEmpty(sourceLocationFileName))
            {
                return "Location of file is empty. Please contact support.";
            }

            if (!System.IO.Directory.Exists(destinationLocation))
                System.IO.Directory.CreateDirectory(destinationLocation);

            File.Copy(sourceLocationFileName, destinationLocationFileName, true);


            // Generate the new version id

            // Increments issue number
            clientDocument.ClientIssueNumber++;

            // Create a new file name with version on it
            // POL-05-01-201000006-00 FILE NAME.doc
            // POL-05-01-XXXXHHHHH-YY FILE NAME.doc
            // |      |  |         |   
            // |      |  |         +---- Client Version
            // |      |  +--------- Client UID
            // |      +------------ FCM Version
            // +------------------- Document Identifier = CUID
            //
            string textversion = clientDocument.DocumentCUID + '-' + clientDocument.SourceIssueNumber.ToString( "00" ) + "-" +
                                 clientDocument.FKClientUID.ToString( "000000000" ) + '-' + clientDocument.ClientIssueNumber.ToString( "00" );

            // FileName includes extension (.doc, .docx, etc.)
            //
            string newFileName = textversion + ' ' + clientDocument.FileName.Substring( 23 ).Trim();

            // Copy file to new name
            //
            string newFilePathName = Utils.getFilePathName( clientDocument.Location, newFileName );

            File.Copy(sourceLocationFileName, newFilePathName, true);

            // Delete old version from main folder
            //
            File.Delete(sourceLocationFileName);

            // Update document details - version, name, etc
            // this.ClientIssueNumber = version;
            clientDocument.ComboIssueNumber = textversion;
            clientDocument.FileName = newFileName;
            // clientDocument.UpdateVersion();

            UpdateVersion( clientDocument );

            return textversion;
        }


        // -----------------------------------------------------
        //    Create new client document version
        // -----------------------------------------------------
        internal static string NewVersionWeb( ClientDocument clientDocument )
        {
            // string ClientDocSourceFolder

            // 1) Create a copy of current version in the version folder
            // 2) Create a Client Document Issue record to point to the versioned document in version folder
            // 3) Update the current client document with new details (file name, issue number etc)

            // Copy existing version to old folder version
            //
            // Old folder comes from %VERSIONFOLDER%
            // 
            // var versionFolder = CodeValue.GetCodeValueExtended( FCMConstant.CodeTypeString.SYSTSET, FCMConstant.SYSFOLDER.VERSIONFOLDER );

            // Create a record to point to the old version
            //
            ClientDocumentVersion documentIssue = new ClientDocumentVersion();
            documentIssue.FKClientDocumentUID = clientDocument.UID;
            documentIssue.ClientIssueNumber = clientDocument.ClientIssueNumber; // Client Version
            documentIssue.SourceIssueNumber = clientDocument.SourceIssueNumber; // FCM Version
            documentIssue.IssueNumberText = documentIssue.ClientIssueNumber.ToString( "0000" );
            documentIssue.ComboIssueNumber = clientDocument.FileName.Substring( 0, 22 );
            documentIssue.FKClientUID = clientDocument.FKClientUID;
            documentIssue.Location = Utils.GetVersionPath( "%VERSIONFOLDER%" + "\\Client" + clientDocument.FKClientUID.ToString( "000000000" ) + clientDocument.Location );
            documentIssue.FileName = clientDocument.FileName;

            documentIssue.Add();

            // Copy the current document into the version folder
            //
            string sourceLocationFileName = Utils.getFilePathName( clientDocument.Location, clientDocument.FileName );

            // Increments issue number
            //
            clientDocument.ClientIssueNumber++;

            // Create a new file name with version on it
            // POL-05-01-201000006-00 FILE NAME.doc
            // POL-05-01-XXXXHHHHH-YY FILE NAME.doc
            // |      |  |         |   
            // |      |  |         +---- Client Version
            // |      |  +--------- Client UID
            // |      +------------ FCM Version
            // +------------------- Document Identifier = CUID
            //
            string textversion = clientDocument.DocumentCUID + '-' + clientDocument.SourceIssueNumber.ToString( "00" ) + "-" +
                                 clientDocument.FKClientUID.ToString( "000000000" ) + '-' + clientDocument.ClientIssueNumber.ToString( "00" );

            // FileName includes extension (.doc, .docx, etc.)
            //
            string newFileName = textversion + ' ' + clientDocument.FileName.Substring( 23 ).Trim();

            // Update document details - version, name, etc
            clientDocument.ComboIssueNumber = textversion;
            clientDocument.FileName = newFileName;

            UpdateVersion( clientDocument );

            return textversion;
        }




        // -----------------------------------------------------
        //    Update Document Version
        // -----------------------------------------------------
        private static void UpdateVersion( ClientDocument clientDocument)
        {

            string ret = "Item updated successfully";

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {

                var commandString =
                (
                   "UPDATE ClientDocument " +
                   " SET " +
                   " ClientIssueNumber = @ClientIssueNumber" +
                   ",Location = @Location" +
                   ",FileName = @FileName" +
                   " WHERE UID = @UID "
                );

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {
                    command.Parameters.Add( "@ClientIssueNumber", MySqlDbType.Decimal ).Value = clientDocument.ClientIssueNumber;
                    command.Parameters.Add( "@Location", MySqlDbType.VarChar ).Value = clientDocument.Location;
                    command.Parameters.Add( "@FileName", MySqlDbType.VarChar ).Value = clientDocument.FileName;
                    command.Parameters.Add( "@UID", MySqlDbType.Int32 ).Value = clientDocument.UID;


                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            return;
        }
    

        //
        // Listing...
        //

        /// <summary>
        /// List documents for a client
        /// </summary>
        /// <param name="clientDocument"></param>
        /// <param name="clientID"></param>
        /// <param name="clientDocumentSetUID"></param>
        /// <param name="condition"></param>
        internal static void List( ClientDocument clientDocument, int clientID, int clientDocumentSetUID, string condition = "" )
        {
            clientDocument.clientDocSetDocLink = new List<scClientDocSetDocLink>();
            clientDocument.clientDocumentList = new List<ClientDocument>();

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {
                var prefix = "CD";

                var commandString = string.Format(
                " SELECT " +
                SQLConcat(prefix) + 
                "   FROM ClientDocument "+ prefix + 
                "   WHERE " +
                "       IsVoid = 'N' " +
                "   AND FKClientUID = {0} " +
                "   AND FKClientDocumentSetUID = {1} " +
                " " + condition + " " +
                "   ORDER BY ParentUID ASC, SequenceNumber ASC ",
                clientID,
                clientDocumentSetUID
                );

                using (var command = new MySqlCommand(
                                      commandString, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Ignore voids
                            if (Convert.ToChar(reader[prefix+FCMDBFieldName.ClientDocument.IsVoid]) == 'Y')
                                continue;

                            var docItem = SetDocumentItem(reader, prefix);

                            // Check if document exists
                            //

                            clientDocument.clientDocSetDocLink.Add( docItem );
                            clientDocument.clientDocumentList.Add(docItem.clientDocument);

                            clientDocument.UID = Convert.ToInt32( reader [prefix + FCMDBFieldName.ClientDocument.UID].ToString() );
                            clientDocument.FKClientUID = Convert.ToInt32( reader [prefix + FCMDBFieldName.ClientDocument.FKClientUID].ToString() );
                            clientDocument.FKClientDocumentSetUID = Convert.ToInt32( reader [prefix + FCMDBFieldName.ClientDocument.FKClientDocumentSetUID].ToString() );
                        }
                    }
                }
            }
        }

        //
        // (STATIC) List documents for a client 
        //
        internal static List<scClientDocSetDocLink> ListS( int clientID, int clientDocumentSetUID )
        {
            var clientDocSetDocLink = new List<scClientDocSetDocLink>();

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {
                string prefix = "CD";
                var commandString = string.Format(
                " SELECT " +
                SQLConcat(prefix) +
                "   FROM ClientDocument " + prefix +
                "   WHERE " +
                "       IsVoid = 'N' " +
                "   AND FKClientUID = {0} " +
                "   AND FKClientDocumentSetUID = {1} " +
                "   ORDER BY ParentUID ASC, SequenceNumber ASC ",
                clientID,
                clientDocumentSetUID
                );

                using (var command = new MySqlCommand(
                                      commandString, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Ignore voids
                            if ( Convert.ToChar( reader [prefix + FCMDBFieldName.ClientDocument.IsVoid] ) == 'Y' )
                                continue;

                            var docItem = SetDocumentItem(reader, prefix);

                            clientDocSetDocLink.Add(docItem);

                        }
                    }
                }
            }
            return clientDocSetDocLink;
        }

        //
        // (STATIC) List documents for a client 
        //
        internal static List<ClientDocument> ListCD( int clientID, int clientDocumentSetUID )
        {

            var clientDocumentList = new List<ClientDocument>();

            using ( var connection = new MySqlConnection( ConnString.ConnectionString ) )
            {
                string prefix = "CD";
                var commandString = string.Format(
                " SELECT " +
                SQLConcat( prefix ) +
                "   FROM ClientDocument " + prefix +
                "   WHERE " +
                "       IsVoid = 'N' " +
                "   AND FKClientUID = {0} " +
                "   AND FKClientDocumentSetUID = {1} " +
                "   ORDER BY ParentUID ASC, SequenceNumber ASC ",
                clientID,
                clientDocumentSetUID
                );

                using ( var command = new MySqlCommand(
                                      commandString, connection ) )
                {
                    connection.Open();
                    using ( MySqlDataReader reader = command.ExecuteReader() )
                    {
                        while ( reader.Read() )
                        {
                            // Ignore voids
                            if ( Convert.ToChar( reader [prefix + FCMDBFieldName.ClientDocument.IsVoid] ) == 'Y' )
                                continue;

                            var docItem = SetDocumentItem( reader, prefix );

                            clientDocumentList.Add( docItem.clientDocument );
                        }
                    }
                }
            }
            return clientDocumentList;
        }

        internal static void ListFolders( ClientDocument clientDocument, int clientID, int clientDocumentSetUID, string condition = "" )
        {

            string cond = " AND IsFolder = 'Y' ";

            List( clientDocument, clientID, clientDocumentSetUID, cond );

        }

        //
        // List documents for a client
        //
        internal static void ListImpacted( ClientDocument clientDocument, Model.ModelDocument.Document document )
        {
            clientDocument.clientDocSetDocLink = new List<scClientDocSetDocLink>();

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {
                string prefix = "CD";
                var commandString = string.Format(
                " SELECT " +
                SQLConcat(prefix) +
                "   FROM ClientDocument " + prefix +
                "   WHERE FKDocumentUID = {0} ",
                document.UID
                );

                using (var command = new MySqlCommand(
                                      commandString, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Ignore voids
                            if ( Convert.ToChar( reader [prefix + FCMDBFieldName.ClientDocument.IsVoid] ) == 'Y' )
                                continue;

                            var docItem = SetDocumentItem(reader, prefix);

                            clientDocument.clientDocSetDocLink.Add( docItem );
                        }
                    }
                }
            }

        }

        // -----------------------------------------------------
        //    Load documents in a tree
        //    The list in tree expects that the list has been 
        //    called before to populate the instance
        // -----------------------------------------------------
        internal static void ListInTree( ClientDocument clientDocument, TreeView fileList, string listType )
        {
            // listType = CLIENT
            // listType = FCM = default;

            string ListType = listType;
            if (ListType == null)
                ListType = "FCM";


            foreach ( var docLinkSet in clientDocument.clientDocSetDocLink )
            {
                // Check if folder has a parent

                string cdocumentUID = docLinkSet.clientDocument.UID.ToString();
                string cparentIUID = docLinkSet.clientDocument.ParentUID.ToString();
                TreeNode treeNode = new TreeNode();

                int image = 0;
                int imageSelected = 0;
                docLinkSet.clientDocument.RecordType = docLinkSet.clientDocument.RecordType.Trim();

                image = Utils.GetFileImage(docLinkSet.clientDocument.SourceFilePresent, docLinkSet.clientDocument.DestinationFilePresent, docLinkSet.clientDocument.DocumentType);
                imageSelected = image;

                //if (ListType == "CLIENT")
                //    treeNode = new TreeNode(docLinkSet.clientDocument.FileName, image, imageSelected);
                //else
                //    treeNode = new TreeNode(docLinkSet.document.Name, image, imageSelected);

                string treenodename = docLinkSet.document.DisplayName;

                if (string.IsNullOrEmpty(treenodename))
                    treenodename = docLinkSet.clientDocument.FileName;

                if (string.IsNullOrEmpty(treenodename))
                    treenodename = "Error: Name not found";

                treeNode = new TreeNode(treenodename, image, imageSelected);

                if (docLinkSet.clientDocument.ParentUID == 0)
                {

                    treeNode.Tag = docLinkSet;
                    treeNode.Name = cdocumentUID;
                    fileList.Nodes.Add(treeNode);

                }
                else
                {
                    // Find the parent node
                    //
                    var node = fileList.Nodes.Find(cparentIUID, true);

                    if (node.Count() > 0)
                    {

                        treeNode.Tag = docLinkSet;
                        treeNode.Name = cdocumentUID;

                        node[0].Nodes.Add(treeNode);
                    }
                    else
                    {
                        // Add Element to the root
                        //
                        treeNode.Tag = docLinkSet;
                        treeNode.Name = cdocumentUID;

                        fileList.Nodes.Add(treeNode);
                    }
                }
            }
        }

        // -----------------------------------
        //        List project plans
        // -----------------------------------
        internal static void ListProjectPlans( ClientDocument clientDocument, int clientID, int clientDocumentSetUID )
        {
            clientDocument.clientDocSetDocLink = new List<scClientDocSetDocLink>();

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {
                string prefix = "CD";
                var commandString = string.Format(
                " SELECT " +
                SQLConcat(prefix) + 
                "   FROM ClientDocument " +prefix +
                "   WHERE FKClientUID = {0} " +
                "   AND FKClientDocumentSetUID = {1} " +
                "   AND IsProjectPlan = 'Y' " +
                "   AND IsVoid = 'N' " +
                "   ORDER BY ParentUID ASC, SequenceNumber ASC ",
                clientID,
                clientDocumentSetUID
                );

                using (var command = new MySqlCommand(
                                      commandString, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Ignore voids
                            if (Convert.ToChar(reader[prefix + FCMDBFieldName.ClientDocument.IsVoid]) == 'Y')
                                continue;

                            var docItem = SetDocumentItem(reader, prefix);

                            clientDocument.clientDocSetDocLink.Add(docItem);
                        }
                    }
                }
            }

        }




        // -----------------------------------------------------
        //    Load project plan in a tree
        //    
        // -----------------------------------------------------
        internal static void ListProjectPlanInTree( ClientDocument clientDocument, int clientID, int clientDocumentSetUID, TreeView fileList )
        {

            int image = FCMConstant.Image.Document;
            int imageSelected = FCMConstant.Image.Document;

            ListProjectPlans( clientDocument, clientID, clientDocumentSetUID );

            foreach ( var projectPlan in clientDocument.clientDocSetDocLink )
            {
                //
                // load plan in tree
                //
                var treeNode = new TreeNode(projectPlan.document.Name, image, imageSelected);
                treeNode.Tag = projectPlan;
                treeNode.Name = projectPlan.clientDocument.UID.ToString();
                fileList.Nodes.Add(treeNode);

                // List contents of the project plan
                //
                var cdl = new ClientDocumentLinkList();
                // cdl.ListChildrenDocuments( projectPlan.clientDocument.UID );

                if (clientID <= 0 || projectPlan.clientDocumentSet.UID <= 0 || projectPlan.document.UID <= 0)
                {
                    MessageBox.Show("Error listing children document. Please contact support");
                    return;
                }

                cdl.ListChildrenDocuments(clientUID: clientID,
                                           clientDocumentSetUID: projectPlan.clientDocumentSet.UID,
                                           documentUID: projectPlan.document.UID,
                                           type: FCMConstant.DocumentLinkType.PROJECTPLAN);

                foreach (var planItem in cdl.clientDocumentLinkList)
                {
                    //
                    // load contents of the project plan in tree
                    //
                    var planItemNode = new TreeNode(planItem.childClientDocument.FileName, image, imageSelected);
                    planItemNode.Tag = planItem;
                    planItemNode.Name = planItem.childClientDocument.UID.ToString();
                    treeNode.Nodes.Add(planItemNode);
                }
            }
        }
        
        /// <summary>
        /// Returns a string to be concatenated with a SQL statement
        /// </summary>
        /// <param name="tablePrefix"></param>
        /// <returns></returns>
        private static string SQLConcat( string tablePrefix )
        {
            string ret = " " +

            tablePrefix + "."+ FCMDBFieldName.ClientDocument.UID + " " + tablePrefix + FCMDBFieldName.ClientDocument.UID + "," +
            tablePrefix + "."+ FCMDBFieldName.ClientDocument.DocumentCUID + " " + tablePrefix + FCMDBFieldName.ClientDocument.DocumentCUID + "," +
            tablePrefix + "."+ FCMDBFieldName.ClientDocument.FKClientUID + " " + tablePrefix + FCMDBFieldName.ClientDocument.FKClientUID + "," +
            tablePrefix + "."+ FCMDBFieldName.ClientDocument.FKClientDocumentSetUID + " " + tablePrefix + FCMDBFieldName.ClientDocument.FKClientDocumentSetUID + "," +
            tablePrefix + "."+ FCMDBFieldName.ClientDocument.FKDocumentUID + " " + tablePrefix + FCMDBFieldName.ClientDocument.FKDocumentUID + "," +
            tablePrefix + "."+ FCMDBFieldName.ClientDocument.SourceLocation + " " + tablePrefix + FCMDBFieldName.ClientDocument.SourceLocation + "," +
            tablePrefix + "."+ FCMDBFieldName.ClientDocument.SourceFileName + " " + tablePrefix + FCMDBFieldName.ClientDocument.SourceFileName + "," +
            tablePrefix + "."+ FCMDBFieldName.ClientDocument.Location + " " + tablePrefix + FCMDBFieldName.ClientDocument.Location + "," +
            tablePrefix + "."+ FCMDBFieldName.ClientDocument.FileName + " " + tablePrefix + FCMDBFieldName.ClientDocument.FileName + "," +
            tablePrefix + "."+ FCMDBFieldName.ClientDocument.SourceIssueNumber + " " + tablePrefix + FCMDBFieldName.ClientDocument.SourceIssueNumber + "," +
            tablePrefix + "."+ FCMDBFieldName.ClientDocument.ClientIssueNumber + " " + tablePrefix + FCMDBFieldName.ClientDocument.ClientIssueNumber + "," +
            tablePrefix + "."+ FCMDBFieldName.ClientDocument.SequenceNumber + " " + tablePrefix + FCMDBFieldName.ClientDocument.SequenceNumber + "," +
            tablePrefix + "."+ FCMDBFieldName.ClientDocument.Generated + " " + tablePrefix + FCMDBFieldName.ClientDocument.Generated + "," +
            tablePrefix + "."+ FCMDBFieldName.ClientDocument.StartDate + " " + tablePrefix + FCMDBFieldName.ClientDocument.StartDate + "," +
            tablePrefix + "."+ FCMDBFieldName.ClientDocument.EndDate + " " + tablePrefix + FCMDBFieldName.ClientDocument.EndDate + "," +
            tablePrefix + "."+ FCMDBFieldName.ClientDocument.RecordType + " " + tablePrefix + FCMDBFieldName.ClientDocument.RecordType + "," +
            tablePrefix + "."+ FCMDBFieldName.ClientDocument.ParentUID + " " + tablePrefix + FCMDBFieldName.ClientDocument.ParentUID + "," +
            tablePrefix + "."+ FCMDBFieldName.ClientDocument.IsProjectPlan + " " + tablePrefix + FCMDBFieldName.ClientDocument.IsProjectPlan + "," +
            tablePrefix + "."+ FCMDBFieldName.ClientDocument.DocumentType + " " + tablePrefix + FCMDBFieldName.ClientDocument.DocumentType + "," +
            tablePrefix + "."+ FCMDBFieldName.ClientDocument.ComboIssueNumber + " " + tablePrefix + FCMDBFieldName.ClientDocument.ComboIssueNumber + "," +
            tablePrefix + "." + FCMDBFieldName.ClientDocument.IsVoid + " " + tablePrefix + FCMDBFieldName.ClientDocument.IsVoid + "," +
            tablePrefix + "." + FCMDBFieldName.ClientDocument.IsLocked + " " + tablePrefix + FCMDBFieldName.ClientDocument.IsLocked + "," +
            tablePrefix + "." + FCMDBFieldName.ClientDocument.IsRoot + " " + tablePrefix + FCMDBFieldName.ClientDocument.IsRoot + "," +
            tablePrefix + "." + FCMDBFieldName.ClientDocument.IsFolder + " " + tablePrefix + FCMDBFieldName.ClientDocument.IsFolder + "," +
            tablePrefix + "." + FCMDBFieldName.ClientDocument.GenerationMessage + " " + tablePrefix + FCMDBFieldName.ClientDocument.GenerationMessage;

            return ret;
        }

        /// <summary>
        /// partial code
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="prefix"></param>
        /// <param name="checkForSourceFile"></param>
        /// <param name="checkForDestinationFile"></param>
        /// <returns></returns>
        private static scClientDocSetDocLink SetDocumentItem(
            MySqlDataReader reader,
            string prefix,
            bool checkForSourceFile = false,
            bool checkForDestinationFile = false )
        {
            var docItem = new scClientDocSetDocLink();

            // Get document
            //
            docItem.document = new Model.ModelDocument.Document();
            docItem.document.UID = Convert.ToInt32( reader [prefix + FCMDBFieldName.ClientDocument.FKDocumentUID] );
            // docItem.document.Read(includeVoid: true);

            docItem.document = RepDocument.Read( false, docItem.document.UID );

            // Get Client Document Set
            //
            docItem.clientDocumentSet = new ClientDocumentSet();
            docItem.clientDocumentSet.UID = Convert.ToInt32( reader [prefix + FCMDBFieldName.ClientDocument.FKClientDocumentSetUID].ToString() );
            docItem.clientDocumentSet.FKClientUID = Convert.ToInt32( reader [prefix + FCMDBFieldName.ClientDocument.FKClientUID].ToString() );
            docItem.clientDocumentSet.Read();

            // Set Client Document 
            //
            docItem.clientDocument = new ClientDocument();
            docItem.clientDocument.UID = Convert.ToInt32( reader [prefix + FCMDBFieldName.ClientDocument.UID].ToString() );
            docItem.clientDocument.DocumentCUID = reader [prefix + FCMDBFieldName.ClientDocument.DocumentCUID].ToString();
            docItem.clientDocument.FKClientUID = Convert.ToInt32( reader [prefix + FCMDBFieldName.ClientDocument.FKClientUID].ToString() );
            docItem.clientDocument.FKClientDocumentSetUID = Convert.ToInt32( reader [prefix + FCMDBFieldName.ClientDocument.FKClientDocumentSetUID].ToString() );
            docItem.clientDocument.FKDocumentUID = Convert.ToInt32( reader [prefix + FCMDBFieldName.ClientDocument.FKDocumentUID].ToString() );
            docItem.clientDocument.SourceLocation = reader [prefix + FCMDBFieldName.ClientDocument.SourceLocation].ToString();
            docItem.clientDocument.SourceFileName = reader [prefix + FCMDBFieldName.ClientDocument.SourceFileName].ToString();
            docItem.clientDocument.Location = reader [prefix + FCMDBFieldName.ClientDocument.Location].ToString();
            docItem.clientDocument.FileName = reader [prefix + FCMDBFieldName.ClientDocument.FileName].ToString();
            docItem.clientDocument.SourceIssueNumber = Convert.ToInt32( reader [prefix + FCMDBFieldName.ClientDocument.SourceIssueNumber].ToString() );
            docItem.clientDocument.ClientIssueNumber = Convert.ToInt32( reader [prefix + FCMDBFieldName.ClientDocument.ClientIssueNumber].ToString() );
            docItem.clientDocument.SequenceNumber = Convert.ToInt32( reader [prefix + FCMDBFieldName.ClientDocument.SequenceNumber].ToString() );
            docItem.clientDocument.Generated = Convert.ToChar( reader [prefix + FCMDBFieldName.ClientDocument.Generated] );
            docItem.clientDocument.StartDate = Convert.ToDateTime( reader [prefix + FCMDBFieldName.ClientDocument.StartDate].ToString() );
            docItem.clientDocument.RecordType = reader [prefix + FCMDBFieldName.ClientDocument.RecordType].ToString();
            //docItem.clientDocument.RecordType = docItem.clientDocument.RecordType.Trim();

            docItem.clientDocument.ParentUID = Convert.ToInt32( reader [prefix + FCMDBFieldName.ClientDocument.ParentUID].ToString() );
            docItem.clientDocument.IsProjectPlan = reader [prefix + FCMDBFieldName.ClientDocument.IsProjectPlan].ToString();
            docItem.clientDocument.DocumentType = reader [prefix + FCMDBFieldName.ClientDocument.DocumentType].ToString();
            docItem.clientDocument.ComboIssueNumber = reader [prefix + FCMDBFieldName.ClientDocument.ComboIssueNumber].ToString();
            docItem.clientDocument.IsVoid = Convert.ToChar( reader [prefix + FCMDBFieldName.ClientDocument.IsVoid].ToString() );
            docItem.clientDocument.IsRoot = Convert.ToChar( reader [prefix + FCMDBFieldName.ClientDocument.IsRoot].ToString() );
            docItem.clientDocument.IsFolder = Convert.ToChar( reader [prefix + FCMDBFieldName.ClientDocument.IsFolder].ToString() );
            docItem.clientDocument.IsLocked = Convert.ToChar( reader [prefix + FCMDBFieldName.ClientDocument.IsLocked].ToString() );
            docItem.clientDocument.GenerationMessage = reader [prefix + FCMDBFieldName.ClientDocument.GenerationMessage].ToString();


            if ( checkForSourceFile )
            {
                // SOURCE FILE is present?
                // 
                docItem.clientDocument.SourceFilePresent = 'N';

                if ( string.IsNullOrEmpty( docItem.clientDocument.SourceLocation ) )
                {
                    docItem.clientDocument.SourceFilePresent = 'N';
                }
                else
                {
                    string filePathName = Utils.getFilePathName( docItem.clientDocument.SourceLocation,
                                                                docItem.clientDocument.SourceFileName );
                    // This is the source client file name
                    //
                    string clientSourceFileLocationName = Utils.getFilePathName(
                                    docItem.clientDocument.SourceLocation.Trim(),
                                    docItem.clientDocument.SourceFileName.Trim() );

                    if ( File.Exists( clientSourceFileLocationName ) )
                    {
                        docItem.clientDocument.SourceFilePresent = 'Y';
                    }
                }
            }

            if ( checkForDestinationFile )
            {
                // DESTINATION FILE is present?
                // 
                docItem.clientDocument.DestinationFilePresent = 'N';

                if ( string.IsNullOrEmpty( docItem.clientDocument.Location ) )
                {
                    docItem.clientDocument.DestinationFilePresent = 'N';
                }
                else
                {
                    string filePathName = Utils.getFilePathName( docItem.clientDocument.Location,
                                                                docItem.clientDocument.FileName );
                    // This is the destination client file name
                    //
                    string clientDestinationFileLocationName = Utils.getFilePathName(
                                    docItem.clientDocument.Location.Trim(),
                                    docItem.clientDocument.FileName.Trim() );

                    if ( File.Exists( clientDestinationFileLocationName ) )
                    {
                        docItem.clientDocument.DestinationFilePresent = 'Y';
                    }
                }
            }

            try
            {
                docItem.clientDocument.EndDate = Convert.ToDateTime( reader [prefix + FCMDBFieldName.ClientDocument.EndDate].ToString() );
            }
            catch
            {
                docItem.clientDocument.EndDate = System.DateTime.MaxValue;
            }

            return docItem;
        }
    }
}
