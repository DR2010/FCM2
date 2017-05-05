using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FCMMySQLBusinessLibrary.Model.ModelDocument;
using FCMMySQLBusinessLibrary.Service.SVCDocument.ServiceContract;
using MackkadoITFramework.ErrorHandling;
using MackkadoITFramework.Utils;

namespace FCMMySQLBusinessLibrary.Service.SVCDocument.Service
{
    public class BUSDocumentSet
    {

        /// <summary>
        /// List of documents
        /// </summary>
        public static List<DocumentSet> DocumentSetList()
        {
            return DocumentSet.ListS();
        }

        /// <summary>
        /// List of documents
        /// </summary>
        public static DocumentSet DocumentSetRead(int documentSetUID)
        {
            DocumentSet documentSet = new DocumentSet();
            documentSet.UID = documentSetUID;
            documentSet.Read('Y');

            return documentSet;
        }

        /// <summary>
        /// List of documents
        /// </summary>
        public static DocumentSet ListDocumentSets()
        {

            var documentSet = new DocumentSet();
            documentSet.documentSetList = DocumentSet.ListS();

            return documentSet;
        }

        /// <summary>
        /// List of documents
        /// </summary>
        public static List<Document> ListDocumentsNotInSet( HeaderInfo headerInfo, int documentSetUID )
        {
            DocumentSet documentSet = new DocumentSet();
            documentSet.UID = documentSetUID;

            var documentsNotInSet = documentSet.ListDocumentsNotInSet(headerInfo, documentSetUID);

            return documentsNotInSet;
        }

        public static ResponseStatus AddDocumentToSet( HeaderInfo headerInfo, int documentSetUID, int documentUID)
        {

            // Find Document
            //
            DocumentReadRequest documentReadRequest = new DocumentReadRequest();
            documentReadRequest.headerInfo = headerInfo;
            documentReadRequest.retrieveVoidedDocuments = false;
            documentReadRequest.UID = documentUID;

            var documentReadResponse = BUSDocument.DocumentRead(documentReadRequest);
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

            // Find DocumentSet
            //
            var documentSet = new DocumentSet();
            documentSet.UID = documentSetUID;
            documentSet.Read('N');

            // Create link
            //
            DocumentSetDocument dsd = new DocumentSetDocument();
            dsd.FKDocumentSetUID = documentSet.UID;
            dsd.FKDocumentUID = documentSelected.UID;
            dsd.EndDate = System.DateTime.MaxValue;
            dsd.StartDate = System.DateTime.Today;
            dsd.UID = 0;
            dsd.Location = documentSelected.Location;
            dsd.SequenceNumber = 1;
            dsd.IsVoid = 'N';
            dsd.FKParentDocumentSetUID = documentSet.UID;
            dsd.FKParentDocumentUID = folderReadRequestParent.UID; // Is this the ID of the parent on the document table or the id of the document on this table?

            dsd.Add();


            return new ResponseStatus();

        }

    }
}
