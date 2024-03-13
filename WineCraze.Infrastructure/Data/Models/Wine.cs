using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WineCraze.Infrastructure.Data.Models
{
    public class Wine
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [Comment("This is for the name of wine")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Comment("Description Of Wine and origin")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("Contry of origin")]
        public string Country { get; set; } = string.Empty;

        [Required]
        [Comment("Region where is created")]
        public string Region { get; set; } = string.Empty;

        [Required]
        [Comment("Year of origin")]
        public DateTime CreatedOn { get; set; }

        public decimal Price { get; set; }

        [Required]
        [Comment("Quantity of wines")]
        public int Quantity { get; set; }

        [Required]
        [Comment("Image of Wine")]
        public string ImageUrl { get; set; } = string.Empty;



        [Comment("Supplier Identification")]
        public int SupplierId { get; set; }
        [ForeignKey(nameof(SupplierId))]
        public Supplier Supplier { get; set; } = null!;


    }
}

//Summary -  Wine entity will represents store information about a wine. 
