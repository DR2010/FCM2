using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using FCMMySQLBusinessLibrary.FCMUtils;
using FCMMySQLBusinessLibrary.Model.ModelClient;
using FCMMySQLBusinessLibrary.Model.ModelClientDocument;
using FCMMySQLBusinessLibrary.Model.ModelMetadata;
using FCMMySQLBusinessLibrary.Repository.RepositoryClientDocument;
using FCMMySQLBusinessLibrary.Service.SVCClient.Contract;
using FCMMySQLBusinessLibrary.Service.SVCClient.Service;
using FCMMySQLBusinessLibrary.Service.SVCClient.ServiceContract;
using MackkadoITFramework.ErrorHandling;
using MackkadoITFramework.Interfaces;
using MackkadoITFramework.APIDocument;
using MackkadoITFramework.Utils;
using Word;
using Excel = Microsoft.Office.Interop.Excel;
using WordNet = Microsoft.Office.Interop.Word;
using Application = Microsoft.Office.Interop.Word.Application;
using System.IO;

namespace FCMMySQLBusinessLibrary
{

    public class WordReport
    {
        object oEndOfDoc = "\\endofdoc";
        private int clientID;
        private int clientDocSetID;
        private object vkFalse;
        private IOutputMessage uioutput;
        private Word.Application vkWordApp;
        private WordNet._Application oApplication;
        private Excel.Application vkExcelApp;
        private ReportMetadataList clientMetadata;
        private List<WordDocumentTasks.TagStructure> ts;
        private ClientDocumentSet cds;
        private double valueForProgressBar;
        private string startTime;
        public Client client;
        public string FileName;
        public string FullFileNamePath;

        int row;

        public WordReport(int ClientID, int ClientDocSetID, IOutputMessage UIoutput = null,
                                   string OverrideDocuments = null)
        {

            row = 1;

            // Set private attributes
            clientID = ClientID;
            clientDocSetID = ClientDocSetID;
            uioutput = UIoutput;

            // Instantiate Word
            //
            vkFalse = false;

            vkWordApp = new Word.Application();

            // Make it not visible
            vkWordApp.Visible = false;

            vkExcelApp = new Excel.Application();

            // Make it not visible
            vkExcelApp.Visible = false;

            // Make it not visible
            oApplication = new Application();
            oApplication.Visible = false;

            // Get Metadata for client

            clientMetadata = new ReportMetadataList();
            clientMetadata.ListMetadataForClient(clientID);

            ts = new List<WordDocumentTasks.TagStructure>();

            // Load variables/ metadata into memory
            //
            #region ClientMetadata
            foreach (ReportMetadata metadata in clientMetadata.reportMetadataList)
            {
                // Retrieve value for the field selected
                //
                string value = metadata.GetValue();

                // If the field is not enabled, the program has to replace the value with spaces.
                //
                var valueOfTag = metadata.Enabled == 'Y' ? value : string.Empty;

                // When the field is an image and it is not enable, do not include the "No image" icon in the list
                //
                if (metadata.InformationType == MackkadoITFramework.Helper.Utils.InformationType.IMAGE && metadata.Enabled == 'N')
                    continue;

                ts.Add(new WordDocumentTasks.TagStructure()
                {
                    TagType = metadata.InformationType,
                    Tag = metadata.FieldCode,
                    TagValue = valueOfTag
                });

            }
            #endregion ClientMetadata

            // Get Client Document Set Details 
            // To get the source and destination folders
            cds = new ClientDocumentSet();
            cds.Get(clientID, clientDocSetID);

            valueForProgressBar = 0;
            startTime = System.DateTime.Now.ToString();

            client = new Client();
            ClientReadRequest crr = new ClientReadRequest();
            crr.clientUID = clientID;
            var response = BUSClient.ClientRead(crr);

            client = response.client;

        }


        ~WordReport()
        {
            oApplication.Quit();
            vkWordApp.Quit( SaveChanges: ref vkFalse, OriginalFormat: ref vkFalse, RouteDocument: ref vkFalse );
            vkExcelApp.Quit();
        }


