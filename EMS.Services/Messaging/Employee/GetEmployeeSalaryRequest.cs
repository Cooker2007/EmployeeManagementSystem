namespace EMS.Services.Messaging.Employee
{
    public class GetEmployeeSalaryRequest : IntegerIdRequest
    {
        public GetEmployeeSalaryRequest(int id)
            : base(id)
        {
        }
    }
}