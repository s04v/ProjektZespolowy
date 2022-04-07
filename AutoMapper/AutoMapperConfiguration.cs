using AutoMapper;
using FindJobWebApi.DTOs;
using FindJobWebApi.Models;

namespace FindJobWebApi.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static IMapper Initialize()
        {
            return new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<CreateCompanyDTO, Company>();
                    //cfg.CreateMap<Company, CreateCompanyDTO>().ReverseMap();
                }
            ).CreateMapper();
        }
    }
}
