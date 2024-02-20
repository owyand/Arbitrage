using Arbitrage.Models;
using Microsoft.AspNetCore.Mvc;

namespace Arbitrage.Controllers
{

    //this controller doesnt need any api calls it is all passed through from odds details
    public class BookmakerController : Controller
    {
        public IActionResult Index(IEnumerable<BookmakerModel> bookmakers)
        {
            return View(bookmakers);
        }
    }
}
