using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwantTest.Model
{
    public class CounterpartyForm
    {
        [JsonProperty("inn")]
        public long INN { get; set; }

        [JsonProperty("kpp")]
        public long? KPP { get; set; }
    }
}
