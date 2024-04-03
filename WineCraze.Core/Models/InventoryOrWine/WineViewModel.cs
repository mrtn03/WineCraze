using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineCraze.Core.Models.InventoryOrWine
{
    public class WineViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Type field is required.")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        public string Type { get; set; }

        [Required(ErrorMessage = "The Country field is required.")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        public string Country { get; set; }

        [Required(ErrorMessage = "The Region field is required.")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        public string Region { get; set; }

        [Required(ErrorMessage = "The CreatedOn field is required.")]
        public string CreatedOn { get; set; }

        [Required(ErrorMessage = "The Price field is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "The Price field must be greater than 0.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The Quantity field is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "The Quantity field must be greater than 0.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "The ImageUrl field is required.")]
        [Url(ErrorMessage = "The ImageUrl field is not a valid URL.")]
        public string ImageUrl { get; set; }

        public int SupplierId { get; set; }
    }
}