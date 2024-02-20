using Newtonsoft.Json;

namespace Arbitrage.Models
{
    public class OutcomeModel
    {
        public class Outcome
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("price")]
            public string Price { get; set; }

            [JsonProperty("point")]
            public string? Point { get; set; }
        }
    }
}
