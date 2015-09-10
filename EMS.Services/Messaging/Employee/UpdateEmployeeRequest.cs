using EMS.Services.ViewModels;

namespace EMS.Services.Messaging.Employee
{
    public class UpdateEmployeeRequest : IntegerIdRequest
    {
        public UpdateEmployeeRequest(int employeeId)
            : base(employeeId)
        {
        }

        public EmployeePorperties EmployeePorperties { get; set; }
    }
}