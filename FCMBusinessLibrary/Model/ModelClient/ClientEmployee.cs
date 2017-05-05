using System.ComponentModel.DataAnnotations;

namespace FCMMySQLBusinessLibrary.Model.ModelClient
{
    public class ClientEmployee
    {

        /// <summary>
        /// 
        /// </summary>
        [Required( ErrorMessage = "Managing Director's Name is mandatory." )]
        [Display( Name = "Managing Director" )]
        public string ManagingDirector { get; set; }

        /// <summary>
        /// HSR1 - Health And Safety Rep
        /// </summary>
        [Required( ErrorMessage = "Health And Safety Representative is mandatory." )]
        [Display( Name = "Health And Safety Representative" )]
        public string HealthAndSafetyRep { get; set; }

        /// <summary>
        /// OHSEAUDITOR - OHS Auditor
        /// </summary>
        [Required( ErrorMessage = "OHS&E Auditor is mandatory." )]
        [Display( Name = "OHS&E Auditor" )]
        public string OHSEAuditor { get; set; }

        /// <summary>
        /// PM1 - Project Manager
        /// </summary>
        [Required( ErrorMessage = "Project Manager is mandatory." )]
        [Display( Name = "Project Manager" )]
        public string ProjectManager { get; set; }

        /// <summary>
        /// POHSEREP - Project OHS Representative
        /// </summary>
        [Required( ErrorMessage = "Project OHS Representative is mandatory." )]
        [Display( Name = "Project OHS Representative" )]
        public string ProjectOHSRepresentative { get; set; }

        /// <summary>
        /// SM1 - Site Manager Name
        /// </summary>
        [Required( ErrorMessage = "Site Manager Name is mandatory." )]
        [Display( Name = "Site Manager" )]
        public string SiteManager { get; set; }

        /// <summary>
        /// SMN1 - Systems Manager Name
        /// </summary>
        [Required( ErrorMessage = "Systems Manager Name is mandatory." )]
        [Display( Name = "Systems Manager" )]
        public string SystemsManager { get; set; }

        /// <summary>
        /// SUP1 - Supervisor Name
        /// </summary>
        [Display( Name = "Supervisor's Name" )]
        [Required( ErrorMessage = "Supervisor Name is mandatory." )]
        public string Supervisor { get; set; }

        /// <summary>
        /// WCPERSON - Workers Compensation Person
        /// </summary>
        [Display( Name = "Workers Compensation Person" )]
        [Required( ErrorMessage = "Workers Compensation Person's name is mandatory." )]
        public string WorkersCompensationCoordinator { get; set; }

        /// <summary>
        /// LH1 - Leading Hand 1
        /// </summary>
        [Display( Name = "Leading Hand 1" )]
        [Required( ErrorMessage = "Leading Hand 1 is mandatory." )]
        public string LeadingHand1 { get; set; }

        /// <summary>
        /// LH2 - Leading Hand 2
        /// </summary>
        [Display( Name = "Leading Hand 2" )]
        [Required( ErrorMessage = "Leading Hand 2 is mandatory." )]
        public string LeadingHand2 { get; set; }

        /// <summary>
        /// ADMINPERSON - Administration Person
        /// </summary>
        [Display( Name = "Administration Person" )]
        [Required( ErrorMessage = "Administration Person is mandatory." )]
        public string AdministrationPerson { get; set; }
    
    }
}
