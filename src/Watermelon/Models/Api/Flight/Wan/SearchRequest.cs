using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Watermelon.Models.Api.Flight.Wan
{
    public class SearchRequest 
    {
        [JsonProperty(PropertyName = "trips")]
        public List<Trip> Trips { get; set; }

        [JsonProperty(PropertyName = "adults_count")]
        public int AdultCount;

        [JsonProperty(PropertyName = "locale")]
        public string Locale;
        
        public class Trip
        {
            [JsonProperty(PropertyName = "departure_code")]
            public string DepartAirportCode { get; set; }

            [JsonProperty(PropertyName = "arrival_code")]
            public string ArriveAirportCode { get; set; }

            [JsonProperty(PropertyName = "outbound_date")]
            public string DepartDate { get; set; }

            [JsonProperty(PropertyName = "inbound_date")]
            public string ReturnDate { get; set; }
        }
    }
}
