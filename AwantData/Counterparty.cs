using System;
using System.Collections.Generic;
using System.Text;

namespace AwantData
{
    public class Counterparty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public CounterpartyTypeEnum CounterpartyType { get; set; }
        public long INN { get; set; }
        public long KPP { get; set; }
    }
}
