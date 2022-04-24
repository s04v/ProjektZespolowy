using System.ComponentModel.DataAnnotations;

namespace FindJobWebApi.Models
{
    public class UserAddress 
    {
        
        public ulong Id { get; set; }
        public string? Country { get; set; } = string.Empty;
        public string? City { get; set; } = string.Empty;
        public string? AddressFirst { get; set; } = string.Empty;
        public string? AddressSecond { get; set; } = string.Empty;
        public string? PostalCode { get; set; } = string.Empty;
    }
}
