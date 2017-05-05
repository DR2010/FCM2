using System;
using System.Collections.Generic;
using System.Threading;
using FCMMySQLBusinessLibrary;
using FCMMySQLBusinessLibrary.Model.ModelClientDocument;
using FCMMySQLBusinessLibrary.Service.SVCClient.Contract;
using FCMMySQLBusinessLibrary.Service.SVCClient.Service;
using FCMMySQLBusinessLibrary.Service.SVCClient.ServiceContract;
using FCMMySQLBusinessLibrary.Service.SVCClientDocument.Service;
using FCMMySQLBusinessLibrary.Service.SVCFCMBackendStatus.Service;
using MackkadoITFramework.Interfaces;
using MackkadoITFramework.ProcessRequest;
using MackkadoITFramework.Utils;
using MackkadoITFramework.Helper;

namespace ConsoleGenerateDocument
{
    class Program : IOutputMessage
    {

        ProcessRequest processRequest;
        List<ProcessRequest> activeList;

        static void Main(string[] args)
        {
            Console.WriteLine("Start Time: {0}", DateTime.Now);
            int sleepMiliseconds = 10000;

            HeaderInfo.Instance.UserID = "SYSTEM";
            HeaderInfo.Instance.CurrentDateTime = DateTime.Now;

            var arguments = new Arguments( args );
            string processName = arguments ["processname"];

            if (string.IsNullOrEmpty(processName))
                processName = "DEBUG";

            Program program = new Program();

            ConnString.ConnectionString = ConnString.ConnectionStringServer;
            ConnString.ConnectionStringFramework = ConnString.ConnectionStringServer;

            LogFile.WriteToTodaysLogFile("Document Generation Server started " + DateTime.Now);
            Console.WriteLine("Document Generation Server started " + DateTime.Now);

            int i = 0;
            while (i <= 3)
            {
                i++;

                Console.WriteLine( "Running = " + DateTime.Now );
                Console.WriteLine( "Process Name = " + processName );

                // Check if there is a request
                //
                program.activeList =  BUSProcessRequest.ListActiveRequests();
                GenerateList( program, false, processName );

                //program.activeList = BUSProcessRequest.ListUnfinishedRequests();
                //GenerateList( program, true );
                Console.WriteLine("Iteration # "+i.ToString());

                Console.WriteLine("Sleeping for {0} miliseconds.", sleepMiliseconds);

                BUSFCMBackendStatus.ReportStatus(HeaderInfo.Instance, processName, "Sleeping...");

                Thread.Sleep(sleepMiliseconds);
            }

        }

