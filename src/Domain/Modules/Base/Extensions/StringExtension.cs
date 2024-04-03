using System.Globalization;

namespace Domain.Modules.Base.Extensions
{
    public static class StringExtension
    {
        public static string GetLast(this string source, int tail_length)
        {
            if (tail_length >= source.Length)
                return source;
            return source.Substring(source.Length - tail_length);
        }

        public static bool IsGuid(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;
            Guid x;
            return Guid.TryParse(value, out x);
        }

        public static string ToTitleCase(this string title)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(title.ToLower());
        }
    }
}