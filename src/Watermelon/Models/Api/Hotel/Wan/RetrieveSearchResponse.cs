using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Watermelon.Models.Api.Hotel.Wan
{
    public class RetrieveSearchResponse
    {
        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("location_coordinates")]
        public IList<double> LocationCoordinates { get; set; }

        [JsonProperty("total_count")]
        public int TotalCount { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("filtered_count")]
        public int FilteredCount { get; set; }

        [JsonProperty("current_page")]
        public int CurrentPage { get; set; }

        [JsonProperty("per_page")]
        public int PerPage { get; set; }

        [JsonProperty("rates")]
        public Rates Rates { get; set; }

        [JsonProperty("districts")]
        public IList<District> Districts { get; set; }

        [JsonProperty("is_done")]
        public bool IsDone { get; set; }

        [JsonProperty("hotels")]
        public IList<Hotel> Hotels { get; set; }
    }
    
    public class Hotel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("districts")]
        public IList<int> Districts { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("property_type")]
        public int PropertyType { get; set; }

        [JsonProperty("brand_id")]
        public int? BrandId { get; set; }

        [JsonProperty("searched")]
        public object Searched { get; set; }

        [JsonProperty("desc")]
        public string Desc { get; set; }

        [JsonProperty("stars")]
        public int Stars { get; set; }

        [JsonProperty("map")]
        public bool Map { get; set; }

        [JsonProperty("room_rates")]
        public IList<RoomRate> RoomRates { get; set; }

        [JsonProperty("summary_room_rates")]
        public IList<SummaryRoomRate> SummaryRoomRates { get; set; }

        [JsonProperty("room_rates_count")]
        public int RoomRatesCount { get; set; }

        [JsonProperty("room_rate_min")]
        public RoomRateMin RoomRateMin { get; set; }

        [JsonProperty("total_reviews")]
        public int TotalReviews { get; set; }

        [JsonProperty("positive")]
        public int Positive { get; set; }

        [JsonProperty("negative")]
        public int Negative { get; set; }

        [JsonProperty("neutral")]
        public int Neutral { get; set; }

        [JsonProperty("rooms_count")]
        public int RoomsCount { get; set; }

        [JsonProperty("rank")]
        public int Rank { get; set; }

        [JsonProperty("satisfaction")]
        public int Satisfaction { get; set; }

        [JsonProperty("satisfaction_description")]
        public string SatisfactionDescription { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("offer")]
        public object Offer { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }
    }

    public class Min
    {
        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("price_usd")]
        public double PriceUsd { get; set; }

        [JsonProperty("price_str")]
        public string PriceStr { get; set; }

        [JsonProperty("currency_code")]
        public string CurrencyCode { get; set; }
    }

    public class Max
    {
        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("price_usd")]
        public double PriceUsd { get; set; }

        [JsonProperty("price_str")]
        public string PriceStr { get; set; }

        [JsonProperty("currency_code")]
        public string CurrencyCode { get; set; }
    }

    public class Rates
    {
        [JsonProperty("min")]
        public Min Min { get; set; }

        [JsonProperty("max")]
        public Max Max { get; set; }
    }

    public class District
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class RoomRate
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("price_str")]
        public string PriceStr { get; set; }

        [JsonProperty("currency_code")]
        public string CurrencyCode { get; set; }

        [JsonProperty("currency_sym")]
        public string CurrencySym { get; set; }

        [JsonProperty("provider_name")]
        public string ProviderName { get; set; }

        [JsonProperty("provider_code")]
        public string ProviderCode { get; set; }

        [JsonProperty("mobile_friendly")]
        public bool MobileFriendly { get; set; }

        [JsonProperty("ex_tax")]
        public bool ExTax { get; set; }

        [JsonProperty("is_direct")]
        public bool IsDirect { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class SummaryRoomRate
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("price_str")]
        public string PriceStr { get; set; }

        [JsonProperty("currency_code")]
        public string CurrencyCode { get; set; }

        [JsonProperty("currency_sym")]
        public string CurrencySym { get; set; }

        [JsonProperty("provider_name")]
        public string ProviderName { get; set; }

        [JsonProperty("provider_code")]
        public string ProviderCode { get; set; }

        [JsonProperty("mobile_friendly")]
        public bool MobileFriendly { get; set; }

        [JsonProperty("ex_tax")]
        public bool ExTax { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("is_direct")]
        public bool IsDirect { get; set; }
    }

    public class RoomRateMin
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("price_str")]
        public string PriceStr { get; set; }

        [JsonProperty("currency_code")]
        public string CurrencyCode { get; set; }

        [JsonProperty("currency_sym")]
        public string CurrencySym { get; set; }

        [JsonProperty("provider_name")]
        public string ProviderName { get; set; }

        [JsonProperty("provider_code")]
        public string ProviderCode { get; set; }

        [JsonProperty("mobile_friendly")]
        public bool MobileFriendly { get; set; }

        [JsonProperty("ex_tax")]
        public bool ExTax { get; set; }

        [JsonProperty("is_direct")]
        public bool IsDirect { get; set; }
    }
}
