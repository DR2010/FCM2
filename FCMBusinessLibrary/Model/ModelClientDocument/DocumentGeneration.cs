using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using FCMMySQLBusinessLibrary.FCMUtils;
using FCMMySQLBusinessLibrary.Model.ModelMetadata;
using FCMMySQLBusinessLibrary.Repository.RepositoryClientDocument;
using FCMMySQLBusinessLibrary.Repository.RepositoryDocument;
using FCMMySQLBusinessLibrary.Service.SVCClient.Service;
using FCMMySQLBusinessLibrary.Service.SVCClientDocument.Service;
using FCMMySQLBusinessLibrary.Service.SVCFCMBackendStatus.Service;
using MackkadoITFramework.ErrorHandling;
using MackkadoITFramework.Interfaces;
using MackkadoITFramework.APIDocument;
using MackkadoITFramework.Utils;

namespace FCMMySQLBusinessLibrary.Model.ModelClientDocument
{
    public class DocumentGeneration
    {
        private object vkFalse;
        private Word.Application vkWordApp;
        // private Microsoft.Office.Interop.Excel.Application vkExcelApp;
        private ReportMetadataList clientMetadata;
        private List<WordDocumentTasks.TagStructure> listOfWordsToReplace;
        private int clientID;
        private int clientDocSetID;
        private double fileprocessedcount;
        private double valueForProgressBar;
        private string startTime;
        private int filecount;
        private IOutputMessage uioutput;
        private string overrideDocuments;
        private ClientDocumentSet cds;
        private DateTime estimated;
        private double averageSpanInSec;
        private double acumulatedSpanInSec;
        private string processName;
        private string userID;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ClientID"></param>
        /// <param name="ClientDocSetID"></param>
        /// <param name="UIoutput"> </param>
        public DocumentGeneration( int ClientID, int ClientDocSetID, IOutputMessage UIoutput,
                                   string OverrideDocuments, string inprocessName, string inuserID)
        {
            processName = inprocessName;
            userID = inuserID;

            if ( OverrideDocuments == null )
                OverrideDocuments = "N";

            // Assign to internal variables
            //
            // iconMessage = IconMessage;

            // Set private attributes
            clientID = ClientID;
            clientDocSetID = ClientDocSetID;
            uioutput = UIoutput;
            overrideDocuments = OverrideDocuments;

            // Instantiate Word
            //
            vkFalse = false;

            vkWordApp = new Word.Application();

            // Make it not visible
            vkWordApp.Visible = false;

            //vkExcelApp = new Microsoft.Office.Interop.Excel.Application();

            // Make it not visible
            // vkExcelApp.Visible = false;

            // Get Metadata for client

            clientMetadata = new ReportMetadataList();

            // Daniel 31/12/2011
            //
            // clientMetadata.ListMetadataForClient(clientID);
            // The intention is to always use the full set of variables.
            // There is need to use all in order to replace the tags not used.
            //
            clientMetadata.ListDefault();

            listOfWordsToReplace = new List<WordDocumentTasks.TagStructure>();

            // Load variables/ metadata into memory
            //
            #region ClientMetadata
            foreach ( ReportMetadata metadata in clientMetadata.reportMetadataList )
            {
                // Add client ID
                metadata.ClientUID = this.clientID;

                // Retrieve value for the field selected
                //
                string value =  metadata.GetValue();

                // If the field is not enabled, the program has to replace the value with spaces.
                // 01-Jan-2012 - No longer necessary.
                // All the variables have to be used

                // var valueOfTag = metadata.Enabled == 'Y' ? value : string.Empty;

                // Set to the value. If value is null, set to spaces.
                var valueOfTag = string.IsNullOrEmpty( value ) ? string.Empty : value;

                // When the field is an image and it is not enable, do not include the "No image" icon in the list
                //
                //if (metadata.InformationType == Utils.InformationType.IMAGE && metadata.Enabled == 'N')
                //    continue;

                // If the field is an image but it has no value, no need to include.
                // Regular fields must be included because they need to be replaced.
                // Images uses bookmarks, no need to be replace. It is not displayed in the document.
                //
                if ( metadata.InformationType == MackkadoITFramework.Helper.Utils.InformationType.IMAGE )
                {
                    if ( string.IsNullOrEmpty( value ) )
                        continue;
                }

                // Add label before value to print.
                //
                if ( metadata.UseAsLabel == 'Y' )
                    valueOfTag = metadata.Description + " " + valueOfTag;

                listOfWordsToReplace.Add( new WordDocumentTasks.TagStructure()
                {
                    TagType = metadata.InformationType,
                    Tag = metadata.FieldCode,
                    TagValue = valueOfTag
                } );

            }
            #endregion ClientMetadata

            // Get Client Document Set Details 
            // To get the source and destination folders
            cds = new ClientDocumentSet();
            cds.Get( clientID, clientDocSetID );

            fileprocessedcount = 0;
            valueForProgressBar = 0;
            startTime = System.DateTime.Now.ToString();

        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~DocumentGeneration()
        {

            // close word application
            if ( vkWordApp != null )
            {
                try
                {
                    vkWordApp.Quit( ref vkFalse, ref vkFalse, ref vkFalse );
                }
                catch
                {
                }
                finally
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject( vkWordApp );
                }
            }
            //if ( vkExcelApp != null )
            //{
            //    try
            //    {
            //        vkExcelApp.Quit();
            //    }
            //    catch
            //    { }
            //    finally
            //    {
            //        System.Runtime.InteropServices.Marshal.ReleaseComObject( vkExcelApp );
            //    }
            //}

        }

