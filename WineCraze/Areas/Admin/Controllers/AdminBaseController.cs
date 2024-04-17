using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static WineCraze.Core.Constants.RoleConstants;

namespace WineCraze.Areas.Admin.Controllers
{
    [Authorize]
    public class AdminBaseController : Controller
    {

    }
}