        /// <summary>
        /// Generate register of systems document using existing file.
        /// </summary>
        /// <param name="tv"></param>
        /// <param name="clientFolder"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public ResponseStatus RegisterOfSytemDocuments2( TreeView tv, string clientFolder, string fileName, string processName, string userID )
        {

            uioutput.AddOutputMessage( "Starting Register of Systems Documents generation...", processName, userID );
            uioutput.AddOutputMessage( clientFolder, processName, userID );
            uioutput.AddOutputMessage( fileName, processName, userID );

            ResponseStatus ret = new ResponseStatus();

            object oMissing = System.Reflection.Missing.Value;
            object vkMissing = System.Reflection.Missing.Value;
            object vkReadOnly = false;
            object vkVisiblefalse = false;
            object vkFalse = false;

            var pastPlannedActivities = string.Empty;

            //Start Word and open the document.
            //WordNet._Application oApplication = new Application { Visible = false };

            // string clientDestinationFileLocation = document.clientDocument.Location.Trim();
            string clientDestinationFileLocation = clientFolder;

            //string clientDestinationFileLocationName = Utils.getFilePathName(
            //    clientDestinationFileLocation, document.clientDocument.FileName.Trim() );

            string clientDestinationFileLocationName = Utils.getFilePathName( clientDestinationFileLocation, fileName.Trim() );

            object destinationFileName = clientDestinationFileLocationName;

            if ( !File.Exists( clientDestinationFileLocationName ) )
            {
                uioutput.AddOutputMessage( "File doesn't exist " + destinationFileName, processName: processName, userID: userID );
                uioutput.AddErrorMessage( "File doesn't exist " + destinationFileName, processName:processName, userID:userID );

                var responseerror = new ResponseStatus(MessageType.Error);

                responseerror.Message = "File doesn't exist " + destinationFileName;
                return responseerror;
            }

            WordNet._Document oDoc;
            try
            {
                uioutput.AddOutputMessage( "Opening document in Word... " + destinationFileName, processName:processName, userID:userID );

                oDoc = oApplication.Documents.Open(
                    ref destinationFileName, ref vkMissing, ref vkFalse,
                    ref vkMissing, ref vkMissing, ref vkMissing,
                    ref vkMissing, ref vkMissing, ref vkMissing,
                    ref vkMissing, ref vkMissing, ref vkVisiblefalse );

            }
            catch ( Exception ex )
            {

                var responseerror = new ResponseStatus( MessageType.Error );

                responseerror.ReturnCode = -1;
                responseerror.ReasonCode = 1000;
                responseerror.Message = "Error copying file.";
                responseerror.Contents = ex;
                return responseerror;
            }


            if ( oDoc.ReadOnly )
            {
                if ( uioutput != null ) uioutput.AddOutputMessage( "(Word) File is Read-only contact support:  " + destinationFileName, processName, userID );
                oDoc.Close();
                System.Runtime.InteropServices.Marshal.ReleaseComObject( oDoc );

                var responseerror = new ResponseStatus( MessageType.Error );
                responseerror.Message = "(Word) File is Read-only contact support:  " + destinationFileName;
                return responseerror;

            }

            try
            {
                if ( uioutput != null ) uioutput.AddOutputMessage( "Saving document in Word... " + destinationFileName, processName, userID );
                oDoc.Save();
            }
            catch (Exception ex)
            {
                if ( uioutput != null ) uioutput.AddOutputMessage( "Error saving file " + clientDestinationFileLocationName, processName, userID );

                var responseerror = new ResponseStatus( MessageType.Error );
                responseerror.Message = "Error saving file " + clientDestinationFileLocationName;
                return responseerror;
            }

            string msg = ">>> Opening file... " + destinationFileName;
            if ( uioutput != null ) uioutput.AddOutputMessage( msg, processName, userID );

            PrintToWord( oDoc, " ", 8, 1 );

            WordNet.Range wrdRng;
            WordNet.Table oTable;

            wrdRng = oDoc.Bookmarks.get_Item( oEndOfDoc ).Range;
            int rowCount = 30;


            // Get number of rows for a client document, client document set
            //
            // var cds = new BUSClientDocumentSet( Utils.ClientID, Utils.ClientSetID XXXXXXXXXXXXXXX );
            var cds = new BUSClientDocumentSet( clientID, clientDocSetID );
            rowCount = cds.DocumentCount;

            if ( rowCount < 1 )
                return new ResponseStatus( MessageType.Error );

            oTable = oDoc.Tables.Add( wrdRng, rowCount, 8, ref vkFalse, ref vkFalse );
            oTable.Borders.OutsideColor = WordNet.WdColor.wdColorBlack;
            oTable.Borders.InsideLineStyle = WordNet.WdLineStyle.wdLineStyleDouble;
            oTable.Borders.OutsideColor = WordNet.WdColor.wdColorBlueGray;
            oTable.Borders.OutsideLineStyle = WordNet.WdLineStyle.wdLineStyleEmboss3D;

            oTable.Rows [1].HeadingFormat = -1;

            WordNet.Row headingRow = oTable.Rows [1];

            ApplyHeadingStyle( headingRow.Cells [1], 200 );
            headingRow.Cells [1].Range.Text = "Directory";

            ApplyHeadingStyle( headingRow.Cells [2], 60 );
            headingRow.Cells [2].Range.Text = "Sub Directory";

            ApplyHeadingStyle( headingRow.Cells [3], 80 );
            headingRow.Cells [3].Range.Text = "Document Number";

            ApplyHeadingStyle( headingRow.Cells [4], 30 );
            headingRow.Cells [4].Range.Text = "Sml";
            ApplyHeadingStyle( headingRow.Cells [5], 40 );
            headingRow.Cells [5].Range.Text = "Med";
            ApplyHeadingStyle( headingRow.Cells [6], 30 );
            headingRow.Cells [6].Range.Text = "Lrg";

            ApplyHeadingStyle( headingRow.Cells [7], 50 );
            headingRow.Cells [7].Range.Text = "Version";

            ApplyHeadingStyle( headingRow.Cells [8], 200 );
            headingRow.Cells [8].Range.Text = "Document Name";

            int line = 0;
            foreach ( var treeNode in tv.Nodes )
            {
                line++;
                WriteLineToRoSD( tv.Nodes [0], oDoc, oTable, prefix: "", parent: "", seqnum: line );
            }

            msg = ">>> End ";
            if ( uioutput != null ) uioutput.AddOutputMessage( msg, processName, userID );

            PrintToWord( oDoc, " ", 12, 1 );

            try
            {
                oDoc.Save();
            }
            catch ( Exception ex )
            {
                if ( uioutput != null ) uioutput.AddOutputMessage( "Error saving file again... " + clientDestinationFileLocationName, processName, userID );

                var responseerror = new ResponseStatus( MessageType.Error );
                responseerror.Message = "Error saving file again... " + clientDestinationFileLocationName;
                return responseerror;
            }

            oDoc.Close();

            ResponseStatus goodresponse = new ResponseStatus(MessageType.Informational);
            goodresponse.Message = "Document SRG-01 generated successfully.";
            return goodresponse;
        }

