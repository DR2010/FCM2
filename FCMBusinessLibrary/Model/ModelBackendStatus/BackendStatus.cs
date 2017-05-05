using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FCMMySQLBusinessLibrary.Model.ModelBackendStatus
{
    public class BackendStatus
    {
        public int UID { get; set; }
        public string ProcessName { get; set; }
        public string Status { get; set; }
        public DateTime ReportDateTime { get; set; }
        public string Details { get; set; }

    }
}
