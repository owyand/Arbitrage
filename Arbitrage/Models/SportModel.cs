using Newtonsoft.Json;

namespace Arbitrage.Models
{
    public class SportModel
    {
        [JsonProperty("key")]
        public string? Key { get; set; }

        [JsonProperty("group")]
        public string? Group { get; set; }

        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("has_outrights")]
        public bool HasOutrights { get; set; }
    }
}
