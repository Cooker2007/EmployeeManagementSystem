using Infrastructure.Common.Domain;
using System.Collections.Generic;

namespace EMS.Domain
{
    public interface ITitleRepository : IRepository<Title, int>
    {
        IEnumerable<Title> GetTitleHistory(int employeeId);

        Title GetEmployeeCurrentTitle(int employeeId);
    }
}