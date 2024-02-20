using Newtonsoft.Json;

namespace Arbitrage.Models
{
    public class MarketModel
    {

        public class Market
        {
            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("outcomes")]
            public List<OutcomeModel> Outcomes { get; set; }
        }
    }
}
