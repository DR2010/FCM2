using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MackkadoITFramework.Utils;
using FCMMySQLBusinessLibrary.Model.ModelDocument;
using MackkadoITFramework.ErrorHandling;

namespace FCMMySQLBusinessLibrary.Service.SVCDocument.ServiceContract
{

    public class DocumentListRequest
    {
        public HeaderInfo headerInfo;
        public string inCondition;
    }

    public class DocumentListResponse
    {
        public List<Document> documentList;
        public ResponseStatus response;
    }


    public class DocumentReadRequest
    {
        public HeaderInfo headerInfo;
        public int UID;
        public string CUID;
        public bool retrieveVoidedDocuments;
    }

    public class DocumentReadResponse
    {
        public Document document;
        public ResponseStatus response;

    }

    public class DocumentSaveRequest
    {
        public HeaderInfo headerInfo;
        public Document inDocument;
        public string saveType;
    }


    public class DocumentSaveResponse
    {
        public Document document;
        public ResponseStatus response;

    }

    public class DocumentNewVersionRequest
    {
        public HeaderInfo headerInfo;
        public Document inDocument;
    }

    public class DocumentNewVersionResponse
    {
        public Document outDocument;
        public ResponseStatus response;
    }

}
