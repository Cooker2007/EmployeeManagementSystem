using System.Collections.Generic;
using System.Linq;

namespace EMS.Data.Repositories
{
    using EMS.Domain;

    using Infrastructure.Common;

    public class DepartmentRepository : RepositoryBase<Department, string, EMSContext>, IDepartmentRepository
    {
        public DepartmentRepository(EMSContext context)
            : base(context)
        {
        }

        /// <summary>
        /// Get an IEnumerable of the current Department Names.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetDepartmentNames()
        {
            IEnumerable<string> departmentNames;
            using (var context = new EMSContext())
            {
                departmentNames = context.Departments.Select(name => name.Name).ToList();
            }
            return departmentNames;
        }

        /// <summary>
        /// Gets the Department Entities of an Employee showing which Departments they worked in.
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns>Returns an IEnumerable in descending ordered by the FromDate.</returns>
        public IEnumerable<DepartmentEmployee> GetDepartmentHistoryByEmployeeId(int employeeId)
        {
            IEnumerable<DepartmentEmployee> deparmentEmployeeHistory =
                this.Context.DepartmentEmployees.Where(e => e.EmployeeId == employeeId)
                    .OrderByDescending(e => e.FromDate)
                    .ToList();
            return deparmentEmployeeHistory;
        }


        /// <summary>
        /// Gets a Dictionary of the Departments Id with the Departments Name.
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, string> GetDepartmentNameDictionary()
        {
            var departmentNameDictionary = new Dictionary<string, string>();

            var temp = from d in this.Context.Departments
                       select new { d.Id, d.Name };

            foreach (var d in temp)
            {
                departmentNameDictionary.Add(d.Id, d.Name);
            }
            return departmentNameDictionary;
        }
    }
}