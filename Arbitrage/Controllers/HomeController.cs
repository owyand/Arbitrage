using Arbitrage.Models;
using Arbitrage.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Arbitrage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISportsbookApiService _sportsbookApiService;

        public HomeController(ILogger<HomeController> logger, ISportsbookApiService sportsbookApiService)
        {
            _logger = logger;
            _sportsbookApiService = sportsbookApiService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> Sports()
        {
            IEnumerable<SportModel> data = await _sportsbookApiService.GetSports();

            return View(data);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}