        /// <summary>
        /// Generate documents selected for a client
        /// </summary>
        /// <param name="clientID"></param>
        /// <param name="clientDocSetID"></param>
        /// <param name="uioutput"></param>
        /// <param name="overrideDocuments"></param>
        private void TBD_GenerateDocumentsForClient(
            int clientID, int clientDocSetID,
            string overrideDocuments )
        {


            uioutput.AddOutputMessage( "Start time: " + System.DateTime.Now.ToString(), processName, userID );

            // Instantiate Word
            //
            object vkFalse = false;
            object vkTrue = true;

            Word.Application vkWordApp =
                                 new Word.Application();

            // Make it not visible
            vkWordApp.Visible = false;

            Microsoft.Office.Interop.Excel.Application vkExcelApp = new Microsoft.Office.Interop.Excel.Application();

            // Make it not visible
            vkExcelApp.Visible = false;

            // Get Metadata for client

            ReportMetadataList clientMetadata = new ReportMetadataList();
            clientMetadata.ListMetadataForClient( clientID );

            var ts = new List<WordDocumentTasks.TagStructure>();

            // Load variables/ metadata into memory
            //
            foreach ( ReportMetadata metadata in clientMetadata.reportMetadataList )
            {
                // Retrieve value for the field selected
                //
                string value =  metadata.GetValue();

                // If the field is not enabled, the program has to replace the value with spaces.
                //
                var valueOfTag = metadata.Enabled == 'Y' ? value : string.Empty;

                // When the field is an image and it is not enable, do not include the "No image" icon in the list
                //
                if ( metadata.InformationType == MackkadoITFramework.Helper.Utils.InformationType.IMAGE && metadata.Enabled == 'N' )
                    continue;

                ts.Add( new WordDocumentTasks.TagStructure()
                {
                    TagType = metadata.InformationType,
                    Tag = metadata.FieldCode,
                    TagValue = valueOfTag
                } );

            }

            // Get Client Document Set Details 
            // To get the source and destination folders
            ClientDocumentSet cds = new ClientDocumentSet();
            cds.Get( clientID, clientDocSetID );

            // Get List of documents for a client
            //
            var cdl = new ClientDocument();
            //cdl.List( Utils.ClientID, Utils.ClientSetID );

            RepClientDocument.List( cdl, Utils.ClientID, Utils.ClientSetID );


            bool fileNotFound = false;
            // ---------------------------------------------------------------------------
            //    Check if source files exist before generation starts
            // ---------------------------------------------------------------------------
            int filecount = 0;
            foreach ( scClientDocSetDocLink doco in cdl.clientDocSetDocLink )
            {
                #region File Inspection
                filecount++;

                // Ignore for now
                //
                if ( doco.clientDocument.RecordType.Trim() == FCMConstant.RecordType.FOLDER )
                {
                    string er = "Folder " + doco.document.Name;

                    uioutput.AddOutputMessage( er, processName, userID );
                    continue;
                }


                // Retrieve updated file name from source
                Model.ModelDocument.Document document = new Model.ModelDocument.Document();
                document.UID = doco.clientDocument.FKDocumentUID;
                // document.Read();

                document = RepDocument.Read( false, doco.clientDocument.FKDocumentUID );

                uioutput.AddOutputMessage( "Inspecting file: " + document.UID + " === " + document.Name, processName, userID );

                // Client Document.SourceFileName is the name for the FCM File
                // Client Document.FileName is the client file name

                // Update client records with new file name
                //
                // Instantiate client document
                ClientDocument cd = new ClientDocument();
                cd.UID = doco.clientDocument.UID;
                // cd.FileName = document.FileName;
                cd.SourceFileName = document.FileName;

                RepClientDocument.UpdateSourceFileName( cd );

                // Update memory with latest file name
                // doco.clientDocument.SourceFileName = cd.FileName;
                doco.clientDocument.SourceFileName = cd.SourceFileName;

                string sourceFileLocationName = Utils.getFilePathName(
                       doco.clientDocument.SourceLocation,
                       doco.clientDocument.SourceFileName );

                // check if source folder/ file exists
                if ( string.IsNullOrEmpty( doco.clientDocument.Location ) )
                {
                    MessageBox.Show( "Document Location is empty." );
                    return;
                }

                if ( string.IsNullOrEmpty( doco.clientDocument.FileName ) )
                {
                    MessageBox.Show( "File Name is empty." );
                    return;
                }

                if ( !File.Exists( sourceFileLocationName ) )
                {
                    string er = "File does not exist " +
                        sourceFileLocationName + " - File Name: " + doco.clientDocument.SourceFileName;

                    uioutput.AddOutputMessage( er, processName: processName, userID: userID );
                    uioutput.AddErrorMessage( er, processName:processName, userID:userID );
                    fileNotFound = true;
                    continue;

                }
                #endregion File Inspection
            }


            // Can't proceed if file not found
            if ( fileNotFound )
                return;

            // Check if destination folder exists
            //
            if ( string.IsNullOrEmpty( cds.Folder ) )
            {
                MessageBox.Show( "Destination folder not set. Generation stopped." );
                return;
            }
            string PhysicalCDSFolder = Utils.GetPathName( cds.Folder );
            if ( !Directory.Exists( PhysicalCDSFolder ) )
                Directory.CreateDirectory( PhysicalCDSFolder );


            // -----------------------------------------------------------------------
            //                          Generation starts here
            // -----------------------------------------------------------------------

            fileprocessedcount = 0;
            valueForProgressBar = 0;
            startTime = System.DateTime.Now.ToString();
            estimated = System.DateTime.Now.AddSeconds( 5 * filecount );

            var previousTime = System.DateTime.Now;
            var agora = System.DateTime.Now;

            foreach ( scClientDocSetDocLink doco in cdl.clientDocSetDocLink )
            {
                fileprocessedcount++;
                valueForProgressBar = ( fileprocessedcount / filecount ) * 100;

                // Get current time
                agora = System.DateTime.Now;

                // Get the time it took to process one file
                TimeSpan span = agora.Subtract( previousTime );

                // Calculate the estimated time to complete
                estimated = System.DateTime.Now.AddSeconds( span.TotalSeconds * filecount );

                uioutput.UpdateProgressBar( valueForProgressBar, estimated );

                previousTime = System.DateTime.Now;

                // Retrieve latest version
                //
                Model.ModelDocument.Document document = new Model.ModelDocument.Document();
                document.UID = doco.clientDocument.FKDocumentUID;
                // document.Read();

                document = RepDocument.Read( false, doco.clientDocument.FKDocumentUID );

                uioutput.AddOutputMessage( ">>> Generating file: " + document.UID + " === " + document.SimpleFileName, processName, userID );

                string sourceFileLocationName = Utils.getFilePathName(
                       doco.clientDocument.SourceLocation,
                       doco.clientDocument.SourceFileName );

                // This is the client file name
                //
                string clientFileLocation = cds.Folder.Trim() +
                    doco.clientDocument.Location.Trim();

                string clientFileLocationName = Utils.getFilePathName(
                    clientFileLocation,
                    doco.clientDocument.FileName.Trim() );



                // Check if file destination directory exists
                //
                string PhysicalLocation = Utils.GetPathName( clientFileLocation );

                if ( string.IsNullOrEmpty( PhysicalLocation ) )
                {
                    string er = "Location is empty " + doco.clientDocument.Location + "\n" +
                                "File Name: " + doco.document.Name;

                    uioutput.AddOutputMessage( er, processName, userID );
                    continue;
                }

                if ( !Directory.Exists( PhysicalLocation ) )
                    Directory.CreateDirectory( PhysicalLocation );

                if ( File.Exists( clientFileLocationName ) )
                {
                    // Proceed but report in list
                    //
                    if ( overrideDocuments == "Yes" )
                    {
                        // Delete file
                        try
                        {
                            File.Delete( clientFileLocationName );
                            uioutput.AddOutputMessage( "File replaced " +
                                              document.SimpleFileName, processName, userID );
                        }
                        catch ( Exception )
                        {
                            uioutput.AddOutputMessage( "Error deleting file " +
                                              document.SimpleFileName, processName, userID );
                            uioutput.AddErrorMessage( "Error deleting file " +
                                              document.SimpleFileName, processName, userID );

                            continue;
                        }
                    }
                    else
                    {
                        uioutput.AddOutputMessage( "File already exists " +
                                          document.SimpleFileName, processName, userID ); 
                        continue;
                    }
                }

                // Copy and fix file
                //

                // Word Documents
                //
                if ( doco.clientDocument.RecordType.Trim() == FCMConstant.RecordType.FOLDER )
                {
                    // Update file - set as GENERATED.
                    //

                    uioutput.AddOutputMessage( "FOLDER: " + doco.clientDocument.SourceFileName, processName, userID );
                }
                else
                {

                    // If is is not a folder, it must be a regular file.
                    // Trying to copy it as well...
                    //

                    var currentDocumentPath = Path.GetExtension( doco.clientDocument.FileName );

                    if ( doco.clientDocument.DocumentType == MackkadoITFramework.Helper.Utils.DocumentType.WORD )
                    {
                        #region Word
                        // ------------------------------------------------------------------------
                        // ------------------------------------------------------------------------
                        // Generate Document and replace tag values in new document generated
                        // ------------------------------------------------------------------------
                        // ------------------------------------------------------------------------
                        var results = WordDocumentTasks.CopyDocument( sourceFileLocationName, clientFileLocationName, ts, vkWordApp, uioutput, processName, userID );
                        if ( results.ReturnCode < 0 )
                        {
                            // Error has occurred
                            //
                            var er = (System.Exception) results.Contents;
                            uioutput.AddOutputMessage( "ERROR: " + er.ToString(), processName, userID );
                            uioutput.AddErrorMessage( "ERROR: " + er.ToString(), processName, userID );

                            continue;
                        }


                        //
                        // Instantiate client document
                        var cd = new ClientDocument();
                        cd.UID = doco.clientDocument.UID;


                        // Update file - set as GENERATED.
                        //

                        // cd.SetGeneratedFlagVersion( 'Y', document.IssueNumber );

                        RepClientDocument.SetGeneratedFlagVersion( cd, 'Y', document.IssueNumber, DateTime.Today.ToString( "yyyyMMdd" ) + " - Generated successfully" );

                        uioutput.AddOutputMessage( "Document generated: " +
                                          clientFileLocationName, processName, userID );

                        #endregion Word
                    }
                    else if ( doco.clientDocument.DocumentType == MackkadoITFramework.Helper.Utils.DocumentType.EXCEL )
                    {
                        // ------------------------------------------------------------------------
                        // ------------------------------------------------------------------------
                        // Generate Document and replace tag values in new document generated
                        // ------------------------------------------------------------------------
                        // ------------------------------------------------------------------------

                        ExcelSpreadsheetTasks.CopyDocument( sourceFileLocationName, clientFileLocationName, ts, uioutput, processName, userID );

                        //
                        // Instantiate client document
                        ClientDocument cd = new ClientDocument();
                        cd.UID = doco.clientDocument.UID;

                        // Update file - set as GENERATED.
                        //

                        //cd.SetGeneratedFlagVersion( 'Y', document.IssueNumber );
                        RepClientDocument.SetGeneratedFlagVersion( cd, 'Y', document.IssueNumber, DateTime.Today.ToString( "yyyyMMdd" ) + " - Generated successfully - " + clientFileLocationName );
                        uioutput.AddOutputMessage( "Document generated: " + clientFileLocationName, processName, userID );

                    }
                    else
                    {
                        File.Copy( sourceFileLocationName, clientFileLocationName );

                        uioutput.AddOutputMessage( "File copied but not modified: " +
                                 Path.GetExtension( doco.clientDocument.FileName ) + " == File: " + clientFileLocationName, processName, userID );
                    }

                }
            }

            // close word application
            vkWordApp.Quit( SaveChanges: ref vkTrue, OriginalFormat: ref vkTrue, RouteDocument: ref vkFalse );
            vkExcelApp.Quit();

            uioutput.AddOutputMessage( "End time: " + System.DateTime.Now.ToString(), processName, userID );

        }

