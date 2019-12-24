using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DadataClient.Model
{
    public partial class Suggestion
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("unrestricted_value")]
        public string UnrestrictedValue { get; set; }

        [JsonProperty("data")]
        public SuggestionData Data { get; set; }
    }
}
