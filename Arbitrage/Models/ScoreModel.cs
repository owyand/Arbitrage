using Newtonsoft.Json;

namespace Arbitrage.Models
{
    public class ScoreModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("score")]
        public string Score { get; set; }
    }
}
