using Infrastructure.Common.Domain;

namespace EMS.Domain
{
    public static class DepartmentBusinessRule
    {
        //Name field
        public static readonly BusinessRule DepartmentNameRequired = new BusinessRule("A Department requires a name.");
    }
}