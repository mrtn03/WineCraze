using Microsoft.AspNetCore.Mvc;

namespace WineCraze.Controllers
{
    public class SalesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}


// Summary - Handles sales-related actions such as creating sales,
// viewing sales history, and generating sales reports.