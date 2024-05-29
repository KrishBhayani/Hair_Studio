    using System;
using System.ComponentModel.DataAnnotations;
namespace Hair_Studio.Areas.Appointment.Models
{
	public class AppointmentModel
	{
        public int AppointmentID { get; set; }
        [Required]
        public int ServiceID { get; set; }
        [Required]
        public DateTime AppointmentDate { get; set; }
        [Required]
        public DateTime AppointmentTime { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Phone { get; set; }
        
        public bool? Status { get; set; }
            
        public DateTime? Created { get; set; }

        public DateTime? Modifed { get; set; }
    }
}

