using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Watermelon.Models;

namespace Watermelon.Services
{
    public class ReferenceDataService : IReferenceDataService
    {
        private IMemoryCache _memoryCache;
        private LocationContext _context;

        public ReferenceDataService(IMemoryCache memoryCache, LocationContext context)
        {
            _memoryCache = memoryCache;
            _context = context;
        }

        public IEnumerable<Airport> GetAirports()
        {
            try
            {
                IEnumerable<Airport> airports;

                if(!_memoryCache.TryGetValue("airports-cache-key", out airports)) //TODO: Fix silly strings
                {
                    airports = _context.Airport.ToList();
                    _memoryCache.Set("airports-cache-key", airports);
                }

                return airports;
            }
            catch(Exception)
            {
                return null; //TODO: Add error stuffs
            }
        }

        public IEnumerable<City> GetCities()
        {
            try
            {
                IEnumerable<City> cities;

                if(!_memoryCache.TryGetValue("cities-cache-key", out cities)) //TODO: Fix silly strings
                {
                    cities = _context.City.ToList();
                    _memoryCache.Set("cities-cache-key", cities);   
                }

                return cities;
            }
            catch(Exception)
            {
                return null; //TODO: Add error stuffs
            }
        }
    }
}
