using InternetTaxiAPI.Application.Services.Driver;
using InternetTaxiAPI.Application.Services.Passenger;
using InternetTaxiAPI.Application.Services.Trip;
using InternetTaxiAPI.Application.Services.Weather;
using InternetTaxiAPI.Domain.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetTaxiAPI
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
            services.AddScoped<IWeatherService, WeatherService>();
            services.AddScoped<IDriversService, DriversService>();
            services.AddScoped<IPassengerService, PassengerService>();
            services.AddScoped<ITripService, TripService>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "InternetTaxiAPI", Version = "v1" });
            });
            string constr = @"Data Source=.; Initial Catalog=InternetTaxi_DB; Integrated Security=True;";
            services.AddEntityFrameworkSqlServer().AddDbContext<DatabaseContext>(options => { options.UseSqlServer(constr); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "InternetTaxiAPI v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
