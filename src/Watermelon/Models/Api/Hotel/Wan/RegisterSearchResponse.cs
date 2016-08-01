using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Watermelon.Models.Api.Hotel.Wan
{
    public class RegisterSearchResponse
    {
        [JsonProperty(PropertyName = "search_id")]
        public int SearchId { get; set; }

        [JsonProperty(PropertyName = "is_done")]
        public bool IsDone { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        public string CreatedAt { get; set; }
    }
}
