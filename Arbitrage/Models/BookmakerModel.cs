using Newtonsoft.Json;

namespace Arbitrage.Models
{
    public class BookmakerModel
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("last_update")]
        public string LastUpdate { get; set; }

        [JsonProperty("markets")]
        public IEnumerable<MarketModel> Markets { get; set; }

    }
}
