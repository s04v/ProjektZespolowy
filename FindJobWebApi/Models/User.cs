using System.ComponentModel.DataAnnotations;

namespace FindJobWebApi.Models
{
    public class User : Profile
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthdayDate { get; set; }
        public string ContactNumber { get; set; }
        [Required]
        public int UserAddressId { get; set; }
        public virtual UserAddress UserAddress { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public float Experience { get; set; }
    }
}
