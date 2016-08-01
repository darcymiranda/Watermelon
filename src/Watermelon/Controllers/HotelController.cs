using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Watermelon.Models;
using Watermelon.Models.Api.Flight.Wan;
using Watermelon.Services.Hotel;
using Watermelon.Services.Travel;

namespace Watermelon.Controllers
{
    [Route("api/[controller]")]
    public class HotelController: Controller
    {
        private readonly IHotel _hotel;

        public HotelController(IHotel hotel)
        {
            _hotel = hotel;
        }

        [HttpGet("Location")]
        public async Task<IActionResult> Location([FromQuery]string query)
        {
            var response = await _hotel.SearchLocation(query);
            return new ObjectResult(response);
        }

        [HttpGet("RegisterSearch")]
        public async Task<IActionResult> RegisterSearch([FromQuery]string locationId, [FromQuery]string checkIn, [FromQuery]string checkOut, string requestIpAddress)
        {
            int numericLocationId;
            if (!int.TryParse(locationId, out numericLocationId))
            {
                return BadRequest("LocationId must be numeric");
            }

            IPAddress ipAddress;
            if (!IPAddress.TryParse(requestIpAddress, out ipAddress))
            {
                return BadRequest("RequestIpAddress must be in IPv4 address format");
            }

            var checkInDateTime = DateTime.ParseExact(checkIn, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            var checkOutDateTime = DateTime.ParseExact(checkOut, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            var response = await _hotel.RegisterSearch(numericLocationId, checkInDateTime, checkOutDateTime, ipAddress);
            return new ObjectResult(response);
        }

        [HttpGet("RetrieveSearch")]
        public async Task<IActionResult> RetrieveSearch([FromQuery]string id)
        {
            int numericSearchId;
            if (!int.TryParse(id, out numericSearchId))
            {
                return BadRequest("SearchId must be numeric");
            }

            var response = await _hotel.RetrieveSearch(numericSearchId);
            return new ObjectResult(response);
        }
    }
}
