using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
//using FCMMySQLBusinessLibrary.Document;
using System.Linq;
using System.Windows.Forms;
using FCMMySQLBusinessLibrary.Service.SVCDocument.ServiceContract;
using MackkadoITFramework.ReferenceData;
using FCMMySQLBusinessLibrary.Model.ModelDocument;
using MackkadoITFramework.Utils;
using MackkadoITFramework.ErrorHandling;
using MackkadoITFramework.Utils;
using MySql.Data.MySqlClient;
using ConnString = MackkadoITFramework.Utils.ConnString;
using HeaderInfo = MackkadoITFramework.Utils.HeaderInfo;
using Utils = MackkadoITFramework.Helper.Utils;

namespace FCMMySQLBusinessLibrary.Repository.RepositoryDocument
{
    /// <summary>
    /// It represents a document, folder or appendix.
    /// </summary>
    internal class RepDocument : Document
    {

        /// <summary>
        /// Database fields
        /// </summary>
        public struct FieldName
        {
            public const string UID = "UID";
            public const string SimpleFileName = "SimpleFileName";
            public const string CUID = "CUID";
            public const string Name = "Name";
            public const string DisplayName = "DisplayName";
            public const string SequenceNumber = "SequenceNumber";
            public const string IssueNumber = "IssueNumber";
            public const string Location = "Location";
            public const string Comments = "Comments";
            public const string FileName = "FileName";
            public const string SourceCode = "SourceCode";
            public const string FKClientUID = "FKClientUID";
            public const string IsVoid = "IsVoid";
            public const string Skip = "Skip";
            public const string ParentUID = "ParentUID";
            public const string RecordType = "RecordType";
            public const string FileExtension = "FileExtension";
            public const string IsProjectPlan = "IsProjectPlan";
            public const string DocumentType = "DocumentType";
            public const string Status = "Status";
            public const string RecordVersion = "RecordVersion";

            public const string CreationDateTime = "CreationDateTime";
            public const string UpdateDateTime = "UpdateDateTime";
            public const string UserIdCreatedBy = "UserIdCreatedBy";
            public const string UserIdUpdatedBy = "UserIdUpdatedBy";
        }

