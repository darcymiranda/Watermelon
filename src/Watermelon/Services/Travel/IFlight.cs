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
        Task<SearchResponse> Search(Airport beginAirport, Airport endAirport, DateTime beginDate, DateTime endDate, int adultCount = 1);
    }
}
