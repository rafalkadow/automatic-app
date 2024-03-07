using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Application.Extensions;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Configuration;
using System.Reflection;

namespace Web.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
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

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddControllers();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Employee API",
                    Version = "v1",
                    Description = "An API to perform Employee operations",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "John Walkner",
                        Email = "John.Walkner@gmail.com",
                        Url = new Uri("https://twitter.com/jwalkner"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Employee API LICX",
                        Url = new Uri("https://example.com/license"),
                    }
                });

                c.SchemaFilter<SwaggerSkipPropertyFilter>();
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
     
                var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                c.SchemaFilter<SwaggerSchemaFilter>();

                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));
            });
            //services.AddSwaggerSetup();
            services.AddCors(options =>
            {
                options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
  
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
        
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CQRS Ninja API v1");
            });

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();
            app.UseCors("Open");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
