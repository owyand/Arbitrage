﻿namespace Arbitrage.Models
{
    public class BookmakerModel
    {
        public string Key { get; set; }
        public string Title { get; set; }
        public DateTime LastUpdate { get; set; }

        public List<MarketModel> Markets { get; set; }

    }
}
