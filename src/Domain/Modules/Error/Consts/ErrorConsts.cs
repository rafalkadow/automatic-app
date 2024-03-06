using Shared.Web;

namespace Domain.Modules.Error.Consts
{
    [Serializable]
    public class ErrorConsts
    {
        public const string Url = "error";
        public const string ControllerName = "Error";
        public const string Title = "Error";
        
        public const string Error400 = "400";
        public const string Error401 = "401";
        public const string Error404 = "404";
        public const string Error500 = "500";

        public static string Error400Url => MyHttpContext.AppBaseUrl + $"/{ControllerName}/" + Error400;
        public static string Error401Url => MyHttpContext.AppBaseUrl + $"/{ControllerName}/" + Error401;
        public static string Error404Url => MyHttpContext.AppBaseUrl + $"/{ControllerName}/" + Error404;
        public static string Error500Url => MyHttpContext.AppBaseUrl + $"/{ControllerName}/" + Error500;
    }
}