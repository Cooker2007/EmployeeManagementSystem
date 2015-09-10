using Infrastructure.Common.Domain;

namespace EMS.Domain
{
    public static class SalaryBusinessRule
    {
        // Amount
        //public static readonly BusinessRule SalaryAmountRequired = new BusinessRule("A Salary must have an amount.");

        public static readonly BusinessRule SalaryAmountMustBePositive = new BusinessRule("A Salary must be more then $0.00.");

        //ToDate
        public static readonly BusinessRule SalaryToDateIsAfterFromDate = new BusinessRule("A Salary's \"To Date\" must be after the \"From Date\".");

        //EmployeeId
        //public static readonly BusinessRule EmployeeIdExists = new BusinessRule("The Employee Id must exist.");

        //FromDate
        public static readonly BusinessRule FromDateAfterPreviousFromDate = new BusinessRule("A Salary cannot take affect before a previous Salary");
        public static readonly BusinessRule FromDateMustExist = new BusinessRule("A Salary must have a From Date.");
        public static readonly BusinessRule ToDateMustExist = new BusinessRule("A Salary must have a To Date.");
    }
}