
namespace Validator.Extensions
{
    public static class StringExtensions
    {
        public static bool MeetsLengthRequirements(this string input, int mininumLength, int maximumLength)
        {
            return input.Length >= mininumLength && input.Length <= maximumLength;
        }

        public static bool LengthIsExactly(this string input, int length)
        {
            return input.Length == length;
        }

        public static bool LengthIsAtLeast(this string input, int minimumLength)
        {
            return input.Length >= minimumLength;
        }

        public static bool LengthIsNotLongerThan(this string input, int maximumLength)
        {
            return input.Length <= maximumLength;
        }

        public static bool IsEmptyOrAtLeast(this string input, int minimumLength)
        {
            return string.IsNullOrEmpty(input) || input.Length >= minimumLength;
        }
    }
}
