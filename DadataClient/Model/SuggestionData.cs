using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DadataClient.Model
{
    public partial class SuggestionData
    {
        [JsonProperty("kpp")]
        public long Kpp { get; set; }

        [JsonProperty("name")]
        public Name Name { get; set; }

        [JsonProperty("inn")]
        public string Inn { get; set; }
    }
}
