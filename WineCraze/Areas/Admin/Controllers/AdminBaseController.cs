using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static WineCraze.Core.Constants.AdminConstants;

namespace WineCraze.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRole)]
    public class AdminBaseController : Controller
    {

    }
}