        private void WriteLineToRoSD(TreeNode tn, WordNet._Document oDoc, WordNet.Table oTable, string prefix="", string parent="", int seqnum=0)
        {
            if (tn.Tag == null || tn.Tag.GetType().Name != "scClientDocSetDocLink") 
            {
                // still need to check subnodes
            }
            else
            {

                int x = 0;
                foreach (TreeNode node in tn.Nodes)
                {
                    x++;
                    row++;

                    scClientDocSetDocLink documentClient = (scClientDocSetDocLink)node.Tag;

                    string currentParent = "";
                    if ( string.IsNullOrEmpty( parent ) )
                    {
                        currentParent = x.ToString();
                    }
                    else
                    {
                        currentParent = parent + "." + x.ToString();
                    }

                    // First column

                    oTable.Cell( row, 1 ).Width = 200;
                    if (documentClient.document.RecordType == "FOLDER")
                        oTable.Cell( row, 1 ).Range.Text = documentClient.document.Name;
                    else
                        oTable.Cell( row, 1 ).Range.Text = "";

                    oTable.Cell( row, 2 ).Width = 60;
                    oTable.Cell( row, 2 ).Range.Text = ""; // Sub Directory

                    oTable.Cell( row, 3 ).Width = 80;
                    if ( documentClient.document.RecordType == "DOCUMENT" )
                        oTable.Cell( row, 3 ).Range.Text = prefix + documentClient.document.CUID;
                    else
                        oTable.Cell( row, 3 ).Range.Text = "";

                    oTable.Cell( row, 4 ).Width = 30;
                    oTable.Cell( row, 4 ).Range.Text = ""; // Sml
                    oTable.Cell( row, 5 ).Width = 40;
                    oTable.Cell( row, 5 ).Range.Text = ""; // Med
                    oTable.Cell( row, 6 ).Width = 30;
                    oTable.Cell( row, 6 ).Range.Text = ""; // Lrg

                    oTable.Cell(row, 7).Width = 50;
                    if ( documentClient.document.RecordType == "DOCUMENT" )
                        oTable.Cell( row, 7 ).Range.Text = prefix + documentClient.document.IssueNumber.ToString( "000" );
                    else
                        oTable.Cell( row, 7 ).Range.Text = "";

                    oTable.Cell( row, 8 ).Width = 200;
                    if ( documentClient.document.RecordType == "DOCUMENT" )
                        oTable.Cell(row, 8).Range.Text = prefix + documentClient.document.SimpleFileName;
                    else
                        oTable.Cell( row, 8 ).Range.Text = "";

                    if ( uioutput != null ) uioutput.AddOutputMessage( documentClient.document.Name, "", "");

                    if ( node.Nodes.Count > 0 )
                        WriteLineToRoSD( node, oDoc, oTable, prefix: "", parent: currentParent, seqnum: x );
                }
            }
        }


