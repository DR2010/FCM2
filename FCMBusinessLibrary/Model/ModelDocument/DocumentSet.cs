using System;
using System.Collections.Generic;
using FCMMySQLBusinessLibrary.Repository.RepositoryDocument;
using MackkadoITFramework.Utils;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace FCMMySQLBusinessLibrary.Model.ModelDocument
{
    public class DocumentSet
    {

        public int UID { get; set; }
        public string Name { get; set; }
        public string TemplateType { get; set; }
        public string TemplateFolder { get; set; }
        public char IsVoid { get; set; }
        public DocumentList documentList { get; set; }
        public List<Document> listOfDocumentsInSet { get; set; }
        public List<DocumentSet> documentSetList { get; set; }
        public string UIDNameDisplay { get; set; }

        /// <summary>
        /// Load document into document set
        /// </summary>
        public void LoadAllDocuments()
        {

            // Retrieve all documents
            // For each document (order by parent uid)
                // check if it is already connected to current Document Set
                // If it is not, connect document
                // Link with parent document in the set
            // Replicate Document Links


            // 21/08/2013
            // Stop using DocumentList
            //

            //DocumentList dl = new DocumentList();
            //dl.List();

            List<Document> docl = RepDocument.List(HeaderInfo.Instance);

            foreach (Document document in docl)
            {
                var found = DocumentSet.FindDocumentInSet(this.UID, document.UID);

                if (found.document.UID > 0)
                    continue;
                else
                {
                    DocumentSetDocument dsl = new DocumentSetDocument();

                    // Generate new UID
                    dsl.UID = this.GetLastUID() + 1;
                  
                    // Add document to set
                    //
                    dsl.FKDocumentSetUID = this.UID;
                    dsl.FKDocumentUID = document.UID;
                    dsl.Location = document.Location;
                    dsl.IsVoid = 'N';
                    dsl.StartDate = System.DateTime.Today;
                    dsl.EndDate = System.DateTime.MaxValue;
                    dsl.FKParentDocumentUID = document.ParentUID; // Uses the Document UID as the source (Has to be combined with Doc Set)
                    dsl.FKParentDocumentSetUID = dsl.FKDocumentSetUID; 
                    dsl.SequenceNumber = document.SequenceNumber;
                    
                    dsl.Add();

                }
            }

            // Replicate document links
            //
            foreach (Document document in docl)
            {
                var children = DocumentLinkList.ListRelatedDocuments(document.UID);

                foreach (var child in children.documentLinkList)
                {
                    // 
                    DocumentSetDocumentLink dsdl = new DocumentSetDocumentLink();
                    dsdl.FKParentDocumentUID = 0;
                    dsdl.FKChildDocumentUID = 0;
                    dsdl.IsVoid = 'N';
                    dsdl.LinkType = child.LinkType;
                    dsdl.UID = GetLastUID() + 1;

                    // Find parent

                    var parent1 = DocumentSet.FindDocumentInSet(this.UID, child.FKParentDocumentUID);

                    // Find child
                    var child1 = DocumentSet.FindDocumentInSet(this.UID, child.FKChildDocumentUID);

                    dsdl.FKParentDocumentUID = parent1.DocumentSetDocument.UID;
                    dsdl.FKChildDocumentUID = child1.DocumentSetDocument.UID;

                    dsdl.Add();

                }
            }

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
                    "SELECT MAX(UID) LASTUID FROM DocumentSet";

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
        //    Get Document Details
        // -----------------------------------------------------
        public static scDocoSetDocumentLink FindDocumentInSet(int documentSetUID, int documentUID)
        {
            // 
            // EA SQL database
            // 
            scDocoSetDocumentLink ret = new scDocoSetDocumentLink();
            ret.document = new Model.ModelDocument.Document();
            ret.documentSet = new DocumentSet();
            ret.DocumentSetDocument = new DocumentSetDocument();

            string commandString = "";

            commandString = string.Format(
                " SELECT " +
                "       Document.UID DocumentUID" +
                "      ,Document.CUID DocumentCUID " +
                "      ,Document.Name DocumentName " +
                "      ,Document.SequenceNumber DocumentSequenceNumber " +
                "      ,Document.IssueNumber DocumentIssueNumber " +
                "      ,Document.Location DocumentLocation "+
                "      ,Document.Comments DocumentComments" +
                "      ,Document.UID DocumentUID" +
                "      ,Document.FileName DocumentFileName" +
                "      ,Document.SourceCode DocumentSourceCode" +
                "      ,Document.FKClientUID DocumentFKClientUID" +
                "      ,Document.ParentUID DocumentParentUID" +
                "      ,Document.RecordType DocumentRecordType" +
                "      ,Document.IsProjectPlan DocumentIsProjectPlan" +
                "      ,Document.DocumentType DocumentDocumentType" +
                "      ,DocSetDoc.UID DocSetDocUID" +
                "      ,DocSetDoc.FKDocumentUID DocSetDocFKDocumentUID" +
                "      ,DocSetDoc.FKDocumentSetUID DocSetDocFKDocumentSetUID" +
                "      ,DocSetDoc.Location DocSetDocLocation" +
                "      ,DocSetDoc.IsVoid DocSetDocIsVoid" +
                "      ,DocSetDoc.StartDate DocSetDocStartDate" +
                "      ,DocSetDoc.EndDate DocSetDocEndDate" +
                "      ,DocSetDoc.FKParentDocumentUID DocSetDocFKParentDocumentUID" +
                "      ,DocSetDoc.FKParentDocumentSetUID DocSetDocFKParentDocumentSetUID" +
                "      ,DocSet.UID SetUID" +
                "      ,DocSet.TemplateType SetTemplateType" +
                "      ,DocSet.TemplateFolder SetTemplateFolder" +
                "  FROM  Document Document" +
                "       ,DocumentSetDocument DocSetDoc " +
                "       ,DocumentSet DocSet " +
                " WHERE " +
                "        Document.UID = DocSetDoc.FKDocumentUID "+
                "    AND DocSetDoc.FKDocumentSetUID = DocSet.UID " +
                "    AND Document.UID = {0} " +
                "    AND DocSetDoc.FKDocumentSetUID = {1}",
                documentUID,
                documentSetUID);

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        try
                        {
                            // Document
                            //
                            RepDocument.LoadDocumentFromReader(ret.document, "", reader);
                            //ret.document.UID = Convert.ToInt32(reader["DocumentUID"].ToString());
                            //ret.document.CUID = reader["DocumentCUID"].ToString();
                            //ret.document.Name = reader["DocumentName"].ToString();
                            //ret.document.SequenceNumber = Convert.ToInt32(reader["DocumentSequenceNumber"].ToString());
                            //ret.document.IssueNumber = Convert.ToInt32(reader["DocumentIssueNumber"].ToString());
                            //ret.document.Location = reader["DocumentLocation"].ToString();
                            //ret.document.Comments = reader["DocumentComments"].ToString();
                            //ret.document.FileName = reader["DocumentFileName"].ToString();
                            //ret.document.SourceCode = reader["DocumentSourceCode"].ToString();
                            //ret.document.FKClientUID = Convert.ToInt32(reader["DocumentFKClientUID"].ToString());
                            //ret.document.ParentUID = Convert.ToInt32(reader["DocumentParentUID"].ToString());
                            //ret.document.RecordType = reader["DocumentRecordType"].ToString();
                            //ret.document.IsProjectPlan = Convert.ToChar(reader["DocumentIsProjectPlan"]);
                            //ret.document.DocumentType = reader["DocumentDocumentType"].ToString();

                            // Document Set
                            //
                            ret.documentSet.UID = Convert.ToInt32(reader["SetUID"].ToString());
                            ret.documentSet.TemplateType = reader["SetTemplateType"].ToString();
                            ret.documentSet.TemplateFolder = reader["SetTemplateFolder"].ToString();
                            ret.documentSet.UIDNameDisplay = ret.documentSet.UID.ToString() +
                                                             "; " + ret.documentSet.TemplateType;

                            // DocumentSetDocument
                            //
                            ret.DocumentSetDocument.UID = Convert.ToInt32(reader["DocSetDocUID"].ToString());
                            ret.DocumentSetDocument.FKDocumentUID = Convert.ToInt32(reader["DocSetDocFKDocumentUID"].ToString());
                            ret.DocumentSetDocument.FKDocumentSetUID = Convert.ToInt32(reader["DocSetDocFKDocumentSetUID"].ToString());
                            ret.DocumentSetDocument.Location = reader["DocSetDocLocation"].ToString();
                            ret.DocumentSetDocument.IsVoid = Convert.ToChar(reader["DocSetDocIsVoid"].ToString());
                            ret.DocumentSetDocument.StartDate = Convert.ToDateTime(reader["DocSetDocStartDate"].ToString());
                            ret.DocumentSetDocument.EndDate = Convert.ToDateTime(reader["DocSetDocEndDate"].ToString());
                            ret.DocumentSetDocument.FKParentDocumentUID = Convert.ToInt32(reader["DocSetDocFKParentDocumentUID"].ToString());
                            ret.DocumentSetDocument.FKParentDocumentSetUID = Convert.ToInt32(reader["DocSetDocFKParentDocumentSetUID"].ToString());

                        }
                        catch 
                        {
                        }
                    }
                }
            }
            return ret;
        }

        // -----------------------------------------------------
        //    Get Document Set Details
        // -----------------------------------------------------
        public bool Read(char IncludeDocuments)
        {
            // 
            // EA SQL database
            // 
            bool ret = false;
            string commandString = "";

            commandString = string.Format(
                " SELECT UID " +
                "      ,TemplateType " +
                "      ,TemplateFolder " +
                "      ,IsVoid " +
                "  FROM DocumentSet " +
                " WHERE UID = {0} ",
                UID);

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {

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
                            this.TemplateType = reader["TemplateType"].ToString();
                            this.TemplateFolder = reader["TemplateFolder"].ToString();
                            this.UIDNameDisplay = this.UID + "; " + this.TemplateType;
                            this.IsVoid = Convert.ToChar(reader["IsVoid"].ToString());
                            ret = true;
                        }
                        catch (Exception ex)
                        {
                            LogFile.WriteToTodaysLogFile(ex.ToString());
                        }
                    }
                }

                if (IncludeDocuments == 'Y')
                {
                    this.documentList = new DocumentList();
                    this.documentList.ListDocSet(this.UID);

                    this.ListDocumentsInSet( this.UID );
                }
            }
            return ret;
        }

        public List<Document> ListDocumentsNotInSet(HeaderInfo headerInfo, int documentSetUID)
        {
            List<Document> documentsNotInSet = new List<Document>();
            List<Document> documentsInSet = new List<Document>();
            List<Document> fullListOfDocuments = new List<Document>();

            fullListOfDocuments = RepDocument.ListDocuments(headerInfo);
            
            ListDocumentsInSet(documentSetUID);
            documentsInSet = this.listOfDocumentsInSet;

            bool found = false;

            foreach (var document in fullListOfDocuments)
            {
                found = false;

                foreach (var documentInSet in listOfDocumentsInSet)
                {
                    // Document already in set
                    if ( document.CUID == documentInSet.CUID )
                    {
                        found = true;
                        break;
                    }
                }

                if (found)
                    continue;

                // if gets to this point, document is not in set
            
                documentsNotInSet.Add(document);
            }

            return documentsNotInSet;

        }


        // -----------------------------------------------------
        //    Delete Document/ Folder node
        // -----------------------------------------------------
        public static void DeleteDocumentTreeNode(int documentSetUID, TreeNode documentSetNode)
        {

            if (documentSetNode == null)
                return;

            if (documentSetUID <= 0)
                return;

            foreach (TreeNode documentAsNode in documentSetNode.Nodes)
            {
                Model.ModelDocument.Document doc = (Model.ModelDocument.Document)documentAsNode.Tag;

                DocumentSetDocument.Delete(DocumentSetUID: documentSetUID, DocumentUID: doc.UID);

                if (documentAsNode.Nodes.Count > 0)
                {
                    foreach (TreeNode tn in documentAsNode.Nodes)
                    {
                        DeleteDocumentTreeNode(documentSetUID: documentSetUID, documentSetNode: tn);
                    }
                }
            }

            Model.ModelDocument.Document doc2 = (Model.ModelDocument.Document)documentSetNode.Tag;
            DocumentSetDocument.Delete(DocumentSetUID: documentSetUID, DocumentUID: doc2.UID);

            return;
        }

        // -----------------------------------------------------
        //    Add new Document Set
        // -----------------------------------------------------
        public int Add()
        {
            int _uid = 0;

            _uid = GetLastUID() + 1;

            this.UID = _uid;

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {

                var commandString =
                (
                   "INSERT INTO DocumentSet" +
                   "( " +
                   " UID " +
                   ",TemplateType " +
                   ",TemplateFolder" +
                   ",IsVoid" +
                   ")" +
                        " VALUES " +
                   "( " +
                   "  @UID    " +
                   ", @TemplateType    " +
                   ", @TemplateFolder " +
                   ", @IsVoid " +
                   " ) "
                   );

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {
                    command.Parameters.Add("@UID", MySqlDbType.Int32).Value = UID;
                    command.Parameters.Add("@TemplateType", MySqlDbType.VarChar).Value = TemplateType;
                    command.Parameters.Add("@TemplateFolder", MySqlDbType.VarChar).Value = TemplateFolder;
                    command.Parameters.Add("@IsVoid", MySqlDbType.VarChar).Value = 'N';

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            return _uid;
        }


        // -----------------------------------------------------
        //    Add new Document Set
        // -----------------------------------------------------
        public void Update()
        {

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {

                var commandString =
                (
                     "UPDATE DocumentSet " +
                     " SET " +
                     " TemplateType =  @TemplateType " +
                     " WHERE UID = @UID "
                   );

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {
                    command.Parameters.Add("@UID", MySqlDbType.Int32).Value = this.UID;
                    command.Parameters.Add("@TemplateType", MySqlDbType.VarChar).Value = this.TemplateType;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            return;
        }

        /// <summary>
        /// List Document Set
        /// </summary>
        public void List()
        {
            this.documentSetList = new List<DocumentSet>();

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {

                var commandString = string.Format(
                " SELECT UID " +
                " ,TemplateType " +
                " ,TemplateFolder " +
                " ,IsVoid " +

                "   FROM DocumentSet " +
                "  WHERE IsVoid = 'N' " 
                );

                using (var command = new MySqlCommand(
                                      commandString, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DocumentSet documentSet = new DocumentSet();
                            documentSet.UID = Convert.ToInt32(reader["UID"].ToString());
                            documentSet.TemplateType = reader["TemplateType"].ToString();
                            documentSet.TemplateFolder = reader["TemplateFolder"].ToString();
                            documentSet.IsVoid = Convert.ToChar(reader["IsVoid"].ToString());
                            documentSet.UIDNameDisplay = documentSet.UID.ToString() + "; " + documentSet.TemplateType; 

                            this.documentSetList.Add(documentSet);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// List Document Set
        /// </summary>
        public static List<DocumentSet> ListS()
        {
            var documentSetList = new List<DocumentSet>();

            using ( var connection = new MySqlConnection( ConnString.ConnectionString ) )
            {

                var commandString = string.Format(
                " SELECT UID " +
                " ,TemplateType " +
                " ,TemplateFolder " +
                " ,IsVoid " +

                "   FROM DocumentSet " +
                "  WHERE IsVoid = 'N' "
                );

                using ( var command = new MySqlCommand(
                                      commandString, connection ) )
                {
                    connection.Open();
                    using ( MySqlDataReader reader = command.ExecuteReader() )
                    {
                        while ( reader.Read() )
                        {
                            DocumentSet documentSet = new DocumentSet();
                            documentSet.UID = Convert.ToInt32( reader ["UID"].ToString() );
                            documentSet.TemplateType = reader ["TemplateType"].ToString();
                            documentSet.TemplateFolder = reader ["TemplateFolder"].ToString();
                            documentSet.IsVoid = Convert.ToChar( reader ["IsVoid"].ToString() );
                            documentSet.UIDNameDisplay = documentSet.UID.ToString() + "; " + documentSet.TemplateType;

                            documentSetList.Add( documentSet );
                        }
                    }
                }
            }

            return documentSetList;
        }

        public void ListInComboBox(ComboBox cbxList)
        {
            this.List();

            foreach (DocumentSet docSet in documentSetList)
            {
                cbxList.Items.Add(docSet.UID + "; " + docSet.TemplateType);
            }
            
        }

        // -----------------------------------------------------
        //        List Documents for a Document Set
        // -----------------------------------------------------
        public void ListDocumentsInSet( int documentSetUID )
        {
            this.listOfDocumentsInSet = new List<Document>();

            using ( var connection = new MySqlConnection( ConnString.ConnectionString ) )
            {

                var commandString = string.Format(
                "  SELECT " +
                RepDocument.SQLDocumentConcat( "DOC" ) +
                " ,LNK.FKParentDocumentUID " +
                " ,LNK.FKParentDocumentSetUID " +
                " ,LNK.SequenceNumber " +
                "   FROM Document DOC " +
                "       ,DocumentSetDocument LNK" +
                "  WHERE " +
                "        LNK.FKDocumentUID = DOC.UID " +
                "    AND DOC.SourceCode = 'FCM' " +
                "    AND LNK.IsVoid     = 'N' " +
                "    AND DOC.IsVoid     = 'N' " +
                "    AND LNK.FKDocumentSetUID = {0}  " +
                "  ORDER BY LNK.FKParentDocumentUID ASC, LNK.SequenceNumber ",
                documentSetUID
                );

                using ( var command = new MySqlCommand(
                                      commandString, connection ) )
                {
                    connection.Open();
                    using ( MySqlDataReader reader = command.ExecuteReader() )
                    {
                        while ( reader.Read() )
                        {
                            Model.ModelDocument.Document _Document = new Model.ModelDocument.Document();
                            RepDocument.LoadDocumentFromReader( _Document, "DOC", reader );

                            // This is necessary because when the list comes from DocumentSet, the parent may change
                            //
                            _Document.ParentUID = Convert.ToInt32( reader ["FKParentDocumentUID"].ToString() );

                            this.listOfDocumentsInSet.Add( _Document );
                        }
                    }
                }
            }
        }


    }
}
