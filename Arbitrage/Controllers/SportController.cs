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
                //"List" but should only be one entry since we are finding by the game gameId
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
                return View(sportOdds);
            }

            // If the game with the provided id was not found, handle the scenario here
            return NotFound(); // For example, returning a "Not Found" page
        }
        public IActionResult BookmakerDetails(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound("ID cannot be null or empty.");
            }

            string? gameListJson = null;
            try
            {
                gameListJson = TempData["gameList"] as string;
                if (gameListJson == null)
                {
                    throw new Exception("TempData is null for 'gameList'.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving TempData: " + ex.Message + Environment.NewLine + ex.StackTrace);
                return StatusCode(500, "Internal server error.");
            }

            IEnumerable<OddsModel>? gameList = null;
            try
            {
                gameList = JsonConvert.DeserializeObject<IEnumerable<OddsModel>>(gameListJson);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deserializing gameListJson: " + ex.Message + Environment.NewLine + ex.StackTrace);
                return StatusCode(500, "Error deserializing data.");
            }

            if (gameList == null)
            {
                return NotFound("Game list is empty.");
            }

            var game = gameList.FirstOrDefault(g => g.Id == id);
            if (game == null)
            {
                return NotFound("Game not found.");
            }

            return View(game);
        }

        //public IActionResult BookmakerDetails(string id)
        //{
        //    if (string.IsNullOrEmpty(id))
        //    {
        //        return NotFound();
        //    }
        //    // Retrieve the JSON string from TempData and deserialize it

        //    string? gameListJson = null;
        //    try
        //    {
        //        gameListJson = TempData["gameList"] as string;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
        //    }

        //    IEnumerable<OddsModel>? gameList = null;
        //    if (gameListJson == null)
        //    {
        //        Console.WriteLine("Oh no");
        //    }
        //    else
        //    {
        //        gameList = JsonConvert.DeserializeObject<IEnumerable<OddsModel>>(gameListJson);
        //    }
        //    if (gameList == null)
        //    {
        //        throw new Exception("API call is null for GetOdds. Possible TempData serialization issues");
        //    }
        //    else
        //    {
        //        foreach (var game in gameList)
        //        {
        //            if (game.Id == id)
        //            {
        //                return View(game);
        //            }
        //        }
        //    }
        //    return NotFound();
        //}

        //find list of events for that sport
        //PassThroughAuthorizationHandler SportModel.key to the service layer to get the events
        //public IActionResult Details(int productId)
        //{
        //    Product product = _unitOfWork.ProductRepo.Get(u => u.Id == productId, includeProperties: "Category");
        //    return View(product);
        //}
    }
}
