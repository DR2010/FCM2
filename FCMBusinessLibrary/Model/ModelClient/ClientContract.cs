using System;
using System.Collections.Generic;
using System.Data;
using MackkadoITFramework.ErrorHandling;
using MackkadoITFramework.Utils;
using MySql.Data.MySqlClient;
using ConnString = MackkadoITFramework.Utils.ConnString;

namespace FCMMySQLBusinessLibrary.Model.ModelClient
{
    public class ClientContract
    {
        
        public int FKCompanyUID { get; set; }
        public int UID { get; set; }
        public string ExternalID { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string UserIdCreatedBy { get; set; }
        public string UserIdUpdatedBy { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }

    }
}
