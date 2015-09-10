namespace EMS.Services.ViewModels
{
    /// <summary>
    /// Basic Salary properties for exporting date from the domain.
    /// </summary>
    public class SalaryViewModel
    {
        public string Amount { get; set; }

        public string EmployeeId { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }
    }
}