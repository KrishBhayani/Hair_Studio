using System;
using System.ComponentModel.DataAnnotations;

namespace Hair_Studio.Areas.Service.Models
{
    public class ServiceModel
    {
        public int ServiceID { get; set; }
        [Required]
        public int StylistID { get; set; }
        [Required]
        public string? ServiceName { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public decimal? Price { get; set; }
        [Required]
        public string? ImageURL { get; set; }

        public IFormFile?ServiceImage { get; set; }
    }

    public class ServiceDropdownModel
    {

        [Required]
        public int ServiceID { get; set; }
        [Required]
        public string? ServiceName { get; set; }
    }
}

