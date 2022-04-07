using System.ComponentModel.DataAnnotations;

namespace FindJobWebApi.Models
{
    public class UserAddress : Address
    {
        [Key]
        public ulong UserAddressId { get; set; }
    }
}
