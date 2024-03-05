using Microsoft.AspNetCore.Http;

namespace Shared.Web
{
    public class FilterUtilityHelper
    {
        public static string GetValueRequest(string constNameFilter, HttpRequest request)
        {
            var valueRequest = request.Form[constNameFilter];
            return valueRequest;
        }

        public static decimal? GetValueRequestDecimal(string constNameFilter, HttpRequest request)
        {
            var valueRequest = request.Form[constNameFilter];
            decimal? returnValue = null;
            if (decimal.TryParse(valueRequest, out decimal value))
            {
                returnValue = value;
            }
            return returnValue;
        }

        public static int? GetValueRequestInt(string constNameFilter, HttpRequest request)
        {
            var valueRequest = request.Form[constNameFilter];
            int? returnValue = null;
            if (int.TryParse(valueRequest, out int value))
            {
                returnValue = value;
            }
            return returnValue;
        }
    }
}