using EMS.Domain;
using EMS.Services.ViewModels;
using System;
using System.Collections.Generic;

namespace EMS.Services.ConversionHelper
{
    public static class ConversionHelper
    {
        public static EmployeeViewModel ConvertToViewModel(this Employee employee)
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel()
            {
                BirthDate = employee.BirthDate.Value.ToShortDateString(),
                CurrentDepartment = string.Empty,
                CurrentManager = string.Empty,
                CurrentSalary = string.Empty,
                CurrentTitle = string.Empty,
                Id = employee.Id.ToString(),
                FirstName = employee.FirstName,
                Gender = employee.Gender.DisplayName,
                HireDate = employee.HireDate.Value.ToShortDateString(),
                LastName = employee.LastName,
            };

            return employeeViewModel;
        }

        public static EmployeeViewModel ConvertToViewModel(this Employee employee, Department department, Employee manager, Salary salary, Title title)
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel()
            {
                BirthDate = employee.BirthDate.Value.ToShortDateString(),
                CurrentManager = string.Empty,
                Id = employee.Id.ToString(),
                FirstName = employee.FirstName,
                Gender = employee.Gender.DisplayName,
                HireDate = employee.HireDate.Value.ToShortDateString(),
                LastName = employee.LastName,
            };

            if (manager != null)
            {
                employeeViewModel.CurrentManager = manager.FirstName + " " + manager.LastName;
            }

            if (department != null)
            {
                employeeViewModel.CurrentDepartment = department.Name;
            }
            if (salary != null)
            {
                employeeViewModel.CurrentSalary = salary.Amount.ToString();
            }
            if (title != null)
            {
                employeeViewModel.CurrentTitle = title.Name;
            }

            return employeeViewModel;
        }

        public static SalaryViewModel ConvertToViewModel(this Salary salary)
        {
            SalaryViewModel salaryViewModel = new SalaryViewModel()
            {
                EmployeeId = salary.EmployeeId.ToString(),
                Amount = salary.Amount.ToString(),
                FromDate = salary.FromDate.Value.ToShortDateString(),
                ToDate = salary.ToDate.Value.ToShortDateString(),
            };

            return salaryViewModel;
        }

        public static IEnumerable<SalaryViewModel> ConvertToViewModels(this IEnumerable<Salary> salaries)
        {
            List<SalaryViewModel> convertedSalaries = new List<SalaryViewModel>();

            foreach (var salary in salaries)
            {
                convertedSalaries.Add(salary.ConvertToViewModel());
            }
            return convertedSalaries;
        }

        public static TitleViewModel ConvertToViewModel(this Title title)
        {
            TitleViewModel titleViewModel = new TitleViewModel
            {
                EmployeeId = title.EmployeeId.ToString(),
                FromDate = title.FromDate.Value.ToShortDateString(),
                Title = title.Name,
                ToDate = title.ToDate.Value.ToShortDateString(),
            };
            return titleViewModel;
        }

        public static IEnumerable<TitleViewModel> ConvertToViewModels(this IEnumerable<Title> titles)
        {
            List<TitleViewModel> convertedTitles = new List<TitleViewModel>();

            foreach (var title in titles)
            {
                convertedTitles.Add(title.ConvertToViewModel());
            }

            return convertedTitles;
        }

        public static DepartmentEmployeeHistoryViewModel ConvertToViewModel(this DepartmentEmployee departmentEmployee, IDictionary<string, string> departmentNameDictionary)
        {
            DepartmentEmployeeHistoryViewModel departmentEmployeeHistoryViewModel = new DepartmentEmployeeHistoryViewModel
            {
                DepartmentId = departmentEmployee.DepartmentId,
                FromDate = departmentEmployee.FromDate.Value.ToShortDateString(),
                ToDate = departmentEmployee.ToDate.Value.ToShortDateString(),
            };

            string deptName;
            if (departmentNameDictionary.TryGetValue(departmentEmployee.DepartmentId, out deptName))
            {
                departmentEmployeeHistoryViewModel.DepartmentName = deptName;
            }
            else
            {
                departmentEmployeeHistoryViewModel.DepartmentName = string.Empty;
            }

            return departmentEmployeeHistoryViewModel;
        }

        public static IEnumerable<DepartmentEmployeeHistoryViewModel> ConvertToViewModels(this IEnumerable<DepartmentEmployee> departmentEmployees, IDictionary<string, string> departmentNameDictionary)
        {
            List<DepartmentEmployeeHistoryViewModel> convertedDepartmentEmployees = new List<DepartmentEmployeeHistoryViewModel>();

            foreach (var de in departmentEmployees)
            {
                convertedDepartmentEmployees.Add(de.ConvertToViewModel(departmentNameDictionary));
            }
            return convertedDepartmentEmployees;
        }
    }
}