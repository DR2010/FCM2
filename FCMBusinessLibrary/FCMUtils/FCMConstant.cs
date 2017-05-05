namespace FCMMySQLBusinessLibrary.FCMUtils
{
    /// <summary>
    /// Class with every constant used in the system
    /// </summary>
    public class FCMConstant
    {
        /// <summary>
        /// It represents the attribute for the database ConnectionString 
        /// </summary>
        public class fcmConfigXml
        {
            public static string ConnectionString = "ConnectionString";
            public static string ConnectionStringMySql = "ConnectionStringMySql";
            public static string ConnectionStringServer = "ConnectionStringServer";
            public static string ConnectionStringLocal = "ConnectionStringLocal";
            public static string LocalAssemblyFolder = "LocalAssemblyFolder";
            public static string ServerAssemblyFolder = "ServerAssemblyFolder";
            public static string EnableLocalDB = "EnableLocalDB";
            public static string EnableServerDB = "EnableServerDB";
            public static string DefaultDB = "DefaultDB";
            public static string AuditLogPath = "AuditLogPath";

        }

        /// <summary>
        /// It represents the attribute for the database ConnectionString 
        /// </summary>
        public enum DataBaseType
        {
            SQLSERVER, 
            MYSQL
        }

        
        /// <summary>
        /// Integer represent the sequence of the image on the Image List.
        /// </summary>
        public struct Image
        {
            public const int Selected = 0;
            public const int Document = 1;
            public const int Folder = 2;
            public const int Client = 3;
            public const int Appendix = 4;
            public const int Excel = 5;
            public const int PDF = 6;
            public const int Undefined = 7;
            public const int Checked = 8;
            public const int Unchecked = 9;

            public const int Word32 = 10;
            public const int WordFileExists32 = 11;
            public const int WordFileNotFound32 = 12;

            public const int WordFileSourceNoDestinationNo = 13;
            public const int WordFileSourceNoDestinationYes = 14;
            public const int WordFileSourceYesDestinationNo = 15;
            public const int WordFileSourceYesDestinationYes = 16;

            public const int ExcelFileSourceNoDestinationNo = 17;
            public const int ExcelFileSourceNoDestinationYes = 18;
            public const int ExcelFileSourceYesDestinationNo = 19;
            public const int ExcelFileSourceYesDestinationYes = 20;

            public const int PDFFileSourceNoDestinationNo = 21;
            public const int PDFFileSourceNoDestinationYes = 22;
            public const int PDFFileSourceYesDestinationNo = 23;
            public const int PDFFileSourceYesDestinationYes = 24;

        }

        /// <summary>
        /// This is the name of the image file representing the file type
        /// </summary>
        public struct ImageFileName
        {
            public const string Selected = "ImageSelected.jpg";
            public const string Document = "ImageWordDocument.jpg";
            public const string Folder = "ImageFolder.jpg";
            public const string Client = "ImageClient.jpg";
            public const string Appendix = "Appendix.jpg";
            public const string Excel = "Excel.jpg";
            public const string PDF = "PDF.jpg";
            public const string Undefined = "ImageWordDocument.jpg";
            public const string Checked = "Checked.jpg";
            public const string Unchecked = "Unchecked.jpg";

            public const string WordFile32 = "WordFile32.jpg";
            public const string WordFileExists32 = "WordFileExists32.jpg";
            public const string WordFileNotFound32 = "WordFileNotFound32.jpg";

            public const string WordFileSourceNoDestinationNo = "WordFileSourceNoDestinationNo";
            public const string WordFileSourceNoDestinationYes = "WordFileSourceNoDestinationYes";
            public const string WordFileSourceYesDestinationNo = "WordFileSourceYesDestinationNo";
            public const string WordFileSourceYesDestinationYes = "";

            public const string ExcelFileSourceNoDestinationNo = "ExcelFileSourceNoDestinationNo";
            public const string ExcelFileSourceNoDestinationYes = "ExcelFileSourceNoDestinationYes";
            public const string ExcelFileSourceYesDestinationNo = "ExcelFileSourceYesDestinationNo";
            public const string ExcelFileSourceYesDestinationYes = "ExcelFileSourceYesDestinationYes";

            public const string PDFFileSourceNoDestinationNo = "PDFFileSourceNoDestinationNo";
            public const string PDFFileSourceNoDestinationYes = "PDFFileSourceNoDestinationYes";
            public const string PDFFileSourceYesDestinationNo = "PDFFileSourceYesDestinationNo";
            public const string PDFFileSourceYesDestinationYes = "PDFFileSourceYesDestinationYes";
        }

        /// <summary>
        /// List of code types
        /// </summary>
        public struct CodeTypeString
        {
            public const string RoleType = "ROLETYPE";
            public const string ErrorCode = "ERRORCODE";
            public const string SYSTSET = "SYSTSET";
            public const string SCREENCODE = "SCREENCODE";
            public const string ERRORCODE = "ERRORCODE";

        }

        /// <summary>
        /// List of Role Types
        /// </summary>
        public struct RoleTypeCode
        {
            public const string AdministrationPerson = "ADMIN";
            public const string ManagingDirector = "MD1";
            public const string ProjectManager = "PM1";
            public const string ProjectOHSRepresentative = "POHSEREP";
            public const string OHSEAuditor = "OHSEAUDITOR";
            public const string SystemsManager = "SMN1";
            public const string SiteManager = "SM1";
            public const string Supervisor = "SUP1";
            public const string LeadingHand1 = "LEADHAND1";
            public const string LeadingHand2 = "LEADHAND2";
            public const string HealthAndSafetyRep = "HSR1";
            public const string WorkersCompensationCoordinator = "WCPERSON";

        }



        /// <summary>
        /// List of folder variables
        /// </summary>
        public struct SYSFOLDER
        {
            public const string TEMPLATEFOLDER = "%TEMPLATEFOLDER%";
            public const string CLIENTFOLDER = "%CLIENTFOLDER%";
            public const string VERSIONFOLDER = "%VERSIONFOLDER%";
            public const string PDFEXEPATH = "PDFEXEPATH";
            public const string LOGOFOLDER = "%LOGOFOLDER%";
            public const string WEBLOGOFOLDER = "%WEBLOGOFOLDER%";

            public const string WEBTEMPLATEFOLDER = "%WEBTEMPLATEFOLDER%";
            public const string WEBCLIENTFOLDER = "%WEBCLIENTFOLDER%";
            public const string WEBVERSIONFOLDER = "%WEBVERSIONFOLDER%";
            public const string LOGFILEFOLDER = "%LOGFILEFOLDER%";

        }

        /// <summary>
        /// Document list mode
        /// </summary>
        public struct DocumentListMode
        {
            public const string SELECT = "SELECT";
            public const string MAINTAIN = "MAINTAIN";
        }


        /// <summary>
        /// Screen Codes
        /// </summary>
        public struct ScreenCode
        {
            public const string Document = "DOCUMENT";
            public const string ClientRegistration = "CLNTREG";
            public const string ClientList = "CLNTLIST";
            public const string ClientDocument = "CLNTDOC";
            public const string ClientDocumentSet = "CLNTDOCSET";
            public const string ClientDocumentSetLink = "CLNTDOCSETLINK";
            public const string DocumentList = "DOCLIST";
            public const string DocumentLink = "DOCLINK";
            public const string DocumentSetLink = "DOCSETLINK";
            public const string DocumentSetList = "DOCSETLIST";
            public const string UserAccess = "USERACCESS";

            public const string ImpactedDocuments = "IMPACTEDDOCUMENTS";
            public const string ProcessRequest = "PROCESSREQUEST";
            public const string ReferenceData = "REFERENCEDATA";
            public const string ReportMetadata = "REPORTMETADATA";
            public const string Users = "USERS";
            public const string UserSettings = "USERSETTINGS";
        }

        /// <summary>
        /// Screen Codes
        /// </summary>
        public struct ScreenControl
        {
            public const string TreeViewClientDocumentList = "TVCLNTDOCLIST";
            public const string TreeViewClientDocumentListDocSet = "TVCLNTDOCLISTDOCSET";
            public const string TreeViewDocumentList = "TVCLNTDOCLIST";
        }

        /// <summary>
        /// Font Size
        /// </summary>
        public struct ScreenProperty
        {
            public const string FontSize = "FONTSIZE";
            public const string IconSize = "ICONSIZE";
        }


        public struct DocumentStatus
        {
            public const string ACTIVE = "ACTIVE";
            public const string INACTIVE = "INACTIVE";
        }

        public struct DocumentSetStatus
        {
            public const string COMPLETED = "COMPLETED";
            public const string DRAFT = "DRAFT";
        }

        public struct DocumentListType
        {
            public const string FCM = "FCM";
            public const string DOCUMENTSET = "DOCUMENTSET";
        }


        public struct MetadataRecordType
        {
            public const string CLIENT = "CL";
            public const string DEFAULT = "DF";
        }

        public struct FieldCode
        {
            public const string COMPANYLOGO = "COMPANYLOGO";
        }

        public struct SaveType
        {
            public const string NEWONLY = "NEWONLY";
            public const string UPDATE = "UPDATE";
        }

        /// <summary>
        /// Indicates the source of the document. It could be FCM or Client
        /// </summary>
        public struct SourceCode
        {
            public const string CLIENT = "CLIENT";
            public const string FCM = "FCM";
        }


        public struct RecordType
        {
            public const string FOLDER = "FOLDER";
            public const string DOCUMENT = "DOCUMENT";
            public const string APPENDIX = "APPENDIX";
        }

        public struct UserRoleType      
        {
            public const string ADMIN = "ADMIN";
            public const string USER = "USER";
            public const string CLIENT = "CLIENT";
            public const string POWERUSER = "POWERUSER";
        }


        public struct DocumentLinkType
        {
            public const string PROJECTPLAN = "PROJPLAN";
            public const string APPENDIX = "APPENDIX";
        }
    }
}
