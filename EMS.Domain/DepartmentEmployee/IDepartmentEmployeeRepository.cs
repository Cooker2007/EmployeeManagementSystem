using Infrastructure.Common.Domain;
using System.Collections.Generic;

namespace EMS.Domain
{
    public interface IDepartmentEmployeeRepository : IRepository<DepartmentEmployee, int>
    {
        IEnumerable<DepartmentEmployee> GetDepartmentEmployeeHistory(int employeeId);
    }
}