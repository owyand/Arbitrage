using Arbitrage.Models;
using Arbitrage.Services.Interfaces;

namespace Arbitrage.Services
{
    public class BookmakerService : IBookmakerService
    {
        public List<BookmakerModel> DeserializeBookmakers(string bookmakersString)
        {
            Console.WriteLine(bookmakersString);

            var bookmakers = new List<BookmakerModel>();

            // Split the string by '&'
            var bookmakerStrings = bookmakersString.Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var bookmakerStr in bookmakerStrings)
            {
                // Remove square brackets from the bookmaker string
                var cleanBookmakerStr = bookmakerStr.Trim('[', ']');

                // Split the bookmaker string by '|'
                var bookmakerProps = cleanBookmakerStr.Split('|');

                // Validate that bookmakerProps has at least 4 elements
                if (bookmakerProps.Length >= 4)
                {
                    var bookmaker = new BookmakerModel
                    {
                        Key = bookmakerProps[0],
                        Title = bookmakerProps[1],
                        LastUpdate = bookmakerProps[2],
                        Markets = DeserializeMarkets(bookmakerProps[3])
                    };

                    bookmakers.Add(bookmaker);
                }
                else
                {
                    // Handle the case where the bookmakerProps array does not contain enough elements
                    // For example, log an error or skip this bookmaker
                }
            }

            return bookmakers;
        }

        private List<MarketModel> DeserializeMarkets(string marketsString)
        {
            Console.WriteLine(marketsString);
            var markets = new List<MarketModel>();

            // Split the string by '&'
            var marketStrings = marketsString.Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var marketStr in marketStrings)
            {
                // Remove square brackets from the market string
                var cleanMarketStr = marketStr.Trim('[', ']');

                // Split the market string by '|'
                var marketProps = cleanMarketStr.Split('|');

                // Validate that marketProps has at least 2 elements
                if (marketProps.Length >= 2)
                {
                    var market = new MarketModel
                    {
                        Key = marketProps[0],
                        Outcomes = DeserializeOutcomes(marketProps[1])
                    };

                    markets.Add(market);
                }
                else
                {
                    // Handle the case where the marketProps array does not contain enough elements
                    // For example, log an error or skip this market
                }
            }

            return markets;
        }

        private List<OutcomeModel> DeserializeOutcomes(string outcomesString)
        {
            Console.WriteLine(outcomesString);
            var outcomes = new List<OutcomeModel>();

            // Split the string by '&'
            var outcomeStrings = outcomesString.Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var outcomeStr in outcomeStrings)
            {
                // Remove square brackets from the outcome string
                var cleanOutcomeStr = outcomeStr.Trim('[', ']');

                // Split the outcome string by '|'
                var outcomeProps = cleanOutcomeStr.Split('|');

                // Validate that outcomeProps has at least 3 elements
                if (outcomeProps.Length >= 3)
                {
                    var outcome = new OutcomeModel
                    {
                        Name = outcomeProps[0],
                        Price = double.Parse(outcomeProps[1]),
                        Point = double.Parse(outcomeProps[2])
                    };

                    outcomes.Add(outcome);
                }
                else
                {
                    // Handle the case where the outcomeProps array does not contain enough elements
                    // For example, log an error or skip this outcome
                }
            }

            return outcomes;
        }
        //public List<BookmakerModel> DeserializeBookmakers(string bookmakersString)
        //{
        //    Console.WriteLine(bookmakersString);
        //    var bookmakers = new List<BookmakerModel>();

        //    // Split the string by ']&[' to separate bookmakers
        //    var bookmakerStrings = bookmakersString.Split(new[] { "&" }, StringSplitOptions.RemoveEmptyEntries);

        //    foreach (var bookmakerStr in bookmakerStrings)
        //    {
        //        // Remove square brackets from the bookmaker string
        //        var cleanBookmakerStr = bookmakerStr.Trim('[', ']');

        //        // Split the bookmaker string by '|' to get its properties
        //        var bookmakerProps = cleanBookmakerStr.Split('|');

        //        var bookmaker = new BookmakerModel
        //        {
        //            Key = bookmakerProps[0],
        //            Title = bookmakerProps[1],
        //            LastUpdate = bookmakerProps[2],
        //            Markets = DeserializeMarkets(bookmakerProps[3])
        //        };

        //        bookmakers.Add(bookmaker);
        //    }

        //    return bookmakers;
        //}

        //private List<MarketModel> DeserializeMarkets(string marketsString)
        //{

        //    Console.WriteLine(marketsString);
        //    var markets = new List<MarketModel>();

        //    // Split the string by ')&(' to separate markets
        //    var marketStrings = marketsString.Split(new[] { "&" }, StringSplitOptions.RemoveEmptyEntries);

        //    foreach (var marketStr in marketStrings)
        //    {
        //        // Remove parentheses from the market string
        //        var cleanMarketStr = marketStr.Trim('(', ')');

        //        // Split the market string by '|' to get its properties
        //        var marketProps = cleanMarketStr.Split('|');

        //        var market = new MarketModel
        //        {
        //            Key = marketProps[0],
        //            Outcomes = DeserializeOutcomes(marketProps[1])
        //        };

        //        markets.Add(market);
        //    }

        //    return markets;
        //}

        //private List<OutcomeModel> DeserializeOutcomes(string outcomesString)
        //{

        //    Console.WriteLine(outcomesString);
        //    var outcomes = new List<OutcomeModel>();

        //    // Split the string by '&'
        //    var outcomeStrings = outcomesString.Split(new[] { "&" }, StringSplitOptions.RemoveEmptyEntries);

        //    foreach (var outcomeStr in outcomeStrings)
        //    {
        //        // Remove parentheses from the outcome string
        //        var cleanOutcomeStr = outcomeStr.Trim('(', ')');

        //        // Split the outcome string by '|'
        //        var outcomeProps = cleanOutcomeStr.Split('|');

        //        var outcome = new OutcomeModel
        //        {
        //            Name = outcomeProps[0],
        //            Price = double.Parse(outcomeProps[1]),
        //            Point = double.Parse(outcomeProps[2])
        //        };

        //        outcomes.Add(outcome);
        //    }

        //    return outcomes;
        //}
    }
}