        /// <summary>
        /// Generate document for client (no treeview required)
        /// </summary>
        public void GenerateDocumentForClient()
        {

            // Load documents in tree 
            //
            TreeView tvFileList = new TreeView();

            // List client document list
            //
            var documentSetList = new ClientDocument();
            //documentSetList.List(this.clientID, this.clientDocSetID);
            RepClientDocument.List( documentSetList, this.clientID, this.clientDocSetID );

            tvFileList.Nodes.Clear();
            // documentSetList.ListInTree(tvFileList, "CLIENT");

            RepClientDocument.ListInTree( documentSetList, tvFileList, "CLIENT" );

            // Generate document
            //
            this.GenerateDocumentsForClient( tvFileList.Nodes [0] );
        }

        /// <summary>
        /// Generate documents based on tree
        /// </summary>
        /// <param name="clientID"></param>
        /// <param name="clientDocSetID"></param>
        /// <param name="uioutput"></param>
        /// <param name="overrideDocuments"></param>
        /// <param name="documentsTreeNode"></param>
        public void GenerateDocumentsForClient( TreeNode documentsTreeNode )
        {

            if ( uioutput != null ) uioutput.AddOutputMessage( "Start time: " + System.DateTime.Now.ToString(), processName, userID );

            filecount = documentsTreeNode.GetNodeCount( includeSubTrees: true );

            estimated = System.DateTime.Now.AddSeconds( 5 * filecount );

            if ( uioutput != null ) uioutput.UpdateProgressBar( valueForProgressBar, estimated );

            GenerateDocumentsController( documentsTreeNode );

            if ( uioutput != null ) uioutput.AddOutputMessage( "End time: " + System.DateTime.Now.ToString(), processName, userID );

            // Set end bar
            if ( uioutput != null ) uioutput.UpdateProgressBar( 100, estimated );


        }


        /// <summary>
        /// This operation updates the destination folder following the
        /// hierarchy of the tree instead of the initial location.
        /// </summary>
        /// <param name="documentsTreeNode"></param>
        public static ResponseStatus UpdateDestinationFolder( int clientID, int clientDocumentSetUID )
        {
            ResponseStatus response = new ResponseStatus();
            response.Contents = "Destination folder updated successfully.";

            // Fix root folder first
            //
            ClientDocument clientDocument = new ClientDocument();
            
            RepClientDocument.FixRootFolder(clientID, clientDocumentSetUID);

            var listOfDocuments = RepClientDocument.ListS( clientID, clientDocumentSetUID );

            foreach ( var doco in listOfDocuments )
            {
                // Update location
                //
                ResponseStatus destLocationDerivedClient = RepClientDocument.GetDocumentPath( doco.clientDocument );
                string destLocationDerived = destLocationDerivedClient.Contents.ToString();

                RepClientDocument.UpdateFieldString( doco.clientDocument.UID, "Location", destLocationDerived );

                // Update file name
                //
                if ( doco.clientDocument.IsFolder == 'Y' )
                {
                    if ( doco.clientDocument.IsRoot == 'Y')
                        RepClientDocument.UpdateFieldString( doco.clientDocument.UID, "FileName", doco.clientDocument.FileName );
                    else
                        RepClientDocument.UpdateFieldString( doco.clientDocument.UID, "FileName", doco.document.FileName );
                }

                response.Contents = destLocationDerived;

            }
            return response;
        }

