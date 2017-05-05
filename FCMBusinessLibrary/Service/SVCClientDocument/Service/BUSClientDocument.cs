using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using FCMMySQLBusinessLibrary.FCMUtils;
using FCMMySQLBusinessLibrary.Model.ModelClientDocument;
using FCMMySQLBusinessLibrary.Model.ModelDocument;
using FCMMySQLBusinessLibrary.Repository.RepositoryClientDocument;
using FCMMySQLBusinessLibrary.Repository.RepositoryDocument;
using FCMMySQLBusinessLibrary.Service.SVCClientDocument.Interface;
using FCMMySQLBusinessLibrary.Service.SVCClientDocument.ServiceContract;
using FCMMySQLBusinessLibrary.Service.SVCDocument.Service;
using FCMMySQLBusinessLibrary.Service.SVCDocument.ServiceContract;
using MackkadoITFramework.Utils;
using MackkadoITFramework.ErrorHandling;
using Utils = MackkadoITFramework.Helper.Utils;

namespace FCMMySQLBusinessLibrary.Service.SVCClientDocument.Service
{
    public class BUSClientDocument 
    
    {
        /// <summary>
        /// Client document list
        /// </summary>
        /// <returns></returns>
        public static ClientDocumentListResponse List( ClientDocumentListRequest request )
        {
            var response = new ClientDocumentListResponse();
            response.clientList = new List<scClientDocSetDocLink>();

            response.clientList = RepClientDocument.ListS( request.clientUID, request.clientDocumentSetUID );

            return response;

        }

        /// <summary>
        /// Client document list
        /// </summary>
        /// <param name="clientDocument"> </param>
        /// <param name="clientID"> </param>
        /// <param name="clientDocumentSetUID"> </param>
        /// <returns></returns>
        public static void ListCD( ClientDocument clientDocument, int clientID, int clientDocumentSetUID )
        {
            RepClientDocument.List( clientDocument, clientID, clientDocumentSetUID );
        }


        /// <summary>
        /// Client document read
        /// </summary>
        /// <returns></returns>
        public static ClientDocument ClientDocumentReadS(int clientDocumentUID)
        {
            return RepClientDocument.Read( clientDocumentUID );
        }

        /// <summary>
        /// Client document update
        /// </summary>
        /// <returns></returns>
        public static SCClientDocument.ClientDocumentUpdateResponse ClientDocumentUpdate( ClientDocument clientDocument )
        {
            var clientDocumentUpdateResponse = new SCClientDocument.ClientDocumentUpdateResponse();
            clientDocumentUpdateResponse.responseStatus = RepClientDocument.Update( clientDocument );

            return clientDocumentUpdateResponse;
        }

        /// <summary>
        /// Client document delete multiple
        /// </summary>
        /// <returns></returns>
        public static ResponseStatus ClientDocumentDeleteMultiple( HeaderInfo headerInfo, int clientUID, int clientDocumentSetUID, List<int> documentIDList )
        {
            ResponseStatus response = new ResponseStatus();

            foreach (var i in documentIDList)
            {
                response = ClientDocumentDelete(headerInfo, clientUID, clientDocumentSetUID, i);
            }
            
            return response;
        }

