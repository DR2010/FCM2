using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FCMMySQLBusinessLibrary.Repository
{
    public static class FCMDBFieldName
    {

        /// <summary>
        /// Database fields
        /// </summary>
        public struct Client
        {
            public const string UID = "UID";
            public const string ABN = "ABN";
            public const string Name = "Name";
            public const string LegalName = "LegalName";
            public const string Address = "Address";
            public const string Phone = "Phone";
            public const string Fax = "Fax";
            public const string Mobile = "Mobile";
            public const string Logo1Location = "Logo1Location";
            public const string Logo2Location = "Logo2Location";
            public const string Logo3Location = "Logo3Location";
            public const string EmailAddress = "EmailAddress";
            public const string MainContactPersonName = "MainContactPersonName";
            public const string IsVoid = "IsVoid";
            public const string FKUserID = "FKUserID";
            public const string FKDocumentSetUID = "FKDocumentSetUID";
            public const string DocSetUIDDisplay = "DocSetUIDDisplay";
            public const string DisplayLogo = "DisplayLogo";
            public const string UserIdCreatedBy = "UserIdCreatedBy";
            public const string UserIdUpdatedBy = "UserIdUpdatedBy";
            public const string CreationDateTime = "CreationDateTime";
            public const string UpdateDateTime = "UpdateDateTime";
            public const string RecordVersion = "recordVersion";

        }

        /// <summary>
        /// Database fields
        /// </summary>
        public struct ClientContract
        {
            public const string FKCompanyUID = "FKCompanyUID";
            public const string UID = "UID";
            public const string ExternalID = "ExternalID";
            public const string Status = "Status";
            public const string Type = "Type";
            public const string StartDate = "StartDate";
            public const string EndDate = "EndDate";
            public const string UserIdCreatedBy = "UserIdCreatedBy";
            public const string UserIdUpdatedBy = "UserIdUpdatedBy";
            public const string CreationDateTime = "CreationDateTime";
            public const string UpdateDateTime = "UpdateDateTime";
        }


        /// <summary>
        /// Database fields
        /// </summary>
        public struct ClientExtraInformation
        {
            public const string UID = "UID";
            public const string FKClientUID = "FKClientUID";
            public const string DateToEnterOnPolicies = "DateToEnterOnPolicies";
            public const string ScopeOfServices = "ScopeOfServices";
            public const string ActionPlanDate = "ActionPlanDate";
            public const string CertificationTargetDate = "CertificationTargetDate";
            public const string TimeTrading = "TimeTrading";
            public const string RegionsOfOperation = "RegionsOfOperation";
            public const string OperationalMeetingsFrequency = "OperationalMeetingsFrequency";
            public const string ProjectMeetingsFrequency = "ProjectMeetingsFrequency";
            //
            public const string UserIdCreatedBy = "UserIdCreatedBy";
            public const string UserIdUpdatedBy = "UserIdUpdatedBy";
            public const string CreationDateTime = "CreationDateTime";
            public const string UpdateDateTime = "UpdateDateTime";
            public const string RecordVersion = "RecordVersion";
            public const string IsVoid = "IsVoid";
        }


        /// <summary>
        /// Database fields
        /// </summary>
        public struct Document
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



        /// <summary>
        /// Database fields
        /// </summary>
        public struct ClientDocument
        {
            public const string UID = "UID";
            public const string DocumentCUID = "DocumentCUID";
            public const string FKClientUID = "FKClientUID";
            public const string FKClientDocumentSetUID = "FKClientDocumentSetUID";
            public const string FKDocumentUID = "FKDocumentUID";

            public const string SourceLocation = "SourceLocation";
            public const string SourceFileName = "SourceFileName";
            public const string Location = "Location";
            public const string FileName = "FileName";
            public const string SourceIssueNumber = "SourceIssueNumber";
            public const string ClientIssueNumber = "ClientIssueNumber";
            public const string SequenceNumber = "SequenceNumber";
            public const string Generated = "xGenerated";
            public const string StartDate = "StartDate";
            public const string EndDate = "EndDate";
            public const string RecordType = "RecordType";
            public const string ParentUID = "ParentUID";
            public const string IsProjectPlan = "IsProjectPlan";
            public const string DocumentType = "DocumentType";
            public const string ComboIssueNumber = "ComboIssueNumber";
            public const string IsVoid = "IsVoid";
            public const string IsLocked = "IsLocked";
            public const string IsRoot = "IsRoot";
            public const string IsFolder = "IsFolder";
            public const string GenerationMessage = "GenerationMessage";

            public const string CreationDateTime = "CreationDateTime";
            public const string UpdateDateTime = "UpdateDateTime";
            public const string UserIdCreatedBy = "UserIdCreatedBy";
            public const string UserIdUpdatedBy = "UserIdUpdatedBy";
        }


        /// <summary>
        /// Database fields
        /// </summary>
        public struct BackendStatus
        {
            public const string UID = "UID";
            public const string ProcessName = "ProcessName";
            public const string Status = "Status";
            public const string ReportDateTime = "ReportDateTime";
            public const string Details = "Details";

        }

    }
}
