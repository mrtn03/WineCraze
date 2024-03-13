using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WineCraze.Infrastructure.Data.Models
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Comment("Name of Supplier")]
        [MaxLength(Constants.DataConstants.NameSupplierMaxLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Comment("Way for contact")]
        [MaxLength(Constants.DataConstants.ContactPersonSupplierMaxLength)]
        public string ContactPerson { get; set; } = string.Empty;

        [Required]
        [Comment("Email for Contact")]
        [MaxLength(Constants.DataConstants.EmailMaxLength)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Comment("Phone number for contact")]
        [MaxLength(Constants.DataConstants.PhoneMaxLength)]
        public string Phone { get; set; } = string.Empty;

        [Required]
        [Comment("Address of supplier")]
        [MaxLength(Constants.DataConstants.AddressMaxLength)]
        public string Address { get; set; } = string.Empty;

        public ICollection<Wine> Wines { get; set; } = new HashSet<Wine>(); 

    }
}

// Summary - Supplier entity contains information about a supplier.
