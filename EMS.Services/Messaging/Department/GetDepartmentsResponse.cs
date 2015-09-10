using EMS.Services.ViewModels;
using System.Collections.Generic;

namespace EMS.Services.Messaging.Department
{
    public class GetDepartmentsResponse : ServiceResponseBase
    {
        public IEnumerable<DepartmentViewModel> Departments { get; set; }
    }
}