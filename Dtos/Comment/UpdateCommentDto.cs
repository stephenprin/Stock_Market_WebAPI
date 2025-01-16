using System.ComponentModel.DataAnnotations;

namespace Stock_Market_WebAPI.Dtos.Comment
{
    public class UpdateCommentDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Title must be over 5 characters")]
        [MaxLength(100, ErrorMessage = "Title must not be over 100 characters")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MinLength(5, ErrorMessage = "Content must be over 5 characters")]
        [MaxLength(500, ErrorMessage = "Content must not be over 500 characters")]
        public string Content { get; set; } = string.Empty;
    }
}
