using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GagiStoreSystem.Data;
using GagiStoreSystem.Infrastructure.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GagiStoreSystem
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var webHost = CreateHostBuilder(args).Build();
            using(IServiceScope scope = webHost.Services.CreateScope())
            {
                using(var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    await Seed.InvokeAsync(context);
                }
            }

            await webHost.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
