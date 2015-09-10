using EMS.Services.ViewModels;

namespace EMS.Services.Messaging.Employee
{
    public class GetEmployeeSalaryResponse : ServiceResponseBase
    {
        public SalaryViewModel Salary { get; set; }
    }
}