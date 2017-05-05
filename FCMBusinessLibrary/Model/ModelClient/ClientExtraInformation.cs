using System;
using System.ComponentModel.DataAnnotations;

namespace FCMMySQLBusinessLibrary.Model.ModelClient
{
    public class ClientExtraInformation
    {

        public int UID { get; set; } // bigint
        public int FKClientUID { get; set; } // bigint

        /// <summary>
        /// Date to enter on policies
        /// </summary>
        [Required( ErrorMessage = "Date to enter on policies is required." )]
        [Display( Name = "Date to enter on policies" )]
        [DataType( DataType.Date )]
        [UIHint( "Date" )]
        [DisplayFormat( DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true )]
        public DateTime DateToEnterOnPolicies { get; set; } // date

        [Required( ErrorMessage = "Scope of services is required." )]
        [Display( Name = "Scope Of Services" )]
        public string ScopeOfServices { get; set; } // varchar(200)

        [Required(ErrorMessage = "Action plan date is required.")]
        [Display(Name = "Action plan date")]
        [DataType(DataType.Date)]
        [UIHint("Date")]
        [DisplayFormat( DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true )]
        public DateTime ActionPlanDate { get; set; } // date

        [Required( ErrorMessage = "Certification Target Date is required." )]
        [Display( Name = "Certification Target Date" )]
        [DataType( DataType.Date )]
        [UIHint( "Date" )]
        [DisplayFormat( DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true )]
        public DateTime CertificationTargetDate { get; set; } // date

        [Display(Name = "Time Trading")]
        public string TimeTrading { get; set; } // varchar(200)

        [Display(Name = "Regions of Operation")]
        public string RegionsOfOperation { get; set; } // varchar(200)
        
        [Display(Name = "Operational Meetings Frequency")]
        public string OperationalMeetingsFrequency { get; set; } // varchar(50)

        [Display(Name = "Project Meetings Frequency")]
        public string ProjectMeetingsFrequency { get; set; } // varchar(50)

        public string IsVoid { get; set; }

        public string UserIdCreatedBy { get; set; }
        public string UserIdUpdatedBy { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public int RecordVersion { get; set; }

    }
}