        private static void GenerateList( Program program, bool isRestart, string processName )
        {
                #region startList
                if (program.activeList.Count > 0)
                {
                    // If there is a request, process the request
                    //

                    foreach (var request in program.activeList)
                    {

                        request.SetStatusToStarted();

                        program.processRequest = request;

                        // Update request to completed
                        //
                        if (request.Type == ProcessRequest.TypeValue.DOCUMENTGENERATION.ToString())
                        {
                            // Find Values
                            //
                            var clientUID = 0;
                            int clientSetID = 0;
                            var overrideDocument = "Yes";
                            int clientDocumentUID = 0;
                            string filename = " Full Set Generated";

                            foreach (var argument in request.argumentList)
                            {
                                if (argument.Code == ProcessRequestArguments.ProcessRequestCodeValues.CLIENTUID.ToString())
                                {
                                    clientUID = Convert.ToInt32(argument.Value);
                                }
                                if (argument.Code == ProcessRequestArguments.ProcessRequestCodeValues.CLIENTSETID.ToString())
                                {
                                    clientSetID = Convert.ToInt32(argument.Value);
                                }
                                if ( argument.Code == ProcessRequestArguments.ProcessRequestCodeValues.OVERRIDE.ToString() )
                                {
                                    overrideDocument = argument.Value;
                                }
                                if ( argument.Code == ProcessRequestArguments.ProcessRequestCodeValues.CLIENTDOCUID.ToString() )
                                {
                                    clientDocumentUID = Convert.ToInt32( argument.Value );
                                    if ( clientDocumentUID > 0 )
                                    {
                                        var clientDocument = BUSClientDocument.ClientDocumentReadS(clientDocumentUID);
                                        filename = " File: " + clientDocument.FileName;
                                    }
                                }
                            }

                            var client = BUSClient.ClientRead( new ClientReadRequest() { clientUID = clientUID, headerInfo = HeaderInfo.Instance } );


                            // Send email to requester
                            //
                            string emailGraham = "graham.coyle@federalcm.com.au";
                            string emailDaniel  = "DanielLGMachado@gmail.com";

                            string emailSubject = "<> STARTED <> " + DateTime.Now + "<> generation requested by: " + request.RequestedByUser +
                                                  " Client: " + clientUID + " " + client.client.Name +
                                                  filename;

                            string emailBody = "Generation Started: " + DateTime.Now + " <> " + emailSubject + " -- " ;

                            if ( request.RequestedByUser.ToUpper() == "GC0001" )
                            {
                                var resp1 = FCMEmail.SendEmailSimple(
                                    iRecipient: emailGraham,
                                    iSubject: emailSubject,
                                    iBody: emailBody );
                            }

                            var resp2 = FCMEmail.SendEmailSimple(
                                iRecipient: emailDaniel,
                                iSubject: emailSubject,
                                iBody: emailBody );


                            // 30.03.2012
                            // Mudar para processamento paralelo e async
                            //

                            // Generate Document
                            //
                            BUSFCMBackendStatus.ReportStatus( HeaderInfo.Instance, processName, "Before document generation starts." );
                            if ( clientDocumentUID > 0 )
                            {
                                program.GenerateDocumentsForClient( clientUID, clientSetID, program, overrideDocument, clientDocumentUID, processName, request.RequestedByUser );
                            }
                            else
                            {
                                program.GenerateFullSetOfDocumentsForClient( clientUID, clientSetID, program, overrideDocument, isRestart, processName, request.RequestedByUser );
                            }
                            // Write output to database of logs and allow access online or
                            // Write to a file and allow access online...
                            // We can see the process of the request...

                            request.SetStatusToCompleted();
                            HeaderInfo.Instance.UserID = request.RequestedByUser;
                            HeaderInfo.Instance.CurrentDateTime = DateTime.Now;



                            // Send email to requester
                            //

                            emailSubject = "<>  ENDED  <> " + DateTime.Now + "<> generation requested by: " + request.RequestedByUser +
                                                  " Client: " + clientUID + " " + client.client.Name +
                                                  filename;

                            emailBody = "Generation Ended: " + DateTime.Now + " <> " + emailSubject + " -- " + "File Generated.";

                            if ( request.RequestedByUser.ToUpper() == "GC0001" )
                            {
                                var resp3 = FCMEmail.SendEmailSimple(
                                    iRecipient: emailGraham,
                                    iSubject: emailSubject,
                                    iBody: emailBody);
                            }

                            var resp4 = FCMEmail.SendEmailSimple(
                                iRecipient: emailDaniel,
                                iSubject: emailSubject,
                                iBody: emailBody );
                        }
                    }
                }

                #endregion
        }

        private void GenerateDocumentsForClient( 
            int clientUID, 
            int clientSetID, 
            Program program, 
            string overrideDocument, 
            int clientDocumentuid, 
            string processName,
            string userID )

