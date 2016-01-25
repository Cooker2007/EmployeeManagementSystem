namespace System
{
    public static class DateTimeHelper
    {
        /// <summary>
        /// Converts the string representation of a date and time to its <see cref="T:Nullable{System.DateTime}"/> equivalent.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static DateTime? ParseNullableDateTime(string input)
        {
            DateTime parsedDateTime;
            var nullableDateTime = DateTime.TryParse(input, out parsedDateTime) ? parsedDateTime : (DateTime?) null;
            return nullableDateTime;
        }

        /// <summary>
        /// Compares the value of this instance to a specified <see cref="T:System.DateTime"/> value and returns a <see cref="T:bool"/> that indicates whether this instance is before than or after than the specified <see cref="T:System.DateTime"/> value.
        /// </summary>
        /// <param name="dateTimeA">This <see cref="T:System.DateTime"/> instance.</param>
        /// <param name="dateTimeB">The <see cref="T:System.DateTime"/> to compare.</param>
        /// <returns>
        /// True if <paramref name="dateTimeA"/> is before <paramref name="dateTimeB"/>.
        /// False if <paramref name="dateTimeA"/> is equal or after <paramref name="dateTimeB"/>.
        /// </returns>
        public static bool IsBefore(this DateTime dateTimeA, DateTime dateTimeB)
        {
            return dateTimeA.CompareTo(dateTimeB) < 0;
        }

        /// <summary>
        /// Compares the value of this instance to a specified <see cref="T:Nullable{System.DateTime}"/> value and returns a <see cref="T:bool"/> that indicates whether this instance is before than or after than the specified <see cref="T:Nullable{System.DateTime}"/> value.
        /// </summary>
        /// <param name="dateTimeA">This <see cref="T:Nullable{System.DateTime}"/> instance.</param>
        /// <param name="dateTimeB">The <see cref="T:Nullable{System.DateTime}"/> to compare.</param>
        /// <returns>
        /// True if the value of <paramref name="dateTimeA"/> is before the value of <paramref name="dateTimeB"/>,
        /// false if the value of <paramref name="dateTimeA"/> is equal or after the value of <paramref name="dateTimeB"/>.
        /// </returns>
        public static bool IsBefore(this DateTime? dateTimeA, DateTime? dateTimeB)
        {
            if (dateTimeA.HasValue && dateTimeB.HasValue)
            {
                return dateTimeA.Value.IsBefore(dateTimeB.Value);
            }
            return false;
        }
    }
}
