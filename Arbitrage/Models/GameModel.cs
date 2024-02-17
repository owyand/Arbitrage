using Newtonsoft.Json;

namespace Arbitrage.Models
{
    public class GameModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("sport_key")]
        public string SportKey { get; set; }

        [JsonProperty("sport_title")]
        public string SportTitle { get; set; }

        [JsonProperty("commence_time")]
        public string CommenceTime { get; set; }

        [JsonProperty("home_team")]
        public string HomeTeam { get; set; }

        [JsonProperty("away_team")]
        public string AwayTeam { get; set; }

        [JsonProperty("completed")]
        public bool Completed { get; set; }

        [JsonProperty("scores")]
        public IEnumerable<ScoreModel> Scores { get; set; }

        [JsonProperty("last_update")]
        public string lastUpdate { get; set; }

    }
}
