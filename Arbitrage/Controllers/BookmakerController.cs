using Arbitrage.Models;
using Arbitrage.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Arbitrage.Controllers
{

    //this controller doesnt need any api calls it is all passed through from odds details
    public class BookmakerController : Controller
    {
        private readonly IBookmakerService _bookmakerService;
        private readonly ILogger _logger;

        public BookmakerController(ILogger<HomeController> logger, IBookmakerService bookmakerService)
        {
            _logger = logger;
            _bookmakerService = bookmakerService;
        }

        public async Task<IActionResult> Index(string query)
        {
            Console.WriteLine(query);
            IEnumerable<BookmakerModel> bookmakers = _bookmakerService.DeserializeBookmakers(query);

            return View(bookmakers);
        }

    }
}
