using Microsoft.AspNetCore.Mvc;

namespace WineCraze.Controllers
{
    public class SupplierController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

// Summary - Manages suppliers, including adding new suppliers,
// updating supplier details, and viewing supplier information.