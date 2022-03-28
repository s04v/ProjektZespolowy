using System.ComponentModel.DataAnnotations;

namespace FindJobWebApi.Models
{
    public abstract class Address
    {
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string AddressFirst { get; set; }
        public string AddressSecond { get; set; }
        public string PostalCode { get; set; }
    }
}
