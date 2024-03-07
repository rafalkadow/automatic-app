using Domain.Interfaces;

namespace Web.Api.Middlewares
{
    public class TransactionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<TransactionMiddleware> logger;

        public TransactionMiddleware(RequestDelegate next, ILogger<TransactionMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext httpContext, IDbContext dbContext)
        {
            if (httpContext.Request.Method.Equals("GET", StringComparison.CurrentCultureIgnoreCase))
            {
                await next(httpContext);
                return;
            }

            try
            {
                await dbContext.BeginTransactionAsync();
                await next(httpContext);
                await dbContext.CommitTransactionAsync();
            }
            catch (Exception ex)
            {
                logger.LogError($"Invoke(ex={ex})");
                await dbContext.RollbackTransactionAsync();
                throw;
            }
        }
    }
}