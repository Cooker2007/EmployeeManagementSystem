using Infrastructure.Common.Domain;

namespace EMS.Domain
{
    public interface IEmployeeRepository : IRepository<Employee, int>
    {
        Employee FindByIdWithCurrentInfo(int id);
    }
}