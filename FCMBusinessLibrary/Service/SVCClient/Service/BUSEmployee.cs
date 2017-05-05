using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FCMMySQLBusinessLibrary.Service.SVCClient.ServiceContract;
using MackkadoITFramework.ErrorHandling;
using FCMMySQLBusinessLibrary.Model.ModelClient;

namespace FCMMySQLBusinessLibrary.Service.SVCClient.Service
{
    public class BUSEmployee
    {

        public static SCEmployee.EmployeeListResponse EmployeeList( int clientUID )
        {
            var employeeList = new SCEmployee.EmployeeListResponse();
            var list = Model.ModelClient.Employee.List( clientUID );

            employeeList.response = new ResponseStatus();
            employeeList.employeeList = list;

            return employeeList;

        }

        public static SCEmployee.EmployeeReadResponse EmployeeRead( int clientUID, int employeeUID )
        {
            var employeeResponse = new SCEmployee.EmployeeReadResponse();

            employeeResponse.response = new ResponseStatus();

            employeeResponse.employee = new Employee();
            employeeResponse.employee.UID = employeeUID;
            employeeResponse.employee.Read();

            return employeeResponse;
        }

        public static ResponseStatus EmployeeUpdate( Employee employee )
        {
            var employeeResponse = new ResponseStatus();

            employee.Update();

            return employeeResponse;
        }

        public static SCEmployee.EmployeeCreateResponse EmployeeCreate( Employee employee )
        {
            var employeeResponse = new SCEmployee.EmployeeCreateResponse();

            employee.Insert();
            employeeResponse.employee = employee;

            return employeeResponse;
        }


        public static ResponseStatus EmployeeDelete( Employee employee )
        {
            var employeeResponse = new ResponseStatus();

            employee.Delete();

            return employeeResponse;
        }

    
    }
}
