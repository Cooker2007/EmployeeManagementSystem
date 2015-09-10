namespace EMS.Services.Messaging.Employee
{
    public class GetEmployeeDepartmentHistoryRequest : IntegerIdRequest
    {
        public GetEmployeeDepartmentHistoryRequest(int id)
            : base(id)
        {
        }
    }
}