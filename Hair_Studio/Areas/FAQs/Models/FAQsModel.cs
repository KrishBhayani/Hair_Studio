using System;
using System.ComponentModel.DataAnnotations;

namespace Hair_Studio.Areas.FAQs.Models
{
    public class FAQsModel
    {
        public int FAQID { get; set; }
        [Required]
        public string? Question { get; set; }
        [Required]
        public string? Answer { get; set; }
    }
}

