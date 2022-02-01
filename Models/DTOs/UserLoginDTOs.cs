using System.ComponentModel.DataAnnotations;

namespace Store.Models.DTOs
{
    public class UserLoginDTOs
    {
        [Required]
        [DataType("Email")]
        public string Email { get; set; }
        [Required]
        [DataType("Password")]
        [MinLength(8)]
        [MaxLength(24)]
        public string Password { get; set; }
    }
}
