namespace EMS.Services.Messaging.Employee
{
    public class ChangeEmployeeDepartmentRequest : IntegerIdRequest
    {
        public ChangeEmployeeDepartmentRequest(int id) : base(id)
        {
        }
    }
}