        /// <summary>
        /// Client document delete
        /// </summary>
        /// <returns></returns>
        public static ResponseStatus ClientDocumentDelete( HeaderInfo headerInfo, int clientUID, int clientDocumentSetUID, int clientDocumentUID )
        {

            string filePhysicallyRemoved = "";

            // Get client document
            var clientDocument = RepClientDocument.Read( clientDocumentUID );

            // Delete file from folder
            var fileNamePath = Utils.getFilePathNameLOCAL( clientDocument.clientDocumentSet.Folder + clientDocument.Location, clientDocument.FileName );

            if ( File.Exists( fileNamePath ) )
            {
                filePhysicallyRemoved = " File exists but not removed. ";
                try
                {
                    File.Delete( fileNamePath );
                    filePhysicallyRemoved = " File exists and has been removed. ";
                }
                catch ( Exception ex )
                {
                    LogFile.WriteToTodaysLogFile( "Error deleting file after Remove issued" + ex );
                    filePhysicallyRemoved = " File exists but not removed. ";
                }
            }

            // Delete record from database
            var response = RepClientDocument.Delete( clientUID, clientDocumentSetUID, clientDocumentUID );

            response.Message = response.Message.Trim() + filePhysicallyRemoved;

            LogFile.WriteToTodaysLogFile( response.Message + " " + clientDocument.FileName + " " + clientDocument.UID, headerInfo.UserID, "", "BUSClientDocument.cs" );

            return response;
        }


        public static string NewVersion( ClientDocument clientDocument )
        {
            return RepClientDocument.NewVersion( clientDocument );
        }

        public static string NewVersionWeb( ClientDocument clientDocument )
        {
            return RepClientDocument.NewVersionWeb( clientDocument );
        }


        public static void ListProjectPlanInTree(ClientDocument clientDocument, int clientID, int clientDocumentSetUID, TreeView fileList)
        {
            RepClientDocument.ListProjectPlanInTree(clientDocument, clientID, clientDocumentSetUID, fileList);
        }
        
        public static void ListInTree(ClientDocument clientDocument, TreeView fileList, string listType)
        {
            RepClientDocument.ListInTree(clientDocument, fileList, listType);
        }
        
        public static void ListImpacted(ClientDocument clientDocument, Model.ModelDocument.Document document)
        {
            RepClientDocument.ListImpacted(clientDocument, document);
        }

        public static void AddRootFolder( ClientDocument clientDocument, int clientUID, int DocSetUID, string DestinationFolder )
        {
            RepClientDocument.AddRootFolder(clientDocument, clientUID, DocSetUID, DestinationFolder);
        }

        public static string GetComboIssueNumber( string documentCUID, int documentVersionNumber, int clientUID )
        {

            return RepClientDocument.GetComboIssueNumber( documentCUID,
                                                  documentVersionNumber,
                                                  clientUID );
        }

        public static int GetLastClientCUID( int clientUID )
        {
            return RepClientDocument.GetLastClientCUID( clientUID );

        }

        public static int LinkDocumentToClientSet(scClientDocSetDocLink doco)
        {
            return RepClientDocument.LinkDocumentToClientSet(doco);
        }

        public static ResponseStatus SetToVoid(int clientUID, int clientDocumentSetUID, int documentUID)
        {
            RepClientDocument.SetToVoid(clientUID, clientDocumentSetUID, documentUID);
            return new ResponseStatus();
        }

        /// <summary>
        /// Delete file
        /// </summary>
        /// <param name="clientDocumentUID"></param>
        /// <returns></returns>
        public static ResponseStatus DeleteFile( int clientDocumentUID )
        {
            RepClientDocument.DeleteFile( clientDocumentUID );
            return new ResponseStatus();
        }

