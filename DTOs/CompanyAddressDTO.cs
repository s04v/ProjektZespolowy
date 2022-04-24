namespace FindJobWebApi.DTOs
{
    public class CompanyAddressDTO
    {
        public ulong Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string AddressFirst { get; set; }
        public string AddressSecond { get; set; }
        public string PostalCode { get; set; }
    }
}
