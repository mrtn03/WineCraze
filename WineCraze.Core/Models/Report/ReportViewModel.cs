using System.ComponentModel.DataAnnotations;

namespace WineCraze.Core.Models.Report
{
    public class ReportViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd H:mm}")]
        public string DateCreated { get; set; } = string.Empty;
    }
}
