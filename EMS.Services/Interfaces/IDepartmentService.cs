using EMS.Services.Messaging.Department;

namespace EMS.Services.Interfaces
{
    public interface IDepartmentService
    {
        GetDepartmentsResponse GetAllDepartments();

        GetDepartmentNamesResponse GetDepartmentNames();
    }
}