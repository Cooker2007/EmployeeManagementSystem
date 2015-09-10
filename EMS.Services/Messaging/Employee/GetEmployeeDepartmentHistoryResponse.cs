using EMS.Services.ViewModels;
using System.Collections.Generic;

namespace EMS.Services.Messaging.Employee
{
    public class GetEmployeeDepartmentHistoryResponse : ServiceResponseBase
    {
        public IEnumerable<DepartmentEmployeeHistoryViewModel> DepartmentHistory { get; set; }
    }
}