using System.Collections.Generic;
using Infrastructure.Common;

namespace EMS.Domain
{
    public interface ISalaryRepository : IRepository<Salary, int>
    {
        IEnumerable<Salary> GetSalaryHistotyByEmployeeId(int employeeId);

        Salary GetEmployeeCurrentSalary(int employeeId);
    }
}