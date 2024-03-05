using System.Globalization;
using System.Text.RegularExpressions;
using Shared.Helpers;

namespace Shared.Extensions.Reports
{
    [Serializable]
    public static class StringStandardizer
    {
        public static string Standardize(this List<string> value)
        {
            if (value != null)
            {
                return string.Join(", ", value);
            }
            return "";
        }

        public static string Standardize(this object value, string intFormat = null, string dateTimeFormat = null, string nullValue = "")
        {
            if (value == null)
            {
                return nullValue;
            }

            switch (value)
            {
                case int intValue:
                    if (intFormat != null)
                    {
                        return intValue.ToString(intFormat);
                    }
                    return intValue.ToString();

                case decimal decimalValue:
                    if (intFormat != null)
                    {
                        return decimalValue.ToString(intFormat);
                    }
                    return decimalValue.ToString("# ### ##0.00", new CultureInfo("pl-PL", false).NumberFormat);

                case DateTime dateTimeValue:

                    if (dateTimeFormat != null)
                    {
                        return dateTimeValue.FromUtcToDefaultTimeZone().ToString(dateTimeFormat);
                    }
                    if (dateTimeValue == DateTime.MinValue)
                    {
                        return "";
                    }
                    return dateTimeValue.FromUtcToDefaultTimeZone().ToString("yyyy-MM-dd HH:mm:ss");

                case bool boolValue:
                    return boolValue ? "Tak" : "Nie";

                case string stringValue:
                    value = Regex.Replace(stringValue, @"\t|\n|\r", "");
                    break;
            }

            return value.ToString();
        }
    }
}