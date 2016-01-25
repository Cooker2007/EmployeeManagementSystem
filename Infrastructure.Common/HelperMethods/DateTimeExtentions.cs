namespace System
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
            if (dateTimeA.HasValue && dateTimeB.HasValue)
            {
                return dateTimeA.Value.IsBefore(dateTimeB.Value);
            }
            return false;
        }
    }
}
