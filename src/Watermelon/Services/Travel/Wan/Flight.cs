using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<SearchResponse> Search(Airport departAirport, Airport arriveAirport, DateTime departDate, DateTime arriveDate, int adultCount = 1)
        {
            var body = new SearchRequest
            {
                AdultCount = adultCount,
                Locale = "en",
                Trips = new List<SearchRequest.Trip>()
                {
                    new SearchRequest.Trip()
                    {
                        DepartAirportCode = departAirport.Code,
                        ArriveAirportCode = arriveAirport.Code,
                        DepartDate = departDate.ToString("yyyy-MM-dd", CultureInfo.CurrentCulture),
                        ReturnDate = arriveDate.ToString("yyyy-MM-dd", CultureInfo.CurrentCulture)
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
            return JsonConvert.DeserializeObject<SearchResponse>(content);
        }
    }
}
