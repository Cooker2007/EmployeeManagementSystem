using Infrastructure.Common;
using Infrastructure.Common.Domain;

namespace EMS.Domain
{
    public static class TitleBusinessRule
    {
        //Name field
        public static readonly BusinessRule TitleNameRequired = new BusinessRule("A Title requires words.");

        //ToDate field- Handled Internally
        public static readonly BusinessRule TitleToDateIsAfterFromDate = new BusinessRule("A Titles's \"To Date\" must be after the \"From Date\".");
    }
}