﻿using Application.Configurations;
using Shared.Interfaces.Services;

namespace Web.Api.Extensions
{
    internal static class ApplicationBuilderExtensions
    {
        internal static IApplicationBuilder UseExceptionHandling(
            this IApplicationBuilder app,
            IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }

            return app;
        }

        internal static IApplicationBuilder UseForwarding(this IApplicationBuilder app, IConfiguration configuration)
        {
            AppConfiguration config = GetApplicationSettings(configuration);
            if (config.BehindSSLProxy)
            {
                app.UseCors();
                app.UseForwardedHeaders();
            }

            return app;
        }

        internal static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", typeof(Program).Assembly.GetName().Name);
                options.RoutePrefix = "swagger";
                options.DisplayRequestDuration();
            });
        }

        //internal static IApplicationBuilder UseEndpoints(this IApplicationBuilder app)
        //    => app.UseEndpoints(endpoints =>
        //    {
        //        endpoints.MapRazorPages();
        //        endpoints.MapControllers();
        //        endpoints.MapFallbackToFile("index.html");
        //        endpoints.MapHub<SignalRHub>(ApplicationConstants.SignalR.HubUrl);
        //    });

        internal static IApplicationBuilder UseRequestLocalizationByCulture(this IApplicationBuilder app)
        {
            //var supportedCultures = LocalizationConstants.SupportedLanguages.Select(l => new CultureInfo(l.Code)).ToArray();
            //app.UseRequestLocalization(options =>
            //{
            //    options.SupportedUICultures = supportedCultures;
            //    options.SupportedCultures = supportedCultures;
            //    options.DefaultRequestCulture = new RequestCulture(supportedCultures.First());
            //    options.ApplyCurrentCultureToResponseHeaders = true;
            //});

            //app.UseMiddleware<RequestCultureMiddleware>();

            return app;
        }

        internal static IApplicationBuilder Initialize(this IApplicationBuilder app, IConfiguration _configuration)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var initializers = serviceScope.ServiceProvider.GetServices<IDatabaseSeeder>();

            foreach (var initializer in initializers)
            {
                initializer.Initialize();
            }

            return app;
        }

        private static AppConfiguration GetApplicationSettings(IConfiguration configuration)
        {
            var applicationSettingsConfiguration = configuration.GetSection(nameof(AppConfiguration));
            return applicationSettingsConfiguration.Get<AppConfiguration>();
        }
    }
}