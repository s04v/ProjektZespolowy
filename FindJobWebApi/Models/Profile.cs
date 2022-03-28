using System.ComponentModel.DataAnnotations;

namespace FindJobWebApi.Models
{
    public abstract class Profile
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string Desciption { get; set; }
    }
}
