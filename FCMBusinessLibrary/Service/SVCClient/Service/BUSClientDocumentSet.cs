using System.Collections.Generic;
using FCMMySQLBusinessLibrary.FCMUtils;
using FCMMySQLBusinessLibrary.Model.ModelClientDocument;
using MackkadoITFramework.ErrorHandling;
using MackkadoITFramework.Utils;

namespace FCMMySQLBusinessLibrary.Service.SVCClient.Service
{
    public class BUSClientDocumentSet
    {

        public int DocumentCount { get { return _DocumentCount; } } 
        private int _DocumentCount;

        public BUSClientDocumentSet(int iClientUID, int iClientDocumentSetUID)
        {
            // Calculate number of documents in set
            ResponseStatus response = new ResponseStatus();

            var clientDocSet = new ClientDocumentSet(iClientUID, iClientDocumentSetUID);
            _DocumentCount = clientDocSet.GetNumberOfDocuments();

        }

        /// <summary>
        /// Add client document set
        /// </summary>
        /// <param name="eventClient"></param>
        /// <returns></returns>
        public static ResponseStatus ClientDocumentSetAdd(HeaderInfo headerInfo)
        {
            ResponseStatus response = new ResponseStatus();

            ClientDocumentSet cds = new ClientDocumentSet(Utils.ClientID);
            cds.FKClientUID = Utils.ClientID;

            //cds.FolderOnly = "CLIENT" + Utils.ClientID.ToString().Trim().PadLeft(4, '0');
            //cds.Folder = FCMConstant.SYSFOLDER.CLIENTFOLDER + @"\" + cds.FolderOnly;

            cds.SourceFolder = FCMConstant.SYSFOLDER.TEMPLATEFOLDER;
            cds.Add(headerInfo);

            return response;
        }

        /// <summary>
        /// List document sets for a client 
        /// </summary>
        /// <param name="eventClient"></param>
        /// <returns></returns>
        public static List<ClientDocumentSet> ClientDocumentSetList(int iClientUID, string sortOrder)
        {
            List<ClientDocumentSet> response = new List<ClientDocumentSet>();

            response = ClientDocumentSet.List(iClientUID, sortOrder);

            return response;
        }
    }
}
