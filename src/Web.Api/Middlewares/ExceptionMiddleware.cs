using Microsoft.AspNetCore.Http.Extensions;

namespace Web.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception exception)
            {
                logger.LogError($"Invoke(exception={exception})");
                logger.LogError($"Invoke(exception.Message={exception.Message})");
                httpContext.Response.Clear();
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                var url = httpContext.Request.GetEncodedUrl();
                httpContext.Response.Redirect("/error/500/Url?errorUrl=" + url);
                logger.LogError($"Invoke(exception.url={url})");
                await httpContext.Response.WriteAsync(exception.ToString());
                throw;
            }
        }
    }
}