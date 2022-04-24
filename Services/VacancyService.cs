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
            //var currentVacancy = _mapper.Map<Vacancy>(vacancyDTO);

            var currentVacancy = new Vacancy();

            currentVacancy.Id = _context.Vacancies.Count() > 0 ? _context.Vacancies.Max(x => x.Id) + 1 : 1;

            currentVacancy.CompanyId = vacancyDTO.CompanyId;

            var company = _context.Companies.FirstOrDefault(x => x.Id == vacancyDTO.CompanyId);
            if (company == null)
                return "error";

            currentVacancy.Company = company;

            currentVacancy.Title = vacancyDTO.Title;
            currentVacancy.Description = vacancyDTO.Description;
            currentVacancy.Requirements =  vacancyDTO.Requirements;
            currentVacancy.Responsibilities = vacancyDTO.Responsibilities;

            currentVacancy.UpdateTime = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);

            _context.Vacancies.Add(currentVacancy);
            _context.SaveChanges();

            return "OK";
        }
    }
}
