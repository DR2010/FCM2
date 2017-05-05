using System;
using System.Collections.Generic;
using FCMMySQLBusinessLibrary.Repository.RepositoryClientDocument;
using MackkadoITFramework.ErrorHandling;
using MackkadoITFramework.ProcessRequest;
using MackkadoITFramework.Utils;

namespace FCMMySQLBusinessLibrary.Service.SVCClient.Service
{
    public class BUSProcessRequest
    {
        /// <summary>
        /// Add Process Request
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static ResponseStatus Add(ProcessRequest processRequest)
        {
            ResponseStatus response = new ResponseStatus();
            response = processRequest.Add();

            return response;
        }

        /// <summary>
        /// Add Document Generation for Client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static ResponseStatus GenerateDocumentClient( int clientUID, int clientSetID, string overrideDocuments, int clientDocumentUID = 0, string userID = "")
        {
            ResponseStatus response = new ResponseStatus();

            ProcessRequest processRequest = new ProcessRequest();
            processRequest.Description = "Document Generation For Client " + clientUID.ToString() + " Set " + clientSetID.ToString();
            processRequest.Type = ProcessRequest.TypeValue.DOCUMENTGENERATION.ToString();
            processRequest.FKClientUID = clientUID;
            processRequest.RequestedByUser = userID;

            response = processRequest.Add();

            ProcessRequestArguments argument1 = new ProcessRequestArguments();
            argument1.FKRequestUID = processRequest.UID;
            argument1.Code = ProcessRequestArguments.ProcessRequestCodeValues.CLIENTUID.ToString();
            argument1.ValueType = ProcessRequestArguments.ValueTypeValue.NUMBER.ToString();
            argument1.Value = clientUID.ToString();
            argument1.Add();

            ProcessRequestArguments argument2 = new ProcessRequestArguments();
            argument2.FKRequestUID = processRequest.UID;
            argument2.Code = ProcessRequestArguments.ProcessRequestCodeValues.CLIENTSETID.ToString();
            argument2.ValueType = ProcessRequestArguments.ValueTypeValue.NUMBER.ToString();
            argument2.Value = clientSetID.ToString();
            argument2.Add();

            ProcessRequestArguments argument3 = new ProcessRequestArguments();
            argument3.FKRequestUID = processRequest.UID;
            argument3.Code = ProcessRequestArguments.ProcessRequestCodeValues.OVERRIDE.ToString();
            argument3.ValueType = ProcessRequestArguments.ValueTypeValue.STRING.ToString();
            argument3.Value = overrideDocuments;
            argument3.Add();

            // Generation for one specific document
            if ( clientDocumentUID > 0 )
            {
                ProcessRequestArguments argument4 = new ProcessRequestArguments();
                argument3.FKRequestUID = processRequest.UID;
                argument3.Code = ProcessRequestArguments.ProcessRequestCodeValues.CLIENTDOCUID.ToString();
                argument3.ValueType = ProcessRequestArguments.ValueTypeValue.STRING.ToString();
                argument3.Value = clientDocumentUID.ToString();
                argument3.Add();

                RepClientDocument.SetFlagToGenerationRequested( clientDocumentUID, Convert.ToInt32(response.Contents) );
            }
            else
            {
                // Full set requested
                // Update requests.
                //
                var list = RepClientDocument.ListS( clientUID, clientSetID );
                foreach ( var doco in list )
                {
                    // RepClientDocument.SetFlagToGenerationRequested( doco.clientDocument.UID );
                    RepClientDocument.SetFlagToGenerationRequested( doco.clientDocument.UID, Convert.ToInt32( response.Contents ) );

                }
            }


            // Send email to requester
            //
            string emailGraham = "graham.coyle@federalcm.com.au";
            string emailDaniel = "DanielLGMachado@gmail.com";

            string emailSubject = "<> REQUESTED <> " + DateTime.Now + " <> generation requested by: " + userID + " for client " + clientUID;

            string emailBody = "Generation has been requested on : " + DateTime.Now + " <> " + emailSubject + " -- ";

            if (userID.ToUpper() == "GC0001")
            {
                var resp1 = FCMEmail.SendEmailSimple(
                    iRecipient: emailGraham,
                    iSubject: emailSubject,
                    iBody: emailBody);
            }

            var resp2 = FCMEmail.SendEmailSimple(
                iRecipient: emailDaniel,
                iSubject: emailSubject,
                iBody: emailBody);

            return response;
        }


