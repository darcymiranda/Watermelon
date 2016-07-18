using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Watermelon.Models
{
    public static class DatabaseData
    {
        public static async Task InitializeDatabaseAsync(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<LocationContext>();
                context.Database.EnsureCreatedAsync().Wait();

                if(context.Airport.Count() == 0)
                    await InsertDataFromCsv<Airport>(configuration.GetSection("Data").GetValue<string>("Airports"), typeof(AirportMap), serviceScope);

                if(context.City.Count() == 0)
                    await InsertDataFromCsv<City>(configuration.GetSection("Data").GetValue<string>("Cities"), typeof(CityMap), serviceScope);
            }
        }

        private async static Task InsertDataFromCsv<T>(string filePath, Type csvClassMap, IServiceScope serviceScope) where T : class
        {
            var context = serviceScope.ServiceProvider.GetService<LocationContext>();

            using (var reader = File.OpenText(filePath))
            {
                CsvReader csvReader = new CsvReader(reader);
                csvReader.Configuration.WillThrowOnMissingField = false;
                csvReader.Configuration.TrimFields = true;
                csvReader.Configuration.RegisterClassMap(csvClassMap);
                
                var data = csvReader.GetRecords<T>().ToArray();
                data.ToList().ForEach(a =>
                {
                    var test = context.Set<T>().Any(e => e == a);
                    if(!test)
                    {
                        context.Add<T>(a);
                    }
                });
            }

            await context.SaveChangesAsync();
        }
    }
}
