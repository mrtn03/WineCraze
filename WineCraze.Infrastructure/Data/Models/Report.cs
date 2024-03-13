using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WineCraze.Infrastructure.Data.Models
{
    public class Report
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Comment("Title of Report")]
        [MaxLength(Constants.DataConstants.TitleMaxLength)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Comment("Description of Report")]
        [MaxLength(Constants.DataConstants.DescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("Date of creation")]
        public DateTime DateCreated { get; set; }
    }
}

// Summary -  Report entity has information about various reports.

// Idea for this entity is to use it to generate and save sales reports, inventory reports, or profit reports.