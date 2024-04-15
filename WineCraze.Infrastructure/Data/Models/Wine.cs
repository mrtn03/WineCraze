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
        [MaxLength(Constants.DataConstants.WineMaxLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Comment("Type Of Wine")]
        [MaxLength(Constants.DataConstants.TypeOfWine)]
        public string Type { get; set; } = string.Empty;

        [Required]
        [Comment("Contry of origin")]
        [MaxLength(Constants.DataConstants.CountryMaxLength)]
        public string Country { get; set; } = string.Empty;

        [Required]
        [Comment("Region where is created")]
        [MaxLength(Constants.DataConstants.RegionMaxLength)]
        public string Region { get; set; } = string.Empty;

        [Required]
        [Comment("Year of origin")]
        public string CreatedOn { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        [Comment("Quantity of wines")]
        public int Quantity { get; set; }

        [Required]
        [Comment("Image of Wine")]
        public string ImageUrl { get; set; } = string.Empty;

        public ICollection<Sale> Sales { get; set; } = new HashSet<Sale>();

        [Comment("Supplier Identification")]
        public int SupplierId { get; set; }
        [ForeignKey(nameof(SupplierId))]
        public Supplier Supplier { get; set; } = null!;

    }
}

//Summary -  Wine entity will represents store information about a wine. 
