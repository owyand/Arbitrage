using Arbitrage.Models;
using Arbitrage.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
            if (sportOdds == null)
            {
                Console.WriteLine("sportEvents is null");
            }

            TempData["games"] = sportOdds;

            return View(sportOdds);
        }

        public IActionResult GameOdds(string id)
        {
            var games = TempData["PropertyName"] as IEnumerable<OddsModel>;
            if (games != null)
            {
                foreach (OddsModel game in games)
                {
                    if (game.Id == id)
                    {
                        // Found the game, redirect to the "Test" action of the "BookmakerController"
                        return RedirectToAction("Test", "Bookmaker");
                    }
                }
            }

            // If the game with the provided id was not found, handle the scenario here
            return NotFound(); // For example, returning a "Not Found" page
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
