using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FCMMySQLBusinessLibrary.Service.SVCClient.Contract;
using FCMMySQLBusinessLibrary.Service.SVCClient.ServiceContract;
using MackkadoITFramework.Utils;
using System.ServiceModel;
using System.ServiceModel.Channels;

[ServiceContract]
public interface IAsyncBUSClient
{
    [OperationContract(AsyncPattern = true)]
    IAsyncResult BeginClientList(HeaderInfo headerInfo, AsyncCallback callback, object asyncState);

    ClientListResponse EndClientList(IAsyncResult result);

}

public class ClientAsync : ClientBase<IAsyncBUSClient>, IAsyncBUSClient
{

    public IAsyncResult BeginClientList(HeaderInfo headerInfo, AsyncCallback callback, object asyncState)
    {
        return Channel.BeginClientList(headerInfo, callback, asyncState);
    }


    public ClientListResponse EndClientList(IAsyncResult result)
    {
        return Channel.EndClientList(result);
    }
}
