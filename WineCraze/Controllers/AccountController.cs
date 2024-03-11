using Microsoft.AspNetCore.Mvc;

namespace WineCraze.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

// Summary - Handles user authentication and authorization, including login,
// registration, and managing user roles.