using System;
namespace Hair_Studio.Areas.SEC_User.Models
{
    public class SEC_UserModel
    {

        public int UserID { get; set; }

        public string? UserName { get; set; }

        public string? Password { get; set; }

        public bool IsAdmin { get; set; }

        public string? ImageURL { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Modifed { get; set; }

    }
}

