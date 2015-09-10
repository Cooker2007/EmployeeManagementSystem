using System;

namespace Infrastructure.Common.HelperMethods
{
    public static class DateTimeHelper
    {
       public static DateTime? ParseNullableDateTime(string s)
       {
           DateTime parsedDateTime;
           DateTime? nullableDateTime = DateTime.TryParse(s, out parsedDateTime) ? parsedDateTime : (DateTime?)null;
           return nullableDateTime;
       }


    }
}
