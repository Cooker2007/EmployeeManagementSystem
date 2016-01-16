using System.Collections.Generic;
using Infrastructure.Common;

namespace EMS.Domain
{
    public interface IDepartmentRepository : IRepository<Department, string>
    {
        IEnumerable<string> GetDepartmentNames();

        IEnumerable<DepartmentEmployee> GetDepartmentHistoryByEmployeeId(int employeeId);

        IDictionary<string, string> GetDepartmentNameDictionary();
    }
}