        /// <summary>
        /// Generate Documents Controller (Word must be previously initialised
        /// </summary>
        private void GenerateDocumentsController( TreeNode documentsTreeNode )
        {
            scClientDocSetDocLink documentTN = new scClientDocSetDocLink();

            // Get List of documents for a client
            //
            if ( documentsTreeNode.Tag.GetType().Name == "scClientDocSetDocLink" )
            {
                documentTN = (scClientDocSetDocLink) documentsTreeNode.Tag;
            }
            else
            {
                if ( documentsTreeNode.Tag.GetType().Name == "Document" )
                {
                    if ( documentTN.clientDocument == null )
                    {
                        if ( uioutput != null ) uioutput.AddOutputMessage( "Error CDISNULL019202 - client document is null.", processName, userID );
                        if ( uioutput != null ) uioutput.AddErrorMessage( "Error CDISNULL019202 - client document is null. Generation stopped.", processName, userID );
                        return;
                    }

                    documentTN.clientDocument.RecordType = FCMConstant.RecordType.DOCUMENT;
                    documentTN.document = (Model.ModelDocument.Document) documentsTreeNode.Tag;
                }
            }

            // If it is a document, generate
            if ( documentTN.clientDocument.RecordType.Trim() != FCMConstant.RecordType.FOLDER )
            {
                #region Generate Document
                // Generate

                // Retrieve updated file name from source
                Model.ModelDocument.Document document = new Model.ModelDocument.Document();
                document.UID = documentTN.clientDocument.FKDocumentUID;
                // document.Read();

                document = RepDocument.Read( false, documentTN.clientDocument.FKDocumentUID );

                if ( uioutput != null ) uioutput.AddOutputMessage( "Inspecting file: " + document.UID + " === " + document.Name, processName, userID );
                // if (iconMessage != null) iconMessage.Text = "Start time: " + System.DateTime.Now.ToString();

                // Update client records with new file name
                //
                // Instantiate client document
                ClientDocument cd = new ClientDocument();
                cd.UID = documentTN.clientDocument.UID;
                cd.SourceFileName = document.FileName;
                // cd.Read();

                // Set comboIssueNumber and File Name
                //
                RepClientDocument.SetClientDestinationFile(
                            clientDocument: cd,
                            clientUID: documentTN.clientDocument.FKClientUID,
                            documentCUID: document.CUID,
                            sourceVersionNumber: document.IssueNumber,
                            simpleFileName: document.SimpleFileName );

                //cd.UpdateSourceFileName();
                // RepClientDocument.UpdateSourceFileName( cd );

                // Update memory with latest file name
                documentTN.clientDocument.SourceFileName = cd.SourceFileName;

                string sourceFileLocationName = Utils.getFilePathName(
                       documentTN.clientDocument.SourceLocation,
                       documentTN.clientDocument.SourceFileName );

                // check if source folder/ file exists
                if ( string.IsNullOrEmpty( documentTN.clientDocument.Location ) )
                {
                    if ( uioutput != null ) uioutput.AddOutputMessage( "Document Location is empty.", processName, userID );
                    return;
                }

                if ( string.IsNullOrEmpty( documentTN.clientDocument.FileName ) )
                {
                    if ( uioutput != null ) uioutput.AddOutputMessage( "File Name is empty.", processName, userID );
                    return;
                }

                if ( !File.Exists( sourceFileLocationName ) )
                {
                    string er = "File does not exist " +
                        sourceFileLocationName + " - File Name: " + documentTN.clientDocument.SourceFileName;

                    if ( uioutput != null ) uioutput.AddOutputMessage( er, processName, userID );
                    if ( uioutput != null ) uioutput.AddErrorMessage( er, processName, userID );
                    return;

                }


                // Check if destination folder exists
                //
                if ( string.IsNullOrEmpty( cds.Folder ) )
                {
                    string er = "Destination folder not set. Generation stopped.";
                    if ( uioutput != null ) uioutput.AddOutputMessage( er, processName, userID );
                    return;
                }
                string PhysicalCDSFolder = Utils.GetPathName( cds.Folder );
                if ( !Directory.Exists( PhysicalCDSFolder ) )
                    Directory.CreateDirectory( PhysicalCDSFolder );

                // Generate one document (Folder will also be created in this call)
                //

                // Get time before file
                var previousTime = System.DateTime.Now;

                // ===================================================================
                //
                //
                try
                {
                    // GenerateDocument( documentTN );
                    GenerateSingleDocument( documentTN.clientDocument.UID, isRestart: false, fixDestinationFolder: true );
                }
                catch ( Exception ex )
                {
                    if ( uioutput != null ) uioutput.AddOutputMessage( "Error generating document. " + documentTN.document.FileName + " " + ex, processName, userID );
                }
                //
                //
                // ===================================================================
                // Get time after file
                var agora = System.DateTime.Now;

                fileprocessedcount++;
                valueForProgressBar = ( fileprocessedcount / filecount ) * 100;
                int leftToProcess = filecount - Convert.ToInt32( fileprocessedcount );

                // Get the time it took to process one file
                TimeSpan span = agora.Subtract( previousTime );

                // Average span in seconds
                acumulatedSpanInSec += span.Seconds;
                averageSpanInSec = acumulatedSpanInSec / fileprocessedcount;

                // Calculate the estimated time to complete
                estimated = System.DateTime.Now.AddSeconds( averageSpanInSec * leftToProcess );

                if ( uioutput != null ) uioutput.UpdateProgressBar( valueForProgressBar, estimated, leftToProcess );

                return;
                #endregion Generate Document

                // Processing for one file ends here
            }
            else
            {
                // If item imported is a FOLDER

                // This is the client destination folder (and name)
                //
                string clientDestinationFileLocation = documentTN.clientDocument.Location.Trim();

                if ( !string.IsNullOrEmpty( clientDestinationFileLocation ) )
                {

                    string clientDestinationFileLocationName = Utils.getFilePathName(
                    clientDestinationFileLocation, documentTN.clientDocument.FileName.Trim() );

                    // string PhysicalLocation = Utils.GetPathName(clientDestinationFileLocation);
                    string PhysicalLocation = clientDestinationFileLocationName;

                    if ( uioutput != null ) uioutput.AddOutputMessage( "Processing Folder: " + PhysicalLocation, processName, userID );

                    if ( !string.IsNullOrEmpty( PhysicalLocation ) )
                    {
                        if ( !Directory.Exists( PhysicalLocation ) )
                        {
                            if ( uioutput != null ) uioutput.AddOutputMessage( "Folder Created: " + clientDestinationFileLocationName, processName, userID );

                            Directory.CreateDirectory( PhysicalLocation );
                        }
                        else
                        {
                            if ( uioutput != null ) uioutput.AddOutputMessage( "Folder Already Exists: " + clientDestinationFileLocationName, processName, userID );
                        }
                    }
                }
                else
                {
                    if ( uioutput != null ) uioutput.AddOutputMessage( "Folder Ignored: " + documentTN.document.Name, processName, userID );
                }

                // Process each document in folder
                //
                foreach ( TreeNode tn in documentsTreeNode.Nodes )
                {
                    scClientDocSetDocLink doco = (scClientDocSetDocLink) tn.Tag;

                    GenerateDocumentsController( tn );
                }
            }
        }


