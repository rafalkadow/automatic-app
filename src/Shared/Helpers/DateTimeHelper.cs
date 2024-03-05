using TimeZoneConverter;

namespace Shared.Helpers
{
    public static class DateTimeHelper
    {
        private const string DefaultTimeZoneId = "Central European Standard Time";

        /// <summary>
        /// For all data that needs constant reference over time
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime FromUtcToDefaultTimeZone(this DateTime dateTime)
        {
            if (dateTime.Kind == DateTimeKind.Local)
            {
                var dateTimeLocal = DateTime.SpecifyKind(dateTime, DateTimeKind.Local);
                return dateTimeLocal;
            }
            return TimeZoneInfo.ConvertTime(dateTime, TimeZoneInfo.Utc, TZConvert.GetTimeZoneInfo(DefaultTimeZoneId));
        }

        /// <summary>
        /// For all data that needs constant reference over time
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime FromDefaultTimeZoneToUtc(this DateTime dateTime)
        {
            if (dateTime.Kind == DateTimeKind.Local)
            {
                var dateTimeLocal = DateTime.SpecifyKind(dateTime, DateTimeKind.Local);
                dateTimeLocal = TimeZoneInfo.ConvertTimeToUtc(dateTimeLocal);

                return dateTimeLocal;
            }
            if (dateTime.Kind == DateTimeKind.Utc)
            {
                return dateTime;
            }
            return TimeZoneInfo.ConvertTime(dateTime, TZConvert.GetTimeZoneInfo(DefaultTimeZoneId), TimeZoneInfo.Utc);
        }
    }
}