        /// <summary>
        /// Get Client Document Path
        /// </summary>
        /// <param name="clientDocument"></param>
        /// <returns></returns>
        public static ResponseStatus GetClientDocumentPath(ClientDocument clientDocument)
        {
            var response = RepClientDocument.GetDocumentPath(clientDocument);
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        public class ClientDocumentListRequest
        {
            public HeaderInfo headerInfo;
            public int clientUID;
            public int clientDocumentSetUID;
        }

        /// <summary>
        /// 
        /// </summary>
        public class ClientDocumentListResponse
        {
            public List<scClientDocSetDocLink> clientList;
            public ResponseStatus response;
        }

        /// <summary>
        /// 
        /// </summary>
        public class ClientDocumentListCDResponse
        {
            public List<ClientDocument> clientList;
            public ResponseStatus response;
        }

        /// <summary>
        /// Associate documents from selected document set to selected client
        /// </summary>
        /// <param name="clientDocumentSet"> </param>
        /// <param name="documentSetUID"></param>
        /// <param name="headerInfo"> </param>
        public static void AssociateDocumentsToClient(
            ClientDocumentSet clientDocumentSet, 
            int documentSetUID,
            HeaderInfo headerInfo)
        {
            // It is a new client document set
            // It maybe a new client, the client document set MUST be new or empty
            // 1) Instantiate a TREE for the Client Document Set document
            // 2) Instantiate a second tree for the documents related to that document set
            // 3) Now the old copy all starts, all the nodes from the second tree are moved to the new tree
            //    following current process
            // 4) Save happens as per usual
            //

            TreeView tvFileList = new TreeView(); // This is the list of documents for a client, it should be EMPTY
            TreeView tvDocumentsAvailable = new TreeView(); // This is the list of documents for a client, it should be EMPTY
            string folderOnly = clientDocumentSet.FolderOnly; // Contains the folder location of the file

            // Add root folder
            //
            ClientDocument clientDocument = new ClientDocument();
            // clientDocument.AddRootFolder( clientDocumentSet.FKClientUID, clientDocumentSet.ClientSetID, clientDocumentSet.FolderOnly );

            RepClientDocument.AddRootFolder( clientDocument, clientDocumentSet.FKClientUID, clientDocumentSet.ClientSetID, clientDocumentSet.FolderOnly );

            // List client document list !!!!!!! Important because the ROOT folder is loaded ;-)
            
            var documentSetList = new ClientDocument();
            // documentSetList.List( clientDocumentSet.FKClientUID, clientDocumentSet.ClientSetID );

            RepClientDocument.List( documentSetList, clientDocumentSet.FKClientUID, clientDocumentSet.ClientSetID );

            tvFileList.Nodes.Clear();
            // documentSetList.ListInTree(tvFileList, "CLIENT");

            RepClientDocument.ListInTree(documentSetList, tvFileList, "CLIENT" );

            if (tvFileList.Nodes.Count > 0)
                tvFileList.Nodes[0].Expand();

            // Load available documents
            //
            tvDocumentsAvailable.Nodes.Clear();

            // Get document list for a given document set
            //
            DocumentSet documentSet = new DocumentSet();
            documentSet.UID = documentSetUID;
            documentSet.Read(IncludeDocuments: 'Y');
            
            // Load document in the treeview
            //
            Model.ModelDocument.Document root = new Model.ModelDocument.Document();
            // root.GetRoot(headerInfo);

            root = RepDocument.GetRoot(headerInfo);

            DocumentList.ListInTree(tvDocumentsAvailable, documentSet.documentList, root);

            while (tvDocumentsAvailable.Nodes[0].Nodes.Count > 0)
            {
                TreeNode tn = tvDocumentsAvailable.Nodes[0].Nodes[0];
                tn.Remove();

                tvFileList.Nodes[0].Nodes.Add(tn);
            }

            tvFileList.SelectedNode = tvFileList.Nodes[0];

            // -------------------------------------------------------------------
            // The documents have been moved from the available to client's tree
            // Now it is time to save the documents
            // -------------------------------------------------------------------
            Save(clientDocumentSet, documentSetUID, tvFileList);

            ClientDocumentLink cloneLinks = new ClientDocumentLink();
            cloneLinks.ReplicateDocSetDocLinkToClient(clientDocumentSet.FKClientUID, clientDocumentSet.ClientSetID, documentSetUID);

        }

        // ----------------------------------------------------------
        //                 Save client documents
        // ----------------------------------------------------------
        private static void Save(
                ClientDocumentSet clientDocumentSet,
                int documentSetUID,
                TreeView tvFileList

            )
        {
            ClientDocument cdsl = new ClientDocument();
            ClientDocumentSet docSet = new ClientDocumentSet();

            var lodsl = new ListOfscClientDocSetDocLink();
            lodsl.list = new List<scClientDocSetDocLink>();

            // Move data into views..

            int selUID = documentSetUID;

            docSet.Get(clientDocumentSet.FKClientUID, selUID);
            docSet.ClientSetID = selUID;
            docSet.Folder = clientDocumentSet.Folder;
            docSet.SourceFolder = clientDocumentSet.SourceFolder;
            docSet.Description = clientDocumentSet.Description;
            docSet.Update();

            // Save complete tree...

            SaveTreeViewToClient(tvFileList, 0, clientDocumentSet);

        }

        // -------------------------------------------------------------------
        //                Saves TreeView of a client tree
        // -------------------------------------------------------------------
        private static void SaveTreeViewToClient(TreeView treeView, int parentID, ClientDocumentSet clientDocumentSet)
        {
            foreach (TreeNode node in treeView.Nodes)
            {
                var documentLink = (scClientDocSetDocLink)node.Tag;

                SaveTreeNodeToClient(node, documentLink.clientDocument.UID, clientDocumentSet);
            }
        }


        // -------------------------------------------------------------------
        //                Saves TreeNode of a client tree
        // -------------------------------------------------------------------
        private static TreeNode SaveTreeNodeToClient(TreeNode treeNode, int parentID, ClientDocumentSet clientDocumentSet)
        {
            TreeNode ret = new TreeNode();
            ClientDocument cdsl = new ClientDocument();

            var t = treeNode.Tag.GetType();

            // If the type is not document, it is an existing document
            //
            // var documentLink = new FCMStructures.scClientDocSetDocLink();
            var documentLink = new scClientDocSetDocLink();

            if (t.Name == "scClientDocSetDocLink")
            {
                documentLink = (scClientDocSetDocLink)treeNode.Tag;
                documentLink.clientDocument.SequenceNumber = treeNode.Index;

            }

            //
            // If the type is Document, it means a new document added to the client
            // list
            //
            if (t.Name == "Document")
            #region Document
            {
                documentLink.document = new Model.ModelDocument.Document();
                documentLink.document = (Model.ModelDocument.Document)treeNode.Tag;

                documentLink.clientDocument = new ClientDocument();
                documentLink.clientDocumentSet = new ClientDocumentSet();

                // Fill in the extra details...
                //

                documentLink.clientDocument.EndDate = System.DateTime.MaxValue;
                documentLink.clientDocument.FKClientDocumentSetUID = clientDocumentSet.ClientSetID; // Utils.ClientSetID;
                documentLink.clientDocument.FKClientUID = clientDocumentSet.FKClientUID; //Utils.ClientID;
                if (clientDocumentSet.FKClientUID <= 0)
                {
                    MessageBox.Show("Client ID not supplied.");
                    return null;
                }
                documentLink.clientDocument.FKDocumentUID = documentLink.document.UID;
                documentLink.clientDocument.Generated = 'N';
                documentLink.clientDocument.SourceIssueNumber = documentLink.document.IssueNumber;
                documentLink.clientDocument.ClientIssueNumber = 00;

                // When the source is client, the name will have already all the numbers
                //
                //if (documentLink.document.SourceCode == Utils.SourceCode.CLIENT)
                //{
                //    documentLink.clientDocument.ComboIssueNumber = documentLink.document.CUID;
                //}
                //else
                //{

                //}

                if (documentLink.document.RecordType == Utils.RecordType.FOLDER)
                {
                    documentLink.clientDocument.ComboIssueNumber = documentLink.document.CUID;
                    documentLink.clientDocument.FileName = documentLink.document.SimpleFileName;
                }
                else
                {
                    documentLink.clientDocument.ComboIssueNumber =
                    RepClientDocument.GetComboIssueNumber(documentLink.document.CUID,
                                                       documentLink.document.IssueNumber,
                                                       clientDocumentSet.FKClientUID);

                    documentLink.clientDocument.FileName = documentLink.clientDocument.ComboIssueNumber + " " +
                                                       documentLink.document.SimpleFileName;
                }
                documentLink.clientDocument.IsProjectPlan = documentLink.document.IsProjectPlan;
                documentLink.clientDocument.DocumentCUID = documentLink.document.CUID;
                documentLink.clientDocument.DocumentType = documentLink.document.DocumentType;
                // The client document location includes the client path (%CLIENTFOLDER%) plus the client document set id
                // %CLIENTFOLDER%\CLIENTSET201000001R0001\


                // How to identify the parent folder
                //
                // documentLink.clientDocument.ParentUID = destFolder.clientDocument.UID;
                documentLink.clientDocument.ParentUID = parentID;

                //  documentLink.clientDocument.Location = txtDestinationFolder.Text +
                //                                         Utils.GetClientPathInside(documentLink.document.Location);

                documentLink.clientDocument.Location = GetClientDocumentLocation(parentID);

                documentLink.clientDocument.RecordType = documentLink.document.RecordType;
                documentLink.clientDocument.SequenceNumber = treeNode.Index;
                documentLink.clientDocument.SourceFileName = documentLink.document.FileName;
                documentLink.clientDocument.SourceLocation = documentLink.document.Location;

                documentLink.clientDocument.StartDate = System.DateTime.Today;
                documentLink.clientDocument.UID = 0;

                documentLink.clientDocumentSet.UID = clientDocumentSet.ClientSetID; // clientDocumentSet.UID; // Utils.ClientSetID;
                documentLink.clientDocumentSet.SourceFolder = clientDocumentSet.SourceFolder;
                documentLink.clientDocumentSet.ClientSetID = clientDocumentSet.ClientSetID; // Utils.ClientSetID;
                documentLink.clientDocumentSet.FKClientUID = clientDocumentSet.FKClientUID;
                documentLink.clientDocumentSet.Folder = clientDocumentSet.Folder;
            }
            #endregion Document

            // Save link to database
            //
            // documentLink.clientDocument.UID = cdsl.LinkDocumentToClientSet(documentLink);

            documentLink.clientDocument.UID = RepClientDocument.LinkDocumentToClientSet( documentLink );

            foreach (TreeNode children in treeNode.Nodes)
            {
                SaveTreeNodeToClient(children, documentLink.clientDocument.UID, clientDocumentSet);
            }


            return ret;
        }

        /// <summary>
        /// Retrieve the parent folder for a given document
        /// </summary>
        /// <returns></returns>
        public static string GetClientDocumentLocation(int clientDocumentUID)
        {
            string ret = "";
            var clientDocument = BUSClientDocument.ClientDocumentReadS( clientDocumentUID );

            if ( clientDocument.UID > 0)
            {
                //  This is to prevent the first level from taking an extra \\ at the front
                // it was causing the folder to be like \\%CLIENTFOLDER%\\
                // At the end the client folder was replace by a physical path
                // and it appears like "\\c:\\fcm\\document\\"

                clientDocument.Location = clientDocument.Location.Trim();

                if (string.IsNullOrEmpty(clientDocument.Location))
                    ret = clientDocument.FileName;
                else
                    ret = clientDocument.Location + "\\" + clientDocument.SourceFileName;

                // ret = clientDocument.Location + "\\" + clientDocument.FileName;

            }
            return ret;
        }



        /// <summary>
        /// List of documents
        /// </summary>
        public static List<Document> ListDocumentsNotInSet( HeaderInfo headerInfo, int clientUID, int documentSetUID )
        {
            ClientDocumentSet documentSet = new ClientDocumentSet();
            documentSet.UID = documentSetUID;

            var documentsNotInSet = documentSet.ListDocumentsNotInSet( headerInfo, clientUID, documentSetUID );

            return documentsNotInSet;
        }

        /// <summary>
        /// Add FCM document to Client Set
        /// </summary>
        /// <param name="headerInfo"></param>
        /// <param name="clientUID"></param>
        /// <param name="clientDocumentSetUID"></param>
        /// <param name="documentUID"></param>
        /// <returns></returns>
        public static ResponseStatus AddDocumentToSet( HeaderInfo headerInfo, int clientUID, int clientDocumentSetUID, int documentUID )
        {
            string sourceFolder = "";
            string destinationFolder = "";


            if ( clientUID <= 0 )
                return new ResponseStatus { Message = "Client UID was not supplied.", XMessageType = MessageType.Error, ReturnCode = -0020, ReasonCode = 0001};

            if ( clientDocumentSetUID <= 0 )
                return new ResponseStatus { Message = "Client Document Set UID  was not supplied.", XMessageType = MessageType.Error, ReturnCode = -0020, ReasonCode = 0002 };

            if ( documentUID <= 0 )
                return new ResponseStatus { Message = "Document UID  was not supplied.", XMessageType = MessageType.Error, ReturnCode = -0020, ReasonCode = 0003 };

            // Find Document
            //
            DocumentReadRequest documentReadRequest = new DocumentReadRequest();
            documentReadRequest.headerInfo = headerInfo;
            documentReadRequest.retrieveVoidedDocuments = false;
            documentReadRequest.UID = documentUID;

            var documentReadResponse = BUSDocument.DocumentRead( documentReadRequest );
            var documentSelected = new Document();
            documentSelected = documentReadResponse.document;

            // Find parent of the document
            //
            var folderReadRequestParent = new DocumentReadRequest();
            folderReadRequestParent.headerInfo = headerInfo;
            folderReadRequestParent.retrieveVoidedDocuments = false;
            folderReadRequestParent.UID = documentSelected.ParentUID; // Reading parent

            var folderParentResponse = BUSDocument.DocumentRead( folderReadRequestParent );
            var folderParent = new Document();
            folderParent = folderParentResponse.document;

            // Find the equivalent parent in ClientDocumentSetDocument
            //
            var foundParent = RepClientDocument.Find(folderParent.UID, clientDocumentSetUID, 'N', clientUID);
            if ( foundParent.UID <= 0 )
                return new ResponseStatus { Message = "Parent folder not found.", XMessageType = MessageType.Error, ReturnCode = -0020, ReasonCode = 0006 };

            // Find ClientDocumentSet
            //
            var clientDocumentSet = new ClientDocumentSet();
            clientDocumentSet.UID = clientDocumentSetUID;
            clientDocumentSet.FKClientUID = clientUID;
            clientDocumentSet.Read();

            if ( clientDocumentSet.UID <= 0 )
                return new ResponseStatus { Message = "Client Document Set not found.", XMessageType = MessageType.Error, ReturnCode = -0030, ReasonCode = 0004};

            // Create link
            //
            var documentLink = new scClientDocSetDocLink();

            if ( documentSelected.RecordType == "DOCUMENT" )
            #region Document
            {
                documentLink.document = new Document();
                documentLink.document = documentSelected;

                documentLink.clientDocument = new ClientDocument();
                documentLink.clientDocumentSet = new ClientDocumentSet();

                // Fill in the extra details...
                //

                documentLink.clientDocument.EndDate = System.DateTime.MaxValue;
                documentLink.clientDocument.FKClientDocumentSetUID = clientDocumentSet.UID;
                documentLink.clientDocument.FKClientUID = clientDocumentSet.FKClientUID;
                documentLink.clientDocument.FKDocumentUID = documentLink.document.UID;
                documentLink.clientDocument.Generated = 'N';
                documentLink.clientDocument.SourceIssueNumber = documentLink.document.IssueNumber;
                documentLink.clientDocument.ClientIssueNumber = 00;

                if ( documentLink.document.RecordType == FCMConstant.RecordType.FOLDER )
                {
                    documentLink.clientDocument.ComboIssueNumber = documentLink.document.CUID;
                    documentLink.clientDocument.FileName = documentLink.document.SimpleFileName;
                }
                else
                {
                    documentLink.clientDocument.ComboIssueNumber =
                    BUSClientDocument.GetComboIssueNumber( documentLink.document.CUID,
                                                           documentLink.document.IssueNumber,
                                                           clientDocumentSet.FKClientUID );


                    documentLink.clientDocument.FileName = documentLink.clientDocument.ComboIssueNumber + " " +
                                                       documentLink.document.SimpleFileName;
                }
                documentLink.clientDocument.IsProjectPlan = documentLink.document.IsProjectPlan;
                documentLink.clientDocument.DocumentCUID = documentLink.document.CUID;
                documentLink.clientDocument.DocumentType = documentLink.document.DocumentType;
                // The client document location includes the client path (%CLIENTFOLDER%) plus the client document set id
                // %CLIENTFOLDER%\CLIENTSET201000001R0001\


                // How to identify the parent folder
                //
                documentLink.clientDocument.ParentUID = foundParent.UID;

                // Daniel
                // 01-Jul-2013
                // Retrieving the clientdocument parent using the UID for the parent clientdocument
                //
//                documentLink.clientDocument.Location = BUSClientDocument.GetClientDocumentLocation(folderReadRequestParent.UID);
                documentLink.clientDocument.Location = BUSClientDocument.GetClientDocumentLocation(foundParent.UID);

                documentLink.clientDocument.RecordType = documentLink.document.RecordType;
                documentLink.clientDocument.SequenceNumber = 1;
                documentLink.clientDocument.SourceFileName = documentLink.document.FileName;
                documentLink.clientDocument.SourceLocation = documentLink.document.Location;

                documentLink.clientDocument.StartDate = System.DateTime.Today;
                documentLink.clientDocument.UID = 0;

                documentLink.clientDocumentSet.UID = clientDocumentSetUID;
                documentLink.clientDocumentSet.SourceFolder = sourceFolder;
                documentLink.clientDocumentSet.ClientSetID = clientDocumentSet.UID;
                documentLink.clientDocumentSet.FKClientUID = clientDocumentSet.FKClientUID;
                documentLink.clientDocumentSet.Folder = destinationFolder;
            }
            #endregion Document

            // Save link to database
            //
            // documentLink.clientDocument.UID = cdsl.LinkDocumentToClientSet(documentLink);

            documentLink.clientDocument.UID = LinkDocumentToClientSet( documentLink );

            return new ResponseStatus();

        }

        /// <summary>
        /// This method adds a new document to a client.
        /// The document is not a document from the MASTER set. 
        /// It is a specific document for the client - it will not be replaced or generated.
        /// This client document is not related to a MASTER document.
        /// </summary>
        /// <returns></returns>
        public static ResponseStatus AddNewDocumentToClient( ClientDocument clientDocument )
        {
            var response = RepClientDocument.Add(clientDocument);

            return new ResponseStatus();
        }


        /// <summary>
        /// List of documents
        /// </summary>
        public static ClientDocument ListClientDocumentsByFolder(int clientUID, int documentSetUID)
        {
            ClientDocumentSet documentSet = new ClientDocumentSet();
            documentSet.UID = documentSetUID;

            var clientdocument = documentSet.ListClientDocumentsByFolder(clientUID, documentSetUID);

            return clientdocument;
        }


        /// <summary>
        /// Client document list
        /// </summary>
        /// <returns></returns>
        public static void ListDocuments(ClientDocument clientDocument, int clientID, int clientDocumentSetUID)
        {
            RepClientDocument.List(clientDocument, clientID, clientDocumentSetUID, " AND CD.RecordType = 'DOCUMENT' ");
        }

    }
}
