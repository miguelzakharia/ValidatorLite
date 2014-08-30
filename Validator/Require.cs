using System;

namespace Validator
{
    public static class Require
    {
        public static void Argument(object argumentValue, string argumentName)
        {
            Argument(argumentValue, "Argument cannot be null.", argumentName);
        }

        public static void Argument(object argumentValue, string exceptionMessage, string argumentName)
        {
            var message = string.IsNullOrEmpty(exceptionMessage) ? "Argument cannot be null" : exceptionMessage;
            if (argumentValue == null)
            {
                throw new ArgumentException(message, argumentName);
            }
        }
    }
}
