namespace Arbitrage.Models
{
    public class MarketModel
    {

        public class Market
        {
            public string Key { get; set; }
            public List<OutcomeModel> Outcomes { get; set; }
        }
    }
}
