using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using FCMMySQLBusinessLibrary.Repository.RepositoryDocument;
using MackkadoITFramework.APIDocument;
using MackkadoITFramework.ReferenceData;
using MakUtils = MackkadoITFramework.Utils;
using MackkadoITFramework.ErrorHandling;
using MackkadoITFramework.Interfaces;
using MakHelperUtils = MackkadoITFramework.Helper.Utils;
using MackkadoITFramework.Utils;
using MackkadoITFramework.ErrorHandling;
using MackkadoITFramework.APIDocument;
using FCMUtils = FCMMySQLBusinessLibrary.FCMUtils.Utils;
using FCMMySQLBusinessLibrary.Model.ModelClient;


namespace FCMMySQLBusinessLibrary.FCMUtils
{
    public static class Utils
    {
        public static ImageList imageList;
        
        private static string userID;
        private static int clientID;
        private static int clientSetID;
        private static string clientSetText;
        private static string clientName;
        private static List<Client> clientList;
        private static int clientIndex;
        private static int imageLogoStartsFrom;
        // private static string fcmenvironment;
        private static UserSettings _UserSettingsCache;
        public static DateTime MinDate
        {
            get
            {
                return new DateTime(1901, 01, 01);
            }
        }
        public static UserSettings UserSettingsCache
        {
            set { _UserSettingsCache = value; }
            get { return _UserSettingsCache; }
        }

        /// <summary>
        /// Read or Write the userID in memory.
        /// </summary>
        public static string UserID
        {
            set 
            { 
                userID = value;

                // Save last user id to database
                CodeValue cv = new CodeValue();
                cv.FKCodeType = "LASTINFO";
                cv.ID = "USERID";
                cv.Read(false);
                cv.ValueExtended = Utils.UserID;

                cv.Save();
            }
    
            get { return userID; }
        }

        public static string ClientSetText
        {
            set { clientSetText = value; }
            get { return clientSetText; }
        }

        public static int ClientID
        {
            set { 
                clientID = value;

                // Save last user id to database
                CodeValue cv = new CodeValue();
                cv.FKCodeType = "LASTINFO";
                cv.ID = "CLIENTID";
                cv.Read(false);
                cv.ValueExtended = Utils.ClientID.ToString();
                cv.Save();

                if (clientList == null)
                    return;

                int c=0;
                foreach (var client in clientList)
                {
                    if (client.UID == clientID)
                    {
                        Utils.clientIndex = c;
                        break;
                    }
                    c++;
                }

            }
            get { return clientID; }
        }
        public static int ClientSetID
        {
            set { clientSetID = value; }
            get { return clientSetID; }
        }
        public static int ClientIndex
        {
            // set { clientIndex = value; }
            get { return clientIndex; }
        }
        public static string ClientName
        {
            set { clientName = value; }
            get { return clientName; }
        }

        public static int ImageLogoStartsFrom
        {
            set { imageLogoStartsFrom = value; }
            get { return imageLogoStartsFrom; }
        }

        public static List<Client> ClientList
        {
            set { clientList = value; }
            get { return clientList; }
        }

        public static string FCMenvironment { get; set; }

        // Print document for Location and Name
        //
        public static void PrintDocument( string Location, string Name, string Type )
        {
            if (Type == MackkadoITFramework.Helper.Utils.DocumentType.WORD)
            {
                string filePathName =
                    Utils.getFilePathName( Location, Name );

                WordDocumentTasks.PrintDocument( filePathName );
            }

            if (Type == MackkadoITFramework.Helper.Utils.DocumentType.EXCEL)
            {
                string filePathName =
                    Utils.getFilePathName( Location, Name );

                var Response = ExcelSpreadsheetTasks.PrintDocument( filePathName );
                if (Response.ReturnCode < 1)
                {
                    MessageBox.Show( Response.Message );
                }
            }
            if (Type == MackkadoITFramework.Helper.Utils.DocumentType.PDF)
            {
                string filePathName =
                    Utils.getFilePathName( Location, Name );
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                var adobe = CodeValue.GetCodeValueExtended( iCodeType: FCMConstant.CodeTypeString.SYSTSET, iCodeValueID: "PDFEXEPATH" );

                if (!File.Exists( adobe ))
                {
                    MessageBox.Show( "I can't find Adobe Reader. Please configure SYSTSET.PDFEXTPATH." );
                    return;
                }

                proc.StartInfo.FileName = adobe ;
                // Print PDF
                proc.StartInfo.Arguments = " /h /p "+ filePathName;
                proc.Start();


            }

        }


