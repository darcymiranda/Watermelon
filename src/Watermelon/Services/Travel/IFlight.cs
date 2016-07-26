using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Watermelon.Models;
using Watermelon.Models.Api.Flight.Wan;

namespace Watermelon.Services.Travel
{
    public interface IFlight
    {
        // TODO: Create own SearchResponse, not one based on WAN
        Task<SearchResponse> Search(Airport departAirport, Airport arriveAirport, DateTime departDate, DateTime returnDate, int adultCount = 1);
    }
}
