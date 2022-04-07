using System.ComponentModel.DataAnnotations;

namespace FindJobWebApi.Models
{
    public class FirmAddress : Address
    {
        [Key]
        public ulong FirmAddressId { get; set; }
    }
}
