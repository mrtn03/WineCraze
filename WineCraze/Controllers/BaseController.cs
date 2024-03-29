using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WineCraze.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {

    }
}
