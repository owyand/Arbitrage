﻿using Arbitrage.Models;

namespace Arbitrage.Services.Interfaces
{
    public interface ISportsbookApiService
    {
        Task<OddsModel> GetOdds();
        Task<IEnumerable<SportModel>> GetSports();
        Task<IEnumerable<EventModel>> GetEvents(string sportKey);
    }
}
