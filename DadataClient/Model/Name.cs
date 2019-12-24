using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DadataClient.Model
{
    public partial class Name
    {
        [JsonProperty("full_with_opf")]
        public string FullWithOpf { get; set; }

        [JsonProperty("short_with_opf")]
        public string ShortWithOpf { get; set; }

        [JsonProperty("latin")]
        public object Latin { get; set; }

        [JsonProperty("full")]
        public string Full { get; set; }

        [JsonProperty("short")]
        public string Short { get; set; }
    }

}
