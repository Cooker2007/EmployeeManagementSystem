using Infrastructure.Common.Domain;
using System.Collections.Generic;

namespace EMS.Domain
{
    public interface ISalaryRepository : IRepository<Salary, int>
    {
        IEnumerable<Salary> GetSalaryHistotyByEmployeeId(int employeeId);

        Salary GetEmployeeCurrentSalary(int employeeId);
    }
}