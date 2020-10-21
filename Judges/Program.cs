using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Judges
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseKestrel((hostingContext, options) =>
                    {
                        int port = hostingContext.Configuration.GetSection("Kestrel").GetValue<int>("Port");

                        options.ListenAnyIP(port);
                        options.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(5);
                        options.Limits.MaxRequestBodySize = null;
                    });
                    webBuilder.UseStartup<Startup>();
                });
    }
}
