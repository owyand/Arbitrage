using Arbitrage.Models;
using Arbitrage.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Arbitrage.Controllers
{
    public class SportController : Controller
    {
        private readonly ISportsbookApiService _sportsbookApiService;
        private readonly ILogger _logger;

        public SportController(ILogger<HomeController> logger, ISportsbookApiService sportsbookApiService)
        {
            _logger = logger;
            _sportsbookApiService = sportsbookApiService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<SportModel> data = await _sportsbookApiService.GetSports();

            return View(data);
        }

        public async Task<IActionResult> SportDetails(string sportKey)
        {
            IEnumerable<EventModel> sportEvents = await _sportsbookApiService.GetEvents(sportKey);
            if (sportEvents == null)
            {
                Console.WriteLine("sportEvents is null");
            }
            else
            {
                Console.WriteLine("sportEvents is not null");
            }
            return View(sportEvents);
        }

        public async Task<IActionResult> OddsDetails(string sportKey)
        {

            IEnumerable<OddsModel> sportOdds = await _sportsbookApiService.GetOdds(sportKey);

            try
            {
                TempData["gameList"] = JsonConvert.SerializeObject(sportOdds);

                TempData.Keep("gameList");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            if (sportOdds == null)
            {
                Console.WriteLine("sportEvents is null");
            }
            else
            {
                //get the header for request displayed here
                Console.WriteLine("sportEvents is not null");
            }
            return View(sportOdds);
        }

        public async Task<IActionResult> BookmakerDetails(string id)
        {

            // Retrieve the JSON string from TempData and deserialize it
            var gameListJson = TempData["gameList"] as string;
            var gameList = JsonConvert.DeserializeObject<IEnumerable<OddsModel>>(gameListJson);

            if (gameList == null)
            {
                throw new Exception("API call is null for GetOdds. Possible TempData serialization issues");
            }
            else
            {
                foreach (var game in gameList)
                {
                    if (game.Id == id)
                    {
                        return View(game);
                    }
                }
            }
            return NotFound();
        }

        //find list of events for that sport
        //PassThroughAuthorizationHandler SportModel.key to the service layer to get the events
        //public IActionResult Details(int productId)
        //{
        //    Product product = _unitOfWork.ProductRepo.Get(u => u.Id == productId, includeProperties: "Category");
        //    return View(product);
        //}
    }
}
