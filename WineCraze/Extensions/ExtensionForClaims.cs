using System.Security.Claims;
using static WineCraze.Core.Constants.RoleConstants;

namespace WineCraze.Extensions
{
    public static class ExtensionForClaims
    {
        public static string Id(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            return user.IsInRole(AdminRole);
        }
    }
}