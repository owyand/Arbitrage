using Newtonsoft.Json;

namespace Arbitrage.Models
{
    public class OutcomeModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("point")]
        public double? Point { get; set; }
    }
}
