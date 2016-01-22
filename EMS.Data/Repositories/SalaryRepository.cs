using EMS.Domain;
using Infrastructure.Common;
using System.Collections.Generic;
using System.Linq;

namespace EMS.Data.Repositories
{
    public class SalaryRepository : RepositoryBase<Salary, int, EMSContext>, ISalaryRepository
    {
        public SalaryRepository(EMSContext context)
            : base(context)
        {
        }

        /// <summary>
        /// Get the Salary records of an Employee.
        /// </summary>
        /// <param name="employeeId">The Id of the Employee.</param>
        /// <returns>Returns an IEnumerable of Salary Entities.</returns>
        public IEnumerable<Salary> GetSalaryHistotyByEmployeeId(int employeeId)
        {
            IEnumerable<Salary> salaryHistory = this.Context.Salaries
                .Where(e => e.EmployeeId == employeeId)
                .OrderByDescending(e => e.DatabaseId)
                .ToList();

            return salaryHistory;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="employeeId">The Id of the Employee.</param>
        /// <returns>Returns the Employees current Salary.</returns>
        public Salary GetEmployeeCurrentSalary(int employeeId)
        {
            var salary = this.Context.Salaries
                .Where(e => e.EmployeeId == employeeId)
                .OrderByDescending(e => e.DatabaseId)
                .FirstOrDefault();

            return salary;
        }
    }
}