        /// <summary>
        /// Generate one document - Stop using this one ASAP, replace by GenerateSingleDocument
        /// </summary>
        /// <param name="doco"></param>
        public void GenerateDocumentTBD( scClientDocSetDocLink doco, string processName, string userID )
        {

            // Deprecated - use GenerateSingleDocument if possible
            //
            //


            // Retrieve latest version
            //
            Model.ModelDocument.Document document = new Model.ModelDocument.Document();
            document.UID = doco.clientDocument.FKDocumentUID;
            // document.Read();

            RepDocument.Read( false, doco.clientDocument.FKDocumentUID );

            string msg = ">>> Generating file: " + document.UID + " === " + document.SimpleFileName;
            if ( uioutput != null ) uioutput.AddOutputMessage( msg, processName, userID );
            // if (iconMessage != null) iconMessage.Text = ">>> Generating file: " + document.UID;


            // Locate source file
            //
            string sourceFileLocationName = Utils.getFilePathName(
                   doco.clientDocument.SourceLocation,
                   doco.clientDocument.SourceFileName );

            // Find the parent folder location
            //
            int parentUID = doco.clientDocument.ParentUID;
            var cdParent = new ClientDocument();
            cdParent.UID = parentUID;
            // cdParent.Read();

            cdParent = RepClientDocument.Read( parentUID );

            // This is the client destination folder (and name)
            //
            //ResponseStatus destLocationDerivedClient = ClientDocument.GetDocumentPath(doco.clientDocument);
            //string destLocationDerived = destLocationDerivedClient.Contents.ToString();

            string clientDestinationFileLocation = doco.clientDocument.Location.Trim();

            string clientDestinationFileLocationName = Utils.getFilePathName(
                clientDestinationFileLocation, doco.clientDocument.FileName.Trim() );

            // This is the source client file name
            //
            string clientSourceFileLocation = doco.clientDocument.Location.Trim();

            string clientSourceFileLocationName = Utils.getFilePathName(
                clientSourceFileLocation,
                doco.clientDocument.FileName.Trim() );

            // Source location and destination may be different.
            // The destination of the file must be the one where it lives on the actual tree
            // To determine where the file should be located, we need to get the parent folder
            // The only way to determine the parent folder is walking through the entire tree from the root.
            // The root is the only thing that can be trusted. Every other location is dependent on the root.

            // The determination of the file location occurs in 2 parts. The one here is the second part.
            // At this point we are not going to use the source location of the original document, instead
            // we are going to use the client document location
            //

            // Check if destination folder directory exists
            //
            string PhysicalLocation = Utils.GetPathName( clientDestinationFileLocation );

            if ( string.IsNullOrEmpty( PhysicalLocation ) )
            {
                string er = "Location is empty " + clientDestinationFileLocation + "\n" +
                            "File Name: " + doco.document.Name;

                if ( uioutput != null ) uioutput.AddOutputMessage( er, processName, userID );
                return;
            }


            // 02/04/2011
            // This step should be done when the "FOLDER" record is created and not when the document
            // is generated
            //

            //if (!Directory.Exists( PhysicalLocation ))
            //    Directory.CreateDirectory( PhysicalLocation );


            // However the folder existence must be checked
            //
            if ( !Directory.Exists( PhysicalLocation ) )
            {
                Directory.CreateDirectory( PhysicalLocation );

                string er = "Destination folder has been created with File! " + PhysicalLocation + "\n" +
                "File Name: " + doco.document.Name;

                if ( uioutput != null ) uioutput.AddOutputMessage( er, processName, userID );
                //return;
            }

            if ( File.Exists( clientDestinationFileLocationName ) )
            {
                // Proceed but report in list
                //
                if ( overrideDocuments == "Yes" )
                {
                    // Delete file
                    try
                    {
                        File.Delete( clientDestinationFileLocationName );
                        if ( uioutput != null ) uioutput.AddOutputMessage( "File deleted... " +
                                            document.SimpleFileName, processName, userID );


                    }
                    catch ( Exception )
                    {
                        if ( uioutput != null ) uioutput.AddOutputMessage( "Error deleting file " +
                                            document.SimpleFileName, processName, userID );
                        if ( uioutput != null ) uioutput.AddErrorMessage( "Error deleting file " +
                                            document.SimpleFileName, processName, userID ); 
                        return;
                    }
                }
                else
                {
                    if ( uioutput != null ) uioutput.AddOutputMessage( "File already exists " +
                                        document.SimpleFileName, processName, userID );
                    return;
                }
            }

            // Copy and fix file
            //

            if ( uioutput != null ) uioutput.AddOutputMessage( "Replacing variables... ", processName, userID );


            // Word Documents
            //
            if ( doco.clientDocument.RecordType.Trim() == FCMConstant.RecordType.FOLDER )
            {
                // Update file - set as GENERATED.
                //

                // This is the moment where the folder destination has to be created
                // and the folder db record has to be updated with the location
                //

                if ( !Directory.Exists( PhysicalLocation ) )
                    Directory.CreateDirectory( PhysicalLocation );

                if ( uioutput != null ) uioutput.AddOutputMessage( "FOLDER: " + doco.clientDocument.SourceFileName, processName, userID );
            }
            else
            {

                // If is is not a folder, it must be a regular file.
                // Trying to copy it as well...
                //

                var currentDocumentPath = Path.GetExtension( doco.clientDocument.FileName );

                if ( doco.clientDocument.DocumentType == MackkadoITFramework.Helper.Utils.DocumentType.WORD )
                {
                    #region Word
                    // ------------------------------------------------------------------------
                    // ------------------------------------------------------------------------
                    // Generate Document and replace tag values in new document generated
                    // ------------------------------------------------------------------------
                    // ------------------------------------------------------------------------
                    var results = WordDocumentTasks.CopyDocument( sourceFileLocationName, clientSourceFileLocationName, listOfWordsToReplace, vkWordApp, uioutput, processName, userID );
                    if ( results.ReturnCode < 0 )
                    {
                        // Error has occurred
                        //
                        var er = (System.Exception) results.Contents;
                        if ( uioutput != null ) uioutput.AddOutputMessage( "ERROR: " + er.ToString(), processName, userID );
                        if ( uioutput != null ) uioutput.AddErrorMessage( "ERROR: " + er.ToString(), processName, userID );

                        return;
                    }

                    #endregion Word
                }
                else if ( doco.clientDocument.DocumentType == MackkadoITFramework.Helper.Utils.DocumentType.EXCEL )
                {
                    // ------------------------------------------------------------------------
                    // ------------------------------------------------------------------------
                    // Generate Document and replace tag values in new document generated
                    // ------------------------------------------------------------------------
                    // ------------------------------------------------------------------------
                    ExcelSpreadsheetTasks.CopyDocument( sourceFileLocationName, clientSourceFileLocationName, listOfWordsToReplace, uioutput, processName, userID );

                }
                else
                {
                    File.Copy( sourceFileLocationName, clientSourceFileLocationName );

                    if ( uioutput != null ) uioutput.AddOutputMessage( "File copied but not modified: " +
                               Path.GetExtension( doco.clientDocument.FileName ) + " == File: " + clientSourceFileLocationName, processName, userID );

                }

                //
                // Instantiate client document
                ClientDocument cd = new ClientDocument();
                cd.UID = doco.clientDocument.UID;

                // Update file - set as GENERATED.
                //

                RepClientDocument.SetGeneratedFlagVersion( cd, 'Y', document.IssueNumber, DateTime.Today.ToString( "yyyyMMdd" ) + " - Generated successfully - " );

                if ( uioutput != null ) uioutput.AddOutputMessage( "Document generated: " +
                                    clientDestinationFileLocationName, processName, userID );
            }
            return;
        }

