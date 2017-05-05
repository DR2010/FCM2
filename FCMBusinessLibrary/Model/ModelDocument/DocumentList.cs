using System;
using System.Collections.Generic;
using FCMMySQLBusinessLibrary.Repository.RepositoryDocument;
using MackkadoITFramework.Helper;
using MackkadoITFramework.Utils;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Linq;

namespace FCMMySQLBusinessLibrary.Model.ModelDocument
{
    public class DocumentList
    {
        public List<Document> documentList;
        // -----------------------------------------------------
        //    List Documents
        // -----------------------------------------------------
        public void ListProjectPlans()
        {
            List(" AND IsProjectPlan = 'Y' ");
        }

        // -----------------------------------------------------
        //    List Documents
        // -----------------------------------------------------
        public void List()
        {
            List(null);
        }

        // -----------------------------------------------------
        //    List Documents
        // -----------------------------------------------------
        private void List(string Condition)
        {
            this.documentList = new List<Model.ModelDocument.Document>();

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {
                
                var commandString = string.Format(
                " SELECT " +
                RepDocument.SQLDocumentConcat("DOC") + 
                "   FROM     Document DOC " +
                "  WHERE DOC.SourceCode = 'FCM' " +
                "    AND DOC.IsVoid = 'N' " +
                Condition +
                "  ORDER BY PARENTUID ASC, SequenceNumber ASC "
                );

                using (var command = new MySqlCommand(
                                      commandString, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Model.ModelDocument.Document _Document = new Model.ModelDocument.Document();
                            RepDocument.LoadDocumentFromReader(_Document, "DOC", reader);
                            
                            documentList.Add(_Document);
                        }
                    }
                }
            }
        }

        // -----------------------------------------------------
        //        List Documents for a Document Set
        // -----------------------------------------------------
        public void ListDocSet( int documentSetUID )
        {
            this.documentList = new List<Model.ModelDocument.Document>();

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {

                var commandString = string.Format(
                "  SELECT "+
                RepDocument.SQLDocumentConcat("DOC") +
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

                using (var command = new MySqlCommand(
                                      commandString, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Model.ModelDocument.Document _Document = new Model.ModelDocument.Document();
                            RepDocument.LoadDocumentFromReader(_Document, "DOC", reader);

                            // This is necessary because when the list comes from DocumentSet, the parent may change
                            //
                            _Document.ParentUID = Convert.ToInt32(reader["FKParentDocumentUID"].ToString());

                            this.documentList.Add(_Document);
                        }
                    }
                }
            }
        }

        // -----------------------------------------------------
        //           Load documents in a tree
        // -----------------------------------------------------
        public static void ListInTree(
            TreeView fileList, 
            DocumentList documentList,
            Model.ModelDocument.Document root)
        {

            // Find root folder
            //
            Model.ModelDocument.Document rootDocument = new Model.ModelDocument.Document();

            rootDocument.CUID = root.CUID;
            rootDocument.RecordType = root.RecordType;
            rootDocument.UID = root.UID;
            // rootDocument.Read();

            rootDocument = RepDocument.Read(false, root.UID);
            
            // Create root
            //
            var rootNode = new TreeNode(rootDocument.FileName, MakConstant.Image.Folder, MakConstant.Image.Folder);

            // Add root node to tree
            //
            fileList.Nodes.Add(rootNode);
            rootNode.Tag = rootDocument;
            rootNode.Name = rootDocument.Name;

            foreach (var document in documentList.documentList)
            {
                // Ignore root folder
                if (document.CUID == "ROOT") continue;
                    
                // Check if folder has a parent
                string cdocumentUID = document.UID.ToString();
                string cparentIUID = document.ParentUID.ToString();

                int image = 0;
                int imageSelected = 0;
                document.RecordType = document.RecordType.Trim();

                #region Image
                switch (document.DocumentType)
                {
                    case Utils.DocumentType.WORD:
                        image = MakConstant.Image.Word32;
                        imageSelected = MakConstant.Image.Word32;


                        // I have to think about this...
                        //
                        if (document.RecordType == Utils.RecordType.APPENDIX)
                        {
                            image = MakConstant.Image.Appendix;
                            imageSelected = MakConstant.Image.Appendix;
                        }
                        break;

                    case Utils.DocumentType.EXCEL:
                        image = MakConstant.Image.Excel;
                        imageSelected = MakConstant.Image.Excel;
                        break;

                    case Utils.DocumentType.FOLDER:
                        image = MakConstant.Image.Folder;
                        imageSelected = MakConstant.Image.Folder;
                        break;

                    case Utils.DocumentType.PDF:
                        image = MakConstant.Image.PDF;
                        imageSelected = MakConstant.Image.PDF;
                        break;

                    default:
                        image = MakConstant.Image.Word32;
                        imageSelected = MakConstant.Image.Word32;
 
                        break;
                }
                #endregion Image

                if (document.ParentUID == 0)
                {
                    var treeNode = new TreeNode( document.FileName, image, image );
                    treeNode.Tag = document;
                    treeNode.Name = cdocumentUID;

                    rootNode.Nodes.Add(treeNode);
                }
                else
                {
                    // Find the parent node
                    //
                    var node = fileList.Nodes.Find(cparentIUID, true);
                    
                    if (node.Count() > 0)
                    {

                        var treeNode = new TreeNode( document.FileName, image, imageSelected );
                        treeNode.Tag = document;
                        treeNode.Name = cdocumentUID;

                        node[0].Nodes.Add(treeNode);
                    }
                    else
                    {
                        // Add Element to the root
                        //
                        var treeNode = new TreeNode( document.FileName, image, imageSelected );
                        treeNode.Tag = document;
                        treeNode.Name = cdocumentUID;

                        rootNode.Nodes.Add(treeNode);

                    }
                }
            }
        }
 
        // -----------------------------------------------------
        //    List Documents for a client
        // -----------------------------------------------------
        public void ListClient(int clientUID)
        {
            this.documentList = new List<Model.ModelDocument.Document>();

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {

                var commandString = string.Format(
                " SELECT " + 
                RepDocument.SQLDocumentConcat("DOC") +
                "   FROM Document DOC " +
                "  WHERE SourceCode = 'CLIENT' " +
                "    AND FKClientUID = {0} " +
                "    AND IsVoid <> 'Y' " + 
                "  ORDER BY PARENTUID ASC, SequenceNumber ASC ",
                clientUID);

                using (var command = new MySqlCommand(
                                      commandString, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Model.ModelDocument.Document _Document = new Model.ModelDocument.Document();
                            RepDocument.LoadDocumentFromReader(_Document, "DOC", reader);

                            documentList.Add(_Document);

                        }
                    }
                }
            }
        }
    }
}
