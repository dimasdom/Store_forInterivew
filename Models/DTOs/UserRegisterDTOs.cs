using System.ComponentModel.DataAnnotations;

namespace Store.Models.DTOs
{
    public class UserRegisterDTOs
    {
        [DataType("Email")]
        [Required]
        public string Email { get; set; }
        [Required]
        public string First_name { get; set; }
        [Required]
        public string Second_name { get; set; }
        [Required]
        [DataType("Password")]
        [MinLength(8)]
        [MaxLength(24)]
        public string Password { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [DataType("UserName")]
        public string UserName { get; set; }
    }
}
