using System.ComponentModel.DataAnnotations;

namespace MoviesTVShows.DTOs
{
    public class RegisterRequest
    {
        [Required]
        [EmailAddress]
        [StringLength(20)]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(20, MinimumLength = 5)]

        public string Password { get; set; } = null!;

        

    }
}
