using System.ComponentModel.DataAnnotations;

namespace Stock_Market_WebAPI.Dtos.User
{
    public class CreateUserDto
    {
        [Required]
        public string? UserName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
