using System.ComponentModel.DataAnnotations;

namespace FindJobWebApi.Models
{
    public class User
    {
        
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime BirthdayDate { get; set; }
        public string ContactNumber { get; set; }
        public int UserAddressId { get; set; }
        public virtual UserAddress UserAddress { get; set; }
        public string Gender { get; set; }
        public float Experience { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Desciption { get; set; }
    }
}
