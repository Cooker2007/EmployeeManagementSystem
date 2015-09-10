namespace EMS.Services.Messaging.Employee
{
    public class GetEmployeeTitleHistoryRequest : IntegerIdRequest
    {
        public GetEmployeeTitleHistoryRequest(int id)
            : base(id)
        {
        }
    }
}