namespace Arbitrage.Models
{
    public class OddsModel
    {
        public string Id { get; set; }
        public string SportKey { get; set; }
        public DateTime CommenceTime { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }

        public List<BookmakerModel> Bookmakers { get; set; }

    }
}
