using System;
using System.Collections.Generic;
using FCMMySQLBusinessLibrary.Repository.RepositoryDocument;
using MackkadoITFramework.Utils;
using MySql.Data.MySqlClient;

namespace FCMMySQLBusinessLibrary.Model.ModelDocument
{
    public class DocumentSetDocumentList
    {
        public List<scDocoSetDocumentLink> documentSetDocumentList;

        //
        // It returns a list of links for a given document set UID
        //
        public void List(DocumentSet documentSet)
        {
            documentSetDocumentList = new List<scDocoSetDocumentLink>();

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {

                var commandString = string.Format(
                " SELECT " +
                "  UID " +
                " ,FKDocumentUID " +
                " ,FKDocumentSetUID " +
                " ,StartDate " +
                " ,EndDate " +
                " ,IsVoid " +
                "   FROM DocumentSetDocument " +
                "   WHERE FKDocumentSetUID = {0} ",
                documentSet.UID
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
                            if (Convert.ToChar(reader["IsVoid"]) == 'Y')
                                continue;

                            var docItem = new scDocoSetDocumentLink();

                            // Get document
                            //
                            docItem.document = new Model.ModelDocument.Document();
                            docItem.document.UID = Convert.ToInt32( reader["FKDocumentUID"] );
                            
                            // 11.01.2013
                            //
                            // docItem.document.Read();

                            docItem.document = RepDocument.Read(true, docItem.document.UID);

                            // Get DocumentSet
                            //
                            docItem.documentSet = new DocumentSet();
                            docItem.documentSet.UID = Convert.ToInt32(reader["FKDocumentSetUID"].ToString());

                            // Set DocumentSetDocument
                            docItem.DocumentSetDocument = new DocumentSetDocument();
                            docItem.DocumentSetDocument.UID = Convert.ToInt32(reader["UID"].ToString());
                            docItem.DocumentSetDocument.FKDocumentUID = Convert.ToInt32(reader["FKDocumentUID"].ToString());
                            docItem.DocumentSetDocument.FKDocumentSetUID = Convert.ToInt32(reader["FKDocumentSetUID"].ToString());
                            docItem.DocumentSetDocument.IsVoid = Convert.ToChar(reader["IsVoid"].ToString());
                            docItem.DocumentSetDocument.StartDate = Convert.ToDateTime(reader["StartDate"].ToString());

                            if (reader["EndDate"] == null)
                            {
                                docItem.DocumentSetDocument.EndDate = System.DateTime.MaxValue;
                            }
                            else
                            {
                                docItem.DocumentSetDocument.EndDate = Convert.ToDateTime(reader["EndDate"].ToString());
                            }
                            documentSetDocumentList.Add(docItem);
                        }
                    }
                }

                return;
            }
        }

        // This method links the list of documents requested to
        // the document set requested
        //
        public void CopyDocumentList(DocumentList documentList, DocumentSet documentSet)
        {

        }
    }
}
