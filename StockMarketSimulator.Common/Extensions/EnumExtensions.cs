using System.ComponentModel;

namespace StockMarketSimulator.Common.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            Type enumType = value.GetType();
            var memberInfo = enumType.GetMember(value.ToString());

            if (memberInfo.Length > 0)
            {
                var attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attributes.Length > 0)
                {
                    return ((DescriptionAttribute)attributes[0]).Description;
                }
            }

            return value.ToString();
        }
    }
}