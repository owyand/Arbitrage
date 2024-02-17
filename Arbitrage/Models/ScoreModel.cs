using Newtonsoft.Json;

namespace Arbitrage.Models
{
    public class ScoreModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("score")]
        public int Score { get; set; }
    }
}
