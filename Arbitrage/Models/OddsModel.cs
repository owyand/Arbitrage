using Newtonsoft.Json;

namespace Arbitrage.Models
{
    public class OddsModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("sport_key")]
        public string SportKey { get; set; }

        [JsonProperty("commence_time")]
        public string CommenceTime { get; set; }

        [JsonProperty("home_team")]
        public string HomeTeam { get; set; }

        [JsonProperty("away_team")]
        public string AwayTeam { get; set; }

        [JsonProperty("bookmakers")]
        public List<BookmakerModel> Bookmakers { get; set; }

    }
}
