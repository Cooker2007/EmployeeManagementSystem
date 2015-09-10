using EMS.Services.Messaging.Salary;

namespace EMS.Services.Interfaces
{
    public interface ISalaryService
    {
        InsertSalaryResponse InsertSalary(InsertSalaryRequest request);
    }
}