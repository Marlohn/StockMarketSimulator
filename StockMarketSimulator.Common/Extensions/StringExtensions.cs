using Ardalis.GuardClauses;

namespace StockMarketSimulator.Common.Extensions
{
    public static class StringExtensions
    {
        public static float ToFloat(this string value)
        {
            Guard.Against.NullOrEmpty(value, nameof(value));

            bool isSuccess = float.TryParse(value, out float result);

            if (!isSuccess)
            {
                throw new ArgumentException($"The provided string '{value}' cannot be converted to float.", nameof(value));
            }

            return result;
        }
    }
}
