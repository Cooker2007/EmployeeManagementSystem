namespace EMS.Services.Messaging.Salary
{
    public class InsertSalaryRequest : IntegerIdRequest
    {
        public InsertSalaryRequest(int id)
            : base(id)
        {
        }
    }
}