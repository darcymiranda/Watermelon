using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Watermelon.Models.Api.Hotel.Wan;

namespace Watermelon.Services.Hotel.Wan
{
    public class Hotel : IHotel
    {
        private readonly HttpClient _client;
        private readonly ApplicationSettings _settings;

        public Hotel(HttpClient client, IOptions<ApplicationSettings> settings)
        {
            _client = client;
            _settings = settings.Value;

            _client.BaseAddress = new Uri(_settings.Wan.Host);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<LocationSearchResponse> SearchLocation(string query)
        {
            // WAN: you have to replace all characters (e.g. . , / \ - ) being pass to our API into _ (underscore)
            var alphanumericQuery = Regex.Replace(query, "[^a-zA-Z0-9_.]+", "_");

            var response = await _client.GetAsync(
                string.Format(_settings.Wan.Endpoints.Hotels.SearchLocation + "?q={0}&key={1}&ts_code={2}",
                                alphanumericQuery, 
                                _settings.Wan.Keys.ApiKey,
                                _settings.Wan.Keys.TsCode
                )
            );

            // TODO: Error handling

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<LocationSearchResponse>(content);
        }

        public async Task<RegisterSearchResponse> RegisterSearch(int locationId, DateTime checkIn, DateTime checkOut, IPAddress requestingIpAddress)
        {
            var response = await _client.GetAsync(
                string.Format(_settings.Wan.Endpoints.Hotels.RegisterSearch + "?location_id={0}&check_in={1}&check_out={2}&user_ip={3}&key={4}&ts_code={5}",
                                locationId, 
                                checkIn.ToString("yyyy-MM-dd", CultureInfo.CurrentCulture), 
                                checkOut.ToString("yyyy-MM-dd", CultureInfo.CurrentCulture), 
                                requestingIpAddress,
                                _settings.Wan.Keys.ApiKey,
                                _settings.Wan.Keys.TsCode
                            )
                        );

            // TODO: Error handling

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<RegisterSearchResponse>(content);
        }

        public async Task<RetrieveSearchResponse> RetrieveSearch(int searchId)
        {
            var response = await _client.GetAsync(
                string.Format(_settings.Wan.Endpoints.Hotels.RetrieveSearch + searchId + "?key={0}&ts_code={1}",
                    _settings.Wan.Keys.ApiKey,
                    _settings.Wan.Keys.TsCode
                    )
                );

            // TODO: Error handling

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<RetrieveSearchResponse>(content);
        }
    }
}
