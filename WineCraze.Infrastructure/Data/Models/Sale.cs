using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WineCraze.Infrastructure.Data.Models
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Comment("Quantity of sales")]
        public int Quantity { get; set; }

        [Required]
        [Comment("Total sum of all sales")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }

        [Required]
        [Comment("Date of sales")]
        public DateTime SaleDate { get; set; }

        [Comment("Wine Identification")]
        public int WineId { get; set; }
        [ForeignKey(nameof(WineId))]
        public Wine Wine { get; set; } = null!;

        [Comment("Customer Identification")]
        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; } = null!;


    }
}

// Summary -  

// Idea is to use it to record sales made by customers, calculate total prices, and store sale dates.