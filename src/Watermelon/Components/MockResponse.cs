using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Watermelon.Components
{
    public class MockResponse
    {
        public Dictionary<string, string> Wan { get; set; } = new Dictionary<string, string>()
        {
            { "/flights/api/k/2/searches", @"{
  ""adults_count"": 1,
  ""cabin"": ""economy"",
  ""children_count"": 0,
  ""country_site_code"": ""CA"",
  ""created_at"": ""2016-07-04T06:15:04.117+08:00"",
  ""device_type"": ""desktop"",
  ""id"": ""zjm6lILlQaOypxmskxf0dw"",
  ""infants_count"": 0,
  ""key"": ""[YWG:YHM:2016-07-24:2016-07-29]~1~0~CA~CA"",
  ""no_provider_codes"": [
    ""wego.com-travelstart.co.za"",
    ""wego.com-kiwi.com"",
    ""wego.com-smartfares.com"",
    ""wego.com-travelfusion.com""
  ],
  ""trips"": [
    {
      ""id"": ""YWG:YHM:2016-07-24:2016-07-29"",
      ""departure_code"": ""YWG"",
      ""departure_name"": ""Winnipeg J.A. Richardson Intl Airport"",
      ""departure_city"": false,
      ""departure_country_code"": ""CA"",
      ""departure_country_name"": ""Canada"",
      ""arrival_code"": ""YHM"",
      ""arrival_name"": ""Toronto John C Munro Hamilton Airport"",
      ""arrival_city"": false,
      ""arrival_country_code"": ""CA"",
      ""arrival_country_name"": ""Canada"",
      ""outbound_date"": ""2016-07-24"",
      ""inbound_date"": ""2016-07-29"",
      ""trip_type"": ""standard""
    }
  ],
  ""user_country_code"": ""CA"",
  ""locale"": ""en""
}" }
        };
    }
}
