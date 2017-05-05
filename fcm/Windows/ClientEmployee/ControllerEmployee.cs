using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FCMMySQLBusinessLibrary;
using FCMMySQLBusinessLibrary.FCMUtils;
using FCMMySQLBusinessLibrary.Model.ModelClient;

namespace fcm
{
    public class ControllerEmployee 
    {
        public Employee model { get; set; }
        public IEmployee view  { get; set; }

        /// <summary>
        /// Constructor of the presenter
        /// </summary>
        public ControllerEmployee(IEmployee iEmployeeView)
        {
            view = iEmployeeView;
            model = new Employee();

            iEmployeeView.EmployeeList += ViewEmployeeList;
            iEmployeeView.EmployeeAdd += ViewEmployeeAdd;
            iEmployeeView.EmployeeUpdate += ViewEmployeeUpdate;
            iEmployeeView.EmployeeDelete += ViewEmployeeDelete;

        }

        public void ViewEmployeeList(object sender, EventArgs e)
        {
            var model = new Employee();

            view.employeeList = Employee.List(view.employee.FKCompanyUID);
            
            return;

        }

        public void ViewEmployeeAdd(object sender, EventArgs e)
        {
            var model = new Employee();

            LoadEmployeeFromController(model);

            view.response = model.Insert();
            view.DisplayMessage(view.response.Message);
            view.ResetScreen();
            return;
        }

        public void ViewEmployeeUpdate(object sender, EventArgs e)
        {
            var model = new Employee();

            LoadEmployeeFromController(model);

            view.response = model.Update();
            view.DisplayMessage(view.response.Message);

            return;
        }

        public void ViewEmployeeDelete(object sender, EventArgs e)
        {
            var model = new Employee();

            view.response = model.Delete();
            view.DisplayMessage(view.response.Message);
            
            return;
        }

        /// <summary>
        /// Populate employee object from controller object
        /// </summary>
        /// <param name="model"></param>
        private void LoadEmployeeFromController(Employee model)
        {
            model.UID = view.employee.UID;
            model.FKCompanyUID = view.employee.FKCompanyUID;
            model.Name = view.employee.Name;
            model.RoleType = view.employee.RoleType;
            model.Address = view.employee.Address;
            model.EmailAddress = view.employee.EmailAddress;
            model.Phone = view.employee.Phone;
            model.Fax = view.employee.Fax;
            model.IsAContact = view.employee.IsAContact;
            model.UserIdCreatedBy = Utils.UserID;
            model.UserIdUpdatedBy = Utils.UserID;
            model.UpdateDateTime = view.employee.UpdateDateTime;
            model.CreationDateTime = view.employee.CreationDateTime;

        }



    }
}
