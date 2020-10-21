using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Judges.Data;
using Judges.Models.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Judges
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup()
        {
            string envType = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            if (string.IsNullOrEmpty(envType))
            {
                envType = Debugger.IsAttached ? "Development" : "Release";
            }

            string settingsName = envType == "Development" ? "appsettings.Development.json" : "appsettings.json";

            IConfigurationBuilder builder = new ConfigurationBuilder()
                .AddJsonFile(settingsName, false, true);

            configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            AppSettings settings = new AppSettings();
            configuration.Bind(settings);

            services
                .RegisterLogicServices()
                .Configure<AppSettings>(configuration)
                .AddDbContext<JudgesContext>(o =>
                {
                    o.UseNpgsql(settings.Connection.DatabaseConnection);

                    o.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddDebug()));
                })
                .AddSwaggerGen(o =>
                {
                    o.SwaggerDoc("v1", new OpenApiInfo() { Title = "Judges", Version = "v1" });

                    string xmlPath = Path.Combine(
                        AppContext.BaseDirectory,
                        $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
                })
                .AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(c => c.MapControllers());
            app.UseSwagger().UseSwaggerUI(o => o.SwaggerEndpoint("v1/swagger.json", "Judges"));
        }
    }
}
