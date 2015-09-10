using EMS.Services.ViewModels;

namespace EMS.Services.Messaging.Employee
{
    public class GetEmployeeResponse : ServiceResponseBase
    {
        public EmployeeViewModel Employee { get; set; }
    }
}