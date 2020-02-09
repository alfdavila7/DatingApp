using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using DatingApp.API.Data;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //Dependency inyection container
        public void ConfigureServices(IServiceCollection services)
        {
            //Provide all in order to connect to the database.
            //For that we need to install the Microsoft.EntityFrameworkCore.Sqlite from NuGet
            services.AddDbContext<DataContext>(x => x.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();
            services.AddCors(); //To tackle the problem which happened by trusting both local hosts
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //Interact with our request as it is going thru the pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Here the order really matters
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); //To tackle the problem which happened by trusting both local hosts

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
