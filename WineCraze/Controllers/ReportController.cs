using Microsoft.AspNetCore.Mvc;

namespace WineCraze.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

// Summary - Generates various reports related to sales, inventory, and profit.