        /// <summary>
        /// Generate selected documents
        /// </summary>
        /// <param name="clientDocumentUIDList"></param>
        public void GenerateGroupOfDocuments( List<int> clientDocumentUIDList, bool isRestart )
        {
            // Read Local config to check if it has to stop
            //
            string stopGeneration = XmlConfig.ReadLocal( MakConstant.ConfigXml.StopGeneration );
            if ( stopGeneration == "Y" )
            {
                if ( uioutput != null ) uioutput.AddOutputMessage( "!!! Generation has stopped before first document using config.", processName, userID );
                return;
            }


            int i = 0;
            bool fixfolders = false;

            foreach ( var docuid in clientDocumentUIDList )
            {
                i++;
                if ( uioutput != null ) uioutput.AddOutputMessage( ".....", processName, userID );
                if ( uioutput != null ) uioutput.AddOutputMessage( ".....", processName, userID );
                if ( uioutput != null ) uioutput.AddOutputMessage( "Generating document # " + docuid.ToString(), processName, userID );
                if ( uioutput != null ) uioutput.AddOutputMessage( ">>", processName, userID );

                fixfolders = false;
               
                if (i==1)
                    fixfolders = true;

                var response = GenerateSingleDocument( docuid, isRestart, fixfolders );

                // Read Local config to check if it has to stop
                //
                stopGeneration = XmlConfig.ReadLocal( MakConstant.ConfigXml.StopGeneration );
                if (stopGeneration=="Y")
                {
                    if ( uioutput != null ) uioutput.AddOutputMessage( "!!! Generation has stopped using config.", processName, userID );
                    break;
                }
            }
        }

