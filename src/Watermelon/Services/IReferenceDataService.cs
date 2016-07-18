using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Watermelon.Models;

namespace Watermelon.Services
{
    public interface IReferenceDataService
    {
        IEnumerable<City> GetCities();
        IEnumerable<Airport> GetAirports();
    }
}
