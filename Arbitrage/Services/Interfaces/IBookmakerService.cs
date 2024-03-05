using Arbitrage.Models;

namespace Arbitrage.Services.Interfaces
{
    public interface IBookmakerService
    {
        public List<BookmakerModel> DeserializeBookmakers(string bookmakersString);
    }
}
