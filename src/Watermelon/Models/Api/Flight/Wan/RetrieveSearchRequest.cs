using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Watermelon.Models.Api.Flight.Wan
{
    public class RetrieveSearchRequest
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("search_id")]
        public string SearchId { get; set; }

        [JsonProperty("trip_id")]
        public string TripId { get; set; }

        [JsonProperty("fares_query_type")]
        public string FaresQueryType { get; set; }
    }
}
