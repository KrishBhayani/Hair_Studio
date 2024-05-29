using System;
using System.ComponentModel.DataAnnotations;
namespace Hair_Studio.Areas.Stylist.Models
{
    public class StylistModel
    {

        public int StylistID { get; set; }

        [Required]
        public string? StylistName { get; set; }
        [Required]
        public int ServiceID { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Phone { get; set; }
        [Required]
        public string? ImageURL { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Modifed { get; set; }


    }
}

