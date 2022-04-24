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

        public string ModifyVacancy(int id, CreateVacancyDTO vacancyDTO)
        {
            var vacancy = _context.Vacancies.SingleOrDefault(x => x.Id == id);
            if (vacancy == null) 
                return "Error";

            if (!string.IsNullOrEmpty(vacancyDTO.Title)) vacancy.Title = vacancyDTO.Title;
            if (!string.IsNullOrEmpty(vacancyDTO.Description)) vacancy.Description = vacancyDTO.Description;
            if (!string.IsNullOrEmpty(vacancyDTO.Requirements)) vacancy.Requirements = vacancyDTO.Requirements;
            if (!string.IsNullOrEmpty(vacancyDTO.Responsibilities)) vacancy.Responsibilities = vacancyDTO.Responsibilities;
            if (!string.IsNullOrEmpty(vacancyDTO.Salary.ToString())) vacancy.Salary = vacancyDTO.Salary;

            vacancy.UpdateTime = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);

            return "OK";
        }
    }
}
