using System.ComponentModel.DataAnnotations;

namespace WineCraze.Core.Models.Account
{
    public class UserRoleViewModel
    {
        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required]
        public string RoleName { get; set; } = string.Empty;
    }
}
