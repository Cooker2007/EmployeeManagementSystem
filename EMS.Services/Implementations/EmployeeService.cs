using EMS.Domain;
using EMS.Services.ConversionHelper;
using EMS.Services.Interfaces;
using EMS.Services.Messaging.Employee;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using EMS.Services.ViewModels;
using Infrastructure.Common.HelperMethods;

namespace EMS.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IDepartmentEmployeeRepository departmentEmployeeRepository;

        private readonly IDepartmentRepository departmentRepository;

        private readonly IEmployeeRepository employeeRepository;

        private readonly ISalaryRepository salaryRepository;

        private readonly ITitleRepository titleRepository;

        public EmployeeService(IDepartmentEmployeeRepository departmentEmployeeRepository,
            IDepartmentRepository departmentRepository, IEmployeeRepository employeeRepository,
            ISalaryRepository salaryRepository, ITitleRepository titleRepository)
        {
            this.departmentEmployeeRepository = departmentEmployeeRepository;
            this.departmentRepository = departmentRepository;
            this.employeeRepository = employeeRepository;
            this.salaryRepository = salaryRepository;
            this.titleRepository = titleRepository;
        }

        public Employee GetEmployee(int id)
        {
            var emp = this.employeeRepository.FindById(id);
            return emp;
        }

        public GetEmployeeResponse GetEmployee(GetEmployeeRequest getEmployeeRequest)
        {
            GetEmployeeResponse response = new GetEmployeeResponse();
            Employee employee;
            Employee manager;
            Department department;
            Salary salary;
            Title title;

            try
            {
                employee = this.employeeRepository.FindById(getEmployeeRequest.Id);

                if (employee != null)
                {
                    var deptEmp = employee.Departments.OrderByDescending(d => d.FromDate).FirstOrDefault();
                    department = deptEmp != null ? deptEmp.Department : null;

                    salary = employee.Salaries.OrderByDescending(d => d.FromDate).FirstOrDefault();
                    title = employee.Titles.OrderByDescending(d => d.FromDate).FirstOrDefault();
                    manager =
                        employee.Managers.OrderByDescending(d => d.FromDate).Select(m => m.Employee).FirstOrDefault();

                    response.Employee = employee.ConvertToViewModel(department, manager, salary, title);
                }
                else
                {
                    response.Exception = this.GetStandardEmployeeNotFoundException(getEmployeeRequest.Id);
                }
            }
            catch (Exception ex)
            {
                response.Exception = ex;
            }
            return response;
        }

        #region Employee Historical Data

        public GetEmployeeDepartmentHistoryResponse GetDepartmentHistory(
            GetEmployeeDepartmentHistoryRequest getEmployeeDepartmentHistoryRequest)
        {
            var response = new GetEmployeeDepartmentHistoryResponse();

            var departmentEmployees =
                this.departmentEmployeeRepository.GetDepartmentEmployeeHistory(getEmployeeDepartmentHistoryRequest.Id);

            if (departmentEmployees != null)
            {
                response.DepartmentHistory = departmentEmployees.ConvertToViewModels(this.GetDepartmentNameDictionary());
            }
            else
            {
                response.Exception = this.GetGenericResourceNotFoundException();
            }
            return response;
        }

        public GetEmployeeTitleHistoryResponse GetTitleHistory(
            GetEmployeeTitleHistoryRequest getEmployeeTitleHistoryRequest)
        {
            var response = new GetEmployeeTitleHistoryResponse();

            var titles = this.titleRepository.GetTitleHistory(getEmployeeTitleHistoryRequest.Id);

            if (titles != null)
            {
                response.TitleHistory = titles.ConvertToViewModels();
            }
            else
            {
                response.Exception = this.GetGenericResourceNotFoundException();
            }
            return response;
        }

        public GetEmployeeSalaryHistoryResponse GetSalaryHistory(GetEmployeeSalaryHistoryRequest request)
        {
            GetEmployeeSalaryHistoryResponse response = new GetEmployeeSalaryHistoryResponse();

            var salaryHistory = this.salaryRepository.GetSalaryHistotyByEmployeeId(request.Id);

            if (salaryHistory != null)
            {
                response.SalaryHistory = salaryHistory.ConvertToViewModels();
            }
            else
            {
                response.Exception = this.GetGenericResourceNotFoundException();
            }
            return response;
        }

        public GetEmployeeSalaryResponse GetCurrentSalary(GetEmployeeSalaryRequest request)
        {
            GetEmployeeSalaryResponse response = new GetEmployeeSalaryResponse();

            var salary = this.salaryRepository.GetEmployeeCurrentSalary(request.Id);

            if (salary != null)
            {
                response.Salary = salary.ConvertToViewModel();
            }
            else
            {
                response.Exception = this.GetGenericResourceNotFoundException();
            }

            return response;
        }


        private IDictionary<string, string> GetDepartmentNameDictionary()
        {
            return this.departmentRepository.GetDepartmentNameDictionary();
        }

        #endregion Employee Historical Data

        #region Resource Not Found Exceptions

        private ResourceNotFoundException GetStandardEmployeeNotFoundException(int id)
        {
            throw new ResourceNotFoundException(string.Format("The requested employee was not found. '{0}'", id));
        }

        private ResourceNotFoundException GetGenericResourceNotFoundException()
        {
            throw new ResourceNotFoundException("The requested data was not found.");
        }

        #endregion Resource Not Found Exceptions

        public UpdateEmployeeResponse UpdateEmployee(UpdateEmployeeRequest updateEmployeeRequest)
        {
            UpdateEmployeeResponse response = new UpdateEmployeeResponse();
            try
            {
                var employee = this.employeeRepository.FindById(updateEmployeeRequest.Id);

                if (employee != null)
                {
                    Gender gender;
                    Gender.TryParse(updateEmployeeRequest.EmployeePorperties.Gender, out gender);

                    employee.UpdateEmployeeData(updateEmployeeRequest.EmployeePorperties.FirstName,
                        updateEmployeeRequest.EmployeePorperties.LastName,
                        updateEmployeeRequest.EmployeePorperties.BirthDate,
                        gender
                        );
                }
            }
            catch (Exception ex)
            {
                response.Exception = ex;
            }

            this.employeeRepository.Save();
            return response;
        }

        public GetEmployeesResponse GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public InsertEmployeeResponse InsertEmployee(InsertEmployeeRequest request)
        {
            Employee newEmployee = this.AssignAvailablePropertiesToDomain(request.InsertEmployeePorperties);
            var brokenRules = newEmployee.GetBrokenRules().ToList();

            InsertEmployeeResponse response = new InsertEmployeeResponse();

            if (brokenRules.Count == 0)
            {
                response.ResponceCode = "Success";
                response.InvalidDataMessage = string.Empty;

                try
                {
                    this.employeeRepository.Add(newEmployee);
                    this.employeeRepository.Save();
                    response.EmployeeId = newEmployee.Id.ToString();

                }
                // TODO Find more specific exception.
                catch (Exception ex)
                {
                    response.Exception = ex;
                    response.ResponceCode = "Database Error";
                }
            }
            else
            {
                response.ResponceCode = "Failure";

                var sb = new StringBuilder();
                foreach (var rule in brokenRules)
                {
                    sb.AppendLine(rule.RuleDescription);
                }

                response.InvalidDataMessage = sb.ToString();
            }
            return response;
        }

        private Employee AssignAvailablePropertiesToDomain(InsertEmployeeProperties insertEmployeePorperties)
        {
            DateTime? nullableBirthDate = DateTimeHelper.ParseNullableDateTime(insertEmployeePorperties.BirthDate);
            DateTime? nullableHireDate = DateTimeHelper.ParseNullableDateTime(insertEmployeePorperties.HireDate);
            
            Gender gender;
            if (!Gender.TryParse(insertEmployeePorperties.Gender, out gender))
            {
                gender = Gender.Unknown;
            }

            Employee newEmployee = Employee.CreateEmployee(insertEmployeePorperties.FirstName, insertEmployeePorperties.LastName, nullableBirthDate,
                nullableHireDate, gender);

            return newEmployee;
        }

        public UpdateEmployeeResponse DeleteEmployee(DeleteEmployeeRequest deleteEmployeeRequest)
        {
            throw new System.NotImplementedException();
        }

        public ChangeEmployeeDepartmentResponse ChangeDepartment(ChangeEmployeeDepartmentRequest request)
        {
            throw new NotImplementedException();
        }

        public ChangeEmployeeSalaryResponse ChangeSalary(ChangeEmployeeSalaryRequest request)
        {
            var response = new ChangeEmployeeSalaryResponse();

            int empId;
            if (int.TryParse(request.Properties.EmployeeId, out empId))
            {
                
                try
                {

                    var employee = this.employeeRepository.FindById(empId);
                    var newSalary = this.AssignAvailablePropertiesToDomain(request.Properties, employee);

                    var brokenRules = newSalary.GetBrokenRules().ToList();

                    if (!brokenRules.Any())
                    {
                        var previousSalary = employee.Salaries.OrderByDescending(a => a.Id).FirstOrDefault();
                        if (previousSalary != null && previousSalary.UpdateFromDate(newSalary))
                        {
                            employee.AddSalary(newSalary);
                        }
                        else
                        {
                            response.Exception = new ArgumentOutOfRangeException(nameof(Salary.FromDate), "The From Date cannot be earlier the previous from date");

                        }
                        if(previousSalary == null)
                        {
                            employee.AddSalary(newSalary);
                        }
                        
                        this.employeeRepository.Save();
                    }
                    else
                    {
                        var sb = new StringBuilder();
                        sb.AppendLine("The Salary could not be added.");
                        foreach (var rule in brokenRules)
                        {
                            sb.AppendLine(rule.RuleDescription);
                        }
                        response.Exception = new ResourceNotFoundException("The salary could not be added.");
                    }

                }
                catch (Exception ex)
                {
                    response.Exception = ex;
                }

                
            }
            else
            {
                response.Exception =
                    new ResourceNotFoundException(string.Format("The requested Employee Id is not valid. '{0}'",
                        request.Properties.EmployeeId));
            }
            return response;

        }

        public ChangeEmployeeTitleResponse ChangeTitle(ChangeEmployeeTitleRequest request)
        {
            throw new NotImplementedException();
        }

        private Salary AssignAvailablePropertiesToDomain(SalaryProperties salaryProperties, Employee employee)
        {
            DateTime? nullableFromDate = DateTimeHelper.ParseNullableDateTime(salaryProperties.FromDate);
            double salaryAmount;
            double.TryParse(salaryProperties.Amount, out salaryAmount);

            Salary newSalary = Salary.CreateSalary(employee, salaryAmount, nullableFromDate);

            return newSalary;
        }


    }
}