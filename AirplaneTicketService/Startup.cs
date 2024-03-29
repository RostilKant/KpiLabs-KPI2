using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirplaneTicketService.Controllers;
using AirplaneTicketService.Data;
using AirplaneTicketService.Models;
using AirplaneTicketService.NewFolder;
using AirplaneTicketService.Persistance;
using AirplaneTicketService.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AirplaneTicketService
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
            services.AddControllers();
            services.AddDbContext<ApplicationContext>(c => c.UseSqlServer
            (Configuration.GetConnectionString("TicketsDb")));
            //services.AddScoped<IRepository<Client>, ClientRepository>();
            //services.AddScoped<IRepository<Plane>, PlaneRepository>();
            services.AddScoped<UnityOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
