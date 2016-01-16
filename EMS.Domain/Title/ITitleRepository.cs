using System.Collections.Generic;
using Infrastructure.Common;

namespace EMS.Domain
{
    public interface ITitleRepository : IRepository<Title, int>
    {
        IEnumerable<Title> GetTitleHistory(int employeeId);

        Title GetEmployeeCurrentTitle(int employeeId);
    }
}