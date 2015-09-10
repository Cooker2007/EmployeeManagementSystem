namespace EMS.Services.Messaging.Employee
{
    public class GetEmployeeSalaryHistoryRequest : IntegerIdRequest
    {
        public GetEmployeeSalaryHistoryRequest(int id)
            : base(id)
        {
        }
    }
}