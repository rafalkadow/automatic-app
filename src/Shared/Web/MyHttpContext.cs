using Microsoft.AspNetCore.Http;

namespace Shared.Web
{
    public class MyHttpContext
    {
        private static IHttpContextAccessor? m_httpContextAccessor;

        public static HttpContext Current
        {
            get
            {
                return m_httpContextAccessor.HttpContext;
            }
        }

        public static string AppBaseUrl => $"{Current.Request.Scheme}://{Current.Request.Host}{Current.Request.PathBase}";

        public static string AppFullUrl => $"{Current.Request.Scheme}://{Current.Request.Host}{Current.Request.PathBase}{Current.Request.Path}/{Current.Request.QueryString}";

        public static void Configure(IHttpContextAccessor contextAccessor)
        {
            m_httpContextAccessor = contextAccessor;
        }

        public static string LanguageCode()
        {
            System.Globalization.CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            var languageCode = cultureInfo.Name;
            return languageCode;
        }

        public static string GetBaseUrl(string urlAdd = null)
        {
            string url = MyHttpContext.AppBaseUrl;

            if (!string.IsNullOrEmpty(urlAdd))
                url = url + "/" + urlAdd;
            return url;
        }

    }
}