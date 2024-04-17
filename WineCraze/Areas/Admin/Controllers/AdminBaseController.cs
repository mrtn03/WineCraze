using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static WineCraze.Core.Constants.RoleConstants;

namespace WineCraze.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = AdminRole)]
    public class AdminBaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}