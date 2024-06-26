﻿using System.ComponentModel.DataAnnotations;

namespace WineCraze.Core.Models.Report
{
    public class ReportViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

     
        [Required(ErrorMessage = "The DateCreated field is required.")]
        public string DateCreated { get; set; }

    }
}
