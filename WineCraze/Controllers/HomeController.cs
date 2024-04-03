using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WineCraze.Core.Contracts;
using WineCraze.Models;

namespace WineCraze.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWineService _wineService;

        public HomeController(ILogger<HomeController> logger, IWineService wineService)
        {
            _logger = logger;
            _wineService = wineService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            // Retrieve the last three wines asynchronously
            var model = await _wineService.GetLastThreeWinesAsync();

            // Pass the model to the view
            return View(model);
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            // Handle specific error statuses
            switch (statusCode)
            {
                case 400:
                    return View("Error400");
                case 401:
                    return View("Error401");
                default:
                    return View();
            }
        }
    }
}