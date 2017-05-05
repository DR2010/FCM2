using FCMMySQLBusinessLibrary.Model.ModelClientDocument;
using MackkadoITFramework.ErrorHandling;

namespace FCMMySQLBusinessLibrary.Service.SVCClient.Service
{
    public class BUSClientDocumentGeneration
    {
        public static ResponseStatus UpdateLocation(int clientID, int clientDocumentSetUID)
        {
            var response = new ResponseStatus();
            response = DocumentGeneration.UpdateDestinationFolder(clientID, clientDocumentSetUID);
            return response;
        }

    }
}
