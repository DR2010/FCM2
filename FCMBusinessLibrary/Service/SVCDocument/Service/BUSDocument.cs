using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FCMMySQLBusinessLibrary.Model.ModelDocument;
using FCMMySQLBusinessLibrary.Repository.RepositoryDocument;
using FCMMySQLBusinessLibrary.Service.SVCDocument.ServiceContract;
using MackkadoITFramework.ErrorHandling;
using MackkadoITFramework.Helper;
using MackkadoITFramework.Utils;

namespace FCMMySQLBusinessLibrary.Service.SVCDocument.Service
{
    public class BUSDocument
    {

        /// <summary>
        /// List of documents
        /// </summary>
        public static DocumentListResponse DocumentListX(DocumentListRequest documentListRequest)
        {
            var documentListResponse = new DocumentListResponse();
            documentListResponse.response = new ResponseStatus();

            documentListResponse.documentList = RepDocument.List( documentListRequest.headerInfo, documentListRequest.inCondition );

            return documentListResponse;
        }

        /// <summary>
        /// List of documents
        /// </summary>
        public static DocumentListResponse DocumentListDocuments( DocumentListRequest documentListRequest )
        {
            var documentListResponse = new DocumentListResponse();
            documentListResponse.response = new ResponseStatus();

            documentListResponse.documentList = RepDocument.ListDocuments( documentListRequest.headerInfo );

            return documentListResponse;
        }

        /// <summary>
        /// List of documents
        /// </summary>
        public static DocumentListResponse FolderAndDocumentList(DocumentListRequest documentListRequest)
        {
            var documentListResponse = new DocumentListResponse();
            documentListResponse.response = new ResponseStatus();

            documentListResponse.documentList = RepDocument.ListFoldersAndDocuments(documentListRequest.headerInfo);

            return documentListResponse;
        }


        /// <summary>
        /// List of documents
        /// </summary>
        public static DocumentListResponse DocumentListFolders( DocumentListRequest documentListRequest )
        {
            var documentListResponse = new DocumentListResponse();
            documentListResponse.response = new ResponseStatus();

            documentListResponse.documentList = RepDocument.ListFolders( documentListRequest.headerInfo );

            return documentListResponse;
        }


        /// <summary>
        /// Retrieve document details
        /// </summary>
        /// <param name="documentReadRequest"></param>
        /// <returns></returns>
        public static DocumentReadResponse DocumentRead(DocumentReadRequest documentReadRequest)
        {
            var documentRead = RepDocument.Read(
                documentReadRequest.retrieveVoidedDocuments, 
                documentReadRequest.UID, 
                documentReadRequest.CUID);

            var documentReadResponse = new DocumentReadResponse();
            documentReadResponse.document = documentRead;
            documentReadResponse.response = new ResponseStatus(MessageType.Informational);

            return documentReadResponse;
        }


        /// <summary>
        /// Retrieve document details
        /// </summary>
        /// <returns></returns>
        public static Document GetRootDocument()
        {
            var documentRead = RepDocument.Read(false,0,"ROOT");

            return documentRead;
        }

        /// <summary>
        /// Set document to void
        /// </summary>
        /// <param name="documentUID"></param>
        public static void SetToVoid(int documentUID)
        {
            RepDocument.SetToVoid(documentUID);
            return;
        }

        /// <summary>
        /// Delete document
        /// </summary>
        /// <param name="documentUID"></param>
        public static void DeleteDocument(int documentUID)
        {
            RepDocument.Delete(documentUID);
            return;
        }

        /// <summary>
        /// Update or Create document
        /// </summary>
        /// <param name="documentSaveRequest"></param>
        /// <returns></returns>
        public static DocumentSaveResponse DocumentSave(DocumentSaveRequest documentSaveRequest)
        {
            var repDocSaveResp = RepDocument.Save(
                        documentSaveRequest.headerInfo,
                        documentSaveRequest.inDocument,
                        documentSaveRequest.saveType);
            
            var documentSaveResponse = new DocumentSaveResponse();
            documentSaveResponse.document = documentSaveRequest.inDocument;
            documentSaveResponse.document.UID = repDocSaveResp;
            if( repDocSaveResp == 0)
            {
                documentSaveResponse.response = new ResponseStatus( MessageType.Error);
                documentSaveResponse.response.Message = "Error Saving Document.";
                documentSaveResponse.response.Successful = false;
                documentSaveResponse.response.ReturnCode = -0010;
            }
            else
            {
                documentSaveResponse.response = new ResponseStatus( MessageType.Informational );
            }

            return documentSaveResponse;
        }

        /// <summary>
        /// Update or Create document
        /// </summary>
        /// <returns></returns>
        public static Document DocumentCreate( HeaderInfo headerInfo, string filename, string filelocation, int parentUID, string recordtype = "DOCUMENT" )
        {

            string documenttype = "WORD"; // Just setting as initial value

            Document document = new Document();

            document.ParentUID = parentUID;

            document.CUID = filename.Substring( 0, 6 );
            document.Location = filelocation;
            document.Location = Utils.getReferenceFilePathName(filelocation);

            document.DisplayName = filename.Substring(10); // Starts after HRM-01-01 HERExxxxxxxx
            document.SimpleFileName = filename.Substring(10); // Starts after HRM-01-01 HERExxxxxxxx
            document.Name = filename;
            var filesplit = filename.Split('.');
            document.FileExtension = String.Concat("." + filesplit[1]);
            document.FileName = filename;
            document.RecordType = recordtype;
            
            string wordExtensions = ".doc .docx .dotx";
            string excelExtensions = ".xls .xlsx";
            string pdfExtensions = ".pdf";

            // Not every extension will be loaded
            //
            if (wordExtensions.Contains(document.FileExtension))
                documenttype = "WORD";

            if (excelExtensions.Contains(document.FileExtension))
                documenttype = "EXCEL";

            if (pdfExtensions.Contains(document.FileExtension))
                documenttype = "PDF";

            document.DocumentType = documenttype;
            document.SequenceNumber = 1;
            document.IssueNumber = 1;
            document.SourceCode = "FCM";
            document.Status = "ACTIVE";

            document.Skip = "N";
            document.IsVoid = "N";
            document.IsProjectPlan = "N";
            document.FKClientUID = 0;
            document.Comments = "Web Upload";

            var documentSaveRequest = new DocumentSaveRequest();
            documentSaveRequest.inDocument = document;
            documentSaveRequest.headerInfo = headerInfo;

            var docresp = BUSDocument.DocumentSave( documentSaveRequest );

            if (docresp.response.ReturnCode <= 0)
            {
                LogFile.WriteToTodaysLogFile(docresp.response.Message);
            }

            document = docresp.document;

            return document;
        }


        /// <summary>
        /// Create new versions
        /// </summary>
        /// <param name="documentSaveRequest"></param>
        /// <returns></returns>
        public static DocumentNewVersionResponse DocumentNewVersion(
            DocumentNewVersionRequest documentSaveRequest)
        {

            var repNewVersionResp = RepDocument.NewVersion(
                        documentSaveRequest.headerInfo,
                        documentSaveRequest.inDocument);

            return repNewVersionResp;
        }

        /// <summary>
        /// List of clients
        /// </summary>
        public static DocumentListResponse DocumentList(HeaderInfo headerInfo)
        {
            var documentListResponse = new DocumentListResponse();
            documentListResponse.response = new ResponseStatus();

            documentListResponse.documentList = RepDocument.List(headerInfo);

            return documentListResponse;
        }

    }


}
