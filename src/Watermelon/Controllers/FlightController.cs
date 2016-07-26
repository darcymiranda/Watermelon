using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Watermelon.Models;
using Watermelon.Models.Api.Flight.Wan;
using Watermelon.Services.Travel;

namespace Watermelon.Controllers
{
    [Route("api/[controller]")]
    public class FlightController: Controller
    {
        private readonly IFlight _flight;
        private readonly LocationContext _locationContext;

        public FlightController(LocationContext serviceProvider, IFlight flight)
        {
            _locationContext = serviceProvider;
            _flight = flight;
        }

        [HttpGet("Search")]
        public async Task<IActionResult> Search([FromQuery]string departAirportCode, [FromQuery]string arriveAirportCode, [FromQuery]string departDate, [FromQuery]string returnDate, int adultCount = 1)
        {
            if (string.IsNullOrEmpty(departAirportCode) || string.IsNullOrEmpty(arriveAirportCode) ||
                string.IsNullOrEmpty(departDate) || string.IsNullOrEmpty(returnDate))
            {
                return BadRequest();
            }

            Airport departAirport = _locationContext.Airport.FirstOrDefault(a => a.Code == departAirportCode);
            Airport arriveAirport = _locationContext.Airport.FirstOrDefault(a => a.Code == arriveAirportCode);

            DateTime departDateTime = DateTime.ParseExact(departDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime returnDateTime = DateTime.ParseExact(returnDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            
            var response = await _flight.Search(departAirport, arriveAirport, departDateTime, returnDateTime, adultCount);

            return new ObjectResult(response);
        }
    }
}