        private void WriteLineToRoSDOld( TreeNode tn, WordNet._Document oDoc, WordNet.Table oTable, string prefix = "", string parent = "", int seqnum = 0 )
        {
            if ( tn.Tag == null || tn.Tag.GetType().Name != "scClientDocSetDocLink" )
            {
                // still need to check subnodes
            }
            else
            {

                int x = 0;
                foreach ( TreeNode node in tn.Nodes )
                {
                    x++;
                    row++;

                    scClientDocSetDocLink documentClient = (scClientDocSetDocLink) node.Tag;

                    // First column

                    string currentParent = "";
                    if ( string.IsNullOrEmpty( parent ) )
                    {
                        currentParent = x.ToString();
                    }
                    else
                    {
                        currentParent = parent + "." + x.ToString();
                    }

                    oTable.Cell( row, 1 ).Width = 30;
                    oTable.Cell( row, 1 ).Range.Text = currentParent;

                    oTable.Cell( row, 2 ).Width = 30;

                    System.Drawing.Bitmap bitmap1 = Properties.Resources.FolderIcon;

                    if ( documentClient.document.RecordType.Trim() == FCMConstant.RecordType.FOLDER )
                    {
                        bitmap1 = Properties.Resources.FolderIcon;
                    }
                    else
                    {
                        bitmap1 = Properties.Resources.WordIcon;

                        if ( documentClient.document.DocumentType == MackkadoITFramework.Helper.Utils.DocumentType.EXCEL )
                            bitmap1 = Properties.Resources.ExcelIcon;

                        if ( documentClient.document.DocumentType == MackkadoITFramework.Helper.Utils.DocumentType.PDF )
                            bitmap1 = Properties.Resources.PDFIcon;

                    }

                    Clipboard.SetImage( bitmap1 );
                    oTable.Cell( row, 2 ).Range.Paste();


                    oTable.Cell( row, 3 ).Width = 60;
                    oTable.Cell( row, 3 ).Range.Text = prefix + documentClient.document.CUID;

                    oTable.Cell( row, 4 ).Width = 50;
                    oTable.Cell( row, 4 ).Range.Text = prefix + documentClient.document.IssueNumber.ToString( "000" );

                    oTable.Cell( row, 5 ).Width = 300;
                    oTable.Cell( row, 5 ).Range.Text = prefix + documentClient.document.Name;

                    oTable.Cell( row, 6 ).Width = 100;
                    oTable.Cell( row, 6 ).Range.Text = "???";

                    if ( uioutput != null ) uioutput.AddOutputMessage( documentClient.document.Name, "", "");

                    if ( node.Nodes.Count > 0 )
                        WriteLineToRoSD( node, oDoc, oTable, prefix: "", parent: currentParent, seqnum: x );

                }
            }
        }


