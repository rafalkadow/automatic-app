using Domain.Interfaces;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Localization;
using Persistence.Context;
using Web.Api.Extensions;
using Application.Extensions;
using Asp.Versioning;
using Persistence;
using Shared.Interfaces.Services;
using Application;
using Application.Interfaces.Services;

namespace Web.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private readonly IConfiguration Configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.Register();

            services.AddDbContext<IDbContext, ApplicationDbContext>(cfg =>
            {
                var connectionString = Configuration.GetConnectionString("DefaultConnection");
                cfg.UseSqlServer(connectionString, providerOptions =>
                {
                    providerOptions.CommandTimeout(180);// <--Timeout in seconds
                });
            }, ServiceLifetime.Scoped).AddTransient<IDatabaseSeeder, DatabaseSeeder>(); ;

            services.AddIfrastructure();
            services.AddForwarding(Configuration);
            services.AddLocalization(options =>
            {
                options.ResourcesPath = "Resources";
            });
            services.AddCurrentUserService();
            services.AddSerialization();

            services.AddServerLocalization();
            services.AddIdentity();
            services.AddJwtAuthentication(services.GetApplicationSettings(Configuration));
            services.AddSignalR();
            services.AddApplicationServices();
            services.AddSharedInfrastructure(Configuration);
            services.RegisterSwagger();
            //services.AddInfrastructureMappings();
            services.AddHangfire(x => x.UseSqlServerStorage(Configuration.GetConnectionString("DefaultConnection")));
            services.AddHangfireServer();
            services.AddControllers().AddValidators();
            services.AddExtendedAttributesValidators();
            //services.AddExtendedAttributesHandlers();
            services.AddRazorPages();
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });
            services.AddLazyCache();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IStringLocalizer<Startup> localizer)
        {
            app.UseForwarding(Configuration);
            app.UseExceptionHandling(env);
            app.UseHttpsRedirection();
            //app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRequestLocalizationByCulture();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHangfireDashboard("/jobs", new DashboardOptions
            {
                DashboardTitle = localizer["Automatic App Jobs"],
            });
            app.UseEndpoints();
            app.ConfigureSwagger();
            app.Initialize(Configuration);
        }
    }
}