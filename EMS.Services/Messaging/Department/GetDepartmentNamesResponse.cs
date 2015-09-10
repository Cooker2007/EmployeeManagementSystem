using EMS.Services.ViewModels;

namespace EMS.Services.Messaging.Department
{
    public class GetDepartmentNamesResponse : ServiceResponseBase
    {
        public DepartmentNamesViewModel Departments { get; set; }
    }
}