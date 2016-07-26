using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.Extensions.Options;
using Watermelon.Models;
using Watermelon.Models.Api.Flight.Wan;

namespace Watermelon.Services.Travel.Wan
{
    public class Flight : IFlight
    {
        private readonly HttpClient _client;
        private readonly ApplicationSettings _settings;

        public Flight(HttpClient client, IOptions<ApplicationSettings> settings)
        {
            _client = client;
            _settings = settings.Value;

            _client.BaseAddress = new Uri(_settings.Wan.Host);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<SearchResponse> Search(Airport departAirport, Airport arriveAirport,
            DateTime departDate, DateTime returnDate, int adultCount = 1)
        {
            var register = await RegisterSearch(departAirport, arriveAirport, departDate, returnDate, adultCount);

            // Docs says needs to wait 10 seconds in order for the search to complete on their end before calling to retrieve the contents. If we call 
            // to retrieve immeditely, nothing will be returned.
            // TODO: Some kind of polling?
            await Task.Delay(3000); // Temp fix

            var fareResponse = await RetrieveSearchResults(register); 
            return fareResponse;
        }

        private async Task<RegisterSearchResponse> RegisterSearch(Airport departAirport, Airport arriveAirport, DateTime departDate, DateTime returnDate, int adultCount = 1)
        {
            var body = new RegisterSearchRequest
            {
                AdultCount = adultCount,
                Locale = "en",
                Trips = new List<RegisterSearchRequest.Trip>()
                {
                    new RegisterSearchRequest.Trip()
                    {
                        DepartAirportCode = departAirport.Code,
                        ArriveAirportCode = arriveAirport.Code,
                        DepartDate = departDate.ToString("yyyy-MM-dd", CultureInfo.CurrentCulture),
                        ReturnDate = returnDate.ToString("yyyy-MM-dd", CultureInfo.CurrentCulture)
                    }
                }
            };
            
            var response = await _client.PostAsync(
                $"{_settings.Wan.Endpoints.Flights.Search}?api_key={_settings.Wan.Keys.ApiKey}&ts_code={_settings.Wan.Keys.TsCode}",
                new StringContent(
                    JsonConvert.SerializeObject(body),
                    Encoding.UTF8,
                    "application/json"
                )
            );
            
            // TODO: Error handling

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<RegisterSearchResponse>(content);
        }

        private async Task<SearchResponse> RetrieveSearchResults(RegisterSearchResponse register)
        {
            return await RetrieveSearchResults(register.SearchId, register.Trips.Select(a => a.TripId).First());
        }

        private async Task<SearchResponse> RetrieveSearchResults(string searchId, string tripId, string fareId = null)
        {
            var body = new
            {
                id = fareId ?? Guid.NewGuid().ToString(),
                search_id = searchId,
                trip_id = tripId,
                fares_query_type = "route"
            };
            
            var response = await _client.PostAsync(
                $"{_settings.Wan.Endpoints.Flights.Fare}?api_key={_settings.Wan.Keys.ApiKey}&ts_code={_settings.Wan.Keys.TsCode}",
                new StringContent(
                    JsonConvert.SerializeObject(body),
                    Encoding.UTF8,
                    "application/json"
                )
            );

            // TODO: Error handling

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<SearchResponse>(content);
        }
    }
}
