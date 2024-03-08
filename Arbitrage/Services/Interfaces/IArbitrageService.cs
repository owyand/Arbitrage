namespace Arbitrage.Services.Interfaces
{
    /*calculateImpliedProbability: This method takes in odds in any format (decimal, fractional, American, etc.) and calculates the implied probability for each outcome.

checkArbitrageOpportunity: This method analyzes the implied probabilities and checks if an arbitrage opportunity exists. It returns a boolean indicating whether an arbitrage opportunity is present.

calculateArbitrageProfit: If an arbitrage opportunity exists, this method calculates the potential profit from placing bets on all outcomes.

convertOddsToDecimal: This method converts odds from various formats (such as fractional or American) to decimal odds for consistency in calculations.

normalizeProbabilities: This method normalizes the implied probabilities to ensure they sum up to 1, which is essential for arbitrage calculations.

calculateBettingAmounts: Given a total betting budget, this method calculates the optimal amount to bet on each outcome to maximize profit in an arbitrage situation.

adjustOddsForBookmakerMargin: Adjusts the odds to account for the bookmaker's margin, ensuring accurate calculations.

validateOdds: Checks the validity of the provided odds (e.g., ensuring they are within a reasonable range) to avoid erroneous calculations.

calculateExpectedValue: Calculates the expected value of a bet, considering both the probability of winning and the potential payout.

calculateReturnOnInvestment: Determines the return on investment for a given set of bets, considering the potential profit and the amount invested.*/
    public interface IArbitrageService
    {
        public decimal calculateImpliedProbability();

        public Boolean checkArbitrageOpportunity();

        public decimal calculateArbitrageProfit();

        public decimal convertOddsToDecimal();

        public void normalizeProbabilities();
        public void calculateBettingAmounts();
        public void adjustOddsForBookmakerMargin();

        public void validateOdds();
        public void calculateExpectedValue();
        public void calculateReturnOnInvestment();
    }
}
