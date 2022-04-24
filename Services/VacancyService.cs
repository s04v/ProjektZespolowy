using AutoMapper;
using FindJobWebApi.DataBase;
using FindJobWebApi.DTOs;
using FindJobWebApi.Models;

namespace FindJobWebApi.Services
{
    public class VacancyService : IVacancyService
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;

        public VacancyService(AppDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public string AddNewVacancy(CreateVacancyDTO vacancyDTO)
        {
            var currentVacancy = _mapper.Map<Vacancy>(vacancyDTO);

            currentVacancy.UpdateTime = DateTime.Now;

            _context.Vacancies.Add(currentVacancy);
            _context.SaveChanges();

            return "OK";
        }
    }
}
