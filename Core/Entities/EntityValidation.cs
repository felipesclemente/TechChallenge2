using System.Text.RegularExpressions;

namespace Core.Entities
{
    public static class EntityValidation
    {
        public static void AssertStringIsNotEmptyOrNull(string value, string message)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new EntityException(message);
            }
        }

        public static void AssertIntIsWithinRange(int value, int min, int max, string message)
        {
            if (value < min || value > max)
            {
                throw new EntityException(message);
            }
        }

        public static void AssertStringIsUnderMaxLength(string value, int maxLength, string message)
        {
            if (!string.IsNullOrEmpty(value) && value.Length > maxLength)
            {
                throw new EntityException(message);
            }
        }

        public static void AssertEmailMatchesRegex(string value, string message)
        {
            var regexEmail = new Regex("^\\S+@\\S+\\.\\S+$");
            if (!string.IsNullOrEmpty(value) && !regexEmail.IsMatch(value))
            {
                throw new EntityException(message);
            }
        }
    }

    public class EntityException : Exception
    {
        public EntityException() { }

        public EntityException(string message) : base(message) { }

        public EntityException(string message, Exception inner) : base(message, inner) { }
    }
}
