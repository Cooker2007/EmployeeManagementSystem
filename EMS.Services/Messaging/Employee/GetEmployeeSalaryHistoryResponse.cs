using EMS.Services.ViewModels;
using System.Collections.Generic;

namespace EMS.Services.Messaging.Employee
{
    public class GetEmployeeSalaryHistoryResponse : ServiceResponseBase
    {
        public IEnumerable<SalaryViewModel> SalaryHistory { get; set; }
    }
}