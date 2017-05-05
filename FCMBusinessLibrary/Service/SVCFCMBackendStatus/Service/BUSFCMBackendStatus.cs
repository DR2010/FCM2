using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FCMMySQLBusinessLibrary.Model.ModelBackendStatus;
using FCMMySQLBusinessLibrary.Repository.RepositoryBackendStatus;
using FCMMySQLBusinessLibrary.Service.SVCDocument.ServiceContract;
using MackkadoITFramework.ErrorHandling;
using MackkadoITFramework.Utils;

namespace FCMMySQLBusinessLibrary.Service.SVCFCMBackendStatus.Service
{
    public class BUSFCMBackendStatus
    {
        /// <summary>
        /// Get last status update for a process
        /// </summary>
        public static BackendStatus ReadLast(HeaderInfo headerInfo, string processName)
        {
            var resp = RepBackendStatus.ReadLast( headerInfo, processName );
            return resp;
        }

        /// <summary>
        /// Report current process status
        /// </summary>
        public static BackendStatus ReportStatus( HeaderInfo headerInfo, string processName, string details, string status = "ACTIVE" )
        {
            BackendStatus backendStatus = new BackendStatus();
            backendStatus.Status = status;
            backendStatus.ProcessName = processName;
            backendStatus.Details = details;
            backendStatus.ReportDateTime = DateTime.Now;

            RepBackendStatus.Insert( headerInfo, backendStatus );
            return backendStatus;
        }
    }
}
