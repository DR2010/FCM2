using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FCMMySQLBusinessLibrary.FCMUtils;
using MackkadoITFramework.Utils;

namespace FCMMySQLBusinessLibrary.Model.ModelClient
{

    public class Client : EventArgs
    {

        public int UID { get; set; }
        public int LogoImageSeqNum { get; set; }

        [Required( ErrorMessage = "ABN is mandatory." )]
        [Display( Name = "ABN" )]
        public string ABN { get; set; }

        [Required(ErrorMessage = "Client name is mandatory.")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Legal name is mandatory.")]
        [Display(Name = "Legal Name")]
        public string LegalName { get; set; }

        [Required( ErrorMessage = "Address is mandatory." )]
        [Display( Name = "Address" )]
        public string Address { get; set; }

        [Required( ErrorMessage = "Phone is mandatory." )]
        [Display( Name = "Phone Number" )]
        public string Phone { get; set; }
        public string Fax { get; set; }

        public string Mobile { get; set; }

        [Display(Name = "Logo - Small")]
        public string Logo1Location { get; set; }

        [Display(Name = "Logo - Medium")]
        public string Logo2Location { get; set; }

        [Display(Name = "Logo - Large")]
        public string Logo3Location { get; set; }

        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Display(Name = "Contact Person - Name")]
        public string MainContactPersonName { get; set; }

        [Display(Name = "Display Logo where applicable")]
        public char? DisplayLogo { get; set; }

        [Display(Name = "Client logs on to the system with user")]
        public string FKUserID { get; set; }

        [Display( Name = "Contractor Size" )]
        public int FKDocumentSetUID { get; set; }

        [Display( Name = "Contractor Size Description" )]
        public string DocSetUIDDisplay { get; set; }

        public string UserIdCreatedBy { get; set; }
        public string UserIdUpdatedBy { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public int RecordVersion { get; set; }
        public string IsVoid { get; set; }
        public ClientExtraInformation clientExtraInformation { get; set; }
        public ClientEmployee clientEmployee { get; set; }

        public FCMConstant.DataBaseType databasetype;
        public HeaderInfo _headerInfo { get; set; }

        public List<Client> clientList { get; set; } 

        public Client()
        {
        }

        public Client(HeaderInfo headerInfo)
        {
        }

    }

}