        /// <summary>
        /// Generate single document
        /// </summary>
        /// <param name="clientDocumentUID"></param>
        public ResponseStatus GenerateSingleDocument( int clientDocumentUID, bool isRestart, bool fixDestinationFolder )
        {


            ResponseStatus response = new ResponseStatus(MessageType.Error);

            // Reporting activity to master
            //
            BUSFCMBackendStatus.ReportStatus( HeaderInfo.Instance, processName, "Generating document # " + clientDocumentUID.ToString() );

            // Read client document
            //
            var clientDocument = RepClientDocument.Read( clientDocumentUID );
            if ( clientDocument.UID == 0 )
            {
                LogFile.WriteToTodaysLogFile( "Client Document not found ID = 0", "DocumentGeneration.cs", processName );
                return new ResponseStatus( MessageType.Error )
                           {Message = "Client Document not found ID = 0", ReturnCode = -0040, ReasonCode = 0002};
            }

            if ( clientDocument.IsLocked == 'Y' )
            {
                LogFile.WriteToTodaysLogFile( "Document is locked. Client updates have been made.", processName );

                // Update file - set as GENERATED.
                //
                RepClientDocument.SetGeneratedFlagVersion( clientDocument, 'E', clientDocument.SourceIssueNumber, DateTime.Today.ToString( "yyyyMMdd" ) + " Document is locked." );

                return new ResponseStatus(MessageType.Warning)
                           {
                               Message = "Document is locked. Client updates have been made.",
                               ReturnCode = 0001,
                               ReasonCode = 0004
                           };
            }


            if (fixDestinationFolder)
            {
                // Fix path
                //
                uioutput.AddOutputMessage("Fixing destination folder...", "UI", Utils.UserID);
                //LogFile.WriteToTodaysLogFile("Fixing destination folder...", processName);
                var responseX = UpdateDestinationFolder(clientID, clientDocument.FKClientDocumentSetUID);
            }


            //
            // Update flag to FAILED... in case something happen before the end of the process
            //

            RepClientDocument.SetGeneratedFlagVersion( clientDocument, 'E', clientDocument.SourceIssueNumber, DateTime.Today.ToString( "yyyyMMdd" ) + " - Start:  " + " Generation has started." );

            // Retrieve latest version
            //
            var document = new Model.ModelDocument.Document();
            document.UID = clientDocument.FKDocumentUID;

            document = RepDocument.Read( false, clientDocument.FKDocumentUID );

            if ( document.UID <= 0 )
            {
                var responseerror = new ResponseStatus( MessageType.Error );
                responseerror.Message = "Document not found.";

                if ( uioutput != null ) uioutput.AddOutputMessage( responseerror.Message, processName: processName, userID: userID );

                return responseerror;
            }

            if ( document.Skip == "Y" )
            {
                var responseerror = new ResponseStatus( MessageType.Warning );
                responseerror.Message = "Skipping document "+ document.CUID + " - because of skip indicator. Contact support.";

                if ( uioutput != null ) uioutput.AddOutputMessage( responseerror.Message, processName: processName, userID: userID );
                return responseerror;
            }


            // It can't be skipped, it has to be copied.
            //
            //if ( document.SourceCode == "CLIENT" )
            //{
            //    var responseerror = new ResponseStatus( MessageType.Warning );
            //    responseerror.Message = "Skipping document " + document.CUID + " - because is is client specific.";

            //    if ( uioutput != null ) uioutput.AddOutputMessage( responseerror.Message, processName: processName, userID: userID );
            //    return responseerror;
            //}

            
            
            
            string msg = ">>> Generating file: " + document.UID + " === " + document.FileName;
            if ( uioutput != null ) uioutput.AddOutputMessage( msg, processName: processName, userID: userID );

            // Check if source version has changed
            //   If the source version has changed we need to physically delete the current file
            if ( document.IssueNumber != clientDocument.SourceIssueNumber )
            {
                // Delete client copy of document

                if ( uioutput != null ) uioutput.AddOutputMessage( "Version has changed " + document.SimpleFileName, processName: processName, userID: userID );
                if ( uioutput != null ) uioutput.AddOutputMessage( "Trying to delete current file. " + document.SimpleFileName, processName: processName, userID: userID );

                string currentClientFile = Utils.getFilePathName(
                           clientDocument.Location,
                           clientDocument.FileName );

                // Delete file
                try
                {
                    File.Delete( currentClientFile );

                }
                catch ( Exception )
                {
                    string errormessage = "Error deleting old version file or file not found." + currentClientFile;
                    if ( uioutput != null ) uioutput.AddOutputMessage( errormessage, processName: processName, userID: userID );
                    if ( uioutput != null ) uioutput.AddErrorMessage( errormessage, processName: processName, userID: userID );

                    if ( uioutput != null ) uioutput.AddOutputMessage( "Proceeding with generation...", processName: processName, userID: userID );

                    // Ok to proceed
                }
            }

            // ###############################################################

            if ( clientDocument.IsFolder == 'Y' || clientDocument.IsFolder == 'Y')
            {
                // Do not touch the name since it has been updated already.
                // Folders and Root shouldn't be touched
            }
            else
            {
                // Update client records with new file name
                //
                clientDocument.SourceFileName = document.FileName;

                // Set comboIssueNumber and File Name
                //
                RepClientDocument.SetClientDestinationFile(
                            clientDocument: clientDocument,
                            clientUID: clientDocument.FKClientUID,
                            documentCUID: document.CUID,
                            sourceVersionNumber: document.IssueNumber,
                            simpleFileName: document.SimpleFileName );

                //cd.UpdateSourceFileName();
                RepClientDocument.UpdateSourceFileName( clientDocument );
            }

            // ###############################################################

            // Locate source file
            //
            string sourceFileLocationName = Utils.getFilePathName(
                   clientDocument.SourceLocation,
                   clientDocument.SourceFileName );

            // Find the parent folder location
            //
            int parentUID = clientDocument.ParentUID;
            var cdParent = new ClientDocument();
            cdParent.UID = parentUID;
            // cdParent.Read();

            cdParent = RepClientDocument.Read( parentUID );

            // This is the client destination folder (and name)
            //
            //ResponseStatus destLocationDerivedClient = ClientDocument.GetDocumentPath(doco.clientDocument);
            //string destLocationDerived = destLocationDerivedClient.Contents.ToString();

            string clientDestinationFileLocation = clientDocument.Location.Trim();

            string clientDestinationFileLocationName = Utils.getFilePathName(
                clientDestinationFileLocation, clientDocument.FileName.Trim() );


            // This is the source client file name
            //
            string clientSourceFileLocation = clientDocument.Location.Trim();

            string clientSourceFileLocationName = Utils.getFilePathName(
                clientSourceFileLocation,
                clientDocument.FileName.Trim() );

            // Source location and destination may be different.
            // The destination of the file must be the one where it lives on the actual tree
            // To determine where the file should be located, we need to get the parent folder
            // The only way to determine the parent folder is walking through the entire tree from the root.
            // The root is the only thing that can be trusted. Every other location is dependent on the root.

            // The determination of the file location occurs in 2 parts. The one here is the second part.
            // At this point we are not going to use the source location of the original document, instead
            // we are going to use the client document location
            //

            // Check if destination folder directory exists
            //
            string PhysicalLocation = Utils.GetPathName( clientDestinationFileLocation );

            if ( string.IsNullOrEmpty( PhysicalLocation ) )
            {
                string er = "Location is empty " + clientDestinationFileLocation + "\n" +
                            "File Name: " + document.Name;

                if ( uioutput != null ) uioutput.AddOutputMessage( er, processName: processName, userID: userID );

                RepClientDocument.SetGeneratedFlagVersion( clientDocument, 'E', 0, DateTime.Today.ToString( "yyyyMMdd" ) + " - Error:  " + er );

                var responseerror = new ResponseStatus( MessageType.Error );
                responseerror.Message = er;
                return responseerror;
            }


            // 02/04/2011
            // This step should be done when the "FOLDER" record is created and not when the document
            // is generated
            //

            //if (!Directory.Exists( PhysicalLocation ))
            //    Directory.CreateDirectory( PhysicalLocation );


            // However the folder existence must be checked
            //
            if ( !Directory.Exists( PhysicalLocation ) )
            {
                Directory.CreateDirectory( PhysicalLocation );

                string er = "Destination folder has been created with File! " + PhysicalLocation + "\n" +
                "File Name: " + document.Name;

                if ( uioutput != null ) uioutput.AddOutputMessage( er, processName: processName, userID: userID );
                //return;
            }

            // In case of restart, do not override what has been generated.
            //

            if ( isRestart )
                overrideDocuments = "No";

            if ( File.Exists( clientDestinationFileLocationName ) )
            {
                // Proceed but report in list
                //
                if ( overrideDocuments == "Yes" )
                {
                    // Delete file
                    try
                    {
                        File.Delete( clientDestinationFileLocationName );

                    }
                    catch ( Exception )
                    {
                        if ( uioutput != null ) uioutput.AddOutputMessage( "Error deleting file " +
                                            document.SimpleFileName, processName: processName, userID: userID );
                        if ( uioutput != null ) uioutput.AddErrorMessage( "Error deleting file " +
                                            document.SimpleFileName, processName: processName, userID: userID );

                        var responseerror = new ResponseStatus( MessageType.Error );
                        responseerror.Message = "Error deleting file " + document.SimpleFileName;

                        RepClientDocument.SetGeneratedFlagVersion( clientDocument, 'E', 0, DateTime.Today.ToString( "yyyyMMdd" ) + " - Error:  " + responseerror.Message );

                        return responseerror;
                    }

                    if ( uioutput != null ) uioutput.AddOutputMessage( "File deleted... " +
                        document.SimpleFileName, processName: processName, userID: userID );

                
                }
                else
                {

                    var responseerror = new ResponseStatus( MessageType.Error ) { Message = "File already exists and it won't be replaced. " + document.SimpleFileName };

                    if ( uioutput != null ) uioutput.AddOutputMessage( responseerror.Message, processName: processName, userID: userID );

                    // Do not update the source issue number in this case
                    //
                    RepClientDocument.SetGeneratedFlagVersion( clientDocument, 'Y', clientDocument.SourceIssueNumber, DateTime.Today.ToString( "yyyyMMdd" ) + " - Warning:  " + responseerror.Message );

                    return responseerror;
                }
            }

            // Copy and fix file
            //

            if ( uioutput != null ) uioutput.AddOutputMessage( "Replacing variables... ", processName: processName, userID: userID );


            // Word Documents
            //
            if ( clientDocument.RecordType.Trim() == FCMConstant.RecordType.FOLDER )
            {
                // Update file - set as GENERATED.
                //

                // This is the moment where the folder destination has to be created
                // and the folder db record has to be updated with the location
                //

                if ( !Directory.Exists( PhysicalLocation ) )
                    Directory.CreateDirectory( PhysicalLocation );

                if ( uioutput != null ) uioutput.AddOutputMessage( "FOLDER: " + clientDocument.SourceFileName, processName: processName, userID: userID );
            }
            else
            {

                // If is is not a folder, it must be a regular file.
                // Trying to copy it as well...
                //

                var currentDocumentPath = Path.GetExtension( clientDocument.FileName );


                if ( document.SourceCode == "CLIENT" )
                {
                    // Copy only
                    //
                    File.Copy( sourceFileLocationName, clientSourceFileLocationName );

                    if ( uioutput != null )
                        uioutput.AddOutputMessage( "Client Specific - File copied but not modified: " +
                                                  Path.GetExtension( clientDocument.FileName ) + " == File: " +
                                                  clientSourceFileLocationName, processName, userID );

                }
                else
                {
                    if (clientDocument.DocumentType == MackkadoITFramework.Helper.Utils.DocumentType.WORD)
                    {
                        #region Word

                        // ------------------------------------------------------------------------
                        // ------------------------------------------------------------------------
                        // Generate Document and replace tag values in new document generated
                        // ------------------------------------------------------------------------
                        // ------------------------------------------------------------------------
                        var results = WordDocumentTasks.CopyDocument(sourceFileLocationName,
                                                                     clientSourceFileLocationName, listOfWordsToReplace,
                                                                     vkWordApp, uioutput, processName, userID);
                        if (results.ReturnCode < 0)
                        {
                            // Error has occurred
                            //
                            var er = (System.Exception) results.Contents;
                            if (uioutput != null)
                                uioutput.AddOutputMessage("ERROR: " + er.ToString(), processName, userID);
                            if (uioutput != null)
                                uioutput.AddErrorMessage("ERROR: " + er.ToString(), processName, userID);

                            var responseerror = new ResponseStatus(MessageType.Error)
                                                    {Message = "ERROR: " + er.ToString()};

                            RepClientDocument.SetGeneratedFlagVersion(clientDocument, 'E', 0,
                                                                      DateTime.Today.ToString("yyyyMMdd") +
                                                                      " - Error:  " + responseerror.Message);

                            return responseerror;

                        }

                        #endregion Word


                        // Generate Register of Systems Documents
                        //
                        if (document.CUID == "SRG-01")
                        {
                            WordReport wr = new WordReport(ClientID: clientDocument.FKClientUID,
                                                           ClientDocSetID: clientDocument.FKClientDocumentSetUID,
                                                           UIoutput: uioutput,
                                                           OverrideDocuments: overrideDocuments);

                            // List client document list
                            //
                            var documentSetList = new ClientDocument();
                            //documentSetList.List(Utils.ClientID, Utils.ClientSetID);

                            var cdlr = new BUSClientDocument.ClientDocumentListRequest();
                            cdlr.clientUID = clientDocument.FKClientUID;
                            cdlr.clientDocumentSetUID = clientDocument.FKClientDocumentSetUID;
                            var response2 = BUSClientDocument.List(cdlr);

                            documentSetList.clientDocSetDocLink = response2.clientList;

                            TreeView tvFileList = new TreeView();
                            BUSClientDocument.ListInTree(documentSetList, tvFileList, "CLIENT");

                            var location = Utils.GetPathName(clientDocument.Location);

                            var response3 = wr.RegisterOfSytemDocuments2(tvFileList, location, clientDocument.FileName,
                                                                         processName, userID);
                            uioutput.AddOutputMessage(response.Message, processName: processName, userID: userID);

                        }

                    }
                    else if (clientDocument.DocumentType == MackkadoITFramework.Helper.Utils.DocumentType.EXCEL)
                    {
                        // ------------------------------------------------------------------------
                        // ------------------------------------------------------------------------
                        // Generate Document and replace tag values in new document generated
                        // ------------------------------------------------------------------------
                        // ------------------------------------------------------------------------

                        ExcelSpreadsheetTasks.CopyDocument(sourceFileLocationName, clientSourceFileLocationName,
                                                           listOfWordsToReplace, uioutput, processName, userID);

                    }
                    else
                    {
                        File.Copy(sourceFileLocationName, clientSourceFileLocationName);

                        if (uioutput != null)
                            uioutput.AddOutputMessage("File copied but not modified: " +
                                                      Path.GetExtension(clientDocument.FileName) + " == File: " +
                                                      clientSourceFileLocationName, processName, userID);

                    }
                }
                //
                // Instantiate client document
                var cd = new ClientDocument();
                cd.UID = clientDocument.UID;

                // Update file - set as GENERATED.
                //
                RepClientDocument.SetGeneratedFlagVersion( clientDocument, 'Y', document.IssueNumber, DateTime.Today.ToString( "yyyyMMdd" ) + " All good." );

                if ( uioutput != null ) uioutput.AddOutputMessage( "Document generated: " + clientDestinationFileLocationName, processName, userID );
            }

            ResponseStatus responseSuccessfull = new ResponseStatus();
            responseSuccessfull.Message = "File generated successfully.";


            return responseSuccessfull;
        }


        /// <summary>
        /// Generate selected documents
        /// </summary>
        /// <param name="clientDocumentUIDList"></param>
        public void GenerateFullSetForClient( int clientID, int clientDocumentSetUID, bool isRestart )
        {

            var listOfClientDocs =  RepClientDocument.ListS(clientID, clientDocumentSetUID);

            List<int> listint = new List<int>();

            foreach (var doc in listOfClientDocs)
            {
                listint.Add(doc.clientDocument.UID);
            }

            // Fix path
            //
            var response = UpdateDestinationFolder( clientID, clientDocumentSetUID );

            GenerateGroupOfDocuments(listint, isRestart);

        }

    }
}

