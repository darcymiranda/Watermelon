using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Watermelon.Components;
using Watermelon.Models;
using Watermelon.Services;
using Watermelon.Services.Hotel;
using Watermelon.Services.Hotel.Wan;
using Watermelon.Services.Travel.Wan;
using Watermelon.Services.Travel;

namespace Watermelon
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            
            if(env.IsDevelopment())
            {
                builder.AddUserSecrets();
            }

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // TODO: Add the rest of the configuration file later
            services.Configure<ApplicationSettings>(Configuration.GetSection("ApiSettings"));

            // Add framework services.
            services.AddMvc();
            services.AddMemoryCache();

            services.AddDbContext<LocationContext>(options =>
                    {
                        options.UseSqlServer(Configuration.GetSection("Database").GetValue<string>("Default"));
                    });

            services.AddTransient<IReferenceDataService, ReferenceDataService>();

            services.AddTransient<IFlight, Flight>();
            services.AddTransient<IHotel, Hotel>();
            
            // Using fake local responses
            //services.AddScoped(p => new HttpClient(new MockHttpClientResponseHandler()));
            services.AddScoped(p => new HttpClient());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            DatabaseData.InitializeDatabaseAsync(app.ApplicationServices, Configuration).Wait();
        }
    }
}
