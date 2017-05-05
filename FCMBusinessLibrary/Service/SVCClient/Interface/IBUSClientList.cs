using System.ServiceModel;
using FCMMySQLBusinessLibrary.Service.SVCClient.Contract;
using FCMMySQLBusinessLibrary.Service.SVCClient.ServiceContract;
using MackkadoITFramework.Utils;

namespace FCMMySQLBusinessLibrary.Service.SVCClient.Interface
{
    [ServiceContract]
    public interface IBUSClientList
    {
        [OperationContract]
        ClientListResponse ClientList(HeaderInfo headerInfo);

    }
}
