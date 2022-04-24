namespace FindJobWebApi.DTOs
{
    public class ModifyCompanyDTO
    {
        public string CompanyName { get; set; }
        public ulong CompanyAddressId { get; set; }
        public string Website { get; set; }
        public string Password { get; set; }
        public string Desciption { get; set; }
    }
}
