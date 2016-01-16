using Infrastructure.Common;
using Infrastructure.Common.Domain;

namespace EMS.Domain
{
    public static class DepartmentEmployeeBusinessRule
    {
        //ToDate field- Handled Internally
        public static readonly BusinessRule DepartmentEmployeeToDateIsAfterFromDate = new BusinessRule("A Titles's \"To Date\" must be after the \"From Date\".");
    }
}