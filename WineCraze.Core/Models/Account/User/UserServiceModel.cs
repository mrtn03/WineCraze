using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineCraze.Core.Models.Account.User
{
    public class UserServiceModel
    {
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Full Name")]
        public string FullName { get; set; } = string.Empty;

        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        public bool IsAgent { get; set; }
    }
}
