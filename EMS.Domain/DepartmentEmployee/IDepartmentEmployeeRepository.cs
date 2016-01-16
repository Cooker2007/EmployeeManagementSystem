using System.Collections.Generic;
using Infrastructure.Common;

namespace EMS.Domain
{
    public interface IDepartmentEmployeeRepository : IRepository<DepartmentEmployee, int>
    {
        IEnumerable<DepartmentEmployee> GetDepartmentEmployeeHistory(int employeeId);
    }
}