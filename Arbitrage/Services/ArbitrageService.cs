using Arbitrage.Services.Interfaces;

namespace Arbitrage.Services
{
    public class ArbitrageService : IArbitrageService
    {
        public void adjustOddsForBookmakerMargin()
        {
            throw new NotImplementedException();
        }

        public decimal calculateArbitrageProfit()
        {
            throw new NotImplementedException();
        }

        public void calculateBettingAmounts()
        {
            throw new NotImplementedException();
        }

        public void calculateExpectedValue()
        {
            throw new NotImplementedException();
        }

        public decimal calculateImpliedProbability()
        {


            throw new NotImplementedException("working on it");
        }

        public void calculateReturnOnInvestment()
        {
            throw new NotImplementedException();
        }

        public bool checkArbitrageOpportunity()
        {
            //sort both and iterate backwards until there is no match then all the past iterations are arbitrage
            throw new NotImplementedException("checking for an arbitrage opportunity");
        }

        public decimal convertOddsToDecimal()
        {
            throw new NotImplementedException();
        }

        public void normalizeProbabilities()
        {
            throw new NotImplementedException();
        }

        public void validateOdds()
        {
            throw new NotImplementedException();
        }
    }
}
