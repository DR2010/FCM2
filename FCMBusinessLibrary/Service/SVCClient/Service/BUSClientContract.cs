using System;
using FCMMySQLBusinessLibrary.Repository.RepositoryClient;
using FCMMySQLBusinessLibrary.Service.SVCClient.Contract;
using FCMMySQLBusinessLibrary.Service.SVCClient.Interface;
using MackkadoITFramework.ErrorHandling;

namespace FCMMySQLBusinessLibrary.Service.SVCClient.Service
{
    public class BUSClientContract : IBUSClientContract
    {
        /// <summary>
        /// Client contract add
        /// </summary>
        /// <param name="clientContract"></param>
        /// <returns></returns>
        public ClientContractAddResponse ClientContractAdd(ClientContractAddRequest clientContract)
        {

            // Using Repository
            ClientContractAddResponse response = new ClientContractAddResponse();
            response.responseStatus = RepClientContract.Insert(
                clientContract.headerInfo, 
                clientContract.clientContract);

            return response;

        }

        /// <summary>
        /// Client contract list
        /// </summary>
        /// <param name="clientContractUID"> </param>
        /// <returns></returns>
        public static ResponseStatus ClientContractList(int clientContractUID)
        {
            var response = new ResponseStatus
                               {
                                   Contents = RepClientContract.List(clientContractUID)
                               };
            return response;
        }

        /// <summary>
        /// Client contract read
        /// </summary>
        /// <param name="clientContractUID"> </param>
        /// <returns></returns>
        public static ResponseStatus Read(int clientContractUID)
        {
            var response = new ResponseStatus
            {
                Contents = RepClientContract.Read(clientContractUID)
            };
            return response;
        }


        /// <summary>
        /// Update details of a client's contract
        /// </summary>
        /// <param name="clientContract"></param>
        /// <returns></returns>
        public ClientContractUpdateResponse ClientContractUpdate(ClientContractUpdateRequest clientContract)
        {

            // Using Repository
            ClientContractUpdateResponse response = new ClientContractUpdateResponse();
            response.responseStatus = RepClientContract.Update(
                clientContract.headerInfo,
                clientContract.clientContract);

            return response;
        }

        /// <summary>
        /// Delete a client's contract
        /// </summary>
        /// <param name="clientContract"></param>
        /// <returns></returns>
        public static ClientContractDeleteResponse ClientContractDelete(ClientContractDeleteRequest clientContractDelete)
        {
            var response = new ClientContractDeleteResponse();
            response.responseStatus = RepClientContract.Delete(
                clientContractDelete.headerInfo, 
                clientContractDelete.clientContract);

            return response;
        }

        /// <summary>
        /// Client contract list
        /// </summary>
        /// <returns></returns>
        public static ResponseStatus GetValidContractOnDate(int clientContractUID, DateTime date)
        {
            var response = RepClientContract.GetValidContractOnDate(clientContractUID, date);
            return response;
        }

    }
}
