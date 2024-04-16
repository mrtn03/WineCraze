using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WineCraze.Core.Constants.ViewModelsConstants;

namespace WineCraze.Core.Models.Inventory
{
    public class WineViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        [StringLength(WineViewModelMaxName)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Type field is required.")]
        [StringLength(WineViewModelMaxType)]
        public string Type { get; set; }

        [Required(ErrorMessage = "The Country field is required.")]
        [StringLength(WineViewModelMaxCountry)]
        public string Country { get; set; }

        [Required(ErrorMessage = "The Region field is required.")]
        [StringLength(WineViewModelMaxRegion)]
        public string Region { get; set; }

        [Required(ErrorMessage = "The CreatedOn field is required.")]
        public string CreatedOn { get; set; }

        [Required(ErrorMessage = "The Price field is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "The Price field must be greater than 0.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The Quantity field is required.")]
        public int Quantity { get; set; }
    }
}