        private static void ApplyHeadingStyle(WordNet.Cell cell, int width = 300)
        {
            cell.Width = width;
            
            cell.Range.Font.Name = "Arial";
            cell.Range.Font.Size = 10;
            cell.Range.Font.Bold = 1;

        }
        private static void ApplyContentsStyle(WordNet.Cell cell, WordNet.WdCellVerticalAlignment verticalAlignment = WordNet.WdCellVerticalAlignment.wdCellAlignVerticalCenter)
        {
            cell.VerticalAlignment = verticalAlignment;
            cell.Range.Font.Name = "Arial";
            cell.Range.Font.Size = 8;
            cell.Range.Font.Bold = 0;
        }


        private void PrintToWord(WordNet._Document oDoc, string toPrint, int fontSize, int bold,
                                 string align = FCMWordAlign.LEFT)
        {
            WordNet.WdParagraphAlignment walign = WordNet.WdParagraphAlignment.wdAlignParagraphLeft;

            if (align == FCMWordAlign.CENTER)
                walign = WordNet.WdParagraphAlignment.wdAlignParagraphCenter;
            if (align == FCMWordAlign.RIGHT)
                walign = WordNet.WdParagraphAlignment.wdAlignParagraphRight;

            object oRng =
                   oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            WordNet.Paragraph oPara = oDoc.Content.Paragraphs.Add(ref oRng);
            oPara.Range.Font.Name = "Arial";
            oPara.Range.Font.Bold = bold;
            oPara.Range.Font.Size = fontSize;
            oPara.Range.Text = toPrint;
            oPara.Range.InsertParagraphAfter();
            oPara.Alignment = walign;

        }

        private struct FCMWordAlign
        {
            public const string LEFT = "LEFT";
            public const string RIGHT = "RIGHT";
            public const string CENTER = "CENTER";
        }



