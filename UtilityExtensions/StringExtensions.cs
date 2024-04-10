using Ardalis.GuardClauses;

namespace UtilityExtensions
{
    public static class StringExtensions
    {
        public static double Todouble(this string value)
        {
            Guard.Against.NullOrEmpty(value, nameof(value));

            bool isSuccess = double.TryParse(value, out double result);

            if (!isSuccess)
            {
                throw new ArgumentException($"The provided string '{value}' cannot be converted to double.", nameof(value));
            }

            return result;
        }
    }
}
