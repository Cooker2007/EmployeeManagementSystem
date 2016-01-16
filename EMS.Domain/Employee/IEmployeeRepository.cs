using Infrastructure.Common;

namespace EMS.Domain
{
    public interface IEmployeeRepository : IRepository<Employee, int>
    {
        Employee FindByIdWithCurrentInfo(int id);
    }
}