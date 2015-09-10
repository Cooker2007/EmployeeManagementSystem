using EMS.Domain;

namespace EMS.Data.Repositories
{
    using Infrastructure.Common;

    public class EmployeeRepository : RepositoryBase<Employee, int, EMSContext>, IEmployeeRepository
    {
        public EmployeeRepository(EMSContext context)
            : base(context)
        {
        }

        public Employee FindByIdWithCurrentInfo(int id)
        {
            var entity = this.Context.Employees.Find(id);

            return entity;
        }
    }
}