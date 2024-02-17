using Arbitrage.Models;

namespace Arbitrage.Services.Interfaces
{
    public interface ISportsbookApiService
    {
        //Returns a list of upcoming and live games with recent odds for a given sport, region and market. Uses quota costs. provides game and odd info for a list of games/events
        Task<OddsModel> GetOdds(string sportKey);

        //Returns a list of in-season sport objects. The sport key can be used as the sport parameter in the /odds requests (below). This endpoint does not count against the usage quota.
        Task<IEnumerable<SportModel>> GetSports();

        //Returns a list of in-play and pre-match events for a specified sport or league. The response includes event id, home and away teams, and the commence time for each event. Odds are not included in the response. This endpoint does not count against the usage quota.
        Task<IEnumerable<EventModel>> GetEvents(string sportKey);

        //Returns a list of upcoming, live and recently completed games for a given sport. Live and recently completed games contain scores. Games from up to 3 days ago can be returned using the daysFrom parameter. Live scores update approximately every 30 seconds. Uses quota. only scores
        Task<IEnumerable<GameModel>> GetScores(string sportKey);
    }
}
