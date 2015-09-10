namespace EMS.Services.Messaging.Employee
{
    public class DeleteEmployeeRequest : IntegerIdRequest
    {
        public DeleteEmployeeRequest(int employeeId)
            : base(employeeId)
        {
        }
    }
}