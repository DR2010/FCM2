using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FCMMySQLBusinessLibrary.Repository.RepositoryDocument
{
    public class RepDocumentSetDocument
    {

        /// <summary>
        /// Returns a string to be concatenated with a SQL statement
        /// </summary>
        /// <param name="tablePrefix"></param>
        /// <returns></returns>
        public static string SQLDocumentConcat(string tablePrefix)
        {
            string ret = " " +
            tablePrefix + ".UID                    " + tablePrefix + "UID,              " +
            tablePrefix + ".FKDocumentUID          " + tablePrefix + "FKDocumentUID,    " +
            tablePrefix + ".FKDocumentSetUID       " + tablePrefix + "FKDocumentSetUID, " +
            tablePrefix + ".Location               " + tablePrefix + "Location, " +
            tablePrefix + ".IsVoid                 " + tablePrefix + "IsVoid, " +
            tablePrefix + ".StartDate              " + tablePrefix + "StartDate, " +
            tablePrefix + ".EndDate                " + tablePrefix + "EndDate, " +
            tablePrefix + ".FKParentDocumentUID    " + tablePrefix + "FKParentDocumentUID, " +
            tablePrefix + ".SequenceNumber         " + tablePrefix + "SequenceNumber, " +
            tablePrefix + ".FKParentDocumentSetUID " + tablePrefix + "FKParentDocumentSetUID, " +
            tablePrefix + ".DocumentType           " + tablePrefix + "DocumentType    ";

            return ret;
        }
    }
}
