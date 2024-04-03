using System.ComponentModel.DataAnnotations;

namespace WineCraze.Core.Models.Sale
{
    public class SaleViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Customer")]
        public int CustomerId { get; set; }

        [Display(Name = "Supplier")]
        public int SupplierId { get; set; }

        [Display(Name = "Report")]
        public int ReportId { get; set; }

        [Display(Name = "Wine")]
        public int WineId { get; set; }

        public int Quantity { get; set; }

        [Display(Name = "Total Price")]
        public decimal TotalPrice { get; set; }
    }
}
