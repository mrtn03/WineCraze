using Microsoft.AspNetCore.Mvc;

namespace WineCraze.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

// Summary - Manages customers, allowing for adding new customers, editing customer details,
// and viewing customer information.