        /// <summary>
        /// Add Document Generation for Client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static ResponseStatus GenerateDocumentClient( int clientUID, int clientSetID, string overrideDocuments, List<int> listDocs, string userID = "")
        {
            ResponseStatus response = new ResponseStatus();

            string emailGraham = "graham.coyle@federalcm.com.au";
            string emailDaniel = "DanielLGMachado@gmail.com";

            string emailSubject = "";

            string emailBody = "";


            foreach ( var doc in listDocs )
            {

                ProcessRequest processRequest = new ProcessRequest();
                processRequest.Description = "Document Generation For Client " + clientUID.ToString() + " Set " +
                                             clientSetID.ToString();
                processRequest.Type = ProcessRequest.TypeValue.DOCUMENTGENERATION.ToString();
                processRequest.FKClientUID = clientUID;
                processRequest.RequestedByUser = userID;

                response = processRequest.Add();

                ProcessRequestArguments argument1 = new ProcessRequestArguments();
                argument1.FKRequestUID = processRequest.UID;
                argument1.Code = ProcessRequestArguments.ProcessRequestCodeValues.CLIENTUID.ToString();
                argument1.ValueType = ProcessRequestArguments.ValueTypeValue.NUMBER.ToString();
                argument1.Value = clientUID.ToString();
                argument1.Add();

                ProcessRequestArguments argument2 = new ProcessRequestArguments();
                argument2.FKRequestUID = processRequest.UID;
                argument2.Code = ProcessRequestArguments.ProcessRequestCodeValues.CLIENTSETID.ToString();
                argument2.ValueType = ProcessRequestArguments.ValueTypeValue.NUMBER.ToString();
                argument2.Value = clientSetID.ToString();
                argument2.Add();

                ProcessRequestArguments argument3 = new ProcessRequestArguments();
                argument3.FKRequestUID = processRequest.UID;
                argument3.Code = ProcessRequestArguments.ProcessRequestCodeValues.OVERRIDE.ToString();
                argument3.ValueType = ProcessRequestArguments.ValueTypeValue.STRING.ToString();
                argument3.Value = overrideDocuments;
                argument3.Add();

                ProcessRequestArguments argument4 = new ProcessRequestArguments();
                argument3.FKRequestUID = processRequest.UID;
                argument3.Code = ProcessRequestArguments.ProcessRequestCodeValues.CLIENTDOCUID.ToString();
                argument3.ValueType = ProcessRequestArguments.ValueTypeValue.STRING.ToString();
                argument3.Value = doc.ToString();
                argument3.Add();

                RepClientDocument.SetFlagToGenerationRequested( doc, Convert.ToInt32(response.Contents) );

                // Send email to requester
                //
                emailGraham = "graham.coyle@federalcm.com.au";
                emailDaniel = "DanielLGMachado@gmail.com";

                emailSubject = "<> REQUESTED <> " + DateTime.Now + " <> generation requested by: " + userID + " for client " + clientUID;

                emailBody = "Generation has been requested on : " + DateTime.Now + " <> " + emailSubject + " -- " + " It hasn't been started yet.";

            }

            try
            {

                if (userID.ToUpper() == "GC0001")
                {
                    var resp1 = FCMEmail.SendEmailSimple(
                        iRecipient: emailGraham,
                        iSubject: emailSubject,
                        iBody: emailBody);
                }

                var resp2 = FCMEmail.SendEmailSimple(
                    iRecipient: emailDaniel,
                    iSubject: emailSubject,
                    iBody: emailBody);
            }
            catch (Exception ex)
            {
                LogFile.WriteToTodaysLogFile("Sending email from Generate selected documents error " + ex.ToString());
            }

            
            
            return response;
        }


        /// <summary>
        /// Add Process Request Argument
        /// </summary>
        /// <param name="processRequestArgument"></param>
        /// <returns></returns>
        public static ResponseStatus AddArgument(ProcessRequestArguments processRequestArgument)
        {
            ResponseStatus response = new ResponseStatus();
            response = processRequestArgument.Add();

            return response;
        }

        /// <summary>
        /// Add process request results
        /// </summary>
        /// <param name="processRequestResults"></param>
        /// <returns></returns>
        public static ResponseStatus AddArgument(ProcessRequestResults processRequestResults)
        {
            ResponseStatus response = new ResponseStatus();
            response = processRequestResults.Add();

            return response;
        }


        /// <summary>
        /// List Active Process Requests
        /// </summary>
        /// <param name="processRequestResults"></param>
        /// <returns></returns>
        public static List<ProcessRequest> ListActiveRequests()
        {
            var statusIn = ProcessRequest.StatusValue.OPEN;
            List<ProcessRequest> response = ProcessRequest.List(statusIn);

            return response;
        }

        /// <summary>
        /// List Active Process Requests
        /// </summary>
        /// <param name="processRequestResults"></param>
        /// <returns></returns>
        public static List<ProcessRequest> ListUnfinishedRequests()
        {
            var statusIn = ProcessRequest.StatusValue.STARTED;
            List<ProcessRequest> response = ProcessRequest.List( statusIn );

            return response;
        }

    
    }
}
