using System.Collections.Generic;

namespace EMS.Domain
{
    using Infrastructure.Common.Domain;

    public interface IDepartmentRepository : IRepository<Department, string>
    {
        IEnumerable<string> GetDepartmentNames();

        IEnumerable<DepartmentEmployee> GetDepartmentHistoryByEmployeeId(int employeeId);

        IDictionary<string, string> GetDepartmentNameDictionary();
    }
}