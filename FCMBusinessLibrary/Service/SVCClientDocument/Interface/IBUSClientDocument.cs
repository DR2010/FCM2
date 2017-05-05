using System.ServiceModel;
using FCMMySQLBusinessLibrary.Model.ModelClientDocument;
using FCMMySQLBusinessLibrary.Service.SVCClientDocument.ServiceContract;

namespace FCMMySQLBusinessLibrary.Service.SVCClientDocument.Interface
{
    [ServiceContract]
    public interface IBUSClientDocument
    {
        SCClientDocument.ClientDocumentUpdateResponse ClientDocumentUpdate(ClientDocument clientDocument);
    }
}
