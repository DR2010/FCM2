using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FCMMySQLBusinessLibrary.Model.ModelClient;
using MackkadoITFramework.ErrorHandling;

namespace FCMMySQLBusinessLibrary.Service.SVCClient.ServiceContract
{
    public class SCEmployee
    {
        public class EmployeeListResponse
        {
            public List<Employee> employeeList;
            public ResponseStatus response;
        }

        public class EmployeeReadResponse
        {
            public Employee employee;
            public ResponseStatus response;
        }

        public class EmployeeCreateResponse
        {
            public Employee employee;
            public ResponseStatus response;
        }


    }
}
