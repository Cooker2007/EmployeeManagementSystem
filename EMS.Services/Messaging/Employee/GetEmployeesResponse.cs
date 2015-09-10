using EMS.Services.ViewModels;
using System.Collections.Generic;

namespace EMS.Services.Messaging.Employee
{
    public class GetEmployeesResponse
    {
        public IEnumerable<EmployeeViewModel> Employees { get; set; }
    }
}