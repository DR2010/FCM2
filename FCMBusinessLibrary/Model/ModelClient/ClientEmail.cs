using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace FCMMySQLBusinessLibrary.Model.ModelClient
{
    public class ClientEmail
    {
        
        public int UID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Type { get; set; }
        public string Attachment { get; set; }
        public string CertificateType { get; set; }
    }
}
