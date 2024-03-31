namespace Web.Api.Extensions
{
    internal static class HostBuilderExtensions
    {
        internal static IHostBuilder UseSerilog(this IHostBuilder builder)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Development.json")
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
            //Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
            //SerilogHostBuilderExtensions.UseSerilog(builder);
            return builder;
        }
    }
}