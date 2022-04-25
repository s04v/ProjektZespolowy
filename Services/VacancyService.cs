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

        public string AddNewVacancy(int companyId, CreateVacancyDTO vacancyDTO)
        {
            var currentVacancy = _mapper.Map<Vacancy>(vacancyDTO);
            currentVacancy.CompanyId = companyId;
            currentVacancy.Id = _context.Vacancies.ToList().OrderBy(x => x.Id).Last().Id + 1;

            currentVacancy.UpdateTime = DateTime.SpecifyKind(DateTime.Now.Date + DateTime.Now.TimeOfDay, DateTimeKind.Utc);

            _context.Vacancies.Add(currentVacancy);
            _context.SaveChanges();

            return "OK";
        }

        public string ModifyVacancy(int id, ModifyVacancyDTO vacancyDTO)
        {
            var vacancy = _context.Vacancies.SingleOrDefault(x => x.Id == vacancyDTO.Id);
            if (vacancy == null || vacancy.CompanyId == id) 
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
