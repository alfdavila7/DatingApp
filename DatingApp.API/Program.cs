using System;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DatingApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope()) // We need an instance of our Datacontext 
            {
                var services = scope.ServiceProvider;
                try // Here we need to handle the error here because there is no error handling exception inside here
                {
                    var context = services.GetRequiredService<DataContext>();
                    context.Database.Migrate(); // Creates or applys changes to the database. Instead of dotnet ef database update
                    Seed.SeedUsers(context); // Seed users if the Db doesnt have users on it.
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred during migration");
                }
            }
            
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            //Configures some defaults using the webserver and the debug in the Terminal
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //Startup class -> Additional configurations for ower application
                    webBuilder.UseStartup<Startup>();
                });
    }
}