        /// <summary>
        /// Compare documents  
        /// </summary>
        /// <param name="Location"></param>
        /// <param name="Name"></param>
        /// <param name="Type"></param>
        /// <param name="DestinationFile"></param>
        public static void CompareDocuments(
            string Source, 
            string Destination, 
            string Type)
        {
            if (Type == MackkadoITFramework.Helper.Utils.DocumentType.WORD)
            {

                WordDocumentTasks.CompareDocuments(Source, Destination);
            }

        }


        // It transforms the reference path into a physical path and add name to it
        //
        public static string getFilePathName( string path, string name )
        {
            string filePathName = path + "\\" + name;
            string fullPathFileName = "";

            var fcmPort = CodeValue.GetCodeValueExtended(FCMConstant.CodeTypeString.SYSTSET, MackkadoITFramework.Helper.Utils.SYSTSET.WEBPORT);
            var fcmHost = CodeValue.GetCodeValueExtended(FCMConstant.CodeTypeString.SYSTSET, MackkadoITFramework.Helper.Utils.SYSTSET.HOSTIPADDRESS);

            // Get template folder 
            var templateFolder =
                CodeValue.GetCodeValueExtended("SYSTSET", FCMConstant.SYSFOLDER.TEMPLATEFOLDER);

            // Get template folder 
            var clientFolder =
                CodeValue.GetCodeValueExtended("SYSTSET", FCMConstant.SYSFOLDER.CLIENTFOLDER);

            // Get version folder 
            var versionFolder =
                CodeValue.GetCodeValueExtended(FCMConstant.CodeTypeString.SYSTSET, FCMConstant.SYSFOLDER.VERSIONFOLDER);

            // Get logo folder 
            var logoFolder =
                CodeValue.GetCodeValueExtended( FCMConstant.CodeTypeString.SYSTSET, FCMConstant.SYSFOLDER.LOGOFOLDER);

            // Get log file folder 
            var logFileFolder =
                CodeValue.GetCodeValueExtended( FCMConstant.CodeTypeString.SYSTSET, FCMConstant.SYSFOLDER.LOGFILEFOLDER);



            // WEB

            if (Utils.FCMenvironment == MackkadoITFramework.Helper.Utils.EnvironmentList.WEB)
            {
                string rpath = path.Replace(@"\", @"/");
                path = rpath;

                // Different for WEB
                filePathName = path + @"/" + name;

                // ----------------------
                // Get WEB template folder 
                // ----------------------
                templateFolder =
                CodeValue.GetCodeValueExtended( FCMConstant.CodeTypeString.SYSTSET, FCMConstant.SYSFOLDER.WEBTEMPLATEFOLDER );

                templateFolder = templateFolder.Replace(MackkadoITFramework.Helper.Utils.SYSTSET.WEBPORT, fcmPort);
                templateFolder = templateFolder.Replace(MackkadoITFramework.Helper.Utils.SYSTSET.HOSTIPADDRESS, fcmHost);

                // ----------------------
                // Get WEB client folder 
                // ----------------------
                clientFolder =
                CodeValue.GetCodeValueExtended( FCMConstant.CodeTypeString.SYSTSET, FCMConstant.SYSFOLDER.WEBCLIENTFOLDER );

                clientFolder = clientFolder.Replace(MackkadoITFramework.Helper.Utils.SYSTSET.WEBPORT, fcmPort);
                clientFolder = clientFolder.Replace(MackkadoITFramework.Helper.Utils.SYSTSET.HOSTIPADDRESS, fcmHost);

                // ----------------------
                // Get WEB version folder 
                // ----------------------
                versionFolder =
                CodeValue.GetCodeValueExtended( FCMConstant.CodeTypeString.SYSTSET, FCMConstant.SYSFOLDER.WEBVERSIONFOLDER );

                versionFolder = versionFolder.Replace( MackkadoITFramework.Helper.Utils.SYSTSET.WEBPORT, fcmPort );
                versionFolder = versionFolder.Replace(MackkadoITFramework.Helper.Utils.SYSTSET.HOSTIPADDRESS, fcmHost);

                // ----------------------
                // Get WEB logo folder 
                // ----------------------
                logoFolder =
                CodeValue.GetCodeValueExtended( FCMConstant.CodeTypeString.SYSTSET, FCMConstant.SYSFOLDER.WEBLOGOFOLDER );

                logoFolder = logoFolder.Replace(MackkadoITFramework.Helper.Utils.SYSTSET.WEBPORT, fcmPort);
                logoFolder = logoFolder.Replace(MackkadoITFramework.Helper.Utils.SYSTSET.HOSTIPADDRESS, fcmHost);

                // --------------------------------------------------------------
                // Get WEB LOG folder - This is LOG for recording what happened
                // --------------------------------------------------------------
                logFileFolder =
                CodeValue.GetCodeValueExtended(FCMConstant.CodeTypeString.SYSTSET, FCMConstant.SYSFOLDER.LOGFILEFOLDER);

                logFileFolder = logFileFolder.Replace(MackkadoITFramework.Helper.Utils.SYSTSET.WEBPORT, fcmPort);
                logFileFolder = logFileFolder.Replace(MackkadoITFramework.Helper.Utils.SYSTSET.HOSTIPADDRESS, fcmHost);

            }

            if (filePathName.Contains(FCMConstant.SYSFOLDER.TEMPLATEFOLDER))
            {
                fullPathFileName =
                    filePathName.Replace( FCMConstant.SYSFOLDER.TEMPLATEFOLDER, templateFolder );
            }

            if (filePathName.Contains(FCMConstant.SYSFOLDER.CLIENTFOLDER))
            {
                fullPathFileName =
                    filePathName.Replace(FCMConstant.SYSFOLDER.CLIENTFOLDER, clientFolder);

            }

            if (filePathName.Contains(FCMConstant.SYSFOLDER.VERSIONFOLDER))
            {
                fullPathFileName =
                    filePathName.Replace(FCMConstant.SYSFOLDER.VERSIONFOLDER, versionFolder);

            }

            if (filePathName.Contains( FCMConstant.SYSFOLDER.LOGOFOLDER))
            {
                fullPathFileName =
                    filePathName.Replace( FCMConstant.SYSFOLDER.LOGOFOLDER, logoFolder);

            }

            if (filePathName.Contains(FCMConstant.SYSFOLDER.LOGFILEFOLDER))
            {
                fullPathFileName =
                    filePathName.Replace(FCMConstant.SYSFOLDER.LOGFILEFOLDER, logFileFolder);
            }

            if (string.IsNullOrEmpty(fullPathFileName))
                fullPathFileName = path + "\\" + name;

            fullPathFileName = fullPathFileName.Replace("\r", "");

            return fullPathFileName;
        }

        // It transforms the reference path into a physical path and add name to it
        //
        public static string GetPathName(string path)
        {
            string filePathName = path;
            string fullPathFileName = "";

            // Get template folder 
            var templateFolder =
                CodeValue.GetCodeValueExtended(FCMConstant.CodeTypeString.SYSTSET, FCMConstant.SYSFOLDER.TEMPLATEFOLDER);

            // Get main client folder 
            var clientFolder =
                CodeValue.GetCodeValueExtended(FCMConstant.CodeTypeString.SYSTSET, FCMConstant.SYSFOLDER.CLIENTFOLDER);

            // Get version folder 
            var versionFolder  =
                CodeValue.GetCodeValueExtended(FCMConstant.CodeTypeString.SYSTSET, FCMConstant.SYSFOLDER.VERSIONFOLDER);

            // Get logo folder 
            var logoFolder =
                CodeValue.GetCodeValueExtended(FCMConstant.CodeTypeString.SYSTSET, FCMConstant.SYSFOLDER.LOGOFOLDER);

            if (filePathName.Contains(FCMConstant.SYSFOLDER.TEMPLATEFOLDER))
            {
                fullPathFileName =
                    filePathName.Replace(FCMConstant.SYSFOLDER.TEMPLATEFOLDER, templateFolder);

            }

            if (filePathName.Contains(FCMConstant.SYSFOLDER.CLIENTFOLDER))
            {
                fullPathFileName =
                    filePathName.Replace(FCMConstant.SYSFOLDER.CLIENTFOLDER, clientFolder);

            }

            if (filePathName.Contains(FCMConstant.SYSFOLDER.VERSIONFOLDER))
            {
                fullPathFileName =
                    filePathName.Replace(FCMConstant.SYSFOLDER.VERSIONFOLDER, versionFolder);

            }

            if (filePathName.Contains(FCMConstant.SYSFOLDER.LOGOFOLDER))
            {
                fullPathFileName =
                    filePathName.Replace(FCMConstant.SYSFOLDER.LOGOFOLDER, logoFolder);
            }

            return fullPathFileName;
        }


        //
        // It returns a reference path 
        //
        public static string getReferenceFilePathName(string path)
        {
            string filePathName = path;
            string referencePathFileName = "";

            // Get template folder 
            var templateFolder =
                CodeValue.GetCodeValueExtended(FCMConstant.CodeTypeString.SYSTSET, FCMConstant.SYSFOLDER.TEMPLATEFOLDER);

            // Get template folder 
            var clientFolder =
                CodeValue.GetCodeValueExtended(FCMConstant.CodeTypeString.SYSTSET, FCMConstant.SYSFOLDER.CLIENTFOLDER);

            if (filePathName.Contains(templateFolder))
            {
                referencePathFileName =
                    filePathName.Replace(templateFolder, FCMConstant.SYSFOLDER.TEMPLATEFOLDER);

            }

            if (filePathName.Contains(clientFolder))
            {
                referencePathFileName =
                    filePathName.Replace(clientFolder, FCMConstant.SYSFOLDER.CLIENTFOLDER);

            }

            if (string.IsNullOrEmpty(referencePathFileName))
                referencePathFileName = path;

            return referencePathFileName;
        }

        /// <summary>
        /// It returns the opposite path (client to template or vice-versa) 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string getOppositePath(string path)
        {
            string filePathName = path;
            string opposite = "";

            if (filePathName.Contains(FCMConstant.SYSFOLDER.TEMPLATEFOLDER))
            {
                opposite =
                    filePathName.Replace(FCMConstant.SYSFOLDER.TEMPLATEFOLDER, 
                    FCMConstant.SYSFOLDER.CLIENTFOLDER);

            }

            if (filePathName.Contains(FCMConstant.SYSFOLDER.CLIENTFOLDER))
            {
                opposite =
                    filePathName.Replace(FCMConstant.SYSFOLDER.CLIENTFOLDER, FCMConstant.SYSFOLDER.TEMPLATEFOLDER);

            }

            if (string.IsNullOrEmpty(opposite))
                opposite = path;

            return opposite;
        }

        /// <summary>
        /// It returns the path of the document inside the client path 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetClientPathInside(string path)
        {
            string filePathName = path;
            string opposite = "";

            if (filePathName.Contains(FCMConstant.SYSFOLDER.TEMPLATEFOLDER))
            {
                opposite =
                    filePathName.Replace(FCMConstant.SYSFOLDER.TEMPLATEFOLDER, "");

            }

            //if (string.IsNullOrEmpty(opposite))
            //    opposite = path;

            return opposite;
        }

        /// <summary>
        /// It returns the Client path 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="destinationPath"></param>
        /// <returns></returns>
        public static string GetClientPath(string path, string destinationPath)
        {
            string destination = "";
            string ultimateDestination = "";

            if (path.Contains(FCMConstant.SYSFOLDER.TEMPLATEFOLDER))
            {
                destination =
                    path.Replace(FCMConstant.SYSFOLDER.TEMPLATEFOLDER, FCMConstant.SYSFOLDER.CLIENTFOLDER);

            }

            // path = %TEMPLATEFOLDER%\\something\\
            // destinationPath = %CLIENTFOLDER%\\CLIENT01\\
            // destination = %CLIENTFOLDER%\\something\\
            // 

            // stripDestination = \\something\\
            string stripDestination = destination.Replace(FCMConstant.SYSFOLDER.CLIENTFOLDER, "");

            // ultimateDestination = \\Client01\\

            ultimateDestination = destinationPath.Replace(FCMConstant.SYSFOLDER.CLIENTFOLDER, "");
            ultimateDestination = FCMConstant.SYSFOLDER.CLIENTFOLDER +  // %CLIENTFOLDER%
                                  ultimateDestination + // \\client01\\
                                  stripDestination;     // \\something\\

            if (string.IsNullOrEmpty(ultimateDestination))
                ultimateDestination = path;

            return ultimateDestination;
        }

        /// <summary>
        /// It returns the Client path 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetVersionPath(string path)
        {
            string destination = path;

            if (path.Contains(FCMConstant.SYSFOLDER.TEMPLATEFOLDER))
            {
                destination =
                    path.Replace(FCMConstant.SYSFOLDER.TEMPLATEFOLDER, FCMConstant.SYSFOLDER.VERSIONFOLDER);

            }

            return destination;
        }


        /// <summary>
        /// Open document
        /// </summary>
        /// <param name="document"></param>
        /// <param name="vkReadOnly"></param>
        /// <param name="isFromWeb"></param>
        public static void OpenDocument(Model.ModelDocument.Document document, object vkReadOnly, bool isFromWeb)
        {
            if (document.DocumentType == MackkadoITFramework.Helper.Utils.DocumentType.WORD)
            {
                string filePathName =
                    Utils.getFilePathName(document.Location,
                                          document.Name );

                WordDocumentTasks.OpenDocument( filePathName, vkReadOnly, isFromWeb );
            }

        }

        // Open document for Location and Name
        //
        public static void OpenDocument(string Location, string Name, string Type, object vkReadOnly, bool isFromWeb = false)
        {
            if (Type == MackkadoITFramework.Helper.Utils.DocumentType.WORD)
            {
                string filePathName =
                    Utils.getFilePathName(Location,
                                          Name);

                WordDocumentTasks.OpenDocument( filePathName, vkReadOnly, isFromWeb );
            }

            if (Type == MackkadoITFramework.Helper.Utils.DocumentType.EXCEL)
            {
                string filePathName =
                    Utils.getFilePathName(Location,
                                          Name);

                var Response = ExcelSpreadsheetTasks.OpenDocument(filePathName);
                if (Response.ReturnCode < 1)
                {
                    MessageBox.Show(Response.Message);
                }
            }
            if (Type == MackkadoITFramework.Helper.Utils.DocumentType.PDF)
            {
                string filePathName =
                    Utils.getFilePathName( Location,
                                          Name );
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                var adobe = CodeValue.GetCodeValueExtended( iCodeType: FCMConstant.CodeTypeString.SYSTSET, iCodeValueID: "PDFEXEPATH" );

                if (!File.Exists( adobe ))
                {
                    MessageBox.Show( "I can't find Adobe Reader. Please configure SYSTSET.PDFEXTPATH." );
                    return;
                }

                proc.StartInfo.FileName = adobe;
                proc.StartInfo.Arguments = filePathName;
                proc.Start();
                    

            }

        }

        /// <summary>
        /// Return image according to Record Type 
        /// </summary>
        /// <param name="RecordType"></param>
        /// <returns></returns>
        public static int ImageSelect(string RecordType)
        {
            int image = FCMConstant.Image.Document;

            switch (RecordType)
            {
                case FCMConstant.RecordType.DOCUMENT:
                    image = FCMConstant.Image.Document;
                    break;
                case FCMConstant.RecordType.APPENDIX:
                    image = FCMConstant.Image.Document;
                    break;
                case FCMConstant.RecordType.FOLDER:
                    image = FCMConstant.Image.Folder;
                    break;
                default:
                    image = FCMConstant.Image.Document;
                    break;
            }

            return image;
        }


        /// <summary>
        /// Get Logo location for a client.
        /// </summary>
        /// <param name="clientUID"></param>
        /// <returns></returns>
        public static string GetImageUrl( string DocumentType, string curEnvironment = MackkadoITFramework.Helper.Utils.EnvironmentList.LOCAL )
        {

            string image = "";

            string logoPath = "";
            string logoName = "";
            string logoPathName = "";

            Utils.FCMenvironment = curEnvironment;


            switch (DocumentType)
            {
                case MackkadoITFramework.Helper.Utils.DocumentType.WORD:
                    logoName = FCMConstant.ImageFileName.Document;
                    break;

                case MackkadoITFramework.Helper.Utils.DocumentType.EXCEL:
                    logoName = FCMConstant.ImageFileName.Excel;
                    break;

                case MackkadoITFramework.Helper.Utils.DocumentType.FOLDER:
                    logoName = FCMConstant.ImageFileName.Folder;
                    break;

                case MackkadoITFramework.Helper.Utils.DocumentType.PDF:
                    logoName = FCMConstant.ImageFileName.PDF;
                    break;

                default:
                    logoName = FCMConstant.ImageFileName.Document;
                    break;
            }


            // Set no icon image if necessary
            //
            logoPath = FCMConstant.SYSFOLDER.LOGOFOLDER;
            logoName = logoName.Replace( FCMConstant.SYSFOLDER.LOGOFOLDER, string.Empty );
            
            logoPathName = Utils.getFilePathName( logoPath, logoName );

            return logoPathName;
        }

        /// <summary>
        /// Return sequence number of the client's logo from the image list
        /// </summary>
        /// <returns></returns>
        public static int GetClientLogoImageSeqNum(int clientUID)
        {
            int image = 0;

            foreach (var client in Utils.ClientList)
            {
                if (client.UID == clientUID)
                {
                    image = client.LogoImageSeqNum;
                    break;
                }
            }

            return image;

        }


        /// <summary>
        /// Get image for file
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public static int GetFileImage(char source, char destination, string documentType )
        {
            int image = FCMConstant.Image.WordFileSourceNoDestinationNo;

            if (source == 'Y')
            {
                if (destination == 'Y')
                {
                    // Source = "Y"; Destination = "Y"
                    switch (documentType)
                    {
                        case MackkadoITFramework.Helper.Utils.DocumentType.WORD:
                            image = FCMConstant.Image.WordFileSourceYesDestinationYes;
                            break;
                        case MackkadoITFramework.Helper.Utils.DocumentType.EXCEL:
                            image = FCMConstant.Image.ExcelFileSourceYesDestinationYes;
                            break;
                        case MackkadoITFramework.Helper.Utils.DocumentType.PDF:
                            image = FCMConstant.Image.PDFFileSourceYesDestinationYes;
                            break;
                        case MackkadoITFramework.Helper.Utils.DocumentType.FOLDER:
                            image = FCMConstant.Image.Folder;
                            break;
                        case MackkadoITFramework.Helper.Utils.DocumentType.APPENDIX:
                            image = FCMConstant.Image.Appendix;
                            break;
                    }
                }
                else
                {
                    // Source = "Y"; Destination = "N"
                    image = FCMConstant.Image.WordFileSourceYesDestinationNo;

                    switch (documentType)
                    {
                        case MackkadoITFramework.Helper.Utils.DocumentType.WORD:
                            image = FCMConstant.Image.WordFileSourceYesDestinationNo;
                            break;
                        case MackkadoITFramework.Helper.Utils.DocumentType.EXCEL:
                            image = FCMConstant.Image.ExcelFileSourceYesDestinationNo;
                            break;
                        case MackkadoITFramework.Helper.Utils.DocumentType.PDF:
                            image = FCMConstant.Image.PDFFileSourceYesDestinationNo;
                            break;
                        case MackkadoITFramework.Helper.Utils.DocumentType.FOLDER:
                            image = FCMConstant.Image.Folder;
                            break;
                        case MackkadoITFramework.Helper.Utils.DocumentType.APPENDIX:
                            image = FCMConstant.Image.Appendix;
                            break;
                    }

                }
            }
            else
            {
                if (destination == 'Y')
                {
                    // Source = "N"; Destination = "Y"
                    image = FCMConstant.Image.WordFileSourceNoDestinationYes;

                    switch (documentType)
                    {
                        case MackkadoITFramework.Helper.Utils.DocumentType.WORD:
                            image = FCMConstant.Image.WordFileSourceNoDestinationYes;
                            break;
                        case MackkadoITFramework.Helper.Utils.DocumentType.EXCEL:
                            image = FCMConstant.Image.ExcelFileSourceNoDestinationYes;
                            break;
                        case MackkadoITFramework.Helper.Utils.DocumentType.PDF:
                            image = FCMConstant.Image.PDFFileSourceNoDestinationYes;
                            break;
                        case MackkadoITFramework.Helper.Utils.DocumentType.FOLDER:
                            image = FCMConstant.Image.Folder;
                            break;
                        case MackkadoITFramework.Helper.Utils.DocumentType.APPENDIX:
                            image = FCMConstant.Image.Appendix;
                            break;
                    }

                }
                else
                {
                    // Source = "N"; Destination = "N"
                    image = FCMConstant.Image.WordFileSourceNoDestinationNo;

                    switch (documentType)
                    {
                        case MackkadoITFramework.Helper.Utils.DocumentType.WORD:
                            image = FCMConstant.Image.WordFileSourceNoDestinationNo;
                            break;
                        case MackkadoITFramework.Helper.Utils.DocumentType.EXCEL:
                            image = FCMConstant.Image.ExcelFileSourceNoDestinationNo;
                            break;
                        case MackkadoITFramework.Helper.Utils.DocumentType.PDF:
                            image = FCMConstant.Image.PDFFileSourceNoDestinationNo;
                            break;
                        case MackkadoITFramework.Helper.Utils.DocumentType.FOLDER:
                            image = FCMConstant.Image.Folder;
                            break;
                        case MackkadoITFramework.Helper.Utils.DocumentType.APPENDIX:
                            image = FCMConstant.Image.Appendix;
                            break;
                    }
                }
            }
            return image;
        }


        /// <summary>
        /// Retrieves cached value for user settings
        /// </summary>
        /// <returns></returns>
        public static string UserSettingGetCacheValue( UserSettings userSettings)
        {
            string valueReturned = "";

            if (Utils.UserSettingsCache == null)
                return valueReturned;

            foreach (var userSet in Utils.UserSettingsCache.ListOfUserSettings)
            {
                if (
                    userSet.FKUserID == userSettings.FKUserID &&
                    userSet.FKScreenCode == userSettings.FKScreenCode &&
                    userSet.FKControlCode == userSettings.FKControlCode &&
                    userSet.FKPropertyCode == userSettings.FKPropertyCode
                    )
                {
                    valueReturned = userSet.Value;
                }
            }
            valueReturned = valueReturned.Trim();

            return valueReturned;
        }

        /// <summary>
        /// Refresh cache
        /// </summary>
        /// <returns></returns>
        public static void RefreshCache()
        {
            Utils.UserSettingsCache.ListOfUserSettings.Clear();

            Utils.UserSettingsCache.ListOfUserSettings = UserSettings.List(Utils.UserID);
        }

        /// <summary>
        /// Refresh cache
        /// </summary>
        /// <returns></returns>
        public static void LoadUserSettingsInCache()
        {
            Utils.UserSettingsCache = new UserSettings();

            Utils.UserSettingsCache.ListOfUserSettings = UserSettings.List(Utils.UserID);
        }


        /// <summary>
        /// Load folder into FCM Database and into FCM folder
        /// </summary>
        /// <param name="sourceFolder"></param>
        /// <param name="uioutput"></param>
        /// <param name="parentUID"></param>
        /// <param name="sequenceNumber"></param>
        /// <param name="headerInfo"></param>
        /// <returns></returns>
        static public ResponseStatus LoadFolder(string sourceFolder,
                     IOutputMessage uioutput,
                     int parentUID, int sequenceNumber, HeaderInfo headerInfo)
        {

            ResponseStatus response = new ResponseStatus();
            response.Message = "Folder loaded successfully.";

            if (!Directory.Exists(sourceFolder))
            {
                response.ReturnCode = -0010;
                response.ReasonCode = -0001;
                response.Message = "Source folder does not exist.";
                response.UniqueCode = "E00.00.0001";
                response.Icon = MessageBoxIcon.Error;
                return response;
            }

            string[] folderNameSplit = sourceFolder.Split('\\');
            string folderName = folderNameSplit[folderNameSplit.Length - 1];

            uioutput.Activate();

            string[] files = Directory.GetFiles(sourceFolder);

            // Create folder that contains files and keep the parent
            //
            // ...
            Model.ModelDocument.Document folder = new Model.ModelDocument.Document();

            if (folderName.Length >= 7)
                folder.CUID = folderName.Substring(0, 7);
            else
                folder.CUID = folderName;

            folder.FileName = folderName;
            folder.Comments = "Loaded by batch";
            folder.Name = folderName;
            folder.DisplayName = folderName;
            folder.FKClientUID = 0;
            folder.IssueNumber = 0;
            string refPath =
                    MakHelperUtils.getReferenceFilePathName(sourceFolder);
            if (string.IsNullOrEmpty(refPath))
            {
                response.ReturnCode = -0010;
                response.ReasonCode = -0002;
                response.Message = "Folder selected is not under managed template folder.";
                response.UniqueCode = "E00.00.0001";
                return response;
            }

            folder.Location = refPath;
            // Store the folder being loaded at the root level
            //
            folder.Location = MakConstant.SYSFOLDER.TEMPLATEFOLDER;
            folder.ParentUID = parentUID;
            folder.SequenceNumber = 0;
            folder.SourceCode = "FCM";
            folder.UID = 0;
            folder.RecordType = MakHelperUtils.RecordType.FOLDER;
            folder.DocumentType = MakHelperUtils.DocumentType.FOLDER;
            folder.SimpleFileName = folder.Name;
            folder.FileExtension = "FOLDER";
            folder.IsProjectPlan = "N";

            // parentUID = folder.Save(headerInfo, MakHelperUtils.SaveType.NEWONLY);

            parentUID = RepDocument.Save(headerInfo, folder, MakHelperUtils.SaveType.NEWONLY);

            // Store each file
            //
            foreach (string file in files)
            {
                #region File Processing
                string name = Path.GetFileName(file);

                string fileName = Path.GetFileNameWithoutExtension(file);
                string fileExtension = Path.GetExtension(file);

                string validExtensions = ".doc .docx .xls .xlsx .pdf .dotx";

                // Not every extension will be loaded
                //
                if (!validExtensions.Contains(fileExtension))
                    continue;


                string fileNameExt = Path.GetFileName(file);

                string simpleFileName = fileNameExt;
                if (fileNameExt.Length > 10)
                    simpleFileName = fileNameExt.Substring(10).Trim();

                Model.ModelDocument.Document document = new Model.ModelDocument.Document();
                document.CUID = fileName.Substring(0, 6);
                document.FileName = fileNameExt;

                //string refPath =
                //        Utils.getReferenceFilePathName(sourceFolder);

                document.Location = refPath;
                string issue = "1";
                document.IssueNumber = Convert.ToInt32(issue);

                try
                {
                    issue = fileName.Substring(7, 2);
                    document.IssueNumber = Convert.ToInt32(issue);
                }
                catch (Exception ex)
                {
                    LogFile.WriteToTodaysLogFile(ex.ToString());
                }
                document.Name = fileName;
                document.SimpleFileName = simpleFileName;
                document.DisplayName = simpleFileName;
                document.SequenceNumber = sequenceNumber;
                document.ParentUID = parentUID;

                document.Comments = "Loaded via batch";
                document.SourceCode = "FCM";
                document.FKClientUID = 0;
                document.RecordType = MakHelperUtils.RecordType.DOCUMENT;
                document.FileExtension = fileExtension;
                document.Status = FCMUtils.FCMConstant.DocumentStatus.ACTIVE;
                document.IsProjectPlan = "N";

                switch (fileExtension)
                {
                    case ".doc":
                        document.DocumentType = MakHelperUtils.DocumentType.WORD;
                        break;

                    case ".docx":
                        document.DocumentType = MakHelperUtils.DocumentType.WORD;
                        break;

                    case ".dotx":
                        document.DocumentType = MakHelperUtils.DocumentType.WORD;
                        break;

                    case ".xls":
                        document.DocumentType = MakHelperUtils.DocumentType.EXCEL;
                        break;

                    case ".xlsx":
                        document.DocumentType = MakHelperUtils.DocumentType.EXCEL;
                        break;

                    case ".pdf":
                        document.DocumentType = MakHelperUtils.DocumentType.PDF;
                        break;

                    default:
                        document.DocumentType = MakHelperUtils.DocumentType.UNDEFINED;
                        break;
                }

                // document.Save(headerInfo, MakHelperUtils.SaveType.NEWONLY);

                RepDocument.Save(headerInfo, document, MakHelperUtils.SaveType.NEWONLY);

                uioutput.AddOutputMessage( document.Name, "", userID );

                sequenceNumber++;
                #endregion File Processing
            }

            // Recursion removed
            //
            string[] folders = Directory.GetDirectories(sourceFolder);
            foreach (string directory in folders)
            {
                string name = Path.GetFileName(directory);
                LoadFolder(directory, uioutput, parentUID, 0, headerInfo);
            }

            return response;
        }
    
    
    }
}
