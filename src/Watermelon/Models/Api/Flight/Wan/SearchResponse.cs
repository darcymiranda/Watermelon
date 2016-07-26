using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Watermelon.Models.Api.Flight.Wan
{
    public class SearchResponse
    {
        [JsonProperty("query_id")]
        public string QueryId { get; set; }

        [JsonProperty("fares_query_type")]
        public string FaresQueryType { get; set; }

        [JsonProperty("currency")]
        public CurrencyType Currency { get; set; }

        [JsonProperty("price_filter")]
        public PriceRangeFilter PriceFilter { get; set; }

        [JsonProperty("provider_filters")]
        public List<PriceMinimumTypeFilter> ProviderFilters { get; set; }

        [JsonProperty("alliance_filters")]
        public List<PriceMinimumTypeFilter> AllianceFilters { get; set; }

        [JsonProperty("stop_type_filters")]
        public List<PriceMinimumTypeFilter> StopTypeFilters { get; set; }

        [JsonProperty("airline_filters")]
        public List<PriceMinimumTypeFilter> AirlineFilters { get; set; }

        [JsonProperty("stopover_airport_filters")]
        public List<PriceMinimumTypeFilter> StopoverAirportFilters { get; set; }

        [JsonProperty("departure_airport_filters")]
        public List<PriceMinimumTypeFilter> DepartureAirportFilters { get; set; }

        [JsonProperty("arrival_airport_filters")]
        public List<PriceMinimumTypeFilter> ArrivalAirportFilters { get; set; }

        [JsonProperty("departure_day_time_filter")]
        public MinMaxFilter DepartureDayTimeFilter { get; set; }

        [JsonProperty("duration_filter")]
        public MinMaxFilter DurationFilter { get; set; }

        [JsonProperty("stopover_duration_filter")]
        public PriceMinimumTypeFilter StopoverDurationFilter { get; set; }

        [JsonProperty("routes")]
        public List<Route> Routes { get; set; }

        [JsonProperty("filtered_routes_count")]
        public int FilteredRoutesCount { get; set; }

        [JsonProperty("routes_count")]
        public int RoutesCount { get; set; }

        public class Route
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("comfort_index")]
            public double ComfortIndex { get; set; }

            [JsonProperty("fares")]
            public List<Fare> Fares { get; set; }
        }

        public class DeeplinkParams
        {
            [JsonProperty("trip_id")]
            public string TripId { get; set; }

            [JsonProperty("device_type")]
            public string DeviceType { get; set; }

            [JsonProperty("route")]
            public string AirportRoute { get; set; }

            [JsonProperty("domain")]
            public string Domain { get; set; }

            [JsonProperty("search_id")]
            public string SearchId { get; set; }

            [JsonProperty("placement_type")]
            public string PlacementType { get; set; }

            [JsonProperty("fare_id")]
            public string FareId { get; set; }
        }

        public class Fare
        { 
            [JsonProperty("price")]
            public double Price { get; set; }

            [JsonProperty("tax_and_fee_exclusive")]
            public bool TaxAndFeeExclusive { get; set; }

            [JsonProperty("provider_parent_code")]
            public string ProviderParentCode { get; set; }

            [JsonProperty("provider_code")]
            public string ProviderCode { get; set; }

            [JsonProperty("provider_name")]
            public string ProviderName { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("alliance")]
            public string Alliance { get; set; }

            [JsonProperty("deeplink")]
            public string Deeplink { get; set; }

            [JsonProperty("deeplink_params")]
            public DeeplinkParams DeeplinkParams { get; set; }

            [JsonProperty("mobile_friendly")]
            public bool MobileFriendly { get; set; }
        }

        public class CurrencyType
        {
            [JsonProperty("code")]
            public string Code { get; set; }

            [JsonProperty("symbol")]
            public string Symbol { get; set; }

            [JsonProperty("exchange_rate")]
            public double ExchangeRate { get; set; }
        }

        public class PriceRangeFilter
        {
            [JsonProperty("min_usd")]
            public double MinUsd { get; set; }

            [JsonProperty("max_usd")]
            public double MaxUsd { get; set; }

            [JsonProperty("min")]
            public double Min { get; set; }

            [JsonProperty("max")]
            public double Max { get; set; }
        }

        public class AllianceFilter
        {
            [JsonProperty("code")]
            public string Code { get; set; }

            [JsonProperty("count")]
            public int Count { get; set; }
        }

        public class PriceMinimumTypeFilter
        {
            [JsonProperty("code")]
            public string Code { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("price_min")]
            public double PriceMin { get; set; }
        }

        public class MinMaxFilter
        {
            [JsonProperty("min")]
            public double Min { get; set; }

            [JsonProperty("max")]
            public double Max { get; set; }
        }
    }
}
