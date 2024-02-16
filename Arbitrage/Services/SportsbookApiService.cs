using Arbitrage.Models;
using Arbitrage.Services.Interfaces;
using Newtonsoft.Json;

namespace Arbitrage.Services
{
    public class SportsbookApiService : ISportsbookApiService
    {
        private readonly HttpClient _httpClient;

        static string apiKey = "c92afe3bfe1458480e6f971207dfbfac";
        //static string sport = "americanfootball_nfl";
        //static string regions = "us";
        //static string markets = "h2h";

        public SportsbookApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<SportModel>> GetSports()
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"https://api.the-odds-api.com//v4/sports/?apiKey={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<SportModel>>(jsonResponse);
            }

            // Handle errors or return default data
            return null;
        }
        public async Task<OddsModel> GetOdds()
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"https://api.the-odds-api.com//v4/sports/?apiKey={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<OddsModel>(jsonResponse);
            }

            // Handle errors or return default data
            return null;
        }

        public async Task<IEnumerable<EventModel>> GetEvents(string sportKey)
        {

            HttpResponseMessage response = await _httpClient.GetAsync($"https://api.the-odds-api.com//v4/sports/{sportKey}/events?apiKey={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<EventModel>>(jsonResponse);
            }
            return null;
        }
    }

}
