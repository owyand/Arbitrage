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
    }
}
