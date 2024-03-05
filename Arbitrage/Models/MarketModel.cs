using Newtonsoft.Json;

namespace Arbitrage.Models
{
    public class MarketModel
    {

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("outcomes")]
        public IEnumerable<OutcomeModel> Outcomes { get; set; }

    }
}
