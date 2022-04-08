using System.ComponentModel.DataAnnotations;

namespace FindJobWebApi.DTOs
{
    public class CreateCompanyDTO
    {
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
