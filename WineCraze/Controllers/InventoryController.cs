using Microsoft.AspNetCore.Mvc;

namespace WineCraze.Controllers
{
    public class InventoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}


// Summary - Manages wine inventory, including adding, editing, and deleting wines.
