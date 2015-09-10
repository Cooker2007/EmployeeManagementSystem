namespace EMS.Services.Messaging.Employee
{
    public class ChangeEmployeeTitleRequest : IntegerIdRequest
    {
        public ChangeEmployeeTitleRequest(int id) : base(id)
        {
        }
    }
}