using Infrastructure.Common;
using Infrastructure.Common.Domain;

namespace EMS.Domain
{
    public static class EmployeeBusinessRule
    {
        // First Name
        public static readonly BusinessRule EmployeeFirstNameRequired = new BusinessRule("An Employee must have a first name.");

        // Last Name
        public static readonly BusinessRule EmployeeLastNameRequired = new BusinessRule("An Employee must have a last name.");

        // Gender
        public static readonly BusinessRule EmployeeGenderRequired = new BusinessRule("An Employee must have a gender.");

        // Birth Date
        public static readonly BusinessRule EmployeeBirthDateRequired = new BusinessRule("An Employee must have a Birth Date");

        public static readonly BusinessRule EmployeeBirthDateNotInFuture = new BusinessRule("An Employee cannot have a Birth Date set after today's date.");

        // Hire Date
        public static readonly BusinessRule EmployeeHireDateRequired = new BusinessRule("An Employee must have a Hired On Date.");

        public static readonly BusinessRule EmployeeHiredAfterBorn = new BusinessRule("An Employee cannot have a Hired On Date before their Birth Date");

        // public static readonly BusinessRule  = new BusinessRule("");
    }
}