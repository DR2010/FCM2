using System;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using FCMMySQLBusinessLibrary.Repository;
using FCMMySQLBusinessLibrary.Repository.RepositoryDocument;
using MackkadoITFramework.ReferenceData;
using MackkadoITFramework.Utils;
using FCMMySQLBusinessLibrary.FCMUtils;
using MackkadoITFramework.ErrorHandling;
using MySql.Data.MySqlClient;
using System.IO;

namespace FCMMySQLBusinessLibrary.Model.ModelClientDocument
{
    public class ClientDocument
    {
        #region properties

        public ClientDocumentSet clientDocumentSet { get; set; }
        public List<scClientDocSetDocLink> clientDocSetDocLink { get; set; }
        public List<ClientDocument> clientDocumentList { get; set; }

        public int UID { get; set; }

        [Display( Name = "Document Unique ID" )]
        public string DocumentCUID { 
            get { return _DocumentCUID; } 
            set { 
                _DocumentCUID = value;

                if (_DocumentCUID.Trim().ToUpper() == "ROOT")
                    IsRoot = 'Y';
                else
                    IsRoot = 'N';
            } 
        }

        [Display( Name = "Client Identifier" )]
        public int FKClientUID { get; set; }

        [Display( Name = "Client Document Set Identifier" )]
        public int FKClientDocumentSetUID { get; set; }

        [Display( Name = "Document Identifier" )]
        public int FKDocumentUID { get; set; }

        [Display( Name = "Source Location" )]
        public string SourceLocation { get; set; }

        [Display( Name = "Source File Name" )]
        public string SourceFileName { get; set; }

        [Display( Name = "Location" )]
        public string Location { get; set; }

        [Display( Name = "File Name" )]
        public string FileName { get; set; }

        [Display( Name = "Source Issue Number" )]
        public int SourceIssueNumber { get; set; }

        [Display( Name = "Client Version Number" )]
        public int ClientIssueNumber { get; set; }

        [Display( Name = "Sequence Number" )]
        public int SequenceNumber { get; set; }

        [Display( Name = "Generated" )]
        public char Generated { get; set; }

        [Display( Name = "Source File Present" )]
        public char SourceFilePresent { get; set; }

        [Display( Name = "Destination File Present" )]
        public char DestinationFilePresent { get; set; }

        [Display( Name = "Start Date" )]
        public DateTime StartDate { get; set; }

        [Display( Name = "End Date" )]
        public DateTime EndDate { get; set; }

        [Display( Name = "Record Type" )]
        public string RecordType
        { 
            get { return _RecordType; } 
            set 
            { 
                _RecordType = value;

                if (_RecordType.Trim() == FCMConstant.RecordType.FOLDER)
                    IsFolder = 'Y';
                else
                    IsFolder = 'N';

            } 
        }

        [Display( Name = "Parent UID" )]
        public int ParentUID { get; set; }

        [Display( Name = "Is Project Plan" )]
        public string IsProjectPlan { get; set; }

        [Display( Name = "Document Type" )]
        public string DocumentType { get; set; }

        [Display( Name = "Combo Issue Number" )]
        public string ComboIssueNumber { get; set; }

        [Display( Name = "Is Void" )]
        public char IsVoid { get; set; }

        [Display( Name = "Is Root" )]
        public char IsRoot { get; set; }

        [Display( Name = "Is Folder" )]
        public char IsFolder { get; set; }

        [Display( Name = "Is Checked" )]
        public bool IsChecked { get; set; }

        [Display( Name = "Is Locked" )]
        public char IsLocked { get; set; }

        [Display( Name = "Generation Message" )]
        public string GenerationMessage { get; set; }

        #endregion properties

        #region attributes
        private string _DocumentCUID;
        private string _RecordType;

        #endregion attributes

        public ClientDocument()
        {
            clientDocumentSet = new ClientDocumentSet();
        }

    }
}
