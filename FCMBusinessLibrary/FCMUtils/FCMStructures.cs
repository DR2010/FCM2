using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FCMMySQLBusinessLibrary.Model.ModelClientDocument;
using FCMMySQLBusinessLibrary.Model.ModelDocument;

namespace FCMMySQLBusinessLibrary
{

    public struct scDocoSetDocumentLink
    {
        public Model.ModelDocument.Document document;
        public DocumentSet documentSet;
        public DocumentSetDocument DocumentSetDocument;
    }

    public struct ListOfscDocoSetDocumentLink
    {
        public List<scDocoSetDocumentLink> list;
    }

    public struct scClientDocSetDocLink
    {
        public Model.ModelDocument.Document document;
        public ClientDocumentSet clientDocumentSet;
        public ClientDocument clientDocument;
    }

    public struct ListOfscClientDocSetDocLink
    {
        public List<scClientDocSetDocLink> list;
    }

    public struct scDocumentSetDocumentLink
    {
        public DocumentSetDocument dsdparent;
        public DocumentSetDocument dsdschild;
        public Model.ModelDocument.Document documentChild;
        public DocumentSetDocumentLink dsdlink;

    }

}
