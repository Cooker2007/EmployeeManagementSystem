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

        public static bool IsBefore(this DateTime first,DateTime second)
        {
            if(first.CompareTo(second) < 0)
            {
                return true;
            }
            return false;
        }
    }
}