        /// <summary>
        /// Generate word document with register of system documents
        /// </summary>
        /// <param name="tv"></param>
        public string RegisterOfSytemDocumentsXXX( TreeView tv, string clientFolder, string clientName, string processName , string userID)
        {
            object oMissing = System.Reflection.Missing.Value;
            var pastPlannedActivities = string.Empty;

            //Start Word and create a new document.
            WordNet._Application oWord = new Application { Visible = false };
            WordNet._Document oDoc = oWord.Documents.Add( ref oMissing, ref oMissing,
                                                 ref oMissing, ref oMissing );

            oDoc.PageSetup.Orientation = WordNet.WdOrientation.wdOrientLandscape;

            //PrintToWord(oDoc, "Register of System Documents", 16, 0, FCMWordAlign.CENTER);
            //PrintToWord(oDoc, " ", 8, 0);

            // Locate client folder
            //
            string clientFileLocationName = Utils.getFilePathName( @"%TEMPLATEFOLDER%\ClientSource\", "ROS-001 Register Of System Documents.doc");
            FullFileNamePath = clientFileLocationName;
            FileName = "RegisterOfSystemDocuments.doc";

            if ( File.Exists( clientFileLocationName ) )
            {
                // Delete file
                try
                {
                    File.Delete( clientFileLocationName );
                    uioutput.AddOutputMessage( "File replaced: " + clientFileLocationName, processName: processName, userID: userID );
                }
                catch ( Exception )
                {
                    uioutput.AddOutputMessage( "Error deleting file " + clientFileLocationName, processName: processName, userID: userID );
                    uioutput.AddErrorMessage( "Error deleting file " + clientFileLocationName, processName: processName, userID: userID );
                    return clientFileLocationName;
                }
            }


            // string filename = Path.Combine(Path.GetTempPath(), Path.ChangeExtension(Path.GetTempFileName(), "doc"));
            oDoc.SaveAs( clientFileLocationName );

            string msg = ">>> Generating file... ";
            if ( uioutput != null ) uioutput.AddOutputMessage( msg, processName: processName, userID: userID );

            PrintToWord( oDoc, " ", 8, 1 );

            WordNet.Range wrdRng;
            WordNet.Table oTable;

            wrdRng = oDoc.Bookmarks.get_Item( oEndOfDoc ).Range;
            int rowCount = 30;

            foreach ( Section wordSection in oDoc.Sections )
            {
                HeaderFooter footer = wordSection.Footers.Item( Word.WdHeaderFooterIndex.wdHeaderFooterPrimary );
                footer.Range.Select();
                footer.Range.Text = FullFileNamePath;
                footer.PageNumbers.Add();

                HeaderFooter header = wordSection.Headers.Item( Word.WdHeaderFooterIndex.wdHeaderFooterPrimary );
                header.Range.Select();
                //header.Range.Text = client.Name + "      Register of System Documents  " ;
                header.Range.Font.Size = 20;
                header.Range.Cells.Add( client.Name );
                header.Range.Cells.Add( "Register of System Documents" );

                oWord.Selection.Paragraphs [1].Alignment = WordNet.WdParagraphAlignment.wdAlignParagraphLeft;

            }



            // Get number of rows for a client document, client document set
            //
            var cds = new BUSClientDocumentSet( Utils.ClientID, Utils.ClientSetID );
            rowCount = cds.DocumentCount;

            if ( rowCount < 1 )
                return clientFileLocationName;

            oTable = oDoc.Tables.Add( wrdRng, rowCount, 8, ref vkFalse, ref vkFalse );
            oTable.Borders.OutsideColor = WordNet.WdColor.wdColorBlack;
            oTable.Borders.InsideLineStyle = WordNet.WdLineStyle.wdLineStyleDouble;
            oTable.Borders.OutsideColor = WordNet.WdColor.wdColorBlueGray;
            oTable.Borders.OutsideLineStyle = WordNet.WdLineStyle.wdLineStyleEmboss3D;

            //oTable.Borders.InsideLineWidth = WordNet.WdLineWidth.wdLineWidth050pt;
            //oTable.Borders.OutsideLineWidth = WordNet.WdLineWidth.wdLineWidth025pt;

            //oTable.Borders.InsideColor = WordNet.WdColor.wdColorAutomatic;
            //oTable.Borders.OutsideColor = WordNet.WdColor.wdColorAutomatic;

            oTable.Rows [1].HeadingFormat = -1;

            WordNet.Row headingRow = oTable.Rows [1];

            ApplyHeadingStyle( headingRow.Cells [1], 200 );
            headingRow.Cells [1].Range.Text = "Directory";

            ApplyHeadingStyle( headingRow.Cells [2], 60 );
            headingRow.Cells [2].Range.Text = "Sub Directory";

            ApplyHeadingStyle( headingRow.Cells [3], 80 );
            headingRow.Cells [3].Range.Text = "Document Number";

            ApplyHeadingStyle( headingRow.Cells [4], 30 );
            headingRow.Cells [4].Range.Text = "Sml";
            ApplyHeadingStyle( headingRow.Cells [5], 40 );
            headingRow.Cells [5].Range.Text = "Med";
            ApplyHeadingStyle( headingRow.Cells [6], 30 );
            headingRow.Cells [6].Range.Text = "Lrg";

            ApplyHeadingStyle( headingRow.Cells [7], 50 );
            headingRow.Cells [7].Range.Text = "Version";

            ApplyHeadingStyle( headingRow.Cells [8], 200 );
            headingRow.Cells [8].Range.Text = "Document Name";

            int line = 0;
            foreach ( var treeNode in tv.Nodes )
            {
                line++;
                WriteLineToRoSD( tv.Nodes [0], oDoc, oTable, prefix: "", parent: "", seqnum: line );
            }


            msg = ">>> End ";
            if ( uioutput != null ) uioutput.AddOutputMessage( msg, processName, userID );

            PrintToWord( oDoc, " ", 12, 1 );

            oDoc.Save();
            oDoc.Close();

            oWord.Visible = true;
            oWord.Documents.Open( FileName: clientFileLocationName );
            oWord.Activate();

            return clientFileLocationName;

        }

    }
}