        {
            Console.WriteLine("Timer Time: {0}", DateTime.Now);

            AddOutputMessage( "Document generation starting...", processName, userID );

            DocumentGeneration wdt = new DocumentGeneration(ClientID: clientUID, 
                                                            ClientDocSetID: clientSetID,
                                                            UIoutput: program,
                                                            OverrideDocuments: overrideDocument,
                                                            inprocessName: processName,
                                                            inuserID: userID );

            //Thread t = new Thread(wdt.GenerateDocumentForClient);          // Kick off a new thread
            //t.Start();    
            
            // Generate document
            //

            if ( clientDocumentuid <= 0 )
            {
                wdt.GenerateDocumentForClient();
            }
            else
            {
                wdt.GenerateSingleDocument( clientDocumentuid, isRestart: false, fixDestinationFolder: true );
            }

            AddOutputMessage( "Generation Completed.", processName, userID );
        }


        private void GenerateListDocumentsForClient( int clientUID, int clientSetID, Program program, string overrideDocument, List<int> listDocs, bool isRestart, string processName, string userID )
        {
            Console.WriteLine( "Timer Time: {0}", DateTime.Now );

            AddOutputMessage( "Document generation starting...", processName, userID );

            DocumentGeneration wdt = new DocumentGeneration( ClientID: clientUID,
                                                            ClientDocSetID: clientSetID,
                                                            UIoutput: program,
                                                            OverrideDocuments: overrideDocument,
                                                            inprocessName: processName,
                                                            inuserID: userID );
            wdt.GenerateGroupOfDocuments(listDocs, isRestart);

            AddOutputMessage( "Generation Completed.", processName, userID );
        }

        private void GenerateFullSetOfDocumentsForClient( int clientUID, int clientSetID, Program program, string overrideDocument, bool isRestart, string processName, string userID )
        {
            Console.WriteLine( "Timer Time: {0}", DateTime.Now );

            AddOutputMessage( "Document generation starting...", processName, userID );

            DocumentGeneration wdt = new DocumentGeneration( ClientID: clientUID,
                                                            ClientDocSetID: clientSetID,
                                                            UIoutput: program,
                                                            OverrideDocuments: overrideDocument,
                                                            inprocessName: processName,
                                                            inuserID: userID );

            wdt.GenerateFullSetForClient( clientUID, clientSetID, isRestart );

            AddOutputMessage( "Generation Completed.", processName, userID );
        }
        
        
        
        
        public void Activate()
        {
            return;
        }

        public void AddErrorMessage( string errorMessage, string processName, string userID )
        {
            string msg =
                processName + ": " +
                DateTime.Now + ": " +
                userID + ": " +
                "Program.cs" + ": " +
                errorMessage; 

            ProcessRequestResults prr = new ProcessRequestResults();
            prr.FKRequestUID = this.processRequest.UID;
            prr.FKClientUID = this.processRequest.FKClientUID;
            prr.Type = ProcessRequestResults.TypeValue.ERROR.ToString();
            prr.Results = msg;

            prr.Add();

            Console.WriteLine( msg );

            LogFile.WriteToTodaysLogFile( errorMessage, processName );
            LogFile.WriteToTodaysLogFile( what: errorMessage, userID: userID, messageCode: "", programName: "UIOutputMessage.cs", processname: processName );
        }

        public void AddOutputMessage( string outputMessage, string processName, string userID)
        {

            string msg =
                processName + ": " +
                DateTime.Now + ": " +
                userID + ": " +
                "Program.cs" + ": " +
                outputMessage; 

            ProcessRequestResults prr = new ProcessRequestResults();
            prr.FKRequestUID = this.processRequest.UID;
            prr.FKClientUID = this.processRequest.FKClientUID;
            prr.Type = ProcessRequestResults.TypeValue.INFORMATIONAL.ToString();
            prr.Results = processName + " " + outputMessage;

            prr.Add();

            Console.WriteLine( msg );

            LogFile.WriteToTodaysLogFile( what: outputMessage, userID: userID, messageCode: "", programName: "UIOutputMessage.cs", processname: processName );

        }

        public void UpdateProgressBar(double value, DateTime estimatedTime, int documentsToBeGenerated = 0)
        {
            return;
        }
    }

}
