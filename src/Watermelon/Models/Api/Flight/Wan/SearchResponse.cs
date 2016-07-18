using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Watermelon.Models.Api.Flight.Wan
{
    public class SearchResponse
    {
        [JsonProperty("id")]
        public string SearchId { get; set; }

        [JsonProperty("adults_count")]
        public int AdultCount { get; set; }

        [JsonProperty("children_count")]
        public int ChildrenCount { get; set; }

        [JsonProperty("infants_count")]
        public int InfantCount { get; set; }

        [JsonProperty("cabin")]
        public string CabinType { get; set; }

        [JsonProperty("device_type")]
        public string DeviceType { get; set; }

        [JsonProperty("country_site_code")]
        public string CountryCode { get; set; }

        [JsonProperty("created_at")]
        public string CreatedDateTime { get; set; }

        [JsonProperty("key")]
        public string Tripkey { get; set; }
        
        [JsonProperty("no_provider_codes")]
        public List<string> NoProviderCodes { get; set; } //?

        [JsonProperty("trips")]
        public List<SearchResponse> Trips { get; set; }

        [JsonProperty("user_country_code")]
        public string UserCountryCode { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }
    }
    
    public class Trip
    { 
        [JsonProperty("id")]
        public string TripId { get; set; }

        [JsonProperty("trip_type")]
        public string TripType { get; set; }

        [JsonProperty("departure_code")]
        public string DepartAirportCode { get; set; }

        [JsonProperty("departure_name")]
        public string DepartAirportName { get; set; }

        [JsonProperty("departure_city")]
        public bool DepartCityName { get; set; }

        [JsonProperty("departure_country_code")]
        public string DepartCountryCode { get; set; }

        [JsonProperty("departure_country_name")]
        public string DepartCountryName { get; set; }

        [JsonProperty("arrival_code")]
        public string ArriveAirportCode { get; set; }

        [JsonProperty("arrival_name")]
        public string ArriveAirportName { get; set; }

        [JsonProperty("arrival_city")]
        public bool ArriveCityName { get; set; }

        [JsonProperty("arrival_country_code")]
        public string ArriveCountryCode { get; set; }

        [JsonProperty("arrival_country_name")]
        public string ArriveCountryName { get; set; }

        [JsonProperty("outbound_date")]
        public string DepartDate { get; set; }

        [JsonProperty("inbound_date")]
        public string ReturnDate { get; set; }
    }
}
