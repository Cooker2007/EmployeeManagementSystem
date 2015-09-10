namespace EMS.Services.Messaging.Employee
{
    public class GetEmployeeRequest : IntegerIdRequest
    {
        public GetEmployeeRequest(int employeeId)
            : base(employeeId)
        {
        }
    }
}