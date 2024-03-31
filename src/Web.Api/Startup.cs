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

namespace Web.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private readonly IConfiguration Configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public void ConfigureServices(IServiceCollection services)
        {
            Application.ServiceCollection.Register(services);

            services.AddDbContext<IDbContext, ApplicationDbContext>(cfg =>
            {
                var connectionString = Configuration.GetConnectionString("DefaultConnection");
                cfg.UseSqlServer(connectionString, providerOptions =>
                {
                    providerOptions.CommandTimeout(180);// <--Timeout in seconds
                });
            }, ServiceLifetime.Scoped);

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
            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Files")),
            //    RequestPath = new PathString("/Files")
            //});
            app.UseRequestLocalizationByCulture();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHangfireDashboard("/jobs", new DashboardOptions
            {
                DashboardTitle = localizer["Automatic App Jobs"],
                //Authorization = new[] { new HangfireAuthorizationFilter() }
            });
            //app.UseEndpoints();
            app.ConfigureSwagger();
            app.Initialize(Configuration);
        }
    }
}