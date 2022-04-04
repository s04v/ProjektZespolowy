using System;
using System.ComponentModel.DataAnnotations;

namespace FindJobWebApi.Models
{
    public class Firm : Profile
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int FirmAddressId { get; set; }
        public virtual FirmAddress FirmAddress { get; set; }
        public string Website { get; set; }
    }
}
