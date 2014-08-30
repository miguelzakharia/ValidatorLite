using System;

namespace Validator.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool IsWithinRange(this DateTime input, DateTime lowerBound, DateTime upperBound)
        {
            return input >= lowerBound && input <= upperBound;
        }
    }
}
