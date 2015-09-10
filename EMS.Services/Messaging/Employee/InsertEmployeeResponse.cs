namespace EMS.Services.Messaging.Employee
{
    public class InsertEmployeeResponse : ServiceResponseBase
    {
        public string ResponceCode { get; set; }

        public string InvalidDataMessage { get; set; }

        public string EmployeeId { get; set; }

    }
}