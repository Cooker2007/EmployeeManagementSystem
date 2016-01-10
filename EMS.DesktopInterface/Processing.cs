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
        public Processing(IEmployeeService employeeService, IDepartmentService departmentService, ISalaryService salaryService)
        {
            this.employeeService = employeeService;
            this.departmentService = departmentService;
            this.salaryService = salaryService;
        }

        private readonly IEmployeeService employeeService;
        private readonly IDepartmentService departmentService;
        private readonly ISalaryService salaryService;


        public IEnumerable<TitleViewModel> GetEmployeeTitleHistory(int employeeId)
        {

                var request = new GetEmployeeTitleHistoryRequest(employeeId);
                var response = this.employeeService.GetTitleHistory(request);
                if (response != null && response.Exception == null)
                {
                    return response.TitleHistory.ToList();
                }
            return null;
        }

        public IEnumerable<DepartmentEmployeeHistoryViewModel> GetEmployeeDepartmentHistory(int employeeId)
        {

                var request = new GetEmployeeDepartmentHistoryRequest(employeeId);
                var response = this.employeeService.GetDepartmentHistory(request);
                if (response != null && response.Exception == null)
                {
                    return response.DepartmentHistory.ToList();
                }
            return null;
        }

        public IEnumerable<SalaryViewModel> GetEmployeeSalaryHistory(int employeeId)
        {
                var request = new GetEmployeeSalaryHistoryRequest(employeeId);
                var response = this.employeeService.GetSalaryHistory(request);
                if (response != null && response.Exception == null)
                {
                    return response.SalaryHistory.ToList();
                }
                return null;
        }

        public IEnumerable<string> GetDepartmentList()
        {
            var response = this.departmentService.GetDepartmentNames();

            return response.Departments.Names;
        }

        public bool SendCreateEmployeeRequest(InsertEmployeeProperties porperties)
        {
            var request = new InsertEmployeeRequest
            {
                InsertEmployeePorperties = porperties
            };

            var response = this.employeeService.InsertEmployee(request);
            if (response != null && response.Exception == null)
            {
                MessageBox.Show(string.Format("Response: {0}" + Environment.NewLine + "Employee Id: {1}" + Environment.NewLine + "Error Messages: {2}",
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
            var request = new ChangeEmployeeSalaryRequest(empId)
            {
                Properties = populateProperties
            };

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
