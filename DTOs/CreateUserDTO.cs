using System.ComponentModel.DataAnnotations;

namespace FindJobWebApi.DTOs
{
    public class CreateUserDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(16)]
        public string Password { get; set; }

    }
}