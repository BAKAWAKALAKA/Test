using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DadataClient.Model
{
    public partial class Party
    {
        [JsonProperty("suggestions")]
        public Suggestion[] Suggestions { get; set; }
    }
}
