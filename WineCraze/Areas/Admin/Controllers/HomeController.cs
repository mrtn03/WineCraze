using Microsoft.AspNetCore.Mvc;

namespace WineCraze.Areas.Admin.Controllers
{
    public class HomeController  : AdminBaseController
    {
        public IActionResult DashBoard()
        {
            return View();
        }
    }
}
