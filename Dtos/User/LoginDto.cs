using System.ComponentModel.DataAnnotations;

namespace Stock_Market_WebAPI.Dtos.User
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
