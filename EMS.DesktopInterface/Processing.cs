using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using EMS.Services;
using EMS.Services.Interfaces;
using EMS.Services.Messaging.Department;
using EMS.Services.Messaging.Employee;
using EMS.Services.ViewModels;

namespace EMS.DesktopInterface
{
    public class Processing
    {
        private readonly IEmployeeService employeeService = MainService.EmployeeService;
        private readonly IDepartmentService departmentService = MainService.DepartmentService;
        private readonly ISalaryService salaryService = MainService.SalaryService;


        public IEnumerable<TitleViewModel> GetEmployeeTitleHistory(int employeeId)
        {
            
                GetEmployeeTitleHistoryRequest request = new GetEmployeeTitleHistoryRequest(employeeId);
                var response = this.employeeService.GetTitleHistory(request);
                if (response != null && response.Exception == null)
                {
                    return response.TitleHistory.ToList();
                }
            return null;
        }

        public IEnumerable<DepartmentEmployeeHistoryViewModel> GetEmployeeDepartmentHistory(int employeeId)
        {
            
                GetEmployeeDepartmentHistoryRequest request = new GetEmployeeDepartmentHistoryRequest(employeeId);
                var response = this.employeeService.GetDepartmentHistory(request);
                if (response != null && response.Exception == null)
                {
                    return response.DepartmentHistory.ToList();
                }
            return null;
        }

        public IEnumerable<SalaryViewModel> GetEmployeeSalaryHistory(int employeeId)
        {
                GetEmployeeSalaryHistoryRequest request = new GetEmployeeSalaryHistoryRequest(employeeId);
                var response = this.employeeService.GetSalaryHistory(request);
                if (response != null && response.Exception == null)
                {
                    return response.SalaryHistory.ToList();
                }
                return null;
        }

        //private void CurrentDepartment_Loaded(object sender, RoutedEventArgs e)
        //{
        //    List<string> data = this.CreateDepartmentList();

        //    var comboBox = sender as ComboBox;
        //    if (comboBox != null)
        //    {
        //        comboBox.ItemsSource = data;
        //    }
        //}

        public IEnumerable<string> GetDepartmentList()
        {
            GetDepartmentNamesResponse response = this.departmentService.GetDepartmentNames();

            return response.Departments.Names;
        }

        public bool SendCreateEmployeeRequest(InsertEmployeeProperties porperties)
        {
            InsertEmployeeRequest request = new InsertEmployeeRequest();
            request.InsertEmployeePorperties = porperties;

            var response = this.employeeService.InsertEmployee(request);
            if (response != null && response.Exception == null)
            {
                MessageBox.Show(string.Format( "Response: {0}" + Environment.NewLine + "Employee Id: {1}" + Environment.NewLine + "Error Messages: {2}",
                    response.ResponceCode, response.EmployeeId, response.InvalidDataMessage));
                if (!string.IsNullOrWhiteSpace(response.EmployeeId))
                {
                    return true;
                }
            }
            return false;
        }

        public bool SendChangeEmployeeSalaryRequest(SalaryProperties populateProperties)
        {
            int empId;
            int.TryParse(populateProperties.EmployeeId, out empId);
            ChangeEmployeeSalaryRequest request = new ChangeEmployeeSalaryRequest(empId);
            request.Properties = populateProperties;

            var response = this.employeeService.ChangeSalary(request);
            if (response != null && response.Exception == null)
            {
                MessageBox.Show("Success");
                return true;
            }
            else if (response != null)
            {
                MessageBox.Show(response.Exception.ToString());
            }
            return false;

        }
    }
}