        public static Document
            Read(bool includeVoid = false, int docuid = 0, string doccuid = "")
        {

            var retdocument = new Document();

            // ---------------
            // EA SQL database
            // --------------- 
            bool ret = false;
            string commandString = "";

            string sincludeVoid = " AND DOC.IsVoid = 'N' ";

            if (includeVoid)
                sincludeVoid = "  ";

            if (docuid > 0)
            {
                commandString = string.Format(
                    " SELECT " +
                    RepDocument.SQLDocumentConcat("DOC") +
                    "  FROM Document DOC" +
                    " WHERE " +
                    "      DOC.UID = {0} " +
                    sincludeVoid,
                    docuid);
            }
            else
            {
                commandString = string.Format(
                    " SELECT " +
                    RepDocument.SQLDocumentConcat("DOC") +
                    "  FROM Document DOC " +
                    " WHERE " +
                    "      DOC.IsVoid = 'N' " +
                    "  AND DOC.CUID = '{0}' ",
                    doccuid);
            }

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        try
                        {
                            LoadDocumentFromReader(retdocument, "DOC", reader);
                            ret = true;
                        }
                        catch (Exception)
                        {
                            retdocument.CUID = "";
                            retdocument.UID = 0;
                            retdocument.Name = "Not found UID " + retdocument.UID.ToString("0000") + " CUID: " + retdocument.CUID;
                            retdocument.FileName = "Not found UID " + retdocument.UID.ToString("0000") + " CUID: " + retdocument.CUID;
                            retdocument.RecordType = "";
                        }
                    }
                }
            }
            return retdocument;
        }

        public static string SQLDocumentConcat(string tablePrefix)
        {
            string ret = " " +
            tablePrefix + ".UID            " + tablePrefix + "UID,            " +
            tablePrefix + ".CUID           " + tablePrefix + "CUID,           " +
            tablePrefix + ".Name           " + tablePrefix + "Name,           " +
            tablePrefix + ".DisplayName    " + tablePrefix + "DisplayName,    " +
            tablePrefix + ".SequenceNumber " + tablePrefix + "SequenceNumber, " +
            tablePrefix + ".IssueNumber    " + tablePrefix + "IssueNumber,    " +
            tablePrefix + ".Location       " + tablePrefix + "Location,       " +
            tablePrefix + ".Comments       " + tablePrefix + "Comments,       " +
            tablePrefix + ".FileName       " + tablePrefix + "FileName,       " +
            tablePrefix + ".Status         " + tablePrefix + "Status,         " +
            tablePrefix + ".SimpleFileName " + tablePrefix + "SimpleFileName, " +
            tablePrefix + ".SourceCode     " + tablePrefix + "SourceCode,     " +
            tablePrefix + ".FKClientUID    " + tablePrefix + "FKClientUID,    " +
            tablePrefix + ".IsVoid         " + tablePrefix + "IsVoid,         " +
            tablePrefix + ".Skip         " + tablePrefix + "Skip,         " +
            tablePrefix + ".ParentUID      " + tablePrefix + "ParentUID,      " +
            tablePrefix + ".RecordType     " + tablePrefix + "RecordType,     " +
            tablePrefix + ".FileExtension  " + tablePrefix + "FileExtension,  " +
            tablePrefix + ".IsProjectPlan  " + tablePrefix + "IsProjectPlan,  " +
            tablePrefix + ".DocumentType   " + tablePrefix + "DocumentType,    " +
            tablePrefix + ".RecordVersion   " + tablePrefix + "RecordVersion,    " +
            tablePrefix + ".UpdateDateTime " + tablePrefix + "UpdateDateTime,  " +
            tablePrefix + ".CreationDateTime " + tablePrefix + "CreationDateTime, " +
            tablePrefix + ".UserIdCreatedBy  " + tablePrefix + "UserIdCreatedBy, " +
            tablePrefix + ".UserIdUpdatedBy  " + tablePrefix + "UserIdUpdatedBy ";

            return ret;
        }


        /// <summary>
        /// Retrieve the name of the document
        /// </summary>
        /// <param name="documentUID"></param>
        /// <returns></returns>
        public static string GetName(int documentUID)
        {
            string ret = "";
            // 
            // EA SQL database
            // 

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {
                var commandString =
                " SELECT Name " +
                "  FROM Document" +
                " WHERE UID = " + documentUID;

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        try
                        {
                            ret = reader["Name"].ToString();
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
            return ret;
        }

        public string GetDocumentLocationAndName()
        {
            string ret = "";

            Read();

            ret = Utils.getFilePathName(this.Location, this.Name);

            return ret;
        }

        //
        // Set void flag (Logical Delete)
        //
        public static void SetToVoid(int DocumentUID)
        {
            string ret = "Item updated successfully";

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {

                var commandString =
                (
                   "UPDATE Document " +
                   " SET " +
                   " IsVoid = @IsVoid" +
                   " WHERE UID = @UID "
                );

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {
                    command.Parameters.Add("@UID", MySqlDbType.Int32).Value = DocumentUID;
                    command.Parameters.Add("@IsVoid", MySqlDbType.VarChar).Value = 'Y';

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            return;
        }

        //
        // Physical Delete
        //
        public static void Delete(int DocumentUID)
        {
            string ret = "Item updated successfully";

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {

                var commandString =
                (
                   "DELETE Document " +
                   " WHERE UID = @UID "
                );



                using (var command = new MySqlCommand(
                                            commandString, connection))
                {
                    command.Parameters.Add("@UID", MySqlDbType.Int32).Value = DocumentUID;

                    connection.Open();
                    command.ExecuteNonQuery();
                }

            }
            return;
        }


        /// <summary>
        /// Add new Document
        /// </summary>
        /// <returns></returns>
        private static int Add(HeaderInfo headerInfo, Model.ModelDocument.Document docadd)
        {

            string ret = "Item added successfully";
            int _uid = 0;
            _uid = GetLastUID() + 1;

            docadd.UID = _uid;
            if (string.IsNullOrEmpty(docadd.Status))
                docadd.Status = "ACTIVE";
            docadd.UserIdCreatedBy = headerInfo.UserID;
            docadd.UserIdUpdatedBy = headerInfo.UserID;
            docadd.CreationDateTime = headerInfo.CurrentDateTime;
            docadd.UpdateDateTime = headerInfo.CurrentDateTime;
            docadd.IsVoid = "N";
            docadd.Skip = "N";
            docadd.Status = "ACTIVE";
            docadd.RecordVersion = 1;
            if (string.IsNullOrEmpty(docadd.DisplayName))
                docadd.DisplayName = "TBA";


            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {
                var commandString =
                (
                        "INSERT INTO Document " +
                        "( " +
                        DocumentFieldString() +
                        ")" +
                            " VALUES " +
                        "( " +
                    "  @" + FieldName.UID +
                    ", @" + FieldName.CUID +
                    ", @" + FieldName.Name +
                    ", @" + FieldName.DisplayName +
                    ", @" + FieldName.SequenceNumber +
                    ", @" + FieldName.IssueNumber +
                    ", @" + FieldName.Location +
                    ", @" + FieldName.Comments +
                    ", @" + FieldName.FileName +
                    ", @" + FieldName.Status +
                    ", @" + FieldName.SimpleFileName +
                    ", @" + FieldName.SourceCode +
                    ", @" + FieldName.FKClientUID +
                    ", @" + FieldName.IsVoid +
                    ", @" + FieldName.Skip +
                    ", @" + FieldName.ParentUID +
                    ", @" + FieldName.RecordType +
                    ", @" + FieldName.FileExtension +
                    ", @" + FieldName.IsProjectPlan +
                    ", @" + FieldName.DocumentType +
                    ", @" + FieldName.RecordVersion +
                    ", @" + FieldName.UpdateDateTime +
                    ", @" + FieldName.CreationDateTime +
                    ", @" + FieldName.UserIdCreatedBy +
                    ", @" + FieldName.UserIdUpdatedBy +
                        " ) "

                        );

                using (var command = new MySqlCommand(
                                          commandString, connection))
                {
                    command.Parameters.Add( "@UID", MySqlDbType.Int32 ).Value = docadd.UID;
                    command.Parameters.Add( "@CUID", MySqlDbType.VarChar ).Value = docadd.CUID;
                    command.Parameters.Add( "@Name", MySqlDbType.VarChar ).Value = docadd.Name;
                    command.Parameters.Add( "@DisplayName", MySqlDbType.VarChar ).Value = docadd.DisplayName;
                    command.Parameters.Add( "@SequenceNumber", MySqlDbType.VarChar ).Value = docadd.SequenceNumber;
                    command.Parameters.Add( "@IssueNumber", MySqlDbType.Decimal ).Value = docadd.IssueNumber;
                    command.Parameters.Add( "@Location", MySqlDbType.VarChar ).Value = docadd.Location;
                    command.Parameters.Add( "@Comments", MySqlDbType.VarChar ).Value = docadd.Comments;
                    command.Parameters.Add( "@FileName", MySqlDbType.VarChar ).Value = docadd.FileName;
                    command.Parameters.Add( "@SimpleFileName", MySqlDbType.VarChar ).Value = docadd.SimpleFileName;
                    command.Parameters.Add( "@SourceCode", MySqlDbType.VarChar ).Value = docadd.SourceCode;
                    command.Parameters.Add( "@FKClientUID", MySqlDbType.Int32 ).Value = docadd.FKClientUID;
                    command.Parameters.Add( "@IsVoid", MySqlDbType.VarChar ).Value = docadd.IsVoid;
                    command.Parameters.Add( "@Skip", MySqlDbType.VarChar ).Value = docadd.Skip;
                    command.Parameters.Add( "@ParentUID", MySqlDbType.VarChar ).Value = docadd.ParentUID;
                    command.Parameters.Add( "@RecordType", MySqlDbType.VarChar ).Value = docadd.RecordType;
                    command.Parameters.Add( "@IsProjectPlan", MySqlDbType.VarChar ).Value = docadd.IsProjectPlan;
                    command.Parameters.Add( "@DocumentType", MySqlDbType.VarChar ).Value = docadd.DocumentType;
                    command.Parameters.Add( "@FileExtension", MySqlDbType.VarChar ).Value = docadd.FileExtension;
                    command.Parameters.Add( "@Status", MySqlDbType.VarChar ).Value = docadd.Status;
                    command.Parameters.Add( "@RecordVersion", MySqlDbType.VarChar ).Value = docadd.RecordVersion;
                    command.Parameters.Add( "@UserIdCreatedBy", MySqlDbType.VarChar ).Value = docadd.UserIdCreatedBy;
                    command.Parameters.Add( "@UserIdUpdatedBy", MySqlDbType.VarChar ).Value = docadd.UserIdUpdatedBy;
                    command.Parameters.Add( "@CreationDateTime", MySqlDbType.DateTime ).Value = docadd.CreationDateTime;
                    command.Parameters.Add( "@UpdateDateTime", MySqlDbType.DateTime ).Value = docadd.UpdateDateTime;

                    connection.Open();

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        LogFile.WriteToTodaysLogFile(
                            "Error adding new document." + ex.ToString(),
                            headerInfo.UserID,
                            "Document.cs"
                            );
                        LogFile.WriteToTodaysLogFile(
                            "SQL String: " + commandString,
                            headerInfo.UserID,
                            "Document.cs"
                            );
                        // Error
                        _uid = 0;
                    }
                }
            }
            return _uid;
        }

        // -----------------------------------------------------
        //    Update Document Version
        // -----------------------------------------------------
        private static void UpdateVersion(HeaderInfo headerInfo, Model.ModelDocument.Document indocument)
        {

            string ret = "Item updated successfully";

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {

                var commandString =
                (
                   "UPDATE Document " +
                   " SET " +
                   " Name =  @Name " +
                   ",IssueNumber = @IssueNumber" +
                   ",Location = @Location" +
                   ",FileName = @FileName" +
                   " WHERE CUID = @CUID "
                );

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {
                    command.Parameters.Add("@CUID", MySqlDbType.VarChar).Value = indocument.CUID;
                    command.Parameters.Add("@Name", MySqlDbType.VarChar).Value = indocument.Name;
                    command.Parameters.Add("@IssueNumber", MySqlDbType.Decimal).Value = indocument.IssueNumber;
                    command.Parameters.Add("@Location", MySqlDbType.VarChar).Value = indocument.Location;
                    command.Parameters.Add("@FileName", MySqlDbType.VarChar).Value = indocument.FileName;

                    connection.Open();
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        LogFile.WriteToTodaysLogFile(
                            "Error updating document version." + ex.ToString(),
                            headerInfo.UserID,
                            "Document.cs"
                            );
                    }
                }
            }
            return;
        }

        /// <summary>
        /// Get Root document. If it does not exits, create a root document.
        /// </summary>
        public static FCMMySQLBusinessLibrary.Model.ModelDocument.Document 
            GetRoot(HeaderInfo headerInfo)
        {

            Model.ModelDocument.Document docreturn = new Model.ModelDocument.Document();

            docreturn.CUID = "ROOT";
            docreturn.Name = "FCM Documents";
            docreturn.RecordType = Utils.RecordType.FOLDER;
            docreturn.UID = 0;

            docreturn = RepDocument.Read(true,0, docreturn.CUID);

            if (docreturn.UID <= 0) // Document not found
            {
                // Create root
                //
                docreturn.CUID = "ROOT";
                docreturn.RecordVersion = 1;
                docreturn.Name = "FCM Documents";
                docreturn.DisplayName = "FCM Documents";
                docreturn.RecordType = Utils.RecordType.FOLDER;
                docreturn.Comments = "Created automatically.";
                docreturn.DocumentType = Utils.DocumentType.FOLDER;
                docreturn.FileName = "ROOT";
                docreturn.FKClientUID = 0;
                docreturn.IsProjectPlan = "N";
                docreturn.IssueNumber = 0;
                docreturn.IsVoid = "N";
                docreturn.Skip = "N";
                docreturn.Location = "ROOT";
                docreturn.RecordType = Utils.RecordType.FOLDER;
                docreturn.SequenceNumber = 0;
                docreturn.SimpleFileName = "ROOT";
                docreturn.UID = 0;
                docreturn.SourceCode = Utils.SourceCode.FCM;
                docreturn.FileExtension = "ROOT";
                
                Save(headerInfo, docreturn);
            }

            return docreturn;
        }

        // -----------------------------------------------------
        //    Update Document
        // -----------------------------------------------------
        private static int Update(HeaderInfo headerInfo, Model.ModelDocument.Document docupdate)
        {

            string ret = "Item updated successfully";

            docupdate.UserIdUpdatedBy = Utils.UserID;
            docupdate.UpdateDateTime = System.DateTime.Now;

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {

                var commandString =
                (
                   "UPDATE Document " +
                   " SET " +
                   " CUID =  @CUID " +
                   ",Name =  @Name " +
                   ",DisplayName =  @DisplayName " +
                   ",SequenceNumber = @SequenceNumber  " +
                   ",IssueNumber = @IssueNumber" +
                   ",Location = @Location" +
                   ",Comments = @Comments " +
                   ",FileName = @FileName" +
                   ",SimpleFileName = @SimpleFileName" +
                   ",SourceCode = @SourceCode " +
                   ",IsProjectPlan = @IsProjectPlan " +
                   ",FKClientUID = @FKClientUID " +
                   ",ParentUID = @ParentUID " +
                   ",DocumentType = @DocumentType " +
                   ",UserIdUpdatedBy = @UserIdUpdatedBy " +
                   ",UpdateDateTime = @UpdateDateTime  " +
                   " WHERE UID = @UID "
                );

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {
                    command.Parameters.Add("@UID", MySqlDbType.VarChar).Value = docupdate.UID;
                    command.Parameters.Add("@CUID", MySqlDbType.VarChar).Value = docupdate.CUID;
                    command.Parameters.Add("@Name", MySqlDbType.VarChar).Value = docupdate.Name;
                    command.Parameters.Add("@DisplayName", MySqlDbType.VarChar).Value = docupdate.DisplayName;
                    command.Parameters.Add("@SequenceNumber", MySqlDbType.VarChar).Value = docupdate.SequenceNumber;
                    command.Parameters.Add("@IssueNumber", MySqlDbType.Decimal).Value = docupdate.IssueNumber;
                    command.Parameters.Add("@Location", MySqlDbType.VarChar).Value = docupdate.Location;
                    command.Parameters.Add("@IsProjectPlan", MySqlDbType.VarChar).Value = docupdate.IsProjectPlan;
                    command.Parameters.Add("@Comments", MySqlDbType.VarChar).Value = docupdate.Comments;
                    command.Parameters.Add("@FileName", MySqlDbType.VarChar).Value = docupdate.FileName;
                    command.Parameters.Add("@SimpleFileName", MySqlDbType.VarChar).Value = docupdate.SimpleFileName;
                    command.Parameters.Add("@SourceCode", MySqlDbType.VarChar).Value = docupdate.SourceCode;
                    command.Parameters.Add("@FKClientUID", MySqlDbType.Int32).Value = docupdate.FKClientUID;
                    command.Parameters.Add("@ParentUID", MySqlDbType.Int32).Value = docupdate.ParentUID;
                    command.Parameters.Add("@DocumentType", MySqlDbType.VarChar).Value = docupdate.DocumentType;
                    command.Parameters.Add("@UserIdUpdatedBy", MySqlDbType.VarChar).Value = docupdate.UserIdUpdatedBy;
                    command.Parameters.Add("@UpdateDateTime", MySqlDbType.DateTime).Value = docupdate.UpdateDateTime;

                    connection.Open();

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        LogFile.WriteToTodaysLogFile(
                            "Error updating document." + ex.ToString(),
                            headerInfo.UserID,
                            "Document.cs"
                            );
                    }
                }
            }
            return docupdate.UID;
        }

        // -----------------------------------------------------
        //   Retrieve last Document Set id
        // -----------------------------------------------------
        private static int GetLastUID()
        {
            int LastUID = 0;

            // 
            // EA SQL database
            // 

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {
                var commandString =
                    "SELECT MAX(UID) LASTUID FROM Document";

                using (var command = new MySqlCommand(
                                            commandString, connection))
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        try
                        {
                            LastUID = Convert.ToInt32(reader["LASTUID"]);
                        }
                        catch (Exception)
                        {
                            LastUID = 0;
                        }
                    }
                }
            }

            return LastUID;
        }

        /// <summary>
        /// Add or Update a record
        /// </summary>
        /// <param name="type">In case of an update, checks the issue number
        /// </param>
        /// <returns></returns>
        public static int Save(HeaderInfo headerInfo, Document indocument, string type = null)
        {
            // Check if code value exists.
            // If it exists, update
            // Else Add a new one
            int uidReturn = 0;

            Model.ModelDocument.Document currentdocument = Read(false, indocument.UID);

            if (currentdocument.UID > 0)
            {
                // If it is a new issue, save the old issue in the issue table
                //
                if (currentdocument.IssueNumber == indocument.IssueNumber)
                {
                    if (type == Utils.SaveType.UPDATE)
                    {
                        // Update location - use reference path instead of fixed path

                        var destLocationDerivedClient = Utils.getReferenceFilePathName(indocument.Location);

                        indocument.Location = destLocationDerivedClient; 
                        uidReturn = Update(headerInfo, indocument);
                    }
                }
                else
                {
                    LogFile.WriteToTodaysLogFile(
                          "Document Save - issue number is different. CUID: " + indocument.CUID,
                          headerInfo.UserID,
                          "Document.cs"
                          );
                }
            }
            else
            {
                uidReturn = Add(headerInfo, indocument);

            }
            return uidReturn;
        }

        // -----------------------------------------------------
        //    Create new document version
        // -----------------------------------------------------
        public static DocumentNewVersionResponse NewVersion( HeaderInfo headerInfo, Document document )
        {

            DocumentNewVersionResponse responseNewVersion = new DocumentNewVersionResponse();

            responseNewVersion.response = new ResponseStatus();

            responseNewVersion.response.Message = "New version created successfully.";

            // Update location - use reference path instead of fixed path

            var destLocationDerivedClient = Utils.getReferenceFilePathName( document.Location );
            document.Location = destLocationDerivedClient; 

            // Copy existing version to old folder version
            // Old folder comes from %VERSIONFOLDER%
            // 
            var versionFolder =
                CodeValue.GetCodeValueExtended(MakConstant.CodeTypeString.SYSTSET, MakConstant.SYSFOLDER.VERSIONFOLDER);

            // Create a record to point to the old version
            var documentVersion = new DocumentVersion();
            documentVersion.FKDocumentCUID = document.CUID;
            documentVersion.FKDocumentUID = document.UID;

            // Generate the new version id
            documentVersion.IssueNumber = document.IssueNumber;
            documentVersion.Location = Utils.GetVersionPath(document.Location);
            documentVersion.FileName = document.FileName;
            documentVersion.Add();

            // Increments issue number
            document.IssueNumber++;

            // Create a new file name with version on it
            // POL-05-01 FILE NAME.doc
            //
            int version = Convert.ToInt32(document.IssueNumber);
            string tversion = version.ToString().PadLeft(2, '0');

            // 12/02/2013 - Daniel - I am not sure if the number is POL-01 or POL-01-02
            // It was 10, today it was 7, now I am making it 10 again... something will go wrong :-(
            //

            string simpleFileName = document.Name.Substring( 10 ).Trim();

            // string simpleFileName = document.Name.Substring(07).Trim();

            string newFileName = document.CUID + '-' +
                                 tversion + ' ' +
                                 simpleFileName;

            // string newFileNameWithExtension = newFileName + ".doc";

            // Well, the simple file name has extension already... so I have commented out the line above
            // 30/04/2011 - Testing to see if it works.
            //
            string newFileNameWithExtension = newFileName;

            // Copy the file with new name
            // Let's copy the document
            //string realLocation = Utils.getFilePathName(document.Location, document.FileName);
            //string realDestination = Utils.getFilePathName(documentVersion.Location, documentVersion.FileName);
            //string realPathDestination = Utils.getFilePathName( documentVersion.Location );

            string realLocation = Utils.getFilePathNameLOCAL( document.Location, document.FileName );
            string realDestination = Utils.getFilePathNameLOCAL( documentVersion.Location, documentVersion.FileName );
            string realPathDestination = Utils.getFilePathNameLOCAL( documentVersion.Location );
            
            if (!System.IO.Directory.Exists(realPathDestination))
                System.IO.Directory.CreateDirectory(realPathDestination);

            if (!System.IO.File.Exists(realLocation))
            {
                responseNewVersion.response.Message = "File to be copied was not found. " + realLocation;
                responseNewVersion.response.ReturnCode = -0010;
                responseNewVersion.response.ReasonCode = 0001;
                responseNewVersion.response.UniqueCode = ResponseStatus.MessageCode.Error.FCMERR00000006;
                return responseNewVersion;
            }

            File.Copy(realLocation, realDestination, true);

            // 15.12.2013
            // Acontece issue aqui quando o Issue Number e' ZERO no campo mas o Issue Number
            // no file name e' maior que zero. E' so' acertar o registro.
            // 

            // Copy file to new name
            //
            string newFilePathName = Utils.getFilePathNameLOCAL(document.Location,newFileNameWithExtension);

            File.Copy(realLocation, newFilePathName, true);

            // Delete old version from main folder
            //
            try
            {
                File.Delete(realLocation);
            }
            catch (Exception ex)
            {
                responseNewVersion.response.Message = "Error deleting file. " + realLocation;
                responseNewVersion.response.ReturnCode = -0010;
                responseNewVersion.response.ReasonCode = 0004;
                responseNewVersion.response.UniqueCode = ResponseStatus.MessageCode.Error.FCMERR00000006;

                LogFile.WriteToTodaysLogFile( responseNewVersion.response.Message + " " + ex.ToString(), "", "", "Document.cs" );

                return responseNewVersion;
            }
            // Update document details - version, name, etc
            document.IssueNumber = version;
            // this.ComboIssueNumber = "C" + version.
            ;
            document.FileName = newFileNameWithExtension;
            document.Name = newFileName;
            // this.UpdateVersion(headerInfo);

            RepDocument.UpdateVersion(headerInfo, document );

            // Build a screen to browse all versions of a file
            // Allow compare/ View
            // Check how to open a 

            responseNewVersion.outDocument = new Document();
            responseNewVersion.outDocument = RepDocument.Read( true, document.UID );

            responseNewVersion.response.Contents = version;
            return responseNewVersion;
        }

        /// <summary>
        /// Load a document from a given reader
        /// </summary>
        /// <param name="retDocument"></param>
        /// <param name="tablePrefix"></param>
        /// <param name="reader"></param>
        public static void LoadDocumentFromReader(
                               Model.ModelDocument.Document retDocument,
                               string tablePrefix,
                               MySqlDataReader reader)
        {

            retDocument.UID = Convert.ToInt32(reader[tablePrefix + FieldName.UID].ToString());
            retDocument.CUID = reader[tablePrefix + FieldName.CUID].ToString();
            retDocument.Name = reader[tablePrefix + FieldName.Name].ToString();
            retDocument.DisplayName = reader[tablePrefix + FieldName.DisplayName].ToString();
            retDocument.SequenceNumber = Convert.ToInt32(reader[tablePrefix + FieldName.SequenceNumber].ToString());
            retDocument.IssueNumber = Convert.ToInt32(reader[tablePrefix + FieldName.IssueNumber].ToString());
            retDocument.Location = reader[tablePrefix + FieldName.Location].ToString();
            retDocument.Comments = reader[tablePrefix + FieldName.Comments].ToString();
            retDocument.SourceCode = reader[tablePrefix + FieldName.SourceCode].ToString();
            retDocument.FileName = reader[tablePrefix + FieldName.FileName].ToString();
            retDocument.SimpleFileName = reader[tablePrefix + FieldName.SimpleFileName].ToString();
            retDocument.FKClientUID = Convert.ToInt32(reader[tablePrefix + FieldName.FKClientUID].ToString());
            retDocument.ParentUID = Convert.ToInt32(reader[tablePrefix + FieldName.ParentUID].ToString());
            retDocument.RecordType = reader[tablePrefix + FieldName.RecordType].ToString();
            retDocument.IsProjectPlan = reader[tablePrefix + FieldName.IsProjectPlan].ToString();
            retDocument.IsVoid = reader [tablePrefix + FieldName.IsVoid].ToString();
            retDocument.Skip = reader [tablePrefix + FieldName.Skip].ToString();
            retDocument.DocumentType = reader [tablePrefix + FieldName.DocumentType].ToString();
            retDocument.RecordVersion = Convert.ToInt32(reader[tablePrefix + FieldName.RecordVersion].ToString());


            //try { retDocument.UpdateDateTime = Convert.ToDateTime(reader[FieldName.UpdateDateTime].ToString()); }
            //catch { retDocument.UpdateDateTime = DateTime.Now; }
            //try { retDocument.CreationDateTime = Convert.ToDateTime(reader[FieldName.CreationDateTime].ToString()); }
            //catch { retDocument.CreationDateTime = DateTime.Now; }
            //try { retDocument.IsVoid = reader[FieldName.IsVoid].ToString(); }
            //catch { retDocument.IsVoid = "N"; }
            //try { retDocument.UserIdCreatedBy = reader[FieldName.UserIdCreatedBy].ToString(); }
            //catch { retDocument.UserIdCreatedBy = "N"; }
            //try { retDocument.UserIdUpdatedBy = reader[FieldName.UserIdCreatedBy].ToString(); }
            //catch { retDocument.UserIdCreatedBy = "N"; }

            return;
        }
        /// <summary>
        /// Returns a string to be concatenated with a SQL statement
        /// </summary>
        /// <param name="tablePrefix"></param>
        /// <returns></returns>

        /// <summary>
        /// Document string of fields.
        /// </summary>
        /// <returns></returns>
        private static string DocumentFieldString()
        {
            return (
                        FieldName.UID
                + "," + FieldName.CUID
                + "," + FieldName.Name
                + "," + FieldName.DisplayName
                + "," + FieldName.SequenceNumber
                + "," + FieldName.IssueNumber
                + "," + FieldName.Location
                + "," + FieldName.Comments
                + "," + FieldName.FileName
                + "," + FieldName.Status
                + "," + FieldName.SimpleFileName
                + "," + FieldName.SourceCode
                + "," + FieldName.FKClientUID
                + "," + FieldName.IsVoid
                + "," + FieldName.Skip
                + "," + FieldName.ParentUID
                + "," + FieldName.RecordType
                + "," + FieldName.FileExtension
                + "," + FieldName.IsProjectPlan
                + "," + FieldName.DocumentType
                + "," + FieldName.RecordVersion
                + "," + FieldName.UpdateDateTime
                + "," + FieldName.CreationDateTime
                + "," + FieldName.UserIdCreatedBy
                + "," + FieldName.UserIdUpdatedBy
            );
        }


        // -----------------------------------------------------
        //    List Documents
        // -----------------------------------------------------
        public void ListProjectPlans(HeaderInfo headerInfo)
        {
            List(headerInfo, " AND IsProjectPlan = 'Y' ");
        }

        // -----------------------------------------------------
        //    List Documents
        // -----------------------------------------------------
        public static List<Document> List(HeaderInfo headerInfo)
        {
            return List(headerInfo, null);
        }

        // -----------------------------------------------------
        //    List Documents
        // -----------------------------------------------------
        public static List<Document> ListDocuments( HeaderInfo headerInfo )
        {
            return List( headerInfo, " AND DOC.RecordType = 'DOCUMENT'  " );
        }

        // -----------------------------------------------------
        //    List Documents
        // -----------------------------------------------------
        public static List<Document> ListFolders( HeaderInfo headerInfo )
        {
            return List( headerInfo, " AND DOC.RecordType = 'FOLDER'  " );
        }

        public static List<Document> ListFoldersAndDocuments(HeaderInfo headerInfo)
        {
            DocumentList docsBeforeSort = new DocumentList();
            DocumentList docsAfterSort = new DocumentList();

            docsAfterSort.documentList = new List<Document>();
            docsBeforeSort.documentList = List(headerInfo, null);

            TreeView tvFileList = new TreeView();

            Document root = GetRoot(headerInfo);

            ListInTree(tvFileList, docsBeforeSort, root);

            // 3 - Move to an ordered list
            foreach (TreeNode documentNode in tvFileList.Nodes)
            {
                var docnode = (Document)documentNode.Tag;

                docsAfterSort.documentList.Add(docnode);

                // If there are inner nodes
                //
                if (documentNode.Nodes.Count > 0)
                {
                    ListInOrder(documentNode, docsAfterSort.documentList);
                }
            }

            return docsAfterSort.documentList;

        }


        private static void ListInOrder(TreeNode treeNode, List<Document> documentList)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {

                var document = (Document)node.Tag;
                documentList.Add(document);

                if (node.Nodes.Count > 0)
                {
                    ListInOrder(node, documentList);
                }
            }
        }

        // -----------------------------------------------------
        //    List Documents
        // -----------------------------------------------------
        
        public static List<Document> List(HeaderInfo _headerInfo, string Condition = null)
        {
            var documentList = new List<Document>();

            documentList = new List<Model.ModelDocument.Document>();

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {

                var commandString = string.Format(
                " SELECT " +
                RepDocument.SQLDocumentConcat("DOC") +
                "   FROM     Document DOC " +
                "  WHERE DOC.SourceCode = 'FCM' " +
                "    AND DOC.IsVoid = 'N' " +
                Condition +
                "  ORDER BY PARENTUID ASC, SequenceNumber ASC "
                );

                using (var command = new MySqlCommand(
                                      commandString, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            Model.ModelDocument.Document _Document = new Model.ModelDocument.Document();
                            RepDocument.LoadDocumentFromReader(_Document, "DOC", reader);

                            if (_Document.ParentUID > 1)
                            {
                                Document parentDoc = RepDocument.Read(true, _Document.ParentUID);
                                _Document.DisplayName = parentDoc.DisplayName + '/' + _Document.DisplayName;
                            }

                            documentList.Add(_Document);
                        }
                    }
                }
            }

            return documentList;
        }


        // -----------------------------------------------------
        //        List Documents for a Document Set
        // -----------------------------------------------------
        public void ListDocSet(int documentSetUID)
        {
            this.documentList = new List<Model.ModelDocument.Document>();

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {

                var commandString = string.Format(
                "  SELECT " +
                RepDocument.SQLDocumentConcat("DOC") +
                " ,LNK.FKParentDocumentUID " +
                " ,LNK.FKParentDocumentSetUID " +
                " ,LNK.SequenceNumber " +
                "   FROM Document DOC " +
                "       ,DocumentSetDocument LNK" +
                "  WHERE " +
                "        LNK.FKDocumentUID = DOC.UID " +
                "    AND DOC.SourceCode = 'FCM' " +
                "    AND LNK.IsVoid     = 'N' " +
                "    AND DOC.IsVoid     = 'N' " +
                "    AND LNK.FKDocumentSetUID = {0}  " +
                "  ORDER BY LNK.FKParentDocumentUID ASC, LNK.SequenceNumber ",
                documentSetUID
                );

                using (var command = new MySqlCommand(
                                      commandString, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Model.ModelDocument.Document _Document = new Model.ModelDocument.Document();
                            RepDocument.LoadDocumentFromReader(_Document, "DOC", reader);

                            // This is necessary because when the list comes from DocumentSet, the parent may change
                            //
                            _Document.ParentUID = Convert.ToInt32(reader["FKParentDocumentUID"].ToString());

                            this.documentList.Add(_Document);
                        }
                    }
                }
            }
        }


        // -----------------------------------------------------
        //           Load documents in a tree
        // -----------------------------------------------------
        public static void ListInTree(
            TreeView fileList,
            DocumentList documentList,
            Model.ModelDocument.Document root)
        {

            // Find root folder
            //
            Model.ModelDocument.Document rootDocument = new Model.ModelDocument.Document();

            rootDocument.CUID = root.CUID;
            rootDocument.RecordType = root.RecordType;
            rootDocument.UID = root.UID;
            // rootDocument.Read();

            rootDocument = RepDocument.Read(false, root.UID);

            // Create root
            //
            var rootNode = new TreeNode(rootDocument.Name, MakConstant.Image.Folder, MakConstant.Image.Folder);

            // Add root node to tree
            //
            fileList.Nodes.Add(rootNode);
            rootNode.Tag = rootDocument;
            rootNode.Name = rootDocument.Name;

            foreach (var document in documentList.documentList)
            {
                // Ignore root folder
                if (document.CUID == "ROOT") continue;

                // Check if folder has a parent
                string cdocumentUID = document.UID.ToString();
                string cparentIUID = document.ParentUID.ToString();

                int image = 0;
                int imageSelected = 0;
                document.RecordType = document.RecordType.Trim();

                #region Image
                switch (document.DocumentType)
                {
                    case Utils.DocumentType.WORD:
                        image = MakConstant.Image.Word32;
                        imageSelected = MakConstant.Image.Word32;


                        // I have to think about this...
                        //
                        if (document.RecordType == Utils.RecordType.APPENDIX)
                        {
                            image = MakConstant.Image.Appendix;
                            imageSelected = MakConstant.Image.Appendix;
                        }
                        break;

                    case Utils.DocumentType.EXCEL:
                        image = MakConstant.Image.Excel;
                        imageSelected = MakConstant.Image.Excel;
                        break;

                    case Utils.DocumentType.FOLDER:
                        image = MakConstant.Image.Folder;
                        imageSelected = MakConstant.Image.Folder;
                        break;

                    case Utils.DocumentType.PDF:
                        image = MakConstant.Image.PDF;
                        imageSelected = MakConstant.Image.PDF;
                        break;

                    default:
                        image = MakConstant.Image.Word32;
                        imageSelected = MakConstant.Image.Word32;

                        break;
                }
                #endregion Image

                if (document.ParentUID == 0)
                {
                    var treeNode = new TreeNode(document.Name, image, image);
                    treeNode.Tag = document;
                    treeNode.Name = cdocumentUID;

                    rootNode.Nodes.Add(treeNode);
                }
                else
                {
                    // Find the parent node
                    //
                    var node = fileList.Nodes.Find(cparentIUID, true);

                    if (node.Count() > 0)
                    {

                        var treeNode = new TreeNode(document.Name, image, imageSelected);
                        treeNode.Tag = document;
                        treeNode.Name = cdocumentUID;

                        node[0].Nodes.Add(treeNode);
                    }
                    else
                    {
                        // Add Element to the root
                        //
                        var treeNode = new TreeNode(document.Name, image, imageSelected);
                        treeNode.Tag = document;
                        treeNode.Name = cdocumentUID;

                        rootNode.Nodes.Add(treeNode);

                    }
                }
            }
        }


        // -----------------------------------------------------
        //    List Documents for a client
        // -----------------------------------------------------
        public void ListClient(int clientUID)
        {
            this.documentList = new List<Model.ModelDocument.Document>();

            using (var connection = new MySqlConnection(ConnString.ConnectionString))
            {

                var commandString = string.Format(
                " SELECT " +
                RepDocument.SQLDocumentConcat("DOC") +
                "   FROM Document DOC " +
                "  WHERE SourceCode = 'CLIENT' " +
                "    AND FKClientUID = {0} " +
                "    AND IsVoid <> 'Y' " +
                "  ORDER BY PARENTUID ASC, SequenceNumber ASC ",
                clientUID);

                using (var command = new MySqlCommand(
                                      commandString, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Model.ModelDocument.Document _Document = new Model.ModelDocument.Document();
                            RepDocument.LoadDocumentFromReader(_Document, "DOC", reader);

                            documentList.Add(_Document);

                        }
                    }
                }
            }
        }


        /// <summary>
        /// Update single field in document
        /// </summary>
        /// <param name="UID"></param>
        /// <param name="fieldName"></param>
        /// <param name="contents"></param>
        public void UpdateFieldString( int UID, string fieldName, string contents )
        {

            string ret = "Item updated successfully";

            using ( var connection = new MySqlConnection( ConnString.ConnectionString ) )
            {

                var commandString =
                (
                   "UPDATE Document " +
                   " SET " +
                   fieldName + "= @contents " +
                   " WHERE UID = @UID "
                );

                using ( var command = new MySqlCommand(
                                            commandString, connection ) )
                {
                    command.Parameters.Add( "@UID", MySqlDbType.Int32 ).Value = UID;
                    command.Parameters.Add( "@contents", MySqlDbType.VarChar ).Value = contents;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            return;
        }

    }
}
