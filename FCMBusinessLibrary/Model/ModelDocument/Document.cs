using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using MackkadoITFramework.Helper;
using MackkadoITFramework.ReferenceData;
using MackkadoITFramework.Utils;
using MackkadoITFramework.ErrorHandling;
using MySql.Data.MySqlClient;

namespace FCMMySQLBusinessLibrary.Model.ModelDocument
{
    /// <summary>
    /// It represents a document, folder or appendix.
    /// </summary>
    public class Document
    {
        [Display( Name = "Unique Identifier" )]
        public int UID { get; set; }

        [Display( Name = "Document Unique Identifier (String)" )]
        public string CUID { get; set; }

        [Display( Name = "Document Name" )]
        public string Name { get; set; }

        [Display( Name = "Display Name" )]
        public string DisplayName { get; set; }

        [Display( Name = "Sequence Number" )]
        public int SequenceNumber { get; set; }

        [Display( Name = "Version Number" )]
        public int IssueNumber { get; set; }
        public string Location { get; set; }
        public string Comments { get; set; }

        [Display( Name = "File Extension" )]
        public string FileExtension { get; set; }
        /// <summary>
        /// It is the file name with extension
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// Indicates the source of the document. It could be from FCM or a Client Document.
        /// </summary>
        public string SourceCode { get; set; }

        [Display( Name = "Client Unique ID" )]
        public int FKClientUID { get; set; }

        [Display( Name = "Parent Document ID" )]
        public int ParentUID { get; set; }
        /// <summary>
        /// Indicates if it is a Folder, Document or Appendix
        /// </summary>
        /// 

        [Display( Name = "Record Type" )]
        public string RecordType { get; set; }
        /// <summary>
        /// Indicates if the document is a project plan.
        /// Project plans are special and can hold other documents.
        /// </summary>

        [Display( Name = "Is a Project Plan" )]
        public string IsProjectPlan { get; set; }
        /// <summary>
        /// Indicates the type of document: Word, Excel, PDF, Undefined etc.
        /// Use Utils.DocumentType
        /// </summary>

        [Display( Name = "Document Type" )]
        public string DocumentType { get; set; }
        /// <summary>
        /// It includes the client and version number of the document
        /// </summary>
        // public string ComboIssueNumber { get { return _ComboIssueNumber; } set { _ComboIssueNumber = value; } }
        /// <summary>
        /// It does not include the prefix (CUID) or version number
        /// </summary>

        [Display( Name = "Simple File Name" )]
        public string SimpleFileName { get; set; }
        /// <summary>
        /// Indicates whether the record is logically deleted.
        /// </summary>

        public string IsVoid { get; set; }
        /// <summary>
        /// Document Status (Draft, Finalised, Deleted)
        /// </summary>
        public string Status { get; set; }

        [Display( Name = "Record Version" )]
        public int RecordVersion { get; set; }
        /// <summary>
        /// Indicate if document has to be skipped during generation
        /// </summary>
        public string Skip { get; set; }

        // Audit fields
        //
        public string UserIdCreatedBy { get; set; }
        public string UserIdUpdatedBy { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }

        public List<Document> documentList;

        public Document()
        {
        }

        public Document(HeaderInfo headerInfo)
        {
        }


    }
}
