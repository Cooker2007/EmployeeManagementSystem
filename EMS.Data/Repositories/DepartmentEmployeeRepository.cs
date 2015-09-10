using EMS.Domain;
using Infrastructure.Common;
using System.Collections.Generic;
using System.Linq;

namespace EMS.Data.Repositories
{
    public class DepartmentEmployeeRepository : RepositoryBase<DepartmentEmployee, int, EMSContext>, IDepartmentEmployeeRepository
    {
        public DepartmentEmployeeRepository(EMSContext context)
            : base(context)
        {
        }

        /// <summary>
        /// Gets the all records of an Employee showing which Departments they worked in.  
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns>Returns an IEnumerable in descending ordered by the FromDate.</returns>
        public IEnumerable<DepartmentEmployee> GetDepartmentEmployeeHistory(int employeeId)
        {
            IEnumerable<DepartmentEmployee> departmentEmployeeHistory =
                this.Context.DepartmentEmployees.Where(e => e.EmployeeId == employeeId)
                    .OrderByDescending(e => e.FromDate);

            return departmentEmployeeHistory;
        }
    }
}