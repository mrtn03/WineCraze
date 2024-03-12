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
        public string Name { get; set; } = string.Empty;

        [Required]
        [Comment("Way for contact")]
        public string ContactPerson { get; set; } = string.Empty;

        [Required]
        [Comment("Email for Contact")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Comment("Phone number for contact")]
        public string Phone { get; set; } = string.Empty;

        [Required]
        [Comment("Address of supplier")]
        public string Address { get; set; } = string.Empty;

        //// Navigation property
        //// if a supplier has multiple wines
        public ICollection<Wine> Wines { get; set; } = new HashSet<Wine>(); 

    }
}

// Summary - Supplier entity contains information about a supplier.
