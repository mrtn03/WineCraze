using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WineCraze.Infrastructure.Data.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Comment("Name of Customer")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Comment("Email of Customer")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Comment("Address of Customer")]
        public string Address { get; set; } = string.Empty;

        [Required]
        [Comment("Phone number for contact of Customer")]
        public string PhoneNumber { get; set; } = string.Empty;

        // Additional properties as needed

        // Navigation properties
        // For example, if a customer has multiple sales

        public ICollection<Sale> Sales { get; set; } = new HashSet<Sale>();
    }
}

// Summary - Customer entity stores information about customers who purchase wines.

// Idea is to use it to record customer information when processing sales or managing customer accounts.
