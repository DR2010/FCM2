using FCMMySQLBusinessLibrary.Model.ModelClient;
using MackkadoITFramework.Utils;
using MackkadoITFramework.ErrorHandling;

namespace FCMMySQLBusinessLibrary.Service.SVCClient.Contract
{

    public class ClientContractAddRequest
    {
        public HeaderInfo headerInfo;
        public ClientContract clientContract;
    }

    public class ClientContractAddResponse
    {
        public ClientContract clientContract;
        public ResponseStatus responseStatus;
    }

    
    public class ClientContractUpdateRequest
    {
        public HeaderInfo headerInfo;
        public ClientContract clientContract;
    }

    public class ClientContractUpdateResponse
    {
        public ClientContract clientContract;
        public ResponseStatus responseStatus;
    }

    public class ClientContractDeleteRequest
    {
        public HeaderInfo headerInfo;
        public ClientContract clientContract;
    }

    public class ClientContractDeleteResponse
    {
        public ClientContract clientContract;
        public ResponseStatus responseStatus;
    }

}
