using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Watermelon.Models.Api.Hotel.Wan;

namespace Watermelon.Services.Hotel
{
    public interface IHotel
    {
        // TODO: Make this a generic class and not from WAN
        Task<LocationSearchResponse> SearchLocation(string query);

        // TODO: Make this a generic class and not from WAN
        Task<RegisterSearchResponse> RegisterSearch(int locationId, DateTime checkIn, DateTime checkOut, IPAddress requestingIpAddress);

        // TODO: Make this a generic class and not from WAN
        Task<RetrieveSearchResponse> RetrieveSearch(int searchId);
    }
}
