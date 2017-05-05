using System.ServiceModel;
using FCMMySQLBusinessLibrary.Service.SVCClient.Contract;

namespace FCMMySQLBusinessLibrary.Service.SVCClient.Interface
{
    /// <summary>
    /// Interface for Client Contract Business Layer
    /// </summary>
    [ServiceContract]
    public interface IBUSClientContract
    {
        /// <summary>
        /// Add Client Contract
        /// </summary>
        /// <param name="clientAddRequest"></param>
        /// <returns></returns>
        [OperationContract]
        ClientContractAddResponse ClientContractAdd(ClientContractAddRequest clientAddRequest);

        /// <summary>
        /// Update Client Contract
        /// </summary>
        /// <param name="clientUpdateRequest"></param>
        /// <returns></returns>
        [OperationContract]
        ClientContractUpdateResponse ClientContractUpdate(ClientContractUpdateRequest clientUpdateRequest);
    }
}


