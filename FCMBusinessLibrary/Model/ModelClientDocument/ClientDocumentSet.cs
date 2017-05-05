using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Forms;
using FCMMySQLBusinessLibrary.Model.ModelDocument;
using FCMMySQLBusinessLibrary.Repository.RepositoryClientDocument;
using FCMMySQLBusinessLibrary.Repository.RepositoryDocument;
using FCMMySQLBusinessLibrary.Service.SVCClientDocument.Service;
using MackkadoITFramework.Helper;
using MackkadoITFramework.Utils;
using MackkadoITFramework.ErrorHandling;
using MySql.Data.MySqlClient;

namespace FCMMySQLBusinessLibrary.Model.ModelClientDocument
{
    public class ClientDocumentSet
    {

        [Display( Name = "Document Unique ID" )]
        public int UID { get; set; }

        [Display( Name = "Client Unique ID" )]
        public int FKClientUID { get; set; }

        [Display( Name = "Description" )]
        public string Description { get; set; }
        public string CombinedIDName { get; set; }
        public string Folder { get; set; }
        public string FolderOnly { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string IsVoid { get; set; }

        [Display( Name = "Client Document Set ID" )]
        public int ClientSetID { get; set; }

        [Display( Name = "Source Folder" )]
        public string SourceFolder { get; set; }

        public string Status { get; set; }
        public string UserIdCreatedBy { get; set; }
        public string UserIdUpdatedBy { get; set;  }
        public DateTime CreationDateTime { get; set;  }
        public DateTime UpdateDateTime { get; set ; }
        public List<ClientDocumentSet> clientDocumentSetList { get; set; }
        public List<Document> listOfDocumentsInSet { get; set; }
    
        /// <summary>
        /// Constructor - Basic
        /// </summary>
        /// <param name="iClientUID"></param>
        /// <param name="iClientDocumentSetUID"></param>
        public ClientDocumentSet()
        {
        }

        /// <summary>
        /// Constructor retrieving client set information
        /// </summary>
        /// <param name="iClientUID"></param>
        /// <param name="iClientDocumentSetUID"></param>
        public ClientDocumentSet(int iClientUID, int iClientDocumentSetUID)
        {
            this.Get(iClientUID, iClientDocumentSetUID);
        }

        /// <summary>
        /// Constructor to set the client
        /// </summary>
        /// <param name="iClientUID"></param>
        /// <param name="iClientDocumentSetUID"></param>
        public ClientDocumentSet(int iClientUID)
        {
            FKClientUID = iClientUID;
        }


        
        // -----------------------------------------------------
        //    Get Client set
        // -----------------------------------------------------
        public bool Get(int iClientUID, int iClientDocumentSetUID)
        {
            bool ret = false;

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {
                var commandString =
                " SELECT " +
                ClientDocumentSetFieldString() +
                "  FROM ClientDocumentSet" +
                " WHERE " +
                " ClientSetID = " + iClientDocumentSetUID +
                " AND FKClientUID = " + iClientUID;

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        try
                        {
                            LoadObject(this, reader);
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
        //    Get Client set using UID
        // -----------------------------------------------------
        public bool Read()
        {
            bool ret = false;

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {
                var commandString = String.Format(
                " SELECT " +
                ClientDocumentSetFieldString() +
                "  FROM ClientDocumentSet" +
                " WHERE " +
                " UID = {0} AND FKClientUID = {1}",
                this.UID,
                this.FKClientUID)
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
                            LoadObject(this, reader);
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
                    "SELECT MAX(UID) LASTUID FROM ClientDocumentSet";

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
        //   Retrieve last Document Set for a client
        // -----------------------------------------------------
        private int GetLastUID(int iClientID)
        {
            int LastUID = 0;

            // 
            // EA SQL database
            // 

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {
                var commandString =
                    "SELECT FKClientUID , MAX(ClientSetID) LASTUID FROM ClientDocumentSet " +
                    // "WHERE FKClientUID = " + iClientID +
                    " GROUP BY FKClientUID " +
                    " HAVING FKClientUID = " + iClientID;

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
        /// Calculate the number of documents in the set
        /// </summary>
        /// <param name="iClientID"></param>
        /// <returns></returns>
        public int GetNumberOfDocuments()
        {
            int DocoCount = 0;
            DocoCount = RepClientDocument.GetNumberOfDocuments(this.FKClientUID, this.ClientSetID);

            return DocoCount;
        }


        // -----------------------------------------------------
        //    Add new Client Document Set
        // -----------------------------------------------------
        public ResponseStatus Add(HeaderInfo headerInfo, MySqlConnection connection = null)
        {

            ResponseStatus response = new ResponseStatus();

            response.Message = "Client Document Set Added Successfully";

            UID = GetLastUID() + 1;
            ClientSetID = GetLastUID(this.FKClientUID) + 1;
            Description = "Client Set Number " + ClientSetID;
            IsVoid = "N";
            Status = "DRAFT";

            FolderOnly =
                "CLIENT" + FKClientUID.ToString().Trim() +
                "SET" + ClientSetID.ToString().Trim().PadLeft(4, '0');

            Folder = MakConstant.SYSFOLDER.CLIENTFOLDER + @"\" + this.FolderOnly;

            CreationDateTime = headerInfo.CurrentDateTime;
            UpdateDateTime = headerInfo.CurrentDateTime;
            UserIdCreatedBy = headerInfo.UserID;
            UserIdUpdatedBy = headerInfo.UserID;

            // Default values
            DateTime _now = DateTime.Today;

            if (connection == null)
            {
                connection = new MySqlConnection(ConnString.ConnectionString);
                connection.Open();
            }

            var commandString =
            (

                "INSERT INTO ClientDocumentSet " +
                "(" +
                ClientDocumentSetFieldString() +
                ")" +
                    " VALUES " +
                "( @UID     " +
                ", @FKClientUID    " +
                ", @ClientSetID    " +
                ", @Description " +
                ", @Folder " +
                ", @FolderOnly " +
                ", @Status " +
                ", @StartDate " +
                ", @EndDate " +
                ", @SourceFolder " +
                ", @IsVoid " +
                ", @CreationDateTime  " +
                ", @UpdateDateTime " +
                ", @UserIdCreatedBy " +
                ", @UserIdUpdatedBy " +
                ")"
            );

            using (var command = new MySqlCommand(
                                        commandString, connection))
            {
                command.Parameters.Add("@UID", MySqlDbType.Int32).Value = UID;
                command.Parameters.Add("@FKClientUID", MySqlDbType.Int32).Value = FKClientUID;
                command.Parameters.Add("@ClientSetID", MySqlDbType.Int32).Value = ClientSetID;
                command.Parameters.Add("@Description", MySqlDbType.VarChar).Value = Description;
                command.Parameters.Add("@Folder", MySqlDbType.VarChar).Value = Folder;
                command.Parameters.Add("@FolderOnly", MySqlDbType.VarChar).Value = FolderOnly;
                command.Parameters.Add("@Status", MySqlDbType.VarChar).Value = Status;
                command.Parameters.Add("@SourceFolder", MySqlDbType.VarChar).Value = SourceFolder;
                command.Parameters.Add("@StartDate", MySqlDbType.DateTime).Value = _now;
                command.Parameters.AddWithValue("@EndDate", "9999-12-31");
                command.Parameters.Add("@IsVoid", MySqlDbType.VarChar).Value = IsVoid;
                command.Parameters.Add("@CreationDateTime", MySqlDbType.DateTime).Value = CreationDateTime;
                command.Parameters.Add("@UpdateDateTime", MySqlDbType.DateTime).Value = UpdateDateTime;
                command.Parameters.Add("@UserIdCreatedBy", MySqlDbType.VarChar).Value = UserIdCreatedBy;
                command.Parameters.Add("@UserIdUpdatedBy", MySqlDbType.VarChar).Value = UserIdUpdatedBy;
                
                command.ExecuteNonQuery();
                }
            return response;
        }

        /// <summary>
        /// Create new document set. (Sub transaction)
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="MySqlTransaction"></param>
        /// <param name="headerInfo"></param>
        /// <returns></returns>
        public ResponseStatus AddSubTransaction(            
                                    MySqlConnection connection, 
                                    MySqlTransaction MySqlTransaction,
                                    HeaderInfo headerInfo)
        {

            ResponseStatus response = new ResponseStatus();

            response.Message = "Client Document Set Added Successfully";

            this.UID = GetLastUID() + 1;
            this.ClientSetID = GetLastUID(this.FKClientUID) + 1;
            this.Description = "Client Set Number " + ClientSetID;
            this.IsVoid = "N";
            this.Status = "DRAFT";

            this.FolderOnly =
                "CLIENT" + this.FKClientUID.ToString().Trim() +
                   "SET" + this.ClientSetID.ToString().Trim().PadLeft(4, '0');

            this.Folder = MakConstant.SYSFOLDER.CLIENTFOLDER + @"\" + this.FolderOnly;

            this.CreationDateTime = System.DateTime.Now;
            this.UpdateDateTime = System.DateTime.Now;
            this.UserIdCreatedBy = Utils.UserID;
            this.UserIdUpdatedBy = Utils.UserID;

            // Default values
            DateTime _now = DateTime.Today;

            var commandString =
            (

                "INSERT INTO ClientDocumentSet " +
                "(" +
                ClientDocumentSetFieldString() +
                ")" +
                    " VALUES " +
                "( @UID     " +
                ", @FKClientUID    " +
                ", @ClientSetID    " +
                ", @Description " +
                ", @Folder " +
                ", @FolderOnly " +
                ", @Status " +
                ", @StartDate " +
                ", @EndDate " +
                ", @SourceFolder " +
                ", @IsVoid " +
                ", @CreationDateTime  " +
                ", @UpdateDateTime " +
                ", @UserIdCreatedBy " +
                ", @UserIdUpdatedBy " +
                ")"
             );

            var command = new MySqlCommand(commandString, connection, MySqlTransaction);

            command.Parameters.Add("@UID", MySqlDbType.Int32).Value = UID;
            command.Parameters.Add("@FKClientUID", MySqlDbType.Int32).Value = FKClientUID;
            command.Parameters.Add("@ClientSetID", MySqlDbType.Int32).Value = ClientSetID;
            command.Parameters.Add("@Description", MySqlDbType.VarChar).Value = Description;
            command.Parameters.Add("@Folder", MySqlDbType.VarChar).Value = Folder;
            command.Parameters.Add("@FolderOnly", MySqlDbType.VarChar).Value = FolderOnly;
            command.Parameters.Add("@Status", MySqlDbType.VarChar).Value = Status;
            command.Parameters.Add("@SourceFolder", MySqlDbType.VarChar).Value = SourceFolder;
            command.Parameters.Add("@StartDate", MySqlDbType.DateTime).Value = _now;
            command.Parameters.Add("@EndDate", MySqlDbType.DateTime).Value = DateTime.MaxValue;
            command.Parameters.Add("@IsVoid", MySqlDbType.VarChar).Value = IsVoid;
            command.Parameters.Add("@CreationDateTime", MySqlDbType.DateTime).Value = CreationDateTime;
            command.Parameters.Add("@UpdateDateTime", MySqlDbType.DateTime).Value = UpdateDateTime;
            command.Parameters.Add("@UserIdCreatedBy", MySqlDbType.VarChar).Value = UserIdCreatedBy;
            command.Parameters.Add("@UserIdUpdatedBy", MySqlDbType.VarChar).Value = UserIdUpdatedBy;

            command.ExecuteNonQuery();
            return response;
        }


        // -----------------------------------------------------
        //    Update Client Document Set
        // -----------------------------------------------------
        public ResponseStatus Update()
        {

            ResponseStatus responseStatus = new ResponseStatus(MessageType.Informational);
            responseStatus.Message = "Document Set updated successfully";

            // Default values
            this.UpdateDateTime = DateTime.Today;
            this.UserIdUpdatedBy = Utils.UserID;


            if (string.IsNullOrEmpty( this.SourceFolder))
            {
                LogFile.WriteToTodaysLogFile("Error: Source folder not supplied. UID: " + this.UID + " Client UID: "+this.FKClientUID);
                this.SourceFolder = "";
            }



            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {

                var commandString =
                (
                   "UPDATE ClientDocumentSet " +
                   " SET " +
                   " Description =  @Description " +
                   ",Folder = @Folder " +
                   ",SourceFolder = @SourceFolder " +
                   ",UpdateDateTime = @UpdateDateTime " +
                   ",UserIdUpdatedBy = @UserIdUpdatedBy " +

                   " WHERE UID = @UID "
                );

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {
                    command.Parameters.Add("@UID", MySqlDbType.VarChar).Value = UID;
                    command.Parameters.Add("@Description", MySqlDbType.VarChar).Value = Description;
                    command.Parameters.Add("@Folder", MySqlDbType.VarChar).Value = Folder;
                    command.Parameters.Add("@SourceFolder ", MySqlDbType.VarChar).Value = SourceFolder;
                    command.Parameters.Add("@UpdateDateTime ", MySqlDbType.DateTime).Value = UpdateDateTime;
                    command.Parameters.Add("@UserIdUpdatedBy ", MySqlDbType.VarChar).Value = UserIdUpdatedBy;
                    
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        LogFile.WriteToTodaysLogFile(ex.ToString(), null, null, "ClientDocumentSet.cs");

                        ResponseStatus responseStatusError = new ResponseStatus(MessageType.Error);
                        responseStatusError.Message = "Error updating documentset " + ex;
                        responseStatusError.ReturnCode = -0010;
                        responseStatusError.ReasonCode = 0002;
                    }
                }
            }
            return responseStatus;
        }


        /// <summary>
        /// Database fields
        /// </summary>
        public struct FieldName
        {
            public const string UID = "UID";
            public const string FKClientUID = "FKClientUID";
            public const string ClientSetID = "ClientSetID"; 
            public const string Description = "Description";
            public const string Folder = "Folder";
            public const string FolderOnly = "FolderOnly";
            public const string Status = "Status"; 
            public const string StartDate = "StartDate";
            public const string EndDate = "EndDate";
            public const string SourceFolder = "SourceFolder";
            public const string IsVoid = "IsVoid";
            public const string UserIdCreatedBy = "UserIdCreatedBy";
            public const string UserIdUpdatedBy = "UserIdUpdatedBy";
            public const string CreationDateTime = "CreationDateTime";
            public const string UpdateDateTime = "UpdateDateTime";
        }


        /// <summary>
        /// Client string of fields.
        /// </summary>
        /// <returns></returns>
        private static string ClientDocumentSetFieldString()
        {
            return (
                        FieldName.UID
                + "," + FieldName.FKClientUID
                + "," + FieldName.ClientSetID
                + "," + FieldName.Description
                + "," + FieldName.Folder
                + "," + FieldName.FolderOnly
                + "," + FieldName.Status
                + "," + FieldName.StartDate
                + "," + FieldName.EndDate
                + "," + FieldName.SourceFolder
                + "," + FieldName.IsVoid
                + "," + FieldName.CreationDateTime
                + "," + FieldName.UpdateDateTime
                + "," + FieldName.UserIdCreatedBy
                + "," + FieldName.UserIdUpdatedBy
            );

        }

        /// <summary>
        /// Load db data into memory
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="reader"></param>
        private static void LoadObject(ClientDocumentSet obj, MySqlDataReader reader)
        {
            obj.UID = Convert.ToInt32(reader[FieldName.UID]);
            obj.FKClientUID = Convert.ToInt32(reader[FieldName.FKClientUID]);
            try { obj.Description = reader[FieldName.Description].ToString(); }
            catch { obj.Description = ""; }
            obj.Folder = reader[FieldName.Folder].ToString();
            obj.FolderOnly = reader[FieldName.FolderOnly].ToString();
            obj.StartDate = Convert.ToDateTime(reader[FieldName.StartDate].ToString());
            obj.EndDate = Convert.ToDateTime(reader[FieldName.EndDate].ToString());
            obj.ClientSetID = Convert.ToInt32(reader[FieldName.ClientSetID].ToString());
            obj.SourceFolder = reader[FieldName.SourceFolder].ToString();
            obj.Status = reader[FieldName.Status].ToString();
            obj.IsVoid = reader[FieldName.IsVoid].ToString();
            
            // Derived field
            obj.CombinedIDName = obj.FKClientUID + ";" + obj.ClientSetID + "; " + obj.Description + "; " + obj.Status;
            
            try { obj.UpdateDateTime = Convert.ToDateTime(reader[FieldName.UpdateDateTime].ToString()); }
            catch { obj.UpdateDateTime = DateTime.Now; }
            try { obj.CreationDateTime = Convert.ToDateTime(reader[FieldName.CreationDateTime].ToString()); }
            catch { obj.CreationDateTime = DateTime.Now; }
            try { obj.IsVoid = reader[FieldName.IsVoid].ToString(); }
            catch { obj.IsVoid = "N"; }
            try { obj.UserIdCreatedBy = reader[FieldName.UserIdCreatedBy].ToString(); }
            catch { obj.UserIdCreatedBy = "N"; }
            try { obj.UserIdUpdatedBy = reader[FieldName.UserIdCreatedBy].ToString(); }
            catch { obj.UserIdCreatedBy = "N"; }


        }


        /// <summary>
        /// Return a list of document sets for a given client.
        /// </summary>
        /// <param name="iClientUID"></param>
        /// <param name="sortOrder"></param>
        /// <returns></returns>
        public static List<ClientDocumentSet> List(int iClientUID, string sortOrder = "DESC")
        {
            List <ClientDocumentSet> documentSetList = new List<ClientDocumentSet>();

            // cds.FKClientUID + ";" + cds.ClientSetID + "; " + cds.Description + "; " +cds.Status
            //
            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {

                var commandString = string.Format(
                " SELECT  " +
                ClientDocumentSetFieldString() +
                "   FROM ClientDocumentSet " +
                " WHERE FKClientUID = '{0}' " +
                " ORDER BY ClientSetID " +
                sortOrder
                ,
                iClientUID);

                using (var command = new MySqlCommand(
                                      commandString, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ClientDocumentSet _clientDocumentSet = new ClientDocumentSet();
                            LoadObject(_clientDocumentSet, reader);

                            documentSetList.Add(_clientDocumentSet);

                        }
                    }
                }
            }

            return documentSetList;
        }

        public List<Document> ListDocumentsNotInSet( HeaderInfo headerInfo, int clientUID, int clientDocumentSetUID )
        {
            var documentsNotInSet = new List<Document>();
            var documentsInSet = new List<ClientDocument>();
            var fullListOfDocuments = new List<Document>();

            fullListOfDocuments = RepDocument.ListDocuments( headerInfo );
            documentsInSet = RepClientDocument.ListCD( clientUID, clientDocumentSetUID );

            bool found = false;

            foreach ( var document in fullListOfDocuments )
            {
                found = false;

                foreach ( var documentInSet in documentsInSet )
                {
                    // Document already in set
                    if ( document.UID == documentInSet.FKDocumentUID )
                    {
                        found = true;
                        break;
                    }
                }

                if ( found )
                    continue;

                // if gets to this point, document is not in set

                documentsNotInSet.Add( document );
            }

            return documentsNotInSet;

        }


        public ClientDocument ListClientDocumentsByFolder( int clientUID, int clientDocumentSetUID)
        {
            ClientDocument listofdocuments = new ClientDocument();
            listofdocuments.clientDocumentList = new List<ClientDocument>();
            listofdocuments.clientDocSetDocLink = new List<scClientDocSetDocLink>();

            listofdocuments.FKClientUID = clientUID;
            listofdocuments.clientDocumentSet.UID = clientDocumentSetUID;
            listofdocuments.FKClientDocumentSetUID = clientDocumentSetUID;

            // 1 - Get list of documents
            
            var clientDocumentListRequest = new BUSClientDocument.ClientDocumentListRequest();
            clientDocumentListRequest.clientDocumentSetUID = clientDocumentSetUID;
            clientDocumentListRequest.clientUID = clientUID;

            var clientDocumentListResponse = BUSClientDocument.List(clientDocumentListRequest);

            // 2 - Move into a tree to order
            TreeView tvFileList = new TreeView();

            tvFileList.Nodes.Clear();
            ListInTree(tvFileList, "CLIENT", clientDocumentListResponse.clientList);
           
            if (tvFileList.Nodes.Count > 0)
                tvFileList.Nodes[0].Expand();

            // 3 - Move to an ordered list
            foreach (TreeNode documentNode in tvFileList.Nodes)
            {
                var docnode = (scClientDocSetDocLink) documentNode.Tag;

                listofdocuments.clientDocSetDocLink.Add(docnode);

                // If there are inner nodes
                //
                if (documentNode.Nodes.Count > 0)
                {
                    ListInOrder(documentNode, listofdocuments.clientDocSetDocLink);
                }
            }

            // 4 - Return list
            return listofdocuments;
        }

        private void ListInOrder(TreeNode treeNode, List<scClientDocSetDocLink> documentList)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {

                var scClientDocSetDocLink = (scClientDocSetDocLink) node.Tag;
                documentList.Add(scClientDocSetDocLink);

                if (node.Nodes.Count > 0)
                {
                    ListInOrder(node, documentList);
                }
            }
        }

        private static void ListInTree(TreeView fileList, string listType, List<scClientDocSetDocLink> clientDocSetDocLink)
        {

            // listType = CLIENT
            // listType = FCM = default;

            string ListType = listType;
            if (ListType == null)
                ListType = "FCM";


            foreach (var docLinkSet in clientDocSetDocLink)
            {
                // Check if folder has a parent

                string cdocumentUID = docLinkSet.clientDocument.UID.ToString();
                string cparentIUID = docLinkSet.clientDocument.ParentUID.ToString();
                TreeNode treeNode = new TreeNode();

                int image = 0;
                int imageSelected = 0;
                docLinkSet.clientDocument.RecordType = docLinkSet.clientDocument.RecordType.Trim();

                image = FCMUtils.Utils.GetFileImage(docLinkSet.clientDocument.SourceFilePresent, docLinkSet.clientDocument.DestinationFilePresent, docLinkSet.clientDocument.DocumentType);
                imageSelected = image;

                string treenodename = docLinkSet.document.FileName;

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

    
    }
}
