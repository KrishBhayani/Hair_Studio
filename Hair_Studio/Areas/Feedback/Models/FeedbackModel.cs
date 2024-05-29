using System;
using System.ComponentModel.DataAnnotations;

namespace Hair_Studio.Areas.Feedback.Models
{
    public class FeedbackModel
    {
        public int FeedbackID { get; set; }

        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]

        public string? Email { get; set; }
        [Required]
        public string? Phone { get; set; }
        [Required]
        public string? Comments { get; set; }
        [Required]
        public int? Rating { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}

