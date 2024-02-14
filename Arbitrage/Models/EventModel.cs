namespace Arbitrage.Models
{
    public class EventModel
    {
        public string Id { get; set; }
        public string SportKey { get; set; }
        public string SportTitle { get; set; }
        public DateTime CommenceTime { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }

    }
}
